using GamesManager.AndroidHandlers;
using GamesManager.Utility;
using Models.GameManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GamesManager.AndroidForm
{
    public partial class AndroidMyGameForm : Form
    {
        public string GameState;

        List<string> _pusherNames = new List<string>();
        DataGridViewRow _currentDataGridViewRow = new DataGridViewRow();

        List<AndroidPushGameInfoModel> _pushGameInfoModelList;

        AndroidPushGameInfoModel _androidPushGameInfoModel;
        delegate void SetTextValue(string text);

        private bool _isInputGame;
        private bool _isInputIcon;

        private string _gameZipFile;
        private string _gameRomFile;

        private string _pngFile = string.Empty;

        private string _unityVersion;
        private string _shortUnityVersion;

        public DataGridViewRow CurrentDataGridViewRow
        {
            get { return _currentDataGridViewRow; }
            set
            {

                if (_currentDataGridViewRow != value)
                {
                    _currentDataGridViewRow = value;

                    this.label_FileName.Text = _currentDataGridViewRow.Cells["FileName"].Value.ToString();
                    this.textBox_GameName.Text = _currentDataGridViewRow.Cells["GameName"].Value.ToString();

                    _androidPushGameInfoModel = _pushGameInfoModelList.Find((x) => x.GameName == this.textBox_GameName.Text);

                    this.textBox_BaiduDevAccount.Text = _androidPushGameInfoModel.BaiduStoreDevAccount;
                    this.textBox_BaiduDevPassword.Text = _androidPushGameInfoModel.BaiduStoreDevPassword;

                    this.textBox_SanLiuLingDevAccount.Text = _androidPushGameInfoModel.SanLiuLingStoreDevAccount;
                    this.textBox_SanLiuLingDevPassword.Text = _androidPushGameInfoModel.SanLiuLingStoreDevPassword;

                    this.textBox_XiaoMiDevAccount.Text = _androidPushGameInfoModel.XiaomiStoreDevAccount;
                    this.textBox_XiaoMiDevPassword.Text = _androidPushGameInfoModel.XiaomiStoreDevPassword;
                }

            }
        }
        public AndroidMyGameForm()
        {
            InitializeComponent();

            _androidPushGameInfoModel = new AndroidPushGameInfoModel();
        }

        private void dataGridView_GameList_SelectionChanged(object sender, EventArgs e)
        {
            _isInputGame = false;
            _isInputIcon = false;
            _gameZipFile = string.Empty;
            _pngFile = string.Empty;

            if (dataGridView_GameList.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_GameList.SelectedCells[0].RowIndex;
                CurrentDataGridViewRow = dataGridView_GameList.Rows[index_t];
            }
        }


        private void ShowInfo(string msg)
        {
            ((MainForm)this.MdiParent).ShowStatus(msg);
        }

        private void AndroidMyGameForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (GameState == "待提交")
                {
                    _pushGameInfoModelList = HttpDataHelper.GetAndroidNotCompletedPushGameInfoModelListByPusherNameAndCount(GlobalData.GlobalPusherUser.Name);
                }
                else
                {
                    _pushGameInfoModelList = HttpDataHelper.AndroidGetGameList(this.textBox_GameName.Text, GlobalData.GlobalPusherUser.Name);
                }

                if (_pushGameInfoModelList == null || _pushGameInfoModelList.Count == 0)
                {
                    MessageBox.Show("没有获取到游戏信息");
                    return;
                }

                dataGridView_GameList.Rows.Clear();

                for (int i = 0; i < _pushGameInfoModelList.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].FileName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].GameName });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].BaiduStoreDevAccount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].BaiduStoreDevPassword });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].BaiduStoreStatus });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].SanLiuLingStoreDevAccount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].SanLiuLingStoreDevPassword });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].SanLiuLingStoreStatus });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].XiaomiStoreDevAccount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].XiaomiStoreDevPassword });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].XiaomiStoreStatus });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].PusherName });

                    dataGridView_GameList.Rows.Add(dgvr);
                }

            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox_Logo_Click(object sender, EventArgs e)
        {
            if (!_isInputGame)
            {
                ShowInfo("请先拖入游戏文件再选取游戏图标！");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Png|*.png";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _pngFile = ofd.FileName;
                pictureBox_Logo.ImageLocation = _pngFile;

                ShowInfo("导入图标成功！");

                _isInputIcon = true;
            }
        }

        private void AndroidMyGameForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                ShowInfo("正在识别文件,请稍候...");

                string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (Path.GetExtension(ss[0]).ToLower() == ".apk")
                {
                    string fileName = Path.GetFileName(ss[0]);
                    for (int i = 0; i < dataGridView_GameList.Rows.Count; i++)
                    {
                        if (dataGridView_GameList.Rows[i].Cells["FileName"].Value.ToString() == fileName)
                        {

                            _unityVersion = ZipHelper.GetUnityVersionShitFuck(ss[0]);

                            if (!_unityVersion.Contains("."))
                            {
                                throw new Exception("无法识别版本," + _unityVersion);
                            }

                            _shortUnityVersion = _unityVersion.Substring(0, 3);

                            string txtFile = ss[0].Replace(".apk", ".txt");
                            if (File.Exists(txtFile))
                            {
                                using (StreamReader sr = new StreamReader(txtFile))
                                {
                                    this.richTextBox_GameInfo.Text = sr.ReadToEnd();
                                    sr.Close();

                                    ShowInfo("识别完成.版本号：" + _unityVersion);
                                }
                            }
                            else
                            {
                                ShowInfo("识别完成.版本号：" + _unityVersion + ",没有游戏简介文件，请自行编写");
                                this.richTextBox_GameInfo.Clear();
                            }


                            dataGridView_GameList.CurrentCell = dataGridView_GameList.Rows[i].Cells["FileName"];
                            _isInputGame = true;
                            _gameZipFile = ss[0];

                            return;
                        }
                    }

                    ShowInfo("您的任务中并不包含这个游戏...");
                }
                else if (Path.GetExtension(ss[0]).ToLower() == ".png")
                {
                    if (_isInputGame)
                    {
                        _pngFile = ss[0].Trim();
                        pictureBox_Logo.ImageLocation = ss[0].Trim();

                        ShowInfo("导入图标成功！");

                        _isInputIcon = true;
                    }
                    else
                    {
                        ShowInfo("请先拖入游戏文件再添加游戏图标！");
                    }
                }
                else
                {
                    ShowInfo("您拖入的不是游戏文件也不是游戏图标！");
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void AndroidMyGameForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isInputGame || !_isInputIcon)
                {
                    ShowInfo("您还没有拖入游戏文件和图标文件，游戏还没有全部提交完成吧？");
                    return;
                }

                if (MessageBox.Show("确认该游戏已经全部提交完成了吗？", "确认一下", MessageBoxButtons.OKCancel)
                    == System.Windows.Forms.DialogResult.OK)
                {
                    HttpDataHelper.AndroidUpdatePushGameInfo(_androidPushGameInfoModel.GameName, "0",
                        _androidPushGameInfoModel.PackageName, _androidPushGameInfoModel.PusherName,
                        "待审核", "待审核", "待审核");

                    dataGridView_GameList.Rows.Remove(_currentDataGridViewRow);
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button_BaiDu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isInputGame || !_isInputIcon)
                {
                    ShowInfo("您还没有拖入游戏文件和图标文件，还不能生成");
                    return;
                }

                try
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(DoWorkFunc));
                    thread.IsBackground = true;
                    thread.Start("baidu");
                }
                catch (Exception ex)
                {
                    ShowInfo(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button_SanLiuLing_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isInputGame || !_isInputIcon)
                {
                    ShowInfo("您还没有拖入游戏文件和图标文件，还不能生成");
                    return;
                }

                try
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(DoWorkFunc));
                    thread.IsBackground = true;
                    thread.Start("sanliuling");
                }
                catch (Exception ex)
                {
                    ShowInfo(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        private void button_XiaoMi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isInputGame || !_isInputIcon)
                {
                    ShowInfo("您还没有拖入游戏文件和图标文件，还不能生成");
                    return;
                }

                try
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(DoWorkFunc));
                    thread.IsBackground = true;
                    thread.Start("xiaomi");
                }
                catch (Exception ex)
                {
                    ShowInfo(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        private void DoWorkFunc(object targetStore)
        {
            try
            {
                string adKey1 = string.Empty;
                string adKey2 = string.Empty;

                switch (targetStore.ToString().ToLower())
                {
                    case "baidu":
                        adKey1 = _androidPushGameInfoModel.BaiDuAppID;
                        break;

                    case "sanliuling":
                        adKey1 = _androidPushGameInfoModel.SanLiuLingBannerID;
                        adKey2 = _androidPushGameInfoModel.SanLiuLingChaPingID;
                        break;

                    case "xiaomi":
                        adKey1 = _androidPushGameInfoModel.YouMiID;
                        adKey2 = _androidPushGameInfoModel.YouMiAppID;
                        break;

                    default:
                        break;

                }

                BasePlayerHandler bp = PlayerHandlerCreater.GetHandler(targetStore.ToString());

                this.Invoke(new SetTextValue(ShowInfo), "开始创建……");
                bp.Init(_shortUnityVersion);

                Thread.Sleep(100);
                this.Invoke(new SetTextValue(ShowInfo), "解包……");
                bp.UnPackage(_gameZipFile);

                Thread.Sleep(100);

                this.Invoke(new SetTextValue(ShowInfo), "原工程复制……");
                bp.CopyInAssets();
                bp.CopyInLibs();
                bp.DeleteGen();
                bp.ReplaceAppIcon(_pngFile);
                bp.ReplaceAdKey1(adKey1);
                bp.ReplaceAdKey2(adKey2);

                bp.ReplacePackageName(_androidPushGameInfoModel.PackageName);
                bp.ReplaceImportPackageName(_androidPushGameInfoModel.PackageName);
                bp.ModifyGameName(_androidPushGameInfoModel.GameName);

                bp.DoReplace();

                Thread.Sleep(100);

                this.Invoke(new SetTextValue(ShowInfo), "完成……");
            }
            catch (Exception ex)
            {
                this.Invoke(new SetTextValue(ShowInfo), ex.Message);
                this.Invoke(new SetTextValue(ShowMessageBox), ex.Message);
            }
        }
        public void ShowMessageBox(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
