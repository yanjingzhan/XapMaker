using GamesManager.Model;
using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamesManager
{
    public partial class LoginForm : Form
    {
        private string _pusherName, _password;
        private bool _isAutoLogin;

        public LoginForm()
        {
            InitializeComponent();

            if (IsAutoLogin())
            {
                _pusherName = CryptHelper.Decrypt(INIHelper.ReadIniData("Login", "PusherName", "", AppDomain.CurrentDomain.BaseDirectory + "conf.ini"));
                _password = CryptHelper.Decrypt(INIHelper.ReadIniData("Login", "Password", "", AppDomain.CurrentDomain.BaseDirectory + "conf.ini"));
            }

            _isAutoLogin = (!string.IsNullOrEmpty(_pusherName) && !string.IsNullOrEmpty(_password));

            if (_isAutoLogin)
            {
                this.groupBox1.Controls.Remove(label_NowLoading);
                this.groupBox1.Visible = false;

                this.Controls.Add(label_NowLoading);
                label_NowLoading.Visible = true;
            }

            this.Shown += LoginForm_Shown;
        }

        void LoginForm_Shown(object sender, EventArgs e)
        {
            if (_isAutoLogin)
            {
                try
                {
                    PusherUserModel pusher_t = HttpDataHelper.GetOnePusher(_pusherName.Trim());

                    string password = pusher_t.Password;

                    if (password.Trim() == _password.Trim())
                    {
                        GlobalData.GlobalPusherUser = pusher_t;

                        MainForm _mainForm = new MainForm();
                        _mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    label_NowLoading.Visible = false;
                    this.groupBox1.Visible = true;

                    MessageBox.Show("登录失败,请重试或联系管理员");
                }
            }
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            try
            {
                PusherUserModel pusher_t = HttpDataHelper.GetOnePusher(this.textBox_PusherUser.Text.Trim());

                string password = pusher_t.Password;

                if (string.IsNullOrEmpty(password))
                {
                    throw new Exception();
                }

                if (password.Trim() == this.textBox_Password.Text.Trim())
                {
                    _password = password.Trim();
                    _pusherName = this.textBox_PusherUser.Text.Trim();

                    if (checkBox_RememberPassword.Checked)
                    {
                        SaveAutoLogin();
                    }

                    GlobalData.GlobalPusherUser = pusher_t;

                    MainForm _mainForm = new MainForm();
                    _mainForm.Show();
                    this.Hide();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("登录失败,请重试或联系管理员");
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool IsAutoLogin()
        {
            return INIHelper.ReadIniData("Login", "AutoLogin", "0", AppDomain.CurrentDomain.BaseDirectory + "conf.ini") == "1";
        }

        private void SaveAutoLogin()
        {
            INIHelper.WriteIniData("Login", "AutoLogin", "1", AppDomain.CurrentDomain.BaseDirectory + "conf.ini");
            INIHelper.WriteIniData("Login", "PusherName", CryptHelper.Encrypt(_pusherName), AppDomain.CurrentDomain.BaseDirectory + "conf.ini");
            INIHelper.WriteIniData("Login", "Password", CryptHelper.Encrypt(_password), AppDomain.CurrentDomain.BaseDirectory + "conf.ini");
        }

        private void textBox_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                button_Login_Click(sender, e);
            }
        }
    }
}
