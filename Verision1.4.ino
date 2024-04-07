#include <SoftwareSerial.h>
#include "PubSubClient.h"
#include <ESP8266WiFi.h>
#include <NTPClient.h>
#include <WiFiUdp.h>
const char* mqtt_server = "broker.netpie.io";
const int mqtt_port = 1883;
const char* mqtt_client = "fc094a0a-6178-493f-9d4c-2b40299eae3b";
const char* mqtt_username = "nZJ38T9DmLER3fpG3KKgerm2qrWCrkqW";
const char* mqtt_password = "pvAx7k2Z8xh4t8GnXAUN6tAKap4DJnJa";
//const char* topic = "your/topic"; // Specify the topic you want to publish to
const char* SOCTopic = "@msg/SOC" ;
const char* TargetTime = "@msg/ttime" ;
const char* Timerequired = "@msg/Rtime" ;
const char* Feedback1 = "@msg/feedback1" ;
const char* Feedback2 = "@msg/feedback2" ;
const char* NCL1 = "@msg/NCL1" ;
const char* NCL2 = "@msg/NCL2" ;
const char* Emergency = "@msg/Emergency" ;
const char* ShadowTopic = "@shadow/data/update";
// ----- Wifi configuration---------------------
const char* ssid     = "Dr.PIEAS";       // WiFi ssid
const char* password = "12345678";   // WiFi password
// ----- For real time---------------
// Replace with your UTC offset in seconds
const long utcOffsetInSeconds = 25200; // For UTC+7 Thailand
WiFiUDP ntpUDP;
NTPClient timeClient(ntpUDP, "pool.ntp.org", utcOffsetInSeconds);
//-------------------------------------
WiFiClient espClient;
PubSubClient client(espClient);
SoftwareSerial EVSerial(D2, D3);
// ----- For Power Calculations---------------
int peakAllowedDemand = 10; //KW
float EVAllowedPower = 0;
float CLoad = 2;
float NCLoad1 = 0;
float NCLoad2 = 0;
float totalpowerconsumption = 0;
float totalenergyconsumption = 0;
int previousTime = 0;
float previouspower = 0;
int elapsedTime = 0;
// ----- For EV Charging SCheduling            ---------------
float ttime = 0;
int availabletime = 0;
int remainingTimeInSeconds;
int Peaktime1 = 18 * 3600;
int Peaktime2 = 22 * 3600;
float soc = 0;
int Batteryrating = 30;
float previousallowedpower = 0;
int timerequired = 0;
float previousSOC = 0;
//int targetTimeInSeconds=0;
//------------------------------------
bool EVConnected = false;
bool receivedConfirmation = false;
bool EmergencyCharge = false;
bool firstfeedback = false;
void setup_wifi() {
  delay(10);
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);

  if (WiFi.begin(ssid, password)) {
    while (WiFi.status() != WL_CONNECTED) {
      delay(500);
      Serial.print(".");
    }
  }
}
void reconnect() {
  while (!client.connected()) {
    Serial.print("Attempting MQTT connection...");
    if (client.connect(mqtt_client, mqtt_username, mqtt_password)) {
      Serial.println("connected");
      client.subscribe(TargetTime);
      client.subscribe(NCL1);
      client.subscribe(NCL2);
      client.subscribe(Emergency);
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      delay(2000);
    }
  }
}

void publishData(const char*topic, String data) {
  if (client.publish(topic, data.c_str())) {
    //Serial.println(data.c_str());
    // Serial.println("Data published successfully");
  } else {
    Serial.println("Failed to publish data");
  }
}
void powercalculation(unsigned long elapsedTime1) {

  //double power = voltage * Irms; // Calculate power
  double energy = (totalpowerconsumption * elapsedTime1) / 3600; // Calculate energy in Wh considering we can replace 3600 with 60 to consider 1h=1minute
  //Serial.println(elapsedTime1);
  // Serial.println(energy);
  totalenergyconsumption += energy;
  //Serial.println(totalenergyconsumption);
  // Check if 5 seconds have elapsed
  String consumption = "{\"data\" : {\"Power Consumed\" : " + String(totalpowerconsumption) + "," + "\"Energy Consumed\" : " + String(totalenergyconsumption) + "}}" ;
  //Serial.print("Sending --> ");
  //Serial.println(consumption);
  publishData(ShadowTopic, consumption);
}
void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  String message;
  for (int i = 0; i < length; i++) {
    message = message + (char)payload[i];
  }
  Serial.print(message);
  if (String(topic) == TargetTime) {
    String targetTimeStr = String((char*)payload);
    ttime = targetTimeStr.toFloat(); // Convert to float or appropriate data type
    publishData(Feedback1, String(ttime));
  }
  if (String(topic) == NCL1) {
    if (message == "ON") {
      NCLoad1 = 3;
    }
    else if (message == "OFF") {
      NCLoad1 = 0;
    }
  }
  if (String(topic) == NCL2) {
    if (message == "ON") {
      NCLoad2 = 2;
    }
    else if (message == "OFF") {
      NCLoad2 = 0;
    }
  }
  if (String(topic) == Emergency) {
    if (message == "ON") {
      EmergencyCharge = true;
    }
    else if (message == "OFF") {
      EmergencyCharge = false;
    }
  }
}

void setup() {
  Serial.begin(9600);
  EVSerial.begin(115200);
  while (!Serial);
  setup_wifi();
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);
  timeClient.begin();

}


void loop() {
  if (!client.connected()) {
    reconnect();
  }
  client.loop();
  timeClient.update();
  //client.setCallback(callback);
  int hours = timeClient.getHours();
  int minutes = timeClient.getMinutes();
  int seconds = timeClient.getSeconds();
  int currentTime = (hours * 3600) + (minutes * 60) + seconds;
  int targetTimeInSeconds = ttime * 3600;
  String tt = "TT: " + String(ttime);
  float load = CLoad + NCLoad1 + NCLoad2;
  //publishData(SOCTopic, tt);
  if (Serial.available()) {
    String data = Serial.readStringUntil('\n');
    Serial.println(data);
    if (data.startsWith("EV Con")) {
      EVConnected = true;
      receivedConfirmation = false; // Reset confirmation flag
    } else if (data.startsWith("Confirmation received")) {
      receivedConfirmation = true;
    } else if (data.startsWith("EV Dis")) {
      EVConnected = false;
      EVAllowedPower = 0;
      Serial.println("Power Allowed: " + String(EVAllowedPower));
      receivedConfirmation = false; // Reset confirmation flag
      publishData(SOCTopic, "EV Disconnected");
    } else if (data.startsWith("SOC:") && EVConnected == true) {
      String socstring = data.substring(4);
      soc = socstring.toFloat();
      //if (elapsedTime % 2 ==0 ) {
      // previousSOC = soc;
      publishData(SOCTopic, data);

    }
  }

  if (EVConnected) {
    if (targetTimeInSeconds >= currentTime) {
      remainingTimeInSeconds = targetTimeInSeconds - currentTime;
    } else {
      remainingTimeInSeconds = ((24 * 3600) - currentTime) + targetTimeInSeconds;
    }
    if (!EmergencyCharge) {
      if (currentTime >= Peaktime1 && currentTime <= Peaktime2) {
        EVAllowedPower = 0;
      }
      else
      {
        EVAllowedPower = peakAllowedDemand - load;
      }
    }
    if (EmergencyCharge) {
      EVAllowedPower = 15.84;
    }
    timerequired = ((((100 - soc) / 100) * Batteryrating) / EVAllowedPower) * 3600;
    String tr = String(timerequired);
    //publishData(Timerequired, tr);

    if (previousallowedpower != EVAllowedPower) {
      previousallowedpower = EVAllowedPower;
      receivedConfirmation = false;
    }

    if (currentTime <= Peaktime1 && targetTimeInSeconds >= Peaktime2 && !EmergencyCharge ) {
      availabletime = remainingTimeInSeconds - (Peaktime2 - Peaktime1);
    }
    else if (currentTime >= Peaktime1 && currentTime <= Peaktime2 && (targetTimeInSeconds >= Peaktime2 || targetTimeInSeconds <= Peaktime1) && !EmergencyCharge )
    {
      availabletime = remainingTimeInSeconds - (Peaktime2 - currentTime);
    }
    else {
      availabletime = remainingTimeInSeconds;
    }

    //if (availabletime <= timerequired && elapsedTime % 7 == 0) {
    // String feedback1 =  String(ttime) +":"+String(availabletime/3600) +":"+
    //                 String(soc + (((peakAllowedDemand - load) * (availabletime / 3600)) / Batteryrating));
    //String SocPossible=String(soc + ((EVAllowedPower * (availabletime / 3600)) / Batteryrating));
    //publishData(Feedback1,SocPossible);
    //firstfeedback=true;
    //}


    if (soc >= 95)
    {
      EVAllowedPower = 0;
      EVConnected = false;
      publishData(SOCTopic, "EV Fully Charged");
    }

    if (!receivedConfirmation && elapsedTime % 3 == 0) {
      Serial.println("Power Allowed: " + String(EVAllowedPower));
    }
  }

  if (previousTime == 0) {
    previousTime = currentTime;
  }

  elapsedTime = currentTime - previousTime;
  totalpowerconsumption = EVAllowedPower + load;

  if (elapsedTime >= 10 || previouspower != totalpowerconsumption) {
    previousTime = currentTime;
     if (EVConnected && availabletime <= timerequired) {
      float SocPossible = ((((EVAllowedPower *availabletime)/3600)/Batteryrating)*100)+soc ;
       // float SocPossible = soc + (((EVAllowedPower * (availabletime / 3600)) / Batteryrating) * 100);
        String feedback1 = "SOC Possible: " + String(SocPossible) + ". Turn ON Emergency Mode for Fast Charge.";
        publishData(Feedback1, feedback1);
    }
    //Serial.println(targetTimeInSeconds);
    previouspower = totalpowerconsumption;
    powercalculation(elapsedTime);
  }
}




