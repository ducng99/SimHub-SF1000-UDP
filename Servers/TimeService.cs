using System;

namespace SimHubToF12020UDP.Servers
{
    public class TimeService : ITimeService
    {
        public DateTime Now() => DateTime.Now;

        public double GetDeltaTime(DateTime timer)
        {
            return DateTime.Now.Subtract(timer).TotalMilliseconds;
        }
    }
}