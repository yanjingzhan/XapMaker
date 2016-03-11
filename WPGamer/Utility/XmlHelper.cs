using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WPGamer.Models;

namespace WPGamer.Utility
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
            StreamReader sr = new StreamReader(Stream, Encoding.UTF8);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        public static string XmlSerialize(GameConfigInfos t)
        {
            //XmlDocument doc = new XmlDocument();
            //XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);

            //doc.AppendChild(dec);
            //XmlElement root = doc.CreateElement("GameConfigInfos");
            //doc.AppendChild(root);

            //root.SetAttribute("PubcenterApplicationID", t.PubcenterApplicationID);
            //root.SetAttribute("PubcenterAdUnitIDs", t.PubcenterAdUnitIDs);
            //root.SetAttribute("GoogleAdUnitID", t.GoogleAdUnitID);
            //root.SetAttribute("GoogleFullScreenAdID", t.GoogleFullScreenAdID);
            //root.SetAttribute("SurfaceAdPosition", t.SurfaceAdPosition);
            //root.SetAttribute("SurfaceAdToken", t.SurfaceAdToken);
            //root.SetAttribute("SmaatoAdID", t.SmaatoAdID);
            //root.SetAttribute("SmaatoPublisherID", t.SmaatoPublisherID);
            //root.SetAttribute("IsEnableSmaatoAdDebug", t.IsEnableSmaatoAdDebug);
            //root.SetAttribute("GameName", t.GameName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sb.AppendLine("<GameConfigInfos");
            sb.AppendLine(string.Format("PubcenterApplicationID = \"{0}\"",t.PubcenterApplicationID));
            sb.AppendLine(string.Format("PubcenterAdUnitIDs = \"{0}\"",t.PubcenterAdUnitIDs));
            sb.AppendLine(string.Format("GoogleAdUnitID = \"{0}\"", t.GoogleAdUnitID));
            sb.AppendLine(string.Format("GoogleFullScreenAdID = \"{0}\"", t.GoogleFullScreenAdID));
            sb.AppendLine(string.Format("SurfaceAdPosition = \"{0}\"", t.SurfaceAdPosition));
            sb.AppendLine(string.Format("SurfaceAdToken = \"{0}\"", t.SurfaceAdToken));
            sb.AppendLine(string.Format("SmaatoAdID = \"{0}\"", t.SmaatoAdID));
            sb.AppendLine(string.Format("SmaatoPublisherID = \"{0}\"", t.SmaatoPublisherID));
            sb.AppendLine(string.Format("IsEnableSmaatoAdDebug = \"{0}\"", t.IsEnableSmaatoAdDebug));
            sb.AppendLine(string.Format("GameName = \"{0}\">", t.GameName));
            sb.AppendLine(string.Format("</GameConfigInfos>"));

            return sb.ToString();
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
