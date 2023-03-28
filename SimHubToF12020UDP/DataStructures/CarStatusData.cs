﻿using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CarStatusData
{
    public byte m_tractionControl;          // 0 (off) - 2 (high)
    public byte m_antiLockBrakes;           // 0 (off) - 1 (on)
    public byte m_fuelMix;                  // Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
    public byte m_frontBrakeBias;           // Front brake bias (percentage)
    public byte m_pitLimiterStatus;         // Pit limiter status - 0 = off, 1 = on
    public float m_fuelInTank;               // Current fuel mass
    public float m_fuelCapacity;             // Fuel capacity
    public float m_fuelRemainingLaps;        // Fuel remaining in terms of laps (value on MFD)
    public ushort m_maxRPM;                   // Cars max RPM, point of rev limiter
    public ushort m_idleRPM;                  // Cars idle RPM
    public byte m_maxGears;                 // Maximum number of gears
    public byte m_drsAllowed;               // 0 = not allowed, 1 = allowed, -1 = unknown


    // Added in Beta3:
    public ushort m_drsActivationDistance;    // 0 = DRS not available, non-zero - DRS will be available
                                              // in [X] metres

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_tyresWear;             // Tyre wear percentage
    public byte m_actualTyreCompound;     // F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1
                                          // 7 = inter, 8 = wet
                                          // F1 Classic - 9 = dry, 10 = wet
                                          // F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard
                                          // 15 = wet
    public byte m_visualTyreCompound;        // F1 visual (can be different from actual compound)
                                             // 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet
                                             // F1 Classic – same as above
                                             // F2 – same as above
    public byte m_tyresAgeLaps;             // Age in laps of the current set of tyres
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_tyresDamage;           // Tyre damage (percentage)
    public byte m_frontLeftWingDamage;      // Front left wing damage (percentage)
    public byte m_frontRightWingDamage;     // Front right wing damage (percentage)
    public byte m_rearWingDamage;           // Rear wing damage (percentage)

    // Added Beta 3:
    public byte m_drsFault;                 // Indicator for DRS fault, 0 = OK, 1 = fault

    public byte m_engineDamage;             // Engine damage (percentage)
    public byte m_gearBoxDamage;            // Gear box damage (percentage)
    public sbyte m_vehicleFiaFlags;          // -1 = invalid/unknown, 0 = none, 1 = green
                                             // 2 = blue, 3 = yellow, 4 = red
    public float m_ersStoreEnergy;           // ERS energy store in Joules
    public byte m_ersDeployMode;            // ERS deployment mode, 0 = none, 1 = medium
                                            // 2 = overtake, 3 = hotlap
    public float m_ersHarvestedThisLapMGUK;  // ERS energy harvested this lap by MGU-K
    public float m_ersHarvestedThisLapMGUH;  // ERS energy harvested this lap by MGU-H
    public float m_ersDeployedThisLap;       // ERS energy deployed this lap
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

