using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesManager.Model
{
    public class AppInfoTempModel
    {
        public string ID;
        public string AppName;
        public string DetailAddress;
        public string DownloadAddress;
        public string AppType;
        public string Rate;
        /// <summary>
        /// 待绑定
        /// 已绑定
        /// </summary>
        public string State;

        public string Time;
    }
}
