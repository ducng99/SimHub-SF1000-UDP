using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CarSetupData
{
    /**
     * <summary>Front wing aero</summary>
     */
    public byte m_frontWing;
    
    /**
     * <summary>Rear wing aero</summary>
     */
    public byte m_rearWing;
    
    /**
     * <summary>Differential adjustment on throttle (percentage)</summary>
     */
    public byte m_onThrottle;
    
    /**
     * <summary>Differential adjustment off throttle (percentage)</summary>
     */
    public byte m_offThrottle;
    
    /**
     * <summary>Front camber angle (suspension geometry)</summary>
     */
    public float m_frontCamber;
    
    /**
     * <summary>Rear camber angle (suspension geometry)</summary>
     */
    public float m_rearCamber;
    
    /**
     * <summary>Front toe angle (suspension geometry)</summary>
     */
    public float m_frontToe;
    
    /**
     * <summary>Rear toe angle (suspension geometry)</summary>
     */
    public float m_rearToe;
    
    /**
     * <summary>Front suspension</summary>
     */
    public byte m_frontSuspension;
    
    /**
     * <summary>Rear suspension</summary>
     */
    public byte m_rearSuspension;
    
    /**
     * <summary>Front anti-roll bar</summary>
     */
    public byte m_frontAntiRollBar;
    
    /**
     * <summary>Front anti-roll bar</summary>
     */
    public byte m_rearAntiRollBar;
    
    /**
     * <summary>Front ride height</summary>
     */
    public byte m_frontSuspensionHeight;
    
    /**
     * <summary>Rear ride height</summary>
     */
    public byte m_rearSuspensionHeight;
    
    /**
     * <summary>Brake pressure (percentage)</summary>
     */
    public byte m_brakePressure;
    
    /**
     * <summary>Brake bias (percentage)</summary>
     */
    public byte m_brakeBias;
    
    /**
     * <summary>Rear left tyre pressure (PSI)</summary>
     */
    public float m_rearLeftTyrePressure;
    
    /**
     * <summary>Rear right tyre pressure (PSI)</summary>
     */
    public float m_rearRightTyrePressure;
    
    /**
     * <summary>Front left tyre pressure (PSI)</summary>
     */
    public float m_frontLeftTyrePressure;
    
    /**
     * <summary>Front right tyre pressure (PSI)</summary>
     */
    public float m_frontRightTyrePressure;
    
    /**
     * <summary>Ballast</summary>
     */
    public byte m_ballast;
    
    /**
     * <summary>Fuel load</summary>
     */
    public float m_fuelLoad;
};
