namespace GamesManager.AndroidLiuMangForm
{
    partial class BatchAddLiuMangApp
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
            this.textBox_JingZhongAppId_Add = new System.Windows.Forms.TextBox();
            this.textBox_IadAppKey_Add = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_GameName_Add = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_AppType_Add = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox_SanLiuLingIds = new System.Windows.Forms.TextBox();
            this.button_Do = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_JingZhongAppId_Add
            // 
            this.textBox_JingZhongAppId_Add.Location = new System.Drawing.Point(604, 78);
            this.textBox_JingZhongAppId_Add.Name = "textBox_JingZhongAppId_Add";
            this.textBox_JingZhongAppId_Add.Size = new System.Drawing.Size(231, 25);
            this.textBox_JingZhongAppId_Add.TabIndex = 33;
            // 
            // textBox_IadAppKey_Add
            // 
            this.textBox_IadAppKey_Add.Location = new System.Drawing.Point(169, 78);
            this.textBox_IadAppKey_Add.Name = "textBox_IadAppKey_Add";
            this.textBox_IadAppKey_Add.Size = new System.Drawing.Size(231, 25);
            this.textBox_IadAppKey_Add.TabIndex = 32;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(506, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 15);
            this.label18.TabIndex = 36;
            this.label18.Text = "精众广告ID";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(46, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 15);
            this.label19.TabIndex = 37;
            this.label19.Text = "Iad广告AppKey";
            // 
            // textBox_GameName_Add
            // 
            this.textBox_GameName_Add.Location = new System.Drawing.Point(171, 22);
            this.textBox_GameName_Add.Name = "textBox_GameName_Add";
            this.textBox_GameName_Add.Size = new System.Drawing.Size(229, 25);
            this.textBox_GameName_Add.TabIndex = 30;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(143, 15);
            this.label20.TabIndex = 28;
            this.label20.Text = "游戏名称(可以不填)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label15.Location = new System.Drawing.Point(12, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 15);
            this.label15.TabIndex = 29;
            this.label15.Text = "(不填的话随机生成)";
            // 
            // textBox_AppType_Add
            // 
            this.textBox_AppType_Add.Location = new System.Drawing.Point(604, 21);
            this.textBox_AppType_Add.Name = "textBox_AppType_Add";
            this.textBox_AppType_Add.Size = new System.Drawing.Size(230, 25);
            this.textBox_AppType_Add.TabIndex = 39;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(507, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 15);
            this.label22.TabIndex = 38;
            this.label22.Text = "商店中类型";
            // 
            // textBox_SanLiuLingIds
            // 
            this.textBox_SanLiuLingIds.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_SanLiuLingIds.Location = new System.Drawing.Point(0, 186);
            this.textBox_SanLiuLingIds.Multiline = true;
            this.textBox_SanLiuLingIds.Name = "textBox_SanLiuLingIds";
            this.textBox_SanLiuLingIds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SanLiuLingIds.Size = new System.Drawing.Size(1110, 383);
            this.textBox_SanLiuLingIds.TabIndex = 40;
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(940, 24);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(149, 79);
            this.button_Do.TabIndex = 41;
            this.button_Do.Text = "执行";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // BatchAddLiuMangApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 569);
            this.Controls.Add(this.button_Do);
            this.Controls.Add(this.textBox_SanLiuLingIds);
            this.Controls.Add(this.textBox_AppType_Add);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textBox_JingZhongAppId_Add);
            this.Controls.Add(this.textBox_IadAppKey_Add);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.textBox_GameName_Add);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label15);
            this.Name = "BatchAddLiuMangApp";
            this.Text = "BatchAddLiuMangApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_JingZhongAppId_Add;
        private System.Windows.Forms.TextBox textBox_IadAppKey_Add;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox_GameName_Add;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_AppType_Add;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox_SanLiuLingIds;
        private System.Windows.Forms.Button button_Do;
    }
}