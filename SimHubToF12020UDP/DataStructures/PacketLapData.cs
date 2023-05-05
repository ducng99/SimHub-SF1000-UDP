﻿using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

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
};
