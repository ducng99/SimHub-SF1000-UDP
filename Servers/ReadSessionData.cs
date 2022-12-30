using SimHubToF12020UDP.Packets;

namespace SimHubToF12020UDP.Servers
{
    public class ReadSessionData : IReadDataService
    {
        public byte[] ReadPacketData()
        {
            return SessionDataPacket.Read();
        }
    }
}