﻿using SimHubToF12020UDP;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimHubToF12020UDPPlugin
{
    public partial class SettingsControl : UserControl
    {
        public SimHubToF12020UDP Plugin { get; }

        public SettingsControl()
        {
            InitializeComponent();
            HeaderSection.Title = "SimHub To F12020 UDP v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        }

        public SettingsControl(SimHubToF12020UDP plugin) : this()
        {
            this.Plugin = plugin;

            if (System.Net.IPAddress.TryParse(Plugin.Settings.ReceiverIP, out var ipAddress))
            {
                ReceiverIP.IPAddress = ipAddress;
                Display_IP.Text = ipAddress.ToString();
                UDPServer.Instance.UpdateIPAddress(ipAddress, Plugin.Settings.ReceiverPort);
            }

            ReceiverPort.Text = Plugin.Settings.ReceiverPort.ToString();
            Display_Port.Text = Plugin.Settings.ReceiverPort.ToString();
            OnlySendDataIfGameRunning.IsChecked = Plugin.Settings.OnlySendDataIfGameRunning;
        }

        private void SaveButtonPrimary_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Plugin.Settings.ReceiverIP = ReceiverIP.IPAddress.ToString();
            Display_IP.Text = Plugin.Settings.ReceiverIP;

            Plugin.Settings.ReceiverPort = Utils.ClampIntegerValue<ushort>(ReceiverPort.Text);
            Display_Port.Text = Plugin.Settings.ReceiverPort.ToString();

            UDPServer.Instance.UpdateIPAddress(ReceiverIP.IPAddress, Plugin.Settings.ReceiverPort);

            Plugin.Settings.OnlySendDataIfGameRunning = OnlySendDataIfGameRunning.IsChecked ?? true;
        }

        private void ReceiverPort_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9))
            {
                e.Handled = true;
            }
        }
    }
}
