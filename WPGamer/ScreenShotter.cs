using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WPGamer.Utility;
using WPGamer.Models;
using System.IO;

namespace WPGamer
{
    public partial class ScreenShotter : Form
    {
        PushGameInfoModel _pushGameInfo;
        public ScreenShotter()
        {
            InitializeComponent();
            this.Load += ScreenShotter_Load;
        }

        void ScreenShotter_Load(object sender, EventArgs e)
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

                if (!checkBox_NoUseNet.Checked)
                {
                    _pushGameInfo = HttpDataHelper.GetOneGameInfoByStateRandom("未截屏", "正截屏");

                    //PushGameInfoModel pushGameInfo = new PushGameInfoModel

                    //{
                    //    GameName = "2005 Adventures",
                    //    FileName = "2005 Adventures.zip",
                    //    SourceType = "gba"
                    //};

                    //待改
                    string gameName = _pushGameInfo.GameName + "";

                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "tmp");
                    }

                    JsonHelper.SerializerToJsonFile(_pushGameInfo, Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "tmp", "gameinfoTemp.txt"));

                    string romZip = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"roms\" + _pushGameInfo.SourceType, _pushGameInfo.FileName);

                    if (!File.Exists(romZip))
                    {
                        SetTipsInfo(romZip + " 游戏文件不存在啊……请确认");
                    }

                    string packageDir = AppDomain.CurrentDomain.BaseDirectory + @"packages\" + _pushGameInfo.SourceType;

                    string romIn = _pushGameInfo.SourceType.ToLower() == "gba" ?
                        Path.Combine(packageDir, @"Assets\dade.gba") :
                        Path.Combine(packageDir, @"Assets\rom.smc");
                    string configFile = Path.Combine(packageDir, @"Assets\GameConfigInfo.xml");

                    string ext = _pushGameInfo.SourceType.ToLower() == "gba" ? ".gba" : ".smc";
                    string country1 = _pushGameInfo.SourceType.ToLower() == "gba" ? "" : "(u)";
                    string country2 = _pushGameInfo.SourceType.ToLower() == "gba" ? "" : "(e)";

                    if (File.Exists(romIn))
                    {
                        File.Delete(romIn);
                    }

                    ZipHelper.DecompressionOneFileByExtnameAndCountry(romZip, ext, country1, country2, romIn);

                    if (!File.Exists(romIn))
                    {
                        throw new Exception(string.Format("没有解压出游戏文件来！请检查{0}文件中是否存在 .{1}文件", romZip, ext));
                    }

                    GameConfigInfos gc = new GameConfigInfos
                    {
                        GameName = gameName,
                        GoogleAdUnitID = _pushGameInfo.GoogleBanner ?? "0",
                        GoogleFullScreenAdID = _pushGameInfo.GoogleChaping ?? "0",
                        PubcenterAdUnitIDs = _pushGameInfo.PubcenterAdID ?? "0",
                        PubcenterApplicationID = _pushGameInfo.PubcenterAppID ?? "0",
                        SurfaceAdToken = _pushGameInfo.SurfaceAccountID ?? "0",
                        SurfaceAdPosition = _pushGameInfo.SurfaceAdID ?? "0",
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

                    string screenShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"roms\" + _pushGameInfo.SourceType,
                        Path.GetFileNameWithoutExtension(_pushGameInfo.FileName));
                    if (Directory.Exists(screenShotPath))
                    {
                        Directory.Delete(screenShotPath, true);
                    }

                    Directory.CreateDirectory(screenShotPath);

                    File.Copy(romZip, Path.Combine(screenShotPath, Path.GetFileName(romZip)));

                    this.textBox_ScreenShotDir.Text = screenShotPath;

                    string wmXmlPath = Path.Combine(packageDir, @"WMAppManifest.xml");
                    XmlHelper.SetGameName(wmXmlPath, gameName);
                    XmlHelper.SetProductID(wmXmlPath, "{" + Guid.NewGuid().ToString() + "}");

                    string xapPath = AppDomain.CurrentDomain.BaseDirectory + "安装包目录";
                    if (!Directory.Exists(xapPath))
                    {
                        Directory.CreateDirectory(xapPath);
                    }

                    ZipHelper.CreateSample(Path.Combine(xapPath, gameName + ".xap"), packageDir);
                    if (!File.Exists(Path.Combine(xapPath, gameName + ".xap")))
                    {
                        throw new Exception(string.Format("没有打包成游戏文件！请重试或联系我！"));
                    }

                    this.textBox_PackageDir.Text = xapPath;

                    SetDevelopingButtonEnable();

                    SetTipsInfo("打包成功，请到 安装包目录 下安装游戏到手机中，并截屏。将截屏文件复制到 截屏图片存的位置 下");

                    SetStatusInfo("打包成功.");
                }

                else
                {
                    string gameFile = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "roms")[0];
                    string sourceType = ZipHelper.GetGameSourceType(gameFile);

                    string packageDir = AppDomain.CurrentDomain.BaseDirectory + @"packages\" + sourceType;

                    string romIn = sourceType.ToLower() == "gba" ?
                        Path.Combine(packageDir, @"Assets\dade.gba") :
                        Path.Combine(packageDir, @"Assets\rom.smc");
                    string configFile = Path.Combine(packageDir, @"Assets\GameConfigInfo.xml");

                    string ext = sourceType.ToLower() == "gba" ? ".gba" : ".smc";
                    string country1 = sourceType.ToLower() == "gba" ? "" : "(u)";
                    string country2 = sourceType.ToLower() == "gba" ? "" : "(e)";

                    if (File.Exists(romIn))
                    {
                        File.Delete(romIn);
                    }

                    ZipHelper.DecompressionOneFileByExtnameAndCountry(gameFile, ext, country1, country2, romIn);

                    if (!File.Exists(romIn))
                    {
                        throw new Exception(string.Format("没有解压出游戏文件来！请检查{0}文件中是否存在 .{1}文件", gameFile, ext));
                    }

                    GameConfigInfos gc = new GameConfigInfos
                    {
                        GameName = Path.GetFileNameWithoutExtension(gameFile),
                        GoogleAdUnitID = "0",
                        GoogleFullScreenAdID = "0",
                        PubcenterAdUnitIDs = "0",
                        PubcenterApplicationID = "0",
                        SurfaceAdToken = "0",
                        SurfaceAdPosition = "0",
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

                    string screenShotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"roms\",
                        Path.GetFileNameWithoutExtension(gameFile));
                    if (Directory.Exists(screenShotPath))
                    {
                        Directory.Delete(screenShotPath, true);
                    }

                    Directory.CreateDirectory(screenShotPath);

                    File.Move(gameFile, Path.Combine(screenShotPath, Path.GetFileName(gameFile)));

                    this.textBox_ScreenShotDir.Text = screenShotPath;

                    string wmXmlPath = Path.Combine(packageDir, @"WMAppManifest.xml");
                    XmlHelper.SetGameName(wmXmlPath, Path.GetFileNameWithoutExtension(gameFile));
                    XmlHelper.SetProductID(wmXmlPath, "{" + Guid.NewGuid().ToString() + "}");

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

            }
            catch (Exception ex)
            {
                SetStatusInfo("获取游戏失败,\n" + ex.Message);
            }
        }

        private void button_SubmitGameInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkBox_NoUseNet.Checked)
                {
                    HttpDataHelper.UpdateJpState("已截屏", _pushGameInfo.ID);
                    SetTipsInfo("提交成功，请继续点击 获取新游戏打包 按钮获取下一个游戏");
                    SetStatusInfo("提交成功");
                    SetStartButtonEnable();

                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                    {
                        foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                        {
                            File.Delete(f);
                        }
                    }

                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                    {
                        foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                        {
                            File.Delete(f);
                        }
                    }
                }
                else
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
            }
            catch (Exception ex)
            {
                SetStatusInfo("提交失败," + ex.Message);
            }
        }

        private void button_DisableIt_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("确定这个游戏不可用？？？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (!checkBox_NoUseNet.Checked)
                    {
                        HttpDataHelper.UpdatePushGameInfoByID("", "", "", "", "", "", "", "", "", _pushGameInfo.ID, "不可用", "", "", "");

                        SetTipsInfo("提交成功，请继续点击 获取新游戏打包 按钮获取下一个游戏");
                        SetStatusInfo("提交成功");
                        SetStartButtonEnable();

                        if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                        {
                            foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                            {
                                File.Delete(f);
                            }
                        }

                        if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                        {
                            foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                            {
                                File.Delete(f);
                            }
                        }
                    }
                    else
                    {
                        SetStartButtonEnable();

                        if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                        {
                            foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                            {
                                File.Delete(f);
                            }
                        }

                        try
                        {
                            Directory.Delete(textBox_ScreenShotDir.Text, true);
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("提交失败," + ex.Message);
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
    }
}
