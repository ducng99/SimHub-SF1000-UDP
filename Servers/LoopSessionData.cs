using System;
using System.Net;
using System.Net.Sockets;

namespace SimHubToF12020UDP.Servers
{
    public class OneLoopSessionData
    {
        private const int Delta500Ms = 500;
        private const int Delta250Ms = 250;

        private readonly UdpClient udpClient;
        private readonly ExecuteMode executeMode;

        private readonly ILoggerService loggerService;
        private readonly ITimeService timeService;
        private readonly ISendDataService sendDataService;
        private readonly IReadDataService readDataService;
        private readonly ITaskSequencerService taskSequencerService;

        public OneLoopSessionData(UdpClient udpClient,
            ExecuteMode executeMode,
            ILoggerService loggerService,
            ITimeService timeService,
            ISendDataService sendDataService,
            IReadDataService readDataService, 
            ITaskSequencerService taskSequencerService)
        {
            this.udpClient = udpClient;
            this.executeMode = executeMode;
            this.loggerService = loggerService;
            this.timeService = timeService;
            this.sendDataService = sendDataService;
            this.readDataService = readDataService;
            this.taskSequencerService = taskSequencerService;
        }

        public async void LoopSessionData()
        {
            var timer = timeService.Now();

            while (udpClient != null)
            {
                var deltaTime = timeService.GetDeltaTime(timer);

                if (deltaTime >= Delta500Ms)
                {
                    timer = timeService.Now();

                    try
                    {
                        var sessionData = readDataService.ReadPacketData();
                        await sendDataService.SendDataAsync(sessionData);
                    }
                    catch (Exception ex)
                    {
                        loggerService.Error("Failed to send UDP packet\n" + ex);
                    }
                }

                await taskSequencerService.WaitFor(Delta250Ms);

                if (executeMode == ExecuteMode.Once)
                {
                    break;
                }
            }
        }
    }
}