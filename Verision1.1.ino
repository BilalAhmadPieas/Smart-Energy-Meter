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
float CLconsumption = 2;
float totalpowerconsumption = 0;
float totalenergyconsumption = 0;
unsigned long previousTime = 0;
float previouspower=0;
// -----             ---------------
bool EVConnected = false;
bool receivedConfirmation = false;
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
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      delay(5000);
    }
  }
}

void publishData(const char*topic, String data) {
  if (client.publish(topic, data.c_str())) {
    Serial.println("Data published successfully");
  } else {
    Serial.println("Failed to publish data");
  }
}
void powercalculation() {
  
  //double power = voltage * Irms; // Calculate power
  double energy = totalpowerconsumption * (30 / 1000.0 / 3600.0); // Calculate energy in Wh
  totalenergyconsumption += energy;
// Check if 5 seconds have elapsed
    String power = "{\"data\" : {\"Power Consumed\" : ";
    power += String(totalpowerconsumption, 2); // Format with 2 decimal places
    power += "}}";
    Serial.print("Sending --> ");
    Serial.println(power);
    publishData(ShadowTopic, power);
  }


void setup() {
  Serial.begin(9600);
  EVSerial.begin(115200);
  while (!Serial);
  setup_wifi();
  client.setServer(mqtt_server, mqtt_port);
  timeClient.begin();
  
}


void loop() {
  if (!client.connected()) {
    reconnect();
  }
  client.loop();
  timeClient.update();
  int hours = timeClient.getHours();
  int minutes = timeClient.getMinutes();
  int seconds=timeClient.getSeconds();
  long currentTime=(hours*3600)+(minutes*60)+seconds;
  // Print hours and minutes
  //Serial.print("Current Time: ");
  //Serial.println(hours);
  //Serial.print("Minutes: ");
  //Serial.println(minutes);
    //Serial.print("Seconds: ");
  //Serial.println(minutes);
    //Serial.print("Current Time In Seconds: ");
  //Serial.println(current_time);
  if (Serial.available()) { // Check for incoming serial data
    //String data = EVSerial.readStringUntil('\n');
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
      //EVSerial.println("Power Allowed: " + String(EVAllowedPower));
      receivedConfirmation = false; // Reset confirmation flag
    }
    else if (data.startsWith("SOC:")) {
      publishData(SOCTopic, data);
    }
  }

  if (EVConnected && !receivedConfirmation) {
    EVAllowedPower = peakAllowedDemand - CLconsumption ;
    Serial.println("Power Allowed: " + String(EVAllowedPower));
  }
   unsigned long elapsedTime = currentTime - previousTime;
totalpowerconsumption = EVAllowedPower + CLconsumption;
if (elapsedTime >= 30|| previouspower != totalpowerconsumption ) {
    previousTime = currentTime;
    previouspower = totalpowerconsumption;
    powercalculation();
}
}




