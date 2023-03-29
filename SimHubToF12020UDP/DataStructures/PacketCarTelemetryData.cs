using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.DataStructures;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PacketCarTelemetryData
{
    public PacketHeader m_header;         // Header

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public CarTelemetryData[] m_carTelemetryData;

    public uint m_buttonStatus;        // Bit flags specifying which buttons are being pressed
                                       // currently - see appendices

    // Added in Beta 3:
    public byte m_mfdPanelIndex;       // Index of MFD panel open - 255 = MFD closed
                                       // Single player, race – 0 = Car setup, 1 = Pits
                                       // 2 = Damage, 3 =  Engine, 4 = Temperatures
                                       // May vary depending on game mode
    public byte m_mfdPanelIndexSecondaryPlayer;   // See above
    public sbyte m_suggestedGear;       // Suggested gear for the player (1-8)
                                        // 0 if no gear suggested
};
