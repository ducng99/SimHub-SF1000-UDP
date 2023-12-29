using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F123;

public struct ParticipantData
{
    /**
     * <summary>Whether the vehicle is AI (1) or Human (0) controlled</summary>
     */
    public byte m_aiControlled;

    /**
     * <summary>Driver id - see appendix, 255 if network human</summary>
     */
    public byte m_driverId;

    /**
     * <summary>Network id - unique identifier for network players</summary>
     */
    public byte m_networkId;

    /**
     * <summary>Team id - see appendix</summary>
     */
    public byte m_teamId;

    /**
     * <summary>My team flag – 1 = My Team, 0 = otherwise</summary>
     */
    public byte m_myTeam;

    /**
     * <summary>Race number of the car</summary>
     */
    public byte m_raceNumber;

    /**
     * <summary>Nationality of the driver</summary>
     */
    public byte m_nationality;

    /**
     * <summary>Name of participant in UTF-8 format – null terminated<br/>
     * Will be truncated with … (U+2026) if too long</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
    public char[] m_name;

    /**
     * <summary>The player's UDP setting, 0 = restricted, 1 = public</summary>
     */
    public byte m_yourTelemetry;

    /**
     * <summary>The player's show online names setting, 0 = off, 1 = on</summary>
     */
    public byte m_showOnlineNames;

    /**
     * <summary>1 = Steam, 3 = PlayStation, 4 = Xbox, 6 = Origin, 255 = unknown</summary>
     */
    public byte m_platform;

};
