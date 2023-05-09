# SimHub-to-F12020-UDP
[![Build](https://github.com/ducng99/SimHub-to-F12020-UDP/actions/workflows/build.yml/badge.svg)](https://github.com/ducng99/SimHub-to-F12020-UDP/actions/workflows/build.yml)

From SimHub app, the plugin will send UDP packets containing data in [F1 2020 format](https://web.archive.org/web/20221127112921/https://forums.codemasters.com/topic/50942-f1-2020-udp-specification/).

This project is mainly for SF1000 wheel to work on unsupported games.

The data is fetched from SimHub without any other plugins so it is limited. Some functionalities on the wheel is not available

## Installation
- Download [latest SimHub](https://www.simhubdash.com/download-2/)
- Download [latest release](https://github.com/ducng99/SimHub-to-F12020-UDP/releases/latest)
- Extract the .dll file to SimHub folder
- Start SimHub and enable the plugin

### Wheel config

You need to configure your wheel to read UDP data. Please read [Thrustmasters guide](https://ts.thrustmaster.com/download/accessories/manuals/SF1000/FWheel_Add-On_Ferrari_SF1000Edition_User_Manual.pdf) on how to set it up.

Here is a hint:

![image](https://user-images.githubusercontent.com/49080794/226588068-e1735f09-33d2-47d3-87b5-c2e48364121b.png)

### Plugin config
- On your wheel settings, note the `IP: ` address showing under Wifi tab

![image](https://user-images.githubusercontent.com/49080794/226587920-0c0df4ba-760d-48c6-ac06-f9c4c73d8e24.png)

- In SimHub, go to `Additional plugins` -> `SimHub To F12020 UDP` tab -> Enter the IP above in "New IP" section -> Click `Save`

![image](https://user-images.githubusercontent.com/49080794/230552482-ff71c17a-f543-420e-8751-8ff05984a77a.png)

- Start your game and the wheel should show data.

## Issue
Any issues please report [here](https://github.com/ducng99/SimHub-to-F12020-UDP/issues/new/choose).
