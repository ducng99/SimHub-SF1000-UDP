using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

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

