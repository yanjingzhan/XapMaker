using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            string a1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"IAD_apktool2015.10.22_XD107\data_decode\a1.bat");
            string test = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"IAD_apktool2015.10.22_XD107\data_decode\test.bat");

            System.IO.Directory.SetCurrentDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"IAD_apktool2015.10.22_XD107\data_decode"));
            Process proc = Process.Start(a1);

            proc.WaitForExit();
            MessageBox.Show("Done");
        }
    }
}
