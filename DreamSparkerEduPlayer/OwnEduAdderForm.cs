using DreamSparkerEduPlayer.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DreamSparkerEduPlayer
{
    public partial class OwnEduAdderForm : Form
    {
        List<User> _userList;

        public int SucCount
        {
            set
            {
                this.label_SucCount.Text = value.ToString();
            }
            get { return int.Parse(this.label_SucCount.Text); }
        }

        public int FailCount
        {
            set
            {
                this.label_FailCount.Text = value.ToString();
            }
            get { return int.Parse(this.label_FailCount.Text); }
        }
        public OwnEduAdderForm()
        {
            InitializeComponent();
            _userList = new List<User>();
            this.comboBox_Domain.SelectedIndex = 0;
            this.comboBox_Target.SelectedIndex = 0;
        }

        private void button_Do_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + string.Format("result_{0}_{1}_{2}_{3}.txt", this.comboBox_Domain.Text,
                Convert.ToInt32(this.numericUpDown_MaxCount.Value).ToString(),
                DateTime.Now.ToString("yyyy-MM-dd"), comboBox_Target.Text), true))
            {
                for (int i = 0; i < Convert.ToInt32(numericUpDown_MaxCount.Value); i++)
                {
                    try
                    {
                        User u = new User
                        {
                            userName = RandomHelper.CreatorZiMu(5, 14),
                            password = RandomHelper.PasswordCreator(3, 4),
                            domain = this.comboBox_Domain.Text
                        };

                        HttpDataHelper.AddDreamSparkerModel(u.userName + "@" + u.domain, u.password, u.password,
                            this.comboBox_Target.Text == "Amazon" ? "amazon空闲中" : "空闲中",
                        string.Empty, string.Empty, "自己", "", this.comboBox_Domain.Text);

                        SucCount = SucCount + 1;
                        SetInfo("成功，" + u.ToString());

                        sw.WriteLine(u.ToString());
                    }
                    catch (Exception ex)
                    {
                        SetInfo("失败，" + ex.Message);
                        FailCount = FailCount + 1;
                    }
                }
            }
        }


        private void SetInfo(string msg)
        {
            this.textBox_Info.AppendText(DateTime.Now.ToString() + "," + msg);
            this.textBox_Info.AppendText(Environment.NewLine);
        }

        public class User
        {
            public string userName;
            public string password;
            public string domain;

            public override string ToString()
            {
                return string.Format("User,{0},{1},{2}", userName, password, domain);
            }
        }
    }
}
