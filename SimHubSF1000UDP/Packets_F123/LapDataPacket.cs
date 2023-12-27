using SimHub.Plugins;
using SimHubSF1000UDP.DataStructures_F123;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.Packets_F123
{
    internal static class LapDataPacket
    {
        private readonly static PluginManager pluginManager = PluginManager.GetInstance();
        private static uint FrameCount = 0;

        private static bool LastDataIsInPitLane = false;
        private static Stopwatch PitLaneStopwatch = new();

        public static byte[] Read()
        {
            var start = !SimHubSF1000UDPSettings.Instance.OnlySendDataIfGameRunning || (pluginManager.LastData?.GameRunning ?? false);

            if (!start)
            {
                return new byte[0];
            }

            FrameCount = (FrameCount + 1) % uint.MaxValue;

            var header = new PacketHeader
            {
                m_packetFormat = 2023,
                m_gameYear = 23,
                m_gameMajorVersion = 1,
                m_gameMinorVersion = 18,
                m_packetVersion = 1,
                m_packetId = 2,
                m_sessionUID = 0,
                m_sessionTime = 0,
                m_frameIdentifier = FrameCount,
                m_overallFrameIdentifier = FrameCount,
                m_playerCarIndex = 0,
                m_secondaryPlayerCarIndex = 255,
            };

            var packet = new PacketLapData
            {
                m_header = header,
                m_lapData = new LapData[22],
                m_timeTrialPBCarIdx = 255,
                m_timeTrialRivalCarIdx = 255,
            };

            float lapDistance = Utils.ClampFloatingValue<float>(Convert.ToDouble(pluginManager.LastData?.NewData?.TrackPositionPercent) * Convert.ToDouble(pluginManager.LastData?.NewData?.TrackLength));
            float totalDistance = lapDistance + Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.CompletedLaps) * Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.TrackLength);
            byte pitStatus = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.IsInPit) == 1 ? (byte)2 : Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.IsInPitLane);

            CheckPitLaneTimer(pluginManager.LastData?.NewData?.IsInPitLane == 1);

            packet.m_lapData[0] = new LapData
            {
                m_lastLapTimeInMS = Utils.ClampFloatingValue<uint>((pluginManager.LastData?.NewData?.LastLapTime ?? new TimeSpan()).TotalMilliseconds),
                m_currentLapTimeInMS = Utils.ClampFloatingValue<uint>((pluginManager.LastData?.NewData?.CurrentLapTime ?? new TimeSpan()).TotalMilliseconds),
                m_sector1TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector1Time ?? new TimeSpan()).TotalMilliseconds),
                m_sector1TimeMinutes = Utils.ClampIntegerValue<byte>((pluginManager.LastData?.NewData?.Sector1Time ?? new TimeSpan()).Minutes),
                m_sector2TimeInMS = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.Sector2Time ?? new TimeSpan()).TotalMilliseconds),
                m_sector2TimeMinutes = Utils.ClampIntegerValue<byte>((pluginManager.LastData?.NewData?.Sector2Time ?? new TimeSpan()).Minutes),
                m_deltaToCarInFrontInMS = 0,
                m_deltaToRaceLeaderInMS = 0,
                m_lapDistance = lapDistance,
                m_totalDistance = totalDistance,
                m_safetyCarDelta = 0,
                m_carPosition = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.Position),
                m_currentLapNum = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.CurrentLap),
                m_pitStatus = pitStatus,
                m_numPitStops = 0,
                m_sector = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.CurrentSectorIndex),
                m_currentLapInvalid = Utils.ClampIntegerValue<byte>((pluginManager.LastData?.NewData?.LapInvalidated ?? false) ? 1 : 0),
                m_penalties = 0,
                m_totalWarnings = 0,
                m_cornerCuttingWarnings = 0,
                m_numUnservedDriveThroughPens = 0,
                m_numUnservedStopGoPens = 0,
                m_gridPosition = 1,
                m_driverStatus = 4,
                m_resultStatus = 2,
                m_pitLaneTimerActive = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.IsInPitLane),
                m_pitLaneTimeInLaneInMS = Utils.ClampIntegerValue<ushort>(PitLaneStopwatch.ElapsedMilliseconds),
                m_pitStopTimerInMS = Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.IsInPitSince),
                m_pitStopShouldServePen = 0,
            };

            if (pluginManager.GameName == "GranTurismo7" && packet.m_lapData[0].m_currentLapNum > 0)
            {
                packet.m_lapData[0].m_currentLapNum--;
            }

            int size = Marshal.SizeOf(packet);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(packet, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        private static void CheckPitLaneTimer(bool isInPitLane)
        {
            if (LastDataIsInPitLane != isInPitLane)
            {
                if (isInPitLane)
                {
                    if (!PitLaneStopwatch.IsRunning)
                    {
                        PitLaneStopwatch.Start();
                    }
                }
                else
                {
                    if (PitLaneStopwatch.IsRunning)
                    {
                        PitLaneStopwatch.Reset();
                    }
                }

                LastDataIsInPitLane = isInPitLane;
            }
        }
    }
}
