using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneDirect3DXamlAppInterop
{
    public partial class ImageLoad : UserControl
    {
        private WebBrowser _webBrowser = new WebBrowser();

        public DependencyProperty NormalImageProperty = DependencyProperty.Register("NormalImage", typeof(string), typeof(ImageLoad), new PropertyMetadata(new PropertyChangedCallback(ImageLoad.Callback)));

        public ImageLoad()
        {
            this.InitializeComponent();

        }


        private static void Callback(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
        {
            ImageLoad item = dependencyObject_0 as ImageLoad;
            try
            {
                item.img.Source = null;
                item.GetImage(dependencyPropertyChangedEventArgs_0.NewValue.ToString());
            }
            catch
            {
            }
        }

        private void GetImage(string string_0)
        {
            try
            {
                if (string.IsNullOrEmpty(string_0))
                {
                    this.img.Source = null;
                    return;
                }
                HttpWebRequest state = (HttpWebRequest)WebRequest.Create(new Uri(string_0));
                state.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.46 Safari/536.5";
                state.Method = "GET";
                state.AllowAutoRedirect = true;
                state.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                state.BeginGetResponse(new AsyncCallback(this.WebResponseCallback), state);
            }
            catch (Exception)
            {

            }
        }

        private void WebResponseCallback(IAsyncResult result)
        {
            try
            {
                HttpWebRequest asyncState = (HttpWebRequest)result.AsyncState;
                StreamReader streamReader_0 = new StreamReader(asyncState.EndGetResponse(result).GetResponseStream());
                base.Dispatcher.BeginInvoke(delegate
                {
                    try
                    {

                        BitmapImage image = new BitmapImage();
                        image.SetSource(streamReader_0.BaseStream);
                        this.img.Source = image;
                    }
                    catch
                    {
                    }
                });
                asyncState.Abort();
            }
            catch
            {
            }
        }

        // Properties
        public string NormalImage
        {
            get
            {
                return (string)base.GetValue(this.NormalImageProperty);
            }
            set
            {
                base.SetValue(this.NormalImageProperty, value);
            }
        }

        public void ClearMemory()
        {
            try
            {
                GC.Collect();
                BitmapImage bitmapImage = img.Source as BitmapImage;
                if (bitmapImage != null)
                {
                    bitmapImage.UriSource = null;
                }
                img.Source = null;

                GC.Collect();
            }
            catch (Exception)
            {

            }
        }


        public void InitImageSource(string imageUrl)
        {
            try
            {
                _webBrowser.IsScriptEnabled = true;
                _webBrowser.LoadCompleted += new LoadCompletedEventHandler(webBrowser_LoadCompleted);
                _webBrowser.NavigationFailed += new NavigationFailedEventHandler(_webBrowser_NavigationFailed);
                string rawHtml = "";
                rawHtml += "<html><head><script type=\"text/javascript\">function getUrl(){var temp = document.getElementById(\"image1\"); return temp.src;}</script></head> <body width=215 bgcolor=\"#ffffff\"><p>";
                rawHtml += "<font color=\"#FFFFFF\">";
                rawHtml += "<img id=\"image1\" src='" + imageUrl + "'/>";
                rawHtml += "</p></font></body></html>";
                _webBrowser.NavigateToString(rawHtml);
            }
            catch (Exception)
            {


            }
        }

        void _webBrowser_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {

        }

        void webBrowser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {

                _webBrowser.Source = null;
                var ee = e.Content;
                var src = _webBrowser.InvokeScript("getUrl") as string;
                img.Source = new BitmapImage(new Uri(src, UriKind.Absolute));
                _webBrowser.Visibility = Visibility.Collapsed;
                _webBrowser.LoadCompleted -= new LoadCompletedEventHandler(webBrowser_LoadCompleted);
                GC.Collect();
            }
            catch (Exception)
            {


            }
        }
    }
}
