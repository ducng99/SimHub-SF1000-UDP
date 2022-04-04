using SimHub.Plugins;
using System;
using System.Runtime.InteropServices;
using static SimHubToF12020UDP.F12020Struct;

namespace SimHubToF12020UDP.Packets
{
    internal static class LapDataPacket
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
                m_gameMinorVersion = 16,
                m_packetVersion = 1,
                m_sessionUID = 0,
                m_sessionTime = 0,
                m_frameIdentifier = FrameCount,
                m_playerCarIndex = 0,
                m_secondaryPlayerCarIndex = 0,
                m_packetId = 2
            };

            var packet = new PacketLapData
            {
                m_header = header,
                m_lapData = new LapData[22]
            };

            float lapDistance = (float)(Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TrackPositionPercent")) * Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TrackLength")));
            float totalDistance = lapDistance + Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CompletedLaps")) * Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TrackLength"));
            byte pitStatus = (byte)(Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.IsInPit")) == 1 ? 2 : Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.IsInPitLane")));

            packet.m_lapData[0] = new LapData
            {
                m_lastLapTime = (float)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.LastLapTime") ?? new TimeSpan())).TotalSeconds,
                m_currentLapTime = (float)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CurrentLapTime") ?? new TimeSpan())).TotalSeconds,
                m_sector1TimeInMS = (ushort)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Sector1Time") ?? new TimeSpan())).TotalMilliseconds,
                m_sector2TimeInMS = (ushort)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Sector2Time") ?? new TimeSpan())).TotalMilliseconds,
                m_bestLapTime = (float)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.BestLapTime") ?? new TimeSpan())).TotalSeconds,
                m_bestLapNum = 0,
                m_bestLapSector1TimeInMS = (ushort)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Sector1BestLapTime") ?? new TimeSpan())).TotalMilliseconds,
                m_bestLapSector2TimeInMS = (ushort)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Sector2BestLapTime") ?? new TimeSpan())).TotalMilliseconds,
                m_bestLapSector3TimeInMS = (ushort)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Sector3BestLapTime") ?? new TimeSpan())).TotalMilliseconds,
                m_bestOverallSector1TimeInMS = (ushort)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Sector1BestTime") ?? new TimeSpan())).TotalMilliseconds,
                m_bestOverallSector1LapNum = 0,
                m_bestOverallSector2TimeInMS = (ushort)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Sector2BestTime") ?? new TimeSpan())).TotalMilliseconds,
                m_bestOverallSector2LapNum = 0,
                m_bestOverallSector3TimeInMS = (ushort)((TimeSpan)(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Sector3BestTime") ?? new TimeSpan())).TotalMilliseconds,
                m_bestOverallSector3LapNum = 0,
                m_lapDistance = lapDistance,
                m_totalDistance = totalDistance,
                m_safetyCarDelta = 0,
                m_carPosition = Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Position")),
                m_currentLapNum = Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CurrentLap")),
                m_pitStatus = pitStatus,
                m_sector = Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CurrentSectorIndex")),
                m_currentLapInvalid = 0,
                m_penalties = 0,
                m_gridPosition = 1,
                m_driverStatus = 4,
                m_resultStatus = 2,
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
