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


## Demo (optional)
Some photos or videos...

[![A video](https://img.youtube.com/vi/pnN55lJG_4c/0.jpg)](https://www.youtube.com/watch?v=pnN55lJG_4c)

## Weekly update
- Week 1
- Week 2
- ...

## ..
  
