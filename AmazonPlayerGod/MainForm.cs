using AmazonPlayerGod.Models;
using AmazonPlayerGod.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmazonPlayerGod
{
    public partial class MainForm : Form
    {
        private int _step = 0;
        PushGameInfoModel _pushGameInfo;

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

        private string _logoutPageUrl = "https://developer.amazon.com/logout.html";
        private string _appIDInStore = "";

        public MainForm()
        {
            InitializeComponent();
                        
            this.webBrowser_Main.DocumentCompleted += webBrowser_Main_DocumentCompleted;
            GetNewModel();
        }

        void webBrowser_Main_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.textBox_CurrentUrl.Text = e.Url.ToString();
            UrlState state = VerfyUrl();

            if (state == UrlState.NeedGoToLogin)
            {
                if (_step == 1)
                {
                    GoToLogin();
                }
            }

            if (state == UrlState.NeedLogin)
            {
                if (_step == 2)
                {
                    Login();
                }
            }

            if (state == UrlState.NeedGoToNewAppPage)
            {
                if (_step == 3)
                {
                    GoToNewAppPage();
                }
            }

            if (state == UrlState.NeedAddGameTitleAndType)
            {
                if (_step == 4)
                {
                    AddGameTitleAndType();
                }
            }

            if (state == UrlState.NeedGoToAvailabilityPage)
            {
                if (_step == 5)
                {
                    GoToAvailabilityPage();
                }
            }

            if (state == UrlState.NeedSetAvailability)
            {
                if (_step == 6)
                {
                    SetAvailability();
                }
            }

            if (state == UrlState.NeedGoToDescriptionPage)
            {
                if (_step == 7)
                {
                    GoToDescriptionPage();
                }
            }

            if (state == UrlState.NeedAddDescription)
            {
                if (_step == 8)
                {
                    AddDescription();
                }
            }

            if (state == UrlState.NeedGoToRatingPage)
            {
                if (_step == 9)
                {
                    GoToRatingPage();
                }
            }

            if (state == UrlState.NeedAddRating)
            {
                if (_step == 10)
                {
                    AddRating();
                }
            }

            if (state == UrlState.Success)
            {
                if (_step == 11)
                {
                    Successed();
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
                    return UrlState.NeedGoToLogin;
                }
            }

            if (_step == 1)
            {
                if (webBrowser_Main.Document.All["ap_email"] != null && webBrowser_Main.Document.All["ap_password"] != null)
                {
                    _step = 2;
                    return UrlState.NeedLogin;
                }
            }

            if (_step == 2)
            {
                if (webBrowser_Main.Document.All["add_new_app_combo"] != null)
                {
                    _step = 3;
                    return UrlState.NeedGoToNewAppPage;
                }
            }

            if (_step == 3)
            {
                if (webBrowser_Main.Document.All["selectedTitleCategory"] != null && webBrowser_Main.Document.All["title"] != null && webBrowser_Main.Document.All["submit_button"] != null)
                {
                    _step = 4;
                    return UrlState.NeedAddGameTitleAndType;
                }
            }

            if (_step == 4)
            {
                if (webBrowser_Main.Document.All["ro_amazon_app_id"] != null)
                {
                    _step = 5;
                    return UrlState.NeedGoToAvailabilityPage;
                }
            }

            if (_step == 5)
            {
                if (webBrowser_Main.Document.All["banjoParticipationIntent1"] != null)
                {
                    _step = 6;
                    return UrlState.NeedSetAvailability;
                }
            }

            if (_step == 6)
            {
                if (webBrowser_Main.Document.All["edit_button"] != null)
                {
                    //*填写详细信息
                    //_step = 7;
                    //return UrlState.NeedGoToDescriptionPage;

                    //不填写详细信息
                    _step = 9;
                    return UrlState.NeedGoToRatingPage;
                }
            }

            if (_step == 7)
            {
                if (webBrowser_Main.Document.All["dpShortDescription"] != null && webBrowser_Main.Document.All["dpMarketingBulletsStr"] != null)
                {
                    _step = 8;
                    return UrlState.NeedAddDescription;
                }
            }

            if (_step == 8)
            {
                if (webBrowser_Main.Document.All["edit_button"] != null)
                {
                    _step = 9;
                    return UrlState.NeedGoToRatingPage;
                }
            }

            if (_step == 9)
            {
                if (webBrowser_Main.Document.All["violence_None"] != null)
                {
                    _step = 10;
                    return UrlState.NeedAddRating;
                }
            }


            if (_step == 10)
            {
                if (webBrowser_Main.Document.All["edit_button"] != null)
                {
                    _step = 11;
                    return UrlState.Success;
                }
            }

            return UrlState.NotComplate;
        }

        private async void Login()
        {
            SetInfo("执行登陆");

            HtmlElement emailElement = webBrowser_Main.Document.All["ap_email"];
            HtmlElement passwordElement = webBrowser_Main.Document.All["ap_password"];
            HtmlElement createButtonElement = webBrowser_Main.Document.All["signInSubmit-input"];

            if (emailElement != null && passwordElement != null)
            {
                emailElement.SetAttribute("value", _pushGameInfo.RealDevAccount);
                passwordElement.SetAttribute("value", _pushGameInfo.RealDevPassword);

                //emailElement.InnerText = _pushGameInfo.RealDevAccount;
                //passwordElement.InnerText = _pushGameInfo.RealDevPassword;

                await Task.Delay(TimeSpan.FromSeconds(1));
                createButtonElement.InvokeMember("click");
            }
        }

        private void GoToLogin()
        {
            SetInfo("执行跳转到登录页面");
            this.webBrowser_Main.Navigate("https://developer.amazon.com/login.html");
        }

        private void GoToNewAppPage()
        {
            SetInfo("执行跳转到添加新App页面");
            this.webBrowser_Main.Navigate("https://developer.amazon.com/application/new.html");
        }

        private void AddGameTitleAndType()
        {
            SetInfo("添加AppTitleAndType");
            HtmlElement titleElement = webBrowser_Main.Document.All["title"];
            HtmlElement selectedTitleCategoryElement = webBrowser_Main.Document.All["selectedTitleCategory"];
            HtmlElement selectedRefinementsElement = webBrowser_Main.Document.All["selectedRefinements"];
            HtmlElement submitButtonElement = webBrowser_Main.Document.All["submit_button"];

            if (titleElement != null && selectedTitleCategoryElement != null &&
                selectedTitleCategoryElement != null && selectedRefinementsElement != null)
            {
                //titleElement.InnerText = _pushGameInfo.GameName;
                //selectedTitleCategoryElement.InnerText = GameTypeConverter.Convert(_pushGameInfo.GameClassify);

                titleElement.SetAttribute("value", _pushGameInfo.GameName);
                selectedTitleCategoryElement.SetAttribute("value", GameTypeConverter.Convert(_pushGameInfo.GameClassify));

                selectedRefinementsElement.SetAttribute("value", "game-app-features_casual,game-app-features_indie,game-app-features_widget");

                submitButtonElement.InvokeMember("click");
            }
        }

        private void GoToAvailabilityPage()
        {
            SetInfo("跳转到availability页面");
            HtmlElement appIdElement = webBrowser_Main.Document.All["ro_amazon_app_id"];
            if (appIdElement != null)
            {
                _appIDInStore = appIdElement.InnerText;
                this.webBrowser_Main.Navigate(
                    string.Format("https://developer.amazon.com/application/availability/{0}/detail.html?default",
                    _appIDInStore));
            }
        }

        private async void SetAvailability()
        {
            SetInfo("设置availability");
            HtmlElement banjoParticipationIntentElement = webBrowser_Main.Document.All["banjoParticipationIntent1"];
            if (banjoParticipationIntentElement != null)
            {
                banjoParticipationIntentElement.InvokeMember("click");

                await Task.Delay(TimeSpan.FromSeconds(2));

                HtmlElement availableWorldWide2Element = webBrowser_Main.Document.All["availableWorldWide2"];
                availableWorldWide2Element.InvokeMember("click");

                await Task.Delay(TimeSpan.FromSeconds(1));

                HtmlElement standardCountriesElement = webBrowser_Main.Document.All["standardCountries"];
                HtmlElementCollection heC = standardCountriesElement.GetElementsByTagName("input");

                foreach (HtmlElement h in heC)
                {
                    if (h.GetAttribute("className").ToLower() == "all")
                    {
                        h.InvokeMember("click");
                    }

                    if (h.Id != null && h.Id.ToLower() == "china")
                    {
                        h.InvokeMember("click");
                    }
                }

                HtmlElement submit_buttonIntentElement = webBrowser_Main.Document.All["submit_button"];
                submit_buttonIntentElement.InvokeMember("click");
            }
        }

        private void GoToDescriptionPage()
        {
            SetInfo("跳转到Description页面");
            this.webBrowser_Main.Navigate(
                    string.Format("https://developer.amazon.com/application/description/{0}/detail.html?default",
                    _appIDInStore));
        }

        private async void AddDescription()
        {
            SetInfo("添加Description页面");
            HtmlElement localeElement = webBrowser_Main.Document.All["locale"];

            if (localeElement != null)
            {
                HtmlElementCollection heC = localeElement.GetElementsByTagName("option");

                foreach (HtmlElement h in heC)
                {
                    if (h.GetAttribute("value") != null && h.GetAttribute("value") == "M25JHWW3B8E8DX")
                    {
                        h.SetAttribute("selected", "selected");
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            HtmlElement dpShortDescriptionElement = webBrowser_Main.Document.All["dpShortDescription"];

            int endIndex = Math.Min(1900, _pushGameInfo.GameDetails.Length);
            dpShortDescriptionElement.InnerText = _pushGameInfo.GameDetails.Substring(0, endIndex);

            HtmlElement publisherDescription = webBrowser_Main.Document.All["publisherDescription"];
            publisherDescription.InnerText = _pushGameInfo.GameDetails;

            HtmlElement dpMarketingBulletsStr = webBrowser_Main.Document.All["dpMarketingBulletsStr"];
            dpMarketingBulletsStr.InnerText = _pushGameInfo.GameDetails;

            HtmlElement submit_button = webBrowser_Main.Document.All["submit_button"];
            submit_button.InvokeMember("click");
        }

        private void GoToRatingPage()
        {
            SetInfo("跳转到Rating页面");
            this.webBrowser_Main.Navigate(
                    string.Format("https://developer.amazon.com/application/rating/{0}/detail.html?default",
                    _appIDInStore));
        }

        private async void AddRating()
        {
            SetInfo("添加Rate");

            List<HtmlElement> ratingElments = new List<HtmlElement>
            {
                webBrowser_Main.Document.All["violence_None"],
                webBrowser_Main.Document.All["cartoon_violence_None"],
                webBrowser_Main.Document.All["drugs_None"],
                webBrowser_Main.Document.All["nudity_None"],
                webBrowser_Main.Document.All["sex_None"],
                webBrowser_Main.Document.All["intolerance_None"],
                webBrowser_Main.Document.All["profanity_None"],
                webBrowser_Main.Document.All["academic_no"],
                webBrowser_Main.Document.All["personal_info_No"],
                webBrowser_Main.Document.All["advertisements_No"],
                webBrowser_Main.Document.All["child_directed_No"],
                webBrowser_Main.Document.All["gambling_No"],
                webBrowser_Main.Document.All["location_No"],
                webBrowser_Main.Document.All["user_generated_content_No"],
            };

            foreach (HtmlElement i in ratingElments)
            {
                i.InvokeMember("click");
            }

            await Task.Delay(TimeSpan.FromSeconds(1));

            HtmlElement submit_button = webBrowser_Main.Document.All["submit_button"];
            submit_button.InvokeMember("click");
        }

        private void Successed()
        {
            SetInfo("成功");

            try
            {
                this.timer1.Stop();
                this.timer1.Interval = Convert.ToInt32(this.numericUpDown_Second.Value) * 1000;


                HttpDataHelper.InputInfoSuccessedByDreamSparkAmazon(_pushGameInfo.ID, _pushGameInfo.RealDevAccount, _pushGameInfo.RealDevPassword);

                CurrentSucCount = CurrentSucCount + 1;

                SetInfo("成功");
            }
            catch (Exception ex)
            {
                CurrentFailCount = CurrentFailCount + 1;
                SetInfo("失败," + ex.Message);
            }


            GetNewModel();

            if (_pushGameInfo != null)
            {
                GoToLogOut();
            }
            else
            {
                SetInfo("没获取到新账号，停止");
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {            
            GoToLogOut();
        }


        private enum UrlState
        {
            NotComplate,
            Success,
            NeedLogin,
            NeedNewPassword,
            NeedGoToLogin,
            NeedGoToNewAppPage,
            NeedAddGameTitleAndType,
            NeedGoToAvailabilityPage,
            NeedSetAvailability,
            NeedGoToDescriptionPage,
            NeedAddDescription,
            NeedGoToRatingPage,
            NeedAddRating
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetInfo("超时重来了");
            GoToLogOut();
        }


        private void GoToLogOut()
        {
            SetInfo("登出");

            _step = 0;
            this.timer1.Stop();
            this.timer1.Interval = Convert.ToInt32(this.numericUpDown_Second.Value) * 1000;

            ReCreateWebBrowser();

            this.webBrowser_Main.Navigate(_logoutPageUrl);

            this.timer1.Start();
        }

        private void GetNewModel()
        {
            try
            {
                SetInfo("获取新的账号");

                _pushGameInfo = HttpDataHelper.GetOneGameInfoAndChangeStateRandomForDevAmazon("安卓未就绪", "安卓填写中");

                //_pushGameInfo = new PushGameInfoModel
                //{
                //    GameName = "fuck shit mayun dashabiwocaonima",
                //    GameDetails = "Welcome to Worms 3, a classic game based on the popular strategy PC game.You already know the deal: place your worms strategically and choose the best weapons to kill all your opponents. Take turns to attack and try to kill them all before the opponent finishes with yours.\r\nNLIST your perfect battle combination as you choose your worms from a new ‘Class’ system  Heavy, Scientist, Scout and classic Soldier. Each has their own unique skill and ability. Which will fit in with your style of play?\r\nSHOW off your skills by earning Achievements! Delightful blends of the simple and complex, these goals have been deliberately engineered to push you and your wormy skills to the limits!\r\nPLAY online with asynchronous multiplayer warfare. Enrol in ranked or friendly matches and show off your prowess. Remember, with asynchronous multiplayer you don’t have to commit to a full session at a time. Take your turn then go beat your friends score in the single-player Bodycount mode!\r\nBATTLE in multiplayer Forts or Deathmatch modes and challenge yourself with the increasingly difficult Bodycount single-player game.\r\nCONQUER 27 single-player missions across 4 new themes (Beach, Spooky, Farmyard and Sewer).\r\nCUSTOMISE your squad and make them unique with a huge amount of customisation elements new to Android!\r\nINCOMING! All your old favourite weapons plus six new ones on Android, including a couple of returning classics such as the Old Lady and the Homing Pigeon!\r\nBE THE BEST and worm your way to the top of the Leaderboards across all major game modes including single player as well as asynchronous online ranked matches.\r\nGREATER CONTROL for players who can now choose between an all-new D-Pad control system and the original touch controls.\r\nNotes Editors:The game can be played locally and online with friends and random players from around the world. Although the game is really fun and addictive, the usability could be enhanced and some aspects of the online game could also be improved.",
                //    RealDevAccount = "nlqwwfegrvwn@xahu.edu.pl",
                //    RealDevPassword = "j2o8f7p7",

                //    GameClassify = "arcade-games"
                //};

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
            this.label_CurrentEduMail.Text = _pushGameInfo.RealDevAccount;
            this.label_CurrentPassword.Text = _pushGameInfo.RealDevPassword;
        }

        private void SetInfo(string msg)
        {
            if (_pushGameInfo != null)
            {
                this.textBox_Info.AppendText(DateTime.Now.ToString() + ", " + _pushGameInfo.RealDevAccount + "," + msg);
                this.textBox_Info.AppendText(Environment.NewLine);
            }
            else
            {
                this.textBox_Info.AppendText(DateTime.Now.ToString() + "," + msg);
                this.textBox_Info.AppendText(Environment.NewLine);
            }
        }


    }
}
