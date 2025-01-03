using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageUsers : Form
    {
        
        DataView dvUsersList = new DataView();

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _RefreshUsersList()
        {
            
            dvUsersList = clsUser.GetUsersList().DefaultView;
            dgvUsersList.DataSource = dvUsersList;

            //Display number of records
            lblUsersCount.Text = clsUser.GetUsersCount().ToString();
        }

        private void _Refresh()
        {
            _RefreshUsersList();
        }

        private void _ShowUserDetails()
        {
            if (dgvUsersList.SelectedCells.Count > 0)
            {
                int SelectedUserID = (int)dgvUsersList.CurrentRow.Cells["User ID"].Value;

                //Open user details form
                frmUserInfo frm = new frmUserInfo(SelectedUserID);
                frm.ShowDialog();

                _RefreshUsersList();
            }
        }

        private void _AddNewUser()
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(-1);
            frm.ShowDialog();

            _RefreshUsersList();
        }

        private void _UpdateUser()
        {
            if (dgvUsersList.SelectedCells.Count > 0)
            {
                int SelectedUserID = (int)dgvUsersList.CurrentRow.Cells["User ID"].Value;

                frmAddUpdateUser frm = new frmAddUpdateUser(SelectedUserID);
                frm.ShowDialog();

                _RefreshUsersList();
            }
        }

        private void _DeleteUser()
        {
            if (dgvUsersList.SelectedCells.Count > 0)
            {
                int SelectedUserID = (int)dgvUsersList.CurrentRow.Cells["User ID"].Value;

                if (MessageBox.Show(clsUtility.askForDeleteMessage("user", SelectedUserID), "Delete?"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsUser.Delete(SelectedUserID))
                    {
                        MessageBox.Show(clsUtility.deleteMessage("user", SelectedUserID), clsUtility.deleteTitle("User")
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _RefreshUsersList();
                    }
                    else
                    {
                        MessageBox.Show(clsUtility.errorDeleteMessage, clsUtility.errorDeleteTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void _ChangeUserPassword()
        {
            if (dgvUsersList.SelectedCells.Count > 0)
            {
                int SelectedUserID = (int)dgvUsersList.CurrentRow.Cells["User ID"].Value;

                frmChangePassword frm = new frmChangePassword(SelectedUserID);
                frm.ShowDialog();

                _RefreshUsersList();
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            _AddNewUser();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowUserDetails();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UpdateUser();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddNewUser();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeleteUser();  
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChangeUserPassword();
        }
    }
}
