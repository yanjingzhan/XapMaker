using DreamSparkerEduPlayer.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamSparkerEduPlayer
{
    public partial class AddEduForm : Form
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

        private enum UrlState
        {
            NotComplate,
            Success,
            NeedAdminLogin,
            NeedGoToAddPage,
            NeedAddAccount
        }

        //private string _adminMail = "alibaba@xahu.edu.pl";
        private string _adminMail = "songxiaosi@wuyiu.edu.gr";
        private string _adminPassword = "alibabasb";
        private string _aid;

        private string _loginForm = "http://qiye.163.com/login/?from=ym";
        private string _addMailUrl = "https://app.ym.163.com/ym/action/account/addview?aid={0}";

        public AddEduForm()
        {
            InitializeComponent();

            this.comboBox_ParentEmailWeb.SelectedIndex = 0;
            this.comboBox_Domain.SelectedIndex = 0;
            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;
        }

        void webBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.textBox_CurrentUrl.Text = e.Url.ToString();

            UrlState state = VerfyUrl();
            if (state == UrlState.NeedAdminLogin)
            {
                if (_step == 1)
                {
                    AdminLogin();
                }
            }

            if (state == UrlState.NeedGoToAddPage)
            {
                if (_step == 2)
                {
                    GoToAddPage();
                }
            }

            if (state == UrlState.NeedAddAccount)
            {
                if (_step == 3)
                {
                    AddAccount();
                }
            }

            if (state == UrlState.Success)
            {
                if (_step == 4)
                {
                    Successed();
                }
            }
        }

        private UrlState VerfyUrl()
        {
            if (_step == 0)
            {
                //accname
                if (webBrowser_Main.Document.All["accname"] != null &&
                   webBrowser_Main.Document.All["accpwd"] != null)
                {
                    _step = 1;
                    return UrlState.NeedAdminLogin;
                }
            }

            if (_step == 1)
            {
                if (webBrowser_Main.Url.ToString().StartsWith("https://app.ym.163.com/ym/action/domain/index"))
                {
                    int index_t = webBrowser_Main.Url.ToString().IndexOf("aid");
                    _aid = webBrowser_Main.Url.ToString().Substring(index_t).Replace("aid=", "");

                    _step = 2;
                    return UrlState.NeedGoToAddPage;
                }
            }

            if (_step == 2)
            {
                if (webBrowser_Main.Document.All["nickname"] != null &&
                    webBrowser_Main.Document.All["account_name"] != null)
                {
                    _step = 3;
                    return UrlState.NeedAddAccount;
                }
            }

            if (_step == 3)
            {
                if (webBrowser_Main.Document.Body.OuterText.Contains("该账号被系统判断为垃圾账号，请注册其他账号"))
                {
                    _step = 3;
                    return UrlState.NeedAddAccount;
                }

                if (webBrowser_Main.Document.Body.OuterText.Contains("添加成功! "))
                {
                    _step = 4;
                    return UrlState.Success;
                }
            }

            return UrlState.NotComplate;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            timer1.Stop();
            timer1.Interval = Convert.ToInt32(numericUpDown_Timeout.Value) * 60 * 1000;

            _step = 0;
            this.webBrowser_Main.Navigate(_loginForm);

            timer1.Start();
        }

        private void AdminLogin()
        {
            HtmlElement adminC = webBrowser_Main.Document.All["accname"];
            HtmlElement passwordC = webBrowser_Main.Document.All["accpwd"];

            HtmlElementCollection tt = webBrowser_Main.Document.All["accountlogin"].GetElementsByTagName("Button");
            HtmlElement loginButton = null;
            foreach (HtmlElement t in tt)
            {
                if (t.TabIndex == 4)
                {
                    loginButton = t;
                }
            }

            adminC.InnerText = _adminMail;
            passwordC.InnerText = _adminPassword;

            loginButton.InvokeMember("click");
        }

        private void GoToAddPage()
        {
            this.webBrowser_Main.Navigate(string.Format(_addMailUrl, _aid));
        }

        private void AddAccount()
        {
            HtmlElement name_t = webBrowser_Main.Document.All["nickname"];
            HtmlElement account_t = webBrowser_Main.Document.All["account_name"];
            HtmlElement password_t = webBrowser_Main.Document.All["pass_re"];
            HtmlElement addbutton_t = webBrowser_Main.Document.All["sub-btn"];

            string name = RandomHelper.CreatorZiMu(5, 14);
            CurrentPassword = RandomHelper.PasswordCreator(3, 4);
            CurrentNewPassword = RandomHelper.PasswordCreator(3, 4);

            CurrentEduMail = name + "@" + this.comboBox_Domain.Text;
            name_t.InnerText = name;
            account_t.InnerText = name;
            password_t.InnerText = CurrentPassword;

            addbutton_t.InvokeMember("click");
        }

        private async void Successed()
        {
            try
            {
                timer1.Stop();
                timer1.Interval = Convert.ToInt32(numericUpDown_Timeout.Value) * 60 * 1000;

                HttpDataHelper.AddDreamSparkerModel(CurrentEduMail, CurrentPassword, CurrentNewPassword, "新注册",
                    string.Empty, string.Empty, this.comboBox_ParentEmailWeb.Text, "", this.comboBox_Domain.Text);

                CurrentSucCount = CurrentSucCount + 1;

                SetInfo("成功");
            }
            catch (Exception ex)
            {
                CurrentFailCount = CurrentFailCount + 1;
                SetInfo("失败," + ex.Message);
            }

            if (CurrentFailCount + CurrentSucCount < Convert.ToInt32(this.numericUpDown_MaxCount.Value))
            {
                timer1.Start();

                await Task.Delay(TimeSpan.FromSeconds(Convert.ToInt32(this.numericUpDown_Second.Value)));

                _step = 2;
                GoToAddPage();
            }
            else
            {
                SetInfo("Ok到了最大值了");
            }
        }

        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + ", " + CurrentEduMail + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetInfo("超时重试");
            Start();
        }
    }
}
