using SimHub.Plugins;
using System;
using System.Runtime.InteropServices;
using static SimHubToF12020UDP.F12020Struct;

namespace SimHubToF12020UDP.Packets
{
    internal static class CarSetupDataPacket
    {
        private static uint FrameCount = 0;

        public static byte[] Read()
        {
            var pluginManager = PluginManager.GetInstance();

            var start = pluginManager.GetPropertyValue("DataCorePlugin.GameRunning");

            if (start == null || !Convert.ToBoolean(start))
            {
                return new byte[0];
            }

            FrameCount = (FrameCount + 1) % uint.MaxValue;

            var header = new PacketHeader
            {
                m_packetFormat = 2020,
                m_gameMajorVersion = 1,
                m_gameMinorVersion = 16,
                m_packetVersion = 1,
                m_sessionUID = 0,
                m_sessionTime = 0,
                m_frameIdentifier = FrameCount,
                m_playerCarIndex = 0,
                m_secondaryPlayerCarIndex = 0,
                m_packetId = 5
            };

            var packet = new PacketCarSetupData
            {
                m_header = header,
                m_carSetups = new CarSetupData[22]
            };

            packet.m_carSetups[0] = new CarSetupData
            {
                m_brakeBias = Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.BrakeBias")),
                m_fuelLoad = (float)Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Fuel")),
            };

            int size = Marshal.SizeOf(packet);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(packet, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
    }
}
