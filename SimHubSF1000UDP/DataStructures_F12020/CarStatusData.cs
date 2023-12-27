using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F12020;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CarStatusData
{
    /**
     * <summary>0 (off) - 2 (high)</summary>
     */
    public byte m_tractionControl;

    /**
     * <summary>0 (off) - 1 (on)</summary>
     */
    public byte m_antiLockBrakes;

    /**
     * <summary>Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max</summary>
     */
    public byte m_fuelMix;

    /**
     * <summary>Front brake bias (percentage)</summary>
     */
    public byte m_frontBrakeBias;

    /**
     * <summary>Pit limiter status - 0 = off, 1 = on</summary>
     */
    public byte m_pitLimiterStatus;

    /**
     * <summary>Current fuel mass</summary>
     */
    public float m_fuelInTank;

    /**
     * <summary>Fuel capacity</summary>
     */
    public float m_fuelCapacity;

    /**
     * <summary>Fuel remaining in terms of laps (value on MFD)</summary>
     */
    public float m_fuelRemainingLaps;

    /**
     * <summary>Cars max RPM, point of rev limiter</summary>
     */
    public ushort m_maxRPM;

    /**
     * <summary>Cars idle RPM</summary>
     */
    public ushort m_idleRPM;

    /**
     * <summary>Maximum number of gears</summary>
     */
    public byte m_maxGears;

    /**
     * <summary>0 = not allowed, 1 = allowed, -1 = unknown</summary>
     */
    public byte m_drsAllowed;

    // Added in Beta3:
    /**
     * <summary>0 = DRS not available, non-zero - DRS will be available in [X] metres</summary>
     */
    public ushort m_drsActivationDistance;

    /**
     * <summary>Tyre wear percentage</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_tyresWear;

    /**
     * <summary>F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1,
     * 7 = inter, 8 = wet<br/>
     * F1 Classic - 9 = dry, 10 = wet,
     * F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard,
     * 15 = wet</summary>
     */
    public byte m_actualTyreCompound;

    /**
     * <summary>F1 visual (can be different from actual compound),
     * 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet<br/>
     * F1 Classic – same as above<br/>
     * F2 – same as above</summary>
     */
    public byte m_visualTyreCompound;

    /**
     * <summary>Age in laps of the current set of tyres</summary>
     */
    public byte m_tyresAgeLaps;

    /**
     * <summary>Tyre damage (percentage)</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] m_tyresDamage;

    /**
     * <summary>Front left wing damage (percentage)</summary>
     */
    public byte m_frontLeftWingDamage;

    /**
     * <summary>Front right wing damage (percentage)</summary>
     */
    public byte m_frontRightWingDamage;

    /**
     * <summary>Rear wing damage (percentage)</summary>
     */
    public byte m_rearWingDamage;

    // Added Beta 3:
    /**
     * <summary>Indicator for DRS fault, 0 = OK, 1 = fault</summary>
     */
    public byte m_drsFault;

    /**
     * <summary>Engine damage (percentage)</summary>
     */
    public byte m_engineDamage;

    /**
     * <summary>Gear box damage (percentage)</summary>
     */
    public byte m_gearBoxDamage;

    /**
     * <summary>-1 = invalid/unknown, 0 = none, 1 = green,
     * 2 = blue, 3 = yellow, 4 = red</summary>
     */
    public sbyte m_vehicleFiaFlags;

    /**
     * <summary>ERS energy store in Joules</summary>
     */
    public float m_ersStoreEnergy;

    /**
     * <summary>ERS deployment mode, 0 = none, 1 = medium,
     * 2 = overtake, 3 = hotlap</summary>
     */
    public byte m_ersDeployMode;

    /**
     * <summary>ERS energy harvested this lap by MGU-K</summary>
     */
    public float m_ersHarvestedThisLapMGUK;

    /**
     * <summary>ERS energy harvested this lap by MGU-H</summary>
     */
    public float m_ersHarvestedThisLapMGUH;

    /**
     * <summary>ERS energy deployed this lap</summary>
     */
    public float m_ersDeployedThisLap;
};
