using System.Threading;
using System.Windows.Interops;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;
using PhoneDirect3DXamlAppInterop.Animation;
using PhoneDirect3DXamlAppInterop.Framework;
using PhoneDirect3DXamlAppInterop.Helper;

namespace PhoneDirect3DXamlAppInterop
{
    using DucLe.Extensions;

    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Info;
    using Microsoft.Phone.Net.NetworkInformation;
    using Microsoft.Phone.Shell;
    using Microsoft.Phone.Tasks;
    using PhoneDirect3DXamlAppComponent;
    using PhoneDirect3DXamlAppInterop.Database;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Linq;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Navigation;
    using Telerik.Windows.Controls;
    using Windows.Phone.Speech.VoiceCommands;
    using Windows.Phone.Storage.SharedAccess;
    using Windows.Storage;
    using Windows.Storage.Streams;

    public partial class MainPage : BaseView
    {
        private bool checkAutoUpload;
        public static bool IsNeedToLoad = true;

        private ApplicationBarIconButton resumeButton;
        private bool shouldInitialize = true;
        public static bool shouldRefreshAllROMList;
        public static bool shouldRefreshRecentROMList;
        public static bool shouldUpdateBackgroud;
        private DispatcherTimer loadRomTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(5d) };

        public MainPage()
        {
            this.InitializeComponent();
            TiltEffect.TiltableItems.Add(typeof(TiltableGrid));
            TiltEffect.TiltableItems.Add(typeof(TiltableCanvas));

            base.DataContext = (ROMDatabase.Current);
            this.SortRomList();
            App.metroSettings.NAppLaunch++;
            this.InitAppBar();
            this.RefreshRecentROMList();
            base.Loaded += this.MainPage_Loaded;

            if (IsNeedToLoad)
            {
                LoadRomProgressBar.Value = 10;
                SplashGrid.RenderTransform = new CompositeTransform();
                SplashGrid.RenderTransformOrigin = new Point(0.5, 0.5);
                loadRomTimer.Tick += (e, s) =>
                {
                    if (LoadRomProgressBar.Value == 100)
                    {
                        HelloKitty.ShowGoogleFullScreenAd();
                        loadRomTimer.Stop();
                        GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEScaleX(SplashGrid, 2, 1, 0), GEAnimation.GEScaleY(SplashGrid, 2, 1, 0) });
                    }
                    LoadRomProgressBar.Value += 1;
                };
            }
            else
            {
                SplashGrid.Visibility = Visibility.Collapsed;

            }


            AdContainer.Children.Clear();

            //            using (Stream resourceStream = Application.GetResourceStream(new Uri("/PhoneDirect3DXamlAppInterop;component/Assets/GameConfigInfo.xml", UriKind.Relative)).Stream)

            using (Stream infoStream = Application.GetResourceStream(new Uri("Assets/GameConfigInfo.xml", UriKind.Relative)).Stream)
            {
                if (infoStream != null)
                {
                    using (StreamReader reader = new StreamReader(infoStream))
                    {
                        var decryptInfo = CommonHelper.Decrypt(reader.ReadToEnd());
                        byte[] buffer = Encoding.UTF8.GetBytes(decryptInfo);
                        MemoryStream stream = new MemoryStream(buffer); 
                        XmlSerializer serializer = new XmlSerializer(typeof(GameConfigInfos));
                        GameConfigInfos infos = (GameConfigInfos)serializer.Deserialize(stream);
                        HelloKitty.SetPubcenterAdInfo(infos.PubcenterApplicationID, infos.PubcenterAdUnitIDs.Split(',').ToList());
                        HelloKitty.SetGoogleAdInfo(infos.GoogleAdUnitID);
                        HelloKitty.SetGoogleFullScreenAdID(infos.GoogleFullScreenAdID);
                        HelloKitty.SetSurfaceAdInfo(infos.SurfaceAdPosition, infos.SurfaceAdToken);
                        HelloKitty.SetSmaatoAdInfo(Int32.Parse(infos.SmaatoAdID), Int32.Parse(infos.SmaatoPublisherID), Int32.Parse(infos.IsEnableSmaatoAdDebug) != 0);
                        this.GameName.Text = infos.GameName;
                        infoStream.Close();
                        reader.Close();
                        stream.Close();
                        GC.Collect();
                    }
                }
            }

            AdContainer.Children.Add(new HelloKitty());
            //ThreadPool.QueueUserWorkItem((WaitCallback)(obj =>
            //{
            //    Thread.Sleep(5000);
            //    this.Dispatcher.BeginInvoke((System.Action)(() =>
            //    {
            //        HelloKitty.ShowGoogleFullScreenAd();
            //    }));
            //}));
            
        }


        private void cheatBlock_Tap(object sender, ContextMenuItemSelectedEventArgs e)
        {
            RadContextMenuItem item = sender as RadContextMenuItem;
            FrameworkElement parent = VisualTreeHelper.GetParent(item) as FrameworkElement;
            ROMDBEntry entry = parent.DataContext as ROMDBEntry;
            PhoneApplicationService.Current.State["parameter"] = entry;
            base.NavigationService.Navigate(new Uri("/CheatPage.xaml", UriKind.Relative));
        }

        private async Task CopyDemoROM()
        {
            IsolatedStorageSettings isoSettings = IsolatedStorageSettings.ApplicationSettings;
            if (!isoSettings.Contains("DEMOCOPIED"))
            {
                string someone="";
                XElement xElement = XElement.Load("WMAppManifest.xml").Descendants("App").Single<XElement>();
                using (IEnumerator<XAttribute> enumerator = xElement.Attributes().GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        XAttribute current = enumerator.Current;
                        if (current.Name.ToString() != "ProductID")
                        {
                            continue;
                        }
                        someone = current.Value;
                        break;
                    }
                }

                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFolder romFolder = await localFolder.CreateFolderAsync("roms", (CreationCollisionOption)3);
                StorageFile asyncVariable0 = await StorageFile.GetFileFromPathAsync("Assets/dade.gba");
                await asyncVariable0.CopyAsync(romFolder);
                isoSettings["DEMOCOPIED"] = true;
                isoSettings.Save();
                await FileHandler.FillDatabaseAsync();
                this.RefreshRecentROMList();
            }
        }

        private async void deleteBlock_Tap(object sender, ContextMenuItemSelectedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show(AppResources.DeleteConfirmText, AppResources.DeleteConfirmTitle, (MessageBoxButton)1);
                if (result != (MessageBoxResult)2)
                {
                    RadContextMenuItem menuItem = sender as RadContextMenuItem;
                    FrameworkElement parent = VisualTreeHelper.GetParent(menuItem) as FrameworkElement;
                    ROMDBEntry rom = parent.DataContext as ROMDBEntry;
                    await FileHandler.DeleteROMAsync(rom);
                    this.RefreshRecentROMList();
                }
            }
            catch (FileNotFoundException)
            {
            }
        }

        private void deleteManageBlock_Tap(object sender, ContextMenuItemSelectedEventArgs e)
        {
            RadContextMenuItem item = sender as RadContextMenuItem;
            FrameworkElement parent = VisualTreeHelper.GetParent(item) as FrameworkElement;
            ROMDBEntry entry = parent.DataContext as ROMDBEntry;
            PhoneApplicationService.Current.State["parameter"] = entry;
            GEAnimation.RunAnimations(new List<Timeline>(){GEAnimation.GEOpacityUsingKeyTime(this,1,1,0)}, () =>
            {
                base.NavigationService.Navigate(new Uri("/managesavestatepage.xaml", UriKind.Relative));
            });
        }

        private async void deleteSavesBlock_Tap(object sender, ContextMenuItemSelectedEventArgs e)
        {
            ROMDBEntry entry;
            MessageBoxResult result = MessageBox.Show(AppResources.DeleteConfirmText, AppResources.DeleteConfirmTitle, (MessageBoxButton)1);
            if (result != (MessageBoxResult)2)
            {
                RadContextMenuItem menuItem = sender as RadContextMenuItem;
                FrameworkElement parent = VisualTreeHelper.GetParent(menuItem) as FrameworkElement;
                entry = parent.DataContext as ROMDBEntry;
            }
            else
            {
                return;
            }
            await FileHandler.DeleteSRAMFile(entry);
            MessageBox.Show(AppResources.SRAMDeletedSuccessfully, AppResources.InfoCaption, (MessageBoxButton)0);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            base.NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }

        private async void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ROMDBEntry entry = (ROMDBEntry)this.lastRomImage.DataContext;
            await this.StartROM(entry);
        }

        private void InitAppBar()
        {
            base.ApplicationBar = (new ApplicationBar());
            base.ApplicationBar.IsMenuEnabled = (true);
            base.ApplicationBar.BackgroundColor = ((Color)Application.Current.Resources["CustomChromeColor"]);
            base.ApplicationBar.ForegroundColor = ((Color)Application.Current.Resources["CustomForegroundColor"]);
            ApplicationBarMenuItem item = new ApplicationBarMenuItem(AppResources.HelpButtonText);
            item.Click += this.helpButton_Click;
            base.ApplicationBar.MenuItems.Add(item);
            ApplicationBarIconButton button4 = new ApplicationBarIconButton(new Uri("/Assets/Icons/transport.play.png", UriKind.Relative));
            button4.Text = (AppResources.ResumeButtonText);
            button4.IsEnabled = (false);
            this.resumeButton = button4;
            this.resumeButton.Click += (this.resumeButton_Click);
            base.ApplicationBar.Buttons.Add(this.resumeButton);
            ApplicationBarIconButton button5 = new ApplicationBarIconButton(new Uri("/Assets/Icons/feature.settings.png", UriKind.Relative));
            button5.Text = (AppResources.SettingsButtonText);
            ApplicationBarIconButton button = button5;
            button.Click += (this.settingsButton_Click);
            base.ApplicationBar.Buttons.Add(button);
            ApplicationBarIconButton button7 = new ApplicationBarIconButton(new Uri("/Assets/Icons/social.like.png", UriKind.Relative));
            button7.Text = (AppResources.ReviewText);
            ApplicationBarIconButton button3 = button7;
            button3.Click += (this.reviewButton_Click);
            base.ApplicationBar.Buttons.Add(button3);
            ApplicationBar.IsVisible = false;
        }

        private async Task Initialize()
        {
            try
            {
                await FileHandler.CreateInitialFolderStructure();
                await this.CopyDemoROM();
                await this.ParseIniFile();
                if (IsNeedToLoad)
                {
                    if (loadRomTimer != null)
                    {
                        loadRomTimer.Start();
                    }
                }
            }
            catch (TaskCanceledException)
            {
            }
        }

        public static void LoadInitialSettings()
        {
            EmulatorSettings settings = EmulatorSettings.Current;
            if (!settings.Initialized)
            {
                IsolatedStorageSettings settings2 = IsolatedStorageSettings.ApplicationSettings;
                settings.Initialized = (true);

                if (!settings2.Contains("RateGameKey"))
                {
                    settings2["RateGameKey"] = (false);
                }

                if (!settings2.Contains("EnableSound"))
                {
                    settings2["EnableSound"] = (true);
                }
                if (!settings2.Contains("VirtualControllerOnTop"))
                {
                    settings2["VirtualControllerOnTop"] = (false);
                }
                if (!settings2.Contains("LowFrequencyModeNew"))
                {
                    settings2["LowFrequencyModeNew"] = (false);
                }
                if (!settings2.Contains("Orientation"))
                {
                    settings2["Orientation"] = (1);
                }
                if (!settings2.Contains("ControllerScale"))
                {
                    settings2["ControllerScale"] = (120);
                }
                if (!settings2.Contains("ButtonScale"))
                {
                    settings2["ButtonScale"] = (100);
                }
                if (!settings2.Contains("ControllerOpacity"))
                {
                    settings2["ControllerOpacity"] = (50);
                }
                if (!settings2.Contains("AspectRatioModeKey"))
                {
                    settings2["AspectRatioModeKey"] = ((AspectRatioMode)0);
                }
                if (!settings2.Contains("SkipFramesKey2"))
                {
                    settings2["SkipFramesKey2"] = (0);
                }
                if (!settings2.Contains("ImageScalingKey"))
                {
                    settings2["ImageScalingKey"] = (100);
                }
                if (!settings2.Contains("TurboSkipFramesKey"))
                {
                    settings2["TurboSkipFramesKey"] = (4);
                }
                if (!settings2.Contains("SynchronizeAudioKey"))
                {
                    settings2["SynchronizeAudioKey"] = (false);
                }
                if (!settings2.Contains("PowerSaveSkipKey"))
                {
                    settings2["PowerSaveSkipKey"] = (0);
                }
                if (!settings2.Contains("DPadStyleKey"))
                {
                    settings2["DPadStyleKey"] = (2);
                }
                if (!settings2.Contains("DeadzoneKey"))
                {
                    settings2["DeadzoneKey"] = (10f);
                }
                if (!settings2.Contains("CameraAssignmentKey"))
                {
                    settings2["CameraAssignmentKey"] = (0);
                }
                if (!settings2.Contains("ConfirmationKey"))
                {
                    settings2["ConfirmationKey"] = (false);
                }
                if (!settings2.Contains("ConfirmationLoadKey"))
                {
                    settings2["ConfirmationLoadKey"] = (false);
                }
                if (!settings2.Contains("AutoIncKey"))
                {
                    settings2["AutoIncKey"] = (false);
                }
                if (!settings2.Contains("SelectLastStateKey"))
                {
                    settings2["SelectLastStateKey"] = (true);
                }
                if (!settings2.Contains("RestoreCheatKey"))
                {
                    settings2["RestoreCheatKey"] = (false);
                }
                if (!settings2.Contains("ManualSnapshotKey"))
                {
                    settings2["ManualSnapshotKey"] = (false);
                }
                if (!settings2.Contains("UseMogaControllerKey"))
                {
                    settings2["UseMogaControllerKey"] = (false);
                }
                if (!settings2.Contains("UseColorButtonKey"))
                {
                    settings2["UseColorButtonKey"] = (true);
                }
                if (!settings2.Contains("BgcolorRKey"))
                {
                    settings2["BgcolorRKey"] = (210);
                }
                if (!settings2.Contains("BgcolorGKey"))
                {
                    settings2["BgcolorGKey"] = (210);
                }
                if (!settings2.Contains("BgcolorBKey"))
                {
                    settings2["BgcolorBKey"] = (210);
                }
                if (!settings2.Contains("AutSaveLoadKey"))
                {
                    settings2["AutSaveLoadKey"] = (App.metroSettings.LoadLastState);
                }
                if (!settings2.Contains("VirtualControllerStyleKey"))
                {
                    settings2["VirtualControllerStyleKey"] = (1);
                }
                if (!settings2.Contains("VibrationEnabledKey"))
                {
                    settings2["VibrationEnabledKey"] = (false);
                }
                if (!settings2.Contains("VibrationDurationKey"))
                {
                    settings2["VibrationDurationKey"] = (0.02);
                }
                if (!settings2.Contains("EnableAutoFireKey"))
                {
                    settings2["EnableAutoFireKey"] = (false);
                }
                if (!settings2.Contains("MapABLRTurboKey"))
                {
                    settings2["MapABLRTurboKey"] = (true);
                }
                if (!settings2.Contains("FullPressStickABLRKey"))
                {
                    settings2["FullPressStickABLRKey"] = (true);
                }
                if (!settings2.Contains("UseMotionControlKey"))
                {
                    settings2["UseMotionControlKey"] = (0);
                }
                if (!settings2.Contains("UseTurboKey"))
                {
                    settings2["UseTurboKey"] = (false);
                }
                int[] defaultControllerPosition = CustomizeControllerPage.GetDefaultControllerPosition();
                if (!settings2.Contains("PadCenterXPKey"))
                {
                    settings2["PadCenterXPKey"] = (defaultControllerPosition[0]);
                }
                if (!settings2.Contains("PadCenterYPKey"))
                {
                    settings2["PadCenterYPKey"] = (defaultControllerPosition[1]);
                }
                if (!settings2.Contains("ALeftPKey"))
                {
                    settings2["ALeftPKey"] = (defaultControllerPosition[2]);
                }
                if (!settings2.Contains("ATopPKey"))
                {
                    settings2["ATopPKey"] = (defaultControllerPosition[3]);
                }
                if (!settings2.Contains("BLeftPKey"))
                {
                    settings2["BLeftPKey"] = (defaultControllerPosition[4]);
                }
                if (!settings2.Contains("BTopPKey"))
                {
                    settings2["BTopPKey"] = (defaultControllerPosition[5]);
                }
                if (!settings2.Contains("StartLeftPKey"))
                {
                    settings2["StartLeftPKey"] = (defaultControllerPosition[6]);
                }
                if (!settings2.Contains("StartTopPKey"))
                {
                    settings2["StartTopPKey"] = (defaultControllerPosition[7]);
                }
                if (!settings2.Contains("SelectRightPKey"))
                {
                    settings2["SelectRightPKey"] = (defaultControllerPosition[8]);
                }
                if (!settings2.Contains("SelectTopPKey"))
                {
                    settings2["SelectTopPKey"] = (defaultControllerPosition[9]);
                }
                if (!settings2.Contains("LLeftPKey"))
                {
                    settings2["LLeftPKey"] = (defaultControllerPosition[10]);
                }
                if (!settings2.Contains("LTopPKey"))
                {
                    settings2["LTopPKey"] = (defaultControllerPosition[11]);
                }
                if (!settings2.Contains("RRightPKey"))
                {
                    settings2["RRightPKey"] = (defaultControllerPosition[12]);
                }
                if (!settings2.Contains("RTopPKey"))
                {
                    settings2["RTopPKey"] = (defaultControllerPosition[13]);
                }
                if (!settings2.Contains("PadCenterXLKey"))
                {
                    settings2["PadCenterXLKey"] = (defaultControllerPosition[14]);
                }
                if (!settings2.Contains("PadCenterYLKey"))
                {
                    settings2["PadCenterYLKey"] = (defaultControllerPosition[15]);
                }
                if (!settings2.Contains("ALeftLKey"))
                {
                    settings2["ALeftLKey"] = (defaultControllerPosition[0x10]);
                }
                if (!settings2.Contains("ATopLKey"))
                {
                    settings2["ATopLKey"] = (defaultControllerPosition[0x11]);
                }
                if (!settings2.Contains("BLeftLKey"))
                {
                    settings2["BLeftLKey"] = (defaultControllerPosition[0x12]);
                }
                if (!settings2.Contains("BTopLKey"))
                {
                    settings2["BTopLKey"] = (defaultControllerPosition[0x13]);
                }
                if (!settings2.Contains("StartLeftLKey"))
                {
                    settings2["StartLeftLKey"] = (defaultControllerPosition[20]);
                }
                if (!settings2.Contains("StartTopLKey"))
                {
                    settings2["StartTopLKey"] = (defaultControllerPosition[0x15]);
                }
                if (!settings2.Contains("SelectRightLKey"))
                {
                    settings2["SelectRightLKey"] = (defaultControllerPosition[0x16]);
                }
                if (!settings2.Contains("SelectTopLKey"))
                {
                    settings2["SelectTopLKey"] = (defaultControllerPosition[0x17]);
                }
                if (!settings2.Contains("LLeftLKey"))
                {
                    settings2["LLeftLKey"] = (defaultControllerPosition[0x18]);
                }
                if (!settings2.Contains("LTopLKey"))
                {
                    settings2["LTopLKey"] = (defaultControllerPosition[0x19]);
                }
                if (!settings2.Contains("RRightLKey"))
                {
                    settings2["RRightLKey"] = (defaultControllerPosition[0x1a]);
                }
                if (!settings2.Contains("RTopLKey"))
                {
                    settings2["RTopLKey"] = (defaultControllerPosition[0x1b]);
                }
                if (!settings2.Contains("MogaAKey"))
                {
                    settings2["MogaAKey"] = (2);
                }
                if (!settings2.Contains("MogaBKey"))
                {
                    settings2["MogaBKey"] = (1);
                }
                if (!settings2.Contains("MogaXKey"))
                {
                    settings2["MogaXKey"] = (0x10);
                }
                if (!settings2.Contains("MogaYKey"))
                {
                    settings2["MogaYKey"] = (0x10);
                }
                if (!settings2.Contains("MogaL1Key"))
                {
                    settings2["MogaL1Key"] = (4);
                }
                if (!settings2.Contains("MogaL2Key"))
                {
                    settings2["MogaL2Key"] = (4);
                }
                if (!settings2.Contains("MogaR1Key"))
                {
                    settings2["MogaR1Key"] = (8);
                }
                if (!settings2.Contains("MogaR2Key"))
                {
                    settings2["MogaR2Key"] = (8);
                }
                if (!settings2.Contains("MogaLeftJoystickKey"))
                {
                    settings2["MogaLeftJoystickKey"] = (0x10);
                }
                if (!settings2.Contains("MogaRightJoystickKey"))
                {
                    settings2["MogaRightJoystickKey"] = (0x10);
                }
                if (!settings2.Contains("MotionLeftKey"))
                {
                    settings2["MotionLeftKey"] = (1);
                }
                if (!settings2.Contains("MotionRightKey"))
                {
                    settings2["MotionRightKey"] = (2);
                }
                if (!settings2.Contains("MotionUpKey"))
                {
                    settings2["MotionUpKey"] = (4);
                }
                if (!settings2.Contains("MotionDownKey"))
                {
                    settings2["MotionDownKey"] = (8);
                }
                if (!settings2.Contains("RestAngleXKey"))
                {
                    settings2["RestAngleXKey"] = (0.0);
                }
                if (!settings2.Contains("RestAngleYKey"))
                {
                    settings2["RestAngleYKey"] = (-0.70711);
                }
                if (!settings2.Contains("RestAngleZKey"))
                {
                    settings2["RestAngleZKey"] = (-0.70711);
                }
                if (!settings2.Contains("MotionDeadzoneHKey"))
                {
                    settings2["MotionDeadzoneHKey"] = (10.0);
                }
                if (!settings2.Contains("MotionDeadzoneVKey"))
                {
                    settings2["MotionDeadzoneVKey"] = (10.0);
                }
                if (!settings2.Contains("MotionAdaptOrientationKey"))
                {
                    settings2["MotionAdaptOrientationKey"] = (true);
                }
                settings2.Save();
                settings.LowFrequencyMode = ((bool)settings2["LowFrequencyModeNew"]);
                settings.SoundEnabled = ((bool)settings2["EnableSound"]);
                settings.Orientation = ((int)settings2["Orientation"]);
                settings.ControllerScale = ((int)settings2["ControllerScale"]);
                settings.ButtonScale = ((int)settings2["ButtonScale"]);
                settings.ControllerOpacity = ((int)settings2["ControllerOpacity"]);
                settings.AspectRatio = AspectRatioMode.Stretch;
                settings.FrameSkip = ((int)settings2["SkipFramesKey2"]);
                settings.ImageScaling = ((int)settings2["ImageScalingKey"]);
                settings.TurboFrameSkip = ((int)settings2["TurboSkipFramesKey"]);
                settings.SynchronizeAudio = ((bool)settings2["SynchronizeAudioKey"]);
                settings.PowerFrameSkip = ((int)settings2["PowerSaveSkipKey"]);
                settings.DPadStyle = ((int)settings2["DPadStyleKey"]);
                settings.Deadzone = ((float)settings2["DeadzoneKey"]);
                settings.CameraButtonAssignment = ((int)settings2["CameraAssignmentKey"]);
                settings.AutoIncrementSavestates = ((bool)settings2["AutoIncKey"]);
                settings.HideConfirmationDialogs = ((bool)settings2["ConfirmationKey"]);
                settings.HideLoadConfirmationDialogs = ((bool)settings2["ConfirmationLoadKey"]);
                settings.SelectLastState = ((bool)settings2["SelectLastStateKey"]);
                settings.RestoreOldCheatValues = ((bool)settings2["RestoreCheatKey"]);
                settings.ManualSnapshots = ((bool)settings2["ManualSnapshotKey"]);
                settings.UseMogaController = ((bool)settings2["UseMogaControllerKey"]);
                settings.BgcolorR = ((int)settings2["BgcolorRKey"]);
                settings.BgcolorG = ((int)settings2["BgcolorGKey"]);
                settings.BgcolorB = ((int)settings2["BgcolorBKey"]);
                settings.AutoSaveLoad = ((bool)settings2["AutSaveLoadKey"]);
                settings.VirtualControllerStyle = ((int)settings2["VirtualControllerStyleKey"]);
                settings.VibrationEnabled = ((bool)settings2["VibrationEnabledKey"]);
                settings.VibrationDuration = ((double)settings2["VibrationDurationKey"]);
                settings.EnableAutoFire = ((bool)settings2["EnableAutoFireKey"]);
                settings.MapABLRTurbo = ((bool)settings2["MapABLRTurboKey"]);
                settings.FullPressStickABLR = ((bool)settings2["FullPressStickABLRKey"]);
                settings.UseMotionControl = ((int)settings2["UseMotionControlKey"]);
                settings.UseTurbo = ((bool)settings2["UseTurboKey"]);
                settings.PadCenterXP = ((int)settings2["PadCenterXPKey"]);
                settings.PadCenterYP = ((int)settings2["PadCenterYPKey"]);
                settings.ALeftP = ((int)settings2["ALeftPKey"]);
                settings.ATopP = ((int)settings2["ATopPKey"]);
                settings.BLeftP = ((int)settings2["BLeftPKey"]);
                settings.BTopP = ((int)settings2["BTopPKey"]);
                settings.StartLeftP = ((int)settings2["StartLeftPKey"]);
                settings.StartTopP = ((int)settings2["StartTopPKey"]);
                settings.SelectRightP = ((int)settings2["SelectRightPKey"]);
                settings.SelectTopP = ((int)settings2["SelectTopPKey"]);
                settings.LLeftP = ((int)settings2["LLeftPKey"]);
                settings.LTopP = ((int)settings2["LTopPKey"]);
                settings.RRightP = ((int)settings2["RRightPKey"]);
                settings.RTopP = ((int)settings2["RTopPKey"]);
                settings.PadCenterXL = ((int)settings2["PadCenterXLKey"]);
                settings.PadCenterYL = ((int)settings2["PadCenterYLKey"]);
                settings.ALeftL = ((int)settings2["ALeftLKey"]);
                settings.ATopL = ((int)settings2["ATopLKey"]);
                settings.BLeftL = ((int)settings2["BLeftLKey"]);
                settings.BTopL = ((int)settings2["BTopLKey"]);
                settings.StartLeftL = ((int)settings2["StartLeftLKey"]);
                settings.StartTopL = ((int)settings2["StartTopLKey"]);
                settings.SelectRightL = ((int)settings2["SelectRightLKey"]);
                settings.SelectTopL = ((int)settings2["SelectTopLKey"]);
                settings.LLeftL = ((int)settings2["LLeftLKey"]);
                settings.LTopL = ((int)settings2["LTopLKey"]);
                settings.RRightL = ((int)settings2["RRightLKey"]);
                settings.RTopL = ((int)settings2["RTopLKey"]);
                settings.MogaA = ((int)settings2["MogaAKey"]);
                settings.MogaB = ((int)settings2["MogaBKey"]);
                settings.MogaX = ((int)settings2["MogaXKey"]);
                settings.MogaY = ((int)settings2["MogaYKey"]);
                settings.MogaL1 = ((int)settings2["MogaL1Key"]);
                settings.MogaL2 = ((int)settings2["MogaL2Key"]);
                settings.MogaR1 = ((int)settings2["MogaR1Key"]);
                settings.MogaR2 = ((int)settings2["MogaR2Key"]);
                settings.MogaLeftJoystick = ((int)settings2["MogaLeftJoystickKey"]);
                settings.MogaRightJoystick = ((int)settings2["MogaRightJoystickKey"]);
                settings.MotionLeft = ((int)settings2["MotionLeftKey"]);
                settings.MotionRight = ((int)settings2["MotionRightKey"]);
                settings.MotionUp = ((int)settings2["MotionUpKey"]);
                settings.MotionDown = ((int)settings2["MotionDownKey"]);
                settings.RestAngleX = ((double)settings2["RestAngleXKey"]);
                settings.RestAngleY = ((double)settings2["RestAngleYKey"]);
                settings.RestAngleZ = ((double)settings2["RestAngleZKey"]);
                settings.MotionDeadzoneH = ((double)settings2["MotionDeadzoneHKey"]);
                settings.MotionDeadzoneV = ((double)settings2["MotionDeadzoneVKey"]);
                settings.MotionAdaptOrientation = ((bool)settings2["MotionAdaptOrientationKey"]);
                settings.SettingsChanged = (new PhoneDirect3DXamlAppComponent.SettingsChangedDelegate(SettingsChangedDelegate));
            }
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            MainPageContainer.Children.Clear();

            GEGridSprite backgroundSprite = new GEGridSprite("/Assets/mainbg.png");
            MainPageContainer.AddChild(backgroundSprite);

            GridButton playBtn = new GridButton("/Assets/playbtn.png");
            playBtn.Width = 117;
            playBtn.Height = 132;
            playBtn.Tap -= playBtn_Tap;
            playBtn.Tap += playBtn_Tap;
            MainPageContainer.AddChild(playBtn, 322, 190, 1);

            //GridButton actionGameBtn = new GridButton("/Assets/actiongames.png");
            //actionGameBtn.Width = 150;
            //actionGameBtn.Height = 70;
            //actionGameBtn.Tap += actionGameBtn_Tap;
            //MainPageContainer.AddChild(actionGameBtn, 633, 77, 1);

            GridButton reviewBtn = new GridButton("/Assets/review.png");
            reviewBtn.Width = 150;
            reviewBtn.Height = 70;
            reviewBtn.Tap -= reviewBtn_Tap;
            reviewBtn.Tap += reviewBtn_Tap;
            MainPageContainer.AddChild(reviewBtn, 135, 372, 1);


            GridButton soundButton = null;
            if (EmulatorSettings.Current.SoundEnabled)
            {
                soundButton = new GridButton("/Assets/soundOn.png");
            }
            else
            {
                soundButton = new GridButton("/Assets/soundOff.png");
            }
            soundButton.Width = 150;
            soundButton.Height = 70;
            soundButton.Tap += (ss, ee) =>
            {
                EmulatorSettings.Current.SoundEnabled = !EmulatorSettings.Current.SoundEnabled;
                IsolatedStorageSettings settings2 = IsolatedStorageSettings.ApplicationSettings;
                settings2["EnableSound"] = EmulatorSettings.Current.SoundEnabled;
                settings2.Save();
                if (EmulatorSettings.Current.SoundEnabled)
                {
                    soundButton.ChangeImage("/Assets/soundOn.png");
                }
                else
                {
                    soundButton.ChangeImage("/Assets/soundOff.png");
                }
                MainPageContainer.ChangePosition(soundButton, 135 + 150 + 20, 372);
            };
            MainPageContainer.AddChild(soundButton, 135 + 150 + 20, 372, 1);

            GridButton saveStoreBtn = new GridButton("/Assets/savestore.png");
            saveStoreBtn.Width = 150;
            saveStoreBtn.Height = 70;
            saveStoreBtn.Tap -= saveStoreBtn_Tap;
            saveStoreBtn.Tap += saveStoreBtn_Tap;
            MainPageContainer.AddChild(saveStoreBtn, 135 + 150 + 20 + 150 + 20, 372, 1);

            try
            {
                if (this.NavigationContext.QueryString.ContainsKey("rom"))
                {
                    string fileName = this.NavigationContext.QueryString["rom"];
                    this.NavigationContext.QueryString.Remove("rom");
                    ROMDBEntry rOM = ROMDatabase.Current.GetROM(fileName);
                    if (rOM != null)
                    {
                        await this.StartROM(rOM);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show(AppResources.TileOpenError, AppResources.ErrorCaption, (MessageBoxButton)0);
            }
            try
            {
                if (this.NavigationContext.QueryString.ContainsKey("fileToken"))
                {
                    string fileId = this.NavigationContext.QueryString["fileToken"];
                    this.NavigationContext.QueryString.Remove("fileToken");
                    string path = HttpUtility.UrlDecode(SharedStorageAccessManager.GetSharedFileName(fileId).Replace("[1]", ""));
                    string incomingFileType = Path.GetExtension(path).ToLower();

                    if (((incomingFileType == ".gb") || (incomingFileType == ".gbc")) || (incomingFileType == ".gba"))
                    {
                        await FileHandler.ImportRomBySharedID(fileId, path, this);
                        this.RefreshRecentROMList();
                    }
                    else if ((incomingFileType == ".sgm") || (incomingFileType == ".sav"))
                    {
                        await FileHandler.ImportSaveBySharedID(fileId, path, this);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(AppResources.FileAssociationError, AppResources.ErrorCaption, 0);
            }

            SystemTray.GetProgressIndicator(this).Text = (AppResources.ApplicationTitle2);
        }

        void actionGameBtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEOpacityUsingKeyTime(this, 1, 1, 0) }, () =>
            {
                base.NavigationService.Navigate(new Uri("/RecommendPage.xaml", UriKind.Relative));
            });
        }

        private async void saveStoreBtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (romList.Items != null)
            {
                ROMDBEntry entry = (ROMDBEntry)romList.Items[0];
                PhoneApplicationService.Current.State["parameter"] = entry;
                GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEOpacityUsingKeyTime(this, 1, 1, 0) }, () =>
                {
                    base.NavigationService.Navigate(new Uri("/ManageSavestatePage.xaml", UriKind.Relative));
                });
              
            }


        }

        private async void playBtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                if (romList.Items != null)
                {
                    ROMDBEntry entry = (ROMDBEntry)romList.Items[0];

                    await this.StartROM(entry);
                }
            }
            catch (Exception)
            {

            }
        }

        void reviewBtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GameService.Instance.IsRateGame = true;
            new MarketplaceReviewTask().Show();
        }

        public override void StopAnimation()
        {

            base.StopAnimation();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            while (base.NavigationService.CanGoBack)
            {
                base.NavigationService.RemoveBackEntry();
            }

            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.ContainsKey("AppId"))
            {
                new MarketplaceDetailTask { ContentIdentifier = NavigationContext.QueryString["AppId"].ToString() }.Show();
                NavigationContext.QueryString.Remove("AppId");
            }

            if (this.ApplicationBar != null)
            {
                this.ApplicationBar.BackgroundColor = ((Color)Application.Current.Resources["CustomChromeColor"]);
                this.ApplicationBar.ForegroundColor = ((Color)Application.Current.Resources["CustomForegroundColor"]);
            }
            if (this.shouldInitialize)
            {
                await this.Initialize();
                this.shouldInitialize = false;
            }
            LoadInitialSettings();
            //if (!App.metroSettings.FirstTurboPrompt)
            //{
            //    RadMessageBox.Show(AppResources.EnableTurboPromptTitle, MessageBoxButtons.YesNo, AppResources.EnableTurboPromptText, null, false, true, (HorizontalAlignment)3, 0, delegate(MessageBoxClosedEventArgs args)
            //    {
            //        if (args.Result == DialogResult.OK)
            //        {
            //            EmulatorSettings.Current.UseTurbo = (true);
            //        }
            //    });
            //    App.metroSettings.FirstTurboPrompt = true;
            //}
            if (shouldUpdateBackgroud)
            {
                this.UpdateBackgroundImage();
                shouldUpdateBackgroud = false;
            }
            if (shouldRefreshRecentROMList)
            {
                this.RefreshRecentROMList();
                shouldRefreshRecentROMList = false;
            }
            if (shouldRefreshAllROMList)
            {
                this.SortRomList();
                shouldRefreshAllROMList = false;
            }
            if (this.lastRomImage.DataContext != null)
            {
                this.resumeButton.IsEnabled = (true);
            }
            else
            {
                this.resumeButton.IsEnabled = (false);
            }
            if (e.NavigationMode == (NavigationMode)3)
            {
                QueryString query = new QueryString(e.Uri.ToString());
                if (query.ContainsKey("rom"))
                {
                    string fileName = query["rom"];
                    ROMDBEntry rOM = ROMDatabase.Current.GetROM(fileName);
                    if (rOM != null)
                    {
                        await this.StartROM(rOM);
                    }
                }
                else if (query.ContainsKey("voiceCommandName"))
                {
                    string voiceCommandName = query["voiceCommandName"];
                    if (voiceCommandName == "PlayGame")
                    {
                        string spokenRomName = query["RomName"];
                        ROMDBEntry entry = ROMDatabase.Current.GetROM(spokenRomName);
                        if (entry != null)
                        {
                            await this.StartROM(entry);
                        }
                    }
                }
            }
        }

        private async Task ParseIniFile()
        {
            StorageFile file = await StorageFile.GetFileFromPathAsync("Assets/vba-over.ini");
            GBAIniParser parser = new GBAIniParser();
            EmulatorSettings settings2 = EmulatorSettings.Current;
            IDictionary<string, ROMConfig> introduced11 = await parser.ParseAsync(file);
            settings2.ROMConfigurations = (introduced11);
        }

        private void pinBlock_Tap(object sender, ContextMenuItemSelectedEventArgs e)
        {
            try
            {
                //RadContextMenuItem item = sender as RadContextMenuItem;
                //FrameworkElement parent = VisualTreeHelper.GetParent(item) as FrameworkElement;
                //ROMDBEntry re = parent.DataContext as ROMDBEntry;
                //FileHandler.CreateROMTile(re);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show(AppResources.MaximumTilesPinned);
            }
        }


        private void recentList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.StartROMFromList(this.recentList);
        }

        private void RefreshRecentROMList()
        {
            this.lastRomImage.DataContext = (ROMDatabase.Current.GetLastPlayed());
            if (this.lastRomImage.DataContext != null)
            {
                this.resumeButton.IsEnabled = (true);
            }
            else
            {
                this.resumeButton.IsEnabled = (false);
            }
            if ((this.lastRomImage.DataContext != null) && App.metroSettings.ShowLastPlayedGame)
            {
                this.lastRomGrid.Visibility = (System.Windows.Visibility)(0);
            }
            else
            {
                this.lastRomGrid.Visibility = (System.Windows.Visibility)(1);
            }
            this.recentList.ItemsSource = (ROMDatabase.Current.GetRecentlyPlayed());
        }

        public async static Task RegisterVoiceCommand(string prefix)
        {
            if ((prefix != null) && (prefix.Trim() != ""))
            {
                string originalText;
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile originalFile = await StorageFile.GetFileFromPathAsync("VoiceCommandDefinitions.xml");
                IRandomAccessStreamWithContentType type = await originalFile.OpenReadAsync();
                IRandomAccessStream windowsRuntimeStream = type;
                using (Stream asyncVariable0 = windowsRuntimeStream.AsStreamForRead((int)windowsRuntimeStream.Size))
                {
                    byte[] buffer = new byte[asyncVariable0.Length];
                    await asyncVariable0.ReadAsync(buffer, 0, (int)asyncVariable0.Length);
                    originalText = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                }
                int index = originalText.IndexOf("    <Example>");
                if (index < 0)
                {
                    MessageBox.Show("Error! Cannot find <Example>");
                }
                else
                {
                    string s = originalText.Substring(0, index);
                    s = s + "    <CommandPrefix> " + prefix + "</CommandPrefix>\r\n";
                    s = s + originalText.Substring(index);
                    StorageFile file2 = await localFolder.CreateFileAsync("VoiceCommandDefinitions.xml", (CreationCollisionOption)1);
                    IStorageFile windowsRuntimeFile = file2;
                    using (Stream asyncVariable1 = await windowsRuntimeFile.OpenStreamForWriteAsync())
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(s);
                        await asyncVariable1.WriteAsync(bytes, 0, bytes.Length);
                    }
                    Uri uri = new Uri("ms-appdata:///local/VoiceCommandDefinitions.xml", UriKind.Absolute);
                    await VoiceCommandService.InstallCommandSetsFromFileAsync(uri);
                }
            }
            else
            {
                Uri uri = new Uri("ms-appx:///VoiceCommandDefinitions.xml", UriKind.Absolute);
                await VoiceCommandService.InstallCommandSetsFromFileAsync(uri);
            }
        }

        private void renameBlock_Tap(object sender, ContextMenuItemSelectedEventArgs e)
        {
            RadContextMenuItem item = sender as RadContextMenuItem;
            FrameworkElement parent = VisualTreeHelper.GetParent(item) as FrameworkElement;
            ROMDBEntry entry = parent.DataContext as ROMDBEntry;
            PhoneApplicationService.Current.State["parameter"] = entry;
            PhoneApplicationService.Current.State["parameter2"] = ROMDatabase.Current;
            base.NavigationService.Navigate(new Uri("/RenamePage.xaml", UriKind.Relative));
        }

        private async void resumeButton_Click(object sender, EventArgs e)
        {
            ROMDBEntry lastPlayed = ROMDatabase.Current.GetLastPlayed();
            await this.StartROM(lastPlayed);
            this.romList.SelectedItem = (null);
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            new MarketplaceReviewTask().Show();
        }

        private void romList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.StartROMFromList(this.romList);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            base.NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }

        public static void SettingsChangedDelegate()
        {
            EmulatorSettings settings = EmulatorSettings.Current;
            IsolatedStorageSettings settings2 = IsolatedStorageSettings.ApplicationSettings;
            settings2["EnableSound"] = (settings.SoundEnabled);
            settings2["LowFrequencyModeNew"] = (settings.LowFrequencyMode);
            settings2["Orientation"] = (settings.Orientation);
            settings2["ControllerScale"] = (settings.ControllerScale);
            settings2["ButtonScale"] = (settings.ButtonScale);
            settings2["ControllerOpacity"] = (settings.ControllerOpacity);
            settings2["SkipFramesKey2"] = (settings.FrameSkip);
            settings2["AspectRatioModeKey"] = (settings.AspectRatio);
            settings2["ImageScalingKey"] = (settings.ImageScaling);
            settings2["TurboSkipFramesKey"] = (settings.TurboFrameSkip);
            settings2["SynchronizeAudioKey"] = (settings.SynchronizeAudio);
            settings2["PowerSaveSkipKey"] = (settings.PowerFrameSkip);
            settings2["DPadStyleKey"] = (settings.DPadStyle);
            settings2["DeadzoneKey"] = (settings.Deadzone);
            settings2["CameraAssignmentKey"] = (settings.CameraButtonAssignment);
            settings2["ConfirmationKey"] = (settings.HideConfirmationDialogs);
            settings2["AutoIncKey"] = (settings.AutoIncrementSavestates);
            settings2["ConfirmationLoadKey"] = (settings.HideLoadConfirmationDialogs);
            settings2["SelectLastStateKey"] = (settings.SelectLastState);
            settings2["RestoreCheatKey"] = (settings.RestoreOldCheatValues);
            settings2["ManualSnapshotKey"] = (settings.ManualSnapshots);
            settings2["UseMogaControllerKey"] = (settings.UseMogaController);
            settings2["BgcolorRKey"] = (settings.BgcolorR);
            settings2["BgcolorGKey"] = (settings.BgcolorG);
            settings2["BgcolorBKey"] = (settings.BgcolorB);
            settings2["AutSaveLoadKey"] = (settings.AutoSaveLoad);
            settings2["VirtualControllerStyleKey"] = (settings.VirtualControllerStyle);
            settings2["VibrationEnabledKey"] = (settings.VibrationEnabled);
            settings2["VibrationDurationKey"] = (settings.VibrationDuration);
            settings2["EnableAutoFireKey"] = (settings.EnableAutoFire);
            settings2["MapABLRTurboKey"] = (settings.MapABLRTurbo);
            settings2["FullPressStickABLRKey"] = (settings.FullPressStickABLR);
            settings2["UseMotionControlKey"] = (settings.UseMotionControl);
            settings2.Save();
        }

        private void SortRomList()
        {
            CollectionViewSource source = new CollectionViewSource();
            source.SortDescriptions.Add(new SortDescription("DisplayName", ListSortDirection.Ascending));
            source.Source = (ROMDatabase.Current.AllROMDBEntries);
            this.romList.DataContext = (source);
            this.romList.SelectedItem = (null);
        }

        private async Task StartROM(ROMDBEntry entry)
        {
            if (entry.SuspendAutoLoadLastState)
            {
                EmulatorPage.ROMLoaded = false;
            }
            EmulatorPage.currentROMEntry = entry;
            LoadROMParameter param = await FileHandler.GetROMFileToPlayAsync(entry.FileName);
            PhoneApplicationService.Current.State["parameter"] = param;
            GEAnimation.RunAnimations(new List<Timeline>() { GEAnimation.GEOpacityUsingKeyTime(this, 1, 1, 0) }, () =>
            {
                this.NavigationService.Navigate(new Uri("/EmulatorPage.xaml", UriKind.Relative));
            });
            
        }

        private async void StartROMFromList(ListBox list)
        {
            ROMDBEntry entry;
            if (list.SelectedItem != null)
            {
                entry = (ROMDBEntry)list.SelectedItem;
                list.SelectedItem = (null);
            }
            else
            {
                return;
            }
            await this.StartROM(entry);
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
                this.panorama.Background = (brush);
            }
            else
            {
                this.panorama.Background = (null);
            }
        }

    }
}

