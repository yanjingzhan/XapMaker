namespace PhoneDirect3DXamlAppInterop
{
    using System;
    using System.ComponentModel;
    using System.IO.IsolatedStorage;
    using System.Threading;

    public class AppSettings : INotifyPropertyChanged
    {
        private const string AutoBackupIndexKey = "AutoBackupIndexKey";
        private const string AutoBackupKey = "AutoBackupKey";
        private const string AutoBackupModeKey = "AutoBackupModeKey";
        private const string BackgroundOpacityKey = "BackgroundOpacityKey";
        private const string BackgroundUriKey = "BackgroundUriKey";
        private const string BackupAutoSaveKey = "BackupAutoSaveKey";
        private const string BackupIngameSaveKey = "BackupIngameSaveKey";
        private const string BackupManualSaveKey = "BackupManualSaveKey";
        private const string BackupOnlyWifiKey = "BackupOnlyWifiKey";
        private const string CanAskReviewKey = "CanAskReviewKey";
        private const string FirstTurboPromptKey = "FirstTurboPromptKey";
        private IsolatedStorageSettings isolatedStore;
        private const string LastIPAddressKey = "LastIPAddressKey";
        private const string LastTimeoutKey = "LastTimeoutKey";
        private const string LoadLastStateKey = "LoadLastStateKey";
        private const string NAppLaunchKey = "NAppLaunchKey";
        private const string NRotatingBackupKey = "NRotatingBackupKey";
        private const string PromotionCodeKey = "PromotionCodeKey";
        private const string ShowLastPlayedGameKey = "ShowLastPlayedGameKey";
        private const string ShowThreeDotsKey = "ShowThreeDotsKey";
        private const string ThemeSelectionKey = "ThemeSelectionKey";
        private const string UseAccentColorKey = "UseAccentColorKey";
        private const string UseDefaultBackgroundKey = "UseDefaultBackgroundKey";
        private const string VoiceCommandVersionKey = "VoiceCommandVersionKey";
        private const string WhenToBackupKey = "WhenToBackupKey";

        public event PropertyChangedEventHandler PropertyChanged;

        public AppSettings()
        {
            try
            {
                this.isolatedStore = IsolatedStorageSettings.ApplicationSettings;
            }
            catch (Exception)
            {
            }
        }

        public bool AddOrUpdateValue(string Key, object value)
        {
            bool flag = false;
            if (this.isolatedStore.Contains(Key))
            {
                if (this.isolatedStore[Key] != value)
                {
                    this.isolatedStore[Key] = value;
                    flag = true;
                }
                return flag;
            }
            this.isolatedStore.Add(Key, value);
            return true;
        }

        public bool Contains(string Key)
        {
            return this.isolatedStore.Contains(Key);
        }

        public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            if (this.isolatedStore.Contains(Key))
            {
                return (valueType) this.isolatedStore[Key];
            }
            return defaultValue;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RemoveValue(string Key)
        {
            if (this.isolatedStore.Contains(Key))
            {
                this.isolatedStore.Remove(Key);
            }
        }

        public void Save()
        {
            this.isolatedStore.Save();
        }

        public bool AutoBackup
        {
            get
            {
                return this.GetValueOrDefault<bool>("AutoBackupKey", false);
            }
            set
            {
                this.AddOrUpdateValue("AutoBackupKey", value);
                this.Save();
            }
        }

        public int AutoBackupMode
        {
            get
            {
                return this.GetValueOrDefault<int>("AutoBackupModeKey", 1);
            }
            set
            {
                this.AddOrUpdateValue("AutoBackupModeKey", value);
                this.Save();
            }
        }

        public double BackgroundOpacity
        {
            get
            {
                return this.GetValueOrDefault<double>("BackgroundOpacityKey", 0.2);
            }
            set
            {
                this.AddOrUpdateValue("BackgroundOpacityKey", value);
                this.Save();
            }
        }

        public string BackgroundUri
        {
            get
            {
                return this.GetValueOrDefault<string>("BackgroundUriKey", FileHandler.DEFAULT_BACKGROUND_IMAGE);
            }
            set
            {
                this.AddOrUpdateValue("BackgroundUriKey", value);
                this.Save();
                this.NotifyPropertyChanged("BackgroundUri");
            }
        }

        public bool BackupAutoSave
        {
            get
            {
                return this.GetValueOrDefault<bool>("BackupAutoSaveKey", true);
            }
            set
            {
                this.AddOrUpdateValue("BackupAutoSaveKey", value);
                this.Save();
            }
        }

        public bool BackupIngameSave
        {
            get
            {
                return this.GetValueOrDefault<bool>("BackupIngameSaveKey", true);
            }
            set
            {
                this.AddOrUpdateValue("BackupIngameSaveKey", value);
                this.Save();
            }
        }

        public bool BackupManualSave
        {
            get
            {
                return this.GetValueOrDefault<bool>("BackupManualSaveKey", true);
            }
            set
            {
                this.AddOrUpdateValue("BackupManualSaveKey", value);
                this.Save();
            }
        }

        public bool BackupOnlyWifi
        {
            get
            {
                return this.GetValueOrDefault<bool>("BackupOnlyWifiKey", false);
            }
            set
            {
                this.AddOrUpdateValue("BackupOnlyWifiKey", value);
                this.Save();
            }
        }

        public bool CanAskReview
        {
            get
            {
                return this.GetValueOrDefault<bool>("CanAskReviewKey", true);
            }
            set
            {
                this.AddOrUpdateValue("CanAskReviewKey", value);
                this.Save();
            }
        }

        public bool FirstTurboPrompt
        {
            get
            {
                return this.GetValueOrDefault<bool>("FirstTurboPromptKey", false);
            }
            set
            {
                this.AddOrUpdateValue("FirstTurboPromptKey", value);
                this.Save();
            }
        }

        public string LastIPAddress
        {
            get
            {
                return this.GetValueOrDefault<string>("LastIPAddressKey", "");
            }
            set
            {
                this.AddOrUpdateValue("LastIPAddressKey", value);
                this.Save();
            }
        }

        public int LastTimeout
        {
            get
            {
                return this.GetValueOrDefault<int>("LastTimeoutKey", 0xbb8);
            }
            set
            {
                this.AddOrUpdateValue("LastTimeoutKey", value);
                this.Save();
            }
        }

        public bool LoadLastState
        {
            get
            {
                return this.GetValueOrDefault<bool>("LoadLastStateKey", false);
            }
            set
            {
                this.AddOrUpdateValue("LoadLastStateKey", value);
                this.Save();
            }
        }

        public int NAppLaunch
        {
            get
            {
                return this.GetValueOrDefault<int>("NAppLaunchKey", 0);
            }
            set
            {
                this.AddOrUpdateValue("NAppLaunchKey", value);
                this.Save();
            }
        }

        public int NRotatingBackup
        {
            get
            {
                return this.GetValueOrDefault<int>("NRotatingBackupKey", 5);
            }
            set
            {
                this.AddOrUpdateValue("NRotatingBackupKey", value);
                this.Save();
            }
        }

        public string PromotionCode
        {
            get
            {
                return this.GetValueOrDefault<string>("PromotionCodeKey", "");
            }
            set
            {
                this.AddOrUpdateValue("PromotionCodeKey", value);
                this.Save();
            }
        }

        public bool ShowLastPlayedGame
        {
            get
            {
                return this.GetValueOrDefault<bool>("ShowLastPlayedGameKey", true);
            }
            set
            {
                this.AddOrUpdateValue("ShowLastPlayedGameKey", value);
                this.Save();
            }
        }

        public bool ShowThreeDots
        {
            get
            {
                return this.GetValueOrDefault<bool>("ShowThreeDotsKey", true);
            }
            set
            {
                this.AddOrUpdateValue("ShowThreeDotsKey", value);
                this.Save();
            }
        }

        public int ThemeSelection
        {
            get
            {
                return this.GetValueOrDefault<int>("ThemeSelectionKey", 0);
            }
            set
            {
                this.AddOrUpdateValue("ThemeSelectionKey", value);
                this.Save();
            }
        }

        public bool UseAccentColor
        {
            get
            {
                return this.GetValueOrDefault<bool>("UseAccentColorKey", true);
            }
            set
            {
                this.AddOrUpdateValue("UseAccentColorKey", value);
                this.Save();
            }
        }

        public bool UseDefaultBackground
        {
            get
            {
                return this.GetValueOrDefault<bool>("UseDefaultBackgroundKey", true);
            }
            set
            {
                this.AddOrUpdateValue("UseDefaultBackgroundKey", value);
                this.Save();
            }
        }

        public int VoiceCommandVersion
        {
            get
            {
                return this.GetValueOrDefault<int>("VoiceCommandVersionKey", 0);
            }
            set
            {
                this.AddOrUpdateValue("VoiceCommandVersionKey", value);
                this.Save();
            }
        }

        public int WhenToBackup
        {
            get
            {
                return this.GetValueOrDefault<int>("WhenToBackupKey", 0);
            }
            set
            {
                this.AddOrUpdateValue("WhenToBackupKey", value);
                this.Save();
            }
        }
    }
}

