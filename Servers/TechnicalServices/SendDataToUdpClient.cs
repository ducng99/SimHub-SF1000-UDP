using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SimHubToF12020UDP.Servers
{
    public class SendDataToUdpClient : ISendDataService
    {
        private readonly UdpClient udpClient;
        private readonly IPEndPoint sender;

        public SendDataToUdpClient(UdpClient udpClient, IPEndPoint sender)
        {
            this.udpClient = udpClient;
            this.sender = sender;
        }
        public async Task SendDataAsync(byte[] sessionData)
        {
            await udpClient.SendAsync(sessionData, sessionData.Length, sender);
        }
    }
}