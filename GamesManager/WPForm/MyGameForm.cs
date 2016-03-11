using GamesManager.Model;
using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamesManager
{
    public partial class MyGameForm : Form
    {
        public string GameState;

        DataGridViewRow _currentDataGridViewRow = new DataGridViewRow();

        private bool _isInputGame;
        private string _gameZipFile;
        private string _gameRomFile;
        private string _pngFile = string.Empty;
        private string _gameFileExtName = string.Empty;

        private List<PushGameInfoModel> _pushGameInfoModelList;

        public DataGridViewRow CurrentDataGridViewRow
        {
            get { return _currentDataGridViewRow; }
            set
            {

                if (_currentDataGridViewRow != value)
                {
                    _currentDataGridViewRow = value;
                    this.textBox_GameNameMore.Text = _currentDataGridViewRow.Cells["GameName"].Value.ToString();
                    this.textBox_VersionMore.Text = _currentDataGridViewRow.Cells["Version"].Value.ToString();
                    this.textBox_DevAccountMore.Text = _currentDataGridViewRow.Cells["DevAccount"].Value.ToString();
                    this.textBox_DevPasswordMore.Text = _currentDataGridViewRow.Cells["DevPassword"].Value.ToString();
                    //this.comboBox_StateMore.SelectedItem = _currentDataGridViewRow.Cells["State"].Value;
                    //this.comboBox_PusherUserMore.SelectedItem = _currentDataGridViewRow.Cells["PusherName"].Value;
                }
            }
        }
        public MyGameForm()
        {
            InitializeComponent();

            this.Shown += MyGameForm_Shown;
        }

        void MyGameForm_Shown(object sender, EventArgs e)
        {
            try
            {
                _pushGameInfoModelList = HttpDataHelper.GetGameList("", GameState, GlobalData.GlobalPusherUser.Name);

                if (_pushGameInfoModelList == null || _pushGameInfoModelList.Count == 0)
                {
                    MessageBox.Show("没有获取到游戏信息");
                    return;
                }

                dataGridView_GameList.Rows.Clear();

                for (int i = 0; i < _pushGameInfoModelList.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].GameName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].Version });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].SurfaceAccountID   });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].SurfaceAdID });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].GoogleBanner });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].GoogleChaping});
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].PubcenterAppID });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].PubcenterAdID});
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].DevAccount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].DevPassword });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].AddTime});
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].UpdateTime});

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].State });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].PusherName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].GameID });

                    dataGridView_GameList.Rows.Add(dgvr);
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        private void ShowInfo(string msg)
        {
            ((MainForm)this.MdiParent).ShowStatus(msg);
        }

        private void dataGridView_GameList_SelectionChanged(object sender, EventArgs e)
        {
            _isInputGame = false;
            _gameRomFile = string.Empty;
            _gameZipFile = string.Empty;

            if (dataGridView_GameList.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_GameList.SelectedCells[0].RowIndex;

                CurrentDataGridViewRow = dataGridView_GameList.Rows[index_t];
            }
        }

        private void MyGameForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                ShowInfo("正在识别文件,请稍候...");

                string[] ss = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (Path.GetExtension(ss[0]).ToLower() == ".zip")
                {
                    bool t = ZipHelper.ExtNameExist(ss[0], ".gba");
                    string gameName = Path.GetFileNameWithoutExtension(ss[0]);
                    if (t)
                    {
                        for (int i = 0; i < dataGridView_GameList.Rows.Count; i++)
                        {
                            if (dataGridView_GameList.Rows[i].Cells["GameName"].Value.ToString() == gameName)
                            {
                                dataGridView_GameList.CurrentCell = dataGridView_GameList.Rows[i].Cells["GameName"];

                                _isInputGame = true;
                                _gameZipFile = ss[0];
                                _gameRomFile = ZipHelper.GetExtNameFile(ss[0], ".gba");
                                _gameFileExtName = ".gba";

                                this.textBox_GameName.Text = gameName + (textBox_VersionMore.Text == "0" ? "" : " " + textBox_VersionMore.Text);

                                ShowInfo("识别完成...");
                                return;
                            }
                        }

                        ShowInfo("您的任务中并不包含这个游戏...");
                    }
                    else
                    {
                        throw new Exception("文件中不包含游戏文件!");
                    }
                }
                else if (Path.GetExtension(ss[0]).ToLower() == ".png")
                {
                    if (_isInputGame)
                    {
                        _pngFile = ss[0].Trim();
                        pictureBox_Logo.ImageLocation = ss[0].Trim();

                        ShowInfo("导入图标成功！");
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

        private void MyGameForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
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
            }
        }

        private void button_GetGameInfo_Click(object sender, EventArgs e)
        {
            if (!_isInputGame)
            {
                ShowInfo("请先拖入游戏文件再获取游戏描述！");
            }
            else
            {
                string s = HtmlHelper.GetGameDescription(textBox_GameNameMore.Text);

                if (string.IsNullOrEmpty(s))
                {
                    ShowInfo("获取游戏描述失败！");
                }
                else
                {
                    this.richTextBox_GameInfo.Text = s;
                }
            }
        }

        private void button_CreateXap_Click(object sender, EventArgs e)
        {
            if (!_isInputGame)
            {
                ShowInfo("请先拖入游戏文件、添加游戏图标后再打包");
                return;
            }

            if (string.IsNullOrEmpty(_pngFile))
            {
                ShowInfo("请先拖入添加游戏图标后再打包");
                return;
            }

            try
            {
                ShowInfo("开始打包...");
                string surfaceAccountId = CryptHelper.Decrypt(_pushGameInfoModelList.Find((x) => x.GameName == textBox_GameNameMore.Text).SurfaceAccountID);
                string surfaceAdID = CryptHelper.Decrypt(_pushGameInfoModelList.Find((x) => x.GameName == textBox_GameNameMore.Text).SurfaceAdID);

                string googleBanner = CryptHelper.Decrypt(_pushGameInfoModelList.Find((x) => x.GameName == textBox_GameNameMore.Text).GoogleBanner);
                string googleChaping = CryptHelper.Decrypt(_pushGameInfoModelList.Find((x) => x.GameName == textBox_GameNameMore.Text).GoogleChaping);

                string pubcenterAppID = CryptHelper.Decrypt(_pushGameInfoModelList.Find((x) => x.GameName == textBox_GameNameMore.Text).PubcenterAppID);
                string pubcenterAdID = CryptHelper.Decrypt(_pushGameInfoModelList.Find((x) => x.GameName == textBox_GameNameMore.Text).PubcenterAdID);

                XmlHelper.WriteAdInfo(AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\Assets\AppManifest.xml",
                    "surfaceAccountId", surfaceAccountId);
                XmlHelper.WriteAdInfo(AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\Assets\AppManifest.xml",
                    "surfaceAdID", surfaceAdID);

                XmlHelper.WriteAdInfo(AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\Assets\AppManifest.xml",
                    "googleBanner", googleBanner);
                XmlHelper.WriteAdInfo(AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\Assets\AppManifest.xml",
                    "googleChaping", googleChaping);

                XmlHelper.WriteAdInfo(AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\Assets\AppManifest.xml",
                    "pubcenterAppID", pubcenterAppID);
                XmlHelper.WriteAdInfo(AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\Assets\AppManifest.xml",
                    "pubcenterAdID", pubcenterAdID);

                XmlHelper.SetGameName(AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\WMAppManifest.xml", textBox_GameName.Text);

                ZipHelper.DecompressionOneFileByExtname(_gameZipFile, _gameFileExtName, 
                    AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\Assets\Pong.gba");
                File.Copy(_pngFile, AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\Images\300.png",true);

                ZipHelper.CreateSample(AppDomain.CurrentDomain.BaseDirectory + @"游戏目录\" + textBox_GameName.Text + ".xap",AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA");

                ShowInfo("打包成功");

            }
            catch (Exception ex)
            {
                ShowInfo("打包失败," + ex.Message);
                MessageBox.Show("打包失败,"  + ex.Message);
            }
        }

        private void button_OpenInDir_Click(object sender, EventArgs e)
        {
            XmlHelper.WriteAdInfo(AppDomain.CurrentDomain.BaseDirectory + @"GameTemplate\GBA\Assets\AppManifest.xml", "s", "a");
        }

        private void button_SubmitDone_Click(object sender, EventArgs e)
        {

        }

    }
}
