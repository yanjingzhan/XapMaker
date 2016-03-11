using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XapMaker.Utility;

namespace XapMaker
{
    public partial class XapMaker : Form
    {
        private string _pngFile = string.Empty;

        private bool _hasSelectedType = false;
        private string _tragetMainPath = string.Empty;
        public XapMaker()
        {
            InitializeComponent();
        }

        private void pictureBox_Logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Png|*.png";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _pngFile = ofd.FileName;
                pictureBox_Logo.ImageLocation = _pngFile;
            }
        }

        private void XapMaker_DragDrop(object sender, DragEventArgs e)
        {
            string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (var s in ss)
            {
                if(Path.GetExtension(s).ToLower() == ".png")
                {
                    _pngFile = s.Trim();
                    pictureBox_Logo.ImageLocation = s.Trim();
                }
            }
        }

        private void XapMaker_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
