using System.Threading.Tasks;

namespace SimHubToF12020UDP.Servers
{
    public interface ISendDataService
    {
        Task SendDataAsync(byte[] sessionData);
    }
}