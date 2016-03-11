namespace XapMaker
{
    partial class XapMaker
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.button_SaveXap = new System.Windows.Forms.Button();
            this.button_SelectRomFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_GameName = new System.Windows.Forms.Button();
            this.textBox_GameName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.textBox_SaveXap = new System.Windows.Forms.TextBox();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.button_SaveXap);
            this.splitContainer1.Panel1.Controls.Add(this.button_SelectRomFile);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.button_GameName);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_GameName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox_Logo);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_SaveXap);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Info);
            this.splitContainer1.Size = new System.Drawing.Size(1019, 510);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "输出位置";
            // 
            // button_SaveXap
            // 
            this.button_SaveXap.Location = new System.Drawing.Point(911, 288);
            this.button_SaveXap.Name = "button_SaveXap";
            this.button_SaveXap.Size = new System.Drawing.Size(93, 41);
            this.button_SaveXap.TabIndex = 3;
            this.button_SaveXap.Text = "保存包";
            this.button_SaveXap.UseVisualStyleBackColor = true;
            // 
            // button_SelectRomFile
            // 
            this.button_SelectRomFile.Location = new System.Drawing.Point(911, 61);
            this.button_SelectRomFile.Name = "button_SelectRomFile";
            this.button_SelectRomFile.Size = new System.Drawing.Size(103, 23);
            this.button_SelectRomFile.TabIndex = 2;
            this.button_SelectRomFile.Text = "选择";
            this.button_SelectRomFile.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(409, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(496, 25);
            this.textBox1.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Rom文件";
            // 
            // button_GameName
            // 
            this.button_GameName.Location = new System.Drawing.Point(629, 22);
            this.button_GameName.Name = "button_GameName";
            this.button_GameName.Size = new System.Drawing.Size(103, 23);
            this.button_GameName.TabIndex = 1;
            this.button_GameName.Text = "确定";
            this.button_GameName.UseVisualStyleBackColor = true;
            this.button_GameName.Visible = false;
            // 
            // textBox_GameName
            // 
            this.textBox_GameName.Location = new System.Drawing.Point(409, 21);
            this.textBox_GameName.Name = "textBox_GameName";
            this.textBox_GameName.Size = new System.Drawing.Size(204, 25);
            this.textBox_GameName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "游戏名称";
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Logo.Location = new System.Drawing.Point(18, 23);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_Logo.TabIndex = 16;
            this.pictureBox_Logo.TabStop = false;
            this.pictureBox_Logo.Click += new System.EventHandler(this.pictureBox_Logo_Click);
            // 
            // textBox_SaveXap
            // 
            this.textBox_SaveXap.Location = new System.Drawing.Point(409, 298);
            this.textBox_SaveXap.Name = "textBox_SaveXap";
            this.textBox_SaveXap.ReadOnly = true;
            this.textBox_SaveXap.Size = new System.Drawing.Size(496, 25);
            this.textBox_SaveXap.TabIndex = 15;
            // 
            // textBox_Info
            // 
            this.textBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Info.Location = new System.Drawing.Point(0, 0);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(1019, 156);
            this.textBox_Info.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "描述";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(409, 103);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(496, 170);
            this.textBox2.TabIndex = 25;
            // 
            // XapMaker
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 510);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "XapMaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XapMaker";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.XapMaker_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.XapMaker_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_SaveXap;
        private System.Windows.Forms.Button button_SelectRomFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_GameName;
        private System.Windows.Forms.TextBox textBox_GameName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_Logo;
        private System.Windows.Forms.TextBox textBox_SaveXap;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;

    }
}

