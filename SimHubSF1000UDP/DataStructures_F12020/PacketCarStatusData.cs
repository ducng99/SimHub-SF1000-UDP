using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F12020;

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
