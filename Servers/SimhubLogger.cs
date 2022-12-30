namespace SimHubToF12020UDP.Servers
{
    public class SimhubLogger : ILoggerService
    {
        public void Error(string message)
        {
            SimHub.Logging.Current.Error(message);
        }
    }
}