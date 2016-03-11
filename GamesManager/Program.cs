using GamesManager.AndroidLiuMangForm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace GamesManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (ConfigurationManager.AppSettings["UserType"].ToString() == "Manager")
            {
                Application.Run(new LiuMangGamesManager());
            }
            else
            {
                Application.Run(new GetLiuLangAdsForm());
            }

            //Application.Run(new LoginForm());
            //Application.Run(new MainForm());
        }
    }
}
