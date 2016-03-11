using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GameInfoAdder.Utility
{
    public class HtmlHelper
    {
        public static string GetGameDetails(string gameName)
        {
            try
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(string.Format("http://www.gamefaqs.com/search/index.html?game={0}", gameName));

                HtmlAgilityPack.HtmlNodeCollection htmlnodeCollection = doc.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[2]/div/div[1]/div[2]/table/tr/td[2]");
                //HtmlAgilityPack.HtmlNodeCollection htmlnodeCollection = doc.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[2]/div/div[1]/div[2]/table/tbody/tr/td[2]");

                if (htmlnodeCollection.Count == 0)
                {
                    htmlnodeCollection = doc.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[2]/div/div[1]/div[2]/table/tr[1]/td[2]");

                }

                if (htmlnodeCollection.Count > 0)
                {
                    string fullUrl = string.Empty;

                    WebClient wc = new WebClient();
                    foreach (var h in htmlnodeCollection)
                    {
                        string urls = h.SelectSingleNode("child::a").GetAttributeValue("href", "null");
                        if (!string.IsNullOrEmpty(urls))
                        {
                            fullUrl = "http://www.gamefaqs.com" + urls;
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(fullUrl))
                    {
                        HtmlAgilityPack.HtmlWeb web2 = new HtmlAgilityPack.HtmlWeb();
                        HtmlAgilityPack.HtmlDocument doc2 = web2.Load(string.Format(fullUrl));

                        HtmlNode htmlNode = doc2.DocumentNode.SelectSingleNode("//div[@class='desc']");

                        return htmlNode.InnerText;
                    }
                }

                return "";
            }
            catch { return ""; }
        }

    }
}
