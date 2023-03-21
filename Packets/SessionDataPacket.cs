using SimHub.Plugins;
using System;
using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.Packets
{
    internal static class SessionDataPacket
    {
        private static uint FrameCount = 0;

        public static byte[] Read()
        {
            var pluginManager = PluginManager.GetInstance();

            var start = pluginManager.GetPropertyValue("DataCorePlugin.GameRunning");

            if (!Convert.ToBoolean(start))
            {
                return new byte[0];
            }

            FrameCount = (FrameCount + 1) % uint.MaxValue;

            var header = new PacketHeader
            {
                m_packetFormat = 2020,
                m_gameMajorVersion = 1,
                m_gameMinorVersion = 13,
                m_packetVersion = 1,
                m_sessionUID = 0,
                m_sessionTime = 0,
                m_frameIdentifier = FrameCount,
                m_playerCarIndex = 0,
                m_secondaryPlayerCarIndex = 0,
                m_packetId = 1
            };

            var packet = new PacketSessionData
            {
                m_header = header,
                m_weather = 0,
                m_trackTemperature = Convert.ToSByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.RoadTemperature")),
                m_airTemperature = Convert.ToSByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.AirTemperature")),
                m_totalLaps = Utils.ClampByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TotalLaps")),
                m_trackLength = Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TrackLength")),
                m_sessionType = 0,
                m_trackId = -1,
                m_formula = 0,
                m_sessionTimeLeft = (ushort)Math.Abs(((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.SessionTimeLeft") ?? new TimeSpan())).TotalSeconds),
                m_sessionDuration = 600,
                m_pitSpeedLimit = 80,
                m_gamePaused = Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GamePaused")),
                m_isSpectating = Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Spectating")),
                m_spectatorCarIndex = 0,
                m_sliProNativeSupport = 0,
                m_numMarshalZones = 0,
                m_marshalZones = new MarshalZone[21],
                m_safetyCarStatus = 0,
                m_networkGame = 0,
                m_numWeatherForecastSamples = 0,
                m_weatherForecastSamples = new WeatherForecastSample[20]
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
