using GamesManager.AndroidHandlers;
using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GamesManager.AndroidForm
{
    public partial class TestIsGoodForm : Form
    {
        private string _filePath;
        private string _unityVersion;

        delegate void SetTextValue(string text);

        public TestIsGoodForm()
        {
            InitializeComponent();
        }

        private void TestIsGoodForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void TestIsGoodForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (Path.GetExtension(ss[0]).ToLower() == ".apk")
                {
                    _filePath = ss[0];
                    string fileName = Path.GetFileName(ss[0]);

                    this.label_FileName.Text = fileName;
                    this.label_FileSize.Text = (new FileInfo(ss[0]).Length / 1024.0d / 1024.0d).ToString("0.00") + "M";
                    this.label_UnityVersion.Text = ZipHelper.GetUnityVersionShitFuck(ss[0]);

                    _unityVersion = this.label_UnityVersion.Text.Substring(0, 3);

                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowInfo(string msg)
        {
            ((MainForm)this.MdiParent).ShowStatus(msg);
        }

        public void ShowMessageBox(string msg)
        {
            MessageBox.Show(msg);
        }


        private void button_CreateObj_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(DoWorkFunc);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void DoWorkFunc()
        {
            try
            {
                BasePlayerHandler bp = PlayerHandlerCreater.GetHandler("test");

                this.Invoke(new SetTextValue(ShowInfo), "开始创建……");
                bp.Init(_unityVersion);

                Thread.Sleep(100);
                this.Invoke(new SetTextValue(ShowInfo), "解包……");
                bp.UnPackage(_filePath);

                Thread.Sleep(100);

                this.Invoke(new SetTextValue(ShowInfo), "原工程复制……");
                bp.CopyInAssets();
                bp.CopyInLibs();

                Thread.Sleep(100);

                this.Invoke(new SetTextValue(ShowInfo), "完成……");

                #region rest

                //BasePlayerHandler bp = PlayerHandlerCreater.GetHandler("baidu");

                //this.Invoke(new SetTextValue(ShowInfo), "开始创建……");
                //bp.Init(_unityVersion);

                //Thread.Sleep(100);
                //this.Invoke(new SetTextValue(ShowInfo), "解包……");
                //bp.UnPackage(_filePath);

                //Thread.Sleep(100);

                //this.Invoke(new SetTextValue(ShowInfo), "原工程复制……");
                //bp.CopyInAssets();
                //bp.CopyInLibs();
                //bp.DeleteGen();
                //bp.ReplaceAdKey1("jiba");
                //bp.ReplaceAdKey2("jiba");
                //bp.ReplacePackageName("com.jiba.jiba2");
                //bp.ReplaceImportPackageName("com.jiba.jiba2");
                //bp.DoReplace();

                //Thread.Sleep(100);

                //this.Invoke(new SetTextValue(ShowInfo), "完成……");
                #endregion
            }
            catch (Exception ex)
            {
                this.Invoke(new SetTextValue(ShowInfo), ex.Message);
                this.Invoke(new SetTextValue(ShowMessageBox), ex.Message);
            }
        }

        private void button_Good_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                ShowInfo("请添加新的游戏");
                return;
            }

            string targetDir = Path.Combine(GlobalData.GoodGamePath, _unityVersion);

            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            string targetFile = Path.Combine(targetDir, new FileInfo(_filePath).Name);
            File.Move(_filePath, targetFile);

            ShowInfo("这个游戏已经移动到“可以用的游戏”目录下。。。请测试下一个游戏");

            _filePath = string.Empty;
        }

        private void button_NotGood_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                ShowInfo("请添加新的游戏");
                return;
            }

            string targetDir = Path.Combine(GlobalData.BadGamePath, _unityVersion);

            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            string targetFile = Path.Combine(targetDir, new FileInfo(_filePath).Name);
            File.Move(_filePath, targetFile);

            ShowInfo("这个游戏已经移动到“坏的游戏”目录下。。。请测试下一个游戏");

            _filePath = string.Empty;

        }

    }
}
