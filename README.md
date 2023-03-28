# SimHub-to-F12020-UDP
From SimHub app, the plugin will send UDP packets containing data in [F1 2020 format](https://web.archive.org/web/20221127112921/https://forums.codemasters.com/topic/50942-f1-2020-udp-specification/).

This project is mainly for SF1000 wheel to work on other games.

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

- In SimHub, go to `Additional plugins` -> `F12020 UDP Broadcast` tab -> Enter the IP above -> Click `Save`

![image](https://user-images.githubusercontent.com/49080794/226588749-75a1cd0d-40b3-46c6-8a01-9af35eaa0589.png)

- Start your game and the wheel should show data.

## Issue
Any issues please report [here](https://github.com/ducng99/SimHub-to-F12020-UDP/issues/new/choose).

## Unused data structures

```CSharp
public unsafe struct FinalClassificationData
{
    public byte m_position;              // Finishing position
    public byte m_numLaps;               // Number of laps completed
    public byte m_gridPosition;          // Grid position of the car
    public byte m_points;                // Number of points scored
    public byte m_numPitStops;           // Number of pit stops made
    public byte m_resultStatus;          // Result status - 0 = invalid, 1 = inactive, 2 = active
                                  // 3 = finished, 4 = disqualified, 5 = not classified
                                  // 6 = retired
    public float m_bestLapTime;           // Best lap time of the session in seconds
    public double m_totalRaceTime;         // Total race time in seconds without penalties
    public byte m_penaltiesTime;         // Total penalties accumulated in seconds
    public byte m_numPenalties;          // Number of penalties applied to this driver
    public byte m_numTyreStints;         // Number of tyres stints up to maximum
    public fixed byte m_tyreStintsActual[8];   // Actual tyres used by this driver
    public fixed byte m_tyreStintsVisual[8];   // Visual tyres used by this driver
};
public unsafe struct PacketFinalClassificationData
{
    public PacketHeader m_header;                             // Header

    public byte m_numCars;                 // Number of cars in the final classification
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public FinalClassificationData[] m_classificationData;
};
```