using SimHub.Plugins;
using SimHubToF12020UDP.DataStructures;
using SimHubToF12020UDPPlugin;
using System;
using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.Packets
{
    internal static class CarTelemetryDataPacket
    {
        private readonly static PluginManager pluginManager = PluginManager.GetInstance();
        private static uint FrameCount = 0;

        public static byte[] Read()
        {
            var start = !SimHubToF12020UDPSettings.Instance.OnlySendDataIfGameRunning || (pluginManager.LastData?.GameRunning ?? false);

            if (!start)
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
                m_secondaryPlayerCarIndex = 255,
                m_packetId = 6
            };

            var packet = new PacketCarTelemetryData
            {
                m_header = header,
                m_carTelemetryData = new CarTelemetryData[22],
                m_buttonStatus = 0,
                m_mfdPanelIndex = 255,
                m_mfdPanelIndexSecondaryPlayer = 255,
                m_suggestedGear = 0
            };

            var _gear = pluginManager.LastData?.NewData?.Gear;
            sbyte gear = _gear == "N" ? (sbyte)0 : (_gear == "R" ? (sbyte)-1 : Utils.ClampIntegerValue<sbyte>(_gear));

            var redlinePercent = Math.Max(0, Convert.ToDouble(pluginManager.LastData?.NewData?.Rpms) - Convert.ToDouble(pluginManager.LastData?.NewData?.CarSettings_CurrentGearRedLineRPM))
                                / (Convert.ToDouble(pluginManager.LastData?.NewData?.CarSettings_MaxRPM) - Convert.ToDouble(pluginManager.LastData?.NewData?.CarSettings_CurrentGearRedLineRPM));
            var revLightsPercent = Convert.ToDouble(pluginManager.LastData?.NewData?.CarSettings_RPMShiftLight1) / 3.0
                                    + Convert.ToDouble(pluginManager.LastData?.NewData?.CarSettings_RPMShiftLight2) / 3.0
                                    + redlinePercent / 3.0;

            packet.m_carTelemetryData[0] = new CarTelemetryData
            {
                m_speed = Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.SpeedKmh),
                m_throttle = Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.Throttle) / 100f,
                m_steer = 0,
                m_brake = Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.Brake) / 100f,
                m_clutch = Utils.ClampIntegerValue<byte>(Math.Min(100, Convert.ToDouble(pluginManager.LastData?.NewData?.Clutch)) / 100),     // Clutch value is different each game, some returns percentage, some returns raw value (3700). We don't have MaxClutch property so unable to find out the percentage
                m_gear = gear,
                m_engineRPM = Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.Rpms),
                m_drs = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.DRSEnabled),
                m_revLightsPercent = Utils.ClampIntegerValue<byte>(revLightsPercent * 100),
                m_brakesTemperature = new ushort[4]
                {
                    Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.BrakeTemperatureRearLeft),
                    Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.BrakeTemperatureRearRight),
                    Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.BrakeTemperatureFrontLeft),
                    Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.BrakeTemperatureFrontRight),
                },
                m_tyresSurfaceTemperature = new byte[4]
                {
                    Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreTemperatureRearLeft),
                    Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreTemperatureRearRight),
                    Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreTemperatureFrontLeft),
                    Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreTemperatureFrontRight),
                },
                m_tyresInnerTemperature = new byte[4]
                {
                    Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreTemperatureRearLeftInner),
                    Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreTemperatureRearRightInner),
                    Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreTemperatureFrontLeftInner),
                    Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreTemperatureFrontRightInner),
                },
                m_engineTemperature = Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.OilTemperature),
                m_tyresPressure = new float[4]
                {
                    Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.TyrePressureRearLeft),
                    Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.TyrePressureRearRight),
                    Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.TyrePressureFrontLeft),
                    Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.TyrePressureFrontRight),
                },
                m_surfaceType = new byte[4] { 0, 0, 0, 0 },
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
