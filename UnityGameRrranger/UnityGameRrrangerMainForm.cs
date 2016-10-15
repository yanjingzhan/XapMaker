using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityGameRrranger.Utility;

namespace UnityGameRrranger
{
    public partial class UnityGameRrrangerMainForm : Form
    {
        private int _currentSucCount;

        public int CurrentSucCount
        {
            get { return _currentSucCount; }
            set
            {
                _currentSucCount = value;
                this.label_SucCount.Text = _currentSucCount.ToString();
            }
        }

        private int _currentFailCount;

        public int CurrentFailCount
        {
            get { return _currentFailCount; }
            set
            {
                _currentFailCount = value;
                this.label_FailCount.Text = _currentFailCount.ToString();
            }
        }

        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + "," + this.label_CurrentGameName.Text + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }

        public UnityGameRrrangerMainForm()
        {
            InitializeComponent();

            this.Load += UnityGameRrrangerMainForm_Load;
        }

        void UnityGameRrrangerMainForm_Load(object sender, EventArgs e)
        {
            this.textBox_OldPackagePath.Text = INIHelper.ReadIniData("UnityGameRrranger", "OldPackagePath", "", AppDomain.CurrentDomain.BaseDirectory + "conf.ini");
            this.textBox_NewPackagePath.Text = INIHelper.ReadIniData("UnityGameRrranger", "NewPackagePath", "", AppDomain.CurrentDomain.BaseDirectory + "conf.ini");
        }

        private void button_SelectOldPackagePath_Click(object sender, EventArgs e)
        {
            FolderDialog fd = new FolderDialog();

            if (fd.DisplayDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_OldPackagePath.Text = fd.Path;
                INIHelper.WriteIniData("UnityGameRrranger", "OldPackagePath", this.textBox_OldPackagePath.Text, AppDomain.CurrentDomain.BaseDirectory + "conf.ini");
            }
        }

        private void button_SelectNewPackagePath_Click(object sender, EventArgs e)
        {
            FolderDialog fd = new FolderDialog();

            if (fd.DisplayDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_NewPackagePath.Text = fd.Path;
                INIHelper.WriteIniData("UnityGameRrranger", "NewPackagePath", this.textBox_NewPackagePath.Text, AppDomain.CurrentDomain.BaseDirectory + "conf.ini");
            }
        }

        private async void button_Start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBox_OldPackagePath.Text)
                || string.IsNullOrWhiteSpace(this.textBox_NewPackagePath.Text))
            {
                MessageBox.Show("请将信息填写完整");
            }

            INIHelper.WriteIniData("UnityGameRrranger", "OldPackagePath", this.textBox_OldPackagePath.Text, AppDomain.CurrentDomain.BaseDirectory + "conf.ini");
            INIHelper.WriteIniData("UnityGameRrranger", "NewPackagePath", this.textBox_NewPackagePath.Text, AppDomain.CurrentDomain.BaseDirectory + "conf.ini");

            foreach (var xapFile in Directory.GetFiles(this.textBox_OldPackagePath.Text, "*.xap"))
            {
                try
                {
                    label_CurrentGameName.Text = Path.GetFileName(xapFile);

                    SetInfo("解压.");
                    await UnZip(xapFile);

                    SetInfo("复制模板");
                    await XCopy(xapFile);

                    CurrentSucCount = CurrentSucCount + 1;
                }
                catch (Exception ex)
                {
                    CurrentFailCount = CurrentFailCount + 1;
                    SetInfo("失败," + ex.Message);
                }
            }

            MessageBox.Show("执行完毕");
        }

        //解压
        private async Task UnZip(string gameFilePath)
        {
            string targetDir = Path.Combine(this.textBox_NewPackagePath.Text, Path.GetFileNameWithoutExtension(gameFilePath), "游戏包");

            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            await Task.Run(() => ZipHelper.ExtractZipFile(gameFilePath, string.Empty, targetDir));
        }

        //复制
        private async Task XCopy(string gameFilePath)
        {
            string targetDir = Path.Combine(this.textBox_NewPackagePath.Text, Path.GetFileNameWithoutExtension(gameFilePath), "Unity模板");

            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            string mobanPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Unity模板");

            string cmd2 = string.Format("/e /y {0} {1}", mobanPath, targetDir.TrimEnd('\\') + "\\");
            //Process.Start("xcopy", cmd2).WaitForExit();
            Process p2 = new Process();
            p2.StartInfo.FileName = "xcopy";
            p2.StartInfo.Arguments = cmd2;
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p2.Start();
            await Task.Run(() => p2.WaitForExit());
        }
    }
}
