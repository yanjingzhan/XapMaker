namespace DreamSparkerEduPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Login = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_VerifyEdu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_DelEdu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddOwn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Amazon = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_VerifyHotmailIsGood = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Login,
            this.toolStripButton_VerifyEdu,
            this.toolStripButton_DelEdu,
            this.toolStripButton_AddOwn,
            this.toolStripButton_Amazon,
            this.toolStripButton2,
            this.toolStripButton_VerifyHotmailIsGood,
            this.toolStripLabel2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1399, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Add.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_Add.ForeColor = System.Drawing.Color.Chocolate;
            this.toolStripButton_Add.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Add.Image")));
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(66, 35);
            this.toolStripButton_Add.Text = "添加";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_Login
            // 
            this.toolStripButton_Login.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Login.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_Login.ForeColor = System.Drawing.Color.Chocolate;
            this.toolStripButton_Login.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Login.Image")));
            this.toolStripButton_Login.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Login.Name = "toolStripButton_Login";
            this.toolStripButton_Login.Size = new System.Drawing.Size(138, 35);
            this.toolStripButton_Login.Text = "登陆改密码";
            this.toolStripButton_Login.Click += new System.EventHandler(this.toolStripButton_Login_Click);
            // 
            // toolStripButton_VerifyEdu
            // 
            this.toolStripButton_VerifyEdu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_VerifyEdu.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_VerifyEdu.ForeColor = System.Drawing.Color.Chocolate;
            this.toolStripButton_VerifyEdu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_VerifyEdu.Image")));
            this.toolStripButton_VerifyEdu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_VerifyEdu.Name = "toolStripButton_VerifyEdu";
            this.toolStripButton_VerifyEdu.Size = new System.Drawing.Size(234, 35);
            this.toolStripButton_VerifyEdu.Text = "获取验证链接并验证";
            this.toolStripButton_VerifyEdu.Click += new System.EventHandler(this.toolStripButton_VerifyEdu_Click);
            // 
            // toolStripButton_DelEdu
            // 
            this.toolStripButton_DelEdu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_DelEdu.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_DelEdu.ForeColor = System.Drawing.Color.Chocolate;
            this.toolStripButton_DelEdu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_DelEdu.Image")));
            this.toolStripButton_DelEdu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DelEdu.Name = "toolStripButton_DelEdu";
            this.toolStripButton_DelEdu.Size = new System.Drawing.Size(234, 35);
            this.toolStripButton_DelEdu.Text = "删除已经存在的邮箱";
            this.toolStripButton_DelEdu.Click += new System.EventHandler(this.toolStripButton_DelEdu_Click);
            // 
            // toolStripButton_AddOwn
            // 
            this.toolStripButton_AddOwn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_AddOwn.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_AddOwn.ForeColor = System.Drawing.Color.Chocolate;
            this.toolStripButton_AddOwn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddOwn.Image")));
            this.toolStripButton_AddOwn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddOwn.Name = "toolStripButton_AddOwn";
            this.toolStripButton_AddOwn.Size = new System.Drawing.Size(138, 35);
            this.toolStripButton_AddOwn.Text = "添加自己的";
            this.toolStripButton_AddOwn.Click += new System.EventHandler(this.toolStripButton_AddOwn_Click);
            // 
            // toolStripButton_Amazon
            // 
            this.toolStripButton_Amazon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_Amazon.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_Amazon.ForeColor = System.Drawing.Color.Chocolate;
            this.toolStripButton_Amazon.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Amazon.Image")));
            this.toolStripButton_Amazon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Amazon.Name = "toolStripButton_Amazon";
            this.toolStripButton_Amazon.Size = new System.Drawing.Size(186, 35);
            this.toolStripButton_Amazon.Text = "注册亚马逊账号";
            this.toolStripButton_Amazon.Click += new System.EventHandler(this.toolStripButton_Amazon_Click);
            // 
            // toolStripButton_VerifyHotmailIsGood
            // 
            this.toolStripButton_VerifyHotmailIsGood.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_VerifyHotmailIsGood.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.toolStripButton_VerifyHotmailIsGood.ForeColor = System.Drawing.Color.Chocolate;
            this.toolStripButton_VerifyHotmailIsGood.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_VerifyHotmailIsGood.Image")));
            this.toolStripButton_VerifyHotmailIsGood.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_VerifyHotmailIsGood.Name = "toolStripButton_VerifyHotmailIsGood";
            this.toolStripButton_VerifyHotmailIsGood.Size = new System.Drawing.Size(274, 35);
            this.toolStripButton_VerifyHotmailIsGood.Text = "VerifyHotmailIsGood";
            this.toolStripButton_VerifyHotmailIsGood.Click += new System.EventHandler(this.toolStripButton_VerifyHotmailIsGood_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(49, 20);
            this.toolStripLabel2.Text = "          ";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold);
            this.toolStripButton2.ForeColor = System.Drawing.Color.Chocolate;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(76, 35);
            this.toolStripButton2.Text = "TEST";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 753);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Login;
        private System.Windows.Forms.ToolStripButton toolStripButton_VerifyEdu;
        private System.Windows.Forms.ToolStripButton toolStripButton_DelEdu;
        private System.Windows.Forms.ToolStripButton toolStripButton_VerifyHotmailIsGood;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddOwn;
        private System.Windows.Forms.ToolStripButton toolStripButton_Amazon;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

