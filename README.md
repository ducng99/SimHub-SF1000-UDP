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

## Scavenged structures 

```CSharp
    /*public unsafe struct FinalClassificationData
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
    };*/
```