using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using SimHubToF12020UDP.Packets;

namespace SimHubToF12020UDP.Servers
{
    public class OneLoopSessionData
    {
        private readonly UdpClient udpClient;
        private readonly ExecuteMode executeMode;
        private readonly ILoggerService loggerService;
        private readonly ITimeService timeService;
        private IPEndPoint sender;
        public OneLoopSessionData(UdpClient udpClient,
            ExecuteMode executeMode,
            ILoggerService loggerService, 
            ITimeService timeService)
        {
            this.udpClient = udpClient;
            this.executeMode = executeMode;
            this.loggerService = loggerService;
            this.timeService = timeService;
        }

        public async void LoopSessionData()
        {
            var timer = timeService.Now();

            while (udpClient != null)
            {
              var  deltaTime = timeService.GetDeltaTime(timer);

                if (deltaTime >= 500)
                {
                    timer = timeService.Now();

                    try
                    {
                        var sessionData = ReadSessionPacketData();
                        await SendDataAsync(sessionData);
                    }
                    catch (Exception ex)
                    {
                        loggerService.Error("Failed to send UDP packet\n" + ex);
                    }
                }
                await WaitFor250Ms();

                if (executeMode == ExecuteMode.Once)
                {
                    break;
                }
            }
        }

        protected virtual byte[] ReadSessionPacketData()
        {
            return SessionDataPacket.Read();
        }

        protected virtual async Task WaitFor250Ms()
        {
            await Task.Delay(250);
        }

        protected virtual async Task SendDataAsync(byte[] sessionData)
        {
            await udpClient.SendAsync(sessionData, sessionData.Length, sender);
        }

        protected virtual double GetDeltaTime(DateTime timer)
        {
            return DateTime.Now.Subtract(timer).TotalMilliseconds;
        }
    }
}