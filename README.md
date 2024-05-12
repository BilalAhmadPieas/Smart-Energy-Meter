# Smart Residential Energy Meter For EV Charging
Bilal Ahmad

## Overview
This smart energy meter not only serves its fundamental purpose of billing data management but also facilitates the implementation of demand response management (DRM) at the user level. It achieves this by encouraging users to participate in DRM activities, such as turning off non-essential and non-critical loads. The project aims to integrate electric vehicles (EVs) into the system without overloading the existing power network. To achieve this, the grid assigns each consumer a sanctioned load, and the smart meter subsequently manages EV charging within that allocated limit. Additionally, the meter implements the concept of smart EV charging by scheduling EV charging during off-peak grid hours. Users can interact with the meter through a cloud platform, enabling them to monitor their consumption and EV charging data. Moreover, they can remotely control their loads according to their preferences and requirements. The user input the time when charged EV is required and then control check whether EV can be charged in availalable time and if not how much SOC% is possible and looking at his driving profile user can choose relevent option.

![Alt text](https://github.com/BilalAhmadPieas/Smart-Energy-Meter/blob/9a83cd9a00d45e2ae4f4ca3d674ac924762f2cfa/images/IOT%20Project%20(1).png)

## Main components and their features:
- **EV Charger**-- Charge EV at power allowed by smart meter and feedback SOC% value.
- **ESP Controller**--Acting as smart meter, implement smart charging and load control.
- **NetPie Cloud**--For monitoring and remote load control.
- **Solid State Relay**--For implementing load control.

## Implementation

The final prototype functions as a smart meter, regulating the power allocated for EV charging in conjunction with other residential loads and grid conditions.

When the EV is not connected, the prototype offers remote load monitoring and control. It encourages user participation in Demand Response Management (DRM) by suggesting the deactivation of non-critical loads during peak grid times.
Upon EV connection, the user inputs a target time using a 24-hour slider on the cloud platform. Considering the running load, sanctioned load limit, and grid conditions, the smart meter's controller specifies the charging power for the EV and provides feedback to the user regarding whether the EV can be fully charged within the available time. If not, it offers insights into the possible State of Charge (SOC) percentage achievable within the timeframe. If feasible, it estimates the remaining time required for a full charge.

Based on the user's driving profile, they can choose to accept the projected SOC or deactivate non-critical loads. Additionally, the user has the option to activate emergency EV charging, wherein the meter allows the EV charger to operate at increased pricing without time or power limitations.

A real-time clock utilizing an NTP server is integrated into the project to ensure precise calculations relative to actual time. During peak grid times when emergency charging is deactivated, the meter suspends EV charging until the peak period concludes, resuming afterward. The available time algorithm exclusively considers off-peak periods for charging.
In the Node MCU 12-E, we utilize an OLED screen to display real-time power and energy consumption data. For the prototype, an EV charger is emulated in Visual Basic, receiving power commands from the ESP via the serial port and subsequently charging the EV battery. Utilizing elapsed time concepts, the charger sends updated SOC percentage values to the controller.
The ESP is connected to the Netpie cloud via WiFi, transmitting data at specific intervals to prevent communication traffic overload. On the Netpie cloud platform, we showcase EV SOC percentages alongside power and energy consumption data, offering control over loads and target time sliders.


## Demo 
[![A video](https://pern-my.sharepoint.com/personal/bsee1741_pieas_edu_pk/_layouts/15/stream.aspx?id=%2Fpersonal%2Fbsee1741%5Fpieas%5Fedu%5Fpk%2FDocuments%2FDocuments%2FMS%20ECE%2FMS%202nd%20Semester%2FIoT%2FSmart%20Meter%20Demo%2Emp4&nav=eyJyZWZlcnJhbEluZm8iOnsicmVmZXJyYWxBcHAiOiJPbmVEcml2ZUZvckJ1c2luZXNzIiwicmVmZXJyYWxBcHBQbGF0Zm9ybSI6IldlYiIsInJlZmVycmFsTW9kZSI6InZpZXciLCJyZWZlcnJhbFZpZXciOiJNeUZpbGVzTGlua0NvcHkifX0&ga=1&referrer=StreamWebApp%2EWeb&referrerScenario=AddressBarCopied%2Eview%2Eb9279fee%2Dec07%2D4171%2D8fba%2Ddac334d66996)

## Weekly update
- Week 1: I learned visual basics and how we can simulate various models in it. Than I modeled EV Charger and Battery charging in Visual basics, which take input of EV Allowed Power from ESP and Feedback battery SOC% after certain inverval. 
- Week 2: In this week i tried to implement HPLC communication between ESp and Visual basics and send basic power allowed command to control charging and get SOC% as feed back in ESP.
- Week 3: I started with basics for cloud, and was albe to display SOC of EV Battery Received from Simulator on Netpie Cloud Using Wifi and ESp module.Next week I plan to work on controlling EV cahrging through cloud and also defining EV charging scheduling algorithm.
- Week 4: I was able to control EV Charging, get back EV SOC from Visual basics,Develop Power and energy consumed logic for meter, Display EV SOC and Power Consumed on cloud. also have introduced real time clock for Ev scheduling.
- Week 5: I worked on EV scheduling procedure and off peak time charging algorithm. In Next week my fist focus is to optimize my code performance espacially in term of communication and introduce emergency charging feature for charging.
- Week 6: I worked on the optimization of of my code performance and also introduced the emergency charging function.
- Week 7: I worked on introducing non critical loads and their control through cloud platform. I also developed a feed back process that if the available time before target time is less than the time reqired to charge the ev, then the user will be informed about how much ev would be charged in available time, and if he wants to get more soc he need to either turn off non critical loads or turn on emergency charging.In next week i plan to introduce the simulation of non critical loads just for the display and then work on my netpie cloud user interface and setting.
- Week 8: I worked on UI setting to make it more catchy,also i fixed some bugs in my code regarding available time calculation.Another addition was to introduce the display of remaining time to fully charge EV.
- Week 9:I am working on my demo prototype, making a stand and displaying control of loads using relays and controller.
- week 10: Working on Power consumption data display on OLED.
  
