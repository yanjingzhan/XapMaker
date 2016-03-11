using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GameInfoAdder.Utility
{
    public class Logger
    {
        public static void Loglog(string msg)
        {
            string logFile = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"log\{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "log"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "log");
            }

            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine(DateTime.Now.ToString() + ":" + msg);
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
