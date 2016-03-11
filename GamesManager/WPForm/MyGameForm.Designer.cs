namespace GamesManager
{
    partial class MyGameForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_GameList = new System.Windows.Forms.DataGridView();
            this.GameName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PusherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_DevPasswordMore = new System.Windows.Forms.TextBox();
            this.textBox_VersionMore = new System.Windows.Forms.TextBox();
            this.textBox_DevAccountMore = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_GameNameMore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox_GameInfo = new System.Windows.Forms.RichTextBox();
            this.button_SubmitDone = new System.Windows.Forms.Button();
            this.button_OpenInDir = new System.Windows.Forms.Button();
            this.button_CreateXap = new System.Windows.Forms.Button();
            this.button_GetGameInfo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_GameName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GameList)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 464);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_GameList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(526, 384);
            this.groupBox2.TabIndex = 5;
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
            this.dataGridView_GameList.Location = new System.Drawing.Point(2, 16);
            this.dataGridView_GameList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_GameList.MultiSelect = false;
            this.dataGridView_GameList.Name = "dataGridView_GameList";
            this.dataGridView_GameList.RowHeadersVisible = false;
            this.dataGridView_GameList.RowTemplate.Height = 27;
            this.dataGridView_GameList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_GameList.Size = new System.Drawing.Size(522, 366);
            this.dataGridView_GameList.TabIndex = 0;
            this.dataGridView_GameList.SelectionChanged += new System.EventHandler(this.dataGridView_GameList_SelectionChanged);
            // 
            // GameName
            // 
            this.GameName.HeaderText = "游戏名称";
            this.GameName.Name = "GameName";
            this.GameName.ReadOnly = true;
            this.GameName.Width = 78;
            // 
            // Version
            // 
            this.Version.HeaderText = "版本";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            this.Version.Width = 54;
            // 
            // DevAccount
            // 
            this.DevAccount.HeaderText = "开发者账号";
            this.DevAccount.Name = "DevAccount";
            this.DevAccount.ReadOnly = true;
            this.DevAccount.Width = 90;
            // 
            // DevPassword
            // 
            this.DevPassword.HeaderText = "开发者密码";
            this.DevPassword.Name = "DevPassword";
            this.DevPassword.ReadOnly = true;
            this.DevPassword.Width = 90;
            // 
            // State
            // 
            this.State.HeaderText = "游戏状态";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.State.Width = 78;
            // 
            // PusherName
            // 
            this.PusherName.HeaderText = "工作人员";
            this.PusherName.Name = "PusherName";
            this.PusherName.ReadOnly = true;
            this.PusherName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PusherName.Width = 78;
            // 
            // GameID
            // 
            this.GameID.HeaderText = "游戏ID";
            this.GameID.Name = "GameID";
            this.GameID.ReadOnly = true;
            this.GameID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GameID.Width = 66;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 384);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(526, 80);
            this.panel3.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_DevPasswordMore);
            this.groupBox3.Controls.Add(this.textBox_VersionMore);
            this.groupBox3.Controls.Add(this.textBox_DevAccountMore);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox_GameNameMore);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(526, 80);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "详细信息";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "开发者密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "游戏版本";
            // 
            // textBox_DevPasswordMore
            // 
            this.textBox_DevPasswordMore.Location = new System.Drawing.Point(346, 52);
            this.textBox_DevPasswordMore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_DevPasswordMore.Name = "textBox_DevPasswordMore";
            this.textBox_DevPasswordMore.ReadOnly = true;
            this.textBox_DevPasswordMore.Size = new System.Drawing.Size(172, 21);
            this.textBox_DevPasswordMore.TabIndex = 4;
            // 
            // textBox_VersionMore
            // 
            this.textBox_VersionMore.Location = new System.Drawing.Point(62, 52);
            this.textBox_VersionMore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_VersionMore.Name = "textBox_VersionMore";
            this.textBox_VersionMore.ReadOnly = true;
            this.textBox_VersionMore.Size = new System.Drawing.Size(201, 21);
            this.textBox_VersionMore.TabIndex = 2;
            // 
            // textBox_DevAccountMore
            // 
            this.textBox_DevAccountMore.Location = new System.Drawing.Point(346, 16);
            this.textBox_DevAccountMore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_DevAccountMore.Name = "textBox_DevAccountMore";
            this.textBox_DevAccountMore.ReadOnly = true;
            this.textBox_DevAccountMore.Size = new System.Drawing.Size(172, 21);
            this.textBox_DevAccountMore.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(280, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "开发者账号";
            // 
            // textBox_GameNameMore
            // 
            this.textBox_GameNameMore.Location = new System.Drawing.Point(62, 16);
            this.textBox_GameNameMore.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_GameNameMore.Name = "textBox_GameNameMore";
            this.textBox_GameNameMore.ReadOnly = true;
            this.textBox_GameNameMore.Size = new System.Drawing.Size(201, 21);
            this.textBox_GameNameMore.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "游戏名称";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(526, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 464);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox_GameInfo);
            this.groupBox1.Controls.Add(this.button_SubmitDone);
            this.groupBox1.Controls.Add(this.button_OpenInDir);
            this.groupBox1.Controls.Add(this.button_CreateXap);
            this.groupBox1.Controls.Add(this.button_GetGameInfo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_GameName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox_Logo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(352, 464);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "游戏打包";
            // 
            // richTextBox_GameInfo
            // 
            this.richTextBox_GameInfo.Location = new System.Drawing.Point(15, 210);
            this.richTextBox_GameInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox_GameInfo.Name = "richTextBox_GameInfo";
            this.richTextBox_GameInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox_GameInfo.Size = new System.Drawing.Size(328, 118);
            this.richTextBox_GameInfo.TabIndex = 28;
            this.richTextBox_GameInfo.Text = "";
            // 
            // button_SubmitDone
            // 
            this.button_SubmitDone.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SubmitDone.ForeColor = System.Drawing.Color.Red;
            this.button_SubmitDone.Location = new System.Drawing.Point(223, 406);
            this.button_SubmitDone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_SubmitDone.Name = "button_SubmitDone";
            this.button_SubmitDone.Size = new System.Drawing.Size(119, 46);
            this.button_SubmitDone.TabIndex = 27;
            this.button_SubmitDone.Text = "确认提交完成";
            this.button_SubmitDone.UseVisualStyleBackColor = true;
            this.button_SubmitDone.Click += new System.EventHandler(this.button_SubmitDone_Click);
            // 
            // button_OpenInDir
            // 
            this.button_OpenInDir.Location = new System.Drawing.Point(250, 373);
            this.button_OpenInDir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_OpenInDir.Name = "button_OpenInDir";
            this.button_OpenInDir.Size = new System.Drawing.Size(92, 24);
            this.button_OpenInDir.TabIndex = 26;
            this.button_OpenInDir.Text = "打开安装包目录";
            this.button_OpenInDir.UseVisualStyleBackColor = true;
            this.button_OpenInDir.Click += new System.EventHandler(this.button_OpenInDir_Click);
            // 
            // button_CreateXap
            // 
            this.button_CreateXap.Location = new System.Drawing.Point(238, 333);
            this.button_CreateXap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_CreateXap.Name = "button_CreateXap";
            this.button_CreateXap.Size = new System.Drawing.Size(104, 35);
            this.button_CreateXap.TabIndex = 25;
            this.button_CreateXap.Text = "生成安装包";
            this.button_CreateXap.UseVisualStyleBackColor = true;
            this.button_CreateXap.Click += new System.EventHandler(this.button_CreateXap_Click);
            // 
            // button_GetGameInfo
            // 
            this.button_GetGameInfo.Location = new System.Drawing.Point(274, 181);
            this.button_GetGameInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_GetGameInfo.Name = "button_GetGameInfo";
            this.button_GetGameInfo.Size = new System.Drawing.Size(69, 22);
            this.button_GetGameInfo.TabIndex = 24;
            this.button_GetGameInfo.Text = "获取描述";
            this.button_GetGameInfo.UseVisualStyleBackColor = true;
            this.button_GetGameInfo.Click += new System.EventHandler(this.button_GetGameInfo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "游戏描述";
            // 
            // textBox_GameName
            // 
            this.textBox_GameName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_GameName.Location = new System.Drawing.Point(132, 154);
            this.textBox_GameName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_GameName.Name = "textBox_GameName";
            this.textBox_GameName.ReadOnly = true;
            this.textBox_GameName.Size = new System.Drawing.Size(212, 21);
            this.textBox_GameName.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("方正等线", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "图片必须为Png格式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "游戏发布名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "点击下方的方块选择图标，或者直接把图片拖进来";
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Logo.Location = new System.Drawing.Point(13, 54);
            this.pictureBox_Logo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.Size = new System.Drawing.Size(113, 120);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Logo.TabIndex = 19;
            this.pictureBox_Logo.TabStop = false;
            this.pictureBox_Logo.Click += new System.EventHandler(this.pictureBox_Logo_Click);
            // 
            // MyGameForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 464);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MyGameForm";
            this.Text = "MyGame";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyGameForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyGameForm_DragEnter);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GameList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_GameList;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn PusherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_DevPasswordMore;
        private System.Windows.Forms.TextBox textBox_VersionMore;
        private System.Windows.Forms.TextBox textBox_DevAccountMore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_GameNameMore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_GameName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_Logo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_CreateXap;
        private System.Windows.Forms.Button button_GetGameInfo;
        private System.Windows.Forms.Button button_SubmitDone;
        private System.Windows.Forms.Button button_OpenInDir;
        private System.Windows.Forms.RichTextBox richTextBox_GameInfo;
    }
}