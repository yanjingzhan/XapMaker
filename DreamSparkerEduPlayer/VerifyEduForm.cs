using DreamSparkerEduPlayer.Models;
using DreamSparkerEduPlayer.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamSparkerEduPlayer
{
    public partial class VerifyEduForm : Form
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

        private string _verifyUrl;
        private string _logoutUrl = "http://login.live.com/logout.srf";
        private string _tokenUrl = "https://www.dreamspark.com/Student/Windows-Store-Access.aspx";

        public VerifyEduForm()
        {
            InitializeComponent();

            this.comboBox_Domain.SelectedIndex = 0;
            this.comboBox_ParentEmailWeb.SelectedIndex = 0;
            //MailHelper mail = new MailHelper("pop.ym.163.com", "alibaba@xahu.edu.pl", "alibabasb");
            //List<MailModel> mailList = mail.GetMailList();

            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;

            _dreamSparkerList = HttpDataHelper.GetEduModelList(0, "已绑定", "") ?? new List<DreamSparkerModel>();
            this.numericUpDown_MaxCount.Value = _dreamSparkerList.Count;
        }

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
            AccountError
        }

        void webBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.textBox_CurrentUrl.Text = e.Url.ToString();

            UrlState state = VerfyUrl();
            if (state == UrlState.NeedGoToVerifyPage)
            {
                if (_step == 1)
                {
                    GoToVerify();
                }
            }

            if (state == UrlState.NeedLogin)
            {
                if (_step == 2)
                {
                    Login();
                }
            }

            if (state == UrlState.NeedGoToTokenPage)
            {
                if (_step == 3)
                {
                    if (checkBox_CheckHotmail.Checked)
                    {
                        HotmailIsGood();
                    }
                    else
                    {
                        GoToTokenPage();
                    }
                }
            }

            if (state == UrlState.NeedClickGetCode)
            {
                if (_step == 4)
                {
                    if (checkBox_CheckHotmail.Checked)
                    {
                        HotmailIsGood();
                    }
                    else
                    {
                        ClickGetCode();
                    }
                }
            }

            if (state == UrlState.Success)
            {
                if (_step == 5)
                {
                    if (checkBox_CheckHotmail.Checked)
                    {
                        HotmailIsGood();
                    }
                    else
                    {
                        GetToken();
                    }
                }
            }

            if (state == UrlState.Fail)
            {
                if (_step == 6)
                {
                    if (checkBox_CheckHotmail.Checked)
                    {
                        HotmailIsGood();
                    }
                    else
                    {
                        Fail();
                    }
                }
            }


            if (state == UrlState.AccountError)
            {
                if (_step == 7)
                {
                    HotmailDie();
                }
            }
        }

        private UrlState VerfyUrl()
        {
            if (_step == 0)
            {
                if (webBrowser_Main.Url.ToString().StartsWith("http://cn.msn.com/"))
                {
                    _step = 1;
                    return UrlState.NeedGoToVerifyPage;
                }
            }

            if (_step == 1)
            {
                if ((webBrowser_Main.Document.All["loginfmt"] != null &&
                     webBrowser_Main.Document.All["passwd"] != null &&
                     webBrowser_Main.Document.All["SI"] != null) ||
                     (webBrowser_Main.Document.All["login"] != null &&
                     webBrowser_Main.Document.All["passwd"] != null &&
                     webBrowser_Main.Document.All["SI"] != null))
                {
                    _step = 2;
                    return UrlState.NeedLogin;
                }

                //if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_LinkButton_SignIn"] != null)
                //{
                //    webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_LinkButton_SignIn"].InvokeMember("click");
                //}

                if (webBrowser_Main.Url.ToString().StartsWith("https://www.dreamspark.com/student/default.aspx"))
                {
                    _step = 1;
                    return UrlState.NeedGoToVerifyPage;
                }

                if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_A_SignOut"] != null)
                {
                    webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_A_SignOut"].InvokeMember("click");
                    //_step = 1;
                    //return UrlState.NeedGoToVerifyPage;
                }
            }

            if (_step == 2)
            {
                if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_divVerificationSucess"] != null)
                {
                    if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_divVerificationSucess"].OuterHtml.Contains("style=\"width: 100%; text-align: center; display: none;\""))
                    {
                        _step = 6;
                        return UrlState.Fail;
                    }
                    else
                    {
                        _step = 3;
                        return UrlState.NeedGoToTokenPage;
                    }
                }

                //if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_LinkButtonOk"] != null)
                //{
                //    _step = 3;
                //    return UrlState.NeedGoToTokenPage;
                //}

                //if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_LinkButton_FailureContinue"] != null)
                //{
                //    _step = 6;
                //    return UrlState.Fail;
                //}

                if (webBrowser_Main.Document.Body.OuterText.Contains("We're sorry, the resource you are looking for is unavailable at this time."))
                {
                    _step = 6;
                    return UrlState.Fail;
                }

                if ((webBrowser_Main.Document.All["idContinue"] != null &&
                     webBrowser_Main.Document.All["_ft_"] != null) ||
                     webBrowser_Main.Document.All["iSendCode"] != null ||
                     webBrowser_Main.Document.All["StartAction"] != null ||
                     webBrowser_Main.Document.All["DisplayPhoneNumber"] != null)
                {
                    _step = 7;
                    return UrlState.AccountError;
                }

                if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_ComboBox_country_TextBox"] != null &&
                    webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_LinkButton_Continue"] != null)
                {
                    _step = 6;
                    return UrlState.Fail;
                }

                HtmlElement he = webBrowser_Main.Document.All["iShowSkip"];
                if (he != null)
                {
                    he.InvokeMember("click");
                }

                he = webBrowser_Main.Document.All["iNext"];
                if (webBrowser_Main.Document.All["iAccrualForm"] != null && he != null)
                {
                    he.InvokeMember("click");
                }

                he = webBrowser_Main.Document.All["iLandingViewAction"];
                if (he != null)
                {
                    he.InvokeMember("click");
                }
            }

            if (_step == 3)
            {
                if (webBrowser_Main.Document.All["LinkButton_GetCode"] != null &&
                     webBrowser_Main.Document.All["divProdRegistered"] != null)
                {
                    _step = 4;
                    return UrlState.NeedClickGetCode;
                }
            }

            if (_step == 4)
            {
                Regex reg = new Regex(@"[a-zA-Z0-9]{5}-[a-zA-Z0-9]{5}-[a-zA-Z0-9]{5}-[a-zA-Z0-9]{5}-[a-zA-Z0-9]{5}");

                if (reg.IsMatch(webBrowser_Main.Document.All["divProdRegistered"].InnerHtml))
                {
                    _step = 5;
                    return UrlState.Success;
                }

            }

            return UrlState.NotComplate;
        }


        private string GetVerifyUrl()
        {
            SetInfo("获取邮件……");

            //test
            if (checkBox_CheckHotmail.Checked)
            {
                return "https://www.verify.microsoft.com/api/v1/emailvalidation/activate/0d01da60-ad67-433f-96bd-1e0e36384456";
            }

            string result = string.Empty;

            //MailHelper mail = new MailHelper("pop.ym.163.com", "alibaba@xahu.edu.pl", "alibabasb");

            string popAdd = this.comboBox_Domain.Text.ToLower() == "xahu.edu.pl" ? "pop.ym.163.com" : "pop3." + this.comboBox_Domain.Text;

            MailHelper mail = new MailHelper(popAdd, _dreamSparkerList[_currentIndex].Account, _dreamSparkerList[_currentIndex].NewPassword);

            List<MailModel> mailList = mail.GetMailList();

            if (mailList != null && mailList.Count > 0)
            {
                foreach (var m in mailList)
                {
                    if (m.FromMail.ToLower() == "msave@microsoft.com" && m.Body.Contains("https://www.verify.microsoft.com"))
                    {
                        int index_t1 = m.Body.IndexOf("https://www.verify.microsoft.com");
                        int index_t2 = m.Body.IndexOf("<br", index_t1);

                        result = m.Body.Substring(index_t1, index_t2 - index_t1);

                        SetInfo("拿到验证地址," + result);
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                SetInfo("没拿到地址，试验下一个");

                _currentIndex++;
                if (_currentIndex < _dreamSparkerList.Count)
                {
                    GoToVerify();
                }
                else
                {
                    SetInfo("完成了");
                }
            }

            return result;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void GoToVerify()
        {
            SetInfo("跳到验证页面");
            ShowInfo();

            _verifyUrl = GetVerifyUrl();

            this.webBrowser_Main.Navigate(_verifyUrl);
        }

        private void Logout()
        {
            ShowInfo();

            SetInfo("登出");

            this.timer1.Stop();
            this.timer1.Interval = Convert.ToInt32(this.numericUpDown_Timeout.Value) * 60 * 1000;

            _step = 0;

            if (checkBox_KillIE.Checked)
            {
                KillIE();
            }

            if (checkBox_KillAnQuan.Checked)
            {
                KillAnQuanWindow();
            }

            this.webBrowser_Main.Navigate(_logoutUrl);

            this.timer1.Start();
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

                submitButton.InvokeMember("click");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GoToTokenPage()
        {
            SetInfo("跳到Token页面");
            this.webBrowser_Main.Navigate(_tokenUrl);
        }


        private void ClickGetCode()
        {
            SetInfo("点击获取Token");
            HtmlElement getCode = webBrowser_Main.Document.All["LinkButton_GetCode"];

            getCode.InvokeMember("click");
        }


        private void GetToken()
        {
            SetInfo("去拿Token");
            Regex reg = new Regex(@"[a-zA-Z0-9]{5}-[a-zA-Z0-9]{5}-[a-zA-Z0-9]{5}-[a-zA-Z0-9]{5}-[a-zA-Z0-9]{5}");

            if (reg.IsMatch(webBrowser_Main.Document.All["divProdRegistered"].InnerHtml))
            {
                _dreamSparkerList[_currentIndex].Token = reg.Match(webBrowser_Main.Document.All["divProdRegistered"].InnerHtml).Value;
                SaveTokenToServer();
            }
        }

        private async void SaveTokenToServer()
        {
            try
            {
                HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerList[_currentIndex].ID, "已获取", _dreamSparkerList[_currentIndex].Token);

                SetInfo("信息更新到服务器成功");

                CurrentSucCount = CurrentSucCount + 1;
            }
            catch (Exception ex)
            {
                SetInfo("失败，" + ex.Message);
                CurrentFailCount = CurrentFailCount + 1;
            }

            await Task.Delay(TimeSpan.FromSeconds(Convert.ToInt32(this.numericUpDown_Second.Value)));
            DoneThis();
        }

        private void Fail()
        {
            SetInfo("失败,验证学术状态失败,本不太可能，但却发生了");

            HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerList[_currentIndex].ID, "已作废");
            SetInfo("信息更新到服务器成功");

            CurrentFailCount = CurrentFailCount + 1;
            DoneThis();
        }


        private async void HotmailDie()
        {
            SetInfo("失败,微软账号被封了，日");
            CurrentFailCount = CurrentFailCount + 1;
            HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerList[_currentIndex].ID, "已作废");

            await Task.Delay(TimeSpan.FromSeconds(Convert.ToInt32(this.numericUpDown_Second.Value)));
            DoneThis();
        }

        private async void HotmailIsGood()
        {
            try
            {
                HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerList[_currentIndex].ID, "已激活2", _dreamSparkerList[_currentIndex].Token);

                SetInfo("信息更新到服务器成功");

                CurrentSucCount = CurrentSucCount + 1;
            }
            catch (Exception ex)
            {
                SetInfo("失败，" + ex.Message);
                CurrentFailCount = CurrentFailCount + 1;
            }

            await Task.Delay(TimeSpan.FromSeconds(Convert.ToInt32(this.numericUpDown_Second.Value)));
            DoneThis();
        }

        private void DoneThis()
        {
            _currentIndex++;

            if (_currentIndex < _dreamSparkerList.Count)
            {
                Logout();
            }
            else
            {
                SetInfo("全部完成了！！！！！！！");
                timer1.Stop();
            }
        }

        private void ShowInfo()
        {
            CurrentPassword = _dreamSparkerList[_currentIndex].Password;
            CurrentNewPassword = _dreamSparkerList[_currentIndex].NewPassword;
            CurrentEduMail = _dreamSparkerList[_currentIndex].Account;

            this.label_HotmailAccount.Text = _dreamSparkerList[_currentIndex].DevAccount;
            this.label_HotmailPassword.Text = _dreamSparkerList[_currentIndex].DevPassword;
        }

        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + ", " + CurrentEduMail + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetInfo("超时重来");
            Logout();
        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private int WM_CLICK = 0x00F5;

        private void KillAnQuanWindow()
        {
            IntPtr hwnd = FindWindow(null, "Windows 安全警告");
            if (hwnd != IntPtr.Zero)
            {
                IntPtr btnhwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "是(&Y)");
                if (btnhwnd != IntPtr.Zero)
                {
                    SendMessage(btnhwnd, WM_CLICK, 0, 0);//先移上去  
                    SendMessage(btnhwnd, WM_CLICK, 0, 0);//再点击  
                }
            }
            IntPtr hwndweb = FindWindow(null, "Web 浏览器");
            if (hwndweb != IntPtr.Zero)
            {
                IntPtr btnhwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "是(&Y)");
                if (btnhwnd != IntPtr.Zero)
                {
                    SendMessage(btnhwnd, WM_CLICK, 0, 0);
                    SendMessage(btnhwnd, WM_CLICK, 0, 0);
                }
            }
        }

        private void KillIE()
        {
            try
            {
                foreach (Process thisproc in Process.GetProcessesByName("iexplore"))
                {
                    //if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
            }
            catch
            {

            }
        }

    }
}
