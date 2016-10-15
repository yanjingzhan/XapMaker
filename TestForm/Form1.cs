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
            System.Drawing.Image image1 = System.Drawing.Image.FromFile(@"D:\work\windowsphone\Unity游戏\Patakong\WP8_EN\Store\images\1\wp_ss_20150617_0006.png");
                       
            // Save the image in PNG format.
            image1.Save(@"d:\test.png", System.Drawing.Imaging.ImageFormat.Png);  
            
            // Save the image in JPEG format.
            image1.Save(@"d:\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

            // Save the image in GIF format.
            image1.Save(@"d:\test.gif", System.Drawing.Imaging.ImageFormat.Gif);
     
        }
    }
}
