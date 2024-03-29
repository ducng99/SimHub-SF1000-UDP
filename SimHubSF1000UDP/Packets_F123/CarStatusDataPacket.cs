﻿using SimHub.Plugins;
using SimHubSF1000UDP.DataStructures_F123;
using System;
using System.Runtime.InteropServices;

namespace SimHubSF1000UDP.Packets_F123
{
    internal static class CarStatusDataPacket
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
                m_packetId = 7,
                m_sessionUID = 0,
                m_sessionTime = 0,
                m_frameIdentifier = FrameCount,
                m_overallFrameIdentifier = FrameCount,
                m_playerCarIndex = 0,
                m_secondaryPlayerCarIndex = 255,
            };

            var packet = new PacketCarStatusData
            {
                m_header = header,
                m_carStatusData = new CarStatusData[22]
            };

            packet.m_carStatusData[0] = new CarStatusData
            {
                m_tractionControl = Utils.ClampIntegerValue<byte>(Math.Min(Utils.ClampIntegerValue<int>(pluginManager.LastData?.NewData?.TCLevel), 2)),
                m_antiLockBrakes = Utils.ClampIntegerValue<byte>(Math.Min(Utils.ClampIntegerValue<int>(pluginManager.LastData?.NewData?.ABSLevel), 1)),
                m_fuelMix = 1,
                m_frontBrakeBias = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.BrakeBias),
                m_pitLimiterStatus = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.PitLimiterOn),
                m_fuelInTank = Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.Fuel),
                m_fuelCapacity = Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.MaxFuel),
                m_fuelRemainingLaps = Utils.ClampFloatingValue<float>(pluginManager.GetPropertyValue("DataCorePlugin.Computed.Fuel_RemainingLaps")),
                m_maxRPM = Utils.ClampIntegerValue<ushort>(pluginManager.LastData?.NewData?.CarSettings_MaxRPM),
                m_idleRPM = Utils.ClampIntegerValue<ushort>(Convert.ToDouble(pluginManager.LastData?.NewData?.CarSettings_MaxRPM) * 0.27),
                m_maxGears = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.CarSettings_MaxGears),
                m_drsAllowed = Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.DRSAvailable),
                m_drsActivationDistance = (ushort)(Convert.ToBoolean(pluginManager.LastData?.NewData?.DRSAvailable) ? 0 : 50),
                m_actualTyreCompound = 16,
                m_visualTyreCompound = 16,
                m_tyresAgeLaps = 0,
                m_vehicleFiaFlags = GetFlag(pluginManager),
                m_enginePowerICE = Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.EngineTorque),
                m_enginePowerMGUK = 0,
                m_ersStoreEnergy = Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.ERSStored),
                m_ersDeployMode = 1,
                // Note: HarvestingPercent on wheel is m_ersHarvestedThisLapMGUK / m_ersHarvestedThisLapMGUH. Data below is incorrectly implemented on the wheel and so cannot be used
                m_ersHarvestedThisLapMGUK = 100f,
                m_ersHarvestedThisLapMGUH = 1f,
                m_ersDeployedThisLap = Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.ERSPercent),
                m_networkPaused = 0,
            };

            if (pluginManager.GameName == "AssettoCorsa")
            {
                packet.m_carStatusData[0].m_ersStoreEnergy = Utils.ClampFloatingValue<float>(Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.ERSMax) - packet.m_carStatusData[0].m_ersStoreEnergy);

                byte ersMode;
                if (Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameRawData.Physics.KersInput")) == 1)
                {
                    ersMode = 3;
                }
                else
                {
                    ersMode = Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameRawData.Physics.ErsPowerLevel"));
                    ersMode = ersMode switch
                    {
                        1 or 2 => 1,
                        3 => 3,
                        4 or 5 => 2,
                        _ => 0,
                    };
                }

                packet.m_carStatusData[0].m_ersDeployMode = ersMode;
            }

            int size = Marshal.SizeOf(packet);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(packet, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        private static sbyte GetFlag(PluginManager pluginManager)
        {
            if (Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.Flag_Green) > 0)
                return 1;
            if (Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.Flag_Blue) > 0)
                return 2;
            if (Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.Flag_Yellow) > 0)
                return 3;
            return 0;
        }
    }
}
