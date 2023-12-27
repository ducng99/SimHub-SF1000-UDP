using SimHub.Plugins;
using SimHubSF1000UDP.DataStructures_F123;
using System;
using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.Packets_F123
{
    internal static class SessionDataPacket
    {
        private readonly static PluginManager pluginManager = PluginManager.GetInstance();
        private static uint FrameCount = 0;

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
                m_packetId = 1,
                m_sessionUID = 0,
                m_sessionTime = 0,
                m_frameIdentifier = FrameCount,
                m_overallFrameIdentifier = FrameCount,
                m_playerCarIndex = 0,
                m_secondaryPlayerCarIndex = 255,
            };

            var packet = new PacketSessionData
            {
                m_header = header,
                m_weather = 0,
                m_trackTemperature = Utils.ClampIntegerValue<sbyte>(pluginManager.LastData?.NewData?.RoadTemperature),
                m_airTemperature = Utils.ClampIntegerValue<sbyte>(pluginManager.LastData?.NewData?.AirTemperature),
                m_totalLaps = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TotalLaps),
                m_trackLength = Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.TrackLength),
                m_sessionType = 0,
                m_trackId = -1,
                m_formula = 0,
                m_sessionTimeLeft = Utils.ClampIntegerValue<ushort>((pluginManager.LastData?.NewData?.SessionTimeLeft ?? new TimeSpan()).TotalSeconds),
                m_sessionDuration = 600,
                m_pitSpeedLimit = 80,
                m_gamePaused = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.GamePaused),
                m_isSpectating = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.Spectating),
                m_spectatorCarIndex = 0,
                m_sliProNativeSupport = 0,
                m_numMarshalZones = 0,
                m_marshalZones = new MarshalZone[21],
                m_safetyCarStatus = 0,
                m_networkGame = 0,
                m_numWeatherForecastSamples = 0,
                m_weatherForecastSamples = new WeatherForecastSample[56],
                m_forecastAccuracy = 0,
                m_aiDifficulty = 100,
                m_seasonLinkIdentifier = 0,
                m_weekendLinkIdentifier = 0,
                m_sessionLinkIdentifier = 0,
                m_pitStopWindowIdealLap = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TotalLaps / 2),
                m_pitStopWindowLatestLap = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TotalLaps - 1),
                m_pitStopRejoinPosition = 1,
                m_steeringAssist = 0,
                m_brakingAssist = 0,
                m_gearboxAssist = 1,
                m_pitAssist = 0,
                m_pitReleaseAssist = 0,
                m_ERSAssist = 0,
                m_DRSAssist = 0,
                m_dynamicRacingLine = 0,
                m_dynamicRacingLineType = 0,
                m_gameMode = 7,
                m_ruleSet = 1,
                m_timeOfDay = 54000,
                m_sessionLength = 7,
                m_speedUnitsLeadPlayer = 1,
                m_temperatureUnitsLeadPlayer = 0,
                m_speedUnitsSecondaryPlayer = 1,
                m_temperatureUnitsSecondaryPlayer = 0,
                m_numSafetyCarPeriods = 0,
                m_numVirtualSafetyCarPeriods = 0,
                m_numRedFlagPeriods = 0,
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
