using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamesManager
{
    public partial class AddGamesForm : Form
    {
        public AddGamesForm()
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
                ShowInfo("正在识别文件,请稍候...");

                string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (Path.GetExtension(ss[0]).ToLower() == ".zip")
                {
                    bool t = ZipHelper.ExtNameExist(ss[0], ".gba");
                    string gameName = Path.GetFileNameWithoutExtension(ss[0]);
                    if (t)
                    {
                        int version = HttpDataHelper.GetGameBiggestVersion(gameName);
                        ShowInfo("识别完成...");

                        this.textBox_GameName.Text = gameName;
                        this.textBox_GameVersion.Text = (version + 1).ToString();
                    }
                    else
                    {
                        throw new Exception("文件中不包含游戏文件!");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button_SubmitGame_Click(object sender, EventArgs e)
        {
            if(CheckCheckItem())
            {
                MessageBox.Show("请把信息填完");
                return;
            }
            else
            {
                try
                {
                    HttpDataHelper.AddPushGameInfo(
                        new Model.PushGameInfoModel
                        {
                            DevAccount = this.textBox_DevAccount.Text.Trim(),
                            DevPassword = this.textBox_DevPassword.Text.Trim(),
                            GameName = this.textBox_GameName.Text.Trim(),
                            GoogleBanner = this.textBox_GoogleBannerID.Text.Trim(),
                            GoogleChaping = this.textBox_GoogleChapingID.Text.Trim(),
                            PubcenterAdID = this.textBox_PubcenterAdID.Text.Trim(),
                            PubcenterAppID = this.textBox_PubcenterAppID.Text.Trim(),
                            PusherName = this.comboBox_PusherName.Text.Trim(),
                            State = "待提交",
                            SurfaceAccountID = this.textBox_SurfaceadAccountId.Text.Trim(),
                            SurfaceAdID = this.textBox_SurfaceadAdID.Text.Trim(),
                            Version = this.textBox_GameVersion.Text.Trim()
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

        private bool CheckCheckItem()
        {
            return (string.IsNullOrEmpty(this.textBox_SurfaceadAccountId.Text.Trim()) &&
               string.IsNullOrEmpty(this.textBox_SurfaceadAdID.Text.Trim()) &&
                string.IsNullOrEmpty(this.textBox_GoogleBannerID.Text.Trim()) &&
                string.IsNullOrEmpty(this.textBox_GoogleChapingID.Text.Trim()) &&
                string.IsNullOrEmpty(this.textBox_PubcenterAdID.Text.Trim()) &&
                string.IsNullOrEmpty(this.textBox_PubcenterAppID.Text.Trim()) &&
                string.IsNullOrEmpty(this.textBox_DevAccount.Text.Trim()) &&
                string.IsNullOrEmpty(this.textBox_DevPassword.Text.Trim()));
        }

        private void ClearItem()
        {
            this.textBox_SurfaceadAccountId.Clear();
            this.textBox_SurfaceadAdID.Clear();
            this.textBox_GoogleBannerID.Clear();
            this.textBox_GoogleChapingID.Clear();
            this.textBox_PubcenterAdID.Clear();
            this.textBox_PubcenterAppID.Clear();
            this.textBox_DevAccount.Clear();
            this.textBox_DevPassword.Clear();
        }

        private void ShowInfo(string msg)
        {
            ((MainForm)this.MdiParent).ShowStatus(msg);
        }

        private void AddGamesForm_Shown(object sender, EventArgs e)
        {
            try
            {
                List<string> pusherNames = HttpDataHelper.GetPusherNames();

                comboBox_PusherName.Items.Clear();
                comboBox_PusherName.Items.AddRange(pusherNames.ToArray());
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

    }
}
