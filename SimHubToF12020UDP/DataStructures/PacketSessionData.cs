﻿using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketSessionData
{
    public PacketHeader m_header;                    // Header

    public byte m_weather;                   // Weather - 0 = clear, 1 = light cloud, 2 = overcast
                                             // 3 = light rain, 4 = heavy rain, 5 = storm
    public sbyte m_trackTemperature;          // Track temp. in degrees celsius
    public sbyte m_airTemperature;            // Air temp. in degrees celsius
    public byte m_totalLaps;                 // Total number of laps in this race
    public ushort m_trackLength;               // Track length in metres
    public byte m_sessionType;               // 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P
                                             // 5 = Q1, 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ
                                             // 10 = R, 11 = R2, 12 = Time Trial
    public sbyte m_trackId;                   // -1 for unknown, 0-21 for tracks, see appendix
    public byte m_formula;                   // Formula, 0 = F1 Modern, 1 = F1 Classic, 2 = F2,
                                             // 3 = F1 Generic
    public ushort m_sessionTimeLeft;           // Time left in session in seconds
    public ushort m_sessionDuration;           // Session duration in seconds
    public byte m_pitSpeedLimit;             // Pit speed limit in kilometres per hour
    public byte m_gamePaused;                // Whether the game is paused
    public byte m_isSpectating;              // Whether the player is spectating
    public byte m_spectatorCarIndex;         // Index of the car being spectated
    public byte m_sliProNativeSupport;     // SLI Pro support, 0 = inactive, 1 = active
    public byte m_numMarshalZones;           // Number of marshal zones to follow

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
    public MarshalZone[] m_marshalZones;          // List of marshal zones – max 21
    public byte m_safetyCarStatus;           // 0 = no safety car, 1 = full safety car
                                             // 2 = virtual safety car
    public byte m_networkGame;               // 0 = offline, 1 = online
    public byte m_numWeatherForecastSamples; // Number of weather samples to follow

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public WeatherForecastSample[] m_weatherForecastSamples;   // Array of weather forecast samples
};

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

