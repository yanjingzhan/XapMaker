namespace PhoneDirect3DXamlAppInterop
{
    using Microsoft.Phone.Controls;
    using System;
    using System.Windows;

    public static class WebBrowserHelper
    {
        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached("Html", typeof(string), typeof(WebBrowserHelper), new PropertyMetadata(new PropertyChangedCallback(OnHtmlChanged)));

        public static string GetHtml(DependencyObject dependencyObject)
        {
            return (string) dependencyObject.GetValue(HtmlProperty);
        }

        private static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser browser = d as WebBrowser;
            if (browser != null)
            {
                string str = e.NewValue.ToString();
                browser.NavigateToString(str);
            }
        }

        public static void SetHtml(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(HtmlProperty, value);
        }
    }
}

