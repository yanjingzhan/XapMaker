namespace DreamSparkerDevRegister
{
    partial class DevRegister
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
            this.button_GetAccount = new System.Windows.Forms.Button();
            this.button_DoneOk = new System.Windows.Forms.Button();
            this.button_Die = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_test = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Token = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_CopyToken = new System.Windows.Forms.Button();
            this.button_CopyLastName = new System.Windows.Forms.Button();
            this.button_CopyDevPassword = new System.Windows.Forms.Button();
            this.button_CopyPhoneNum = new System.Windows.Forms.Button();
            this.button_CopyCity = new System.Windows.Forms.Button();
            this.button_CopyZipCode = new System.Windows.Forms.Button();
            this.button_CopyAddress = new System.Windows.Forms.Button();
            this.button_CopyEmail = new System.Windows.Forms.Button();
            this.button_CopyShowName = new System.Windows.Forms.Button();
            this.button_CopyFirstName = new System.Windows.Forms.Button();
            this.button_CopyDevAccount = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.textBox_DevPassword = new System.Windows.Forms.TextBox();
            this.textBox_PhoneNum = new System.Windows.Forms.TextBox();
            this.textBox_City = new System.Windows.Forms.TextBox();
            this.textBox_ZipCode = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_ShowName = new System.Windows.Forms.TextBox();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.textBox_DevAccount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_ReCreatShowName = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_GetAccount
            // 
            this.button_GetAccount.Location = new System.Drawing.Point(16, 12);
            this.button_GetAccount.Name = "button_GetAccount";
            this.button_GetAccount.Size = new System.Drawing.Size(150, 112);
            this.button_GetAccount.TabIndex = 0;
            this.button_GetAccount.Text = "获取账号";
            this.button_GetAccount.UseVisualStyleBackColor = true;
            this.button_GetAccount.Click += new System.EventHandler(this.button_GetAccount_Click);
            // 
            // button_DoneOk
            // 
            this.button_DoneOk.Enabled = false;
            this.button_DoneOk.Location = new System.Drawing.Point(252, 13);
            this.button_DoneOk.Name = "button_DoneOk";
            this.button_DoneOk.Size = new System.Drawing.Size(150, 112);
            this.button_DoneOk.TabIndex = 1;
            this.button_DoneOk.Text = "注册完成";
            this.button_DoneOk.UseVisualStyleBackColor = true;
            this.button_DoneOk.Click += new System.EventHandler(this.button_DoneOk_Click);
            // 
            // button_Die
            // 
            this.button_Die.Enabled = false;
            this.button_Die.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Die.ForeColor = System.Drawing.Color.Red;
            this.button_Die.Location = new System.Drawing.Point(503, 13);
            this.button_Die.Name = "button_Die";
            this.button_Die.Size = new System.Drawing.Size(150, 112);
            this.button_Die.TabIndex = 2;
            this.button_Die.Text = "账号被封";
            this.button_Die.UseVisualStyleBackColor = true;
            this.button_Die.Click += new System.EventHandler(this.button_Die_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_test);
            this.groupBox1.Controls.Add(this.label_info);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 708);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(1076, 87);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 23);
            this.button_test.TabIndex = 7;
            this.button_test.Text = "test";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Visible = false;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // label_info
            // 
            this.label_info.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_info.ForeColor = System.Drawing.Color.Blue;
            this.label_info.Location = new System.Drawing.Point(12, 21);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(1133, 89);
            this.label_info.TabIndex = 0;
            this.label_info.Text = " ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_ReCreatShowName);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox_Token);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button_CopyToken);
            this.groupBox2.Controls.Add(this.button_CopyLastName);
            this.groupBox2.Controls.Add(this.button_CopyDevPassword);
            this.groupBox2.Controls.Add(this.button_CopyPhoneNum);
            this.groupBox2.Controls.Add(this.button_CopyCity);
            this.groupBox2.Controls.Add(this.button_CopyZipCode);
            this.groupBox2.Controls.Add(this.button_CopyAddress);
            this.groupBox2.Controls.Add(this.button_CopyEmail);
            this.groupBox2.Controls.Add(this.button_CopyShowName);
            this.groupBox2.Controls.Add(this.button_CopyFirstName);
            this.groupBox2.Controls.Add(this.button_CopyDevAccount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_LastName);
            this.groupBox2.Controls.Add(this.textBox_DevPassword);
            this.groupBox2.Controls.Add(this.textBox_PhoneNum);
            this.groupBox2.Controls.Add(this.textBox_City);
            this.groupBox2.Controls.Add(this.textBox_ZipCode);
            this.groupBox2.Controls.Add(this.textBox_Address);
            this.groupBox2.Controls.Add(this.textBox_Email);
            this.groupBox2.Controls.Add(this.textBox_ShowName);
            this.groupBox2.Controls.Add(this.textBox_FirstName);
            this.groupBox2.Controls.Add(this.textBox_DevAccount);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(689, 554);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "开发者账号";
            // 
            // textBox_Token
            // 
            this.textBox_Token.Location = new System.Drawing.Point(125, 512);
            this.textBox_Token.Name = "textBox_Token";
            this.textBox_Token.ReadOnly = true;
            this.textBox_Token.Size = new System.Drawing.Size(313, 25);
            this.textBox_Token.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 517);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "促销代码";
            // 
            // button_CopyToken
            // 
            this.button_CopyToken.Location = new System.Drawing.Point(465, 514);
            this.button_CopyToken.Name = "button_CopyToken";
            this.button_CopyToken.Size = new System.Drawing.Size(75, 23);
            this.button_CopyToken.TabIndex = 4;
            this.button_CopyToken.Text = "复制";
            this.button_CopyToken.UseVisualStyleBackColor = true;
            this.button_CopyToken.Click += new System.EventHandler(this.button_CopyToken_Click);
            // 
            // button_CopyLastName
            // 
            this.button_CopyLastName.Location = new System.Drawing.Point(464, 223);
            this.button_CopyLastName.Name = "button_CopyLastName";
            this.button_CopyLastName.Size = new System.Drawing.Size(75, 23);
            this.button_CopyLastName.TabIndex = 3;
            this.button_CopyLastName.Text = "复制";
            this.button_CopyLastName.UseVisualStyleBackColor = true;
            this.button_CopyLastName.Click += new System.EventHandler(this.button_CopyLastName_Click);
            // 
            // button_CopyDevPassword
            // 
            this.button_CopyDevPassword.Location = new System.Drawing.Point(464, 78);
            this.button_CopyDevPassword.Name = "button_CopyDevPassword";
            this.button_CopyDevPassword.Size = new System.Drawing.Size(75, 23);
            this.button_CopyDevPassword.TabIndex = 3;
            this.button_CopyDevPassword.Text = "复制";
            this.button_CopyDevPassword.UseVisualStyleBackColor = true;
            this.button_CopyDevPassword.Click += new System.EventHandler(this.button_CopyDevPassword_Click);
            // 
            // button_CopyPhoneNum
            // 
            this.button_CopyPhoneNum.Location = new System.Drawing.Point(465, 308);
            this.button_CopyPhoneNum.Name = "button_CopyPhoneNum";
            this.button_CopyPhoneNum.Size = new System.Drawing.Size(75, 23);
            this.button_CopyPhoneNum.TabIndex = 3;
            this.button_CopyPhoneNum.Text = "复制";
            this.button_CopyPhoneNum.UseVisualStyleBackColor = true;
            this.button_CopyPhoneNum.Click += new System.EventHandler(this.button_CopyPhoneNum_Click);
            // 
            // button_CopyCity
            // 
            this.button_CopyCity.Location = new System.Drawing.Point(465, 390);
            this.button_CopyCity.Name = "button_CopyCity";
            this.button_CopyCity.Size = new System.Drawing.Size(75, 23);
            this.button_CopyCity.TabIndex = 3;
            this.button_CopyCity.Text = "复制";
            this.button_CopyCity.UseVisualStyleBackColor = true;
            this.button_CopyCity.Click += new System.EventHandler(this.button_CopyCity_Click);
            // 
            // button_CopyZipCode
            // 
            this.button_CopyZipCode.Location = new System.Drawing.Point(465, 435);
            this.button_CopyZipCode.Name = "button_CopyZipCode";
            this.button_CopyZipCode.Size = new System.Drawing.Size(75, 23);
            this.button_CopyZipCode.TabIndex = 3;
            this.button_CopyZipCode.Text = "复制";
            this.button_CopyZipCode.UseVisualStyleBackColor = true;
            this.button_CopyZipCode.Click += new System.EventHandler(this.button_CopyZipCode_Click);
            // 
            // button_CopyAddress
            // 
            this.button_CopyAddress.Location = new System.Drawing.Point(465, 349);
            this.button_CopyAddress.Name = "button_CopyAddress";
            this.button_CopyAddress.Size = new System.Drawing.Size(75, 23);
            this.button_CopyAddress.TabIndex = 3;
            this.button_CopyAddress.Text = "复制";
            this.button_CopyAddress.UseVisualStyleBackColor = true;
            this.button_CopyAddress.Click += new System.EventHandler(this.button_CopyAddress_Click);
            // 
            // button_CopyEmail
            // 
            this.button_CopyEmail.Location = new System.Drawing.Point(465, 265);
            this.button_CopyEmail.Name = "button_CopyEmail";
            this.button_CopyEmail.Size = new System.Drawing.Size(75, 23);
            this.button_CopyEmail.TabIndex = 3;
            this.button_CopyEmail.Text = "复制";
            this.button_CopyEmail.UseVisualStyleBackColor = true;
            this.button_CopyEmail.Click += new System.EventHandler(this.button_CopyEmail_Click);
            // 
            // button_CopyShowName
            // 
            this.button_CopyShowName.Location = new System.Drawing.Point(465, 140);
            this.button_CopyShowName.Name = "button_CopyShowName";
            this.button_CopyShowName.Size = new System.Drawing.Size(75, 23);
            this.button_CopyShowName.TabIndex = 3;
            this.button_CopyShowName.Text = "复制";
            this.button_CopyShowName.UseVisualStyleBackColor = true;
            this.button_CopyShowName.Click += new System.EventHandler(this.button_CopyShowName_Click);
            // 
            // button_CopyFirstName
            // 
            this.button_CopyFirstName.Location = new System.Drawing.Point(465, 179);
            this.button_CopyFirstName.Name = "button_CopyFirstName";
            this.button_CopyFirstName.Size = new System.Drawing.Size(75, 23);
            this.button_CopyFirstName.TabIndex = 3;
            this.button_CopyFirstName.Text = "复制";
            this.button_CopyFirstName.UseVisualStyleBackColor = true;
            this.button_CopyFirstName.Click += new System.EventHandler(this.button_CopyFirstName_Click);
            // 
            // button_CopyDevAccount
            // 
            this.button_CopyDevAccount.Location = new System.Drawing.Point(465, 40);
            this.button_CopyDevAccount.Name = "button_CopyDevAccount";
            this.button_CopyDevAccount.Size = new System.Drawing.Size(75, 23);
            this.button_CopyDevAccount.TabIndex = 3;
            this.button_CopyDevAccount.Text = "复制";
            this.button_CopyDevAccount.UseVisualStyleBackColor = true;
            this.button_CopyDevAccount.Click += new System.EventHandler(this.button_CopyDevAccount_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "姓氏";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "开发者密码";
            // 
            // textBox_LastName
            // 
            this.textBox_LastName.Location = new System.Drawing.Point(125, 219);
            this.textBox_LastName.Name = "textBox_LastName";
            this.textBox_LastName.ReadOnly = true;
            this.textBox_LastName.Size = new System.Drawing.Size(313, 25);
            this.textBox_LastName.TabIndex = 1;
            // 
            // textBox_DevPassword
            // 
            this.textBox_DevPassword.Location = new System.Drawing.Point(125, 75);
            this.textBox_DevPassword.Name = "textBox_DevPassword";
            this.textBox_DevPassword.ReadOnly = true;
            this.textBox_DevPassword.Size = new System.Drawing.Size(313, 25);
            this.textBox_DevPassword.TabIndex = 1;
            // 
            // textBox_PhoneNum
            // 
            this.textBox_PhoneNum.Location = new System.Drawing.Point(125, 306);
            this.textBox_PhoneNum.Name = "textBox_PhoneNum";
            this.textBox_PhoneNum.ReadOnly = true;
            this.textBox_PhoneNum.Size = new System.Drawing.Size(313, 25);
            this.textBox_PhoneNum.TabIndex = 1;
            // 
            // textBox_City
            // 
            this.textBox_City.Location = new System.Drawing.Point(125, 388);
            this.textBox_City.Name = "textBox_City";
            this.textBox_City.ReadOnly = true;
            this.textBox_City.Size = new System.Drawing.Size(313, 25);
            this.textBox_City.TabIndex = 1;
            // 
            // textBox_ZipCode
            // 
            this.textBox_ZipCode.Location = new System.Drawing.Point(125, 433);
            this.textBox_ZipCode.Name = "textBox_ZipCode";
            this.textBox_ZipCode.ReadOnly = true;
            this.textBox_ZipCode.Size = new System.Drawing.Size(313, 25);
            this.textBox_ZipCode.TabIndex = 1;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(125, 347);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.ReadOnly = true;
            this.textBox_Address.Size = new System.Drawing.Size(313, 25);
            this.textBox_Address.TabIndex = 1;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(125, 263);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.ReadOnly = true;
            this.textBox_Email.Size = new System.Drawing.Size(313, 25);
            this.textBox_Email.TabIndex = 1;
            // 
            // textBox_ShowName
            // 
            this.textBox_ShowName.Location = new System.Drawing.Point(125, 139);
            this.textBox_ShowName.Name = "textBox_ShowName";
            this.textBox_ShowName.ReadOnly = true;
            this.textBox_ShowName.Size = new System.Drawing.Size(313, 25);
            this.textBox_ShowName.TabIndex = 1;
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.Location = new System.Drawing.Point(125, 177);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.ReadOnly = true;
            this.textBox_FirstName.Size = new System.Drawing.Size(313, 25);
            this.textBox_FirstName.TabIndex = 1;
            // 
            // textBox_DevAccount
            // 
            this.textBox_DevAccount.Location = new System.Drawing.Point(125, 37);
            this.textBox_DevAccount.Name = "textBox_DevAccount";
            this.textBox_DevAccount.ReadOnly = true;
            this.textBox_DevAccount.Size = new System.Drawing.Size(313, 25);
            this.textBox_DevAccount.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "电话号码";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 393);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "城市";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 437);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "邮政编码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "地址";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "电子邮件地址";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "发布者显示名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "名字";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "开发者账号";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(577, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_ReCreatShowName
            // 
            this.button_ReCreatShowName.Location = new System.Drawing.Point(546, 140);
            this.button_ReCreatShowName.Name = "button_ReCreatShowName";
            this.button_ReCreatShowName.Size = new System.Drawing.Size(116, 23);
            this.button_ReCreatShowName.TabIndex = 8;
            this.button_ReCreatShowName.Text = "重新生成";
            this.button_ReCreatShowName.UseVisualStyleBackColor = true;
            this.button_ReCreatShowName.Click += new System.EventHandler(this.button_ReCreatShowName_Click);
            // 
            // DevRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 845);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Die);
            this.Controls.Add(this.button_DoneOk);
            this.Controls.Add(this.button_GetAccount);
            this.Name = "DevRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_GetAccount;
        private System.Windows.Forms.Button button_DoneOk;
        private System.Windows.Forms.Button button_Die;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Token;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_CopyToken;
        private System.Windows.Forms.Button button_CopyDevPassword;
        private System.Windows.Forms.Button button_CopyDevAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_DevPassword;
        private System.Windows.Forms.TextBox textBox_DevAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Button button_CopyLastName;
        private System.Windows.Forms.Button button_CopyFirstName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_CopyEmail;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_CopyPhoneNum;
        private System.Windows.Forms.Button button_CopyCity;
        private System.Windows.Forms.Button button_CopyZipCode;
        private System.Windows.Forms.Button button_CopyAddress;
        private System.Windows.Forms.TextBox textBox_PhoneNum;
        private System.Windows.Forms.TextBox textBox_City;
        private System.Windows.Forms.TextBox textBox_ZipCode;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_CopyShowName;
        private System.Windows.Forms.TextBox textBox_ShowName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_ReCreatShowName;
    }
}

