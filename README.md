# SimHub SF1000 UDP
[![Build](https://github.com/ducng99/SimHub-SF1000-UDP/actions/workflows/build.yml/badge.svg)](https://github.com/ducng99/SimHub-SF1000-UDP/actions/workflows/build.yml)
[![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/ducng99/SimHub-SF1000-UDP/total?logo=github&label=Downloads&labelColor=333&color=196719)](https://github.com/ducng99/SimHub-SF1000-UDP/releases/latest)

This plugin's primary goal is to provide more games support to Thrustmaster™ SF1000 wheel, such as Assetto Corsa, through its support for F1 2020 & F1 23 games UDP.

Some functionalities on the wheel won't be available depending on the game you play. Also, the SF1000 wheel has bugs in its firmware, so some data will not be shown on the dash, most notably the ERS bar (I reported this and got no response so I guess we'll have to live with it).

<details>
  <summary>How it works (technical details?)</summary>
  <p>From SimHub app, this plugin will send UDP packets containing data in <a href="https://answers.ea.com/t5/General-Discussion/F1-23-UDP-Specification/td-p/12632888" target="_blank">F1 23 UDP format</a>, or <a href="https://web.archive.org/web/20221127112921/https://forums.codemasters.com/topic/50942-f1-2020-udp-specification/" target="_blank">F1 2020 UDP format</a>.</p>
  <p>Data comes directly from SimHub without any other plugins so it is limited.</p>
  <p>Some data is modified to adapt to some bugs in the wheel, and some will be dropped to avoid unnecessary data being transferred to the wheel (eg. weather).</p>
</details>

## Installation

- Download [latest SimHub](https://www.simhubdash.com/download-2/)
- Download [latest release](https://github.com/ducng99/SimHub-SF1000-UDP/releases/latest) (SimHubSF1000UDP_v*.zip)
- Open the zip file
- Extract the one file (*.dll) to your SimHub folder (where SimHubWPF.exe file is)
- Start SimHub and enable the plugin when prompted (only have to do once)
- Follow Configuration steps below

> [!NOTE]
> Starting from v2, this plugin supports `F1 2020` and `F1 23` UDP format. By default, `F1 23` UDP format is used, which only supports SF1000 wheel with firmware v6.27 and above.
>
> If your wheel does not show any data or has older firmware, you can switch to `F1 2020` format by opening `SimHub` -> `Additional plugins` -> `SimHub SF1000 UDP` tab -> UDP format dropdown -> Select `F1 2020` -> Click `Save` button.
>
> **(Recommended)** See [Thrustmaster SF1000 website](https://support.thrustmaster.com/en/product/ferrarisf1000addon-en/) for more information on how to check & update your wheel firmware.

## Configuration
### 1. Wheel config

- First thing, you need to configure Wi-Fi for your wheel, please go to [Thrustmaster SF1000 website](https://support.thrustmaster.com/en/product/ferrarisf1000addon-en/), and read instructions provided by them on how to set up UDP/Wi-Fi.
You should see these two files (you can ignore the steps for F1 games):

  ![image](https://github.com/ducng99/SimHub-SF1000-UDP/assets/49080794/ed9bae64-c6a0-4370-8645-0a99b2f79281)

- If your wheel's firmware is v5 and below (check on wheel's info screen), you need to configure your wheel to read UDP data. You need to do this everytime the wheel turns on. Please read [Thrustmaster's guide](https://ts.thrustmaster.com/download/accessories/manuals/SF1000/FWheel_Add-On_Ferrari_SF1000Edition_User_Manual.pdf) on how to set it up.

  ![image](https://user-images.githubusercontent.com/49080794/226588068-e1735f09-33d2-47d3-87b5-c2e48364121b.png)

- If you have firmware v6.27 and above, UDP is always enabled, you don't have to configure anything on the wheel. If the Wi-Fi screen shows `UDP: 20777` then you are good to go. If not, check your firmware version again on Info screen or check if Wi-Fi has been configured correctly.

### 2. Plugin config
- On your wheel Wi-Fi screen, note the `IP: xxx.xxx.xxx.xxx` address line.

  ![image](https://user-images.githubusercontent.com/49080794/226587920-0c0df4ba-760d-48c6-ac06-f9c4c73d8e24.png)

- Open SimHub, go to `Additional plugins` -> `SimHub SF1000 UDP` tab -> Enter the IP shown on your wheel in "New IP" section -> Click `Save` button.

  ![image](https://github.com/ducng99/SimHub-SF1000-UDP/assets/49080794/2f8eceac-2206-4f18-83ac-60f22471a2b4)

- Select your game in SimHub `Games` screen if you haven't already (if you have SimHub Licensed Edition then you don't have to manually select the game - not an ad).

- Start your game and the wheel should show the dash.

## Building

> [!NOTE]
> This section is for developers only, if you just want to use the plugin, follow [Installation](https://github.com/ducng99/SimHub-SF1000-UDP#installation) and [Configuration](https://github.com/ducng99/SimHub-SF1000-UDP#configuration)

### Requirements

- Visual Studio 2022 (recommended), other versions might work but not tested.
- .NET Framework 4.8

### Steps

1. Clone this repo
2. Open Visual Studio
3. SimHub libraries are included in this repo, so building should be straightforward as hitting build button.
4. A .dll file will be generated in `bin/Debug` or `bin/Release` folder, depending on your configuration selection.
5. Copy the built .dll file to SimHub directory.
6. Do whatever you want with the plugin

## Issues & suggestions
If you have any issues/questions or suggestions, please create an issue [here](https://github.com/ducng99/SimHub-SF1000-UDP/issues/new/choose).

## Disclaimer
This application/project is not affiliated, associated, authorized, endorsed by, or in any way officially connected with Guillemot Corporation S.A, or any of its subsidiaries or its affiliate. Thrustmaster is a registered trademarks of Guillemot Corporation S.A.

This application/project is not affiliated, associated, authorized, endorsed by, or in any way officially connected with Electronic Arts, or any of its subsidiaries or its affiliate.
