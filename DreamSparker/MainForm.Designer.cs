namespace DreamSparker
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_KillAnQuan = new System.Windows.Forms.CheckBox();
            this.checkBox_KillIE = new System.Windows.Forms.CheckBox();
            this.button_test = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_Interval = new System.Windows.Forms.NumericUpDown();
            this.button_Do = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_EduFailCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_EduCurrentCount = new System.Windows.Forms.Label();
            this.label_EduTotalCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_EduSucCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label_EduCurrentAccount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_HotmailFailCount = new System.Windows.Forms.Label();
            this.label_HotmailCurrentCount = new System.Windows.Forms.Label();
            this.label_HotmailTotalCount = new System.Windows.Forms.Label();
            this.label_HotmailSucCount = new System.Windows.Forms.Label();
            this.label_HotmailCurrentAccount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.webBrowser_Main = new System.Windows.Forms.WebBrowser();
            this.textBox_CurrentWebBrowserUrl = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Interval)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 205);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_KillAnQuan);
            this.groupBox3.Controls.Add(this.checkBox_KillIE);
            this.groupBox3.Controls.Add(this.button_test);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numericUpDown_Interval);
            this.groupBox3.Controls.Add(this.button_Do);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(802, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 205);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "控制";
            // 
            // checkBox_KillAnQuan
            // 
            this.checkBox_KillAnQuan.AutoSize = true;
            this.checkBox_KillAnQuan.Checked = true;
            this.checkBox_KillAnQuan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_KillAnQuan.Location = new System.Drawing.Point(149, 32);
            this.checkBox_KillAnQuan.Name = "checkBox_KillAnQuan";
            this.checkBox_KillAnQuan.Size = new System.Drawing.Size(119, 19);
            this.checkBox_KillAnQuan.TabIndex = 4;
            this.checkBox_KillAnQuan.Text = "杀死安全弹窗";
            this.checkBox_KillAnQuan.UseVisualStyleBackColor = true;
            // 
            // checkBox_KillIE
            // 
            this.checkBox_KillIE.AutoSize = true;
            this.checkBox_KillIE.Location = new System.Drawing.Point(6, 32);
            this.checkBox_KillIE.Name = "checkBox_KillIE";
            this.checkBox_KillIE.Size = new System.Drawing.Size(105, 19);
            this.checkBox_KillIE.TabIndex = 4;
            this.checkBox_KillIE.Text = "杀死IE进程";
            this.checkBox_KillIE.UseVisualStyleBackColor = true;
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(304, 164);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 3;
            this.button_test.Text = "test";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "超时时间";
            // 
            // numericUpDown_Interval
            // 
            this.numericUpDown_Interval.Location = new System.Drawing.Point(79, 164);
            this.numericUpDown_Interval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Interval.Name = "numericUpDown_Interval";
            this.numericUpDown_Interval.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown_Interval.TabIndex = 1;
            this.numericUpDown_Interval.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(9, 81);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(90, 57);
            this.button_Do.TabIndex = 0;
            this.button_Do.Text = "执行";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_EduFailCount);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label_EduCurrentCount);
            this.groupBox2.Controls.Add(this.label_EduTotalCount);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label_EduSucCount);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label_EduCurrentAccount);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(410, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 205);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hotmail账号";
            // 
            // label_EduFailCount
            // 
            this.label_EduFailCount.AutoSize = true;
            this.label_EduFailCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_EduFailCount.Location = new System.Drawing.Point(283, 98);
            this.label_EduFailCount.Name = "label_EduFailCount";
            this.label_EduFailCount.Size = new System.Drawing.Size(75, 20);
            this.label_EduFailCount.TabIndex = 2;
            this.label_EduFailCount.Text = "label1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Edu当前账号";
            // 
            // label_EduCurrentCount
            // 
            this.label_EduCurrentCount.AutoSize = true;
            this.label_EduCurrentCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_EduCurrentCount.Location = new System.Drawing.Point(283, 32);
            this.label_EduCurrentCount.Name = "label_EduCurrentCount";
            this.label_EduCurrentCount.Size = new System.Drawing.Size(75, 20);
            this.label_EduCurrentCount.TabIndex = 2;
            this.label_EduCurrentCount.Text = "label1";
            // 
            // label_EduTotalCount
            // 
            this.label_EduTotalCount.AutoSize = true;
            this.label_EduTotalCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_EduTotalCount.Location = new System.Drawing.Point(84, 32);
            this.label_EduTotalCount.Name = "label_EduTotalCount";
            this.label_EduTotalCount.Size = new System.Drawing.Size(75, 20);
            this.label_EduTotalCount.TabIndex = 2;
            this.label_EduTotalCount.Text = "label1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(211, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Edu失败";
            // 
            // label_EduSucCount
            // 
            this.label_EduSucCount.AutoSize = true;
            this.label_EduSucCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_EduSucCount.Location = new System.Drawing.Point(84, 98);
            this.label_EduSucCount.Name = "label_EduSucCount";
            this.label_EduSucCount.Size = new System.Drawing.Size(75, 20);
            this.label_EduSucCount.TabIndex = 2;
            this.label_EduSucCount.Text = "label1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Edu成功";
            // 
            // label_EduCurrentAccount
            // 
            this.label_EduCurrentAccount.AutoSize = true;
            this.label_EduCurrentAccount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_EduCurrentAccount.ForeColor = System.Drawing.Color.Red;
            this.label_EduCurrentAccount.Location = new System.Drawing.Point(109, 164);
            this.label_EduCurrentAccount.Name = "label_EduCurrentAccount";
            this.label_EduCurrentAccount.Size = new System.Drawing.Size(75, 20);
            this.label_EduCurrentAccount.TabIndex = 2;
            this.label_EduCurrentAccount.Text = "label1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(211, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Edu当前";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "Edu总数";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_HotmailFailCount);
            this.groupBox1.Controls.Add(this.label_HotmailCurrentCount);
            this.groupBox1.Controls.Add(this.label_HotmailTotalCount);
            this.groupBox1.Controls.Add(this.label_HotmailSucCount);
            this.groupBox1.Controls.Add(this.label_HotmailCurrentAccount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotmail账号";
            // 
            // label_HotmailFailCount
            // 
            this.label_HotmailFailCount.AutoSize = true;
            this.label_HotmailFailCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HotmailFailCount.Location = new System.Drawing.Point(310, 98);
            this.label_HotmailFailCount.Name = "label_HotmailFailCount";
            this.label_HotmailFailCount.Size = new System.Drawing.Size(75, 20);
            this.label_HotmailFailCount.TabIndex = 2;
            this.label_HotmailFailCount.Text = "label1";
            // 
            // label_HotmailCurrentCount
            // 
            this.label_HotmailCurrentCount.AutoSize = true;
            this.label_HotmailCurrentCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HotmailCurrentCount.Location = new System.Drawing.Point(310, 32);
            this.label_HotmailCurrentCount.Name = "label_HotmailCurrentCount";
            this.label_HotmailCurrentCount.Size = new System.Drawing.Size(75, 20);
            this.label_HotmailCurrentCount.TabIndex = 2;
            this.label_HotmailCurrentCount.Text = "label1";
            // 
            // label_HotmailTotalCount
            // 
            this.label_HotmailTotalCount.AutoSize = true;
            this.label_HotmailTotalCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HotmailTotalCount.Location = new System.Drawing.Point(111, 32);
            this.label_HotmailTotalCount.Name = "label_HotmailTotalCount";
            this.label_HotmailTotalCount.Size = new System.Drawing.Size(75, 20);
            this.label_HotmailTotalCount.TabIndex = 2;
            this.label_HotmailTotalCount.Text = "label1";
            // 
            // label_HotmailSucCount
            // 
            this.label_HotmailSucCount.AutoSize = true;
            this.label_HotmailSucCount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HotmailSucCount.Location = new System.Drawing.Point(111, 98);
            this.label_HotmailSucCount.Name = "label_HotmailSucCount";
            this.label_HotmailSucCount.Size = new System.Drawing.Size(75, 20);
            this.label_HotmailSucCount.TabIndex = 2;
            this.label_HotmailSucCount.Text = "label1";
            // 
            // label_HotmailCurrentAccount
            // 
            this.label_HotmailCurrentAccount.AutoSize = true;
            this.label_HotmailCurrentAccount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HotmailCurrentAccount.ForeColor = System.Drawing.Color.Red;
            this.label_HotmailCurrentAccount.Location = new System.Drawing.Point(141, 164);
            this.label_HotmailCurrentAccount.Name = "label_HotmailCurrentAccount";
            this.label_HotmailCurrentAccount.Size = new System.Drawing.Size(75, 20);
            this.label_HotmailCurrentAccount.TabIndex = 2;
            this.label_HotmailCurrentAccount.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hotmail当前账号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hotmail失败";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hotmail成功";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Hotmail当前";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hotmail总数";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 717);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1221, 130);
            this.panel2.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_Info);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1221, 130);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "输出";
            // 
            // textBox_Info
            // 
            this.textBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Info.Location = new System.Drawing.Point(3, 21);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(1215, 106);
            this.textBox_Info.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 205);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1221, 512);
            this.panel3.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.webBrowser_Main);
            this.groupBox4.Controls.Add(this.textBox_CurrentWebBrowserUrl);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1221, 512);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "浏览器";
            // 
            // webBrowser_Main
            // 
            this.webBrowser_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_Main.Location = new System.Drawing.Point(3, 46);
            this.webBrowser_Main.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_Main.Name = "webBrowser_Main";
            this.webBrowser_Main.ScriptErrorsSuppressed = true;
            this.webBrowser_Main.Size = new System.Drawing.Size(1215, 463);
            this.webBrowser_Main.TabIndex = 1;
            // 
            // textBox_CurrentWebBrowserUrl
            // 
            this.textBox_CurrentWebBrowserUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_CurrentWebBrowserUrl.Location = new System.Drawing.Point(3, 21);
            this.textBox_CurrentWebBrowserUrl.Name = "textBox_CurrentWebBrowserUrl";
            this.textBox_CurrentWebBrowserUrl.ReadOnly = true;
            this.textBox_CurrentWebBrowserUrl.Size = new System.Drawing.Size(1215, 25);
            this.textBox_CurrentWebBrowserUrl.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 847);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "～(￣▽￣～)DreamSparker(～￣▽￣)～";
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Interval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_HotmailFailCount;
        private System.Windows.Forms.Label label_HotmailCurrentCount;
        private System.Windows.Forms.Label label_HotmailTotalCount;
        private System.Windows.Forms.Label label_HotmailSucCount;
        private System.Windows.Forms.Label label_HotmailCurrentAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_EduFailCount;
        private System.Windows.Forms.Label label_EduCurrentCount;
        private System.Windows.Forms.Label label_EduTotalCount;
        private System.Windows.Forms.Label label_EduSucCount;
        private System.Windows.Forms.Label label_EduCurrentAccount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_Do;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.WebBrowser webBrowser_Main;
        private System.Windows.Forms.TextBox textBox_CurrentWebBrowserUrl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_Interval;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.CheckBox checkBox_KillIE;
        private System.Windows.Forms.CheckBox checkBox_KillAnQuan;
    }
}

