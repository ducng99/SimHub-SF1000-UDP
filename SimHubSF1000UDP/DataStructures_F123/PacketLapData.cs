using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.DataStructures_F123;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketLapData
{
    /**
     * <summary>Header</summary>
     */
    public PacketHeader m_header;

    /**
     * <summary>Lap data for all cars on track</summary>
     */
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public LapData[] m_lapData;

    /**
     * <summary>Index of Personal Best car in time trial (255 if invalid)</summary>
     */
    public byte m_timeTrialPBCarIdx;

    /**
     * <summary>Index of Rival car in time trial (255 if invalid)</summary>
     */
    public byte m_timeTrialRivalCarIdx;
};
