using Models.GameManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GamesManager.Utility;
using GamesManager.Model;

namespace GamesManager.AndroidLiuMangForm
{
    public partial class LiuMangGamesManager : Form
    {
        DataGridViewRow _currentDataGridViewRow = new DataGridViewRow();

        List<AndroidPushGameInfoModel> _pushGameInfoModelList;

        private Random _myRd = new Random();

        public DataGridViewRow CurrentDataGridViewRow
        {
            get { return _currentDataGridViewRow; }
            set
            {

                if (_currentDataGridViewRow != value)
                {
                    _currentDataGridViewRow = value;

                    //this.label_FileName.Text = _currentDataGridViewRow.Cells["FileName"].Value.ToString();
                    //this.label_GameName.Text = _currentDataGridViewRow.Cells["GameName"].Value.ToString();
                    //this.comboBox_PusherUser.SelectedItem = _currentDataGridViewRow.Cells["PusherName"].Value;
                    //this.comboBox_BaiduStoreStatus.SelectedItem = _currentDataGridViewRow.Cells["BaiduStoreStatus"].Value;
                    //this.comboBox_SanLiuLingStoreStatus.SelectedItem = _currentDataGridViewRow.Cells["SanLiuLingStoreStatus"].Value;
                    //this.comboBox_XiaomiStoreStatus.SelectedItem = _currentDataGridViewRow.Cells["XiaomiStoreStatus"].Value;

                    //_currentGameVersion = _pushGameInfoModelList.Find((x) => x.GameName == this.label_GameName.Text).Version;
                    //_currentGamePackageName = _pushGameInfoModelList.Find((x) => x.GameName == this.label_GameName.Text).PackageName;

                    this.textBox_GameNameModify.Text = _currentDataGridViewRow.Cells["Column_GameName"].Value.ToString();
                    this.textBox_PackageName.Text = _currentDataGridViewRow.Cells["Column_PackageName"].Value.ToString();
                    this.textBox_IadAppKey.Text = _currentDataGridViewRow.Cells["Column_IAdPushAppKey"].Value.ToString();
                    this.textBox_JingZhongAppId.Text = _currentDataGridViewRow.Cells["Column_JingZhongAppId"].Value.ToString();
                    this.textBox_DownlandAddress.Text = _currentDataGridViewRow.Cells["Column_DownloadAddress"].Value.ToString();
                    this.textBox_AppTypeMore.Text = _currentDataGridViewRow.Cells["Column_AppType"].Value.ToString();

                    this.textBox_BaiDuDevAccount.Text = _currentDataGridViewRow.Cells["Column_BaiDuDevAccount"].Value.ToString();
                    this.textBox_BaiDuPassword.Text = _currentDataGridViewRow.Cells["Column_BaiDuPassword"].Value.ToString();
                    this.textBox_SanLiuLingDevAccount.Text = _currentDataGridViewRow.Cells["Column_SanLiuLingDevAccount"].Value.ToString();
                    this.textBox_SanLiuLingPassword.Text = _currentDataGridViewRow.Cells["Column_SanLiuLingPassword"].Value.ToString();
                    this.textBox_XiaoMiDevAccount.Text = _currentDataGridViewRow.Cells["Column_XiaoMiDevAccount"].Value.ToString();
                    this.textBox_XiaoMiPassword.Text = _currentDataGridViewRow.Cells["Column_XiaoMiPassword"].Value.ToString();

                    this.comboBox_GameStateModify.Text = _currentDataGridViewRow.Cells["Column_State"].Value.ToString();

                }
            }
        }
        public LiuMangGamesManager()
        {
            InitializeComponent();
            this.comboBox_GameState.SelectedIndex = 0;
        }

        private void SetStatusInfo(string info)
        {
            this.toolStripStatusLabel_Status.Text = DateTime.Now.ToString() + "----" + info;
        }

        private void button_GetAdInfo_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_GameList.Rows.Clear();

                _pushGameInfoModelList = HttpDataHelper.AndroidGetLiuMangGameList(this.textBox_GameName.Text, this.comboBox_GameState.Text, this.textBox_PackageName_Select.Text);

                if (_pushGameInfoModelList == null || _pushGameInfoModelList.Count == 0)
                {
                    SetStatusInfo("没有获取到游戏信息");
                    return;
                }


                for (int i = 0; i < _pushGameInfoModelList.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = i + 1 });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].GameName });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].PackageName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].State });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].IAdPushAppKey });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].JingZhongAppId });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].DownloadAddress });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].BaiduStoreDevAccount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].BaiduStoreDevPassword });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].SanLiuLingStoreDevAccount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].SanLiuLingStoreDevPassword });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].XiaomiStoreDevAccount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].XiaomiStoreDevPassword });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList[i].AppType });

                    dataGridView_GameList.Rows.Add(dgvr);
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("没有获取到游戏信息," + ex.Message);
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

        private void button_UpdateGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (_pushGameInfoModelList != null && _pushGameInfoModelList.Count > 0)
                {
                    if (MessageBox.Show("确定更新吗?", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        string version = _pushGameInfoModelList.Find((x) => x.PackageName == this.textBox_PackageName.Text).Version;
                        HttpDataHelper.UpdateLiuMangPushGameInfo(this.textBox_GameNameModify.Text, version, this.textBox_PackageName.Text, this.comboBox_GameStateModify.Text,
                                                                this.textBox_IadAppKey.Text, this.textBox_JingZhongAppId.Text, this.textBox_DownlandAddress.Text, this.textBox_AppTypeMore.Text);

                        _currentDataGridViewRow.Cells["Column_GameName"].Value = this.textBox_GameNameModify.Text;
                        _currentDataGridViewRow.Cells["Column_State"].Value = this.comboBox_GameStateModify.Text;
                        _currentDataGridViewRow.Cells["Column_IAdPushAppKey"].Value = this.textBox_IadAppKey.Text;
                        _currentDataGridViewRow.Cells["Column_JingZhongAppId"].Value = this.textBox_JingZhongAppId.Text;
                        _currentDataGridViewRow.Cells["Column_DownloadAddress"].Value = this.textBox_DownlandAddress.Text;
                        _currentDataGridViewRow.Cells["Column_AppType"].Value = this.textBox_AppTypeMore.Text;

                        SetStatusInfo("更新成功");
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("更新失败," + ex.Message);
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_pushGameInfoModelList != null && _pushGameInfoModelList.Count > 0)
                {
                    if (MessageBox.Show("确定删除吗?", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        string version = _pushGameInfoModelList.Find((x) => x.PackageName == this.textBox_PackageName.Text).Version;
                        HttpDataHelper.AndroidDeleteGame(this.textBox_GameNameModify.Text, version, this.textBox_PackageName.Text);

                        dataGridView_GameList.Rows.Remove(_currentDataGridViewRow);
                        SetStatusInfo("删除成功");
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("删除失败," + ex.Message);
            }
        }

        private void button_CreatePackageName_Click(object sender, EventArgs e)
        {
            this.textBox_PackageName_Add.Text = RandomHelper.GetPackageName();
            if (checkBox_AutoCopyAdd.Checked)
            {
                Clipboard.SetText(this.textBox_PackageName_Add.Text);
            }
        }

        private void button_Submit_Add_Click(object sender, EventArgs e)
        {
            if (!this.checkBox_GetAdKeyFromDB_Add.Checked)
            {
                if (string.IsNullOrWhiteSpace(this.textBox_PackageName_Add.Text) ||
                  string.IsNullOrWhiteSpace(this.textBox_JingZhongAppId_Add.Text) ||
                   string.IsNullOrWhiteSpace(this.textBox_IadAppKey_Add.Text) ||
                   string.IsNullOrWhiteSpace(this.textBox_DownloadAddress_Add.Text))
                {
                    SetStatusInfo("除了游戏名称可以为空，其他的为必填项");
                    return;
                }
            }

            try
            {
                string gameName_t = string.IsNullOrWhiteSpace(this.textBox_GameName_Add.Text)
                    ? RandomHelper.PasswordCreatorZiMu(_myRd, 10) : this.textBox_GameName_Add.Text;

                //手动添加广告ID
                if (!this.checkBox_GetAdKeyFromDB_Add.Checked)
                {
                    HttpDataHelper.AddLiuMangAds(this.textBox_IadAppKey_Add.Text, this.textBox_PackageName_Add.Text,
                                                    this.textBox_JingZhongAppId_Add.Text, this.textBox_PackageName_Add.Text, "已用");
                }
                else
                {
                    this.textBox_PackageName_Add.Text = RandomHelper.GetPackageName();
                }

                HttpDataHelper.AndroidAddLiuMangPushGameInfo(gameName_t, this.textBox_PackageName_Add.Text,
                                                                this.textBox_IadAppKey_Add.Text, this.textBox_JingZhongAppId_Add.Text,
                                                                this.textBox_DetailAddress_Add.Text, this.textBox_AppType_Add.Text);

                HttpDataHelper.UpdateAppInfoTempModel(_currentAppListDataGridViewRow.Cells["Column_ID_Add"].Value.ToString(), "已绑定");
                dataGridView_AppList_Add.Rows.Remove(_currentAppListDataGridViewRow);

                SetStatusInfo("添加成功");
                ClearAddInfo();
            }
            catch (Exception ex)
            {
                SetStatusInfo("添加失败," + ex.Message);
            }
        }

        private void ClearAddInfo()
        {
            this.textBox_PackageName_Add.Clear();
            this.textBox_IadAppKey_Add.Clear();
            this.textBox_JingZhongAppId_Add.Clear();
        }



        private List<AppInfoTempModel> _appInfoTempModelList = new List<AppInfoTempModel>();

        DataGridViewRow _currentAppListDataGridViewRow = new DataGridViewRow();

        public DataGridViewRow CurrentAppListDataGridViewRow
        {
            get { return _currentAppListDataGridViewRow; }
            set
            {
                if (_currentAppListDataGridViewRow != value)
                {
                    _currentAppListDataGridViewRow = value;

                    this.textBox_DetailAddress_Add.Text = _currentAppListDataGridViewRow.Cells["Column_DetailAddress_Add"].Value.ToString();
                    this.textBox_DownloadAddress_Add.Text = _currentAppListDataGridViewRow.Cells["Column_DownloadAddress_Add"].Value.ToString();
                    this.textBox_AppType_Add.Text = _currentAppListDataGridViewRow.Cells["Column_AppType_Add"].Value.ToString();
                }
            }
        }
        private void button_SelectFreeApps_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_AppList_Add.Rows.Clear();

                _appInfoTempModelList = HttpDataHelper.GetFreeInfoTempModelList();

                if (_appInfoTempModelList == null || _appInfoTempModelList.Count == 0)
                {
                    SetStatusInfo("没有获取到应用信息");
                    return;
                }

                for (int i = 0; i < _appInfoTempModelList.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = i + 1 });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _appInfoTempModelList[i].ID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _appInfoTempModelList[i].AppName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _appInfoTempModelList[i].DetailAddress });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _appInfoTempModelList[i].DownloadAddress });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _appInfoTempModelList[i].AppType });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _appInfoTempModelList[i].Rate });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _appInfoTempModelList[i].State });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _appInfoTempModelList[i].Time });

                    dataGridView_AppList_Add.Rows.Add(dgvr);
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("没有获取到应用信息," + ex.Message);
            }
        }

        private void dataGridView_AppList_Add_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_AppList_Add.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_AppList_Add.SelectedCells[0].RowIndex;
                CurrentAppListDataGridViewRow = dataGridView_AppList_Add.Rows[index_t];
            }
        }

        private void button_AddBatch_Click(object sender, EventArgs e)
        {
            new BatchAddLiuMangApp().ShowDialog();
        }

        private void button_GoToDetailPage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_DetailAddress_Add.Text))
            {
                System.Diagnostics.Process.Start(this.textBox_DetailAddress_Add.Text);
            }
        }

        private void button_GoToDownLoadPage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_DownloadAddress_Add.Text))
            {
                System.Diagnostics.Process.Start(this.textBox_DownloadAddress_Add.Text);
            }
        }

        private void button_DeleteAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (_appInfoTempModelList != null && _appInfoTempModelList.Count > 0)
                {
                    if (MessageBox.Show("确定删除吗?", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        string id = _appInfoTempModelList.Find((x) => x.DetailAddress == this.textBox_DetailAddress_Add.Text).ID;
                        HttpDataHelper.DeleteAppInfoTempByID(id);

                        dataGridView_AppList_Add.Rows.Remove(_currentAppListDataGridViewRow);
                        SetStatusInfo("删除成功");
                    }
                }
            }
            catch (Exception ex)
            {
                SetStatusInfo("删除失败," + ex.Message);
            }
        }

        private void checkBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = (sender as CheckBox).Checked;
        }

        private void checkBox_GetAdKeyFromDB_Add_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox_GameName_Add.Enabled = !checkBox_GetAdKeyFromDB_Add.Checked;
            this.textBox_IadAppKey_Add.Enabled = !checkBox_GetAdKeyFromDB_Add.Checked;
            this.textBox_JingZhongAppId_Add.Enabled = !checkBox_GetAdKeyFromDB_Add.Checked;
            this.textBox_PackageName_Add.Enabled = !checkBox_GetAdKeyFromDB_Add.Checked;
            this.button_CreatePackageName.Enabled = !checkBox_GetAdKeyFromDB_Add.Checked;
        }

        private void button_ShowLiuMangAdsManager_Click(object sender, EventArgs e)
        {
            new LiuMangAdsManager().Show();
        }

        private void button_GetAdNameAndCopy_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox_AdName.Text = HttpDataHelper.GetLiuMangsAdList(this.textBox_IadAppKey.Text, this.textBox_JingZhongAppId.Text, string.Empty, string.Empty)[0].IadAppName;
                Clipboard.SetText(this.textBox_AdName.Text);
            }
            catch (Exception ex)
            {
                SetStatusInfo("删除失败," + ex.Message);
            }
        }

        //private void dataGridView_AppList_Add_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    foreach (DataGridViewRow dr in dataGridView_AppList_Add.Rows)
        //    {
        //        dr.Cells[0].Value = dr.Index + 1;
        //    }
        //}

    }
}
