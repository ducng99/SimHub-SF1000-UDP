using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketCarStatusData
{
    /**
     * <summary>Header</summary>
     */
    public PacketHeader m_header;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarStatusData[] m_carStatusData;
};
