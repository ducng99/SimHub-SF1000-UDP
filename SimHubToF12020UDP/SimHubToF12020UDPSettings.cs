namespace SimHubToF12020UDPPlugin
{
    /// <summary>
    /// Settings class, make sure it can be correctly serialized using JSON.net
    /// </summary>
    public class SimHubToF12020UDPSettings
    {
        public static SimHubToF12020UDPSettings Instance;

        public string ReceiverIP = "192.168.1.2";
        public int ReceiverPort = 20777;
        public bool OnlySendDataIfGameRunning = true;

        public SimHubToF12020UDPSettings()
        {
            Instance = this;
        }
    }
}