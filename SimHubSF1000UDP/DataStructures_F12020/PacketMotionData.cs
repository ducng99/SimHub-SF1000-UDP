using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F12020;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketMotionData
{
    /**
     * <summary>Header</summary>
     */
    public PacketHeader m_header;

    /**
     * <summary>Data for all cars on track</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarMotionData[] m_carMotionData;

    // Extra player car ONLY data
    /**
     * <summary>Note: All wheel arrays have the following order:</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_suspensionPosition;

    /**
     * <summary>RL, RR, FL, FR</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_suspensionVelocity;

    /**
     * <summary>RL, RR, FL, FR</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_suspensionAcceleration;

    /**
     * <summary>Speed of each wheel</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelSpeed;

    /**
     * <summary>Slip ratio for each wheel</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_wheelSlip;
    
    /**
     * <summary>Velocity in local space</summary>
     */
    public float m_localVelocityX;
    
    /**
     * <summary>Velocity in local space</summary>
     */
    public float m_localVelocityY;
    
    /**
     * <summary>Velocity in local space</summary>
     */
    public float m_localVelocityZ;
    
    /**
     * <summary>Angular velocity x-component</summary>
     */
    public float m_angularVelocityX;
    
    /**
     * <summary>Angular velocity y-component</summary>
     */
    public float m_angularVelocityY;
    
    /**
     * <summary>Angular velocity z-component</summary>
     */
    public float m_angularVelocityZ;
    
    /**
     * <summary>Angular velocity x-component</summary>
     */
    public float m_angularAccelerationX;
    
    /**
     * <summary>Angular velocity y-component</summary>
     */
    public float m_angularAccelerationY;
    
    /**
     * <summary>Angular velocity z-component</summary>
     */
    public float m_angularAccelerationZ;
    
    /**
     * <summary>Current front wheels angle in radians</summary>
     */
    public float m_frontWheelsAngle;
};
