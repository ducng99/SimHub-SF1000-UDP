using SimHub.Plugins;
using SimHubToF12020UDP.DataStructures;
using System;
using System.Runtime.InteropServices;

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

            float lapDistance = Utils.ClampFloatingValue<float>(Convert.ToDouble(pluginManager.LastData?.NewData?.TrackPositionPercent) * Convert.ToDouble(pluginManager.LastData?.NewData?.TrackLength));
            float totalDistance = lapDistance + Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.CompletedLaps) * Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.TrackLength);
            byte pitStatus = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.IsInPit) == 1 ? (byte)2 : Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.IsInPitLane);

            packet.m_lapData[0] = new LapData
            {
                m_lastLapTime = Utils.ClampFloatingValue<float>((pluginManager.LastData?.NewData?.LastLapTime ?? new TimeSpan()).TotalSeconds),
                m_currentLapTime = Utils.ClampFloatingValue<float>((pluginManager.LastData?.NewData?.CurrentLapTime ?? new TimeSpan()).TotalSeconds),
                m_sector1TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector1Time ?? new TimeSpan()).TotalMilliseconds),
                m_sector2TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector2Time ?? new TimeSpan()).TotalMilliseconds),
                m_bestLapTime = Utils.ClampFloatingValue<float>((pluginManager.LastData?.NewData?.BestLapTime ?? new TimeSpan()).TotalSeconds),
                m_bestLapNum = 0,
                m_bestLapSector1TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector1BestLapTime ?? new TimeSpan()).TotalMilliseconds),
                m_bestLapSector2TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector2BestLapTime ?? new TimeSpan()).TotalMilliseconds),
                m_bestLapSector3TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector3BestLapTime ?? new TimeSpan()).TotalMilliseconds),
                m_bestOverallSector1TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector1BestTime ?? new TimeSpan()).TotalMilliseconds),
                m_bestOverallSector1LapNum = 0,
                m_bestOverallSector2TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector2BestTime ?? new TimeSpan()).TotalMilliseconds),
                m_bestOverallSector2LapNum = 0,
                m_bestOverallSector3TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector3BestTime ?? new TimeSpan()).TotalMilliseconds),
                m_bestOverallSector3LapNum = 0,
                m_lapDistance = lapDistance,
                m_totalDistance = totalDistance,
                m_safetyCarDelta = 0,
                m_carPosition = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.Position),
                m_currentLapNum = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.CurrentLap),
                m_pitStatus = pitStatus,
                m_sector = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.CurrentSectorIndex),
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
