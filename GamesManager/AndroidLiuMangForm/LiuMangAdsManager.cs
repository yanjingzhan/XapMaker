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

namespace GamesManager.AndroidLiuMangForm
{
    public partial class LiuMangAdsManager : Form
    {
        DataGridViewRow _currentDataGridViewRow = new DataGridViewRow();

        List<LiuMangAds> _LiuMangAds;

        public DataGridViewRow CurrentDataGridViewRow
        {
            get { return _currentDataGridViewRow; }
            set
            {

                if (_currentDataGridViewRow != value)
                {
                    _currentDataGridViewRow = value;
                }
            }
        }

        public LiuMangAdsManager()
        {
            InitializeComponent();
            this.comboBox_Status.SelectedIndex = 0;
            this.comboBox_Status_Add.SelectedIndex = 1;
        }

        private void SetStatusInfo(string info)
        {
            this.toolStripStatusLabel_Status.Text = DateTime.Now.ToString() + "----" + info;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_LiuMangAds.Rows.Clear();

                _LiuMangAds = HttpDataHelper.GetLiuMangsAdList("", "", this.textBox_InAdSiteName.Text, this.comboBox_Status.Text);

                if (_LiuMangAds == null || _LiuMangAds.Count == 0)
                {
                    SetStatusInfo("没有获取到游戏信息");
                    return;
                }


                for (int i = 0; i < _LiuMangAds.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = i + 1 });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _LiuMangAds[i].ID });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _LiuMangAds[i].IadKey });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _LiuMangAds[i].IadAppName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _LiuMangAds[i].JingZhongKey });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _LiuMangAds[i].JingZhongAppName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _LiuMangAds[i].Status });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _LiuMangAds[i].Time });

                    dataGridView_LiuMangAds.Rows.Add(dgvr);
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("没有获取到游戏信息," + ex.Message);
            }
        }

        private void dataGridView_LiuMangAds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                try
                {
                    HttpDataHelper.DeleteLiuMangAd(senderGrid.Rows[e.RowIndex].Cells["Column_ID"].Value.ToString());
                    this.dataGridView_LiuMangAds.Rows.Remove(_currentDataGridViewRow);
                }
                catch (Exception ex)
                {
                    SetStatusInfo("删除失败," + ex.Message);
                }
            }
        }

        private void dataGridView_LiuMangAds_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_LiuMangAds.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_LiuMangAds.SelectedCells[0].RowIndex;
                CurrentDataGridViewRow = dataGridView_LiuMangAds.Rows[index_t];
            }
        }

        private void button_AddOne_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.textBox_AppName_Add.Text) || string.IsNullOrWhiteSpace(this.textBox_IadKey_Add.Text)
                    || string.IsNullOrWhiteSpace(this.textBox_JingZhongKey_Add.Text))
                {
                    SetStatusInfo("不能为空！");
                    return;
                }

                HttpDataHelper.AddLiuMangAds(this.textBox_IadKey_Add.Text, this.textBox_AppName_Add.Text,
                                             this.textBox_JingZhongKey_Add.Text, this.textBox_AppName_Add.Text, this.comboBox_Status_Add.Text);

                SetStatusInfo("ok！");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                SetStatusInfo("添加失败," + ex.Message);
            }
        }

        private void ClearTextBox()
        {
            this.textBox_IadKey_Add.Clear();
            this.textBox_JingZhongKey_Add.Clear();
            this.textBox_AppName_Add.Clear();
        }
    }
}
