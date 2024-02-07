# SimHub SF1000 UDP
[![Build](https://github.com/ducng99/SimHub-SF1000-UDP/actions/workflows/build.yml/badge.svg)](https://github.com/ducng99/SimHub-SF1000-UDP/actions/workflows/build.yml)
[![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/ducng99/SimHub-SF1000-UDP/total?logo=github&label=Downloads&labelColor=333&color=196719)](https://github.com/ducng99/SimHub-SF1000-UDP/releases)

This plugin primary goal is to add more games support to Thrustmaster™ SF1000 wheel through its support for F1 2020 & F1 23 games UDP.

Some data will be modified to accomodate for some bugs the wheel has, and some will be dropped to avoid unnecessary data being transferred to the wheel (eg. weather).

Some functionalities on the wheel will not be available depends on the game you are playing. SF1000 wheel has bugs in its firmware, so some data will not be shown on the wheel, most notably the ERS bar (I reported this and got no response so I guess we'll have to live with it).

<details>
  <summary>How it works (technical details?)</summary>
  <p>From SimHub app, this plugin will send UDP packets containing data in <a href="https://answers.ea.com/t5/General-Discussion/F1-23-UDP-Specification/td-p/12632888" target="_blank">F1 23 UDP format</a>, or <a href="https://web.archive.org/web/20221127112921/https://forums.codemasters.com/topic/50942-f1-2020-udp-specification/" target="_blank">F1 2020 UDP format</a>.</p>
  <p>Data comes directly from SimHub without any other plugins so it is limited.</p>
</details>

## Installation

- Download [latest SimHub](https://www.simhubdash.com/download-2/)
- Download [latest release](https://github.com/ducng99/SimHub-SF1000-UDP/releases/latest) (SimHubSF1000UDP_v*.zip)
- Open the zip file
- Extract the one file (*.dll) to your SimHub folder (where SimHubWPF.exe file is)
- Start SimHub and enable the plugin when prompted (only have to do once)

> [!CAUTION]
> Please check if you have installed v1.* previously, remove file `SimHubToF12020UDP.dll` from SimHub folder before installing v2 - which has a new name `SimHubSF1000UDP.dll`.

> [!NOTE]
> Starting from v2, this plugin supports `F1 2020` and `F1 23` UDP format. By default, `F1 23` UDP format is used, which supports SF1000 wheel with firmware v6.27 and above.
>
> If your wheel does not show any data or has older firmware, go to `Additional plugins` -> `SimHub SF1000 UDP` tab -> UDP format dropdown -> Select `F1 2020` -> Click `Save` button.
>
> **(Recommended)** See [Thrustmaster SF1000 website](https://support.thrustmaster.com/en/product/ferrarisf1000addon-en/) for more information on how to check & update your wheel firmware.

## Configuration
### 1. Wheel config

First thing, you need to configure Wi-Fi for your wheel, please go to [Thrustmaster SF1000 website](https://support.thrustmaster.com/en/product/ferrarisf1000addon-en/), and read instructions provided by them on how to set up UDP/Wi-Fi.
You should see these two files (you can ignore the steps for F1 games):

![image](https://github.com/ducng99/SimHub-SF1000-UDP/assets/49080794/ed9bae64-c6a0-4370-8645-0a99b2f79281)

- For firmware v5 and below, you need to configure your wheel to read UDP data. You need to do this everytime the wheel turns on. Please read [Thrustmaster's guide](https://ts.thrustmaster.com/download/accessories/manuals/SF1000/FWheel_Add-On_Ferrari_SF1000Edition_User_Manual.pdf) on how to set it up.

  ![image](https://user-images.githubusercontent.com/49080794/226588068-e1735f09-33d2-47d3-87b5-c2e48364121b.png)

- For firmware v6.27 and above, UDP is always enabled, you don't have to configure anything on the wheel. If the Wi-Fi screen shows `UDP: 20777` then you are good to go. If not, check your firmware version on Info screen.

### 2. Plugin config
- On your wheel Wi-Fi screen, note the `IP: xxx.xxx.xxx.xxx` address line.

  ![image](https://user-images.githubusercontent.com/49080794/226587920-0c0df4ba-760d-48c6-ac06-f9c4c73d8e24.png)

- Open SimHub, go to `Additional plugins` -> `SimHub SF1000 UDP` tab -> Enter the IP shown above in "New IP" section -> Click `Save` button.

  ![image](https://github.com/ducng99/SimHub-SF1000-UDP/assets/49080794/2f8eceac-2206-4f18-83ac-60f22471a2b4)

- Start your game and the wheel should show data.

## Building
### Requirements

- Visual Studio 2022 (recommended), other versions might work but not tested.
- .NET Framework 4.8

### Steps

1. SimHub libraries are included in this repo, so building should be straightforward as hitting build button. A .dll file will be generated in `bin/Debug` or `bin/Release` folder, depending on your configuration selection.
2. You know what to do next.

## Issue
Any issues please report [here](https://github.com/ducng99/SimHub-SF1000-UDP/issues/new/choose).

## Disclaimer
This application/project is not affiliated, associated, authorized, endorsed by, or in any way officially connected with Guillemot Corporation S.A, or any of its subsidiaries or its affiliate. Thrustmaster is a registered trademarks of Guillemot Corporation S.A.

This application/project is not affiliated, associated, authorized, endorsed by, or in any way officially connected with Electronic Arts, or any of its subsidiaries or its affiliate.
