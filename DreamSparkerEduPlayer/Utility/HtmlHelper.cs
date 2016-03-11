using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamSparkerEduPlayer.Utility
{
    public class HtmlHelper
    {
        public static List<string> GetUserDelId(string url)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            HtmlAgilityPack.HtmlNodeCollection clooection = doc.DocumentNode.SelectNodes("//td[@class=\"wd5\"]");

            List<string> result = new List<string>();
            if (clooection.Count > 0)
            {
                foreach (var c in clooection)
                {
                    if (c.ChildNodes.Count > 1)
                    {
                        string s = c.ChildNodes[1].Attributes["onclick"].ToString();
                    }
                }
            }

            return result;
        }
    }
}
