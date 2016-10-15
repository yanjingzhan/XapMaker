using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WPGamer.Models;
using WPGamer.Utility;

namespace WPGamer
{
    public partial class PackageBuilder : Form
    {
        PushGameInfoModel _pushGameInfo;
        public PackageBuilder()
        {
            InitializeComponent();
            this.Load += PackageBuilder_Load;
        }

        void PackageBuilder_Load(object sender, EventArgs e)
        {
            SetStartButtonEnable();

            SetTipsInfo("请点击 获取新游戏打包 按钮");
        }

        private void SetTipsInfo(string info)
        {
            this.label_Tips.Text = info;
        }

        private void SetStatusInfo(string info)
        {
            this.toolStripStatusLabel_Status.Text = DateTime.Now.ToString() + "----" + info;
        }

        private void SetStartButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = true;
            this.button_DisableIt.Enabled = false;
            this.button_OpenPackageDir.Enabled = false;
            this.button_SubmitGameInfo.Enabled = false;
            this.button_DevAccountDie.Enabled = false;
            this.button_RePackage.Enabled = false;

            this.textBox_PackageDir.Clear();
            this.textBox_GameDetails.Clear();
            this.textBox_GameName.Clear();
            this.textBox_DevAccount.Clear();
            this.textBox_DevPassword.Clear();

            this.textBox_KeyWords1.Clear();
            this.textBox_KeyWords2.Clear();
            this.textBox_KeyWords3.Clear();
            this.textBox_KeyWords4.Clear();

            this.textBox_Country.Clear();
            this.textBox_Email.Clear();
            this.textBox_FirstName.Clear();
            this.textBox_LastName.Clear();
            this.textBox_PhoneNumber.Clear();
            this.textBox_PublisherName.Clear();
            this.textBox_NewGameName.Clear();
        }

        private void SetDevelopingButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = false;
            this.button_DisableIt.Enabled = true;
            this.button_OpenPackageDir.Enabled = true;
            this.button_SubmitGameInfo.Enabled = true;
            this.button_DevAccountDie.Enabled = true;
            this.button_RePackage.Enabled = true;
        }


        private void button_Shot_GetNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                SetStatusInfo("正在执行……");

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

                //List<string> keyWords = HttpDataHelper.GetKeyWords(4);
                //this.textBox_KeyWords1.Text = keyWords[0];
                //this.textBox_KeyWords2.Text = keyWords[1];
                //this.textBox_KeyWords3.Text = keyWords[2];
                //this.textBox_KeyWords4.Text = keyWords[3];


                //GlobalData.PusherName = INIHelper.ReadIniData("user", "pusher", "", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini"));
                if (!checkBox_GaveGameName.Checked)
                {
                    //_pushGameInfo = HttpDataHelper.GetOneGameInfoByRealStateRandom("待提交", "开发中", GlobalData.PusherName);

                    _pushGameInfo = HttpDataHelper.GetOneGameInfoAndChangeStateRandomForDev("待提交", "开发中");

                    //for test
                    //_pushGameInfo = new PushGameInfoModel
                    //{
                    //    FileName = "shit 24 jib.xap",
                    //    FixedGameName = "shit 24 jib",
                    //    GameName = "shiteating",
                    //    SourceType = "Unity",
                    //    BackImagePath = "http://gamemanager.pettostudio.net/resoures/wp/moniqi/F1 Dream ROC Race of Champions_bj.png",
                    //    LogoPath = "http://gamemanager.pettostudio.net/resoures/wp/moniqi/F1 Dream GR ROC Race of Champions_logo.png"
                    //};
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.textBox_GaveGameName.Text))
                    {
                        SetStatusInfo("请填写需要专门查找的游戏名称");
                        return;
                    }

                    _pushGameInfo = HttpDataHelper.GetGameList(this.textBox_GaveGameName.Text, "", "")[0];
                }

                string gameName = _pushGameInfo.GameName + "";

                this.textBox_GameDetails.Text = _pushGameInfo.GameDetails;
                this.textBox_GameName.Text = _pushGameInfo.GameName;
                this.textBox_DevAccount.Text = _pushGameInfo.RealDevAccount;
                this.textBox_DevPassword.Text = _pushGameInfo.RealDevPassword;

                //this.textBox_DevAccount.Text = _pushGameInfo.DevAccount;
                //this.textBox_DevPassword.Text = _pushGameInfo.DevPassword;

                //WindowsDevAccounts wda = HttpDataHelper.GetDevAccountByAccountName(_pushGameInfo.DevAccount);
                //this.textBox_Country.Text = wda.Country;
                //this.textBox_Email.Text = wda.Email;
                //this.textBox_FirstName.Text = wda.FirstName;
                //this.textBox_LastName.Text = wda.LastName;
                //this.textBox_PhoneNumber.Text = wda.PhoneNumber;
                //this.textBox_PublisherName.Text = wda.PublisherName;

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "tmp");
                }

                JsonHelper.SerializerToJsonFile(_pushGameInfo, Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "tmp", "gameinfoTemp.txt"));

                string romZip = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"roms\" + Path.GetFileNameWithoutExtension(_pushGameInfo.FileName) + @"\" + _pushGameInfo.FileName);

                //unity的特殊处理
                if(_pushGameInfo.SourceType .ToLower() == "unity")
                {
                    string ft = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"unity\" + _pushGameInfo.FixedGameName);

                    if(!Directory.Exists(ft))
                    {
                        SetTipsInfo(ft + " 文件夹不存在啊……请确认");
                        return;
                    }

                    foreach (var f in Directory.GetFiles(ft))
                    {
                        if(Path.GetExtension(f).ToLower() == ".xap")
                        {
                            romZip = f;
                            break;
                        }
                    }
                }

                if (!File.Exists(romZip))
                {
                    SetTipsInfo(romZip + " 游戏文件不存在啊……请确认");
                    return;
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

                if (_pushGameInfo.SourceType.ToLower() != "unity")
                {
                    ZipHelper.DecompressionOneFileByExtnameAndCountry(romZip, ext, country1, country2, romIn);

                    if (!File.Exists(romIn))
                    {
                        throw new Exception(string.Format("没有解压出游戏文件来！请检查{0}文件中是否存在 .{1}文件", romZip, ext));
                    }
                }
                else
                {
                    ZipHelper.ExtractZipFile(romZip, string.Empty, packageDir);
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
                if (_pushGameInfo.SourceType.ToLower() != "unity")
                {
                    HttpDataHelper.DownloadFile(_pushGameInfo.BackImagePath, Path.Combine(packageDir, @"Assets\mainbg.png"));
                    HttpDataHelper.DownloadFile(_pushGameInfo.BackImagePath, Path.Combine(packageDir, @"Assets\startImage.png"));
                    HttpDataHelper.DownloadFile(_pushGameInfo.LogoPath, Path.Combine(packageDir, @"Assets\300.png"));
                }
                else
                {
                    HttpDataHelper.DownloadFile(_pushGameInfo.LogoPath, Path.Combine(packageDir, @"300.png"));
                }

                string wmXmlPath = Path.Combine(packageDir, @"WMAppManifest.xml");
                XmlHelper.SetGameName(wmXmlPath, (_pushGameInfo.GameName));
                XmlHelper.SetProductID(wmXmlPath, "{" + Guid.NewGuid().ToString() + "}");

                string xapPath = AppDomain.CurrentDomain.BaseDirectory + "安装包目录";
                if (!Directory.Exists(xapPath))
                {
                    Directory.CreateDirectory(xapPath);
                }

                ZipHelper.CreateSample(Path.Combine(xapPath, (_pushGameInfo.GameName) + ".xap"), packageDir);
                if (!File.Exists(Path.Combine(xapPath, (_pushGameInfo.GameName) + ".xap")))
                {
                    throw new Exception(string.Format("没有打包成游戏文件！请重试或联系我！"));
                }

                if (_pushGameInfo.SourceType.ToLower() != "unity")
                {

                    foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"roms\" + Path.GetFileNameWithoutExtension(_pushGameInfo.FileName))))
                    {
                        if (Path.GetExtension(file).ToLower() == ".png")
                        {
                            //File.Copy(file, Path.Combine(xapPath, Path.GetFileName(file)));
                            System.Drawing.Image.FromFile(file).Save(Path.Combine(xapPath, Path.GetFileName(file)),System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                }
                else
                {
                    foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"unity\" + Path.GetFileNameWithoutExtension(_pushGameInfo.FileName))))
                    {
                        if (Path.GetExtension(file).ToLower() == ".png")
                        {
                            //File.Copy(file, Path.Combine(xapPath, Path.GetFileName(file)));
                            System.Drawing.Image.FromFile(file).Save(Path.Combine(xapPath, Path.GetFileName(file)), System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                }

                if (_pushGameInfo.SourceType.ToLower() != "unity")
                {
                    File.Copy(Path.Combine(packageDir, @"Assets\300.png"), Path.Combine(xapPath, "300.png"));
                }
                else
                {
                    File.Copy(Path.Combine(packageDir, @"300.png"), Path.Combine(xapPath, "300.png"));
                }

                this.textBox_PackageDir.Text = xapPath;

                SetDevelopingButtonEnable();

                SetTipsInfo("打包成功，请到 安装包目录 下的 xap 文件提交到商店，完成后点击 提交完成 按钮");

                SetStatusInfo("打包成功.");

            }
            catch (Exception ex)
            {
                SetStatusInfo("获取游戏失败,\n" + ex.Message);
            }
        }

        private void button_SubmitGameInfo_Click(object sender, EventArgs e)
        {
            //HttpDataHelper.UpdatePushGameStateInfoByID("待审核", _pushGameInfo.ID);

            HttpDataHelper.DevSuccessedByDreamSpark(_pushGameInfo.ID, _pushGameInfo.RealDevAccount, _pushGameInfo.RealDevPassword);

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

        private void button_DisableIt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定这个游戏不可用？？？ _(:зゝ∠)_", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HttpDataHelper.UpdatePushGameStateInfoByID("待确认", _pushGameInfo.ID);
                HttpDataHelper.UpdateDreamSparkerByDevAccount(_pushGameInfo.RealDevAccount, "待确认");

                SetTipsInfo("游戏不可用信息提交成功，请继续点击 获取新游戏打包 按钮获取下一个游戏");
                SetStatusInfo("游戏不可用信息提交成功");
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
        }

        private void button_OpenPackageDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + this.textBox_PackageDir.Text + "\"");
        }

        #region Copy

        private void button_CopyGameDetails_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_GameDetails.Text))
            {
                Clipboard.SetText(this.textBox_GameDetails.Text);
            }
        }

        private void button_CopyKeyWords1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_KeyWords1.Text))
            {
                Clipboard.SetText(this.textBox_KeyWords1.Text);
            }
        }

        private void button_CopyKeyWords2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_KeyWords2.Text))
            {

                Clipboard.SetText(this.textBox_KeyWords2.Text);
            }
        }

        private void button_CopyKeyWords3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_KeyWords3.Text))
            {
                Clipboard.SetText(this.textBox_KeyWords3.Text);
            }
        }

        private void button_CopyKeyWords4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_KeyWords4.Text))
            {
                Clipboard.SetText(this.textBox_KeyWords4.Text);
            }
        }

        private void button_CopyDevAccount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_DevAccount.Text))
            {
                Clipboard.SetText(this.textBox_DevAccount.Text);
            }
        }

        private void button_CopyDevPassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_DevPassword.Text))
            {
                Clipboard.SetText(this.textBox_DevPassword.Text);
            }
        }

        private void button_CopyGameName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_GameName.Text))
            {
                Clipboard.SetText(this.textBox_GameName.Text);
            }
        }

        private void checkBox_GaveGameName_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_GaveGameName.Visible = (sender as CheckBox).Checked;
        }

        private void button_CopyLastName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_LastName.Text))
            {
                Clipboard.SetText(this.textBox_LastName.Text);
            }
        }

        private void button_CopyPhoneNumber_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_PhoneNumber.Text))
            {
                Clipboard.SetText(this.textBox_PhoneNumber.Text);
            }
        }

        private void button_CopyPublisherName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_PublisherName.Text))
            {
                Clipboard.SetText(this.textBox_PublisherName.Text);
            }
        }

        private void button_CopyEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Email.Text))
            {
                Clipboard.SetText(this.textBox_Email.Text);
            }
        }

        private void button_CopyCountry_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Country.Text))
            {
                Clipboard.SetText(this.textBox_Country.Text);
            }
        }

        private void button_CopyFirstName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_FirstName.Text))
            {
                Clipboard.SetText(this.textBox_FirstName.Text);
            }
        }

        #endregion

        private void button_DevAccountDie_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定账号被封了？账号被封了 (○´･д･)ﾉ？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HttpDataHelper.UpdatePushGameStateInfoByID("待提交", _pushGameInfo.ID);
                HttpDataHelper.UpdateDreamSparkerByDevAccount(_pushGameInfo.RealDevAccount, "已被封");

                SetTipsInfo("被封信息提交成功，请继续点击 获取新游戏打包 按钮获取下一个游戏");
                SetStatusInfo("被封信息提交成功");
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
        }

        private void button_RePackage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要用新的名称吗(○´･д･)ﾉ？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {   
                if(string.IsNullOrWhiteSpace(this.textBox_NewGameName.Text))
                {
                    SetStatusInfo("请填写新的游戏名称.");
                    return;
                }

                string packageDir = AppDomain.CurrentDomain.BaseDirectory + @"packages\" + _pushGameInfo.SourceType;
                string wmXmlPath = Path.Combine(packageDir, @"WMAppManifest.xml");
                XmlHelper.SetGameName(wmXmlPath, (this.textBox_NewGameName.Text));

                HttpDataHelper.UpdatePushGameNameByID(this.textBox_NewGameName.Text, _pushGameInfo.ID);

                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                {
                    foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                    {
                        File.Delete(f);
                    }
                }

                string xapPath = AppDomain.CurrentDomain.BaseDirectory + "安装包目录";
                if (!Directory.Exists(xapPath))
                {
                    Directory.CreateDirectory(xapPath);
                }

                ZipHelper.CreateSample(Path.Combine(xapPath, (_pushGameInfo.GameName) + ".xap"), packageDir);
                if (!File.Exists(Path.Combine(xapPath, (_pushGameInfo.GameName) + ".xap")))
                {
                    throw new Exception(string.Format("没有打包成游戏文件！请重试或联系我！"));
                }

                foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"roms\" + Path.GetFileNameWithoutExtension(_pushGameInfo.FileName))))
                {
                    if (Path.GetExtension(file).ToLower() == ".png")
                    {
                        File.Copy(file, Path.Combine(xapPath, Path.GetFileName(file)));
                    }
                }

                File.Copy(Path.Combine(packageDir, @"Assets\300.png"), Path.Combine(xapPath, "300.png"));
                this.textBox_PackageDir.Text = xapPath;

                this.textBox_GameName.Text = this.textBox_NewGameName.Text;

                SetTipsInfo("重新打包成功，请到 安装包目录 下的 xap 文件提交到商店，完成后点击 提交完成 按钮");

                SetStatusInfo("重新打包成功.");
            }
        }
    }
}
