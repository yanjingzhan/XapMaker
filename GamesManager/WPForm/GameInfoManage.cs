using GamesManager.Model;
using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamesManager
{
    public partial class GameInfoManage : Form
    {
        List<string> _pusherNames = new List<string>();
        DataGridViewRow _currentDataGridViewRow = new DataGridViewRow();

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
                    this.textBox_GameIDMore.Text = _currentDataGridViewRow.Cells["GameID"].Value.ToString();
                    this.comboBox_StateMore.SelectedItem = _currentDataGridViewRow.Cells["State"].Value;
                    this.comboBox_PusherUserMore.SelectedItem = _currentDataGridViewRow.Cells["PusherName"].Value;
                }
            }
        }
        public GameInfoManage()
        {
            InitializeComponent();
        }

        private void GameInfoManage_Shown(object sender, EventArgs e)
        {
            comboBox_GameState.SelectedIndex = 0;

            try
            {
                _pusherNames = HttpDataHelper.GetPusherNames();

                comboBox_PusherName.Items.Clear();
                comboBox_PusherName.Items.Add("全部");
                comboBox_PusherName.Items.AddRange(_pusherNames.ToArray());

                comboBox_PusherName.SelectedIndex = 0;

                comboBox_PusherUserMore.Items.Clear();
                comboBox_PusherUserMore.Items.AddRange(_pusherNames.ToArray());
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

        private void button_GetGameList_Click(object sender, EventArgs e)
        {
            try
            {
                List<PushGameInfoModel> pushGameInfoModelList = HttpDataHelper.GetGameList(this.textBox_GameName.Text, this.comboBox_GameState.Text, this.comboBox_PusherName.Text);

                if (pushGameInfoModelList == null || pushGameInfoModelList.Count == 0)
                {
                    MessageBox.Show("没有获取到游戏信息");
                    return;
                }

                dataGridView_GameList.Rows.Clear();

                for (int i = 0; i < pushGameInfoModelList.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].GameName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].Version });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].SurfaceAccountID   });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].SurfaceAdID });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].GoogleBanner });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].GoogleChaping});
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].PubcenterAppID });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].PubcenterAdID});
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].DevAccount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].DevPassword });
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].AddTime});
                    //dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].UpdateTime});

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].State });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].PusherName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pushGameInfoModelList[i].GameID });

                    dataGridView_GameList.Rows.Add(dgvr);
                }
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
                if (MessageBox.Show("确定删除?", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HttpDataHelper.DeleteGame(this.textBox_GameNameMore.Text, this.textBox_VersionMore.Text);

                    dataGridView_GameList.Rows.Remove(_currentDataGridViewRow);

                    ShowInfo(string.Format("{0}，删除成功", this.textBox_GameNameMore.Text));
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
                HttpDataHelper.UpdatePushGameInfo(this.textBox_GameNameMore.Text, this.textBox_VersionMore.Text,
                            this.comboBox_StateMore.Text, this.comboBox_PusherUserMore.Text, this.textBox_GameIDMore.Text);

                _currentDataGridViewRow.Cells["GameID"].Value = this.textBox_GameIDMore.Text;
                _currentDataGridViewRow.Cells["State"].Value = this.comboBox_StateMore.Text;
                _currentDataGridViewRow.Cells["PusherName"].Value = this.comboBox_PusherUserMore.Text;

                ShowInfo(string.Format("{0}，更新成功",this.textBox_GameNameMore.Text));
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
