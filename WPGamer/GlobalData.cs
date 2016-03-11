using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WPGamer.Utility;

namespace WPGamer
{
    public static class GlobalData
    {
        public static string PusherName;

        static GlobalData()
        {
            PusherName = INIHelper.ReadIniData("user","pusher","",Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini"));
        }
    }
}
