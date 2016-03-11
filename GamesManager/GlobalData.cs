using GamesManager.Model;
using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GamesManager
{
    public static class GlobalData
    {
        public static PusherUserModel GlobalPusherUser;

        /// <summary>
        /// 配置文件位置
        /// </summary>
        public static string ConfigIniPath;

        /// <summary>
        /// 安卓打包工程位置
        /// </summary>
        public static string AndroidCopyOutPath;

        /// <summary>
        /// 可以运行的文件的路径
        /// </summary>
        public static string GoodGamePath;

        /// <summary>
        /// 不可以运行的文件的路径
        /// </summary>
        public static string BadGamePath;

        static GlobalData()
        {
            GlobalPusherUser = new PusherUserModel();
            ConfigIniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\Config.ini");
            AndroidCopyOutPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "打包用的工程");

            //if (!Directory.Exists(AndroidCopyOutPath))
            //{
            //    Directory.CreateDirectory(AndroidCopyOutPath);
            //}

            GoodGamePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                 "可以用的游戏");
            if(!Directory.Exists(GoodGamePath))
            {
                Directory.CreateDirectory(GoodGamePath);
            }
            BadGamePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                 "坏的游戏");
            if (!Directory.Exists(BadGamePath))
            {
                Directory.CreateDirectory(BadGamePath);
            }
        }
    }
}
