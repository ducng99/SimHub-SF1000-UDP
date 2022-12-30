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
}
