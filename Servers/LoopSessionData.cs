using System;
using System.Net;
using System.Net.Sockets;

namespace SimHubToF12020UDP.Servers
{
    public class OneLoopSessionData
    {
        private const int Delta250Ms = 250;

        private readonly UdpClient udpClient;
        private readonly ExecuteMode executeMode;

        private readonly ILoggerService loggerService;
        private readonly ITimeService timeService;
        private readonly ISendDataService sendDataService;
        private readonly IReadDataService readDataService;
        private readonly int deltaToEnterSendingLoop;
        private readonly int waitLoopInterval;
        private readonly ITaskSequencerService taskSequencerService;

        public OneLoopSessionData(UdpClient udpClient,
            ExecuteMode executeMode,
            ILoggerService loggerService,
            ITimeService timeService,
            ISendDataService sendDataService,
            ITaskSequencerService taskSequencerService,
            IReadDataService readDataService,
            int deltaToEnterSendingLoop, 
            int waitLoopInterval)
        {
            this.udpClient = udpClient;
            this.executeMode = executeMode;
            this.loggerService = loggerService;
            this.timeService = timeService;
            this.sendDataService = sendDataService;
            this.taskSequencerService = taskSequencerService;
            
            // Specific to session data
            this.readDataService = readDataService;
            this.deltaToEnterSendingLoop = deltaToEnterSendingLoop;
            this.waitLoopInterval = waitLoopInterval;
        }

        public async void LoopSessionData()
        {
            var timer = timeService.Now();

            /**
             * Thought: We should have a way to stop the loop when running.
             * */

            while (udpClient != null)
            {
                var deltaTime = timeService.GetDeltaTime(timer);

                if (deltaTime >= deltaToEnterSendingLoop)
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

                await taskSequencerService.WaitFor(waitLoopInterval);

                if (executeMode == ExecuteMode.Once)
                {
                    break;
                }
            }
        }
    }
}