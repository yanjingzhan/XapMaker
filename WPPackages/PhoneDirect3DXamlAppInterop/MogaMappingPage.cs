namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using PhoneDirect3DXamlAppComponent;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Diagnostics;
    using System.IO.IsolatedStorage;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public partial class MogaMappingPage : PhoneApplicationPage
    {

        private string[] appFunctionList = new string[] { "A", "B", "L", "R", "Emulator Menu" };


        public MogaMappingPage()
        {
            this.InitializeComponent();
            SystemTray.GetProgressIndicator(this).Text = (AppResources.ApplicationTitle2);
            base.ApplicationBar.BackgroundColor = ((Color)Application.Current.Resources["CustomChromeColor"]);
            base.ApplicationBar.ForegroundColor = ((Color)Application.Current.Resources["CustomForegroundColor"]);
            this.Abtn.ItemsSource = (this.appFunctionList);
            this.Bbtn.ItemsSource = (this.appFunctionList);
            this.Xbtn.ItemsSource = (this.appFunctionList);
            this.Ybtn.ItemsSource = (this.appFunctionList);
            this.L1btn.ItemsSource = (this.appFunctionList);
            this.R1btn.ItemsSource = (this.appFunctionList);
            this.L2btn.ItemsSource = (this.appFunctionList);
            this.R2btn.ItemsSource = (this.appFunctionList);
            this.LeftJoystickbtn.ItemsSource = (this.appFunctionList);
            this.RightJoystickbtn.ItemsSource = (this.appFunctionList);
            this.Abtn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaA, 2.0);
            this.Bbtn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaB, 2.0);
            this.Xbtn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaX, 2.0);
            this.Ybtn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaY, 2.0);
            this.L1btn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaL1, 2.0);
            this.L2btn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaL2, 2.0);
            this.R1btn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaR1, 2.0);
            this.R2btn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaR2, 2.0);
            this.LeftJoystickbtn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaLeftJoystick, 2.0);
            this.RightJoystickbtn.SelectedIndex = (int)Math.Log((double)EmulatorSettings.Current.MogaRightJoystick, 2.0);
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            if (base.NavigationService.CanGoBack)
            {
                base.NavigationService.GoBack();
            }
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            EmulatorSettings.Current.MogaA = ((int)Math.Pow(2.0, (double)this.Abtn.SelectedIndex));
            EmulatorSettings.Current.MogaB = ((int)Math.Pow(2.0, (double)this.Bbtn.SelectedIndex));
            EmulatorSettings.Current.MogaX = ((int)Math.Pow(2.0, (double)this.Xbtn.SelectedIndex));
            EmulatorSettings.Current.MogaY = ((int)Math.Pow(2.0, (double)this.Ybtn.SelectedIndex));
            EmulatorSettings.Current.MogaL1 = ((int)Math.Pow(2.0, (double)this.L1btn.SelectedIndex));
            EmulatorSettings.Current.MogaL2 = ((int)Math.Pow(2.0, (double)this.L2btn.SelectedIndex));
            EmulatorSettings.Current.MogaR1 = ((int)Math.Pow(2.0, (double)this.R1btn.SelectedIndex));
            EmulatorSettings.Current.MogaR2 = ((int)Math.Pow(2.0, (double)this.R2btn.SelectedIndex));
            EmulatorSettings.Current.MogaLeftJoystick = ((int)Math.Pow(2.0, (double)this.LeftJoystickbtn.SelectedIndex));
            EmulatorSettings.Current.MogaRightJoystick = ((int)Math.Pow(2.0, (double)this.RightJoystickbtn.SelectedIndex));
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings["MogaAKey"] = (int)Math.Pow(2.0, (double)this.Abtn.SelectedIndex);
            settings["MogaBKey"] = (int)Math.Pow(2.0, (double)this.Bbtn.SelectedIndex);
            settings["MogaXKey"] = (int)Math.Pow(2.0, (double)this.Xbtn.SelectedIndex);
            settings["MogaYKey"] = (int)Math.Pow(2.0, (double)this.Ybtn.SelectedIndex);
            settings["MogaL1Key"] = (int)Math.Pow(2.0, (double)this.L1btn.SelectedIndex);
            settings["MogaL2Key"] = (int)Math.Pow(2.0, (double)this.L2btn.SelectedIndex);
            settings["MogaR1Key"] = (int)Math.Pow(2.0, (double)this.R1btn.SelectedIndex);
            settings["MogaR2Key"] = (int)Math.Pow(2.0, (double)this.R2btn.SelectedIndex);
            settings["MogaLeftJoystickKey"] = (int)Math.Pow(2.0, (double)this.LeftJoystickbtn.SelectedIndex);
            settings["MogaRightJoystickKey"] = (int)Math.Pow(2.0, (double)this.RightJoystickbtn.SelectedIndex);
            settings.Save();
            if (base.NavigationService.CanGoBack)
            {
                base.NavigationService.GoBack();
            }
        }
    }
}

