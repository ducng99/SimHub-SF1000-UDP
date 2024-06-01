using SimHub.Plugins;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace SimHubSF1000UDP
{
    [PluginDescription("Add more games support for Thrustmaster™ SF1000 wheel through UDP")]
    [PluginAuthor("Maxhyt")]
    [PluginName("SimHub SF1000 UDP")]
    public class SimHubSF1000UDP : IPlugin, IWPFSettings
    {
        public SimHubSF1000UDPSettings Settings;

        /// <summary>
        /// Instance of the current plugin manager
        /// </summary>
        public PluginManager PluginManager { get; set; }

        /// <summary>
        /// Called at plugin manager stop, close/dispose anything needed here ! 
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void End(PluginManager pluginManager)
        {
            // Save settings
            this.SaveCommonSettings("GeneralSettings", Settings);

            UDPServer.DestroyInstance();
        }

        /// <summary>
        /// Returns the settings control, return null if no settings control is required
        /// </summary>
        /// <param name="pluginManager"></param>
        /// <returns></returns>
        public System.Windows.Controls.Control GetWPFSettingsControl(PluginManager pluginManager)
        {
            return new SettingsControl(this);
        }

        /// <summary>
        /// Called once after plugins startup
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void Init(PluginManager pluginManager)
        {
            SimHub.Logging.Current.Info("[SimHub SF1000 UDP] Starting plugin");

            // Load settings
            Settings = this.ReadCommonSettings("GeneralSettings", () => new SimHubSF1000UDPSettings());

            // Warning v1 found
            if (File.Exists("SimHubToF12020UDP.dll"))
            {
                MessageBox.Show("Old version detected. Please close SimHub and remove SimHubToF12020UDP.dll file.", "SimHub SF1000 UDP", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Regex F1gameMatch = new(@"^F120\d{2}$");

            // Only run if not in F1 game
            if (!F1gameMatch.IsMatch(pluginManager.GameName))
            {
                UDPServer.Instance.Start();
            }
        }
    }
}