using SimHub.Plugins;
using SimHubToF12020UDP.DataStructures;
using System;
using System.Runtime.InteropServices;

namespace SimHubToF12020UDP.Packets
{
    internal static class CarStatusDataPacket
    {
        private static uint FrameCount = 0;

        public static byte[] Read()
        {
            var pluginManager = PluginManager.GetInstance();

            var start = pluginManager.LastData.GameRunning;

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
                m_secondaryPlayerCarIndex = 0,
                m_packetId = 7
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
                m_tyresWear = new byte[4]
                {
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreWearRearLeft)),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreWearRearRight)),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreWearFrontLeft)),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreWearFrontRight)),
                },
                m_actualTyreCompound = 16,
                m_visualTyreCompound = 16,
                m_tyresAgeLaps = 0,
                m_tyresDamage = new byte[4]
                {
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreWearRearLeft)),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreWearRearRight)),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreWearFrontLeft)),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.TyreWearFrontRight)),
                },
                m_frontLeftWingDamage = 0,
                m_frontRightWingDamage = 0,
                m_rearWingDamage = 0,
                m_drsFault = 0,
                m_engineDamage = 0,
                m_gearBoxDamage = 0,
                m_vehicleFiaFlags = GetFlag(pluginManager),
                m_ersStoreEnergy = Utils.ClampFloatingValue<float>(pluginManager.LastData?.NewData?.ERSStored),
                m_ersDeployMode = 1,
                m_ersHarvestedThisLapMGUK = 100f,
                m_ersHarvestedThisLapMGUH = 1f,
                m_ersDeployedThisLap = 100f
            };

            if (pluginManager.GameName == "AssettoCorsa")
            {
                packet.m_carStatusData[0].m_ersDeployedThisLap = 100 - (Utils.ClampFloatingValue<float>(pluginManager.GetPropertyValue("DataCorePlugin.GameRawData.Physics.KersCurrentKJ")) * 100000 / Utils.ClampFloatingValue<float>(pluginManager.GetPropertyValue("DataCorePlugin.GameRawData.StaticInfo.ErsMaxJ")));

                byte ersMode;
                if (Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameRawData.Physics.KersInput")) == 1)
                {
                    ersMode = 2;
                }
                else
                {
                    ersMode = Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameRawData.Physics.ErsPowerLevel"));
                    ersMode = ersMode switch
                    {
                        1 or 2 => 1,
                        3 => 2,
                        4 or 5 => 3,
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
            if (Utils.ClampIntegerValue<byte>(pluginManager.LastData?.NewData?.Flag_Black) > 0) // There is no red flag in SimHub
                return 4;
            return 0;
        }
    }
}
