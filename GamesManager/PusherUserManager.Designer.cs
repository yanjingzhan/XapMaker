namespace GamesManager
{
    partial class PusherUserManager
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_RoleAdd = new System.Windows.Forms.ComboBox();
            this.button_SubmitAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_PusherNameAdd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_PasswordAdd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_DeleteEdit = new System.Windows.Forms.Button();
            this.button_SubmitEdit = new System.Windows.Forms.Button();
            this.comboBox_RoleEdit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_PasswordEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_PusherNameEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_AllUsers = new System.Windows.Forms.DataGridView();
            this.PusherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_SelectPusherNames = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Info = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AllUsers)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(760, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 595);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_RoleAdd);
            this.groupBox2.Controls.Add(this.button_SubmitAdd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_PusherNameAdd);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_PasswordAdd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 298);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加新的";
            // 
            // comboBox_RoleAdd
            // 
            this.comboBox_RoleAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RoleAdd.FormattingEnabled = true;
            this.comboBox_RoleAdd.Items.AddRange(new object[] {
            "工作人员",
            "管理员"});
            this.comboBox_RoleAdd.Location = new System.Drawing.Point(20, 186);
            this.comboBox_RoleAdd.Name = "comboBox_RoleAdd";
            this.comboBox_RoleAdd.Size = new System.Drawing.Size(267, 23);
            this.comboBox_RoleAdd.TabIndex = 3;
            // 
            // button_SubmitAdd
            // 
            this.button_SubmitAdd.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SubmitAdd.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button_SubmitAdd.Location = new System.Drawing.Point(206, 226);
            this.button_SubmitAdd.Name = "button_SubmitAdd";
            this.button_SubmitAdd.Size = new System.Drawing.Size(81, 55);
            this.button_SubmitAdd.TabIndex = 4;
            this.button_SubmitAdd.Text = "确定添加";
            this.button_SubmitAdd.UseVisualStyleBackColor = true;
            this.button_SubmitAdd.Click += new System.EventHandler(this.button_SubmitAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "工作人员名字";
            // 
            // textBox_PusherNameAdd
            // 
            this.textBox_PusherNameAdd.Location = new System.Drawing.Point(20, 55);
            this.textBox_PusherNameAdd.Name = "textBox_PusherNameAdd";
            this.textBox_PusherNameAdd.Size = new System.Drawing.Size(267, 25);
            this.textBox_PusherNameAdd.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "角色";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "密码";
            // 
            // textBox_PasswordAdd
            // 
            this.textBox_PasswordAdd.Location = new System.Drawing.Point(20, 118);
            this.textBox_PasswordAdd.Name = "textBox_PasswordAdd";
            this.textBox_PasswordAdd.Size = new System.Drawing.Size(267, 25);
            this.textBox_PasswordAdd.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_DeleteEdit);
            this.groupBox1.Controls.Add(this.button_SubmitEdit);
            this.groupBox1.Controls.Add(this.comboBox_RoleEdit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_PasswordEdit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_PusherNameEdit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "更新或删除";
            // 
            // button_DeleteEdit
            // 
            this.button_DeleteEdit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_DeleteEdit.ForeColor = System.Drawing.Color.OrangeRed;
            this.button_DeleteEdit.Location = new System.Drawing.Point(125, 257);
            this.button_DeleteEdit.Name = "button_DeleteEdit";
            this.button_DeleteEdit.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteEdit.TabIndex = 5;
            this.button_DeleteEdit.Text = "删除";
            this.button_DeleteEdit.UseVisualStyleBackColor = true;
            this.button_DeleteEdit.Click += new System.EventHandler(this.button_DeleteEdit_Click);
            // 
            // button_SubmitEdit
            // 
            this.button_SubmitEdit.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SubmitEdit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button_SubmitEdit.Location = new System.Drawing.Point(206, 225);
            this.button_SubmitEdit.Name = "button_SubmitEdit";
            this.button_SubmitEdit.Size = new System.Drawing.Size(81, 55);
            this.button_SubmitEdit.TabIndex = 4;
            this.button_SubmitEdit.Text = "确定更新";
            this.button_SubmitEdit.UseVisualStyleBackColor = true;
            this.button_SubmitEdit.Click += new System.EventHandler(this.button_SubmitEdit_Click);
            // 
            // comboBox_RoleEdit
            // 
            this.comboBox_RoleEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RoleEdit.FormattingEnabled = true;
            this.comboBox_RoleEdit.Items.AddRange(new object[] {
            "工作人员",
            "管理员"});
            this.comboBox_RoleEdit.Location = new System.Drawing.Point(20, 181);
            this.comboBox_RoleEdit.Name = "comboBox_RoleEdit";
            this.comboBox_RoleEdit.Size = new System.Drawing.Size(267, 23);
            this.comboBox_RoleEdit.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "角色";
            // 
            // textBox_PasswordEdit
            // 
            this.textBox_PasswordEdit.Location = new System.Drawing.Point(20, 115);
            this.textBox_PasswordEdit.Name = "textBox_PasswordEdit";
            this.textBox_PasswordEdit.Size = new System.Drawing.Size(267, 25);
            this.textBox_PasswordEdit.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "密码";
            // 
            // textBox_PusherNameEdit
            // 
            this.textBox_PusherNameEdit.Location = new System.Drawing.Point(20, 54);
            this.textBox_PusherNameEdit.Name = "textBox_PusherNameEdit";
            this.textBox_PusherNameEdit.ReadOnly = true;
            this.textBox_PusherNameEdit.Size = new System.Drawing.Size(267, 25);
            this.textBox_PusherNameEdit.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作人员名字";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 595);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_AllUsers);
            this.groupBox3.Controls.Add(this.button_SelectPusherNames);
            this.groupBox3.Controls.Add(this.statusStrip1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 595);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "所有";
            // 
            // dataGridView_AllUsers
            // 
            this.dataGridView_AllUsers.AllowUserToAddRows = false;
            this.dataGridView_AllUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_AllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_AllUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PusherName,
            this.Password,
            this.Role,
            this.AddTime});
            this.dataGridView_AllUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_AllUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_AllUsers.Location = new System.Drawing.Point(3, 21);
            this.dataGridView_AllUsers.MultiSelect = false;
            this.dataGridView_AllUsers.Name = "dataGridView_AllUsers";
            this.dataGridView_AllUsers.RowHeadersVisible = false;
            this.dataGridView_AllUsers.RowTemplate.Height = 27;
            this.dataGridView_AllUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_AllUsers.Size = new System.Drawing.Size(754, 445);
            this.dataGridView_AllUsers.TabIndex = 0;
            this.dataGridView_AllUsers.SelectionChanged += new System.EventHandler(this.dataGridView_AllUsers_SelectionChanged);
            // 
            // PusherName
            // 
            this.PusherName.HeaderText = "名字";
            this.PusherName.Name = "PusherName";
            this.PusherName.Width = 62;
            // 
            // Password
            // 
            this.Password.HeaderText = "密码";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 62;
            // 
            // Role
            // 
            this.Role.HeaderText = "角色";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            this.Role.Width = 62;
            // 
            // AddTime
            // 
            this.AddTime.HeaderText = "添加时间";
            this.AddTime.Name = "AddTime";
            this.AddTime.ReadOnly = true;
            this.AddTime.Width = 92;
            // 
            // button_SelectPusherNames
            // 
            this.button_SelectPusherNames.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_SelectPusherNames.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SelectPusherNames.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_SelectPusherNames.Location = new System.Drawing.Point(3, 466);
            this.button_SelectPusherNames.Name = "button_SelectPusherNames";
            this.button_SelectPusherNames.Size = new System.Drawing.Size(754, 98);
            this.button_SelectPusherNames.TabIndex = 2;
            this.button_SelectPusherNames.Text = "点击获取人员";
            this.button_SelectPusherNames.UseVisualStyleBackColor = true;
            this.button_SelectPusherNames.Click += new System.EventHandler(this.button_SelectPusherNames_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Info});
            this.statusStrip1.Location = new System.Drawing.Point(3, 564);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(754, 28);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Info
            // 
            this.toolStripStatusLabel_Info.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.toolStripStatusLabel_Info.Name = "toolStripStatusLabel_Info";
            this.toolStripStatusLabel_Info.Size = new System.Drawing.Size(38, 23);
            this.toolStripStatusLabel_Info.Text = "----";
            // 
            // PusherUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 595);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "PusherUserManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工作人员管理";
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_AllUsers)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView_AllUsers;
        private System.Windows.Forms.Button button_SelectPusherNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn PusherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddTime;
        private System.Windows.Forms.Button button_DeleteEdit;
        private System.Windows.Forms.Button button_SubmitEdit;
        private System.Windows.Forms.ComboBox comboBox_RoleEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_PasswordEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PusherNameEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_RoleAdd;
        private System.Windows.Forms.Button button_SubmitAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_PusherNameAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_PasswordAdd;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Info;

    }
}