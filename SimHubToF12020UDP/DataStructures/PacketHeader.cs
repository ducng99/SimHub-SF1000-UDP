using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketHeader
{
    /**
     * <summary>2020</summary>
     */
    public ushort m_packetFormat;

    /**
     * <summary>Game major version - "X.00"</summary>
     */
    public byte m_gameMajorVersion;

    /**
     * <summary>Game minor version - "1.XX"</summary>
     */
    public byte m_gameMinorVersion;

    /**
     * <summary>Version of this packet type, all start from 1</summary>
     */
    public byte m_packetVersion;

    /**
     * <summary>Identifier for the packet type, see below</summary>
     */
    public byte m_packetId;

    /**
     * <summary>Unique identifier for the session</summary>
     */
    public ulong m_sessionUID;

    /**
     * <summary>Session timestamp</summary>
     */
    public float m_sessionTime;

    /**
     * <summary>Identifier for the frame the data was retrieved on</summary>
     */
    public uint m_frameIdentifier;

    /**
     * <summary>Index of player's car in the array</summary>
     */
    public byte m_playerCarIndex;

    // ADDED IN BETA 2: 
    /**
     * <summary>Index of secondary player's car in the array (splitscreen)<br/>
     * 255 if no second player</summary>
     */
    public byte m_secondaryPlayerCarIndex;
};
