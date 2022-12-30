using System.Runtime.InteropServices;

namespace SimHubToF12020UDP
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WeatherForecastSample
    {
        public byte m_sessionType;                     // 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 5 = Q1
                                                       // 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ, 10 = R, 11 = R2
                                                       // 12 = Time Trial
        public byte m_timeOffset;                      // Time in minutes the forecast is for
        public byte m_weather;                         // Weather - 0 = clear, 1 = light cloud, 2 = overcast
                                                       // 3 = light rain, 4 = heavy rain, 5 = storm
        public sbyte m_trackTemperature;                // Track temp. in degrees celsius
        public sbyte m_airTemperature;                  // Air temp. in degrees celsius
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
