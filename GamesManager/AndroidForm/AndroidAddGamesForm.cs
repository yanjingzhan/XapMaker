using GamesManager.Model;
using GamesManager.Utility;
using Models.GameManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamesManager.AndroidForm
{
    public partial class AndroidAddGamesForm : Form
    {
        public AndroidAddGamesForm()
        {
            InitializeComponent();
        }

        private void AddGamesForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void AddGamesForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (Path.GetExtension(ss[0]).ToLower() == ".apk")
                {
                    string fileName = Path.GetFileName(ss[0]);

                    this.label_FileName.Text = fileName;
                    this.textBox_PackageName.Text = RandomHelper.GetPackageName();
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

        private bool CheckCheckItem()
        {
            return (string.IsNullOrEmpty(textBox_BaiDuAppID.Text) ||
               string.IsNullOrEmpty(textBox_BaiduStoreDevPassword.Text) ||
               string.IsNullOrEmpty(textBox_BaiduStoreDevPassword.Text) ||
               string.IsNullOrEmpty(textBox_GameName.Text) ||
               string.IsNullOrEmpty(textBox_GameVersion.Text) ||
               string.IsNullOrEmpty(textBox_JingZhongAppId.Text) ||
               string.IsNullOrEmpty(textBox_PackageName.Text) ||
               string.IsNullOrEmpty(textBox_SanLiuLingAppID.Text) ||
               string.IsNullOrEmpty(textBox_SanLiuLingBannerID.Text) ||
               string.IsNullOrEmpty(textBox_SanLiuLingChaPingID.Text) ||
               string.IsNullOrEmpty(textBox_SanLiuLingStoreDevPassword.Text) ||
               string.IsNullOrEmpty(textBox_XiaomiStoreDevPassword.Text) ||
               string.IsNullOrEmpty(textBox_YouMiID.Text) ||
               string.IsNullOrEmpty(textBox_YouMiAppID.Text) ||
               string.IsNullOrEmpty(textBox_SanLiuLingStoreDevPassword.Text) ||
               string.IsNullOrEmpty(textBox_SanLiuLingStoreDevPassword.Text) ||

               string.IsNullOrEmpty(comboBox_BaiduStoreDevAccount.Text) ||
               string.IsNullOrEmpty(comboBox_PusherName.Text) ||
               string.IsNullOrEmpty(comboBox_SanLiuLingStoreDevAccount.Text) ||
               string.IsNullOrEmpty(comboBox_XiaomiStoreDevAccount.Text));
        }

        private void ClearItem()
        {
            this.label_FileName.Text = "请把要添加的游戏文件拖进来 :-)";
            this.textBox_BaiDuAppID.Clear();
            //this.textBox_BaiduStoreDevPassword.Clear();
            this.textBox_GameName.Clear();
            this.textBox_GameVersion.Clear();
            this.textBox_JingZhongAppId.Clear();
            this.textBox_PackageName.Clear();
            this.textBox_SanLiuLingAppID.Clear();
            this.textBox_SanLiuLingBannerID.Clear();
            this.textBox_SanLiuLingChaPingID.Clear();
            //this.textBox_SanLiuLingStoreDevPassword.Clear();
            //this.textBox_XiaomiStoreDevPassword.Clear();
            this.textBox_YouMiID.Clear();
            this.textBox_YouMiAppID.Clear();
        }

        DevAccounts _devAccounts;
        private void AddGamesForm_Shown(object sender, EventArgs e)
        {
            try
            {
                List<string> pusherNames = HttpDataHelper.GetPusherNames();

                comboBox_PusherName.Items.Clear();
                comboBox_PusherName.Items.AddRange(pusherNames.ToArray());

                _devAccounts = HttpDataHelper.GetDevAccountList();

                comboBox_BaiduStoreDevAccount.Items.Clear();
                comboBox_SanLiuLingStoreDevAccount.Items.Clear();
                comboBox_XiaomiStoreDevAccount.Items.Clear();

                comboBox_BaiduStoreDevAccount.Items.AddRange(_devAccounts.GetBaiduDevAccounts().ToArray());
                comboBox_SanLiuLingStoreDevAccount.Items.AddRange(_devAccounts.GetSanLiuLingDevAccounts().ToArray());
                comboBox_XiaomiStoreDevAccount.Items.AddRange(_devAccounts.GetXiaoMiDevAccounts().ToArray());
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_DevAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox s = sender as ComboBox;
            switch (s.Name)
            {
                case "comboBox_BaiduStoreDevAccount":
                    this.textBox_BaiduStoreDevPassword.Text = _devAccounts.GetBaiduDevPasswordByAccount(s.Text);
                    break;

                case "comboBox_SanLiuLingStoreDevAccount":
                    this.textBox_SanLiuLingStoreDevPassword.Text = _devAccounts.GetSanLiuLingDevPasswordByAccount(s.Text);
                    break;

                case "comboBox_XiaomiStoreDevAccount":
                    this.textBox_XiaomiStoreDevPassword.Text = _devAccounts.GetXiaoMiDevPasswordByAccount(s.Text);
                    break;

                default:
                    break;
            }
        }

        private void button_SubmitGame_Click(object sender, EventArgs e)
        {
            if (CheckCheckItem())
            {
                MessageBox.Show("请把信息填完");
                return;
            }
            else
            {
                try
                {
                    HttpDataHelper.AndroidAddPushGameInfo(
                        new AndroidPushGameInfoModel
                        {
                            BaiDuAppID = this.textBox_BaiDuAppID.Text,
                            BaiduStoreDevAccount = this.comboBox_BaiduStoreDevAccount.Text,
                            BaiduStoreDevPassword = this.textBox_BaiduStoreDevPassword.Text,
                            BaiduStoreStatus = "待提交",
                            DevAccount = string.Empty,
                            DevPassword = string.Empty,
                            DuoMengAppID = string.Empty,
                            DuoMengBannerID = string.Empty,
                            DuoMengChaPingID = string.Empty,
                            GameID = string.Empty,
                            FileName = this.label_FileName.Text,
                            GameName = this.textBox_GameName.Text,
                            GoogleBanner = string.Empty,
                            GoogleChaping = string.Empty,
                            JingZhongAppId = this.textBox_JingZhongAppId.Text,
                            PackageName = this.textBox_PackageName.Text,
                            PusherName = this.comboBox_PusherName.Text,
                            SanLiuLingAppID = this.textBox_SanLiuLingAppID.Text,
                            SanLiuLingBannerID = this.textBox_SanLiuLingBannerID.Text,
                            SanLiuLingChaPingID = this.textBox_SanLiuLingChaPingID.Text,
                            SanLiuLingStoreDevAccount = this.comboBox_SanLiuLingStoreDevAccount.Text,
                            SanLiuLingStoreDevPassword = this.textBox_SanLiuLingStoreDevPassword.Text,
                            SanLiuLingStoreStatus = "待提交",
                            State = string.Empty,
                            Version = this.textBox_GameVersion.Text,
                            XiaomiStoreDevAccount = this.comboBox_XiaomiStoreDevAccount.Text,
                            XiaomiStoreDevPassword = this.textBox_XiaomiStoreDevPassword.Text,
                            XiaomiStoreStatus = "待提交",
                            YouMiAppID = this.textBox_YouMiAppID.Text,
                            YouMiID = this.textBox_YouMiID.Text
                        });

                    ShowInfo("提交成功");
                    ClearItem();
                }
                catch (Exception ex)
                {
                    ShowInfo("提交信息失败," + ex.Message);
                    MessageBox.Show("提交信息失败," + ex.Message);
                }
            }
        }
    }
}
