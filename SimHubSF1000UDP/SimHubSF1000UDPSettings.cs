namespace SimHubSF1000UDP
{
    /// <summary>
    /// Settings class, make sure it can be correctly serialized using JSON.net
    /// </summary>
    public class SimHubSF1000UDPSettings
    {
        public static SimHubSF1000UDPSettings Instance;

        public string ReceiverIP = "192.168.1.2";
        public int ReceiverPort = 20777;
        public bool OnlySendDataIfGameRunning = true;

        public SimHubSF1000UDPSettings()
        {
            Instance = this;
        }
    }
}