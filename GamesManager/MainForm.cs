using GamesManager.AndroidForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamesManager
{
    public partial class MainForm : Form
    {
        private string _platform;

        private AddGamesForm _addGameForm;
        private GameInfoManage _gameInfoManageForm;
        private PusherUserManager _pusherUserManager;
        private MyGameForm _myGameForm;

        private AndroidAddGamesForm _androidAddGamesForm;
        private AndroidGameInfoManage _androidGameInfoManage;
        private AndroidMyGameForm _androidMyGameForm;
        private TestIsGoodForm _testIsGoodForm;

        public MainForm()
        {
            InitializeComponent();

            _platform = ConfigurationManager.AppSettings["StoreNames"] == null ? "Android" : ConfigurationManager.AppSettings["StoreNames"];

            this.Text = "感谢您~ " + GlobalData.GlobalPusherUser.Name;
            this.FormClosed += MainForm_FormClosed;

            if (GlobalData.GlobalPusherUser.Role == "管理员")
            {
                toolStripButton_SelectNeedMePush.Visible = false;
                toolStripButton_SelectAllMyApp.Visible = false;
            }
            else
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton3.Visible = false;
            }
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void ShowStatus(string msg)
        {
            this.toolStripStatusLabel_Status.Text = DateTime.Now.ToString() + "----" + msg;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_Status.Text = string.Empty;

            if (_platform == "WP")
            {
                if (_gameInfoManageForm != null)
                {
                    _gameInfoManageForm.Close();
                    _gameInfoManageForm.Dispose();
                    _gameInfoManageForm = null;
                }

                _addGameForm = new AddGamesForm();
                _addGameForm.MdiParent = this;
                _addGameForm.Dock = DockStyle.Fill;
                _addGameForm.Show();
            }
            else
            {
                if (_androidAddGamesForm != null)
                {
                    _androidAddGamesForm.Close();
                    _androidAddGamesForm.Dispose();
                    _androidAddGamesForm = null;
                }

                _androidAddGamesForm = new AndroidAddGamesForm();
                _androidAddGamesForm.MdiParent = this;
                _androidAddGamesForm.Dock = DockStyle.Fill;
                _androidAddGamesForm.Show();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_Status.Text = string.Empty;

            if (_platform == "WP")
            {

                if (_addGameForm != null)
                {
                    _addGameForm.Close();
                    _addGameForm.Dispose();
                    _addGameForm = null;
                }

                _gameInfoManageForm = new GameInfoManage();
                _gameInfoManageForm.MdiParent = this;
                _gameInfoManageForm.Dock = DockStyle.Fill;
                _gameInfoManageForm.Show();
            }
            else
            {
                if (_androidGameInfoManage != null)
                {
                    _androidGameInfoManage.Close();
                    _androidGameInfoManage.Dispose();
                    _androidGameInfoManage = null;
                }

                _androidGameInfoManage = new AndroidGameInfoManage();
                _androidGameInfoManage.MdiParent = this;
                _androidGameInfoManage.Dock = DockStyle.Fill;
                _androidGameInfoManage.Show();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _pusherUserManager = new PusherUserManager();
            _pusherUserManager.ShowDialog();
        }

        private void toolStripButton_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_LogOut_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "conf.ini");

                MessageBox.Show("注销完成");
            }
            catch { }
        }

        private void toolStripButton_SelectNeedMePush_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_Status.Text = string.Empty;

            if (_platform == "WP")
            {

                if (_myGameForm != null)
                {
                    if (string.IsNullOrEmpty(_myGameForm.GameState))
                    {
                        _myGameForm.Close();
                        _myGameForm.Dispose();
                        _myGameForm = null;

                        _myGameForm = new MyGameForm();
                        _myGameForm.GameState = "待提交";
                        _myGameForm.MdiParent = this;
                        _myGameForm.Dock = DockStyle.Fill;
                        _myGameForm.Show();
                    }
                }
                else
                {
                    _myGameForm = new MyGameForm();
                    _myGameForm.GameState = "待提交";
                    _myGameForm.MdiParent = this;
                    _myGameForm.Dock = DockStyle.Fill;
                    _myGameForm.Show();
                }
            }
            else
            {
                if (_androidMyGameForm != null)
                {
                    if (string.IsNullOrEmpty(_androidMyGameForm.GameState))
                    {
                        _androidMyGameForm.Close();
                        _androidMyGameForm.Dispose();
                        _androidMyGameForm = null;

                        _androidMyGameForm = new AndroidMyGameForm();
                        _androidMyGameForm.GameState = "待提交";
                        _androidMyGameForm.MdiParent = this;
                        _androidMyGameForm.Dock = DockStyle.Fill;
                        _androidMyGameForm.Show();
                    }
                }
                else
                {
                    _androidMyGameForm = new AndroidMyGameForm();
                    _androidMyGameForm.GameState = "待提交";
                    _androidMyGameForm.MdiParent = this;
                    _androidMyGameForm.Dock = DockStyle.Fill;
                    _androidMyGameForm.Show();
                }
            }
        }

        private void toolStripButton_SelectAllMyApp_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_Status.Text = string.Empty;

            if (_platform == "WP")
            {

                if (_myGameForm != null)
                {
                    if (!string.IsNullOrEmpty(_myGameForm.GameState))
                    {
                        _myGameForm.Close();
                        _myGameForm.Dispose();
                        _myGameForm = null;

                        _myGameForm = new MyGameForm();
                        _myGameForm.GameState = "";
                        _myGameForm.MdiParent = this;
                        _myGameForm.Dock = DockStyle.Fill;
                        _myGameForm.Show();
                    }
                }
                else
                {
                    _myGameForm = new MyGameForm();
                    _myGameForm.GameState = "";
                    _myGameForm.MdiParent = this;
                    _myGameForm.Dock = DockStyle.Fill;
                    _myGameForm.Show();
                }
            }
            else
            {
                if (_androidMyGameForm != null)
                {
                    if (!string.IsNullOrEmpty(_androidMyGameForm.GameState))
                    {
                        _androidMyGameForm.Close();
                        _androidMyGameForm.Dispose();
                        _androidMyGameForm = null;

                        _androidMyGameForm = new AndroidMyGameForm();
                        _androidMyGameForm.GameState = "";
                        _androidMyGameForm.MdiParent = this;
                        _androidMyGameForm.Dock = DockStyle.Fill;
                        _androidMyGameForm.Show();
                    }
                }
                else
                {
                    _androidMyGameForm = new AndroidMyGameForm();
                    _androidMyGameForm.GameState = "";
                    _androidMyGameForm.MdiParent = this;
                    _androidMyGameForm.Dock = DockStyle.Fill;
                    _androidMyGameForm.Show();
                }
            }
        }

        private void toolStripButton_TestIsGood_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_Status.Text = string.Empty;

            if (_testIsGoodForm != null)
            {
                _testIsGoodForm.Close();
                _testIsGoodForm.Dispose();
                _testIsGoodForm = null;
            }
            _testIsGoodForm = new TestIsGoodForm();
            _testIsGoodForm.MdiParent = this;
            _testIsGoodForm.Dock = DockStyle.Fill;
            _testIsGoodForm.Show();
        }
    }
}
