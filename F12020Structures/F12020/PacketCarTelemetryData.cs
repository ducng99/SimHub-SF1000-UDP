using System.Runtime.InteropServices;

namespace SimHubToF12020UDP
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarTelemetryData
    {
        public PacketHeader m_header;         // Header

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarTelemetryData[] m_carTelemetryData;

        public uint m_buttonStatus;        // Bit flags specifying which buttons are being pressed
                                           // currently - see appendices

        // Added in Beta 3:
        public byte m_mfdPanelIndex;       // Index of MFD panel open - 255 = MFD closed
                                           // Single player, race – 0 = Car setup, 1 = Pits
                                           // 2 = Damage, 3 =  Engine, 4 = Temperatures
                                           // May vary depending on game mode
        public byte m_mfdPanelIndexSecondaryPlayer;   // See above
        public sbyte m_suggestedGear;       // Suggested gear for the player (1-8)
                                            // 0 if no gear suggested
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
