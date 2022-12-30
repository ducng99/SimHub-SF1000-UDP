using System.Runtime.InteropServices;

namespace SimHubToF12020UDP
{

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

}
