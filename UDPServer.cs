using SimHubToF12020UDP.Packets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SimHubToF12020UDPPlugin
{
    internal class UDPServer
    {
        private static UDPServer _instance = null;
        private UdpClient udpClient;
        private IPEndPoint sender = new(IPAddress.Parse("192.168.1.20"), 20777);

        public IPAddress ReceiverIP
        {
            private get { return null; }
            set
            {
                sender = new(value, 20777);
            }
        }

        public static UDPServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UDPServer();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        private UDPServer()
        {
            SimHub.Logging.Current.Info("UDP Server starting");

            do
            {
                try
                {
                    udpClient = new();
                }
                catch (Exception) { }

                Thread.Sleep(1000);
            } while (udpClient == null);

            SimHub.Logging.Current.Info("UDP Server started!");
        }

        public void Init()
        {
            Task.Run(LoopSessionData);
            Task.Run(LoopLapData);
            Task.Run(LoopCarTelemetryData);
            Task.Run(LoopCarStatusData);
            Task.Run(LoopCarSetupData);
        }

        public async void LoopSessionData()
        {
            var timer = DateTime.Now;

            while (true)
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
                        SimHub.Logging.Current.Error("Failed to send UDP packet\n" + ex);
                    }
                }

                await Task.Delay(250);
            }
        }

        public async void LoopCarSetupData()
        {
            var timer = DateTime.Now;

            while (true)
            {
                var deltaTime = DateTime.Now.Subtract(timer).TotalMilliseconds;

                if (deltaTime >= 500)
                {
                    timer = DateTime.Now;

                    try
                    {
                        var carSetupData = CarSetupDataPacket.Read();
                        await udpClient.SendAsync(carSetupData, carSetupData.Length, sender);
                    }
                    catch (Exception ex)
                    {
                        SimHub.Logging.Current.Error("Failed to send UDP packet\n" + ex);
                    }
                }

                await Task.Delay(250);
            }
        }

        public async void LoopCarTelemetryData()
        {
            var timer = DateTime.Now;

            while (true)
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
                        SimHub.Logging.Current.Error("Failed to send UDP packet\n" + ex);
                    }
                }

                await Task.Delay(8);
            }
        }

        public async void LoopCarStatusData()
        {
            var timer = DateTime.Now;

            while (true)
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
                        SimHub.Logging.Current.Error("Failed to send UDP packet\n" + ex);
                    }
                }

                await Task.Delay(8);
            }
        }

        public async void LoopLapData()
        {
            var timer = DateTime.Now;

            while (true)
            {
                var deltaTime = DateTime.Now.Subtract(timer).TotalMilliseconds;

                if (deltaTime >= 16.666667)
                {
                    timer = DateTime.Now;

                    try
                    {
                        var lapdata = LapDataPacket.Read();
                        await udpClient.SendAsync(lapdata, lapdata.Length, sender);
                    }
                    catch (Exception ex)
                    {
                        SimHub.Logging.Current.Error("Failed to send UDP packet\n" + ex);
                    }
                }

                await Task.Delay(8);
            }
        }
    }
}
