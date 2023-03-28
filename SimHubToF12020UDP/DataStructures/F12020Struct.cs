using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketHeader
{
    public ushort m_packetFormat;             // 2020
    public byte m_gameMajorVersion;         // Game major version - "X.00"
    public byte m_gameMinorVersion;         // Game minor version - "1.XX"
    public byte m_packetVersion;            // Version of this packet type, all start from 1
    public byte m_packetId;                 // Identifier for the packet type, see below
    public ulong m_sessionUID;               // Unique identifier for the session
    public float m_sessionTime;              // Session timestamp
    public uint m_frameIdentifier;          // Identifier for the frame the data was retrieved on
    public byte m_playerCarIndex;           // Index of player's car in the array

    // ADDED IN BETA 2: 
    public byte m_secondaryPlayerCarIndex;  // Index of secondary player's car in the array (splitscreen)
                                            // 255 if no second player
};

/*public struct CarMotionData
{
    public float m_worldPositionX;           // World space X position
    public float m_worldPositionY;           // World space Y position
    public float m_worldPositionZ;           // World space Z position
    public float m_worldVelocityX;           // Velocity in world space X
    public float m_worldVelocityY;           // Velocity in world space Y
    public float m_worldVelocityZ;           // Velocity in world space Z
    public short m_worldForwardDirX;         // World space forward X direction (normalised)
    public short m_worldForwardDirY;         // World space forward Y direction (normalised)
    public short m_worldForwardDirZ;         // World space forward Z direction (normalised)
    public short m_worldRightDirX;           // World space right X direction (normalised)
    public short m_worldRightDirY;           // World space right Y direction (normalised)
    public short m_worldRightDirZ;           // World space right Z direction (normalised)
    public float m_gForceLateral;            // Lateral G-Force component
    public float m_gForceLongitudinal;       // Longitudinal G-Force component
    public float m_gForceVertical;           // Vertical G-Force component
    public float m_yaw;                      // Yaw angle in radians
    public float m_pitch;                    // Pitch angle in radians
    public float m_roll;                     // Roll angle in radians
};

public unsafe struct PacketMotionData
{
    public PacketHeader m_header;                  // Header

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarMotionData[] m_carMotionData;      // Data for all cars on track

    // Extra player car ONLY data
    public fixed float m_suspensionPosition[4];      // Note: All wheel arrays have the following order:
    public fixed float m_suspensionVelocity[4];      // RL, RR, FL, FR
    public fixed float m_suspensionAcceleration[4];  // RL, RR, FL, FR
    public fixed float m_wheelSpeed[4];              // Speed of each wheel
    public fixed float m_wheelSlip[4];               // Slip ratio for each wheel
    public float m_localVelocityX;             // Velocity in local space
    public float m_localVelocityY;             // Velocity in local space
    public float m_localVelocityZ;             // Velocity in local space
    public float m_angularVelocityX;           // Angular velocity x-component
    public float m_angularVelocityY;           // Angular velocity y-component
    public float m_angularVelocityZ;           // Angular velocity z-component
    public float m_angularAccelerationX;       // Angular velocity x-component
    public float m_angularAccelerationY;       // Angular velocity y-component
    public float m_angularAccelerationZ;       // Angular velocity z-component
    public float m_frontWheelsAngle;           // Current front wheels angle in radians
};*/

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MarshalZone
{
    public float m_zoneStart;   // Fraction (0..1) of way through the lap the marshal zone starts
    public sbyte m_zoneFlag;    // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct WeatherForecastSample
{
    public byte m_sessionType;                     // 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 5 = Q1
                                                   // 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ, 10 = R, 11 = R2
                                                   // 12 = Time Trial
    public byte m_timeOffset;                      // Time in minutes the forecast is for
    public byte m_weather;                         // Weather - 0 = clear, 1 = light cloud, 2 = overcast
                                                   // 3 = light rain, 4 = heavy rain, 5 = storm
    public sbyte m_trackTemperature;                // Track temp. in degrees celsius
    public sbyte m_airTemperature;                  // Air temp. in degrees celsius
};

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

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LapData
{
    public float m_lastLapTime;               // Last lap time in seconds
    public float m_currentLapTime;            // Current time around the lap in seconds

    //UPDATED in Beta 3:
    public ushort m_sector1TimeInMS;           // Sector 1 time in milliseconds
    public ushort m_sector2TimeInMS;           // Sector 2 time in milliseconds
    public float m_bestLapTime;               // Best lap time of the session in seconds
    public byte m_bestLapNum;                // Lap number best time achieved on
    public ushort m_bestLapSector1TimeInMS;    // Sector 1 time of best lap in the session in milliseconds
    public ushort m_bestLapSector2TimeInMS;    // Sector 2 time of best lap in the session in milliseconds
    public ushort m_bestLapSector3TimeInMS;    // Sector 3 time of best lap in the session in milliseconds
    public ushort m_bestOverallSector1TimeInMS;// Best overall sector 1 time of the session in milliseconds
    public byte m_bestOverallSector1LapNum;  // Lap number best overall sector 1 time achieved on
    public ushort m_bestOverallSector2TimeInMS;// Best overall sector 2 time of the session in milliseconds
    public byte m_bestOverallSector2LapNum;  // Lap number best overall sector 2 time achieved on
    public ushort m_bestOverallSector3TimeInMS;// Best overall sector 3 time of the session in milliseconds
    public byte m_bestOverallSector3LapNum;  // Lap number best overall sector 3 time achieved on


    public float m_lapDistance;               // Distance vehicle is around current lap in metres – could
                                              // be negative if line hasn’t been crossed yet
    public float m_totalDistance;             // Total distance travelled in session in metres – could
                                              // be negative if line hasn’t been crossed yet
    public float m_safetyCarDelta;            // Delta in seconds for safety car
    public byte m_carPosition;               // Car race position
    public byte m_currentLapNum;             // Current lap number
    public byte m_pitStatus;                 // 0 = none, 1 = pitting, 2 = in pit area
    public byte m_sector;                    // 0 = sector1, 1 = sector2, 2 = sector3
    public byte m_currentLapInvalid;         // Current lap invalid - 0 = valid, 1 = invalid
    public byte m_penalties;                 // Accumulated time penalties in seconds to be added
    public byte m_gridPosition;              // Grid position the vehicle started the race in
    public byte m_driverStatus;              // Status of driver - 0 = in garage, 1 = flying lap
                                             // 2 = in lap, 3 = out lap, 4 = on track
    public byte m_resultStatus;              // Result status - 0 = invalid, 1 = inactive, 2 = active
                                             // 3 = finished, 4 = disqualified, 5 = not classified
                                             // 6 = retired
};

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketLapData
{
    public PacketHeader m_header;             // Header

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public LapData[] m_lapData;        // Lap data for all cars on track
};

/*public unsafe struct FastestLap
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
};*/

public struct ParticipantData
{
    public byte m_aiControlled;            // Whether the vehicle is AI (1) or Human (0) controlled
    public byte m_driverId;                // Driver id - see appendix
    public byte m_teamId;                  // Team id - see appendix
    public byte m_raceNumber;              // Race number of the car
    public byte m_nationality;             // Nationality of the driver
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
    public char[] m_name;                  // Name of participant in UTF-8 format – null terminated
                                           // Will be truncated with … (U+2026) if too long
    public byte m_yourTelemetry;           // The player's UDP setting, 0 = restricted, 1 = public
};

public struct PacketParticipantsData
{
    public PacketHeader m_header;           // Header

    public byte m_numActiveCars;  // Number of active cars in the data – should match number of
                                  // cars on HUD
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public ParticipantData[] m_participants;
};

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

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketCarTelemetryData
{
    public PacketHeader m_header;         // Header

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarTelemetryData[] m_carTelemetryData;

    public uint m_buttonStatus;        // Bit flags specifying which buttons are being pressed
                                       // currently - see appendices

    // Added in Beta 3:
    public byte m_mfdPanelIndex;       // Index of MFD panel open - 255 = MFD closed
                                       // Single player, race – 0 = Car setup, 1 = Pits
                                       // 2 = Damage, 3 =  Engine, 4 = Temperatures
                                       // May vary depending on game mode
    public byte m_mfdPanelIndexSecondaryPlayer;   // See above
    public sbyte m_suggestedGear;       // Suggested gear for the player (1-8)
                                        // 0 if no gear suggested
};

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

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketCarStatusData
{
    public PacketHeader m_header;           // Header

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarStatusData[] m_carStatusData;
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

