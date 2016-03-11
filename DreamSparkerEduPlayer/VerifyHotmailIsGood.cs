using DreamSparkerEduPlayer.Models;
using DreamSparkerEduPlayer.Utility;
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

namespace DreamSparkerEduPlayer
{
    public partial class VerifyHotmailIsGood : Form
    {
        private int _step = 0;

        private int _currentSucCount;

        public int CurrentSucCount
        {
            get { return _currentSucCount; }
            set
            {
                _currentSucCount = value;
                this.label_SucCount.Text = _currentSucCount.ToString();
            }
        }

        private int _currentFailCount;

        public int CurrentFailCount
        {
            get { return _currentFailCount; }
            set
            {
                _currentFailCount = value;
                this.label_FailCount.Text = _currentFailCount.ToString();
            }
        }

        private string _currentEduMail;

        public string CurrentEduMail
        {
            get { return _currentEduMail; }
            set
            {
                _currentEduMail = value;
                this.label_CurrentEduMail.Text = _currentEduMail;
            }
        }

        private string _currentPassword;

        public string CurrentPassword
        {
            get { return _currentPassword; }
            set
            {
                _currentPassword = value;
                this.label_CurrentPassword.Text = _currentPassword;
            }
        }

        private string _currentNewPassword;

        public string CurrentNewPassword
        {
            get { return _currentNewPassword; }
            set
            {
                _currentNewPassword = value;
                this.label_NewPassword.Text = CurrentNewPassword;
            }
        }

        private int _currentIndex;
        private List<DreamSparkerModel> _dreamSparkerList;
        private string targetUri = "https://dev.windows.com/overview?from=UHF";
        private string _logoutUrl = "http://login.live.com/logout.srf";

        private enum UrlState
        {
            NotComplate,
            Success,
            NeedLogin,
            NeedNewPassword,
            NeedGoToVerifyPage,
            NeedGoToTokenPage,
            NeedClickGetCode,
            Fail,
            AccountError,
            NeedClickAnotherAccount,
            NeedClickUserMSAccount
        }

        public VerifyHotmailIsGood()
        {
            InitializeComponent();

            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;

            _dreamSparkerList = HttpDataHelper.GetEduModelList(0, "已激活", "") ?? new List<DreamSparkerModel>();
            this.numericUpDown_MaxCount.Value = _dreamSparkerList.Count;

            this.Load += VerifyHotmailIsGood_Load;


        }

        void VerifyHotmailIsGood_Load(object sender, EventArgs e)
        {
            if (INIHelper.ReadIniData("VerifyHotmailIsGood", "AutoRestart", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")) == "1")
            {
                checkBox_RestartEveryTime.Checked = true;
                button_Start_Click(sender, e);
            }
        }

        void webBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.textBox_CurrentUrl.Text = e.Url.ToString();

            UrlState state = VerfyUrl();
            if (state == UrlState.NeedClickAnotherAccount)
            {
                if (_step == 1)
                {
                    ClickAnotherAccount();
                }
            }

            if (state == UrlState.NeedClickUserMSAccount)
            {
                if (_step == 2)
                {
                    ClickUserMSAccount();
                }
            }

            if (state == UrlState.NeedLogin)
            {
                if (_step == 3)
                {
                    Login();
                }
            }

            if (state == UrlState.Fail)
            {
                if (_step == 4)
                {
                    Fail();
                }
            }

            if (state == UrlState.Success)
            {
                if (_step == 5)
                {
                    Success();
                }
            }

            if (state == UrlState.AccountError)
            {
                if (_step == 6)
                {
                    Fail();
                }
            }
        }

        private UrlState VerfyUrl()
        {
            if (_step == 0)
            {
                if (webBrowser_Main.Url.ToString().StartsWith("https://login.microsoftonline.com/common/oauth2/authorize") && webBrowser_Main.Document.All["use_another_account"] != null)
                {
                    _step = 1;
                    return UrlState.NeedClickAnotherAccount;
                }


                if (webBrowser_Main.Document.All["alternative-identity-providers"] != null)
                {
                    _step = 2;
                    return UrlState.NeedClickUserMSAccount;
                }
            }

            if (_step == 1)
            {
                if (webBrowser_Main.Document.All["alternative-identity-providers"] != null)
                {
                    _step = 2;
                    return UrlState.NeedClickUserMSAccount;
                }
            }

            if (_step == 2)
            {
                if ((webBrowser_Main.Document.All["loginfmt"] != null &&
                     webBrowser_Main.Document.All["passwd"] != null &&
                     webBrowser_Main.Document.All["SI"] != null) ||
                     (webBrowser_Main.Document.All["login"] != null &&
                     webBrowser_Main.Document.All["passwd"] != null &&
                     webBrowser_Main.Document.All["SI"] != null))
                {
                    _step = 3;
                    return UrlState.NeedLogin;
                }
            }

            if (_step == 3)
            {
                if (webBrowser_Main.Document.Body.OuterText.Contains("访问受限") ||
                    webBrowser_Main.Document.Body.OuterText.ToLower().Contains("access restricted"))
                {
                    _step = 4;
                    return UrlState.Fail;
                }

                if (webBrowser_Main.Document.Body.OuterText.ToLower().Contains("dashboard") ||
                    webBrowser_Main.Document.Body.OuterText.Contains("仪表板"))
                {
                    _step = 5;
                    return UrlState.Success;
                }


                if ((webBrowser_Main.Document.All["idContinue"] != null &&
                     webBrowser_Main.Document.All["_ft_"] != null) ||
                     webBrowser_Main.Document.All["iSendCode"] != null ||
                     webBrowser_Main.Document.All["StartAction"] != null ||
                     webBrowser_Main.Document.All["DisplayPhoneNumber"] != null)
                {
                    _step = 6;
                    return UrlState.AccountError;
                }
            }

            return UrlState.NotComplate;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            ANewVerify();
        }

        private void ANewVerify()
        {
            _step = 0;

            this.timer1.Stop();
            this.timer1.Interval = Convert.ToInt32(this.numericUpDown_Timeout.Value) * 60 * 1000;
            this.timer1.Start();

            CurrentEduMail = _dreamSparkerList[_currentIndex].DevAccount;
            CurrentPassword = _dreamSparkerList[_currentIndex].DevPassword;

            this.webBrowser_Main.Navigate(targetUri);
        }

        private void ClickAnotherAccount()
        {
            SetInfo("使用其他");

            HtmlElement anotherAccount = webBrowser_Main.Document.All["use_another_account"];
            if (anotherAccount != null)
            {
                anotherAccount.InvokeMember("click");
            }
        }

        private void ClickUserMSAccount()
        {
            SetInfo("使用微软账号");

            HtmlElement anotherAccount = webBrowser_Main.Document.All["alternative-identity-providers"];
            if (anotherAccount != null)
            {
                var userMsA = anotherAccount.GetElementsByTagName("a");
                if (userMsA != null && userMsA.Count > 0)
                {
                    userMsA[0].InvokeMember("click");
                }
            }
        }

        private void Login()
        {
            try
            {
                SetInfo("执行登录");

                HtmlDocument hd = webBrowser_Main.Document;

                HtmlElement loginTextBox = hd.All["login"] ?? hd.All["loginfmt"];
                HtmlElement passwordTextBox = hd.All["passwd"];

                HtmlElement submitButton = hd.All["SI"];

                loginTextBox.InnerText = _dreamSparkerList[_currentIndex].DevAccount;
                passwordTextBox.InnerText = _dreamSparkerList[_currentIndex].DevPassword;

                //loginTextBox.InnerText = "syrrakosgiecgnck@hotmail.com";
                //passwordTextBox.InnerText = "erEth1472763";

                submitButton.InvokeMember("click");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void Fail()
        {
            SetInfo("失败,微软账号被封了，日");
            CurrentFailCount = CurrentFailCount + 1;
            HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerList[_currentIndex].ID, "已被封");

            await Task.Delay(TimeSpan.FromSeconds(Convert.ToInt32(this.numericUpDown_Second.Value)));
            DoneThis();
        }

        private void checkBox_RestartEveryTime_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_RestartEveryTime.Checked)
            {
                INIHelper.WriteIniData("VerifyHotmailIsGood", "AutoRestart", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
            }
        }

        private async void Success()
        {
            SetInfo("成功,微软账号还活着");
            CurrentFailCount = CurrentFailCount + 1;
            HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerList[_currentIndex].ID, "已激活2");

            await Task.Delay(TimeSpan.FromSeconds(Convert.ToInt32(this.numericUpDown_Second.Value)));
            DoneThis();
        }


        private void DoneThis()
        {
            if (checkBox_RestartEveryTime.Checked)
            {
                INIHelper.WriteIniData("VerifyHotmailIsGood", "AutoRestart", "1", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
                System.Windows.Forms.Application.Restart();
            }
            else
            {
                SetInfo("傻逼什么都不做");
            }
        }

        private void Logout()
        {
            SetInfo("登出");
            this.webBrowser_Main.Navigate(_logoutUrl);
        }

        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + ", " + CurrentEduMail + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DoneThis();
        }


    }
}
