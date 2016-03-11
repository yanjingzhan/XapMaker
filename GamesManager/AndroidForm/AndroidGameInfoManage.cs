using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GamesManager.Utility;
using Models.GameManager;

namespace GamesManager.AndroidForm
{
    public partial class AndroidGameInfoManage : Form
    {
        
        List<string> _pusherNames = new List<string>();
        DataGridViewRow _currentDataGridViewRow = new DataGridViewRow();
        
        List<AndroidPushGameInfoModel> _pushGameInfoModelList;

        string _currentGameVersion;
        string _currentGamePackageName;
        public DataGridViewRow CurrentDataGridViewRow
        {
            get { return _currentDataGridViewRow; }
            set
            {

                if (_currentDataGridViewRow != value)
                {
                    _currentDataGridViewRow = value;

                    this.label_FileName.Text = _currentDataGridViewRow.Cells["FileName"].Value.ToString();
                    this.label_GameName.Text = _currentDataGridViewRow.Cells["GameName"].Value.ToString();
                    this.comboBox_PusherUser.SelectedItem = _currentDataGridViewRow.Cells["PusherName"].Value;
                    this.comboBox_BaiduStoreStatus.SelectedItem = _currentDataGridViewRow.Cells["BaiduStoreStatus"].Value;
                    this.comboBox_SanLiuLingStoreStatus.SelectedItem = _currentDataGridViewRow.Cells["SanLiuLingStoreStatus"].Value;
                    this.comboBox_XiaomiStoreStatus.SelectedItem = _currentDataGridViewRow.Cells["XiaomiStoreStatus"].Value;

                    _currentGameVersion = _pushGameInfoModelList.Find((x) => x.GameName == this.label_GameName.Text).Version;
                    _currentGamePackageName = _pushGameInfoModelList.Find((x) => x.GameName == this.label_GameName.Text).PackageName;
                }

            }
        }

        public AndroidGameInfoManage()
        {
            InitializeComponent();
        }

        private void ShowInfo(string msg)
        {
            ((MainForm)this.MdiParent).ShowStatus(msg);
        }

        private void button_GetGameList_Click(object sender, EventArgs e)
        {
            try
            {
                _pushGameInfoModelList = HttpDataHelper.AndroidGetGameList(this.textBox_GameName.Text, this.comboBox_PusherName.Text);

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

        private void button_UpdateMore_Click(object sender, EventArgs e)
        {
            try
            {
                HttpDataHelper.AndroidUpdatePushGameInfo(this.label_GameName.Text, _currentGameVersion, _currentGamePackageName,
                                                        this.comboBox_PusherUser.Text, this.comboBox_BaiduStoreStatus.Text, this.comboBox_SanLiuLingStoreStatus.Text,
                                                        this.comboBox_XiaomiStoreStatus.Text);

                _currentDataGridViewRow.Cells["PusherName"].Value = this.comboBox_PusherUser.Text;
                _currentDataGridViewRow.Cells["BaiduStoreStatus"].Value = this.comboBox_BaiduStoreStatus.Text;
                _currentDataGridViewRow.Cells["SanLiuLingStoreStatus"].Value = this.comboBox_SanLiuLingStoreStatus.Text;
                _currentDataGridViewRow.Cells["XiaomiStoreStatus"].Value = this.comboBox_XiaomiStoreStatus.Text;


                ShowInfo(string.Format("{0}，更新成功", this.label_GameName.Text));
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void AndroidGameInfoManage_Shown(object sender, EventArgs e)
        {
            try
            {
                List<string> pusherNames = HttpDataHelper.GetPusherNames();

                comboBox_PusherName.Items.Clear();
                comboBox_PusherName.Items.AddRange(pusherNames.ToArray());

                comboBox_PusherUser.Items.Clear();
                comboBox_PusherUser.Items.AddRange(pusherNames.ToArray());
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_GameList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_GameList.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_GameList.SelectedCells[0].RowIndex;
                CurrentDataGridViewRow = dataGridView_GameList.Rows[index_t];
            }
        }

        private void button_DeleteGameInfo_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("确定删除这个游戏吗?", "删除", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HttpDataHelper.AndroidDeleteGame(this.label_GameName.Text, _currentGameVersion, _currentGamePackageName);
                    dataGridView_GameList.Rows.Remove(_currentDataGridViewRow);

                    ShowInfo(string.Format("{0}，删除成功", this.textBox_GameName.Text));
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
