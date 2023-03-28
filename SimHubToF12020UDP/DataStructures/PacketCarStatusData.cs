using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketCarStatusData
{
    public PacketHeader m_header;           // Header

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarStatusData[] m_carStatusData;
};
