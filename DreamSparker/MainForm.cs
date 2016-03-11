using DreamSparker.Models;
using DreamSparker.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamSparker
{
    public partial class MainForm : Form
    {
        private int _step;

        private List<HotmailAccountMail> _hotmailAccountMailList;
        private List<EduAccountMail> _eduAccountMail;

        private List<DreamSparkerModel> _dreamSparkerModelList;
        private AccountInfo _hotmailModel;

        private int _eduFailCount;
        private int _eduSucCount;
        private int _eduTotalCount;
        private int _currentEduIndex;

        private int _hotmailFailCount;
        private int _hotmailSucCount;
        private int _hotmailTotalCount;
        private int _currentHotmailIndex;

        private enum UrlState
        {
            NeedGoToLoginPage,
            NeedLogin,
            NeedVerfy,
            NeedInputEdu,
            Complate,
            NotComplate,
            AccountError,
            NeedGoToEdu,
            EduDie,
            Success
        }

        //private string _loginUrl = "https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1450859598&rver=6.2.6289.0&wp=MBI_SSL&wreply=https:%2F%2Fwww.dreamspark.com%2Faccount%2Fcreateaccount.aspx%3Fwa%3Dwsignin1.0&lc=2052&id=259848";

        //private string _loginUrl = string.Format("http://www.windowsphone.com/en-US/auth/signin?returnUrl=https%253a%252f%252fwww.windowsphone.com%253a443%252f{0}%252fstore%252fapp%252f{1}%252f{2}%253fsignin%253dtrue"
        //,"zh-cn", "x", "d2b6a184-da39-4c9a-9e0a-8b589b03dec0");
        //,"","","");

        //private string _logoutUrl = "http://www.windowsphone.com/auth/signout";
        //private string _loginUrl = "https://www.dreamspark.com/account/createaccount.aspx?wa=wsignin1.0";

        private string _logoutUrl = "http://login.live.com/logout.srf";
        private string _loginUrl = "https://www.dreamspark.com/Account/MyAccount.aspx?GetVerified=true";
        private string _dreamSparkStudentUrl = "https://www.dreamspark.com/account/createaccount.aspx?wa=wsignin1.0";

        public MainForm()
        {
            InitializeComponent();

            _dreamSparkerModelList = HttpDataHelper.GetEduModelList(0, "空闲中", "");
            _hotmailModel = HttpDataHelper.GetAccountInfoByDevState(1, "不是")[0];

            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;
        }

        void webBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.textBox_CurrentWebBrowserUrl.Text = e.Url.ToString();

            UrlState state = VerifyUrl();

            if (state == UrlState.NeedGoToLoginPage)
            {
                if (_step == 1)
                {
                    GoToLogIn();
                }
            }

            if (state == UrlState.NeedLogin)
            {
                if (_step == 2)
                {
                    Login();
                }
            }

            if (state == UrlState.NeedVerfy)
            {
                if (_step == 3)
                {
                    VerfyCountry();
                }
            }

            if (state == UrlState.NeedGoToEdu)
            {
                if (_step == 4)
                {
                    GoToEdu();
                }
            }

            if (state == UrlState.NeedInputEdu)
            {
                if (_step == 5)
                {
                    AddEdu();
                }
            }

            if (state == UrlState.EduDie)
            {
                if (_step == 6)
                {
                    ChangeEdu();
                }
            }

            if (state == UrlState.Success)
            {
                if (_step == 7)
                {
                    Success();
                }
            }

            if (state == UrlState.AccountError)
            {
                if (_step == 8)
                {
                    HotmailDie();
                }
            }
        }

        private UrlState VerifyUrl()
        {
            webBrowser_Main.Stop();
            if (_step == 0)
            {
                //if ((webBrowser_Main.Url.ToString().StartsWith("http://www.windowsphone.com/") &&
                //    webBrowser_Main.Url.ToString().Length <= 35) ||
                //    (webBrowser_Main.Url.ToString().StartsWith("http://www.microsoft.com/") &&
                //    webBrowser_Main.Url.ToString().Contains("windows/phones") &&
                //    webBrowser_Main.Document.All["Phones-Hero"] != null) ||
                //    webBrowser_Main.Document.All["meControl"] != null)
                if (webBrowser_Main.Url.ToString().StartsWith("http://cn.msn.com/"))
                {
                    _step = 1;
                    return UrlState.NeedGoToLoginPage;
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

                if (webBrowser_Main.Url.ToString().StartsWith("https://www.dreamspark.com/student/default.aspx"))
                {
                    _step = 1;
                    return UrlState.NeedGoToLoginPage;
                }

                if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_LinkButton_SignIn"] != null)
                {
                    webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_LinkButton_SignIn"].InvokeMember("click");
                }

                if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_A_SignOut"] != null)
                {
                    webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_A_SignOut"].InvokeMember("click");
                }
            }

            if (_step == 2)
            {
                HtmlElement country_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_ComboBox_country_TextBox"];
                HtmlElement verfy_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_LinkButton_Continue"];

                if (country_t != null && verfy_t != null)
                {
                    _step = 3;
                    return UrlState.NeedVerfy;
                }

                HtmlElement eduMail_t1 = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_TextBox_SEVSchoolEmailAddress"];
                HtmlElement eduMail_t2 = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_TextBox_SEVRetypeSchoolEmailAddress"];

                if (eduMail_t1 != null && eduMail_t2 != null)
                {
                    _step = 5;
                    return UrlState.NeedInputEdu;
                }

                if ((webBrowser_Main.Document.All["idContinue"] != null &&
                     webBrowser_Main.Document.All["_ft_"] != null) ||
                     webBrowser_Main.Document.All["iSendCode"] != null ||
                     webBrowser_Main.Document.All["StartAction"] != null ||
                     webBrowser_Main.Document.All["DisplayPhoneNumber"] != null)
                {
                    _step = 8;
                    return UrlState.AccountError;
                }
            }

            if (_step == 3)
            {
                HtmlElement updateProgressDiv_t = webBrowser_Main.Document.All["updateProgressDiv"];
                if (updateProgressDiv_t != null && updateProgressDiv_t.OuterHtml.Contains("display: inline;"))
                {
                    _step = 4;
                    return UrlState.NeedGoToEdu;
                }

                HtmlElement StudentBody_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_GetVerifiedTab"];
                if (StudentBody_t != null)
                {
                    _step = 4;
                    return UrlState.NeedGoToEdu;
                }
            }

            if (_step == 4)
            {
                HtmlElement eduMail_t1 = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_TextBox_SEVSchoolEmailAddress"];
                HtmlElement eduMail_t2 = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_TextBox_SEVRetypeSchoolEmailAddress"];

                if (eduMail_t1 != null && eduMail_t2 != null)
                {
                    _step = 5;
                    return UrlState.NeedInputEdu;
                }
            }

            if (_step == 5)
            {
                if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_divMessage"] != null)
                {
                    _step = 6;
                    return UrlState.EduDie;
                }

                HtmlElement tipsElment = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_Div3"];
                if (tipsElment != null && tipsElment.OuterHtml.Contains("style=\"color: green;\""))
                {
                    _step = 7;
                    return UrlState.Success;
                }
            }

            return UrlState.NotComplate;
        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            ShowInfo();
            Logout();
        }

        private void GoToLogIn()
        {
            SetInfo("转向登录页面");
            DisposBrowser();
            this.webBrowser_Main.Navigate(_loginUrl);
        }

        private async void Login()
        {
            try
            {
                SetInfo("执行登录");

                HtmlDocument hd = webBrowser_Main.Document;

                HtmlElement loginTextBox = hd.All["login"] ?? hd.All["loginfmt"];
                HtmlElement passwordTextBox = hd.All["passwd"];

                HtmlElement submitButton = hd.All["SI"];

                loginTextBox.InnerText = _hotmailModel.Account;
                passwordTextBox.InnerText = _hotmailModel.Password;

                submitButton.InvokeMember("click");

                await Task.Delay(TimeSpan.FromSeconds(20));
                if (_step == 2)
                {
                    HtmlElement country_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_ComboBox_country_TextBox"];
                    HtmlElement verfy_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_LinkButton_Continue"];

                    if (country_t != null && verfy_t != null)
                    {
                        _step = 3;
                        VerfyCountry();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void VerfyCountry()
        {
            SetInfo("输入国家");

            HtmlElement country_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_ComboBox_country_TextBox"];
            HtmlElement verfy_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_LinkButton_Continue"];

            HtmlElement c_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_ComboBox_country_OptionList"];

            HtmlElement c_t2 = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_ComboBox_country_HiddenField"];

            c_t2.SetAttribute("value", "47");

            if (country_t != null && verfy_t != null)
            {
                //country_t.SetAttribute("value", "China");

                country_t.InnerText = "China";
            }

            HtmlElement fName_t = webBrowser_Main.Document.All["ctl00$ctl00$ContentPlaceHolder1$StudentBody$TextBox_FName"];
            HtmlElement lName_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_TextBox_LName"];

            HtmlElement month_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_drpCalMonth1_TextBox"];
            HtmlElement year_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_drpCalYear1_TextBox"];

            if (string.IsNullOrWhiteSpace(fName_t.GetAttribute("value")))
            {
                SetInfo("失败,没有名字，日");
                HotmailDie();
                return;
                //fName_t.InnerText = RandomHelper.CreatorZiMu(3, 8);
            }

            if (string.IsNullOrWhiteSpace(lName_t.GetAttribute("value")))
            {
                SetInfo("失败,没有名字，日");
                HotmailDie();
                //lName_t.InnerText = RandomHelper.CreatorZiMu(3, 8);
            }

            //month_t.SetAttribute("value",RandomHelper.CreatorMonth());
            //year_t.SetAttribute("value", new Random().Next(1970, 1990).ToString());

            HtmlElement myCalendar_t = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_myCalendar"];

            List<HtmlElement> daysList = new List<HtmlElement>();

            foreach (HtmlElement a in webBrowser_Main.Document.All)
            {
                if (a.GetAttribute("className").ToLower() == "daystyle")
                {
                    daysList.Add(a);
                }
            }

            //daysList[5].FirstChild.InvokeMember("click");



            //HtmlElement months = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_drpCalMonth1_OptionList"];
            //month_t.Children[5].InvokeMember("click");

            //month_t.InnerText = RandomHelper.CreatorMonth();
            //year_t.InnerText = new Random().Next(1970, 1990).ToString();

            Random rd = new Random();
            int month_i = rd.Next(1, 13);
            int year_i = rd.Next(1986, 1996);

            
            string s = webBrowser_Main.Document.All["ctl00$ctl00$ContentPlaceHolder1$StudentBody$drpCalMonth1$HiddenField"].GetAttribute("value");

            int f_t = 0;
            int.TryParse(s, out f_t);
            if (f_t > 0)
            {
                verfy_t.InvokeMember("click");
            }
            else
            {
                month_t.InnerText = RandomHelper.CreatorMonth(month_i);
                webBrowser_Main.Document.All["ctl00$ctl00$ContentPlaceHolder1$StudentBody$drpCalMonth1$HiddenField"].SetAttribute("value", month_i.ToString());

                year_t.InnerText = year_i.ToString();
                webBrowser_Main.Document.All["ctl00$ctl00$ContentPlaceHolder1$StudentBody$drpCalYear1$HiddenField"].SetAttribute("value", year_i.ToString().Substring(2, 2));


                //await Task.Delay(TimeSpan.FromSeconds(10));
                //daysList[5].FirstChild.Focus();
                //daysList[5].FirstChild.InvokeMember("click");
                //await Task.Delay(TimeSpan.FromMilliseconds(200));
                //daysList[5].FirstChild.InvokeMember("click");

                verfy_t.InvokeMember("click");

                //await Task.Delay(TimeSpan.FromSeconds(10));
                daysList[5].FirstChild.InvokeMember("click");

                //await Task.Delay(TimeSpan.FromSeconds(10));
                //verfy_t.InvokeMember("click");



                await Task.Delay(TimeSpan.FromSeconds(10));
                daysList.Clear();
                foreach (HtmlElement a in webBrowser_Main.Document.All)
                {
                    if (a.GetAttribute("className").ToLower() == "daystyle")
                    {
                        daysList.Add(a);
                    }
                }
                daysList[rd.Next(1, 28)].FirstChild.InvokeMember("click");

                await Task.Delay(TimeSpan.FromSeconds(25));
                verfy_t.InvokeMember("click");


                await Task.Delay(TimeSpan.FromSeconds(10));
                if (_step == 3)
                {
                    daysList.Clear();
                    foreach (HtmlElement a in webBrowser_Main.Document.All)
                    {
                        if (a.GetAttribute("className").ToLower() == "daystyle")
                        {
                            daysList.Add(a);
                        }
                    }
                    daysList[rd.Next(1, 28)].FirstChild.InvokeMember("click");

                    await Task.Delay(TimeSpan.FromSeconds(25));
                    verfy_t.InvokeMember("click");

                }

            }
            /*
            Random rd = new Random();
            int year_s = rd.Next(1970, 1990);
            int month_s = rd.Next(1, 12);
            int day_s = rd.Next(1, 28);

            string a1 = "ctl00_ctl00_ToolkitScriptManager1_HiddenField=" + webBrowser_Main.Document.All["ctl00_ctl00_ToolkitScriptManager1_HiddenField"].GetAttribute("Value");
            string a2 = "ctl00$ctl00$DropDownList_PageLanguage_HiddenFieldValue=" + "zh-CN";
            string a3 = "ctl00$ctl00$DropDownList_PageLanguage$TextBox=" + "English";
            string a4 = "ctl00$ctl00$DropDownList_PageLanguage$HiddenField=" + webBrowser_Main.Document.All["ctl00$ctl00$DropDownList_PageLanguage$HiddenField"].GetAttribute("Value");
            string a5 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$TextBox_FName=" + RandomHelper.CreatorZiMu(3, 8);
            string a6 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$txtCal=" + year_s + "/" + month_s + "/" + day_s;
            string a7 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$drpCalMonth1$TextBox=" + RandomHelper.CreatorMonth(month_s - 1);
            string a8 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$drpCalMonth1$HiddenField=" + month_s;
            string a9 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$drpCalYear1$TextBox=" + year_s;
            string a10 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$drpCalYear1$HiddenField=" + year_s.ToString().Substring(2, 2);

            string a11 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$TextBox_PreferredEmail=" + _hotmailModel.Account;
            string a12 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$TextBox_ConfirmPreferredEmail=" + _hotmailModel.Account;

            string a13 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$ComboBox_Language$TextBox=" + "English";
            string a14 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$ComboBox_Language$HiddenField=" + webBrowser_Main.Document.All["ctl00$ctl00$ContentPlaceHolder1$StudentBody$ComboBox_Language$HiddenField"].GetAttribute("Value");

            string a15 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$ComboBox_country$TextBox=" + "China";
            string a16 = "ctl00$ctl00$ContentPlaceHolder1$StudentBody$ComboBox_country$HiddenField=" + "47";

            string a17 = "ctl00$ctl00$__hndMAPLocale=" + "zh-CN";
            string a18 = "__LASTFOCUS=" + webBrowser_Main.Document.All["__LASTFOCUS"].GetAttribute("Value");
            string a19 = "__EVENTTARGET=" + webBrowser_Main.Document.All["__EVENTTARGET"].GetAttribute("Value");
            string a20 = "__EVENTARGUMENT=" + webBrowser_Main.Document.All["__EVENTARGUMENT"].GetAttribute("Value");
            string a21 = "__VIEWSTATE=" + webBrowser_Main.Document.All["__VIEWSTATE"].GetAttribute("Value");
            string a22 = "__EVENTVALIDATION=" + webBrowser_Main.Document.All["__EVENTVALIDATION"].GetAttribute("Value");

            string aa = a1 + "&" + a2 + "&" + a3 + "&" + a4 + "&" + a5 + "&" + a6 + "&" + a7 + "&" + a8 + "&" + a9 + "&" + a10 + "&" + a11 + "&" +
                        a12 + "&" + a13 + "&" + a14 + "&" + a15 + "&" + a16 + "&" + a17 + "&" + a18 + "&" + a19 + "&" + a20 + "&" + a21 + "&" + a22;

            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            byte[] data = encoding.GetBytes(aa);
            string url = "https://www.dreamspark.com/account/createaccount.aspx?wa=wsignin1.0";

            webBrowser_Main.Navigate(url, string.Empty, data, "Content-Type: application/x-www-form-urlencoded");
             */
        }

        private async void GoToEdu()
        {
            await Task.Delay(TimeSpan.FromSeconds(60));

            if (_step == 4)
            {
                SetInfo("跳转到添加EDU页面");
                this.webBrowser_Main.Navigate(_loginUrl);
            }
        }

        private async void AddEdu()
        {
            SetInfo("添加EDU邮箱");

            HtmlElement eduMail_t1 = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_TextBox_SEVSchoolEmailAddress"];
            HtmlElement eduMail_t2 = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_TextBox_SEVRetypeSchoolEmailAddress"];

            HtmlElement eduButton = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_LinkButton_SchoolEmailVerification"];
            if (eduMail_t1 != null && eduMail_t2 != null && eduButton != null)
            {
                //eduMail_t1.InnerText = _eduAccountMail[_currentEduIndex].EduAccount;
                //eduMail_t2.InnerText = _eduAccountMail[_currentEduIndex].EduAccount;

                eduMail_t1.InnerText = _dreamSparkerModelList[_currentEduIndex].Account;
                eduMail_t2.InnerText = _dreamSparkerModelList[_currentEduIndex].Account;

                eduButton.InvokeMember("click");

                await Task.Delay(TimeSpan.FromSeconds(20));

                if (webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_divMessage"] != null)
                {
                    _step = 6;
                    ChangeEdu();
                }

                HtmlElement tipsElment = webBrowser_Main.Document.All["ctl00_ctl00_ContentPlaceHolder1_StudentBody_userVerificationControl_Div3"];
                if (tipsElment != null && tipsElment.OuterHtml.Contains("style=\"color: green;\""))
                {
                    _step = 7;
                    Success();
                }
            }
        }

        private void ChangeEdu()
        {
            SetInfo("EDU不对，换下一个");

            _eduFailCount++;
            ShowInfo();

            _currentEduIndex++;

            if (_currentEduIndex < _dreamSparkerModelList.Count)
            {
                ShowInfo();
                AddEdu();
            }

            else
            {
                SetInfo("EDU邮箱没有了，结束");
                timer1.Stop();
            }
        }

        private void HotmailDie()
        {
            SetInfo("失败,微软账号被封了，日");
            _hotmailFailCount++;
            HttpDataHelper.UpdateAccounDevState("死了", _hotmailModel.State, _hotmailModel.ID);

            ShowInfo();

            try
            {
                _hotmailModel = HttpDataHelper.GetAccountInfoByDevState(1, "不是")[0];
                ShowInfo();

                Logout();
            }
            catch (Exception ex)
            {
                SetInfo("获取Hotmail失败," + ex.Message);
                timer1.Stop();
            }
        }


        private void Success()
        {
            SetInfo("添加成功");
            try
            {
                HttpDataHelper.UpdateDreamSparkerModel(_dreamSparkerModelList[_currentEduIndex].ID, "已绑定", _hotmailModel.Account, _hotmailModel.Password);
                HttpDataHelper.UpdateAccounDevState("是", _hotmailModel.State, _hotmailModel.ID);

                _eduSucCount++;
                _hotmailSucCount++;
                ShowInfo();

                SetInfo("更新成功");
            }
            catch (Exception ex)
            {
                _hotmailFailCount++;
                _eduFailCount++;
                ShowInfo();

                SetInfo("更新失败," + ex.Message);
            }

            _currentEduIndex++;

            if (_currentEduIndex < _dreamSparkerModelList.Count)
            {
                try
                {
                    _hotmailModel = HttpDataHelper.GetAccountInfoByDevState(1, "不是")[0];
                    ShowInfo();

                    Logout();
                }
                catch (Exception ex)
                {
                    SetInfo("获取Hotmail失败," + ex.Message);
                    timer1.Stop();
                }
            }

            else
            {
                SetInfo("EDU邮箱没有了，结束");
                timer1.Stop();
            }
        }

        private void ShowInfo()
        {
            label_EduCurrentAccount.Text = _dreamSparkerModelList[_currentEduIndex].Account;
            label_EduCurrentCount.Text = _currentEduIndex.ToString();
            label_EduFailCount.Text = _eduFailCount.ToString();
            label_EduSucCount.Text = _eduSucCount.ToString();
            label_EduTotalCount.Text = _dreamSparkerModelList.Count.ToString();

            label_HotmailCurrentAccount.Text = _hotmailModel.Account;
            label_HotmailCurrentCount.Text = "0";
            label_HotmailFailCount.Text = _hotmailFailCount.ToString();
            label_HotmailSucCount.Text = _hotmailSucCount.ToString();
            label_HotmailTotalCount.Text = "0";
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

        private void Logout()
        {
            SetInfo("登出");

            this.timer1.Stop();
            this.timer1.Interval = Convert.ToInt32(this.numericUpDown_Interval.Value) * 1000;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetInfo("超时重来");

            this.timer1.Stop();

            _step = 0;
            this.timer1.Interval = Convert.ToInt32(this.numericUpDown_Interval.Value) * 1000;

            this.webBrowser_Main.Navigate(_logoutUrl);

            this.timer1.Start();
        }

        private void DisposBrowser()
        {
            webBrowser_Main.Stop();
            webBrowser_Main.Dispose();
            webBrowser_Main = new WebBrowser();

            webBrowser_Main.DocumentCompleted -= webBrowser_Main_DocumentCompleted;
            webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;

            webBrowser_Main.Dock = DockStyle.Fill;
            webBrowser_Main.ScriptErrorsSuppressed = true;

            groupBox4.Controls.Add(webBrowser_Main);

        }

        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + ", " + _dreamSparkerModelList[_currentEduIndex].Account + ", "
                                        + _hotmailModel.Account + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            //this.webBrowser_Main.Navigate(_dreamSparkStudentUrl);

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

    }
}
