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
using WPGamer.Models;
using WPGamer.Utility;

namespace WPGamer
{
    public partial class UnityPackageBuilder : Form
    {
        DataGridViewRow _currentDataGridViewRow_MoNiQi = new DataGridViewRow();
        DataGridViewRow _currentDataGridViewRowDevAccount_MoNiQi = new DataGridViewRow();


        List<PushGameInfoModel> _pushGameInfoModelList_MoNiQi;
        List<DreamSparkerModel> _windowsDevAccountList_MoNiQi;

        private string _currentLogo_MoNiQi;
        private string _currentBgImage_MoNiQi;

        public DataGridViewRow CurrentMoNiQiDataGridViewRow_MoNiQi
        {
            get { return _currentDataGridViewRow_MoNiQi; }
            set
            {

                if (_currentDataGridViewRow_MoNiQi != value)
                {
                    _currentDataGridViewRow_MoNiQi = value;

                    this.textBox_GameName.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GameName"].Value.ToString();
                    this.textBox_GameDetails.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GameDetails"].Value.ToString();
                    //this.textBox_MoNiQi_GameName_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_ADName"].Value.ToString();
                    //this.comboBox_MoNiQi_State_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_State"].Value.ToString();

                    //this.textBox_MoNiQi_PubcenterAppID_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_PubcenterAppID"].Value.ToString();
                    //this.textBox_MoNiQi_PubcenterAdID_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_PubcenterAdID"].Value.ToString();
                    //this.textBox_MoNiQi_SurfaceAccountID_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_SurfaceAccountID"].Value.ToString();
                    //this.textBox_MoNiQi_SurfaceAdID_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_SurfaceAdID"].Value.ToString();
                    //this.textBox_MoNiQi_GoogleBanner_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GoogleBanner"].Value.ToString();
                    //this.textBox_MoNiQi_GoogleChaping_Update.Text = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GoogleChaping"].Value.ToString();

                    _currentBgImage_MoNiQi = string.Empty;
                    _currentLogo_MoNiQi = string.Empty;

                }
            }
        }

        public DataGridViewRow CurrentDataGridViewRowDevAccount_MoNiQi
        {
            get { return _currentDataGridViewRowDevAccount_MoNiQi; }
            set
            {

                if (_currentDataGridViewRowDevAccount_MoNiQi != value)
                {
                    _currentDataGridViewRowDevAccount_MoNiQi = value;

                    this.textBox_DevAccount.Text = _currentDataGridViewRowDevAccount_MoNiQi.Cells["Column_Unity_DevAccount"].Value.ToString().Trim();
                    this.textBox_DevPassword.Text = _currentDataGridViewRowDevAccount_MoNiQi.Cells["Column_Unity_DevPassword"].Value.ToString().Trim();
                }
            }
        }

        PushGameInfoModel p_t = null;

        public UnityPackageBuilder()
        {
            InitializeComponent();
            this.Load += UnityPackageBuilder_Load;
        }

        void UnityPackageBuilder_Load(object sender, EventArgs e)
        {
            SetStartButtonEnable();
        }

        private void SetStatusInfo(string info)
        {
            this.toolStripStatusLabel_Status.Text = DateTime.Now.ToString() + "----" + info;
        }

        private void SetStartButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = true;
            this.button_DisableIt.Enabled = false;
            this.button_OpenPackageDir.Enabled = false;
            this.button_SubmitGameInfo.Enabled = false;
            this.button_DevAccountDie.Enabled = false;
            this.button_RePackage.Enabled = false;

            this.textBox_PackageDir.Clear();
            this.textBox_GameDetails.Clear();
            this.textBox_GameName.Clear();
            this.textBox_DevAccount.Clear();
            this.textBox_DevPassword.Clear();

            this.textBox_NewGameName.Clear();
        }

        private void SetDevelopingButtonEnable()
        {
            this.button_Shot_GetNewGame.Enabled = false;
            this.button_DisableIt.Enabled = true;
            this.button_OpenPackageDir.Enabled = true;
            this.button_SubmitGameInfo.Enabled = true;
            this.button_DevAccountDie.Enabled = true;
            this.button_RePackage.Enabled = true;
        }


        private void button_UpdateTables_Click(object sender, EventArgs e)
        {
            try
            {
                SetStatusInfo("正在获取……可能会比较慢,请稍候…………");

                dataGridView_MoNiQi_GameList.Rows.Clear();

                _pushGameInfoModelList_MoNiQi = HttpDataHelper.GetGameList("", "unity待提交", "");

                if (_pushGameInfoModelList_MoNiQi == null || _pushGameInfoModelList_MoNiQi.Count == 0)
                {
                    SetStatusInfo("没有获取到游戏信息");
                    return;
                }

                for (int i = 0; i < _pushGameInfoModelList_MoNiQi.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = i + 1 });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].ID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].GameName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].State });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].SurfaceAccountID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].SurfaceAdID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].GoogleBanner });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].GoogleChaping });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].PubcenterAppID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].PubcenterAdID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].AddTime });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].UpdateTime });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].SourceType });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].FileName });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].GameDetails });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _pushGameInfoModelList_MoNiQi[i].AdName });

                    dataGridView_MoNiQi_GameList.Rows.Add(dgvr);
                }

                dataGridView_MoNiQi_GameList.Columns[0].Width = 150;

                dataGridView_MoNiQi_WinAccountsList.Rows.Clear();
                _windowsDevAccountList_MoNiQi = HttpDataHelper.GetDreamSparkerListByCount("Unity可用", 0);

                if (_windowsDevAccountList_MoNiQi == null || _windowsDevAccountList_MoNiQi.Count == 0)
                {
                    SetStatusInfo("没有获取到开发者账号信息");
                    return;
                }

                _windowsDevAccountList_MoNiQi.Sort((left, right) =>
                {
                    if (int.Parse(left.PushCount) > int.Parse(right.PushCount))
                    {
                        return 1;
                    }
                    else if (int.Parse(left.PushCount) == int.Parse(right.PushCount))
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                });

                for (int i = 0; i < _windowsDevAccountList_MoNiQi.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = i + 1 });

                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _windowsDevAccountList_MoNiQi[i].ID });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _windowsDevAccountList_MoNiQi[i].PushCount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _windowsDevAccountList_MoNiQi[i].DevAccount });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = _windowsDevAccountList_MoNiQi[i].DevPassword });

                    dataGridView_MoNiQi_WinAccountsList.Rows.Add(dgvr);
                }

                SetStatusInfo("获取成功，请继续打包");
            }
            catch (Exception ex)
            {
                SetStatusInfo("获取游戏失败，" + ex.Message);
            }
        }

        private void dataGridView_MoNiQi_WinAccountsList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_MoNiQi_WinAccountsList.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_MoNiQi_WinAccountsList.SelectedCells[0].RowIndex;
                CurrentDataGridViewRowDevAccount_MoNiQi = dataGridView_MoNiQi_WinAccountsList.Rows[index_t];
            }
        }

        private void dataGridView_MoNiQi_GameList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_MoNiQi_GameList.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_MoNiQi_GameList.SelectedCells[0].RowIndex;
                CurrentMoNiQiDataGridViewRow_MoNiQi = dataGridView_MoNiQi_GameList.Rows[index_t];
            }
        }

        private void button_Shot_GetNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                SetStatusInfo("正在打包，可能比较慢……");
                this.button_Shot_GetNewGame.Enabled = false;

                p_t = HttpDataHelper.GetOneGameByID(_currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_ID"].Value.ToString());
                if (p_t.State.ToLower() == "unity开发中")
                {
                    button_UpdateTables_Click(sender, e);
                    SetStatusInfo("上个游戏已经被提交了，请重新来……");

                    this.button_Shot_GetNewGame.Enabled = true;
                    return;
                }

                HttpDataHelper.UpdatePushGameStateInfoByID("unity开发中", _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_ID"].Value.ToString());

                string romsPath = Path.Combine(INIHelper.ReadIniData("user", "rompath", AppDomain.CurrentDomain.BaseDirectory + "unity", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini")));
                string gameFileDir = Path.Combine(romsPath, p_t.FixedGameName);

                if (!Directory.Exists(gameFileDir))
                {
                    button_UpdateTables_Click(sender, e);
                    SetStatusInfo(string.Format("打包失败了，木有找到游戏路径，请重来", p_t.FixedGameName));
                    this.button_Shot_GetNewGame.Enabled = true;
                    return;
                }

                string gameFilePath = string.Empty;

                foreach (var f in Directory.GetFiles(gameFileDir))
                {
                    if (Path.GetExtension(f).ToLower() == ".xap")
                    {
                        gameFilePath = f;
                        break;
                    }
                }

                if (string.IsNullOrWhiteSpace(gameFilePath))
                {
                    button_UpdateTables_Click(sender, e);
                    SetStatusInfo(string.Format("打包失败了，木有找到游戏文件，请重来", p_t.FixedGameName));
                    this.button_Shot_GetNewGame.Enabled = true;
                    return;
                }

                string packageDir = AppDomain.CurrentDomain.BaseDirectory + "temp";
                if (Directory.Exists(packageDir))
                {
                    Directory.Delete(packageDir, true);
                }

                Directory.CreateDirectory(packageDir);
                ZipHelper.ExtractZipFile(gameFilePath, string.Empty, packageDir);

                string configFile = Path.Combine(packageDir, @"Assets\GameConfigInfo.xml");
                if (!File.Exists(configFile))
                {
                    throw new Exception("广告配置文件不存在,解压失败了可能");
                }

                GameConfigInfos gc = new GameConfigInfos
                {
                    GameName = this.textBox_GameName.Text.Trim(),
                    GoogleAdUnitID = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GoogleBanner"].Value.ToString(),
                    GoogleFullScreenAdID = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_GoogleChaping"].Value.ToString(),
                    PubcenterAdUnitIDs = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_PubcenterAdID"].Value.ToString(),
                    PubcenterApplicationID = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_PubcenterAppID"].Value.ToString(),
                    SurfaceAdToken = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_SurfaceAccountID"].Value.ToString(),
                    SurfaceAdPosition = _currentDataGridViewRow_MoNiQi.Cells["Column_MoNiQi_SurfaceAdID"].Value.ToString(),
                    IsEnableSmaatoAdDebug = "0",
                    SmaatoAdID = "0",
                    SmaatoPublisherID = "0"
                };

                string gameInfoEncode = CryptHelper.Encrypt(XmlHelper.XmlSerialize<GameConfigInfos>(gc));

                using (StreamWriter sw = new StreamWriter(configFile, false))
                {
                    sw.WriteLine(gameInfoEncode);

                    sw.Close();
                    sw.Dispose();
                }

                HttpDataHelper.DownloadFile(p_t.LogoPath, Path.Combine(packageDir, @"300.png"));

                string wmXmlPath = Path.Combine(packageDir, @"WMAppManifest.xml");
                XmlHelper.SetGameName(wmXmlPath, (p_t.GameName));
                XmlHelper.SetProductID(wmXmlPath, "{" + Guid.NewGuid().ToString() + "}");

                string xapPath = AppDomain.CurrentDomain.BaseDirectory + "安装包目录";
                if (Directory.Exists(xapPath))
                {
                    Directory.Delete(xapPath, true);
                }
                Directory.CreateDirectory(xapPath);

                ZipHelper.CreateSample(Path.Combine(xapPath, (p_t.GameName) + ".xap"), packageDir);
                if (!File.Exists(Path.Combine(xapPath, (p_t.GameName) + ".xap")))
                {
                    throw new Exception(string.Format("没有打包成游戏文件！请重试或联系我！"));
                }

                foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"unity\" + Path.GetFileNameWithoutExtension(p_t.FileName))))
                {
                    if (Path.GetExtension(file).ToLower() == ".png")
                    {
                        //File.Copy(file, Path.Combine(xapPath, Path.GetFileName(file)));
                        System.Drawing.Image.FromFile(file).Save(Path.Combine(xapPath, Path.GetFileName(file)), System.Drawing.Imaging.ImageFormat.Png);
                    }
                }

                File.Copy(Path.Combine(packageDir, @"300.png"), Path.Combine(xapPath, "300.png"), true);

                SetDevelopingButtonEnable();
                this.textBox_PackageDir.Text = xapPath;
                SetStatusInfo("打包成功，请到 安装包目录 下的 xap 文件提交到商店，完成后点击 提交完成 按钮.");
            }
            catch (Exception ex)
            {
                button_UpdateTables_Click(sender, e);
                SetStatusInfo("失败了，" + ex.Message + ",请重来");
                this.button_Shot_GetNewGame.Enabled = true;
            }
        }

        private void button_RePackage_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要用新的名称吗(○´･д･)ﾉ？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(this.textBox_NewGameName.Text))
                    {
                        SetStatusInfo("请填写新的游戏名称.");
                        return;
                    }

                    this.button_RePackage.Enabled = false;

                    string packageDir = AppDomain.CurrentDomain.BaseDirectory + "temp";

                    string wmXmlPath = Path.Combine(packageDir, @"WMAppManifest.xml");
                    XmlHelper.SetGameName(wmXmlPath, (this.textBox_NewGameName.Text));

                    HttpDataHelper.UpdatePushGameNameByID(this.textBox_NewGameName.Text, p_t.ID);

                    if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                    {
                        foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                        {
                            File.Delete(f);
                        }
                    }

                    string xapPath = AppDomain.CurrentDomain.BaseDirectory + "安装包目录";
                    if (!Directory.Exists(xapPath))
                    {
                        Directory.CreateDirectory(xapPath);
                    }

                    ZipHelper.CreateSample(Path.Combine(xapPath, (p_t.GameName) + ".xap"), packageDir);
                    if (!File.Exists(Path.Combine(xapPath, (p_t.GameName) + ".xap")))
                    {
                        throw new Exception(string.Format("没有打包成游戏文件！请重试或联系我！"));
                    }

                    foreach (var file in Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"unity\" + Path.GetFileNameWithoutExtension(p_t.FileName))))
                    {
                        if (Path.GetExtension(file).ToLower() == ".png")
                        {
                            File.Copy(file, Path.Combine(xapPath, Path.GetFileName(file)));
                        }
                    }

                    File.Copy(Path.Combine(packageDir, @"300.png"), Path.Combine(xapPath, "300.png"));
                    this.textBox_PackageDir.Text = xapPath;

                    this.textBox_GameName.Text = this.textBox_NewGameName.Text;

                    this.button_RePackage.Enabled = true;

                    SetStatusInfo("重新打包成功.");
                }
            }
            catch (Exception ex)
            {
                this.button_RePackage.Enabled = true;
                SetStatusInfo("重新打包失败，" + ex.Message);
            }
        }

        private void button_OpenPackageDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "\"" + this.textBox_PackageDir.Text + "\"");
        }

        private void button_SubmitGameInfo_Click(object sender, EventArgs e)
        {

            HttpDataHelper.DevSuccessedByDreamSpark(p_t.ID, this.textBox_DevAccount.Text, this.textBox_DevPassword.Text);

            SetStatusInfo("提交成功");
            SetStartButtonEnable();

            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
            {
                foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                {
                    File.Delete(f);
                }
            }

            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
            {
                foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                {
                    File.Delete(f);
                }
            }

            button_UpdateTables_Click(sender, e);
        }

        private void button_DevAccountDie_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定账号被封了？账号被封了 (○´･д･)ﾉ？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HttpDataHelper.UpdatePushGameStateInfoByID("Unity待提交", p_t.ID);
                HttpDataHelper.UpdateDreamSparkerByDevAccount(this.textBox_DevAccount.Text, "unity被封");

                SetStatusInfo("被封信息提交成功");
                SetStartButtonEnable();

                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                {
                    foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                    {
                        File.Delete(f);
                    }
                }

                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                {
                    foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                    {
                        File.Delete(f);
                    }
                }
            }

            button_UpdateTables_Click(sender, e);
        }

        private void button_DisableIt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定这个游戏不可用？？？ _(:зゝ∠)_", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                HttpDataHelper.UpdatePushGameStateInfoByID("unity待确认", p_t.ID);
                HttpDataHelper.UpdateDreamSparkerByDevAccount(this.textBox_DevAccount.Text, "unity待确认");

                SetStatusInfo("游戏不可用信息提交成功");
                SetStartButtonEnable();

                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                {
                    foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "tmp"))
                    {
                        File.Delete(f);
                    }
                }

                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                {
                    foreach (var f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "安装包目录"))
                    {
                        File.Delete(f);
                    }
                }
            }

            button_UpdateTables_Click(sender, e);
        }

        private void button_CopyGameName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_GameName.Text))
            {
                Clipboard.SetText(this.textBox_GameName.Text);
            }
        }

        private void button_CopyDevAccount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_DevAccount.Text))
            {
                Clipboard.SetText(this.textBox_DevAccount.Text);
            }
        }

        private void button_CopyDevPassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_DevPassword.Text))
            {
                Clipboard.SetText(this.textBox_DevPassword.Text);
            }
        }

        private void button_CopyGameDetails_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBox_GameDetails.Text))
            {
                Clipboard.SetText(this.textBox_GameDetails.Text);
            }
        }
    }
}
