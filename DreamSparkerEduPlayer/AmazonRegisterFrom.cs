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
    public partial class AmazonRegisterFrom : Form
    {
        private DreamSparkerModel _currentDreamSparkerModel;

        public int SucCount
        {
            set
            {
                this.label_SucCount.Text = value.ToString();
            }
            get { return int.Parse(this.label_SucCount.Text); }
        }

        public int FailCount
        {
            set
            {
                this.label_FailCount.Text = value.ToString();
            }
            get { return int.Parse(this.label_FailCount.Text); }
        }

        private enum UrlState
        {
            NotComplate,
            Success,
            NeedLogin,
            NeedReg,
            NeedGoToReg,
            NeedRegAgain,
            NeedInputInfo,
            NeedAccept,
            NeedPaymentSave
        }

        private int _step = 0;

        private string _logoutPageUrl = "https://developer.amazon.com/logout.html";
        private string _regPagUrl = "https://developer.amazon.com/login";

        public AmazonRegisterFrom()
        {
            InitializeComponent();
            this.Load += AmazonRegisterFrom_Load;
            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;
        }

        void AmazonRegisterFrom_Load(object sender, EventArgs e)
        {
            GetNewModel();
            if(INIHelper.ReadIniData("AmazonRegisterFrom", "AutoRestart", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")) == "1")
            {
                checkBox_RestartEveryTime.Checked = true;
                button_Start_Click(sender,e);
            }
        }

        void webBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.textBox_CurrentUrl.Text = e.Url.ToString();

            UrlState state = VerfyUrl();
            if (state == UrlState.NeedGoToReg)
            {
                if (_step == 1)
                {
                    GoToReg();
                }
            }

            if (state == UrlState.NeedReg)
            {
                if (_step == 2)
                {
                    Reg();
                }
            }

            if (state == UrlState.NeedRegAgain)
            {
                if (_step == 3)
                {
                    RegAgain();
                }
            }

            if (state == UrlState.NeedInputInfo)
            {
                if (_step == 4)
                {
                    InputInfo();
                }
            }

            if (state == UrlState.NeedAccept)
            {
                if (_step == 5)
                {
                    Accept();
                }
            }

            if (state == UrlState.NeedPaymentSave)
            {
                if (_step == 6)
                {
                    PaymentSave();
                }
            }

            if (state == UrlState.Success)
            {
                if (_step == 7)
                {
                    Success();
                }
            }
        }

        private UrlState VerfyUrl()
        {
            if (_step == 0)
            {
                if (webBrowser_Main.Url.ToString().Contains("https://developer.amazon.com/appsandservices"))
                {
                    _step = 1;
                    return UrlState.NeedGoToReg;
                }
            }

            if (_step == 1)
            {
                if (webBrowser_Main.Document.All["ap_email"] != null && webBrowser_Main.Document.All["ap_signin_create_radio"] != null)
                {
                    _step = 2;
                    return UrlState.NeedReg;
                }
            }

            if (_step == 2)
            {
                if (webBrowser_Main.Document.All["customerName"] != null && webBrowser_Main.Document.All["continue-input"] != null)
                {
                    _step = 3;
                    return UrlState.NeedRegAgain;
                }
            }

            if (_step == 3)
            {
                if (webBrowser_Main.Document.All["country"] != null && webBrowser_Main.Document.All["city"] != null)
                {
                    _step = 4;
                    return UrlState.NeedInputInfo;
                }
            }

            if (_step == 4)
            {
                if (webBrowser_Main.Document.All["submit_button"] != null)
                {
                    _step = 5;
                    return UrlState.NeedAccept;
                }
            }

            if (_step == 5)
            {
                if (webBrowser_Main.Document.All["submit_button"] != null)
                {
                    _step = 6;
                    return UrlState.NeedPaymentSave;
                }
            }

            if (_step == 6)
            {
                if (webBrowser_Main.Document.All["add_new_app"] != null)
                {
                    _step = 7;
                    return UrlState.Success;
                }
            }
            return UrlState.NotComplate;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            GoToLogOut();
        }

        int _failCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            SetInfo("超时重来了");

            if (_failCount < 5)
            {
                _failCount++;
                GoToLogOut();
            }
            else
            {
                Fail();
                _failCount = 0;
            }
        }

        private async void GoToLogOut()
        {
            SetInfo("登出");

            _step = 0;
            this.timer1.Stop();
            this.timer1.Interval = Convert.ToInt32(this.numericUpDown_Second.Value) * 1000;

            int wait = new Random().Next((int)numericUpDown_Minute.Value - 5, (int)numericUpDown_Minute.Value + 2);

            SetInfo(string.Format("延时{0}分钟开始", wait));
            //await Task.Delay(TimeSpan.FromMinutes(wait));
            SetInfo(string.Format("延时{0}分钟结束", wait));

            if(checkBox_ClearCookie.Checked)
            {
                SetInfo("清除Cookie");
                SystemHelper.IEclear2();
            }

            ReCreateWebBrowser();

            this.webBrowser_Main.Navigate(_logoutPageUrl);

            this.timer1.Start();
        }

        private void GoToReg()
        {
            SetInfo("去注册页面");
            this.webBrowser_Main.Navigate(_regPagUrl);
        }

        private void Reg()
        {
            SetInfo("执行注册");
            HtmlElement emailElement = webBrowser_Main.Document.All["ap_email"];
            HtmlElement createElement = webBrowser_Main.Document.All["ap_signin_create_radio"];
            HtmlElement createButtonElement = webBrowser_Main.Document.All["signInSubmit-input"];


            if (emailElement != null && createElement != null)
            {
                createElement.InvokeMember("click");
                emailElement.InnerText = _currentDreamSparkerModel.Account;

                createButtonElement.InvokeMember("click");
            }
        }

        private void RegAgain()
        {
            SetInfo("执行二次注册");
            HtmlElement customerNameElement = webBrowser_Main.Document.All["customerName"];
            HtmlElement ap_emailElement = webBrowser_Main.Document.All["ap_email"];
            HtmlElement ap_email_checkElement = webBrowser_Main.Document.All["ap_email_check"];

            HtmlElement ap_passwordElement = webBrowser_Main.Document.All["ap_password"];
            HtmlElement ap_password_checkElement = webBrowser_Main.Document.All["ap_password_check"];
            HtmlElement continue_inputElement = webBrowser_Main.Document.All["continue-input"];


            if (customerNameElement != null && ap_passwordElement != null)
            {
                int t = _currentDreamSparkerModel.Account.IndexOf("@");
                customerNameElement.InnerText = _currentDreamSparkerModel.Account.Substring(0, t);
                ap_emailElement.InnerText = _currentDreamSparkerModel.Account;
                ap_email_checkElement.InnerText = _currentDreamSparkerModel.Account;

                string password = RandomHelper.PasswordCreator(3, 4);
                ap_passwordElement.InnerText = password;
                ap_password_checkElement.InnerText = password;

                _currentDreamSparkerModel.DevAccount = _currentDreamSparkerModel.Account;
                _currentDreamSparkerModel.DevPassword = password;

                ShowLableInfo();
                SetInfo(string.Format("生成账号密码 {0}，{1}", _currentDreamSparkerModel.DevAccount, password));

                continue_inputElement.InvokeMember("click");
            }
        }

        private async void InputInfo()
        {
            SetInfo("执行信息添加");

            if (webBrowser_Main.Document.All["country"] != null && webBrowser_Main.Document.All["city"] != null)
            {
                Random rd = new Random();
                int index_t = rd.Next(1, 90);
                while (index_t == 45)
                {
                    index_t = rd.Next(1, 90);
                }

                webBrowser_Main.Document.All["country"].SetAttribute("selectedIndex", index_t.ToString());

                await Task.Delay(TimeSpan.FromSeconds(6));

                webBrowser_Main.Document.All["lname"].InnerText = RandomHelper.CreatorZiMu(4, 8);
                webBrowser_Main.Document.All["phone"].InnerText = RandomHelper.GetRandomPhoneNum();
                webBrowser_Main.Document.All["developer"].InnerText = RandomHelper.GetRandomDevName(3, 8);
                webBrowser_Main.Document.All["address1"].InnerText = RandomHelper.CreatorZiMu(4, 8) + " " + RandomHelper.CreatorZiMu(2, 8) + " " + RandomHelper.CreatorZiMu(2, 8);
                webBrowser_Main.Document.All["city"].InnerText = RandomHelper.CreatorZiMu(4, 10);
                //webBrowser_Main.Document.All["stateSelection"].SetAttribute("selectedIndex", rd.Next(0,50).ToString());

                webBrowser_Main.Document.All["stateText"].InnerText = RandomHelper.CreatorZiMu(4, 10);
                webBrowser_Main.Document.All["zip"].InnerText = RandomHelper.GetRandomZipCode(5, 6);

                webBrowser_Main.Document.All["submit_button"].InvokeMember("click");
            }
        }

        private async void Accept()
        {
            SetInfo("选择接受");

            if (webBrowser_Main.Document.All["submit_button"] != null)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                webBrowser_Main.Document.All["submit_button"].InvokeMember("click");
            }
        }

        private async void PaymentSave()
        {
            SetInfo("Payment提交");

            if (webBrowser_Main.Document.All["submit_button"] != null)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                webBrowser_Main.Document.All["submit_button"].InvokeMember("click");
            }

        }

        private void Success()
        {
            SetInfo("成功");

            try
            {
                this.timer1.Stop();
                this.timer1.Interval = Convert.ToInt32(this.numericUpDown_Second.Value) * 1000;


                HttpDataHelper.UpdateDreamSparkerModel(_currentDreamSparkerModel.ID, "amazon已激活",
                    _currentDreamSparkerModel.DevAccount, _currentDreamSparkerModel.DevPassword);

                SucCount = SucCount + 1;

                SetInfo("成功");
            }
            catch (Exception ex)
            {
                FailCount = FailCount + 1;
                SetInfo("失败," + ex.Message);
            }

            if(checkBox_RestartEveryTime.Checked)
            {
                INIHelper.WriteIniData("AmazonRegisterFrom","AutoRestart","1",Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"conf.ini"));
                System.Windows.Forms.Application.Restart();
            }

            GetNewModel();

            if (_currentDreamSparkerModel != null)
            {
                GoToLogOut();
            }
            else
            {
                SetInfo("没获取到新账号，停止");
            }
        }

        private void Fail()
        {
            SetInfo("失败");

            try
            {
                this.timer1.Stop();
                this.timer1.Interval = Convert.ToInt32(this.numericUpDown_Second.Value) * 1000;


                HttpDataHelper.UpdateDreamSparkerModel(_currentDreamSparkerModel.ID, "amazon已作废");
                FailCount = FailCount + 1;
            }
            catch (Exception ex)
            {
                FailCount = FailCount + 1;
                SetInfo("失败," + ex.Message);
            }

            if (checkBox_RestartEveryTime.Checked)
            {
                INIHelper.WriteIniData("AmazonRegisterFrom", "AutoRestart", "1", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
                System.Windows.Forms.Application.Restart();
            }

            GetNewModel();

            if (_currentDreamSparkerModel != null)
            {
                GoToLogOut();
            }
            else
            {
                SetInfo("没获取到新账号，停止");
            }
        }

        private void GetNewModel()
        {
            try
            {
                SetInfo("获取新的账号");

                _currentDreamSparkerModel = HttpDataHelper.GetOneEduModelList(1, "amazon空闲中");

                //test
                _currentDreamSparkerModel = new DreamSparkerModel { 
                    DevAccount = "testchagn@126.com",
                    DevPassword = "testchange",
                    Account = "testchagn@126.com",
                    Password = "testchange",
                    NewPassword = "testchange",
                };
                ShowLableInfo();
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }

        private void ReCreateWebBrowser()
        {
            webBrowser_Main.Stop();
            webBrowser_Main.Dispose();
            webBrowser_Main = new WebBrowser();

            webBrowser_Main.DocumentCompleted -= webBrowser_Main_DocumentCompleted;
            webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;

            webBrowser_Main.Dock = DockStyle.Fill;
            webBrowser_Main.ScriptErrorsSuppressed = true;

            panel3.Controls.Add(webBrowser_Main);
        }

        private void ShowLableInfo()
        {
            this.label_CurrentEduMail.Text = _currentDreamSparkerModel.Account;
            this.label_CurrentPassword.Text = _currentDreamSparkerModel.DevPassword;
        }

        private void SetInfo(string msg)
        {
            string account = _currentDreamSparkerModel == null ? string.Empty : _currentDreamSparkerModel.Account + ",";
            this.textBox_Info.AppendText(DateTime.Now.ToString() + "," + account + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }

        private void checkBox_RestartEveryTime_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_RestartEveryTime.Checked)
            {
                INIHelper.WriteIniData("AmazonRegisterFrom", "AutoRestart", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini"));
            }
        }

        private void checkBox_ClearCookie_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
