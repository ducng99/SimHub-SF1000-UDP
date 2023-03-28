using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

/*[StructLayout(LayoutKind.Sequential, Pack = 1)]
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
};*/

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CarTelemetryData
{
    public ushort m_speed;                         // Speed of car in kilometres per hour
    public float m_throttle;                      // Amount of throttle applied (0.0 to 1.0)
    public float m_steer;                         // Steering (-1.0 (full lock left) to 1.0 (full lock right))
    public float m_brake;                         // Amount of brake applied (0.0 to 1.0)
    public byte m_clutch;                        // Amount of clutch applied (0 to 100)
    public sbyte m_gear;                          // Gear selected (1-8, N=0, R=-1)
    public ushort m_engineRPM;                     // Engine RPM
    public byte m_drs;                           // 0 = off, 1 = on
    public byte m_revLightsPercent;              // Rev lights indicator (percentage)

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public ushort[] m_brakesTemperature;          // Brakes temperature (celsius)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_tyresSurfaceTemperature;    // Tyres surface temperature (celsius)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_tyresInnerTemperature;      // Tyres inner temperature (celsius)
    public ushort m_engineTemperature;             // Engine temperature (celsius)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_tyresPressure;              // Tyres pressure (PSI)
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_surfaceType;                // Driving surface, see appendices
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

