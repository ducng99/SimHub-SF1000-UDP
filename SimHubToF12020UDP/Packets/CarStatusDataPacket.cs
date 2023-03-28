﻿using SimHub.Plugins;
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
                m_packetId = 7
            };

            var packet = new PacketCarStatusData
            {
                m_header = header,
                m_carStatusData = new CarStatusData[22]
            };

            packet.m_carStatusData[0] = new CarStatusData
            {
                m_tractionControl = Utils.ClampIntegerValue<byte>(Math.Min(Utils.ClampIntegerValue<int>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TCLevel")), 2)),
                m_antiLockBrakes = Utils.ClampIntegerValue<byte>(Math.Min(Utils.ClampIntegerValue<int>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.ABSLevel")), 1)),
                m_fuelMix = 1,
                m_frontBrakeBias = Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.BrakeBias")),
                m_pitLimiterStatus = Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.PitLimiterOn")),
                m_fuelInTank = Utils.ClampFloatingValue<float>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Fuel")),
                m_fuelCapacity = Utils.ClampFloatingValue<float>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.MaxFuel")),
                m_fuelRemainingLaps = Utils.ClampFloatingValue<float>(pluginManager.GetPropertyValue("DataCorePlugin.Computed.Fuel_RemainingLaps")),
                m_maxRPM = Utils.ClampIntegerValue<ushort>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CarSettings_MaxRPM")),
                m_idleRPM = Utils.ClampIntegerValue<ushort>(Convert.ToDouble(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CarSettings_MaxRPM")) * 0.27),
                m_maxGears = Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.CarSettings_MaxGears")),
                m_drsAllowed = Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.DRSAvailable")),
                m_drsActivationDistance = (ushort)(Convert.ToBoolean(pluginManager.GetPropertyValue("DataCorePlugin.GameData.DRSAvailable")) ? 0 : 50),
                m_tyresWear = new byte[4]
                {
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreWearRearLeft"))),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreWearRearRight"))),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreWearFrontLeft"))),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreWearFrontRight"))),
                },
                m_actualTyreCompound = 16,
                m_visualTyreCompound = 16,
                m_tyresAgeLaps = 0,
                m_tyresDamage = new byte[4]
                {
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreWearRearLeft"))),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreWearRearRight"))),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreWearFrontLeft"))),
                    (byte)(100 - Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.TyreWearFrontRight"))),
                },
                m_frontLeftWingDamage = 0,
                m_frontRightWingDamage = 0,
                m_rearWingDamage = 0,
                m_drsFault = 0,
                m_engineDamage = 0,
                m_gearBoxDamage = 0,
                m_vehicleFiaFlags = GetFlag(pluginManager),
                m_ersStoreEnergy = Utils.ClampFloatingValue<float>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.ERSStored")),
                m_ersDeployMode = 1,
                m_ersHarvestedThisLapMGUK = 0,
                m_ersHarvestedThisLapMGUH = 0,
                m_ersDeployedThisLap = 0
            };

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
            if (Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Flag_Green")) > 0)
                return 1;
            if (Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Flag_Blue")) > 0)
                return 2;
            if (Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Flag_Yellow")) > 0)
                return 3;
            if (Utils.ClampIntegerValue<byte>(pluginManager.GetPropertyValue("DataCorePlugin.GameData.Flag_Red")) > 0)
                return 4;
            return 0;
        }
    }
}
