namespace DreamSparkerEduPlayer
{
    partial class OwnEduAdderForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_FailCount = new System.Windows.Forms.Label();
            this.label_SucCount = new System.Windows.Forms.Label();
            this.numericUpDown_MaxCount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Domain = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.button_Do = new System.Windows.Forms.Button();
            this.comboBox_Target = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "成功";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "失败";
            // 
            // label_FailCount
            // 
            this.label_FailCount.AutoSize = true;
            this.label_FailCount.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_FailCount.Location = new System.Drawing.Point(239, 20);
            this.label_FailCount.Name = "label_FailCount";
            this.label_FailCount.Size = new System.Drawing.Size(29, 31);
            this.label_FailCount.TabIndex = 5;
            this.label_FailCount.Text = "0";
            // 
            // label_SucCount
            // 
            this.label_SucCount.AutoSize = true;
            this.label_SucCount.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SucCount.Location = new System.Drawing.Point(73, 20);
            this.label_SucCount.Name = "label_SucCount";
            this.label_SucCount.Size = new System.Drawing.Size(29, 31);
            this.label_SucCount.TabIndex = 6;
            this.label_SucCount.Text = "0";
            // 
            // numericUpDown_MaxCount
            // 
            this.numericUpDown_MaxCount.Location = new System.Drawing.Point(390, 23);
            this.numericUpDown_MaxCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_MaxCount.Name = "numericUpDown_MaxCount";
            this.numericUpDown_MaxCount.Size = new System.Drawing.Size(120, 25);
            this.numericUpDown_MaxCount.TabIndex = 8;
            this.numericUpDown_MaxCount.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(316, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "添加数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "邮箱域名";
            // 
            // comboBox_Domain
            // 
            this.comboBox_Domain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Domain.FormattingEnabled = true;
            this.comboBox_Domain.Items.AddRange(new object[] {
            "lmu.edu.gr",
            "xahu.edu.pl",
            "wyu.edu.gr",
            "wuyiu.edu.gr"});
            this.comboBox_Domain.Location = new System.Drawing.Point(630, 25);
            this.comboBox_Domain.Name = "comboBox_Domain";
            this.comboBox_Domain.Size = new System.Drawing.Size(165, 23);
            this.comboBox_Domain.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_Info);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 170);
            this.panel1.TabIndex = 11;
            // 
            // textBox_Info
            // 
            this.textBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Info.Location = new System.Drawing.Point(0, 0);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(1003, 170);
            this.textBox_Info.TabIndex = 1;
            // 
            // button_Do
            // 
            this.button_Do.Location = new System.Drawing.Point(823, 25);
            this.button_Do.Name = "button_Do";
            this.button_Do.Size = new System.Drawing.Size(168, 134);
            this.button_Do.TabIndex = 12;
            this.button_Do.Text = "添加";
            this.button_Do.UseVisualStyleBackColor = true;
            this.button_Do.Click += new System.EventHandler(this.button_Do_Click);
            // 
            // comboBox_Target
            // 
            this.comboBox_Target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Target.FormattingEnabled = true;
            this.comboBox_Target.Items.AddRange(new object[] {
            "DreamSpark",
            "Amazon"});
            this.comboBox_Target.Location = new System.Drawing.Point(630, 83);
            this.comboBox_Target.Name = "comboBox_Target";
            this.comboBox_Target.Size = new System.Drawing.Size(165, 23);
            this.comboBox_Target.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(556, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "目的所在";
            // 
            // OwnEduAdderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 439);
            this.Controls.Add(this.button_Do);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Target);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_Domain);
            this.Controls.Add(this.numericUpDown_MaxCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_FailCount);
            this.Controls.Add(this.label_SucCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OwnEduAdderForm";
            this.Text = "OwnEduAdderForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_FailCount;
        private System.Windows.Forms.Label label_SucCount;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Domain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.Button button_Do;
        private System.Windows.Forms.ComboBox comboBox_Target;
        private System.Windows.Forms.Label label1;

    }
}