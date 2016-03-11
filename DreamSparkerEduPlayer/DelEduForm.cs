using DreamSparkerEduPlayer.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamSparkerEduPlayer
{
    public partial class DelEduForm : Form
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

        private enum UrlState
        {
            NotComplate,
            Success,
            NeedAdminLogin,
            NeedGoToAddPage,
            NeedAddAccount,
            NeedGetDelId,
            NeedGetDelIdAndDel
        }

        //private string _adminMail = "alibaba@xahu.edu.pl";
        private string _adminMail = "songxiaosi@wuyiu.edu.gr";
        private string _adminPassword = "alibabasb";
        private string _aid;

        private string _loginForm = "http://qiye.163.com/login/?from=ym";
        private string _manageMailUrl = "https://app.ym.163.com/ym/action/account/list?aid={0}";
        private string _delMailUrl = "https://app.ym.163.com/ym/action/account/delete?aid={0}&account_id={1}";

        private List<string> _delIdList = new List<string>();

        public DelEduForm()
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
                    GoToManagePage();
                }
            }

            if (state == UrlState.NeedGetDelIdAndDel)
            {
                if (_step == 2)
                {
                    GetDelId();
                }
            }

            if (state == UrlState.Success)
            {
                if (_step == 4)
                {
                    //Successed();
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
                if (webBrowser_Main.Document.All["pages"] != null)
                {
                    //HtmlHelper.GetUserDelId(webBrowser_Main.Url.AbsoluteUri);

                    _step = 2;
                    return UrlState.NeedGetDelIdAndDel;
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

        private void GoToManagePage()
        {
            this.webBrowser_Main.Navigate(string.Format(_manageMailUrl, _aid));
        }

        private void GetDelId()
        {
            foreach (HtmlElement item in webBrowser_Main.Document.All)
            {
                Console.WriteLine(item.GetAttribute("className"));

                if (item.GetAttribute("className").Equals("wd5") && item.InnerHtml.Contains("onclick="))
                {
                    int index_t1 = item.InnerHtml.LastIndexOf("(");
                    int index_t2 = item.InnerHtml.LastIndexOf(")");

                    _delIdList.Add(item.InnerHtml.Substring(index_t1 + 1, index_t2 - index_t1 - 1));
                    break;
                }
            }

            DeleteId();
        }

        private void DeleteId()
        {
            this.webBrowser_Main.Navigate(string.Format(_delMailUrl, _aid, _delIdList[0]));
            _delIdList.Clear();
        }
    }
}
