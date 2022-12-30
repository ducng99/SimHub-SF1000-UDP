using System.Windows.Controls;

namespace SimHubToF12020UDPPlugin
{
    /// <summary>
    /// Logique d'interaction pour SettingsControlDemo.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SimHubToF12020UDP Plugin { get; }

        public SettingsControl()
        {
            InitializeComponent();
        }

        /**
         * To be changed to data binding.
         * 
         * */
        public SettingsControl(SimHubToF12020UDP plugin) : this()
        {
            this.Plugin = plugin;

            if (System.Net.IPAddress.TryParse(Plugin.Settings.ReceiverIP, out var ipAddress))
            {
                ReceiverIP.IPAddress = ipAddress;
                Display_IP.Text = ipAddress.ToString();
                UDPServer.Instance.ReceiverIP = ipAddress;
            }
        }

        /**
         * To be changed to data binding.
         * 
         * */
        private void SHButtonPrimary_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UDPServer.Instance.ReceiverIP = ReceiverIP.IPAddress;
            Display_IP.Text = ReceiverIP.IPAddress.ToString();
            Plugin.Settings.ReceiverIP = ReceiverIP.IPAddress.ToString();
        }
    }
}
