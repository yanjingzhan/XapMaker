namespace GamesManager.AndroidLiuMangForm
{
    partial class LiuMangAdsManager
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
            this.button_Search = new System.Windows.Forms.Button();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_InAdSiteName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_LiuMangAds = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_AppName_Add = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_IadKey_Add = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_JingZhongKey_Add = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Status_Add = new System.Windows.Forms.ComboBox();
            this.button_AddOne = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_Count_MoreAdd = new System.Windows.Forms.Label();
            this.button_AddMore = new System.Windows.Forms.Button();
            this.Column_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_IadKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_IadAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_JingZhongKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_JingZhongAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LiuMangAds)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Search);
            this.panel1.Controls.Add(this.comboBox_Status);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_InAdSiteName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1092, 100);
            this.panel1.TabIndex = 0;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(856, 21);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(213, 54);
            this.button_Search.TabIndex = 2;
            this.button_Search.Text = "查询";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Items.AddRange(new object[] {
            "全部",
            "已用",
            "空闲",
            "作废"});
            this.comboBox_Status.Location = new System.Drawing.Point(331, 52);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(232, 23);
            this.comboBox_Status.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "状态";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "在广告平台上的名字：";
            // 
            // textBox_InAdSiteName
            // 
            this.textBox_InAdSiteName.Location = new System.Drawing.Point(15, 52);
            this.textBox_InAdSiteName.Name = "textBox_InAdSiteName";
            this.textBox_InAdSiteName.Size = new System.Drawing.Size(218, 25);
            this.textBox_InAdSiteName.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 442);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1092, 301);
            this.panel2.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 269);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1092, 32);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Status
            // 
            this.toolStripStatusLabel_Status.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.toolStripStatusLabel_Status.ForeColor = System.Drawing.Color.Blue;
            this.toolStripStatusLabel_Status.Name = "toolStripStatusLabel_Status";
            this.toolStripStatusLabel_Status.Size = new System.Drawing.Size(27, 27);
            this.toolStripStatusLabel_Status.Text = "...";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView_LiuMangAds);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1092, 342);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView_LiuMangAds
            // 
            this.dataGridView_LiuMangAds.AllowUserToAddRows = false;
            this.dataGridView_LiuMangAds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_LiuMangAds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LiuMangAds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Number,
            this.Column_ID,
            this.Column_IadKey,
            this.Column_IadAppName,
            this.Column_JingZhongKey,
            this.Column_JingZhongAppName,
            this.Column_Status,
            this.Column_Time,
            this.Column_Delete});
            this.dataGridView_LiuMangAds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_LiuMangAds.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_LiuMangAds.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_LiuMangAds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_LiuMangAds.MultiSelect = false;
            this.dataGridView_LiuMangAds.Name = "dataGridView_LiuMangAds";
            this.dataGridView_LiuMangAds.RowHeadersVisible = false;
            this.dataGridView_LiuMangAds.RowTemplate.Height = 27;
            this.dataGridView_LiuMangAds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_LiuMangAds.Size = new System.Drawing.Size(1092, 342);
            this.dataGridView_LiuMangAds.TabIndex = 2;
            this.dataGridView_LiuMangAds.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_LiuMangAds_CellContentClick);
            this.dataGridView_LiuMangAds.SelectionChanged += new System.EventHandler(this.dataGridView_LiuMangAds_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_AddOne);
            this.groupBox1.Controls.Add(this.textBox_JingZhongKey_Add);
            this.groupBox1.Controls.Add(this.comboBox_Status_Add);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_IadKey_Add);
            this.groupBox1.Controls.Add(this.textBox_AppName_Add);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1092, 116);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加单个";
            // 
            // textBox_AppName_Add
            // 
            this.textBox_AppName_Add.Location = new System.Drawing.Point(165, 34);
            this.textBox_AppName_Add.Name = "textBox_AppName_Add";
            this.textBox_AppName_Add.Size = new System.Drawing.Size(218, 25);
            this.textBox_AppName_Add.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "在广告平台上的名字：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "iad:";
            // 
            // textBox_IadKey_Add
            // 
            this.textBox_IadKey_Add.Location = new System.Drawing.Point(166, 74);
            this.textBox_IadKey_Add.Name = "textBox_IadKey_Add";
            this.textBox_IadKey_Add.Size = new System.Drawing.Size(218, 25);
            this.textBox_IadKey_Add.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(399, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "精众：";
            // 
            // textBox_JingZhongKey_Add
            // 
            this.textBox_JingZhongKey_Add.Location = new System.Drawing.Point(457, 75);
            this.textBox_JingZhongKey_Add.Name = "textBox_JingZhongKey_Add";
            this.textBox_JingZhongKey_Add.Size = new System.Drawing.Size(218, 25);
            this.textBox_JingZhongKey_Add.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "状态";
            // 
            // comboBox_Status_Add
            // 
            this.comboBox_Status_Add.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Status_Add.FormattingEnabled = true;
            this.comboBox_Status_Add.Items.AddRange(new object[] {
            "已用",
            "空闲",
            "作废"});
            this.comboBox_Status_Add.Location = new System.Drawing.Point(457, 38);
            this.comboBox_Status_Add.Name = "comboBox_Status_Add";
            this.comboBox_Status_Add.Size = new System.Drawing.Size(218, 23);
            this.comboBox_Status_Add.TabIndex = 1000;
            this.comboBox_Status_Add.TabStop = false;
            // 
            // button_AddOne
            // 
            this.button_AddOne.Location = new System.Drawing.Point(952, 41);
            this.button_AddOne.Name = "button_AddOne";
            this.button_AddOne.Size = new System.Drawing.Size(117, 59);
            this.button_AddOne.TabIndex = 13;
            this.button_AddOne.Text = "添加";
            this.button_AddOne.UseVisualStyleBackColor = true;
            this.button_AddOne.Click += new System.EventHandler(this.button_AddOne_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_AddMore);
            this.groupBox2.Controls.Add(this.label_Count_MoreAdd);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1092, 153);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批量添加（格式：在平台上的名字+tab+iad应用名称+tab+精众广告ID+tab+状态）";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "总数：";
            // 
            // label_Count_MoreAdd
            // 
            this.label_Count_MoreAdd.AutoSize = true;
            this.label_Count_MoreAdd.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Count_MoreAdd.ForeColor = System.Drawing.Color.Blue;
            this.label_Count_MoreAdd.Location = new System.Drawing.Point(166, 40);
            this.label_Count_MoreAdd.Name = "label_Count_MoreAdd";
            this.label_Count_MoreAdd.Size = new System.Drawing.Size(27, 27);
            this.label_Count_MoreAdd.TabIndex = 0;
            this.label_Count_MoreAdd.Text = "0";
            // 
            // button_AddMore
            // 
            this.button_AddMore.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AddMore.ForeColor = System.Drawing.Color.Red;
            this.button_AddMore.Location = new System.Drawing.Point(952, 31);
            this.button_AddMore.Name = "button_AddMore";
            this.button_AddMore.Size = new System.Drawing.Size(117, 59);
            this.button_AddMore.TabIndex = 14;
            this.button_AddMore.Text = "执行";
            this.button_AddMore.UseVisualStyleBackColor = true;
            // 
            // Column_Number
            // 
            this.Column_Number.HeaderText = "序号";
            this.Column_Number.Name = "Column_Number";
            this.Column_Number.ReadOnly = true;
            this.Column_Number.Width = 62;
            // 
            // Column_ID
            // 
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 48;
            // 
            // Column_IadKey
            // 
            this.Column_IadKey.HeaderText = "Iad广告ID";
            this.Column_IadKey.Name = "Column_IadKey";
            this.Column_IadKey.ReadOnly = true;
            this.Column_IadKey.Width = 102;
            // 
            // Column_IadAppName
            // 
            this.Column_IadAppName.HeaderText = "Iad应用名称";
            this.Column_IadAppName.Name = "Column_IadAppName";
            this.Column_IadAppName.ReadOnly = true;
            this.Column_IadAppName.Width = 79;
            // 
            // Column_JingZhongKey
            // 
            this.Column_JingZhongKey.HeaderText = "精众广告ID";
            this.Column_JingZhongKey.Name = "Column_JingZhongKey";
            this.Column_JingZhongKey.ReadOnly = true;
            this.Column_JingZhongKey.Width = 85;
            // 
            // Column_JingZhongAppName
            // 
            this.Column_JingZhongAppName.HeaderText = "精众应用名称";
            this.Column_JingZhongAppName.Name = "Column_JingZhongAppName";
            this.Column_JingZhongAppName.ReadOnly = true;
            this.Column_JingZhongAppName.Width = 85;
            // 
            // Column_Status
            // 
            this.Column_Status.HeaderText = "状态";
            this.Column_Status.Name = "Column_Status";
            this.Column_Status.ReadOnly = true;
            this.Column_Status.Width = 58;
            // 
            // Column_Time
            // 
            this.Column_Time.HeaderText = "添加时间";
            this.Column_Time.Name = "Column_Time";
            this.Column_Time.ReadOnly = true;
            this.Column_Time.Width = 71;
            // 
            // Column_Delete
            // 
            this.Column_Delete.HeaderText = "删  除";
            this.Column_Delete.Name = "Column_Delete";
            this.Column_Delete.Text = "删  除";
            this.Column_Delete.Width = 40;
            // 
            // LiuMangAdsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 743);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "LiuMangAdsManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LiuMangAdsManager";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LiuMangAds)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_InAdSiteName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.DataGridView dataGridView_LiuMangAds;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_AppName_Add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_AddOne;
        private System.Windows.Forms.TextBox textBox_JingZhongKey_Add;
        private System.Windows.Forms.ComboBox comboBox_Status_Add;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_IadKey_Add;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_Count_MoreAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_AddMore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IadKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IadAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_JingZhongKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_JingZhongAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Time;
        private System.Windows.Forms.DataGridViewButtonColumn Column_Delete;
    }
}