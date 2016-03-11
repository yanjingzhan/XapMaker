namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Devices.Sensors;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using Microsoft.Xna.Framework;
    using PhoneDirect3DXamlAppComponent;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Diagnostics;
    using System.IO.IsolatedStorage;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    public partial class MotionMappingPage : PhoneApplicationPage
    {
        private string[] appFunctionList = new string[] { "Left", "Right", "Up", "Down", "A", "B", "L", "R", AppResources.NoneButtonText };

        public MotionMappingPage()
        {
            this.InitializeComponent();
            SystemTray.GetProgressIndicator(this).Text=(AppResources.ApplicationTitle2);

            base.ApplicationBar.BackgroundColor = ((System.Windows.Media.Color)Application.Current.Resources["CustomChromeColor"]);
            base.ApplicationBar.ForegroundColor = ((System.Windows.Media.Color)Application.Current.Resources["CustomForegroundColor"]);
            this.Leftbtn.ItemsSource = (this.appFunctionList);
            this.Rightbtn.ItemsSource = (this.appFunctionList);
            this.Upbtn.ItemsSource = (this.appFunctionList);
            this.Downbtn.ItemsSource = (this.appFunctionList);
            this.Leftbtn.SelectedIndex = (int)Math.Round(Math.Log((double)EmulatorSettings.Current.MotionLeft, 2.0));
            this.Rightbtn.SelectedIndex = (int)Math.Round(Math.Log((double)EmulatorSettings.Current.MotionRight, 2.0));
            this.Upbtn.SelectedIndex = (int)Math.Round(Math.Log((double)EmulatorSettings.Current.MotionUp, 2.0));
            this.Downbtn.SelectedIndex = (int)Math.Round(Math.Log((double)EmulatorSettings.Current.MotionDown, 2.0));
            this.horizontalDeadzoneSlider.Value = (EmulatorSettings.Current.MotionDeadzoneH);
            this.verticalDeadzoneSlider.Value = (EmulatorSettings.Current.MotionDeadzoneV);
            this.adaptOrientationSwitch.IsChecked = (new bool?(EmulatorSettings.Current.MotionAdaptOrientation));
        }

        private void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Vector3 vector = e.SensorReading.Acceleration;
            EmulatorSettings.Current.RestAngleX = ((double)vector.X);
            EmulatorSettings.Current.RestAngleY = ((double)vector.Y);
            EmulatorSettings.Current.RestAngleZ = ((double)vector.Z);
            IsolatedStorageSettings.ApplicationSettings["RestAngleXKey"] = ((double)vector.X);
            IsolatedStorageSettings.ApplicationSettings["RestAngleYKey"] = ((double)vector.Y);
            IsolatedStorageSettings.ApplicationSettings["RestAngleZKey"] = ((double)vector.Z);
            IsolatedStorageSettings.ApplicationSettings.Save();
            ((Accelerometer)sender).Stop();
            base.Dispatcher.BeginInvoke(() => MessageBox.Show(AppResources.CalibrationSuccessText));
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
            EmulatorSettings.Current.MotionLeft = ((int)Math.Pow(2.0, (double)this.Leftbtn.SelectedIndex));
            EmulatorSettings.Current.MotionRight = ((int)Math.Pow(2.0, (double)this.Rightbtn.SelectedIndex));
            EmulatorSettings.Current.MotionUp = ((int)Math.Pow(2.0, (double)this.Upbtn.SelectedIndex));
            EmulatorSettings.Current.MotionDown = ((int)Math.Pow(2.0, (double)this.Downbtn.SelectedIndex));
            EmulatorSettings.Current.MotionDeadzoneH = (this.horizontalDeadzoneSlider.Value);
            EmulatorSettings.Current.MotionDeadzoneV = (this.verticalDeadzoneSlider.Value);
            EmulatorSettings.Current.MotionAdaptOrientation = (this.adaptOrientationSwitch.IsChecked.Value);
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            settings["MotionLeftKey"] = ((int)Math.Pow(2.0, (double)this.Leftbtn.SelectedIndex));
            settings["MotionRightKey"] = ((int)Math.Pow(2.0, (double)this.Rightbtn.SelectedIndex));
            settings["MotionUpKey"] = ((int)Math.Pow(2.0, (double)this.Upbtn.SelectedIndex));
            settings["MotionDownKey"] = ((int)Math.Pow(2.0, (double)this.Downbtn.SelectedIndex));
            settings["MotionDeadzoneHKey"] = (this.horizontalDeadzoneSlider.Value);
            settings["MotionDeadzoneVKey"] = (this.verticalDeadzoneSlider.Value);
            settings["MotionAdaptOrientationKey"] = (this.adaptOrientationSwitch.IsChecked.Value);
            settings.Save();
            if (base.NavigationService.CanGoBack)
            {
                base.NavigationService.GoBack();
            }
        }

        private void CalibrateBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((EmulatorSettings.Current.UseMotionControl == 1) && Accelerometer.IsSupported)
            {
                Accelerometer accelerometer = new Accelerometer();
                try
                {
                    accelerometer.CurrentValueChanged += (this.accelerometer_CurrentValueChanged);
                    accelerometer.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show(AppResources.FailedToCalibrateText);
                }
            }
            else if ((EmulatorSettings.Current.UseMotionControl == 2) && Motion.IsSupported)
            {
                Motion motion = new Motion();
                try
                {
                    motion.CurrentValueChanged += (this.motion_CurrentValueChanged);
                    motion.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show(AppResources.FailedToCalibrateText);
                }
            }
        }

        private void horizontalDeadzoneLock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.horizontalDeadzoneSlider.IsEnabled)
            {
                this.horizontalDeadzoneSlider.IsEnabled = (false);
                this.horizontalDeadzoneImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.lock.png", UriKind.Relative)));
            }
            else
            {
                this.horizontalDeadzoneSlider.IsEnabled = (true);
                this.horizontalDeadzoneImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.unlock.png", UriKind.Relative)));
            }
        }

        private void horizontalDeadzoneSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }


        private void motion_CurrentValueChanged(object sender, SensorReadingEventArgs<MotionReading> e)
        {
            AttitudeReading reading = e.SensorReading.Attitude;
            EmulatorSettings.Current.RestAngleX = ((((double)reading.Roll) / 3.14159265) * 180.0);
            EmulatorSettings.Current.RestAngleY = ((((double)reading.Pitch) / 3.14159265) * 180.0);
            IsolatedStorageSettings.ApplicationSettings["RestAngleXKey"] = ((((double)reading.Roll) / 3.14159265) * 180.0);
            IsolatedStorageSettings.ApplicationSettings["RestAngleYKey"] = ((((double)reading.Pitch) / 3.14159265) * 180.0);
            IsolatedStorageSettings.ApplicationSettings.Save();
            ((Motion)sender).Stop();
            base.Dispatcher.BeginInvoke(() => MessageBox.Show(AppResources.CalibrationSuccessText));
        }

        private void verticalDeadzoneLock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.verticalDeadzoneSlider.IsEnabled)
            {
                this.verticalDeadzoneSlider.IsEnabled = (false);
                this.verticalDeadzoneImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.lock.png", UriKind.Relative)));
            }
            else
            {
                this.verticalDeadzoneSlider.IsEnabled = (true);
                this.verticalDeadzoneImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.unlock.png", UriKind.Relative)));
            }
        }

        private void verticalDeadzoneSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
    }
}

