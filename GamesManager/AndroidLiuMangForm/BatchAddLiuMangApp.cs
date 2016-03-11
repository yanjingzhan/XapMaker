using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamesManager.AndroidLiuMangForm
{
    public partial class BatchAddLiuMangApp : Form
    {

        private Random _myRd = new Random();
        public BatchAddLiuMangApp()
        {
            InitializeComponent();
        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            string[] sanliulingIds = this.textBox_SanLiuLingIds.Text.Split('\n');

            foreach (var id in sanliulingIds)
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    string detailAddress_t = "http://zhushou.360.cn/detail/index/soft_id/" + id.Trim();


                    string gameName_t = string.IsNullOrWhiteSpace(this.textBox_GameName_Add.Text)
                                    ? RandomHelper.PasswordCreatorZiMu(_myRd, 10) : this.textBox_GameName_Add.Text;

                    HttpDataHelper.AndroidAddLiuMangPushGameInfo(gameName_t, RandomHelper.GetPackageName(),
                                                                 this.textBox_IadAppKey_Add.Text, this.textBox_JingZhongAppId_Add.Text,
                                                                 detailAddress_t, this.textBox_AppType_Add.Text);
                }
            }

            MessageBox.Show("完成");
        }
    }
}
