using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using Microsoft.Phone.Controls;


namespace PhoneDirect3DXamlAppInterop
{
    public class GameService : INotifyPropertyChanged
    {
        private IsolatedStorageSettings appSetting;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static bool IsShowFullAd;

        private static GameService instance;
        public static GameService Instance
        {
            get
            {
                if (GameService.instance == null)
                {
                    GameService.instance = new GameService();
                }
                return GameService.instance;
            }
        }

        public bool IsRateGame
        {
            get { return (bool)this.appSetting["IsRateGame"]; }
            set
            {
                this.appSetting["IsRateGame"] = value;
                appSetting.Save();
                this.RaisePropertyChanged("IsRateGame");
            }
        }

        public GameService()
        {
            this.appSetting = IsolatedStorageSettings.ApplicationSettings;

            if (!this.appSetting.Contains("IsRateGame"))
            {
                this.appSetting.Add("IsRateGame", false);
            }
        }
    }
}
