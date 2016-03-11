using DreamSparkerDevRegister.Models;
using DreamSparkerDevRegister.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamSparkerDevRegister
{
    public partial class DevRegister : Form
    {
        private DreamSparkerModel _dreamSparkerModel;

        public DevRegister()
        {
            InitializeComponent();
            SetButtonBeginState();
        }

        private void button_GetAccount_Click(object sender, EventArgs e)
        {
            try
            {
                _dreamSparkerModel = HttpDataHelper.GetEduModelList(1, "已获取", "")[0];
                this.textBox_DevAccount.Text = _dreamSparkerModel.DevAccount;
                this.textBox_DevPassword.Text = _dreamSparkerModel.DevPassword;
                this.textBox_Token.Text = _dreamSparkerModel.Token;

                string address = CharsHelper.ConvertToPinYin(CharsHelper.GetAddress(), " ").ToLower();
                this.textBox_Address.Text = address.Length > 40 ? address.Substring(0, 40) : address;
                this.textBox_Email.Text = _dreamSparkerModel.DevAccount;
                this.textBox_FirstName.Text = CharsHelper.ConvertToPinYin(CharsHelper.CreateGBChar(1, 2)).ToLower();
                this.textBox_LastName.Text = CharsHelper.ConvertToPinYin(CharsHelper.LastNameGetter()).ToLower();

                string[] cityAndZip = CharsHelper.GetCityAndZipCode().Split(':');
                this.textBox_City.Text = CharsHelper.ConvertToPinYin(cityAndZip[0]).ToLower();
                this.textBox_ZipCode.Text = CharsHelper.ConvertToPinYin(cityAndZip[1]).ToLower();
                this.textBox_PhoneNum.Text = CharsHelper.GetRandomPhoneNum();
                //this.textBox_ShowName.Text = CharsHelper.PasswordCreatorZiMu(6, 12);
                this.textBox_ShowName.Text = CharsHelper.GetRandomDevName(3, 8);

                SetButtonWorkingState();

                SetInfo("获取成功，请登录网址并使用激活码注册");
            }
            catch
            {
                SetInfo("获取失败了,可能是库中没有需要激活的账号了，请再次点击，如果还不行请联系我");
            }
        }

        private void button_ReCreatShowName_Click(object sender, EventArgs e)
        {
            this.textBox_ShowName.Text = CharsHelper.GetRandomDevName(3, 8);
            button_CopyShowName_Click(sender, e);
        }

        private void SetButtonBeginState()
        {
            this.button_GetAccount.Enabled = true;
            this.button_DoneOk.Enabled = false;
            this.button_Die.Enabled = false;
            this.button_ReCreatShowName.Enabled = true;

            this.textBox_DevAccount.Clear();
            this.textBox_DevPassword.Clear();
            this.textBox_Token.Clear();

            this.textBox_Address.Clear();
            this.textBox_City.Clear();
            this.textBox_Email.Clear();
            this.textBox_FirstName.Clear();
            this.textBox_LastName.Clear();
            this.textBox_PhoneNum.Clear();
            this.textBox_ZipCode.Clear();
            this.textBox_ShowName.Clear();
        }

        private void SetButtonWorkingState()
        {
            this.button_GetAccount.Enabled = false;
            this.button_DoneOk.Enabled = true;
            this.button_Die.Enabled = true;
            this.button_ReCreatShowName.Enabled = true;
        }

        private void SetInfo(string msg)
        {
            this.label_info.Text = msg;
        }

        private void button_CopyToken_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Token.Text))
            {
                Clipboard.SetText(this.textBox_Token.Text);
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

        private void button_DoneOk_Click(object sender, EventArgs e)
        {
            try
            {
                HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerModel.ID, "已激活", "", "");
                SetInfo("提交成功,请获取下一个");

                SetButtonBeginState();
            }
            catch
            {
                SetInfo("提交失败，请重试");
            }
        }

        private void button_Die_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定这个账号已经作废了吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerModel.ID, "已作废", "", "");
                    SetInfo("提交成功,请获取下一个");

                    SetButtonBeginState();
                }
            }
            catch
            {
                SetInfo("提交失败，请重试");
            }
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            string s = CharsHelper.CreateGBChar(1, 2);
            string s1 = CharsHelper.LastNameGetter();
            MessageBox.Show(s + ":" + CharsHelper.ConvertToPinYin(s) + Environment.NewLine + s1 + ":" + CharsHelper.ConvertToPinYin(s1));
        }

        private void button_CopyFirstName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_FirstName.Text))
            {
                Clipboard.SetText(this.textBox_FirstName.Text);
            }
        }

        private void button_CopyLastName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_LastName.Text))
            {
                Clipboard.SetText(this.textBox_LastName.Text);
            }
        }

        private void button_CopyEmail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Email.Text))
            {
                Clipboard.SetText(this.textBox_Email.Text);
            }
        }

        private void button_CopyPhoneNum_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_PhoneNum.Text))
            {
                Clipboard.SetText(this.textBox_PhoneNum.Text);
            }
        }

        private void button_CopyAddress_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_Address.Text))
            {
                Clipboard.SetText(this.textBox_Address.Text);
            }
        }

        private void button_CopyCity_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_City.Text))
            {
                Clipboard.SetText(this.textBox_City.Text);
            }
        }

        private void button_CopyZipCode_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_ZipCode.Text))
            {
                Clipboard.SetText(this.textBox_ZipCode.Text);
            }
        }

        private void button_CopyShowName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_ShowName.Text))
            {
                Clipboard.SetText(this.textBox_ShowName.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CharsHelper.FuckChs(@"C:\Users\petto_000\Desktop\fuck1.txt", @"C:\Users\petto_000\Desktop\fuck2.txt");
            MessageBox.Show(CharsHelper.GetRandomDevName(3, 7));
        }


    }
}
