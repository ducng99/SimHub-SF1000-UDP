using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F123;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketCarDamageData
{
    /**
     * <summary>Header</summary>
     */
    public PacketHeader m_header;

    /**
     * <summary>Lap data for all cars on track</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarDamageData[] m_carDamageData;
}
