namespace GamesManager.AndroidForm
{
    partial class TestIsGoodForm
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
            this.label_FileName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_FileSize = new System.Windows.Forms.Label();
            this.label_UnityVersion = new System.Windows.Forms.Label();
            this.button_NotGood = new System.Windows.Forms.Button();
            this.button_Good = new System.Windows.Forms.Button();
            this.button_CreateObj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_FileName
            // 
            this.label_FileName.AutoSize = true;
            this.label_FileName.Font = new System.Drawing.Font("华文细黑", 26.667F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label_FileName.ForeColor = System.Drawing.Color.Red;
            this.label_FileName.Location = new System.Drawing.Point(145, 62);
            this.label_FileName.Name = "label_FileName";
            this.label_FileName.Size = new System.Drawing.Size(397, 30);
            this.label_FileName.TabIndex = 24;
            this.label_FileName.Text = "请把要添加的游戏文件拖进来 :-)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(55, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "文件名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "文件大小";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "版本号";
            // 
            // label_FileSize
            // 
            this.label_FileSize.AutoSize = true;
            this.label_FileSize.Font = new System.Drawing.Font("华文细黑", 26.667F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label_FileSize.ForeColor = System.Drawing.Color.Red;
            this.label_FileSize.Location = new System.Drawing.Point(145, 155);
            this.label_FileSize.Name = "label_FileSize";
            this.label_FileSize.Size = new System.Drawing.Size(28, 30);
            this.label_FileSize.TabIndex = 24;
            this.label_FileSize.Text = "0";
            // 
            // label_UnityVersion
            // 
            this.label_UnityVersion.AutoSize = true;
            this.label_UnityVersion.Font = new System.Drawing.Font("华文细黑", 26.667F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label_UnityVersion.ForeColor = System.Drawing.Color.Red;
            this.label_UnityVersion.Location = new System.Drawing.Point(145, 248);
            this.label_UnityVersion.Name = "label_UnityVersion";
            this.label_UnityVersion.Size = new System.Drawing.Size(28, 30);
            this.label_UnityVersion.TabIndex = 24;
            this.label_UnityVersion.Text = "0";
            // 
            // button_NotGood
            // 
            this.button_NotGood.Font = new System.Drawing.Font("华文细黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_NotGood.Location = new System.Drawing.Point(794, 545);
            this.button_NotGood.Name = "button_NotGood";
            this.button_NotGood.Size = new System.Drawing.Size(138, 41);
            this.button_NotGood.TabIndex = 26;
            this.button_NotGood.Text = "不可用";
            this.button_NotGood.UseVisualStyleBackColor = true;
            this.button_NotGood.Click += new System.EventHandler(this.button_NotGood_Click);
            // 
            // button_Good
            // 
            this.button_Good.Font = new System.Drawing.Font("华文细黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Good.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_Good.Location = new System.Drawing.Point(951, 458);
            this.button_Good.Name = "button_Good";
            this.button_Good.Size = new System.Drawing.Size(138, 128);
            this.button_Good.TabIndex = 26;
            this.button_Good.Text = "可以用";
            this.button_Good.UseVisualStyleBackColor = true;
            this.button_Good.Click += new System.EventHandler(this.button_Good_Click);
            // 
            // button_CreateObj
            // 
            this.button_CreateObj.Location = new System.Drawing.Point(412, 254);
            this.button_CreateObj.Name = "button_CreateObj";
            this.button_CreateObj.Size = new System.Drawing.Size(130, 23);
            this.button_CreateObj.TabIndex = 27;
            this.button_CreateObj.Text = "生成工程...";
            this.button_CreateObj.UseVisualStyleBackColor = true;
            this.button_CreateObj.Click += new System.EventHandler(this.button_CreateObj_Click);
            // 
            // TestIsGoodForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 653);
            this.Controls.Add(this.button_CreateObj);
            this.Controls.Add(this.button_Good);
            this.Controls.Add(this.button_NotGood);
            this.Controls.Add(this.label_UnityVersion);
            this.Controls.Add(this.label_FileSize);
            this.Controls.Add(this.label_FileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestIsGoodForm";
            this.Text = "TestIsGoodForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TestIsGoodForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TestIsGoodForm_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_FileName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_FileSize;
        private System.Windows.Forms.Label label_UnityVersion;
        private System.Windows.Forms.Button button_NotGood;
        private System.Windows.Forms.Button button_Good;
        private System.Windows.Forms.Button button_CreateObj;
    }
}