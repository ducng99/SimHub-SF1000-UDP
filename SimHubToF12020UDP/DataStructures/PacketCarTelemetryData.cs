using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketCarTelemetryData
{
    /**
     * <summary>Header</summary>
     */
    public PacketHeader m_header;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarTelemetryData[] m_carTelemetryData;

    // Added in Beta 3:
    /**
     * <summary>Bit flags specifying which buttons are being pressed
     * currently - see appendices</summary>
     */
    public uint m_buttonStatus;
    
    /**
     * <summary>Index of MFD panel open - 255 = MFD closed<br/>
     * Single player, race – 0 = Car setup, 1 = Pits,
     * 2 = Damage, 3 =  Engine, 4 = Temperatures<br/>
     * May vary depending on game mode</summary>
     */
    public byte m_mfdPanelIndex;
    
    /**
     * <summary>See above</summary>
     */
    public byte m_mfdPanelIndexSecondaryPlayer;
    
    /**
     * <summary>Suggested gear for the player (1-8)<br/>
     * 0 if no gear suggested</summary>
     */
    public sbyte m_suggestedGear;
};
