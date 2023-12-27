using SimHubSF1000UDP.Packets_F12020;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SimHubSF1000UDP
{
    internal class UDPServer
    {
        private static UDPServer _instance = null;
        private UdpClient udpClient;
        private IPEndPoint sender = new(IPAddress.Parse("192.168.1.20"), 20777);

        private Task[] RunningTasks = new Task[0];

        public static UDPServer Instance
        {
            get
            {
                _instance ??= new UDPServer();
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public static void DestroyInstance()
        {
            Instance.udpClient.Close();
            Instance.udpClient = null;

            Task.WaitAll(Instance.RunningTasks);

            Instance = null;
        }

        private UDPServer()
        {
            udpClient = new();
        }

        public void UpdateIPAddress(IPAddress ipAddress, int port)
        {
            sender = new(ipAddress, port);
        }

        public void Init()
        {
            RunningTasks = new Task[]
            {
                Task.Run(LoopSessionData),
                Task.Run(LoopLapData),
                Task.Run(LoopCarTelemetryData),
                Task.Run(LoopCarStatusData),
                Task.Run(LoopParticipantData),
            };
        }

        public async void LoopSessionData()
        {
            var timer = DateTime.Now;

            while (udpClient != null)
            {
                var deltaTime = DateTime.Now.Subtract(timer).TotalMilliseconds;

                if (deltaTime >= 500)
                {
                    timer = DateTime.Now;

                    try
                    {
                        var sessionData = SessionDataPacket.Read();
                        await udpClient.SendAsync(sessionData, sessionData.Length, sender);
                    }
                    catch (Exception ex)
                    {
                        SimHub.Logging.Current.Error("Failed sending UDP packet\n" + ex);
                    }
                }

                await Task.Delay(250);
            }
        }

        public async void LoopCarTelemetryData()
        {
            var timer = DateTime.Now;

            while (udpClient != null)
            {
                var deltaTime = DateTime.Now.Subtract(timer).TotalMilliseconds;

                if (deltaTime >= 16.666667)
                {
                    timer = DateTime.Now;

                    try
                    {
                        var carTelemetryData = CarTelemetryDataPacket.Read();
                        await udpClient.SendAsync(carTelemetryData, carTelemetryData.Length, sender);
                    }
                    catch (Exception ex)
                    {
                        SimHub.Logging.Current.Error("Failed sending UDP packet\n" + ex);
                    }
                }

                await Task.Delay(8);
            }
        }

        public async void LoopCarStatusData()
        {
            var timer = DateTime.Now;

            while (udpClient != null)
            {
                var deltaTime = DateTime.Now.Subtract(timer).TotalMilliseconds;

                if (deltaTime >= 16.666667)
                {
                    timer = DateTime.Now;

                    try
                    {
                        var carStatusData = CarStatusDataPacket.Read();
                        await udpClient.SendAsync(carStatusData, carStatusData.Length, sender);
                    }
                    catch (Exception ex)
                    {
                        SimHub.Logging.Current.Error("Failed sending UDP packet\n" + ex);
                    }
                }

                await Task.Delay(8);
            }
        }

        public async void LoopLapData()
        {
            var timer = DateTime.Now;

            while (udpClient != null)
            {
                var deltaTime = DateTime.Now.Subtract(timer).TotalMilliseconds;

                if (deltaTime >= 16.666667)
                {
                    timer = DateTime.Now;

                    try
                    {
                        var lapData = LapDataPacket.Read();
                        await udpClient.SendAsync(lapData, lapData.Length, sender);
                    }
                    catch (Exception ex)
                    {
                        SimHub.Logging.Current.Error("Failed sending UDP packet\n" + ex);
                    }
                }

                await Task.Delay(8);
            }
        }
        
        public async void LoopParticipantData()
        {
            var timer = DateTime.Now;

            while (udpClient != null)
            {
                var deltaTime = DateTime.Now.Subtract(timer).TotalSeconds;

                if (deltaTime >= 5)
                {
                    timer = DateTime.Now;

                    try
                    {
                        var participantData = ParticipantDataPacket.Read();
                        await udpClient.SendAsync(participantData, participantData.Length, sender);
                    }
                    catch (Exception ex)
                    {
                        SimHub.Logging.Current.Error("Failed sending UDP packet\n" + ex);
                    }
                }

                await Task.Delay(2500);
            }
        }
    }
}
