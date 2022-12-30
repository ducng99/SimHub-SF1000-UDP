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
        private IPEndPoint sender;
        public OneLoopSessionData(UdpClient udpClient,
            ExecuteMode executeMode)
        {
            this.udpClient = udpClient;
            this.executeMode = executeMode;
        }

        public async void LoopSessionData()
        {
            var timer = DateTime.Now;

            while (udpClient != null)
            {
                var deltaTime = GetDeltaTime(timer);

                if (deltaTime >= 500)
                {
                    timer = DateTime.Now;

                    try
                    {
                        var sessionData = SessionDataPacket.Read();
                        await SendDataAsync(sessionData);
                    }
                    catch (Exception ex)
                    {
                        SimHub.Logging.Current.Error("Failed to send UDP packet\n" + ex);
                    }
                }
                await WaitFor250Ms();

                if(executeMode == ExecuteMode.Once)
                {
                    break;
                }
            }
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
