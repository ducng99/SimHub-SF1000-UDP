using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketMotionData
{
    public PacketHeader m_header;                  // Header

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarMotionData[] m_carMotionData;      // Data for all cars on track

    // Extra player car ONLY data
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_suspensionPosition;      // Note: All wheel arrays have the following order:
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_suspensionVelocity;      // RL, RR, FL, FR
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_suspensionAcceleration;  // RL, RR, FL, FR
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelSpeed;              // Speed of each wheel
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelSlip;               // Slip ratio for each wheel
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
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
};
