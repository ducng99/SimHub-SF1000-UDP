using System.Runtime.InteropServices;

namespace SimHubToF12020UDP
{
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

}
