﻿namespace AmazonPlayerGod
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.webBrowser_Main = new System.Windows.Forms.WebBrowser();
            this.textBox_CurrentUrl = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_Second = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Second)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(1204, 457);
            this.panel3.TabIndex = 8;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // webBrowser_Main
            // 
            this.webBrowser_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_Main.Location = new System.Drawing.Point(0, 25);
            this.webBrowser_Main.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_Main.Name = "webBrowser_Main";
            this.webBrowser_Main.ScriptErrorsSuppressed = true;
            this.webBrowser_Main.Size = new System.Drawing.Size(1204, 432);
            this.webBrowser_Main.TabIndex = 1;
            this.webBrowser_Main.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_Main_DocumentCompleted_1);
            // 
            // textBox_CurrentUrl
            // 
            this.textBox_CurrentUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_CurrentUrl.Location = new System.Drawing.Point(0, 0);
            this.textBox_CurrentUrl.Name = "textBox_CurrentUrl";
            this.textBox_CurrentUrl.ReadOnly = true;
            this.textBox_CurrentUrl.Size = new System.Drawing.Size(1204, 25);
            this.textBox_CurrentUrl.TabIndex = 0;
            this.textBox_CurrentUrl.TextChanged += new System.EventHandler(this.textBox_CurrentUrl_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown_Second);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button_Start);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(672, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 194);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // numericUpDown_Second
            // 
            this.numericUpDown_Second.Location = new System.Drawing.Point(368, 27);
            this.numericUpDown_Second.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Second.Name = "numericUpDown_Second";
            this.numericUpDown_Second.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown_Second.TabIndex = 10;
            this.numericUpDown_Second.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_Second.ValueChanged += new System.EventHandler(this.numericUpDown_Second_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "超时秒数";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(368, 143);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(152, 40);
            this.button_Start.TabIndex = 3;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 194);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "成功";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "失败";
            this.label4.Click += new System.EventHandler(this.label4_Click);
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
            this.label_NewPassword.Click += new System.EventHandler(this.label_NewPassword_Click);
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
            this.label_CurrentPassword.Click += new System.EventHandler(this.label_CurrentPassword_Click);
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
            this.label_CurrentEduMail.Click += new System.EventHandler(this.label_CurrentEduMail_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "新密码";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "密码";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "当前";
            this.label6.Click += new System.EventHandler(this.label6_Click);
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
            this.label_FailCount.Click += new System.EventHandler(this.label_FailCount_Click);
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
            this.label_SucCount.Click += new System.EventHandler(this.label_SucCount_Click);
            // 
            // textBox_Info
            // 
            this.textBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Info.Location = new System.Drawing.Point(0, 0);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(1204, 100);
            this.textBox_Info.TabIndex = 0;
            this.textBox_Info.TextChanged += new System.EventHandler(this.textBox_Info_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_Info);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 651);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1204, 100);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 751);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Second)).EndInit();
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
        private System.Windows.Forms.Button button_Start;
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
        private System.Windows.Forms.NumericUpDown numericUpDown_Second;
        private System.Windows.Forms.Label label9;
    }
}

