using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

public struct PacketParticipantsData
{
    /**
     * <summary>Header</summary>
     */
    public PacketHeader m_header;
    
    /**
     * <summary>Number of active cars in the data – should match number of cars on HUD</summary>
     */
    public byte m_numActiveCars;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public ParticipantData[] m_participants;
};
