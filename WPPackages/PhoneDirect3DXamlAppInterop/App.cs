using System.Globalization;
using System.Threading;

namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Info;
    using Microsoft.Phone.Shell;
    using PhoneDirect3DXamlAppComponent;
    using PhoneDirect3DXamlAppInterop.Database;
    using PhoneDirect3DXamlAppInterop.Resources;
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Navigation;
    using Windows.ApplicationModel.Store;
    using Windows.Networking.Sockets;

    public partial class App : Application
    {
        public string jijiK = "c78193388eed652a104cd29e";
        public string jijiC = "c153290fd66b15cd757487cd";

        public static int APP_VERSION = 2;
        public static string exportFolderID;
        public static DateTime LastAutoBackupTime;
        public static StreamSocket linkSocket;
        public static AppSettings metroSettings = new AppSettings();
        private bool mustClearPagestack;
        private bool phoneApplicationInitialized;
        private IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        public static int VOICE_COMMAND_VERSION = 11;
        private bool wasRelaunched;

        public App()
        {
            base.UnhandledException += (this.Application_UnhandledException);
            this.InitializeComponent();
            MergeCustomColors();
            this.InitializePhoneApplication();
            this.InitializeLanguage();
            if (Debugger.IsAttached)
            {
                Application.Current.Host.Settings.EnableFrameRateCounter = (true);
                PhoneApplicationService.Current.UserIdleDetectionMode = (IdleDetectionMode)(1);
            }
            ROMDatabase.Current.Initialize();
            ROMDatabase.Current.LoadCollectionsFromDatabase();

            if (Thread.CurrentThread.CurrentCulture.Name != "en-US")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            }
        }

        private void Application_Activated(object sender, ActivatedEventArgs e)
        {

            if (!e.IsApplicationInstancePreserved)
            {
                EmulatorPage.IsTombstoned = true;
            }

            try
            {
                JPushSDK.JServer.Activated();
            }
            catch { }
        }

        private void Application_Closing(object sender, ClosingEventArgs e)
        {
            this.RemoveCurrentDeactivationSettings();
        }

        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            this.SaveCurrentDeactivationSettings();

            try
            {
                JPushSDK.JServer.Deactivated();
            }
            catch { }
        }

        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            try
            {
                JPushSDK.JServer.Setup(jijiK, jijiC, null);
                JPushSDK.JServer.RegisterNotification();
                UmengSDK.UmengAnalytics.onLaunching("5666e132e0f55af9b4002841");
            }
            catch { }
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            if (e.NavigationMode == (NavigationMode)4)
            {
                this.RootFrame.Navigated += this.ClearBackStackAfterReset;
            }
        }

        private bool CheckLastRomPlayed(string currentUri)
        {
            bool flag = false;
            if (metroSettings.Contains("LastFilePlayed"))
            {
                string str = this.settings["LastFilePlayed"] as string;
                flag = currentUri.Contains(str);
            }
            if (!flag && metroSettings.Contains("LastRomPlayed"))
            {
                string str2 = this.settings["LastRomPlayed"] as string;
                flag = currentUri.ToLower().Contains(str2.ToLower());
            }
            return flag;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            this.RootFrame.Navigated -= ClearBackStackAfterReset;
            if (e.NavigationMode == null)
            {
                while (this.RootFrame.RemoveBackEntry() != null)
                {
                }
            }
        }

        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            if (base.RootVisual != this.RootFrame)
            {
                base.RootVisual = (this.RootFrame);
            }
            this.RootFrame.Navigated -= this.CompleteInitializePhoneApplication;
        }

        private void InitializeLanguage()
        {
            try
            {
                this.RootFrame.Language = (XmlLanguage.GetLanguage(AppResources.ResourceLanguage));
                FlowDirection direction = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                this.RootFrame.FlowDirection = (direction);
            }
            catch
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                throw;
            }
        }

        private void InitializePhoneApplication()
        {
            if (!this.phoneApplicationInitialized)
            {
                this.RootFrame = new PhoneApplicationFrame();
                this.RootFrame.Navigated += this.CompleteInitializePhoneApplication;
                this.RootFrame.UriMapper = (new GBAUriMapper());
                this.RootFrame.NavigationFailed += this.RootFrame_NavigationFailed;
                this.RootFrame.Navigated += this.CheckForResetNavigation;
                this.RootFrame.Navigating += this.RootFrame_Navigating;
                this.phoneApplicationInitialized = true;
            }
        }

        public static void MergeCustomColors()
        {
            string str;
            ResourceDictionary dictionary = new ResourceDictionary();
            Application.Current.Resources.Remove("CustomForegroundColor");
            Application.Current.Resources.Remove("CustomChromeColor");
            if (metroSettings.ThemeSelection == 0)
            {
                str = string.Format("/CustomTheme/LightTheme.xaml", new object[0]);
                Application.Current.Resources.Add("CustomChromeColor", Color.FromArgb(0xff, 0xdd, 0xdd, 0xdd));
                Application.Current.Resources.Add("CustomForegroundColor", Color.FromArgb(0xde, 0, 0, 0));
            }
            else
            {
                str = string.Format("/CustomTheme/DarkTheme.xaml", new object[0]);
                Application.Current.Resources.Add("CustomChromeColor", Color.FromArgb(0xff, 0x1f, 0x1f, 0x1f));
                Application.Current.Resources.Add("CustomForegroundColor", Color.FromArgb(0xff, 0xff, 0xff, 0xff));
            }
            Color color = Color.FromArgb(0xff, 0x4d, 0x3a, 0x89);
            color = Color.FromArgb(0xff, 0xb6, 30, 0x45);
            Application.Current.Resources.Remove("SystemTrayColor");
            Application.Current.Resources.Add("SystemTrayColor", color);
            SolidColorBrush brush = Application.Current.Resources["HeaderBackgroundBrush"] as SolidColorBrush;
            brush.Color = (color);
            brush.Opacity = (0.7);
            SolidColorBrush brush2 = Application.Current.Resources["HeaderForegroundBrush"] as SolidColorBrush;
            brush2.Color = (Colors.White);
            brush2.Opacity = (1.0);
            SolidColorBrush brush3 = Application.Current.Resources["ListboxBackgroundBrush"] as SolidColorBrush;
            brush3.Color = (color);
            brush3.Opacity = (0.05);
            ResourceDictionary dictionary4 = new ResourceDictionary();
            dictionary4.Source = (new Uri(str, UriKind.Relative));
            ResourceDictionary dictionary2 = dictionary4;
            dictionary.MergedDictionaries.Add(dictionary2);
            ResourceDictionary dictionary3 = Application.Current.Resources;
            foreach (DictionaryEntry entry in dictionary.MergedDictionaries[0])
            {
                SolidColorBrush brush4 = entry.Value as SolidColorBrush;
                SolidColorBrush brush5 = dictionary3[entry.Key] as SolidColorBrush;
                if ((brush5 != null) && (brush4 != null))
                {
                    brush5.Color = (brush4.Color);
                }
            }
        }

        public void RemoveCurrentDeactivationSettings()
        {
            if (metroSettings.Contains("LastFilePlayed"))
            {
                metroSettings.RemoveValue("LastFilePlayed");
            }
            if (metroSettings.Contains("LastRomPlayed"))
            {
                metroSettings.RemoveValue("LastRomPlayed");
            }
            metroSettings.Save();
        }

        private void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == (NavigationMode)4)
            {
                this.wasRelaunched = true;
            }
            else if ((e.NavigationMode == null) && this.wasRelaunched)
            {
                this.wasRelaunched = false;
                this.mustClearPagestack = true;
                if (e.Uri.ToString().Contains("rom=") || e.Uri.ToString().Contains("RomName="))
                {
                    if (this.CheckLastRomPlayed(HttpUtility.UrlDecode(e.Uri.ToString())))
                    {
                        this.mustClearPagestack = false;
                    }
                    else
                    {
                        this.mustClearPagestack = true;
                    }
                }
                else if (e.Uri.ToString().Contains("/MainPage.xaml"))
                {
                    this.mustClearPagestack = false;
                }
                if (!this.mustClearPagestack)
                {
                    e.Cancel = true;
                    this.RootFrame.Navigated -=this.ClearBackStackAfterReset;
                }
            }
        }

        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        public void SaveCurrentDeactivationSettings()
        {
            if (this.RootFrame.CurrentSource.ToString().Contains("EmulatorPage.xaml"))
            {
                if (metroSettings.AddOrUpdateValue("LastFilePlayed", EmulatorPage.currentROMEntry.FileName) && metroSettings.AddOrUpdateValue("LastRomPlayed", EmulatorPage.currentROMEntry.DisplayName))
                {
                    metroSettings.Save();
                }
            }
            else if (metroSettings.AddOrUpdateValue("LastFilePlayed", "no_rom_is_being_played") && metroSettings.AddOrUpdateValue("LastRomPlayed", "no_rom_is_being_played"))
            {
                metroSettings.Save();
            }
        }

        public static bool HasAds
        {
get { return false; }
        }

        public static bool IsPremium
        {
            get { return true; }
        }

        public static bool IsTrial
        {
            get { return false; }
        }

        public PhoneApplicationFrame RootFrame { get; private set; }
    }
}

