# SimHub-to-F12020-UDP
[![Build](https://github.com/ducng99/SimHub-to-F12020-UDP/actions/workflows/build.yml/badge.svg)](https://github.com/ducng99/SimHub-to-F12020-UDP/actions/workflows/build.yml)

This app primary goal is to add more games support to Thrustmaster™ SF1000 wheel through its UDP connection. Some data will be modified to accomodate for some bugs the wheel has.

From SimHub app, this plugin will send UDP packets containing data in [F1 2020 format](https://web.archive.org/web/20221127112921/https://forums.codemasters.com/topic/50942-f1-2020-udp-specification/).

The data is fetched from SimHub without any other plugins so it is limited. Some functionalities on the wheel will not be available.

## Installation
- Download [latest SimHub](https://www.simhubdash.com/download-2/)
- Download [latest release](https://github.com/ducng99/SimHub-to-F12020-UDP/releases/latest)
- Extract the .dll file to SimHub folder (where SimHubWPF.exe file is)
- Start SimHub and enable the plugin when prompt (only once)

### Wheel config (firmware v5 and below only)

For firmware v5 and below, you need to configure your wheel to read UDP data. Please read [Thrustmasters guide](https://ts.thrustmaster.com/download/accessories/manuals/SF1000/FWheel_Add-On_Ferrari_SF1000Edition_User_Manual.pdf) on how to set it up.

![image](https://user-images.githubusercontent.com/49080794/226588068-e1735f09-33d2-47d3-87b5-c2e48364121b.png)

For firmware v6.27 and above, UDP is always enabled, you don't have to configure anything on the wheel

### Plugin config
- On your wheel settings, note the `IP: ` address showing under Wifi tab

![image](https://user-images.githubusercontent.com/49080794/226587920-0c0df4ba-760d-48c6-ac06-f9c4c73d8e24.png)

- In SimHub, go to `Additional plugins` -> `SimHub To F12020 UDP` tab -> Enter the IP above in "New IP" section -> Click `Save`

![image](https://github.com/ducng99/SimHub-to-F12020-UDP/assets/49080794/0a04a656-f3a4-463b-bf40-cfa286d4c199)

- Start your game and the wheel should show data.

## Issue
Any issues please report [here](https://github.com/ducng99/SimHub-to-F12020-UDP/issues/new/choose).

<!--
## Disclaimer
This application/project is not affiliated, associated, authorized, endorsed by, or in any way officially connected with Guillemot Corporation S.A, or any of its subsidiaries or its affiliate. Thrustmaster is a registered trademarks of Guillemot Corporation S.A.
-->
