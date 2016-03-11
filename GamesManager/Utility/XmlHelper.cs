using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GamesManager.Utility
{
    public class XmlHelper
    {
        public static void WriteAdInfo(string xmlPath, string name, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlElement rootElem = doc.DocumentElement;

            XmlNode node = doc.CreateElement("Status");

            XmlAttribute name_t = doc.CreateAttribute("Name");
            name_t.Value = name;

            XmlAttribute value_t = doc.CreateAttribute("Value");
            value_t.Value = value;

            node.Attributes.Append(name_t);
            node.Attributes.Append(value_t);

            rootElem.AppendChild(node);

            doc.Save(xmlPath);
        }

        public static void SetGameName(string xmlPath, string gameName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlElement rootElem = doc.DocumentElement;
            XmlElement appElem = rootElem.GetElementsByTagName("App")[0] as XmlElement;
            appElem.SetAttribute("Title", gameName);

            XmlElement tokensElem = rootElem.GetElementsByTagName("Tokens")[0] as XmlElement;
            XmlElement titleElem = tokensElem.SelectSingleNode("PrimaryToken/TemplateFlip/Title") as XmlElement;

            titleElem.InnerText = gameName;

            doc.Save(xmlPath);
        }

        public static void SetProductID(string xmlPath, string id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlElement rootElem = doc.DocumentElement;
            XmlElement appElem = rootElem.GetElementsByTagName("App")[0] as XmlElement;
            appElem.SetAttribute("ProductID", id);

            doc.Save(xmlPath);
        }

        public static string XmlSerialize<T>(T t)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(typeof(T));

            xml.Serialize(Stream, t);
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;  
        }

        public static string GetIconPath(string xmlPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            XmlElement rootElem = doc.DocumentElement;
            XmlElement appElem = rootElem.GetElementsByTagName("application")[0] as XmlElement;
            return appElem.GetAttribute("android:icon");
        }

    }
}
