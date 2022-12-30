using System.Runtime.InteropServices;

namespace SimHubToF12020UDP
{
    public struct PacketParticipantsData
    {
        public PacketHeader m_header;           // Header

        public byte m_numActiveCars;  // Number of active cars in the data – should match number of
                                      // cars on HUD
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public ParticipantData[] m_participants;
    };
}
