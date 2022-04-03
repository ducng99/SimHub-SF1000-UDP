# SimHub-to-F12020-UDP
From SimHub app, the plugin will send UDP packets containing data in [F1 2020 format](https://forums.codemasters.com/topic/50942-f1-2020-udp-specification/).

This project is mainly for SF1000 wheel to work on other games.

The data is fetched from SimHub without any other plugins so it is limited. Some functionalities on the wheel is not available

## Installation
- Download [latest release](/ducng99/SimHub-to-F12020-UDP/releases/latest)
- Extract the .dll file to SimHub folder
- Start SimHub and enable the plugin

You need to configure your wheel to read UDP data. Read Thrustmasters guide on how to set it up.

- On your wheel settings, note the `IP: ` address showing under Wifi tab
- In SimHub, go to `Additional plugins` -> `F12020 UDP Broadcast` tab -> Enter the IP above -> Click `Save`
- Start your game and the wheel should show data.

Any issues please create a report.