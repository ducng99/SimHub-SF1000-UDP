using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketHeader
{
    public ushort m_packetFormat;             // 2020
    public byte m_gameMajorVersion;         // Game major version - "X.00"
    public byte m_gameMinorVersion;         // Game minor version - "1.XX"
    public byte m_packetVersion;            // Version of this packet type, all start from 1
    public byte m_packetId;                 // Identifier for the packet type, see below
    public ulong m_sessionUID;               // Unique identifier for the session
    public float m_sessionTime;              // Session timestamp
    public uint m_frameIdentifier;          // Identifier for the frame the data was retrieved on
    public byte m_playerCarIndex;           // Index of player's car in the array

    // ADDED IN BETA 2: 
    public byte m_secondaryPlayerCarIndex;  // Index of secondary player's car in the array (splitscreen)
                                            // 255 if no second player
};
