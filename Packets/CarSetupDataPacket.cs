﻿using SimHub.Plugins;
using System;
using System.Runtime.InteropServices;
using static SimHubToF12020UDP.F12020Struct;

namespace SimHubToF12020UDP.Packets
{
    internal static class CarSetupDataPacket
    {
        private static uint FrameCount = 0;

        public static byte[] Read()
        {
            var pluginManager = PluginManager.GetInstance();

            var start = pluginManager.GetPropertyValue("DataCorePlugin.GameRunning");

            if (start == null || !Convert.ToBoolean(start))
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
                m_packetId = 5
            };

            var packet = new PacketCarSetupData
            {
                m_header = header,
                m_carSetups = new CarSetupData[22]
            };

            packet.m_carSetups[0] = new CarSetupData
            {
                m_frontWing = 5,
                m_rearWing = 5,
                m_onThrottle = 100,
                m_offThrottle = 50,
                m_frontCamber = -2f,
                m_rearCamber = -1.2f,
                m_frontToe = 0.07f,
                m_rearToe = 0.2f,
                m_frontSuspension = 2,
                m_rearSuspension = 7,
                m_frontAntiRollBar = 2,
                m_rearAntiRollBar = 7,
                m_frontSuspensionHeight = 2,
                m_rearSuspensionHeight = 7,
                m_brakePressure = 100,
                m_brakeBias = 56,
                m_rearLeftTyrePressure = 23.5f,
                m_rearRightTyrePressure = 23.5f,
                m_frontLeftTyrePressure = 25f,
                m_frontRightTyrePressure = 25f,
                m_ballast = 6,
                m_fuelLoad = 20,
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
