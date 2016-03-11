namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Devices.Sensors;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using Microsoft.Phone.Tasks;
    using PhoneDirect3DXamlAppComponent;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO.IsolatedStorage;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using Telerik.Windows.Controls;

    public partial class SettingsPage : PhoneApplicationPage
    {
        public const string ALeftLKey = "ALeftLKey";
        public const string ALeftPKey = "ALeftPKey";
        public const string AspectKey = "AspectRatioModeKey";
        private string[] aspectRatioList = new string[] { AppResources.AspectRatioOriginalSetting, AppResources.AspectRatioStretchSetting, AppResources.AspectRatioOneSetting, AppResources.AspectRatio4to3Setting, AppResources.AspectRatio5to4Setting };
        public const string ATopLKey = "ATopLKey";
        public const string ATopPKey = "ATopPKey";
        public const string AutoIncKey = "AutoIncKey";
        public const string AutoSaveLoadKey = "AutSaveLoadKey";
        public const string BgcolorBKey = "BgcolorBKey";
        public const string BgcolorGKey = "BgcolorGKey";
        public const string BgcolorRKey = "BgcolorRKey";
        public const string BLeftLKey = "BLeftLKey";
        public const string BLeftPKey = "BLeftPKey";
        public const string BTopLKey = "BTopLKey";
        public const string BTopPKey = "BTopPKey";
        public const string ButtonScaleKey = "ButtonScale";
        public const string CameraAssignKey = "CameraAssignmentKey";
        public const string ConfirmationKey = "ConfirmationKey";
        public const string ConfirmationLoadKey = "ConfirmationLoadKey";
        public const string ControllerScaleKey = "ControllerScale";
        public const string CreateManualSnapshotKey = "ManualSnapshotKey";
        public const string DeadzoneKey = "DeadzoneKey";
        public const string DPadStyleKey = "DPadStyleKey";
        public const string EnableAutoFireKey = "EnableAutoFireKey";
        public const string EnableSoundKey = "EnableSound";
        private string[] frameskiplist = new string[] { AppResources.FrameSkipAutoSetting, "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string[] frameskiplist2 = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        public const string FullPressStickABLRKey = "FullPressStickABLRKey";
        public const string ImageScalingKey = "ImageScalingKey";
        private bool initdone;
        public const string LLeftLKey = "LLeftLKey";
        public const string LLeftPKey = "LLeftPKey";
        public const string LowFreqModeKey = "LowFrequencyModeNew";
        public const string LTopLKey = "LTopLKey";
        public const string LTopPKey = "LTopPKey";
        public const string MapABLRTurboKey = "MapABLRTurboKey";
        public const string MogaAKey = "MogaAKey";
        public const string MogaBKey = "MogaBKey";
        public const string MogaL1Key = "MogaL1Key";
        public const string MogaL2Key = "MogaL2Key";
        public const string MogaLeftJoystickKey = "MogaLeftJoystickKey";
        public const string MogaR1Key = "MogaR1Key";
        public const string MogaR2Key = "MogaR2Key";
        public const string MogaRightJoystickKey = "MogaRightJoystickKey";
        public const string MogaXKey = "MogaXKey";
        public const string MogaYKey = "MogaYKey";
        public const string MotionAdaptOrientationKey = "MotionAdaptOrientationKey";
        public const string MotionDeadzoneHKey = "MotionDeadzoneHKey";
        public const string MotionDeadzoneVKey = "MotionDeadzoneVKey";
        public const string MotionDownKey = "MotionDownKey";
        public const string MotionLeftKey = "MotionLeftKey";
        public const string MotionRightKey = "MotionRightKey";
        public const string MotionUpKey = "MotionUpKey";
        public const string OpacityKey = "ControllerOpacity";
        public const string OrientationKey = "Orientation";
        private string[] orientationList = new string[] { AppResources.OrientationBoth, AppResources.OrientationLandscape, AppResources.OrientationPortrait };
        public const string PadCenterXLKey = "PadCenterXLKey";
        public const string PadCenterXPKey = "PadCenterXPKey";
        public const string PadCenterYLKey = "PadCenterYLKey";
        public const string PadCenterYPKey = "PadCenterYPKey";
        public Popup popupWindow;
        public const string PowerSaverKey = "PowerSaveSkipKey";
        public const string RestAngleXKey = "RestAngleXKey";
        public const string RestAngleYKey = "RestAngleYKey";
        public const string RestAngleZKey = "RestAngleZKey";
        public const string RestoreCheatKey = "RestoreCheatKey";
        public const string RRightLKey = "RRightLKey";
        public const string RRightPKey = "RRightPKey";
        public const string RTopLKey = "RTopLKey";
        public const string RTopPKey = "RTopPKey";

        public const string SelectLastState = "SelectLastStateKey";
        public const string SelectRightLKey = "SelectRightLKey";
        public const string SelectRightPKey = "SelectRightPKey";
        public const string SelectTopLKey = "SelectTopLKey";
        public const string SelectTopPKey = "SelectTopPKey";
        public static bool shouldUpdateBackgroud;
        public const string SkipFramesKey = "SkipFramesKey2";
        public const string StartLeftLKey = "StartLeftLKey";
        public const string StartLeftPKey = "StartLeftPKey";
        public const string StartTopLKey = "StartTopLKey";
        public const string StartTopPKey = "StartTopPKey";
        public const string StretchKey = "FullscreenStretch";
        public const string SyncAudioKey = "SynchronizeAudioKey";

        public const string TurboFrameSkipKey = "TurboSkipFramesKey";
        public const string UseColorButtonKey = "UseColorButtonKey";
        public const string UseMogaControllerKey = "UseMogaControllerKey";
        public const string UseMotionControlKey = "UseMotionControlKey";
        public const string UseTurboKey = "UseTurboKey";
        public const string VControllerPosKey = "VirtualControllerOnTop";
        public const string VibrationDurationKey = "VibrationDurationKey";
        public const string VibrationEnabledKey = "VibrationEnabledKey";
        public const string VirtualControllerStyleKey = "VirtualControllerStyleKey";

        public SettingsPage()
        {
            this.InitializeComponent();
            SystemTray.GetProgressIndicator(this).Text = (AppResources.ApplicationTitle2);

            this.frameSkipPicker.ItemsSource = (this.frameskiplist);
            this.turboFrameSkipPicker.ItemsSource = (this.frameskiplist2);
            this.aspectRatioPicker.ItemsSource = (this.aspectRatioList);
            this.orientationPicker.ItemsSource = (this.orientationList);
            this.ReadSettings();
        }

        private void aspectRatioPicker_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AspectRatio = ((AspectRatioMode)this.aspectRatioPicker.SelectedIndex);
            }
        }

        private void assignPicker_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.CameraButtonAssignment = (this.assignPicker.SelectedIndex);
                if (EmulatorSettings.Current.CameraButtonAssignment == 0)
                {
                    this.autoFireSwitch.Visibility = (System.Windows.Visibility)(1);
                    this.mapABLRTurboSwitch.Visibility = (System.Windows.Visibility)(1);
                    this.fullPressStickABRLSwitch.Visibility = (System.Windows.Visibility)(1);
                }
                else
                {
                    this.autoFireSwitch.Visibility = (System.Windows.Visibility)(0);
                    this.mapABLRTurboSwitch.Visibility = (System.Windows.Visibility)(0);
                    this.fullPressStickABRLSwitch.Visibility = (System.Windows.Visibility)(0);
                }
            }
        }

        private void autoBackupSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                App.metroSettings.AutoBackup = this.autoBackupSwitch.IsChecked.Value;
                if (App.metroSettings.AutoBackup)
                {
                    this.SetupAutoBackupBtn.Visibility = (System.Windows.Visibility)(0);
                }
                else
                {
                    this.SetupAutoBackupBtn.Visibility = (System.Windows.Visibility)(1);
                }
            }
        }

        private void autoFireSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.EnableAutoFire = (this.autoFireSwitch.IsChecked.Value);
            }
        }

        private void autoIncSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AutoIncrementSavestates = (true);
            }
        }

        private void autoIncSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.AutoIncrementSavestates = (false);
            }
        }

        private void backgroundOpacityLock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.backgroundOpacitySlider.IsEnabled)
            {
                this.backgroundOpacitySlider.IsEnabled = (false);
                this.backgroundOpacityImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.lock.png", UriKind.Relative)));
            }
            else
            {
                this.backgroundOpacitySlider.IsEnabled = (true);
                this.backgroundOpacityImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.unlock.png", UriKind.Relative)));
            }
        }

        private void backgroundOpacitySlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                App.metroSettings.BackgroundOpacity = this.backgroundOpacitySlider.Value / 100.0;
                this.UpdateBackgroundImage();
                MainPage.shouldUpdateBackgroud = true;
            }
        }

        private void buttonScaleLock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.buttonScaleSlider.IsEnabled)
            {
                this.buttonScaleSlider.IsEnabled = (false);
                this.buttonScaleImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.lock.png", UriKind.Relative)));
            }
            else
            {
                this.buttonScaleSlider.IsEnabled = (true);
                this.buttonScaleImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.unlock.png", UriKind.Relative)));
            }
        }

        private void ButtonScaleSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ButtonScale = ((int)this.buttonScaleSlider.Value);
            }
        }

        private void ChangeVoiceCommandPrefixBtn_Click(object sender, RoutedEventArgs e)
        {
            base.IsHitTestVisible = (false);
            this.popupWindow = new Popup();
            EditCheatControl.TextToEdit = "";
            EditCheatControl.PromptText = AppResources.EnterVoicePrefixText;
            this.popupWindow.Child = (new EditCheatControl());
            this.popupWindow.VerticalOffset = (0.0);
            this.popupWindow.HorizontalOffset = (0.0);
            this.popupWindow.IsOpen = (true);
            this.popupWindow.Closed += (async delegate(object s1, EventArgs e1)
            {
                this.IsHitTestVisible = (true);
                if (EditCheatControl.IsOKClicked)
                {
                    if ((EditCheatControl.TextToEdit != null) && (EditCheatControl.TextToEdit.Trim() != ""))
                    {
                        await MainPage.RegisterVoiceCommand(EditCheatControl.TextToEdit);
                    }
                    else
                    {
                        MessageBox.Show(AppResources.InputEmptyError);
                    }
                }
            });
        }

        private void cheatRestoreSwitch_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.RestoreOldCheatValues = (true);
            }
        }

        private void cheatRestoreSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.RestoreOldCheatValues = (false);
            }
        }

        private void chkUseAccentColor_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.initdone)
            {
                App.metroSettings.UseAccentColor = this.chkUseAccentColor.IsChecked.Value;
                //FileHandler.UpdateLiveTile();
            }
        }

        private void ChooseBackgroundImageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.IsPremium)
            {
                PhotoChooserTask task = new PhotoChooserTask();
                task.Completed += (this.photoChooserTask_Completed);
                task.ShowCamera = (true);
                task.Show();
            }
            else if (MessageBox.Show(AppResources.PremiumFeaturePromptText, AppResources.UnlockFeatureText, (MessageBoxButton)1) == (MessageBoxResult)1)
            {
                base.NavigationService.Navigate(new Uri("/PurchasePage.xaml", UriKind.Relative));
            }
        }

        private void confirmationLoadSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.HideLoadConfirmationDialogs = (true);
            }
        }

        private void confirmationLoadSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.HideLoadConfirmationDialogs = (false);
            }
        }

        private void confirmationSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.HideConfirmationDialogs = (true);
            }
        }

        private void confirmationSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.HideConfirmationDialogs = (false);
            }
        }

        private void CPositionLandscapeBtn_Click(object sender, RoutedEventArgs e)
        {
            base.NavigationService.Navigate(new Uri("/CustomizeControllerPage.xaml?orientation=0", UriKind.Relative));
        }

        private void CPositionPortraitBtn_Click(object sender, RoutedEventArgs e)
        {
            base.NavigationService.Navigate(new Uri("/CustomizeControllerPage.xaml?orientation=2", UriKind.Relative));
        }

        private void CustomizeBgcolorBtn_Click(object sender, RoutedEventArgs e)
        {
            EventHandler handler = null;
            if (App.IsPremium || !App.HasAds)
            {
                base.IsHitTestVisible = (false);
                this.popupWindow = new Popup();
                this.popupWindow.Child = (new ColorChooserControl());
                this.popupWindow.VerticalOffset = (130.0);
                this.popupWindow.HorizontalOffset = (10.0);
                this.popupWindow.IsOpen = (true);
                if (handler == null)
                {
                    handler = (s1, e1) => base.IsHitTestVisible = (true);
                }
                this.popupWindow.Closed += (handler);
            }
            else if (MessageBox.Show(AppResources.PremiumFeaturePromptText, AppResources.UnlockFeatureText, (MessageBoxButton)1) == (MessageBoxResult)1)
            {
                base.NavigationService.Navigate(new Uri("/PurchasePage.xaml", UriKind.Relative));
            }
        }

        private void deadzoneLock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.deadzoneSlider.IsEnabled)
            {
                this.deadzoneSlider.IsEnabled = (false);
                this.deadzoneImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.lock.png", UriKind.Relative)));
            }
            else
            {
                this.deadzoneSlider.IsEnabled = (true);
                this.deadzoneImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.unlock.png", UriKind.Relative)));
            }
        }

        private void deadzoneSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.Deadzone = ((float)this.deadzoneSlider.Value);
            }
        }

        private void dpadStyleBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.DPadStyle = (this.dpadStyleBox.SelectedIndex);
            }
        }

        private void enableSoundSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SoundEnabled = (true);
            }
        }

        private void enableSoundSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SoundEnabled = (false);
            }
        }

        private void frameSkipPicker_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.FrameSkip = (this.frameSkipPicker.SelectedIndex - 1);
            }
        }

        private void fullPressStickABRLSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.FullPressStickABLR = (this.fullPressStickABRLSwitch.IsChecked.Value);
            }
        }

        private void imageScaleSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ImageScaling = ((int)this.imageScaleSlider.Value);
            }
        }

        private void loaLastStateSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                if (this.loadLastStateSwitch.IsChecked.Value)
                {
                    if (MessageBox.Show(AppResources.AutoSaveWarning, AppResources.WarningTitle, (MessageBoxButton)1) == (MessageBoxResult)1)
                    {
                        EmulatorSettings.Current.AutoSaveLoad = (this.loadLastStateSwitch.IsChecked.Value);
                    }
                    else
                    {
                        this.loadLastStateSwitch.IsChecked = (false);
                    }
                }
                else
                {
                    EmulatorSettings.Current.AutoSaveLoad = (this.loadLastStateSwitch.IsChecked.Value);
                }
            }
        }

        private void lowFreqSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.LowFrequencyMode = (true);
            }
        }

        private void lowFreqSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.LowFrequencyMode = (false);
            }
        }

        private void manualSnapshotSwitch_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ManualSnapshots = (true);
            }
        }

        private void manualSnapshotSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ManualSnapshots = (false);
            }
        }

        private void mapABLRTurboSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.MapABLRTurbo = (this.mapABLRTurboSwitch.IsChecked.Value);
            }
        }

        private void MappingBtn_Click(object sender, RoutedEventArgs e)
        {
            base.NavigationService.Navigate(new Uri("/MogaMappingPage.xaml", UriKind.Relative));
        }

        private void motionControlBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                if ((this.motionControlBox.SelectedIndex == 1) && !Accelerometer.IsSupported)
                {
                    MessageBox.Show(AppResources.AccelerometerMissingText);
                    this.motionControlBox.SelectedIndex = 0;
                }
                else if (this.motionControlBox.SelectedIndex == 2)
                {
                    if (!Gyroscope.IsSupported)
                    {
                        MessageBox.Show(AppResources.GyroMissingText);
                        this.motionControlBox.SelectedIndex = 0;
                    }
                    else if (!Motion.IsSupported)
                    {
                        MessageBox.Show(AppResources.CompassMissingText);
                        this.motionControlBox.SelectedIndex = 0;
                    }
                }
                EmulatorSettings.Current.UseMotionControl = (this.motionControlBox.SelectedIndex);
                if (EmulatorSettings.Current.UseMotionControl == 0)
                {
                    this.MotionSettingBtn.Visibility = (System.Windows.Visibility)(1);
                }
                else
                {
                    this.MotionSettingBtn.Visibility = (System.Windows.Visibility)(0);
                    if (EmulatorSettings.Current.UseMotionControl == 1)
                    {
                        EmulatorSettings.Current.RestAngleX = (0.0);
                        EmulatorSettings.Current.RestAngleY = (-0.70711);
                        EmulatorSettings.Current.RestAngleZ = (-0.70711);
                        IsolatedStorageSettings.ApplicationSettings["RestAngleXKey"] = (0.0);
                        IsolatedStorageSettings.ApplicationSettings["RestAngleYKey"] = (-0.70711);
                        IsolatedStorageSettings.ApplicationSettings["RestAngleZKey"] = (-0.70711);
                        IsolatedStorageSettings.ApplicationSettings.Save();
                    }
                    else if (EmulatorSettings.Current.UseMotionControl == 2)
                    {
                        EmulatorSettings.Current.RestAngleX = (0.0);
                        EmulatorSettings.Current.RestAngleY = (45.0);
                        IsolatedStorageSettings.ApplicationSettings["RestAngleXKey"] = (0.0);
                        IsolatedStorageSettings.ApplicationSettings["RestAngleYKey"] = (45.0);
                        IsolatedStorageSettings.ApplicationSettings.Save();
                    }
                }
            }
        }

        private void MotionSettingBtn_Click(object sender, RoutedEventArgs e)
        {
            base.NavigationService.Navigate(new Uri("/MotionMappingPage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if ((this.popupWindow != null) && this.popupWindow.IsOpen)
            {
                this.popupWindow.IsOpen = (false);
                e.Cancel = true;
            }
            else
            {
                base.OnBackKeyPress(e);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.toggleUseMogaController.IsChecked = new bool?(EmulatorSettings.Current.UseMogaController);
            if (EmulatorSettings.Current.UseMogaController)
            {
                this.MappingBtn.Visibility = (System.Windows.Visibility)(0);
            }
            else
            {
                this.MappingBtn.Visibility = (System.Windows.Visibility)(1);
            }
            if (shouldUpdateBackgroud)
            {
                this.UpdateBackgroundImage();
                MainPage.shouldUpdateBackgroud = true;
                shouldUpdateBackgroud = false;
            }
            base.OnNavigatedTo(e);
        }

        private void opacityLock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.opacitySlider.IsEnabled)
            {
                this.opacitySlider.IsEnabled = (false);
                this.opacityImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.lock.png", UriKind.Relative)));
            }
            else
            {
                this.opacitySlider.IsEnabled = (true);
                this.opacityImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.unlock.png", UriKind.Relative)));
            }
        }

        private void opacitySlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ControllerOpacity = ((int)this.opacitySlider.Value);
            }
        }

        private void orientationBothRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.Orientation = (0);
            }
        }

        private void orientationLandscapeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.Orientation = (1);
            }
        }

        private void orientationPicker_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.Orientation = (this.orientationPicker.SelectedIndex);
            }
        }

        private void orientationPortraitRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.Orientation = (2);
            }
        }

        private void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == (TaskResult)1)
            {
                BitmapImage image = new BitmapImage();
                image.SetSource(e.ChosenPhoto);
                WriteableBitmap bitmap = new WriteableBitmap(image);
                ImageCroppingPage.wbSource = bitmap;
                base.NavigationService.Navigate(new Uri("/ImageCroppingPage.xaml", UriKind.Relative));
            }
        }

        private void PinSecondaryTileBtn_Click(object sender, RoutedEventArgs e)
        {
            FileHandler.CreateOrUpdateSecondaryTile(true);
        }

        private void ReadSettings()
        {
            EmulatorSettings emuSettings = EmulatorSettings.Current;
            this.enableSoundSwitch.IsChecked = (new bool?(emuSettings.SoundEnabled));
            this.lowFreqSwitch.IsChecked = (new bool?(emuSettings.LowFrequencyMode));
            this.scaleSlider.Value = ((double)emuSettings.ControllerScale);
            this.buttonScaleSlider.Value = ((double)emuSettings.ButtonScale);
            this.opacitySlider.Value = ((double)emuSettings.ControllerOpacity);
            this.imageScaleSlider.Value = ((double)emuSettings.ImageScaling);
            this.deadzoneSlider.Value = ((double)emuSettings.Deadzone);
            this.syncSoundSwitch.IsChecked = (new bool?(emuSettings.SynchronizeAudio));
            this.confirmationSwitch.IsChecked = (new bool?(emuSettings.HideConfirmationDialogs));
            this.autoIncSwitch.IsChecked = (new bool?(emuSettings.AutoIncrementSavestates));
            this.confirmationLoadSwitch.IsChecked = (new bool?(emuSettings.HideLoadConfirmationDialogs));
            this.cheatRestoreSwitch.IsChecked = (new bool?(emuSettings.RestoreOldCheatValues));
            this.manualSnapshotSwitch.IsChecked = (new bool?(emuSettings.ManualSnapshots));
            this.showThreeDotsSwitch.IsChecked = (new bool?(App.metroSettings.ShowThreeDots));
            this.showLastPlayedGameSwitch.IsChecked = (new bool?(App.metroSettings.ShowLastPlayedGame));
            this.loadLastStateSwitch.IsChecked = (new bool?(emuSettings.AutoSaveLoad));
            this.autoBackupSwitch.IsChecked = (new bool?(App.metroSettings.AutoBackup));
            this.autoFireSwitch.IsChecked = (new bool?(emuSettings.EnableAutoFire));
            this.mapABLRTurboSwitch.IsChecked = (new bool?(emuSettings.MapABLRTurbo));
            this.fullPressStickABRLSwitch.IsChecked = (new bool?(emuSettings.FullPressStickABLR));
            if (App.metroSettings.BackgroundUri != null)
            {
                this.useBackgroundImageSwitch.IsChecked = (new bool?(true));
                this.backgroundOpacityPanel.Visibility = (System.Windows.Visibility)(0);
                this.ChooseBackgroundImageGrid.Visibility = (System.Windows.Visibility)(0);
            }
            else
            {
                this.useBackgroundImageSwitch.IsChecked = (new bool?(false));
                this.backgroundOpacityPanel.Visibility = (System.Windows.Visibility)(1);
                this.ChooseBackgroundImageGrid.Visibility = (System.Windows.Visibility)(1);
            }
            if (emuSettings.VirtualControllerStyle != 2)
            {
                this.CustomizeBgcolorBtn.Visibility = (System.Windows.Visibility)0;
            }
            else
            {
                this.CustomizeBgcolorBtn.Visibility = (System.Windows.Visibility)(1);
            }
            if (this.autoBackupSwitch.IsChecked.Value)
            {
                this.SetupAutoBackupBtn.Visibility = (System.Windows.Visibility)(0);
            }
            else
            {
                this.SetupAutoBackupBtn.Visibility = (System.Windows.Visibility)(1);
            }
            this.chkUseAccentColor.IsChecked = (new bool?(App.metroSettings.UseAccentColor));
            this.toggleVibration.IsChecked = new bool?(emuSettings.VibrationEnabled);
            if (emuSettings.VibrationEnabled)
            {
                this.txtVibrationDuration.Visibility = (System.Windows.Visibility)(0);
            }
            else
            {
                this.txtVibrationDuration.Visibility = (System.Windows.Visibility)(1);
            }
            this.toggleTurbo.IsChecked = new bool?(emuSettings.UseTurbo);
            base.Loaded += (delegate(object o, RoutedEventArgs e)
            {
                this.turboFrameSkipPicker.SelectedIndex = emuSettings.TurboFrameSkip;
                this.frameSkipPicker.SelectedIndex = Math.Min(emuSettings.FrameSkip + 1, this.frameSkipPicker.Items.Count - 1);
                this.aspectRatioPicker.SelectedIndex = (int)emuSettings.AspectRatio;
                this.orientationPicker.SelectedIndex = emuSettings.Orientation;
                this.dpadStyleBox.SelectedIndex = emuSettings.DPadStyle;
                this.assignPicker.SelectedIndex = emuSettings.CameraButtonAssignment;
                if (emuSettings.CameraButtonAssignment == 0)
                {
                    this.autoFireSwitch.Visibility = (System.Windows.Visibility)(1);
                    this.mapABLRTurboSwitch.Visibility = (System.Windows.Visibility)(1);
                    this.fullPressStickABRLSwitch.Visibility = (System.Windows.Visibility)(1);
                }
                else
                {
                    this.autoFireSwitch.Visibility = (System.Windows.Visibility)(0);
                    this.mapABLRTurboSwitch.Visibility = (System.Windows.Visibility)(0);
                    this.fullPressStickABRLSwitch.Visibility = (System.Windows.Visibility)(0);
                }
                this.themePicker.SelectedIndex = App.metroSettings.ThemeSelection;
                this.virtualControlStyleBox.SelectedIndex = emuSettings.VirtualControllerStyle;
                this.backgroundOpacitySlider.Value = (App.metroSettings.BackgroundOpacity * 100.0);
                this.txtVibrationDuration.Text = (emuSettings.VibrationDuration.ToString());
                this.motionControlBox.SelectedIndex = emuSettings.UseMotionControl;
                if (EmulatorSettings.Current.UseMotionControl == 0)
                {
                    this.MotionSettingBtn.Visibility = (System.Windows.Visibility)(1);
                }
                else
                {
                    this.MotionSettingBtn.Visibility = (System.Windows.Visibility)(0);
                }
                this.initdone = true;
            });
        }

        private void ResetBackgroundImageBtn_Click(object sender, RoutedEventArgs e)
        {
            App.metroSettings.BackgroundUri = FileHandler.DEFAULT_BACKGROUND_IMAGE;
            App.metroSettings.UseDefaultBackground = true;
            this.UpdateBackgroundImage();
            MainPage.shouldUpdateBackgroud = true;
        }

        private void scaleLock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.scaleSlider.IsEnabled)
            {
                this.scaleSlider.IsEnabled = (false);
                this.scaleImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.lock.png", UriKind.Relative)));
            }
            else
            {
                this.scaleSlider.IsEnabled = (true);
                this.scaleImage.ImageSource = (new BitmapImage(new Uri("Assets/Icons/appbar.unlock.png", UriKind.Relative)));
            }
        }

        private void scaleSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.ControllerScale = ((int)this.scaleSlider.Value);
            }
        }

        private void SetupAutoBackupBtn_Click(object sender, RoutedEventArgs e)
        {
            base.NavigationService.Navigate(new Uri("/AutoBackupPage.xaml", UriKind.Relative));
        }

        private void showLastPlayedGameSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                App.metroSettings.ShowLastPlayedGame = this.showLastPlayedGameSwitch.IsChecked.Value;
            }
        }

        private void showThreeDotsSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                App.metroSettings.ShowThreeDots = this.showThreeDotsSwitch.IsChecked.Value;
            }
        }

        private void syncSoundSwitch_Checked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SynchronizeAudio = (true);
            }
        }

        private void syncSoundSwitch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.SynchronizeAudio = (false);
            }
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = (new Uri("http://www.youtube.com/watch?v=YfqzZhcr__o"));
            task.Show();
        }

        private void themePicker_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                App.metroSettings.ThemeSelection = this.themePicker.SelectedIndex;
                App.MergeCustomColors();
            }
        }

        private void toggleTurbo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.UseTurbo = (this.toggleTurbo.IsChecked.Value);
                IsolatedStorageSettings.ApplicationSettings["UseTurboKey"] = (this.toggleTurbo.IsChecked.Value);
            }
        }

        private void toggleUseMogaController_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.initdone)
            {
                if (App.IsPremium)
                {
                    EmulatorSettings.Current.UseMogaController = (this.toggleUseMogaController.IsChecked.Value);
                }
                else
                {
                    this.toggleUseMogaController.IsChecked = new bool?(EmulatorSettings.Current.UseMogaController);
                    if (MessageBox.Show(AppResources.PremiumFeaturePromptText, AppResources.UnlockFeatureText, (MessageBoxButton)1) == (MessageBoxResult)1)
                    {
                        base.NavigationService.Navigate(new Uri("/PurchasePage.xaml", UriKind.Relative));
                    }
                }
                if (EmulatorSettings.Current.UseMogaController)
                {
                    this.MappingBtn.Visibility = (System.Windows.Visibility)(0);
                }
                else
                {
                    this.MappingBtn.Visibility = (System.Windows.Visibility)(1);
                }
            }
        }

        private void toggleVibration_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.VibrationEnabled = (this.toggleVibration.IsChecked.Value);
                if (EmulatorSettings.Current.VibrationEnabled)
                {
                    this.txtVibrationDuration.Visibility = (System.Windows.Visibility)(0);
                }
                else
                {
                    this.txtVibrationDuration.Visibility = (System.Windows.Visibility)(1);
                }
            }
        }

        private void turboFrameSkipPicker_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.TurboFrameSkip = (this.turboFrameSkipPicker.SelectedIndex);
            }
        }

        private void txtVibrationDuration_TextChanged(object sender, TextChangedEventArgs e)
        {
            double result = 0.0;
            if (this.txtVibrationDuration.Text != "")
            {
                double.TryParse(this.txtVibrationDuration.Text, out result);
            }
            if ((result < 0.0) || (result > 5.0))
            {
                MessageBox.Show(AppResources.VibrationDurationErrorText);
            }
            else
            {
                EmulatorSettings.Current.VibrationDuration = (result);
            }
        }

        private void UpdateBackgroundImage()
        {
            if (App.metroSettings.BackgroundUri != null)
            {
                ImageBrush brush = new ImageBrush();
                brush.Opacity = (App.metroSettings.BackgroundOpacity);
                brush.Stretch = (Stretch)(0);
                brush.AlignmentX = (AlignmentX)(1);
                brush.AlignmentY = (AlignmentY)(0);
                brush.ImageSource = (FileHandler.getBitmapImage(App.metroSettings.BackgroundUri, FileHandler.DEFAULT_BACKGROUND_IMAGE));
                this.pivot.Background = (brush);
            }
            else
            {
                this.pivot.Background = (null);
            }
        }

        private void useBackgroundImageSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (this.initdone)
            {
                if (this.useBackgroundImageSwitch.IsChecked.Value)
                {
                    if (App.metroSettings.UseDefaultBackground)
                    {
                        App.metroSettings.BackgroundUri = FileHandler.DEFAULT_BACKGROUND_IMAGE;
                    }
                    else
                    {
                        App.metroSettings.BackgroundUri = "CustomBackground.jpg";
                    }
                    this.backgroundOpacityPanel.Visibility = (System.Windows.Visibility)(0);
                    this.ChooseBackgroundImageGrid.Visibility = (System.Windows.Visibility)(0);
                }
                else
                {
                    App.metroSettings.BackgroundUri = null;
                    this.backgroundOpacityPanel.Visibility = (System.Windows.Visibility)(1);
                    this.ChooseBackgroundImageGrid.Visibility = (System.Windows.Visibility)(1);
                }
                this.UpdateBackgroundImage();
                MainPage.shouldUpdateBackgroud = true;
            }
        }

        private void virtualControlStyleBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (this.initdone)
            {
                EmulatorSettings.Current.VirtualControllerStyle = (this.virtualControlStyleBox.SelectedIndex);
                if (EmulatorSettings.Current.VirtualControllerStyle != 2)
                {
                    this.CustomizeBgcolorBtn.Visibility = (System.Windows.Visibility)(0);
                }
                else
                {
                    this.CustomizeBgcolorBtn.Visibility = (System.Windows.Visibility)(1);
                }
            }
        }

    }
}

