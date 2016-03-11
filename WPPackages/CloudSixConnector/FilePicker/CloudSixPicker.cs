namespace CloudSixConnector.FilePicker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Xml.Linq;
    using Windows.System;

    public class CloudSixPicker
    {
        public CloudSixPicker(string appcustomextension)
        {
            this.AppCustomExtension = appcustomextension;
            this.FileExtensions = new List<CloudSixFileExtension>();
            try
            {
                XElement element = XElement.Load(Application.GetResourceStream(new Uri("WMAppManifest.xml", UriKind.Relative)).Stream);
                this.AppName = element.Element("App").Attribute("Title").Value;
            }
            catch
            {
                this.AppName = "";
            }
        }

        public static CloudSixFileSelected GetAnswer(string fileId)
        {
            return new CloudSixFileSelected(fileId);
        }

        public void Show()
        {
            string str = "";
            if (this.FileExtensions.Count > 0)
            {
                str = (from f in this.FileExtensions
                       where f != null
                       select f).Select<CloudSixFileExtension, string>(delegate(CloudSixFileExtension f)
                {
                    //string str = string.Empty;
                    if (string.IsNullOrEmpty(f.Extension))
                    {
                        str = "*";
                    }
                    else
                    {
                        str = HttpUtility.UrlEncode(f.Extension);
                    }
                    if (f.MaxFileSizeInKb > 0)
                    {
                        return (str + "|" + f.MaxFileSizeInKb);
                    }
                    return str;
                }).Aggregate<string>((a, b) => a + ";" + b);
            }
            object[] args = new object[] { HttpUtility.UrlEncode(this.AppName ?? ""), HttpUtility.UrlEncode(this.Caption ?? ""), HttpUtility.UrlEncode(this.Token ?? ""), HttpUtility.UrlEncode(this.AppCustomExtension ?? ""), str };
            Launcher.LaunchUriAsync(new Uri(string.Format("cloudsix:FilePicker?appname={0}&caption={1}&token={2}&myextension={3}&fileext={4}", args), UriKind.Absolute));
        }

        public string AppCustomExtension { get; private set; }

        public string AppName { get; set; }

        public string Caption { get; set; }

        public List<CloudSixFileExtension> FileExtensions { get; private set; }

        public string Token { get; set; }
    }
}

