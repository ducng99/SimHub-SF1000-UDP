using System.Runtime.InteropServices;

namespace SimHubToF12020UDP
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketHeader
    {
        public ushort m_packetFormat;             // 2020
        public byte m_gameMajorVersion;         // Game major version - "X.00"
        public byte m_gameMinorVersion;         // Game minor version - "1.XX"
        public byte m_packetVersion;            // Version of this packet type, all start from 1
        public byte m_packetId;                 // Identifier for the packet type, see below
        public ulong m_sessionUID;               // Unique identifier for the session
        public float m_sessionTime;              // Session timestamp
        public uint m_frameIdentifier;          // Identifier for the frame the data was retrieved on
        public byte m_playerCarIndex;           // Index of player's car in the array

        // ADDED IN BETA 2: 
        public byte m_secondaryPlayerCarIndex;  // Index of secondary player's car in the array (splitscreen)
                                                // 255 if no second player
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
