using SimHub.Plugins;
using System;
using System.Runtime.InteropServices;
using static SimHubToF12020UDP.F12020Struct;

namespace SimHubToF12020UDP.Packets
{
    internal static class CarTelemetryDataPacket
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

            var gear = pluginManager.GetPropertyValue("DataCorePlugin.GameData.Gear");
            gear = (string)gear == "N" ? 0 : ((string)gear == "R" ? -1 : gear);

            var redlinePercent = Math.Max(0, Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Rpms")) - Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CarSettings_CurrentGearRedLineRPM")))
                                / (Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CarSettings_MaxRPM")) - Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CarSettings_CurrentGearRedLineRPM")));
            var revLightsPercent = Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CarSettings_RPMShiftLight1")) / 3.0
                                    + Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CarSettings_RPMShiftLight2")) / 3.0
                                    + redlinePercent / 3.0;

            packet.m_carTelemetryData[0] = new CarTelemetryData
            {
                m_speed = Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.SpeedKmh")),
                m_throttle = (float)Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Throttle")) / 100f,
                m_steer = 0,
                m_brake = (float)Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Brake")) / 100f,
                m_clutch = (byte)Math.Max(100, Convert.ToUInt32(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Clutch"))),
                m_gear = Convert.ToSByte(gear),
                m_engineRPM = Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Rpms")),
                m_drs = Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.DRSEnabled")),
                m_revLightsPercent = (byte)(revLightsPercent * 100),
                m_brakesTemperature = new ushort[4]
                {
                    Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.BrakeTemperatureRearLeft")),
                    Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.BrakeTemperatureRearRight")),
                    Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.BrakeTemperatureFrontLeft")),
                    Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.BrakeTemperatureFrontRight")),
                },
                m_tyresSurfaceTemperature = new byte[4]
                {
                    Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreTemperatureRearLeft")),
                    Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreTemperatureRearRight")),
                    Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreTemperatureFrontLeft")),
                    Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreTemperatureFrontRight")),
                },
                m_tyresInnerTemperature = new byte[4]
                {
                    Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreTemperatureRearLeftInner")),
                    Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreTemperatureRearRightInner")),
                    Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreTemperatureFrontLeftInner")),
                    Convert.ToByte(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreTemperatureFrontRightInner")),
                },
                m_engineTemperature = Convert.ToUInt16(pluginManager.GetPropertyValue("DataCorePlugin.GameData.OilTemperature")),
                m_tyresPressure = new float[4]
                {
                    (float)Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyrePressureRearLeft")),
                    (float)Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyrePressureRearRight")),
                    (float)Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyrePressureFrontLeft")),
                    (float)Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyrePressureFrontRight")),
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
