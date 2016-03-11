using GamesManager.Model;
using GamesManager.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamesManager
{
    public partial class PusherUserManager : Form
    {
        DataGridViewRow _currentDataGridViewRow = new DataGridViewRow();

        public DataGridViewRow CurrentDataGridViewRow
        {
            get { return _currentDataGridViewRow; }
            set
            {

                if (_currentDataGridViewRow != value)
                {
                    _currentDataGridViewRow = value;
                    this.textBox_PusherNameEdit.Text = _currentDataGridViewRow.Cells["PusherName"].Value.ToString();
                    this.textBox_PasswordEdit.Text = _currentDataGridViewRow.Cells["Password"].Value.ToString();
                    this.comboBox_RoleEdit.SelectedItem = _currentDataGridViewRow.Cells["Role"].Value;
                }
            }
        }

        public PusherUserManager()
        {
            InitializeComponent();

            this.comboBox_RoleAdd.SelectedIndex = 0;
        }

        private void ShowInfo(string msg)
        {
            this.toolStripStatusLabel_Info.Text = DateTime.Now.ToString() + "----" + msg;
        }

        private void button_SelectPusherNames_Click(object sender, EventArgs e)
        {
            try
            {
                List<PusherUserModel> pusherUserModelList = HttpDataHelper.GetPushers();

                this.dataGridView_AllUsers.Rows.Clear();

                for (int i = 0; i < pusherUserModelList.Count; i++)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pusherUserModelList[i].Name });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pusherUserModelList[i].Password });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pusherUserModelList[i].Role });
                    dgvr.Cells.Add(new DataGridViewTextBoxCell { Value = pusherUserModelList[i].AddTime });

                    this.dataGridView_AllUsers.Rows.Add(dgvr);
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_AllUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_AllUsers.SelectedCells.Count > 0)
            {
                int index_t = dataGridView_AllUsers.SelectedCells[0].RowIndex;
                CurrentDataGridViewRow = dataGridView_AllUsers.Rows[index_t];
            }
        }

        private void button_SubmitEdit_Click(object sender, EventArgs e)
        {
            try
            {
                HttpDataHelper.UpdatePusherUser(this.textBox_PusherNameEdit.Text, this.comboBox_RoleEdit.Text, this.textBox_PasswordEdit.Text);

                _currentDataGridViewRow.Cells["PusherName"].Value = this.textBox_PusherNameEdit.Text;
                _currentDataGridViewRow.Cells["Password"].Value = this.textBox_PasswordEdit.Text;
                _currentDataGridViewRow.Cells["Role"].Value = this.comboBox_RoleEdit.Text;

                ShowInfo(string.Format("{0}，更新成功", this.textBox_PusherNameEdit.Text));
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button_DeleteEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定删除?", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HttpDataHelper.DeletePusherUser(this.textBox_PusherNameEdit.Text);
                    dataGridView_AllUsers.Rows.Remove(_currentDataGridViewRow);

                    ShowInfo(string.Format("{0}，删除成功", this.textBox_PusherNameEdit.Text));
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button_SubmitAdd_Click(object sender, EventArgs e)
        {
            try
            {
                HttpDataHelper.AddPusherUser(this.textBox_PusherNameAdd.Text, this.textBox_PasswordAdd.Text, this.comboBox_RoleAdd.Text);
                ShowInfo(string.Format("{0}，添加成功", this.textBox_PusherNameAdd.Text));
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
