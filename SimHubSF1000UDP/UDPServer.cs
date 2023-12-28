using System;
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
        private IPEndPoint ReceiverAddress = new(IPAddress.Parse("192.168.1.20"), 20777);

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
            ReceiverAddress = new(IPAddress.Parse(SimHubSF1000UDPSettings.Instance.ReceiverIP), SimHubSF1000UDPSettings.Instance.ReceiverPort);

            Stop();
            Start();
        }

        public void Start()
        {
            UDPClient = new();
            IsRunning = true;

            RunningTasks = SimHubSF1000UDPSettings.Instance.UDPFormat switch
            {
                UDPFormats.F12020 => new Task[]
                {
                    Task.Run(() => RunLoop(typeof(Packets_F12020.SessionDataPacket), 500)),
                    Task.Run(() => RunLoop(typeof(Packets_F12020.LapDataPacket), 50)),
                    Task.Run(() => RunLoop(typeof(Packets_F12020.CarTelemetryDataPacket), 50)),
                    Task.Run(() => RunLoop(typeof(Packets_F12020.CarStatusDataPacket), 50)),
                    Task.Run(() => RunLoop(typeof(Packets_F12020.ParticipantDataPacket), 5000)),
                },
                UDPFormats.F123 => new Task[]
                {
                    Task.Run(() => RunLoop(typeof(Packets_F123.SessionDataPacket), 500)),
                    Task.Run(() => RunLoop(typeof(Packets_F123.LapDataPacket), 8.3333)),
                    Task.Run(() => RunLoop(typeof(Packets_F123.CarTelemetryDataPacket), 8.3333)),
                    Task.Run(() => RunLoop(typeof(Packets_F123.CarStatusDataPacket), 8.3333)),
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
