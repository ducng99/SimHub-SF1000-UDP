# SimHub SF1000 UDP
[![Build](https://github.com/ducng99/SimHub-SF1000-UDP/actions/workflows/build.yml/badge.svg)](https://github.com/ducng99/SimHub-SF1000-UDP/actions/workflows/build.yml)

> [!CAUTION]
> You are viewing version 2 of this plugin. It only supports SF1000 wheel with firmware v6.27 and above. If you have older firmware, please use [version 1](https://github.com/ducng99/SimHub-SF1000-UDP/tree/v1) instead.
> See [Thrustmaster SF1000 website](https://support.thrustmaster.com/en/product/ferrarisf1000addon-en/) for more information on how to update your wheel firmware.

> [!NOTE]
> This version is still in development and not ready for use.

This plugin primary goal is to add more games support to Thrustmaster™ SF1000 wheel through its UDP support for F1 games. Some data will be modified to accomodate for some bugs the wheel has.

From SimHub app, this plugin will send UDP packets containing data in [F1 23 UDP format](https://answers.ea.com/t5/General-Discussion/F1-23-UDP-Specification/td-p/12632888).

The data is fetched from SimHub without any other plugins so it is limited. Some functionalities on the wheel will not be available.

## Installation
- Download [latest SimHub](https://www.simhubdash.com/download-2/)
- Download [latest release](https://github.com/ducng99/SimHub-SF1000-UDP/releases/latest)
- Extract the .dll file to SimHub folder (where SimHubWPF.exe file is)
- Start SimHub and enable the plugin when prompted (only once)

## Configuration
### Wheel config

First thing, you need to configure Wi-Fi for your wheel, please go to [Thrustmaster SF1000 website](https://support.thrustmaster.com/en/product/ferrarisf1000addon-en/), and read instructions provided by them on how to set up UDP/Wi-Fi.
You should see these two files (you can ignore the steps for F1 games):

![image](https://github.com/ducng99/SimHub-SF1000-UDP/assets/49080794/ed9bae64-c6a0-4370-8645-0a99b2f79281)

- For firmware v5 and below, you need to configure your wheel to read UDP data. You need to do this everytime the wheel turns on. Please read [Thrustmaster's guide](https://ts.thrustmaster.com/download/accessories/manuals/SF1000/FWheel_Add-On_Ferrari_SF1000Edition_User_Manual.pdf) on how to set it up.

  ![image](https://user-images.githubusercontent.com/49080794/226588068-e1735f09-33d2-47d3-87b5-c2e48364121b.png)

- For firmware v6.27 and above, UDP is always enabled, you don't have to configure anything on the wheel. If the Wi-Fi screen shows `UDP: 20777` then you are good to go. If not, check your firmware version on Info screen.

### Plugin config
- On your wheel Wi-Fi screen, note the `IP: xxx.xxx.xxx.xxx` address line.

  ![image](https://user-images.githubusercontent.com/49080794/226587920-0c0df4ba-760d-48c6-ac06-f9c4c73d8e24.png)

- Open SimHub, go to `Additional plugins` -> `SimHub SF1000 UDP` tab -> Enter the IP shown above in "New IP" section -> Click `Save` button.

  ![image](https://github.com/ducng99/SimHub-SF1000-UDP/assets/49080794/0a04a656-f3a4-463b-bf40-cfa286d4c199)

- Start your game and the wheel should show data.

## Issue
Any issues please report [here](https://github.com/ducng99/SimHub-SF1000-UDP/issues/new/choose).

## Disclaimer
This application/project is not affiliated, associated, authorized, endorsed by, or in any way officially connected with Guillemot Corporation S.A, or any of its subsidiaries or its affiliate. Thrustmaster is a registered trademarks of Guillemot Corporation S.A.
