using System.Threading.Tasks;

namespace SimHubToF12020UDP.Servers
{
    public interface ITaskSequencerService
    {
        Task WaitFor(int delay);
    }
}