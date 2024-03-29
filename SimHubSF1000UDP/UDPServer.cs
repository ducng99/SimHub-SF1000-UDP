﻿using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

#nullable enable
namespace SimHubSF1000UDP
{
    internal class UDPServer
    {
        private static UDPServer? _instance = null;
        private UdpClient? UDPClient = null;
        private IPEndPoint ReceiverAddress = new(IPAddress.Parse(SimHubSF1000UDPSettings.Instance.ReceiverIP), SimHubSF1000UDPSettings.Instance.ReceiverPort);
        private double SendDelayMS = 1000.0 / 60;

        private bool IsRunning = false;
        private Task[] RunningTasks = new Task[0];

        public static UDPServer Instance
        {
            get
            {
                _instance ??= new UDPServer();
                return _instance;
            }
        }

        public static void DestroyInstance()
        {
            Instance.Stop();

            _instance = null;
        }

        public void Update()
        {
            Stop();
            Start();
        }

        public void Start()
        {
            UDPClient = new();
            IsRunning = true;
            ReceiverAddress = new(IPAddress.Parse(SimHubSF1000UDPSettings.Instance.ReceiverIP), SimHubSF1000UDPSettings.Instance.ReceiverPort);
            SendDelayMS = 1000.0 / SimHubSF1000UDPSettings.Instance.UDPSendRate;

            SimHub.Logging.Current.Info("[SimHub SF1000 UDP] UDP server started. Sending to " + SimHubSF1000UDPSettings.Instance.ReceiverIP + ":" + SimHubSF1000UDPSettings.Instance.ReceiverPort + " every " + SendDelayMS + "ms");

            RunningTasks = SimHubSF1000UDPSettings.Instance.UDPFormat switch
            {
                UDPFormats.F12020 => new Task[]
                {
                    Task.Run(() => RunLoop(typeof(Packets_F12020.SessionDataPacket), 500)),
                    Task.Run(() => RunLoop(typeof(Packets_F12020.LapDataPacket), SendDelayMS)),
                    Task.Run(() => RunLoop(typeof(Packets_F12020.CarTelemetryDataPacket), SendDelayMS)),
                    Task.Run(() => RunLoop(typeof(Packets_F12020.CarStatusDataPacket), SendDelayMS)),
                    Task.Run(() => RunLoop(typeof(Packets_F12020.ParticipantDataPacket), 5000)),
                },
                UDPFormats.F123 => new Task[]
                {
                    Task.Run(() => RunLoop(typeof(Packets_F123.SessionDataPacket), 500)),
                    Task.Run(() => RunLoop(typeof(Packets_F123.LapDataPacket), SendDelayMS)),
                    Task.Run(() => RunLoop(typeof(Packets_F123.CarTelemetryDataPacket), SendDelayMS)),
                    Task.Run(() => RunLoop(typeof(Packets_F123.CarStatusDataPacket), SendDelayMS)),
                    Task.Run(() => RunLoop(typeof(Packets_F123.ParticipantDataPacket), 5000)),
                    Task.Run(() => RunLoop(typeof(Packets_F123.CarDamageDataPacket), 100))
                },
                _ => new Task[0]
            };
        }

        private void Stop()
        {
            IsRunning = false;
            Task.WaitAll(RunningTasks);

            UDPClient?.Close();
            UDPClient?.Dispose();
            UDPClient = null;

            SimHub.Logging.Current.Info("[SimHub SF1000 UDP] UDP server stopped");
        }

        private async Task RunLoop(Type outputPacket, double sendRateInMs)
        {
            var timer = Stopwatch.StartNew();

            while (IsRunning)
            {
                if (timer.ElapsedMilliseconds >= sendRateInMs)
                {
                    timer.Restart();

                    try
                    {
                        var sessionData = (byte[])outputPacket.GetMethod("Read").Invoke(null, null);
                        if (UDPClient != null && sessionData.Length > 0)
                        {
                            UDPClient.Send(sessionData, sessionData.Length, ReceiverAddress);
                        }
                    }
                    catch (Exception ex)
                    {
                        SimHub.Logging.Current.Error("[SimHub SF1000 UDP] Failed sending UDP packet\n" + ex);
                    }
                }

                await Task.Delay((int)(sendRateInMs / 2));
            }

            timer.Stop();
        }
    }
}
