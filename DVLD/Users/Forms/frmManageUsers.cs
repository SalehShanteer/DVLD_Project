using DVLD_Business;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageUsers : Form
    {
        
        private DataView _dvUsersList = new DataView();

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _Refresh()
        {
            cbxFilter.SelectedIndex = 0; // Filter default index at (None)

            _RefreshUsersList();
        }

        private void _RefreshUsersList()
        {
            Thread RefreshUsersListThread = new Thread(() =>
            {
                _dvUsersList = clsUser.GetUsersList().DefaultView;

                // Invoke to update UI from main thread
                this.Invoke(new Action(() =>
                {
                    dgvUsersList.DataSource = _dvUsersList;

                    //Display number of records
                    int recordsCount = dgvUsersList.Rows.Count;
                    lblUsersCount.Text = recordsCount.ToString();

                    // If there are records
                    if (recordsCount > 0)
                    {
                        _PrepareApplicationList();
                    }
                }));
            });

            RefreshUsersListThread.Start();
        }

        private void _PrepareApplicationList()
        {
            //Adjust columns widths
            dgvUsersList.Columns["User ID"].Width = 60;
            dgvUsersList.Columns["Person ID"].Width = 70;
            dgvUsersList.Columns["Full Name"].Width = 350;
            dgvUsersList.Columns["Role"].Width = 200;
        }

        private void _Filter()
        {
            string filterAttribute = cbxFilter.Text;
            string filter = txtFilter.Text.Trim();

            if (filterAttribute == "None" || string.IsNullOrEmpty(filter))
            {
                _dvUsersList.RowFilter = string.Empty;
            }
            else
            {
                if (filterAttribute == "Person ID" || filterAttribute == "User ID")
                {
                    _dvUsersList.RowFilter = $"[{filterAttribute}] = {filter}";
                }
                else
                {
                    _dvUsersList.RowFilter = $"[{filterAttribute}] LIKE '{filter}%'";
                }
            }
        }

        private void _FilterUserActivation()
        {
            switch (cbxUserActivation.Text)
            {
                case "All":
                    {
                        _dvUsersList.RowFilter = string.Empty;
                        break;
                    }
                case "Yes": 
                    {
                        _dvUsersList.RowFilter = "[Is Active] = 1";
                        break;
                    }
                case "No":
                    {
                        _dvUsersList.RowFilter = "[Is Active] = 0";
                        break;
                    }

                    default:
                    {
                        _dvUsersList.RowFilter = string.Empty;
                        break;
                    }
            }
        }

        private void _ShowUserDetails()
        {

            if (!clsSettings.CheckPermission((int)clsSettings.enUserPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

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
            if (!clsSettings.CheckPermission((int)clsSettings.enUserPermissions.AddUpdate))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmAddUpdateUser frm = new frmAddUpdateUser(-1);

            frm.SavePerson += (sender, IsSaved) =>
            {
                if (IsSaved)
                {
                    _RefreshUsersList(); // Refresh users list after saving new user
                }
            };

            frm.ShowDialog();
        }

        private void _UpdateUser()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enUserPermissions.AddUpdate))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvUsersList.SelectedCells.Count > 0)
            {
                int SelectedUserID = (int)dgvUsersList.CurrentRow.Cells["User ID"].Value;

                frmAddUpdateUser frm = new frmAddUpdateUser(SelectedUserID);

                frm.SavePerson += (sender, IsSaved) =>
                {
                    if (IsSaved)
                    {
                        _RefreshUsersList(); // Refresh users list after updating user
                    }
                };

                frm.ShowDialog();
            }
        }

        private void _DeleteUser()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enUserPermissions.Delete))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

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
            if (!clsSettings.CheckPermission((int)clsSettings.enUserPermissions.AddUpdate))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

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

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (cbxFilter.Text == "User ID" || cbxFilter.Text == "Person ID"))
            {
                e.Handled = true;// Ensure only digits allowed when User ID and Person ID selected
            }
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear filter textBox
            txtFilter.Text = string.Empty;

            if (cbxFilter.Text == "None")
            {
                txtFilter.Visible = false;
                cbxUserActivation.Visible = false;
            }
            else if (cbxFilter.Text == "Is Active")
            {
                txtFilter.Visible = false;
                cbxUserActivation.Visible = true;
                cbxUserActivation.SelectedIndex = 0; // Filter default index at (All)
            }
            else
            {
                txtFilter.Visible = true;
                cbxUserActivation.Visible = false;
            }
        }

        private void cbxUserActivation_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterUserActivation();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
