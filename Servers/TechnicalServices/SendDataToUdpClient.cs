using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SimHubToF12020UDP.Servers
{
    public class SendDataToUdpClient : ISendDataService
    {
        private UdpClient udpClient;
        private IPEndPoint destination;


        public SendDataToUdpClient(
            string ip, 
            int port)
        {
            Configure(ip, port);
        }

        internal UdpClient UdpClient => udpClient;

        public void Configure(string ip, int port)
        {
            Destroy();

            /**
             * thought : add sanity check on ip and port.
             * 
             * */

            /**
             * Thought: use a factory that retuenrs a wrapper around the udp client
             * So we can test anything.
             * */

            if (IPAddress.TryParse(ip, out IPAddress address))
            {
                destination = new IPEndPoint(address, port);
                udpClient = new UdpClient();
            }
        }

        public void Destroy()
        {
            if(udpClient == null) return;

            udpClient.Close();
            udpClient = null;
        }

        public async Task SendDataAsync(byte[] sessionData)
        {
            await udpClient.SendAsync(
                sessionData, 
                sessionData.Length, 
                destination);
        }
    }
}