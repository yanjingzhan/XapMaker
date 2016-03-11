using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityScreenShoter.Models;
using UnityScreenShoter.Utility;

namespace UnityScreenShoter
{
    public partial class MainForm : Form
    {
        PushGameInfoModel _pushGameInfo;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;

            //MessageBox.Show(Path.GetDirectoryName(@"E:\Work\Android\Decompile\Apktool\apktool.bat"));
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            SetStartButtonEnable();

            SetTipsInfo("请点击 获取新游戏打包 按钮");
        }

        private void SetStartButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = true;
            this.button_DisableIt.Enabled = false;
            this.button_OpenPackageDir.Enabled = false;
            this.button_OpenScreenShotDir.Enabled = false;
            this.button_SubmitGameInfo.Enabled = false;

            this.textBox_ScreenShotDir.Clear();
            this.textBox_PackageDir.Clear();
        }

        private void SetDevelopingButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = false;
            this.button_DisableIt.Enabled = true;
            this.button_OpenPackageDir.Enabled = true;
            this.button_OpenScreenShotDir.Enabled = true;
            this.button_SubmitGameInfo.Enabled = true;
        }

        private void SetTipsInfo(string info)
        {
            this.label_Tips.Text = info;
        }

        private void SetStatusInfo(string info)
        {
            this.toolStripStatusLabel_Status.Text = DateTime.Now.ToString() + "----" + info;
        }

        private void button_Shot_GetNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                SetStatusInfo("正在执行……");

                string gameFile = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "unity", "*.xap")[0];
                string packageDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"packages\unity", Path.GetFileNameWithoutExtension(gameFile));

                string configFile = Path.Combine(packageDir, @"Assets\GameConfigInfo.xml");

                if (Directory.Exists(packageDir))
                {
                    Directory.Delete(packageDir,true);
                }

                Directory.CreateDirectory(packageDir);

                ZipHelper.ExtractZipFile(gameFile, "", packageDir);

                GameConfigInfos gc = new GameConfigInfos
                {
                    GameName = Path.GetFileNameWithoutExtension(gameFile),
                    GoogleAdUnitID = "",
                    GoogleFullScreenAdID = "",
                    PubcenterAdUnitIDs = "",
                    PubcenterApplicationID = "",
                    SurfaceAdToken = "",
                    SurfaceAdPosition = "",
                    IsEnableSmaatoAdDebug = "0",
                    SmaatoAdID = "0",
                    SmaatoPublisherID = "0"
                };

                string gameInfoEncode = CryptHelper.Encrypt(XmlHelper.XmlSerialize<GameConfigInfos>(gc));

                using (StreamWriter sw = new StreamWriter(configFile, false))
                {
                    sw.WriteLine(gameInfoEncode);

                    sw.Close();
                    sw.Dispose();
                }

                string screenShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"unity\",Path.GetFileNameWithoutExtension(gameFile));
                if (Directory.Exists(screenShotPath))
                {
                    Directory.Delete(screenShotPath, true);
                }

                Directory.CreateDirectory(screenShotPath);

                File.Move(gameFile, Path.Combine(screenShotPath, Path.GetFileName(gameFile)));

                this.textBox_ScreenShotDir.Text = screenShotPath;

                string wmXmlPath = Path.Combine(packageDir, @"WMAppManifest.xml");
                XmlHelper.SetGameName(wmXmlPath, "0.0需要截屏");
                XmlHelper.SetProductID(wmXmlPath, "{" + "db93699d-b287-4277-a72f-87df8e7cf339" + "}");

                //XmlHelper.SetGameName(wmXmlPath, Path.GetFileNameWithoutExtension(gameFile));
                //XmlHelper.SetProductID(wmXmlPath, "{" + Guid.NewGuid().ToString() + "}");

                string xapPath = AppDomain.CurrentDomain.BaseDirectory + "安装包目录";
                if (!Directory.Exists(xapPath))
                {
                    Directory.CreateDirectory(xapPath);
                }

                ZipHelper.CreateSample(Path.Combine(xapPath, Path.GetFileNameWithoutExtension(gameFile) + ".xap"), packageDir);
                if (!File.Exists(Path.Combine(xapPath, Path.GetFileNameWithoutExtension(gameFile) + ".xap")))
                {
                    throw new Exception(string.Format("没有打包成游戏文件！请重试或联系我！"));
                }

                this.textBox_PackageDir.Text = xapPath;

                SetDevelopingButtonEnable();

                SetTipsInfo("打包成功，请到 安装包目录 下安装游戏到手机中，并截屏。将截屏文件复制到 截屏图片存的位置 下");

                SetStatusInfo("打包成功.");
            }
            catch (Exception ex)
            {
                SetStatusInfo("获取游戏失败,\n" + ex.Message);
            }
        }

        private void button_OpenPackageDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + this.textBox_PackageDir.Text + "\"");
        }

        private void button_OpenScreenShotDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + this.textBox_ScreenShotDir.Text + "\"");
            //System.Diagnostics.Process.Start("explorer.exe", this.textBox_ScreenShotDir.Text);
        }

        private void button_SubmitGameInfo_Click(object sender, EventArgs e)
        {
            SetStartButtonEnable();

            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
            {
                foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                {
                    File.Delete(f);
                }
            }
        }

        private void button_DisableIt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定这个游戏不可用？？？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Directory.Delete(textBox_ScreenShotDir.Text, true);
                }
                catch { }

                SetStartButtonEnable();

                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                {
                    foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                    {
                        File.Delete(f);
                    }
                }              
            }
        }
    }
}
