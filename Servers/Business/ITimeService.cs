using System;

namespace SimHubToF12020UDP.Servers
{
    public interface ITimeService
    {
        DateTime Now();

        double GetDeltaTime(DateTime timer);
    }
}