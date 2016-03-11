using DreamSparkerEduPlayer.Models;
using DreamSparkerEduPlayer.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DreamSparkerEduPlayer
{
    public partial class MainForm : Form
    {
        private List<Form> _childForms;
        public MainForm()
        {
            InitializeComponent();
            _childForms = new List<Form>();

            if (INIHelper.ReadIniData("AmazonRegisterFrom", "AutoRestart", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")) == "1")
            {
                toolStripButton_Amazon_Click(new object(), new EventArgs());
            }
            else if (INIHelper.ReadIniData("VerifyHotmailIsGood", "AutoRestart", "0", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "conf.ini")) == "1")
            {
                toolStripButton_VerifyHotmailIsGood_Click(new object(), new EventArgs());
            }
        }

        private void ClearChildForm()
        {
            foreach (var f in _childForms)
            {
                f.Close();
                f.Dispose();
            }
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            ClearChildForm();

            AddEduForm aef = new AddEduForm();
            aef.MdiParent = this;
            aef.Dock = DockStyle.Fill;
            aef.Show();

            _childForms.Add(aef);
        }

        private void toolStripButton_Login_Click(object sender, EventArgs e)
        {
            ClearChildForm();

            LoginEduForm lef = new LoginEduForm();
            lef.MdiParent = this;
            lef.Dock = DockStyle.Fill;
            lef.Show();

            _childForms.Add(lef);
        }

        private void toolStripButton_VerifyEdu_Click(object sender, EventArgs e)
        {
            ClearChildForm();

            VerifyEduForm vef = new VerifyEduForm();
            vef.MdiParent = this;
            vef.Dock = DockStyle.Fill;
            vef.Show();

            _childForms.Add(vef);
        }

        private void toolStripButton_DelEdu_Click(object sender, EventArgs e)
        {
            ClearChildForm();

            DelEduForm def = new DelEduForm();
            def.MdiParent = this;
            def.Dock = DockStyle.Fill;
            def.Show();

            _childForms.Add(def);
        }

        private void toolStripButton_test_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_AddOwn_Click(object sender, EventArgs e)
        {
            ClearChildForm();

            OwnEduAdderForm oef = new OwnEduAdderForm();
            oef.MdiParent = this;
            oef.Dock = DockStyle.Fill;
            oef.Show();

            _childForms.Add(oef);

        }

        private void toolStripButton_Amazon_Click(object sender, EventArgs e)
        {
            ClearChildForm();

            AmazonRegisterFrom arf = new AmazonRegisterFrom();
            arf.MdiParent = this;
            arf.Dock = DockStyle.Fill;
            arf.Show();

            _childForms.Add(arf);
        }

        private void toolStripButton_VerifyHotmailIsGood_Click(object sender, EventArgs e)
        {
            ClearChildForm();

            VerifyHotmailIsGood vhi = new VerifyHotmailIsGood();
            vhi.MdiParent = this;
            vhi.Dock = DockStyle.Fill;
            vhi.Show();

            _childForms.Add(vhi);
        }
    }
}
