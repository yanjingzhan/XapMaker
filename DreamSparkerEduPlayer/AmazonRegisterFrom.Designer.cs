namespace DreamSparkerEduPlayer
{
    partial class AmazonRegisterFrom
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
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.webBrowser_Main = new System.Windows.Forms.WebBrowser();
            this.textBox_CurrentUrl = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_RestartEveryTime = new System.Windows.Forms.CheckBox();
            this.checkBox_ClearCookie = new System.Windows.Forms.CheckBox();
            this.numericUpDown_Minute = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Second = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_MaxCount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.comboBox_Domain = new System.Windows.Forms.ComboBox();
            this.comboBox_ParentEmailWeb = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_NewPassword = new System.Windows.Forms.Label();
            this.label_CurrentPassword = new System.Windows.Forms.Label();
            this.label_CurrentEduMail = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_FailCount = new System.Windows.Forms.Label();
            this.label_SucCount = new System.Windows.Forms.Label();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Second)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.webBrowser_Main);
            this.panel3.Controls.Add(this.textBox_CurrentUrl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 194);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1421, 363);
            this.panel3.TabIndex = 8;
            // 
            // webBrowser_Main
            // 
            this.webBrowser_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_Main.Location = new System.Drawing.Point(0, 25);
            this.webBrowser_Main.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_Main.Name = "webBrowser_Main";
            this.webBrowser_Main.ScriptErrorsSuppressed = true;
            this.webBrowser_Main.Size = new System.Drawing.Size(1421, 338);
            this.webBrowser_Main.TabIndex = 1;
            // 
            // textBox_CurrentUrl
            // 
            this.textBox_CurrentUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_CurrentUrl.Location = new System.Drawing.Point(0, 0);
            this.textBox_CurrentUrl.Name = "textBox_CurrentUrl";
            this.textBox_CurrentUrl.ReadOnly = true;
            this.textBox_CurrentUrl.Size = new System.Drawing.Size(1421, 25);
            this.textBox_CurrentUrl.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_RestartEveryTime);
            this.groupBox1.Controls.Add(this.checkBox_ClearCookie);
            this.groupBox1.Controls.Add(this.numericUpDown_Minute);
            this.groupBox1.Controls.Add(this.numericUpDown_Second);
            this.groupBox1.Controls.Add(this.numericUpDown_MaxCount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_Start);
            this.groupBox1.Controls.Add(this.comboBox_Domain);
            this.groupBox1.Controls.Add(this.comboBox_ParentEmailWeb);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(889, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 194);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制";
            // 
            // checkBox_RestartEveryTime
            // 
            this.checkBox_RestartEveryTime.AutoSize = true;
            this.checkBox_RestartEveryTime.Location = new System.Drawing.Point(197, 164);
            this.checkBox_RestartEveryTime.Name = "checkBox_RestartEveryTime";
            this.checkBox_RestartEveryTime.Size = new System.Drawing.Size(89, 19);
            this.checkBox_RestartEveryTime.TabIndex = 5;
            this.checkBox_RestartEveryTime.Text = "每次重启";
            this.checkBox_RestartEveryTime.UseVisualStyleBackColor = true;
            this.checkBox_RestartEveryTime.CheckedChanged += new System.EventHandler(this.checkBox_RestartEveryTime_CheckedChanged);
            // 
            // checkBox_ClearCookie
            // 
            this.checkBox_ClearCookie.AutoSize = true;
            this.checkBox_ClearCookie.Checked = true;
            this.checkBox_ClearCookie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ClearCookie.Location = new System.Drawing.Point(20, 164);
            this.checkBox_ClearCookie.Name = "checkBox_ClearCookie";
            this.checkBox_ClearCookie.Size = new System.Drawing.Size(131, 19);
            this.checkBox_ClearCookie.TabIndex = 5;
            this.checkBox_ClearCookie.Text = "清除IE Cookie";
            this.checkBox_ClearCookie.UseVisualStyleBackColor = true;
            this.checkBox_ClearCookie.CheckedChanged += new System.EventHandler(this.checkBox_ClearCookie_CheckedChanged);
            // 
            // numericUpDown_Minute
            // 
            this.numericUpDown_Minute.Location = new System.Drawing.Point(91, 119);
            this.numericUpDown_Minute.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Minute.Name = "numericUpDown_Minute";
            this.numericUpDown_Minute.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown_Minute.TabIndex = 4;
            this.numericUpDown_Minute.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // numericUpDown_Second
            // 
            this.numericUpDown_Second.Location = new System.Drawing.Point(352, 67);
            this.numericUpDown_Second.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Second.Name = "numericUpDown_Second";
            this.numericUpDown_Second.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown_Second.TabIndex = 4;
            this.numericUpDown_Second.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // numericUpDown_MaxCount
            // 
            this.numericUpDown_MaxCount.Location = new System.Drawing.Point(91, 67);
            this.numericUpDown_MaxCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_MaxCount.Name = "numericUpDown_MaxCount";
            this.numericUpDown_MaxCount.ReadOnly = true;
            this.numericUpDown_MaxCount.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown_MaxCount.TabIndex = 4;
            this.numericUpDown_MaxCount.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "间隔分钟";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "超时秒数";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "添加数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "邮箱域名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "邮箱宿主";
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(307, 148);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(152, 40);
            this.button_Start.TabIndex = 3;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // comboBox_Domain
            // 
            this.comboBox_Domain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Domain.FormattingEnabled = true;
            this.comboBox_Domain.Items.AddRange(new object[] {
            "xahu.edu.pl"});
            this.comboBox_Domain.Location = new System.Drawing.Point(352, 29);
            this.comboBox_Domain.Name = "comboBox_Domain";
            this.comboBox_Domain.Size = new System.Drawing.Size(165, 23);
            this.comboBox_Domain.TabIndex = 1;
            // 
            // comboBox_ParentEmailWeb
            // 
            this.comboBox_ParentEmailWeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ParentEmailWeb.FormattingEnabled = true;
            this.comboBox_ParentEmailWeb.Items.AddRange(new object[] {
            "网易",
            "Office365"});
            this.comboBox_ParentEmailWeb.Location = new System.Drawing.Point(91, 28);
            this.comboBox_ParentEmailWeb.Name = "comboBox_ParentEmailWeb";
            this.comboBox_ParentEmailWeb.Size = new System.Drawing.Size(165, 23);
            this.comboBox_ParentEmailWeb.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1421, 194);
            this.panel1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label_NewPassword);
            this.groupBox2.Controls.Add(this.label_CurrentPassword);
            this.groupBox2.Controls.Add(this.label_CurrentEduMail);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label_FailCount);
            this.groupBox2.Controls.Add(this.label_SucCount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 194);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "成功";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "失败";
            // 
            // label_NewPassword
            // 
            this.label_NewPassword.AutoSize = true;
            this.label_NewPassword.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_NewPassword.Location = new System.Drawing.Point(72, 152);
            this.label_NewPassword.Name = "label_NewPassword";
            this.label_NewPassword.Size = new System.Drawing.Size(29, 31);
            this.label_NewPassword.TabIndex = 2;
            this.label_NewPassword.Text = "0";
            // 
            // label_CurrentPassword
            // 
            this.label_CurrentPassword.AutoSize = true;
            this.label_CurrentPassword.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CurrentPassword.Location = new System.Drawing.Point(72, 109);
            this.label_CurrentPassword.Name = "label_CurrentPassword";
            this.label_CurrentPassword.Size = new System.Drawing.Size(29, 31);
            this.label_CurrentPassword.TabIndex = 2;
            this.label_CurrentPassword.Text = "0";
            // 
            // label_CurrentEduMail
            // 
            this.label_CurrentEduMail.AutoSize = true;
            this.label_CurrentEduMail.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CurrentEduMail.Location = new System.Drawing.Point(72, 61);
            this.label_CurrentEduMail.Name = "label_CurrentEduMail";
            this.label_CurrentEduMail.Size = new System.Drawing.Size(29, 31);
            this.label_CurrentEduMail.TabIndex = 2;
            this.label_CurrentEduMail.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "新密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "当前";
            // 
            // label_FailCount
            // 
            this.label_FailCount.AutoSize = true;
            this.label_FailCount.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_FailCount.Location = new System.Drawing.Point(238, 21);
            this.label_FailCount.Name = "label_FailCount";
            this.label_FailCount.Size = new System.Drawing.Size(29, 31);
            this.label_FailCount.TabIndex = 2;
            this.label_FailCount.Text = "0";
            // 
            // label_SucCount
            // 
            this.label_SucCount.AutoSize = true;
            this.label_SucCount.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SucCount.Location = new System.Drawing.Point(72, 21);
            this.label_SucCount.Name = "label_SucCount";
            this.label_SucCount.Size = new System.Drawing.Size(29, 31);
            this.label_SucCount.TabIndex = 2;
            this.label_SucCount.Text = "0";
            // 
            // textBox_Info
            // 
            this.textBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Info.Location = new System.Drawing.Point(0, 0);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(1421, 100);
            this.textBox_Info.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_Info);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 557);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1421, 100);
            this.panel2.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AmazonRegisterFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 657);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AmazonRegisterFrom";
            this.Text = "AmazonRegisterFrom";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Second)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.WebBrowser webBrowser_Main;
        private System.Windows.Forms.TextBox textBox_CurrentUrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Second;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.ComboBox comboBox_Domain;
        private System.Windows.Forms.ComboBox comboBox_ParentEmailWeb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_NewPassword;
        private System.Windows.Forms.Label label_CurrentPassword;
        private System.Windows.Forms.Label label_CurrentEduMail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_FailCount;
        private System.Windows.Forms.Label label_SucCount;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Minute;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_ClearCookie;
        private System.Windows.Forms.CheckBox checkBox_RestartEveryTime;
    }
}