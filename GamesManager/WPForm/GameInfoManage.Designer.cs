namespace GamesManager
{
    partial class GameInfoManage
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
            this.textBox_GameName = new System.Windows.Forms.TextBox();
            this.comboBox_PusherName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_GameState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_GetGameList = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_DeleteGameInfo = new System.Windows.Forms.Button();
            this.button_UpdateMore = new System.Windows.Forms.Button();
            this.textBox_GameIDMore = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_StateMore = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_PusherUserMore = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_VersionMore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_GameNameMore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_GameList = new System.Windows.Forms.DataGridView();
            this.GameName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PusherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Controls.Add(this.button_GetGameList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 706);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_GameName);
            this.groupBox1.Controls.Add(this.comboBox_PusherName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_GameState);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 240);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // textBox_GameName
            // 
            this.textBox_GameName.Location = new System.Drawing.Point(15, 189);
            this.textBox_GameName.Name = "textBox_GameName";
            this.textBox_GameName.Size = new System.Drawing.Size(134, 25);
            this.textBox_GameName.TabIndex = 4;
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
            this.comboBox_PusherName.Location = new System.Drawing.Point(15, 117);
            this.comboBox_PusherName.Name = "comboBox_PusherName";
            this.comboBox_PusherName.Size = new System.Drawing.Size(134, 23);
            this.comboBox_PusherName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "游戏名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "工作人员";
            // 
            // comboBox_GameState
            // 
            this.comboBox_GameState.FormattingEnabled = true;
            this.comboBox_GameState.Items.AddRange(new object[] {
            "全部",
            "待提交",
            "待审核",
            "已发布",
            "审核失败"});
            this.comboBox_GameState.Location = new System.Drawing.Point(15, 49);
            this.comboBox_GameState.Name = "comboBox_GameState";
            this.comboBox_GameState.Size = new System.Drawing.Size(134, 23);
            this.comboBox_GameState.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "游戏状态";
            // 
            // button_GetGameList
            // 
            this.button_GetGameList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_GetGameList.ForeColor = System.Drawing.Color.Blue;
            this.button_GetGameList.Location = new System.Drawing.Point(31, 249);
            this.button_GetGameList.Name = "button_GetGameList";
            this.button_GetGameList.Size = new System.Drawing.Size(121, 75);
            this.button_GetGameList.TabIndex = 4;
            this.button_GetGameList.Text = "获取游戏";
            this.button_GetGameList.UseVisualStyleBackColor = true;
            this.button_GetGameList.Click += new System.EventHandler(this.button_GetGameList_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(771, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 706);
            this.panel2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_DeleteGameInfo);
            this.groupBox3.Controls.Add(this.button_UpdateMore);
            this.groupBox3.Controls.Add(this.textBox_GameIDMore);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.comboBox_StateMore);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.comboBox_PusherUserMore);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_VersionMore);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox_GameNameMore);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 706);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "详细信息";
            // 
            // button_DeleteGameInfo
            // 
            this.button_DeleteGameInfo.ForeColor = System.Drawing.Color.Red;
            this.button_DeleteGameInfo.Location = new System.Drawing.Point(190, 468);
            this.button_DeleteGameInfo.Name = "button_DeleteGameInfo";
            this.button_DeleteGameInfo.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteGameInfo.TabIndex = 14;
            this.button_DeleteGameInfo.Text = "删除";
            this.button_DeleteGameInfo.UseVisualStyleBackColor = true;
            this.button_DeleteGameInfo.Click += new System.EventHandler(this.button_DeleteGameInfo_Click);
            // 
            // button_UpdateMore
            // 
            this.button_UpdateMore.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_UpdateMore.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button_UpdateMore.Location = new System.Drawing.Point(126, 371);
            this.button_UpdateMore.Name = "button_UpdateMore";
            this.button_UpdateMore.Size = new System.Drawing.Size(139, 72);
            this.button_UpdateMore.TabIndex = 13;
            this.button_UpdateMore.Text = "确认更新";
            this.button_UpdateMore.UseVisualStyleBackColor = true;
            this.button_UpdateMore.Click += new System.EventHandler(this.button_UpdateMore_Click);
            // 
            // textBox_GameIDMore
            // 
            this.textBox_GameIDMore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_GameIDMore.Location = new System.Drawing.Point(9, 309);
            this.textBox_GameIDMore.Name = "textBox_GameIDMore";
            this.textBox_GameIDMore.Size = new System.Drawing.Size(256, 25);
            this.textBox_GameIDMore.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "游戏ID";
            // 
            // comboBox_StateMore
            // 
            this.comboBox_StateMore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_StateMore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_StateMore.FormattingEnabled = true;
            this.comboBox_StateMore.Items.AddRange(new object[] {
            "待提交",
            "待审核",
            "已发布",
            "审核失败"});
            this.comboBox_StateMore.Location = new System.Drawing.Point(9, 181);
            this.comboBox_StateMore.Name = "comboBox_StateMore";
            this.comboBox_StateMore.Size = new System.Drawing.Size(256, 23);
            this.comboBox_StateMore.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "游戏状态";
            // 
            // comboBox_PusherUserMore
            // 
            this.comboBox_PusherUserMore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_PusherUserMore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PusherUserMore.FormattingEnabled = true;
            this.comboBox_PusherUserMore.Items.AddRange(new object[] {
            "全部",
            "待提交",
            "待审核",
            "已发布",
            "审核失败"});
            this.comboBox_PusherUserMore.Location = new System.Drawing.Point(9, 236);
            this.comboBox_PusherUserMore.Name = "comboBox_PusherUserMore";
            this.comboBox_PusherUserMore.Size = new System.Drawing.Size(256, 23);
            this.comboBox_PusherUserMore.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "工作人员";
            // 
            // textBox_VersionMore
            // 
            this.textBox_VersionMore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_VersionMore.Location = new System.Drawing.Point(9, 118);
            this.textBox_VersionMore.Name = "textBox_VersionMore";
            this.textBox_VersionMore.ReadOnly = true;
            this.textBox_VersionMore.Size = new System.Drawing.Size(256, 25);
            this.textBox_VersionMore.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "游戏版本";
            // 
            // textBox_GameNameMore
            // 
            this.textBox_GameNameMore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_GameNameMore.Location = new System.Drawing.Point(9, 52);
            this.textBox_GameNameMore.Name = "textBox_GameNameMore";
            this.textBox_GameNameMore.ReadOnly = true;
            this.textBox_GameNameMore.Size = new System.Drawing.Size(256, 25);
            this.textBox_GameNameMore.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "游戏名称";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(175, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(596, 706);
            this.panel3.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_GameList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(596, 706);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "游戏列表";
            // 
            // dataGridView_GameList
            // 
            this.dataGridView_GameList.AllowUserToAddRows = false;
            this.dataGridView_GameList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_GameList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_GameList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GameName,
            this.Version,
            this.DevAccount,
            this.DevPassword,
            this.State,
            this.PusherName,
            this.GameID});
            this.dataGridView_GameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_GameList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_GameList.Location = new System.Drawing.Point(3, 21);
            this.dataGridView_GameList.MultiSelect = false;
            this.dataGridView_GameList.Name = "dataGridView_GameList";
            this.dataGridView_GameList.RowHeadersVisible = false;
            this.dataGridView_GameList.RowTemplate.Height = 27;
            this.dataGridView_GameList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_GameList.Size = new System.Drawing.Size(590, 682);
            this.dataGridView_GameList.TabIndex = 0;
            this.dataGridView_GameList.SelectionChanged += new System.EventHandler(this.dataGridView_GameList_SelectionChanged);
            // 
            // GameName
            // 
            this.GameName.HeaderText = "游戏名称";
            this.GameName.Name = "GameName";
            this.GameName.ReadOnly = true;
            this.GameName.Width = 92;
            // 
            // Version
            // 
            this.Version.HeaderText = "版本";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            this.Version.Width = 62;
            // 
            // DevAccount
            // 
            this.DevAccount.HeaderText = "开发者账号";
            this.DevAccount.Name = "DevAccount";
            this.DevAccount.ReadOnly = true;
            this.DevAccount.Width = 107;
            // 
            // DevPassword
            // 
            this.DevPassword.HeaderText = "开发者密码";
            this.DevPassword.Name = "DevPassword";
            this.DevPassword.ReadOnly = true;
            this.DevPassword.Width = 107;
            // 
            // State
            // 
            this.State.HeaderText = "游戏状态";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.State.Width = 92;
            // 
            // PusherName
            // 
            this.PusherName.HeaderText = "工作人员";
            this.PusherName.Name = "PusherName";
            this.PusherName.ReadOnly = true;
            this.PusherName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PusherName.Width = 92;
            // 
            // GameID
            // 
            this.GameID.HeaderText = "游戏ID";
            this.GameID.Name = "GameID";
            this.GameID.ReadOnly = true;
            this.GameID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GameID.Width = 78;
            // 
            // GameInfoManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 706);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameInfoManage";
            this.Text = "GameInfoManage";
            this.Shown += new System.EventHandler(this.GameInfoManage_Shown);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_GameName;
        private System.Windows.Forms.ComboBox comboBox_PusherName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_GameState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_GetGameList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_GameList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn PusherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameID;
        private System.Windows.Forms.TextBox textBox_GameNameMore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_PusherUserMore;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_VersionMore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_GameIDMore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_StateMore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_UpdateMore;
        private System.Windows.Forms.Button button_DeleteGameInfo;

    }
}