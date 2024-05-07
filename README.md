# Smart Residential Energy Meter For EV Charging
Bilal Ahmad

## Overview
This smart energy meter not only serves its fundamental purpose of billing data management but also facilitates the implementation of demand response management (DRM) at the user level. It achieves this by encouraging users to participate in DRM activities, such as turning off non-essential and non-critical loads. The project aims to integrate electric vehicles (EVs) into the system without overloading the existing power network. To achieve this, the grid assigns each consumer a sanctioned load, and the smart meter subsequently manages EV charging within that allocated limit. Additionally, the meter implements the concept of smart EV charging by scheduling EV charging during off-peak grid hours. Users can interact with the meter through a cloud platform, enabling them to monitor their consumption and EV charging data. Moreover, they can remotely control their loads according to their preferences and requirements.

![Alt text]([images/IOT Project.png](https://github.com/BilalAhmadPieas/Smart-Energy-Meter/blob/main/images/IOT%20Project.png?raw=true))

## Main components and their features:
- **The heater and the ventilator**--Actively controlling the temperature inside the chamber within the range of 20-40 degree C with an error that is less than 1 degree C.
- **The Humidifier/dehumidifier**--Activelt controlling the humidity level inside the chamber within the range of 25-75 percent with an error that is less than 5 percent.
- **The chamber**--insulated box with a volume of ca. 15 liters.
- **Control input buttons**--Consists of physical buttons to get input from the user.
- **A Display**--Showing the status and the temperature/humidity information.
- **Control software**--Monitor and control the climate in real-time. Any given temperature/humidity setting can be reached within max. 2 minutes regardless of the initial condition.

## Implementation
The final prototype uses a 60 Watt DC heat coil as a heater and a 90X90mm 12 DC fan as a ventilator. An off the shelf humidifier/dehumidifier unit from TGGS is used. These devices are connected to the controller via a relay board that can be turned on and off using the IO pin of the controller.

An LCD display and some pressed buttons are used to provide interface to the user. The LCD utilizes the i2c interface to the controller and the buttons are connected directly to the IO pins of the controller.

In additional, an AC to DC power supply is used to power the setting.

The selected controller is the Arduino Mega2650 board. The source code with detailed comment can be found in the file [climate_control.ino](https://github.com/chayakornn/Example_project_summary/blob/main/climate_control.ino)

## Demo (optional)
Some photos or videos...

[![A video](https://img.youtube.com/vi/pnN55lJG_4c/0.jpg)](https://www.youtube.com/watch?v=pnN55lJG_4c)

## Weekly update
- Week 1
- Week 2
- ...

## ..
  
