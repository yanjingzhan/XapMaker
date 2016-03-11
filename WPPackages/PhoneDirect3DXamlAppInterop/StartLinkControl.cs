namespace PhoneDirect3DXamlAppInterop
{
    using Coding4Fun.Toolkit.Controls;
    using Microsoft.Phone.Controls;
    using PhoneDirect3DXamlAppComponent;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using Telerik.Windows.Controls;
    using Windows.Foundation;

    public partial class StartLinkControl : UserControl
    {
        private bool initdone;
        public static Direct3DBackground m_d3dBackground;

        public StartLinkControl()
        {
            this.InitializeComponent();
            this.txtAddress.Text = (App.metroSettings.LastIPAddress);
            this.txtTimeout.Text = (App.metroSettings.LastTimeout.ToString());
            base.Loaded += (s1, e1) =>
                {
                    this.initdone = true;
                };
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            m_d3dBackground.StopConnectLoop();
            this.ClosePopup();
        }

        private void ClosePopup()
        {
            (base.Parent as Popup).IsOpen = (false);
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            App.metroSettings.LastIPAddress = this.txtAddress.Text;
            App.metroSettings.LastTimeout = int.Parse(this.txtTimeout.Text);
            if (this.rolePicker.SelectedIndex == 0)
            {
                this.ConnectButton.IsEnabled = (false);
                string ipaddress = m_d3dBackground.SetupSocket(true, 2, int.Parse(this.txtTimeout.Text), "");
                this.tblkStatus.Foreground = ((SolidColorBrush)Application.Current.Resources["PhoneForegroundBrush"]);
                this.tblkStatus.Text = (string.Format(AppResources.HostIPAddressText, ipaddress));
                IAsyncOperation<int> asyncAction = m_d3dBackground.ConnectSocket();
                await asyncAction;
                if (asyncAction.GetResults() == 0)
                {
                    this.tblkStatus.Foreground = (new SolidColorBrush(Colors.Green));
                    this.tblkStatus.Text = (AppResources.LinkConnectedText);
                }
                else
                {
                    new SolidColorBrush(Colors.Red);
                    this.tblkStatus.Text = (AppResources.LinkErrorText);
                }
                this.ConnectButton.IsEnabled = (true);
            }
            else
            {
                this.ConnectButton.IsEnabled=(false);
                m_d3dBackground.SetupSocket(false, 2, int.Parse(this.txtTimeout.Text), this.txtAddress.Text);
                IAsyncOperation<int> asyncAction = m_d3dBackground.ConnectSocket();
                await asyncAction;
                if (asyncAction.GetResults() == 0)
                {
                    this.tblkStatus.Foreground = (new SolidColorBrush(Colors.Green));
                    this.tblkStatus.Text = (AppResources.LinkConnectedText);
                }
                else
                {
                    new SolidColorBrush(Colors.Red);
                    this.tblkStatus.Text = (AppResources.LinkErrorText);
                }
                this.ConnectButton.IsEnabled = (true);
            }
        }


        private void rolePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                if (this.rolePicker.SelectedIndex == 0)
                {
                    this.txtAddress.Visibility = (System.Windows.Visibility)(1);
                    this.tblkStatus.Text = (AppResources.TapStartServerIPText);
                    this.ConnectButton.Content = (AppResources.StartServerText);
                }
                else
                {
                    this.txtAddress.Visibility = (System.Windows.Visibility)(0);
                    this.tblkStatus.Text = (AppResources.StartServerOtherText);
                    this.ConnectButton.Content = (AppResources.ConnectText);
                }
            }
        }

    }
}

