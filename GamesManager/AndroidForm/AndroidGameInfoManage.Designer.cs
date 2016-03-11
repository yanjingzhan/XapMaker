namespace GamesManager.AndroidForm
{
    partial class AndroidGameInfoManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_GetGameList = new System.Windows.Forms.Button();
            this.textBox_GameName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_PusherName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_DeleteGameInfo = new System.Windows.Forms.Button();
            this.button_UpdateMore = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_BaiduStoreStatus = new System.Windows.Forms.ComboBox();
            this.comboBox_PusherUser = new System.Windows.Forms.ComboBox();
            this.comboBox_XiaomiStoreStatus = new System.Windows.Forms.ComboBox();
            this.comboBox_SanLiuLingStoreStatus = new System.Windows.Forms.ComboBox();
            this.label_GameName = new System.Windows.Forms.Label();
            this.label_FileName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_GameList = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaiduStoreDevAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaiduStoreDevPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaiduStoreStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SanLiuLingStoreDevAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SanLiuLingStoreDevPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SanLiuLingStoreStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XiaomiStoreDevAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XiaomiStoreDevPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XiaomiStoreStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PusherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GameList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1443, 125);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button_GetGameList);
            this.groupBox1.Controls.Add(this.textBox_GameName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_PusherName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1443, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(33, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "下列二项什么都不选表示查询所有";
            // 
            // button_GetGameList
            // 
            this.button_GetGameList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_GetGameList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_GetGameList.ForeColor = System.Drawing.Color.Blue;
            this.button_GetGameList.Location = new System.Drawing.Point(1307, 35);
            this.button_GetGameList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_GetGameList.Name = "button_GetGameList";
            this.button_GetGameList.Size = new System.Drawing.Size(121, 75);
            this.button_GetGameList.TabIndex = 11;
            this.button_GetGameList.Text = "查询游戏";
            this.button_GetGameList.UseVisualStyleBackColor = true;
            this.button_GetGameList.Click += new System.EventHandler(this.button_GetGameList_Click);
            // 
            // textBox_GameName
            // 
            this.textBox_GameName.Location = new System.Drawing.Point(573, 72);
            this.textBox_GameName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_GameName.Name = "textBox_GameName";
            this.textBox_GameName.Size = new System.Drawing.Size(323, 25);
            this.textBox_GameName.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "游戏名称";
            // 
            // comboBox_PusherName
            // 
            this.comboBox_PusherName.FormattingEnabled = true;
            this.comboBox_PusherName.Items.AddRange(new object[] {
            "全部",
            "待提交",
            "待审核",
            "已发布",
            "审核失败"});
            this.comboBox_PusherName.Location = new System.Drawing.Point(109, 72);
            this.comboBox_PusherName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_PusherName.Name = "comboBox_PusherName";
            this.comboBox_PusherName.Size = new System.Drawing.Size(300, 23);
            this.comboBox_PusherName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "工作人员";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 495);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1443, 210);
            this.panel2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_DeleteGameInfo);
            this.groupBox3.Controls.Add(this.button_UpdateMore);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBox_BaiduStoreStatus);
            this.groupBox3.Controls.Add(this.comboBox_PusherUser);
            this.groupBox3.Controls.Add(this.comboBox_XiaomiStoreStatus);
            this.groupBox3.Controls.Add(this.comboBox_SanLiuLingStoreStatus);
            this.groupBox3.Controls.Add(this.label_GameName);
            this.groupBox3.Controls.Add(this.label_FileName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1443, 210);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "更新或删除";
            // 
            // button_DeleteGameInfo
            // 
            this.button_DeleteGameInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_DeleteGameInfo.ForeColor = System.Drawing.Color.Red;
            this.button_DeleteGameInfo.Location = new System.Drawing.Point(1341, 142);
            this.button_DeleteGameInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_DeleteGameInfo.Name = "button_DeleteGameInfo";
            this.button_DeleteGameInfo.Size = new System.Drawing.Size(87, 35);
            this.button_DeleteGameInfo.TabIndex = 16;
            this.button_DeleteGameInfo.Text = "删除";
            this.button_DeleteGameInfo.UseVisualStyleBackColor = true;
            this.button_DeleteGameInfo.Click += new System.EventHandler(this.button_DeleteGameInfo_Click);
            // 
            // button_UpdateMore
            // 
            this.button_UpdateMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_UpdateMore.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_UpdateMore.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button_UpdateMore.Location = new System.Drawing.Point(1289, 46);
            this.button_UpdateMore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_UpdateMore.Name = "button_UpdateMore";
            this.button_UpdateMore.Size = new System.Drawing.Size(139, 72);
            this.button_UpdateMore.TabIndex = 15;
            this.button_UpdateMore.Text = "确认更新";
            this.button_UpdateMore.UseVisualStyleBackColor = true;
            this.button_UpdateMore.Click += new System.EventHandler(this.button_UpdateMore_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 155);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "工作人员";
            // 
            // comboBox_BaiduStoreStatus
            // 
            this.comboBox_BaiduStoreStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BaiduStoreStatus.FormattingEnabled = true;
            this.comboBox_BaiduStoreStatus.Items.AddRange(new object[] {
            "待提交",
            "待审核",
            "已发布",
            "审核失败"});
            this.comboBox_BaiduStoreStatus.Location = new System.Drawing.Point(728, 38);
            this.comboBox_BaiduStoreStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_BaiduStoreStatus.Name = "comboBox_BaiduStoreStatus";
            this.comboBox_BaiduStoreStatus.Size = new System.Drawing.Size(256, 23);
            this.comboBox_BaiduStoreStatus.TabIndex = 11;
            // 
            // comboBox_PusherUser
            // 
            this.comboBox_PusherUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PusherUser.FormattingEnabled = true;
            this.comboBox_PusherUser.Location = new System.Drawing.Point(96, 151);
            this.comboBox_PusherUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_PusherUser.Name = "comboBox_PusherUser";
            this.comboBox_PusherUser.Size = new System.Drawing.Size(256, 23);
            this.comboBox_PusherUser.TabIndex = 11;
            // 
            // comboBox_XiaomiStoreStatus
            // 
            this.comboBox_XiaomiStoreStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_XiaomiStoreStatus.FormattingEnabled = true;
            this.comboBox_XiaomiStoreStatus.Items.AddRange(new object[] {
            "待提交",
            "待审核",
            "已发布",
            "审核失败"});
            this.comboBox_XiaomiStoreStatus.Location = new System.Drawing.Point(728, 152);
            this.comboBox_XiaomiStoreStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_XiaomiStoreStatus.Name = "comboBox_XiaomiStoreStatus";
            this.comboBox_XiaomiStoreStatus.Size = new System.Drawing.Size(256, 23);
            this.comboBox_XiaomiStoreStatus.TabIndex = 11;
            // 
            // comboBox_SanLiuLingStoreStatus
            // 
            this.comboBox_SanLiuLingStoreStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SanLiuLingStoreStatus.FormattingEnabled = true;
            this.comboBox_SanLiuLingStoreStatus.Items.AddRange(new object[] {
            "待提交",
            "待审核",
            "已发布",
            "审核失败"});
            this.comboBox_SanLiuLingStoreStatus.Location = new System.Drawing.Point(728, 100);
            this.comboBox_SanLiuLingStoreStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_SanLiuLingStoreStatus.Name = "comboBox_SanLiuLingStoreStatus";
            this.comboBox_SanLiuLingStoreStatus.Size = new System.Drawing.Size(256, 23);
            this.comboBox_SanLiuLingStoreStatus.TabIndex = 11;
            // 
            // label_GameName
            // 
            this.label_GameName.AutoSize = true;
            this.label_GameName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_GameName.ForeColor = System.Drawing.Color.Red;
            this.label_GameName.Location = new System.Drawing.Point(93, 92);
            this.label_GameName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_GameName.Name = "label_GameName";
            this.label_GameName.Size = new System.Drawing.Size(26, 32);
            this.label_GameName.TabIndex = 0;
            this.label_GameName.Text = "-";
            // 
            // label_FileName
            // 
            this.label_FileName.AutoSize = true;
            this.label_FileName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_FileName.ForeColor = System.Drawing.Color.Red;
            this.label_FileName.Location = new System.Drawing.Point(93, 29);
            this.label_FileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_FileName.Name = "label_FileName";
            this.label_FileName.Size = new System.Drawing.Size(26, 32);
            this.label_FileName.TabIndex = 0;
            this.label_FileName.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(619, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "百度商店状态";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(619, 156);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "小米商店状态";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(619, 104);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "360商店状态";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 101);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "游戏名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "文件名";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 125);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1443, 370);
            this.panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_GameList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1443, 370);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "游戏列表";
            // 
            // dataGridView_GameList
            // 
            this.dataGridView_GameList.AllowUserToAddRows = false;
            this.dataGridView_GameList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_GameList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_GameList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.GameName,
            this.BaiduStoreDevAccount,
            this.BaiduStoreDevPassword,
            this.BaiduStoreStatus,
            this.SanLiuLingStoreDevAccount,
            this.SanLiuLingStoreDevPassword,
            this.SanLiuLingStoreStatus,
            this.XiaomiStoreDevAccount,
            this.XiaomiStoreDevPassword,
            this.XiaomiStoreStatus,
            this.PusherName});
            this.dataGridView_GameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_GameList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_GameList.Location = new System.Drawing.Point(3, 20);
            this.dataGridView_GameList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_GameList.MultiSelect = false;
            this.dataGridView_GameList.Name = "dataGridView_GameList";
            this.dataGridView_GameList.RowHeadersVisible = false;
            this.dataGridView_GameList.RowTemplate.Height = 27;
            this.dataGridView_GameList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_GameList.Size = new System.Drawing.Size(1437, 348);
            this.dataGridView_GameList.TabIndex = 0;
            this.dataGridView_GameList.SelectionChanged += new System.EventHandler(this.dataGridView_GameList_SelectionChanged);
            // 
            // FileName
            // 
            this.FileName.HeaderText = "文件名";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 71;
            // 
            // GameName
            // 
            this.GameName.HeaderText = "游戏名称";
            this.GameName.Name = "GameName";
            this.GameName.ReadOnly = true;
            this.GameName.Width = 71;
            // 
            // BaiduStoreDevAccount
            // 
            this.BaiduStoreDevAccount.HeaderText = "百度开发者账号";
            this.BaiduStoreDevAccount.Name = "BaiduStoreDevAccount";
            this.BaiduStoreDevAccount.ReadOnly = true;
            this.BaiduStoreDevAccount.Width = 98;
            // 
            // BaiduStoreDevPassword
            // 
            this.BaiduStoreDevPassword.HeaderText = "百度开发者密码";
            this.BaiduStoreDevPassword.Name = "BaiduStoreDevPassword";
            this.BaiduStoreDevPassword.ReadOnly = true;
            this.BaiduStoreDevPassword.Width = 98;
            // 
            // BaiduStoreStatus
            // 
            this.BaiduStoreStatus.HeaderText = "百度商店状态";
            this.BaiduStoreStatus.Name = "BaiduStoreStatus";
            this.BaiduStoreStatus.ReadOnly = true;
            this.BaiduStoreStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BaiduStoreStatus.Width = 85;
            // 
            // SanLiuLingStoreDevAccount
            // 
            this.SanLiuLingStoreDevAccount.HeaderText = "360开发者账号";
            this.SanLiuLingStoreDevAccount.Name = "SanLiuLingStoreDevAccount";
            this.SanLiuLingStoreDevAccount.Width = 93;
            // 
            // SanLiuLingStoreDevPassword
            // 
            this.SanLiuLingStoreDevPassword.HeaderText = "360开发者密码";
            this.SanLiuLingStoreDevPassword.Name = "SanLiuLingStoreDevPassword";
            this.SanLiuLingStoreDevPassword.Width = 93;
            // 
            // SanLiuLingStoreStatus
            // 
            this.SanLiuLingStoreStatus.HeaderText = "360商店状态";
            this.SanLiuLingStoreStatus.Name = "SanLiuLingStoreStatus";
            this.SanLiuLingStoreStatus.Width = 79;
            // 
            // XiaomiStoreDevAccount
            // 
            this.XiaomiStoreDevAccount.HeaderText = "小米开发者账号";
            this.XiaomiStoreDevAccount.Name = "XiaomiStoreDevAccount";
            this.XiaomiStoreDevAccount.Width = 98;
            // 
            // XiaomiStoreDevPassword
            // 
            this.XiaomiStoreDevPassword.HeaderText = "小米开发者密码";
            this.XiaomiStoreDevPassword.Name = "XiaomiStoreDevPassword";
            this.XiaomiStoreDevPassword.Width = 98;
            // 
            // XiaomiStoreStatus
            // 
            this.XiaomiStoreStatus.HeaderText = "小米商店状态";
            this.XiaomiStoreStatus.Name = "XiaomiStoreStatus";
            this.XiaomiStoreStatus.Width = 85;
            // 
            // PusherName
            // 
            this.PusherName.HeaderText = "工作人员";
            this.PusherName.Name = "PusherName";
            this.PusherName.ReadOnly = true;
            this.PusherName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PusherName.Width = 71;
            // 
            // AndroidGameInfoManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 705);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AndroidGameInfoManage";
            this.Text = "AndroidGameInfoManage";
            this.Shown += new System.EventHandler(this.AndroidGameInfoManage_Shown);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GameList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_GameName;
        private System.Windows.Forms.ComboBox comboBox_PusherName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_GetGameList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_GameList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_FileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_GameName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_BaiduStoreStatus;
        private System.Windows.Forms.ComboBox comboBox_XiaomiStoreStatus;
        private System.Windows.Forms.ComboBox comboBox_SanLiuLingStoreStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox_PusherUser;
        private System.Windows.Forms.Button button_DeleteGameInfo;
        private System.Windows.Forms.Button button_UpdateMore;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaiduStoreDevAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaiduStoreDevPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaiduStoreStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SanLiuLingStoreDevAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SanLiuLingStoreDevPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn SanLiuLingStoreStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn XiaomiStoreDevAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn XiaomiStoreDevPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn XiaomiStoreStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PusherName;
    }
}