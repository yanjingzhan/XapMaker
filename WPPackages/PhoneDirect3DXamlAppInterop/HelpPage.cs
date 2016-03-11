namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Info;
    using Microsoft.Phone.Shell;
    using Microsoft.Phone.Tasks;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Navigation;

    public partial class HelpPage : PhoneApplicationPage
    {
        public HelpPage()
        {
            this.InitializeComponent();

            SystemTray.GetProgressIndicator(this).Text = (AppResources.ApplicationTitle2);
        }

        private void contactBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            EmailComposeTask task = new EmailComposeTask();
            task.To = (AppResources.AboutContact);
            task.Subject = (AppResources.EmailSubjectText);
            task.Body = (string.Format(AppResources.EmailBodyText, DeviceStatus.DeviceName));
            task.Show();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string str = null;
            base.NavigationContext.QueryString.TryGetValue("index", out str);
            if (str != null)
            {
                this.MainPivotControl.SelectedIndex = (int.Parse(str));
            }
            base.OnNavigatedTo(e);
        }
    }
}

