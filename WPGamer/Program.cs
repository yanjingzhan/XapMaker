using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace WPGamer
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
                Application.Run(new WpGameManager());
            }
            else if (ConfigurationManager.AppSettings["UserType"].ToString() == "User")
            {
                Application.Run(new ScreenShotter());
            }
            else if (ConfigurationManager.AppSettings["UserType"].ToString() == "Packager")
            {
                Application.Run(new PackageBuilder());
            }
            else if (ConfigurationManager.AppSettings["UserType"].ToString() == "ScreenShotter")
            {
                Application.Run(new ScreenShotter());
            }
            else
            {
                Application.Run(new UnityPackageBuilder());
            }
            //Application.Run(new ScreenShotter());

            //Application.Run(new WpGameManager());
        }
    }
}
