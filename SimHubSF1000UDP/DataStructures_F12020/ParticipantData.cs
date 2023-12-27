using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F12020;

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
    /**
     * <summary>Whether the vehicle is AI (1) or Human (0) controlled</summary>
     */
    public byte m_aiControlled;
    
    /**
     * <summary>Driver id - see appendix</summary>
     */
    public byte m_driverId;
    
    /**
     * <summary>Team id - see appendix</summary>
     */
    public byte m_teamId;
    
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
};
