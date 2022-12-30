using System.Threading.Tasks;

namespace SimHubToF12020UDP.Servers
{
    public class TaskSequencerService : ITaskSequencerService
    {
        public async Task WaitFor(int delay)
        {
            await Task.Delay(delay);
        }
    }
}