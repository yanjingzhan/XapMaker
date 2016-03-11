using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PEGIGetter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.webBrowser_Main.Navigated += webBrowser_Main_Navigated;
        }

        void webBrowser_Main_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.textBox_CurrentUrl.Text = e.Url.ToString();    
        }

        private void button_WebBrowserGo_Click(object sender, EventArgs e)
        {
            webBrowser_Main.Navigate(this.textBox_TargetUrl.Text);
        }
    }
}
