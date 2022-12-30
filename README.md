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

### Classification structures

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
    
### Car setup data
```
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarSetupData
    {
        public byte m_frontWing;                // Front wing aero
        public byte m_rearWing;                 // Rear wing aero
        public byte m_onThrottle;               // Differential adjustment on throttle (percentage)
        public byte m_offThrottle;              // Differential adjustment off throttle (percentage)
        public float m_frontCamber;              // Front camber angle (suspension geometry)
        public float m_rearCamber;               // Rear camber angle (suspension geometry)
        public float m_frontToe;                 // Front toe angle (suspension geometry)
        public float m_rearToe;                  // Rear toe angle (suspension geometry)
        public byte m_frontSuspension;          // Front suspension
        public byte m_rearSuspension;           // Rear suspension
        public byte m_frontAntiRollBar;         // Front anti-roll bar
        public byte m_rearAntiRollBar;          // Front anti-roll bar
        public byte m_frontSuspensionHeight;    // Front ride height
        public byte m_rearSuspensionHeight;     // Rear ride height
        public byte m_brakePressure;            // Brake pressure (percentage)
        public byte m_brakeBias;                // Brake bias (percentage)
        public float m_rearLeftTyrePressure;     // Rear left tyre pressure (PSI)
        public float m_rearRightTyrePressure;    // Rear right tyre pressure (PSI)
        public float m_frontLeftTyrePressure;    // Front left tyre pressure (PSI)
        public float m_frontRightTyrePressure;   // Front right tyre pressure (PSI)
        public byte m_ballast;                  // Ballast
        public float m_fuelLoad;                 // Fuel load
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarSetupData
    {
        public PacketHeader m_header;            // Header

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarSetupData[] m_carSetups;
    };
```

### Participant Data

```
    public unsafe struct FastestLap
    {
        public byte vehicleIdx; // Vehicle index of car achieving fastest lap
        public float lapTime;    // Lap time is in seconds
    }
;

    public unsafe struct Retirement
    {
        public byte vehicleIdx; // Vehicle index of car retiring
    }
;

    public unsafe struct TeamMateInPits
    {
        public byte vehicleIdx; // Vehicle index of team mate
    };

    public unsafe struct RaceWinner
    {
        public byte vehicleIdx; // Vehicle index of the race winner
    };

    public unsafe struct Penalty
    {

        public byte penaltyType;          // Penalty type – see Appendices
        public byte infringementType;     // Infringement type – see Appendices
        public byte vehicleIdx;           // Vehicle index of the car the penalty is applied to
        public byte otherVehicleIdx;      // Vehicle index of the other car involved
        public byte time;                 // Time gained, or time spent doing action in seconds
        public byte lapNum;               // Lap the penalty occurred on
        public byte placesGained;         // Number of places gained by this
    };

    public unsafe struct SpeedTrap
    {
        public byte vehicleIdx; // Vehicle index of the vehicle triggering speed trap
        public float speed;      // Top speed achieved in kilometres per hour
    };

    struct PacketEventData
    {
        PacketHeader    	m_header;             // Header

        byte               	m_eventStringCode[4]; // Event string code, see below
        EventDataDetails	m_eventDetails;       // Event details - should be interpreted differently
                                                    // for each type
    };
```