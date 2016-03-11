using DreamSparkerEduPlayer.Models;
using DreamSparkerEduPlayer.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamSparkerEduPlayer
{
    public partial class LoginEduForm : Form
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
        private string _loginForm = "http://qiye.163.com/login/?from=ym";

        public LoginEduForm()
        {
            InitializeComponent();
            _dreamSparkerList = new List<DreamSparkerModel>();

            this.comboBox_ParentEmailWeb.SelectedIndex = 0;
            this.comboBox_Domain.SelectedIndex = 0;
            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;

            _dreamSparkerList = HttpDataHelper.GetEduModelList(0, "新注册", "网易");
            this.numericUpDown_MaxCount.Value = _dreamSparkerList.Count;
        }

        private enum UrlState
        {
            NotComplate,
            Success,
            NeedLogin,
            NeedNewPassword
        }

        void webBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.textBox_CurrentUrl.Text = e.Url.ToString();

            UrlState state = VerfyUrl();
            if (state == UrlState.NeedLogin)
            {
                if (_step == 1)
                {
                    Login();
                }
            }

            if (state == UrlState.NeedNewPassword)
            {
                if (_step == 2)
                {
                    SetNewPassword();
                }
            }

            if (state == UrlState.Success)
            {
                if (_step == 3)
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
                    return UrlState.NeedLogin;
                }
            }

            if (_step == 1)
            {
                if (webBrowser_Main.Document.All["password"] != null &&
                    webBrowser_Main.Document.All["cpassword"] != null)
                {
                    _step = 2;
                    return UrlState.NeedNewPassword;
                }
            }

            if (_step == 2)
            {
                //if (webBrowser_Main.Document.All["dvSuccessMsg"] != null &&
                //    webBrowser_Main.Document.All["frmAddByFilter"] != null)

                if (webBrowser_Main.Url.AbsoluteUri.Contains("http://mail.ym.163.com/jy3/main.jsp?sid="))
                {
                    _step = 3;
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
            _step = 0;
            this.webBrowser_Main.Navigate(_loginForm);

            CurrentPassword = _dreamSparkerList[_currentIndex].Password;
            CurrentNewPassword = _dreamSparkerList[_currentIndex].NewPassword;
            CurrentEduMail = _dreamSparkerList[_currentIndex].Account;
        }

        private void Login()
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

            adminC.InnerText = _dreamSparkerList[_currentIndex].Account;
            passwordC.InnerText = _dreamSparkerList[_currentIndex].Password;

            loginButton.InvokeMember("click");
        }

        private void SetNewPassword()
        {
            HtmlElement password = webBrowser_Main.Document.All["password"];
            HtmlElement passwordC = webBrowser_Main.Document.All["cpassword"];

            HtmlElement accept = webBrowser_Main.Document.All["confirm"];

            HtmlElementCollection tt = webBrowser_Main.Document.GetElementsByTagName("Button");
            HtmlElement loginButton = null;
            foreach (HtmlElement t in tt)
            {
                if (t.GetAttribute("type") == "submit")
                {
                    loginButton = t;
                }
            }

            password.InnerText = _dreamSparkerList[_currentIndex].NewPassword;
            passwordC.InnerText = _dreamSparkerList[_currentIndex].NewPassword;

            accept.SetAttribute("checked", "checked");
            loginButton.InvokeMember("click");
        }

        private async void Successed()
        {
            try
            {
                HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerList[_currentIndex].ID, "空闲中");

                CurrentSucCount = CurrentSucCount + 1;
                SetInfo("成功");
            }
            catch (Exception ex)
            {
                CurrentFailCount = CurrentFailCount + 1;
                SetInfo("失败," + ex.Message);
            }

            await Task.Delay(TimeSpan.FromSeconds(Convert.ToInt32(this.numericUpDown_Second.Value)));
            _currentIndex++;

            if (_currentIndex < _dreamSparkerList.Count)
            {
                Start();
            }
            else
            {
                SetInfo("弄完了");
            }
        }

        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + ", " + CurrentEduMail + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }
    }
}