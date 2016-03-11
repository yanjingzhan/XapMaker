using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamSparker.Utility
{
    public class RandomHelper
    {
        private static Random _rd = new Random();

        public static string PasswordCreator(int minLength, int maxLength)
        {
            string pwd = string.Empty;

            int length = _rd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; i++)
            {
                pwd += ((char)_rd.Next(65, 90)).ToString().ToLower();
                pwd += (_rd.Next(0, 9)).ToString();

            }
            return pwd;
        }

        public static string CreatorZiMu(int minLength, int maxLength)
        {
            string pwd = string.Empty;

            int length = _rd.Next(minLength, maxLength + 1);
            for (int i = 0; i < length; i++)
            {
                pwd += ((char)_rd.Next(65, 90)).ToString().ToLower();

            }
            return pwd;
        }

        public static string CreatorMonth()
        {
            string[] months = new string[]{"January","February","March","April","May",
                "June","July","August","September","October","November","December"};

            return months[_rd.Next(0, 13)];
        }

        public static string CreatorMonth(int index)
        {
            string[] months = new string[]{"January","February","March","April","May",
                "June","July","August","September","October","November","December"};

            return months[index-1];
        }
    }
}
