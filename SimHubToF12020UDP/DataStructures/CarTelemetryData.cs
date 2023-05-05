using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CarTelemetryData
{
    /**
     * <summary>Speed of car in kilometres per hour</summary>
     */
    public ushort m_speed;
    
    /**
     * <summary>Amount of throttle applied (0.0 to 1.0)</summary>
     */
    public float m_throttle;
    
    /**
     * <summary>Steering (-1.0 (full lock left) to 1.0 (full lock right))</summary>
     */
    public float m_steer;
    
    /**
     * <summary>Amount of brake applied (0.0 to 1.0)</summary>
     */
    public float m_brake;
    
    /**
     * <summary>Amount of clutch applied (0 to 100)</summary>
     */
    public byte m_clutch;
    
    /**
     * <summary>Gear selected (1-8, N=0, R=-1)</summary>
     */
    public sbyte m_gear;
    
    /**
     * <summary>Engine RPM</summary>
     */
    public ushort m_engineRPM;
    
    /**
     * <summary>0 = off, 1 = on</summary>
     */
    public byte m_drs;

    /**
     * <summary>Rev lights indicator (percentage)</summary>
     */
    public byte m_revLightsPercent;

    /**
     * <summary>Brakes temperature (celsius)</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public ushort[] m_brakesTemperature;

    /**
     * <summary>Tyres surface temperature (celsius)</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_tyresSurfaceTemperature;

    /**
     * <summary>Tyres inner temperature (celsius)</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_tyresInnerTemperature;

    /**
     * <summary>Engine temperature (celsius)</summary>
     */
    public ushort m_engineTemperature;

    /**
     * <summary>Tyres pressure (PSI)</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public float[] m_tyresPressure;

    /**
     * <summary>Driving surface, see appendices</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_surfaceType;
};
