using GamesManager.Utility;
using Models.GameManager;
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

namespace GamesManager.AndroidLiuMangForm
{
    public partial class GetLiuLangAdsForm : Form
    {
        private AndroidPushGameInfoModel _androidPushGameInfoModel;
        private string _currentFilePath;
        private string _currentIconPath;
        private string _tempJsonFile;

        public GetLiuLangAdsForm()
        {
            InitializeComponent();

            _tempJsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "NotComplete.txt");
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp")))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp"));
            }

            //string path =Path.GetDirectoryName(@"E:\Work\WinFrom\XapMaker\GamesManager\Utility\ZipHelper.cs");
        }

        private void GetLiuLangAdsForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(_tempJsonFile))
            {
                _androidPushGameInfoModel = JsonHelper.DeserializeObjectFromJsonFile<AndroidPushGameInfoModel>(_tempJsonFile);
            }

            if (_androidPushGameInfoModel != null)
            {
                textBox_BaiDuDevAccount.Text = _androidPushGameInfoModel.BaiduStoreDevAccount;
                textBox_BaiDuPassword.Text = _androidPushGameInfoModel.BaiduStoreDevPassword;
                textBox_DownlandAddress.Text = _androidPushGameInfoModel.DownloadAddress;
                textBox_IadAppKey.Text = _androidPushGameInfoModel.IAdPushAppKey;
                textBox_JingZhongAppId.Text = _androidPushGameInfoModel.JingZhongAppId;
                textBox_PackageName.Text = _androidPushGameInfoModel.PackageName;
                textBox_SanLiuLingDevAccount.Text = _androidPushGameInfoModel.SanLiuLingStoreDevAccount;
                textBox_SanLiuLingPassword.Text = _androidPushGameInfoModel.SanLiuLingStoreDevPassword;
                textBox_XiaoMiDevAccount.Text = _androidPushGameInfoModel.XiaomiStoreDevAccount;
                textBox_XiaoMiPassword.Text = _androidPushGameInfoModel.XiaomiStoreDevPassword;
                textBox_AppType.Text = _androidPushGameInfoModel.AppType;

                SetDevelopingButtonEnable();
                SetTipsInfo("检测到上次退出前还有没有提交完的,请继续提交*_^");
            }
            else
            {
                SetStartButtonEnable();
                SetTipsInfo("请点击 获取新游戏 按钮来获取新的游戏^_^");
            }
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
            button_GetNewAndroidLiuMangGame.Enabled = true;
            button_SubmitGameInfo.Enabled = false;
            button_DisableIt.Enabled = false;
            button_AutoPackage.Enabled = false;
        }

        private void SetDevelopingButtonEnable()
        {
            button_GetNewAndroidLiuMangGame.Enabled = false;
            button_SubmitGameInfo.Enabled = true;
            button_DisableIt.Enabled = true;
            button_AutoPackage.Enabled = true;
        }

        private void button_GetNewAndroidLiuMangGame_Click(object sender, EventArgs e)
        {
            try
            {
                _androidPushGameInfoModel = HttpDataHelper.GetOneFreeLiuMangGameInfo();
                if (_androidPushGameInfoModel == null)
                {
                    SetTipsInfo("没有获取到游戏,可能是库里没有了,请重试,如果重试多次无效,请联系我");
                }
                else
                {
                    textBox_BaiDuDevAccount.Text = _androidPushGameInfoModel.BaiduStoreDevAccount;
                    textBox_BaiDuPassword.Text = _androidPushGameInfoModel.BaiduStoreDevPassword;
                    textBox_DownlandAddress.Text = _androidPushGameInfoModel.DownloadAddress;
                    textBox_IadAppKey.Text = _androidPushGameInfoModel.IAdPushAppKey;
                    textBox_JingZhongAppId.Text = _androidPushGameInfoModel.JingZhongAppId;
                    textBox_PackageName.Text = _androidPushGameInfoModel.PackageName;
                    textBox_SanLiuLingDevAccount.Text = _androidPushGameInfoModel.SanLiuLingStoreDevAccount;
                    textBox_SanLiuLingPassword.Text = _androidPushGameInfoModel.SanLiuLingStoreDevPassword;
                    textBox_XiaoMiDevAccount.Text = _androidPushGameInfoModel.XiaomiStoreDevAccount;
                    textBox_XiaoMiPassword.Text = _androidPushGameInfoModel.XiaomiStoreDevPassword;
                    textBox_AppType.Text = _androidPushGameInfoModel.AppType;

                    SetTipsInfo("已获取到游戏信息，请复制游戏下载地址，下载游戏后把游戏拖进来。");
                    SetDevelopingButtonEnable();

                    try
                    {
                        JsonHelper.SerializerToJsonFile(_androidPushGameInfoModel, _tempJsonFile);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                SetTipsInfo("没有获取到游戏,可能是库里没有了,请重试,如果重试多次无效,请联系我");
            }
        }

        private void button_SubmitGameInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_currentFilePath))
                {
                    SetStatusInfo("请先下载游戏，再把游戏文件拖进来");
                    return;
                }

                if (string.IsNullOrWhiteSpace(_currentIconPath))
                {
                    SetStatusInfo("请把游戏的图标拖进来");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox_GameName.Text))
                {
                    SetStatusInfo("游戏名称不能为空");
                    return;
                }

                if (MessageBox.Show("您确定游戏已经完全提交到商店了吗？点击确定表示完成", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HttpDataHelper.UpdateGameNameAndState(textBox_GameName.Text, textBox_PackageName.Text);

                    File.Delete(_tempJsonFile);
                    SetStartButtonEnable();
                    SetTipsInfo("提交成功，请点击 获取新游戏 按钮来获取新的游戏^_^");

                    ClearAllTextBoxContent();
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("提交失败,请重试," + ex.Message);
            }
        }

        private void button_CopyDownloadAddress_Click(object sender, EventArgs e)
        {
            if (_androidPushGameInfoModel == null)
            {
                return;
            }

            switch ((sender as Button).Name)
            {
                case "button_CopyDownloadAddress":
                    Clipboard.SetDataObject(textBox_DownlandAddress.Text);
                    break;

                case "button_CopyIadAppKey":
                    Clipboard.SetDataObject(textBox_IadAppKey.Text);
                    break;

                case "button_CopyJingZhongAppId":
                    Clipboard.SetDataObject(textBox_JingZhongAppId.Text);
                    break;

                case "button_CopyPackageName":
                    Clipboard.SetDataObject(textBox_PackageName.Text);
                    break;

                case "button_CopyGameName":
                    Clipboard.SetDataObject(textBox_GameName.Text);
                    break;

                case "button_CopyBaiDuDevAccount":
                    Clipboard.SetDataObject(textBox_BaiDuDevAccount.Text);
                    break;

                case "textBox_DownlandAddress":
                    Clipboard.SetDataObject(textBox_DownlandAddress.Text);
                    break;

                case "button_CopyBaiduPassword":
                    Clipboard.SetDataObject(textBox_BaiDuPassword.Text);
                    break;

                case "button_CopySanLiuLingDevAccount":
                    Clipboard.SetDataObject(textBox_SanLiuLingDevAccount.Text);
                    break;

                case "button_CopySanLiuLingPassword":
                    Clipboard.SetDataObject(textBox_SanLiuLingPassword.Text);
                    break;

                case "button_CopyXiaoMiDevAccount":
                    Clipboard.SetDataObject(textBox_XiaoMiDevAccount.Text);
                    break;

                case "button_CopyXiaoMiPassword":
                    Clipboard.SetDataObject(textBox_XiaoMiPassword.Text);
                    break;

                default: break;
            }

            SetStatusInfo(string.Format("复制成功,内容为：{0}", Clipboard.GetText()));
        }

        private void GetLiuLangAdsForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void GetLiuLangAdsForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (_androidPushGameInfoModel == null)
                {
                    return;
                }

                string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (Path.GetExtension(ss[0]).ToLower() == ".apk")
                {
                    _currentFilePath = ss[0];

                    if (!_currentFilePath.EndsWith("#" + _androidPushGameInfoModel.IAdPushAppKey.Trim() + Path.GetExtension(_currentFilePath)))
                    {
                        string fileDirPath = Path.GetDirectoryName(_currentFilePath);
                        string newFileName = Path.GetFileNameWithoutExtension(_currentFilePath)
                                            + "#" + _androidPushGameInfoModel.IAdPushAppKey.Trim() + Path.GetExtension(_currentFilePath);

                        File.Move(_currentFilePath, Path.Combine(fileDirPath, newFileName));
                        _currentFilePath = Path.Combine(fileDirPath, newFileName);
                    }

                    SetTipsInfo(string.Format("游戏文件名已经修改为 {0},确定图标也拖进来后，请点击 打包 按钮 :-)", Path.GetFileName(_currentFilePath)));
                }

                if (Path.GetExtension(ss[0]).ToLower() == ".png")
                {
                    _currentIconPath = ss[0];
                    this.pictureBox_Logo.Image = new Bitmap(_currentIconPath);
                    SetTipsInfo(string.Format("图标文件已拖入，确定游戏文件也拖进来后，请点击 打包 按钮 :-)", Path.GetFileName(_currentFilePath)));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button_DisableIt_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("您确定游戏不能用吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HttpDataHelper.UpdateGameNameAndDisableState(textBox_GameName.Text, textBox_PackageName.Text);

                    File.Delete(_tempJsonFile);
                    SetStartButtonEnable();
                    SetTipsInfo("提交成功，请点击 获取新游戏 按钮来获取新的游戏^_^");

                    ClearAllTextBoxContent();
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("提交失败,请重试," + ex.Message);
            }
        }


        private void ClearAllTextBoxContent()
        {
            this.textBox_AppType.Clear();
            this.textBox_BaiDuDevAccount.Clear();
            this.textBox_BaiDuPassword.Clear();
            this.textBox_DownlandAddress.Clear();
            this.textBox_GameName.Clear();
            this.textBox_IadAppKey.Clear();
            this.textBox_JingZhongAppId.Clear();
            this.textBox_PackageName.Clear();
            this.textBox_SanLiuLingDevAccount.Clear();
            this.textBox_SanLiuLingPassword.Clear();
            this.textBox_XiaoMiDevAccount.Clear();
            this.textBox_XiaoMiPassword.Clear();

            this._currentFilePath = string.Empty;
            this._currentIconPath = string.Empty;
            this.pictureBox_Logo.Image = null;
        }

        delegate void InvokeSetStatusInfo(string msg);

        private void button_AutoPackage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentFilePath))
            {
                SetStatusInfo("请先下载游戏，再把游戏文件拖进来");
                return;
            }

            if (string.IsNullOrWhiteSpace(_currentIconPath))
            {
                SetStatusInfo("请把游戏的图标拖进来");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox_GameName.Text))
            {
                SetStatusInfo("游戏名称不能为空");
                return;
            }

            try
            {
                string iadDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"iad\data");
                string a1Path = Path.Combine(iadDataPath, "a1.bat");
                string b1Path = Path.Combine(iadDataPath, "b1.bat");
                //string b1Path = Path.Combine(iadDataPath, "test.bat");
                string c1Path = Path.Combine(iadDataPath, "c1.bat");
                string d1Path = Path.Combine(iadDataPath, "d1.bat");

                string targetXapDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"iad\apks\targets");
                string outPutXapDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"iad\apks\out");
                string tempXapDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"iad\apks\temp");

                foreach (var file in Directory.GetFiles(targetXapDir))
                {
                    File.Delete(file);
                }

                File.Copy(_currentFilePath, Path.Combine(targetXapDir, Path.GetFileName(_currentFilePath)));

                Directory.SetCurrentDirectory(iadDataPath);

                SetStatusInfo("1.反编译");
                Process.Start(a1Path).WaitForExit();

                SetStatusInfo("2.替换Logo");
                ReplaeceIcon(tempXapDir, Path.GetFileNameWithoutExtension(_currentFilePath));

                SetStatusInfo("3.注入");
                Process.Start(b1Path, string.Format("{0} {1} {2} {3}",
                                    textBox_PackageName.Text.Trim(), "1", "1.0", textBox_GameName.Text.Trim())).WaitForExit();

                SetStatusInfo("4.打包");
                Process.Start(c1Path).WaitForExit();

                SetStatusInfo("5.签名");
                Process.Start(d1Path).WaitForExit();

                string outXapFile = Path.Combine(outPutXapDir, "new_" + Path.GetFileName(_currentFilePath));
                string finalXapFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "自动打包后文件存放在这里", Path.GetFileName(_currentFilePath));
                if (File.Exists(outXapFile))
                {
                    if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "自动打包后文件存放在这里")))
                    {
                        Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "自动打包后文件存放在这里"));
                    }

                    File.Move(outXapFile, finalXapFile);

                    SetStatusInfo("成功");
                    SetTipsInfo("自动打包成功，文件在《自动打包后文件存放在这里》文件夹下的" + Path.GetFileName(_currentFilePath));
                }
                else
                {
                    SetTipsInfo("打包失败，请点击 这个游戏用不了 按钮");
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("打包失败," + ex.Message);
                SetTipsInfo("打包失败，请点击 这个游戏用不了 按钮");
            }
        }

        private void RePackage()
        {

        }

        private void ReplaeceIcon(string tempXapDir, string xapName)
        {
            string androidManifestXml = Path.Combine(tempXapDir, xapName, "AndroidManifest.xml");
            string l_t = XmlHelper.GetIconPath(androidManifestXml);

            string logoSmallPath = l_t.Substring(0, l_t.IndexOf("/")).Replace("@", "");
            string logoName = l_t.Substring(l_t.IndexOf("/") + 1);

            string resPath = Path.Combine(tempXapDir, xapName, "res");

            foreach (string dir in Directory.GetDirectories(resPath))
            {
                if (dir.ToLower().Contains(logoSmallPath.ToLower()))
                {
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        if (Path.GetFileNameWithoutExtension(file).ToLower() == logoName.ToLower())
                        {
                            File.Copy(_currentIconPath, file, true);
                        }
                    }
                }
            }
        }

        private void button_CopyIadAppKey_Click(object sender, EventArgs e)
        {

        }
    }
}
