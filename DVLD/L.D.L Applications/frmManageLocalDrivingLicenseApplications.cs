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
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {

        private DataView _dvLocalDrivingLicenseApplicationList;
        
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _Refresh()
        {
            cbxFilter.SelectedIndex = 0; // Filter default index at (None)
            
            _RefreshLocalDrivingLicenseApplications();
        }

        private void _RefreshLocalDrivingLicenseApplications()
        {
            _dvLocalDrivingLicenseApplicationList = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationsList().DefaultView; 
            dgvLocalDrivingLicenseApplicationsList.DataSource = _dvLocalDrivingLicenseApplicationList;

            // Display Local Driving License Applications Count
            lblLocalDrivingLicenseApplicationsCount.Text = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationsCount().ToString();
        }

        private void _Filter()
        {
            string filterAttribute = cbxFilter.Text;
            string filter = txtFilter.Text.Trim();

            if (filterAttribute == "None" || string.IsNullOrEmpty(filter))
            {
                _dvLocalDrivingLicenseApplicationList.RowFilter = string.Empty;
            }
            else
            {
                if (filterAttribute == "L.D.L.AppID")
                {
                    _dvLocalDrivingLicenseApplicationList.RowFilter = $"{filterAttribute} = {filter}";
                }
                else
                {
                    _dvLocalDrivingLicenseApplicationList.RowFilter = $"[{filterAttribute}] LIKE '{filter}%'";
                }
            }
        }


        // Managing L.D.L.App
        private void _AddNewLocalDrivingLicenseApplication()
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(-1);
            frm.ShowDialog();

            _RefreshLocalDrivingLicenseApplications();
        }

        private void _UpdateLocalDrivingLicenseApplication()
        {
            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                
                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(SelectedLocalDrivingLicenseApplicationID);
                frm.ShowDialog();

                _RefreshLocalDrivingLicenseApplications();
            }
        }

        private void _DeleteLocalDrivingLicenseApplication()
        {
            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {

                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                if (MessageBox.Show(clsUtility.askForDeleteMessage("LocalDrivingLicenseApplication", SelectedLocalDrivingLicenseApplicationID), "Delete?"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsLocalDrivingLicenseApplication.Delete(SelectedLocalDrivingLicenseApplicationID))
                    {
                        MessageBox.Show(clsUtility.deleteMessage("LocalDrivingLicenseApplication", SelectedLocalDrivingLicenseApplicationID)
                            , clsUtility.deleteTitle("LocalDrivingLicenseApplication"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshLocalDrivingLicenseApplications();
                    }
                    else
                    {
                        MessageBox.Show(clsUtility.errorDeleteMessage, clsUtility.errorDeleteTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                    }
                }
            }
        }

        private void _CancelLocalDrivingLicenseApplication()
        {
            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                if (MessageBox.Show($"Are you sure you want to cancel this application with ID = ({SelectedLocalDrivingLicenseApplicationID}) ?"
                    , "Cancel Application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                    if (clsLocalDrivingLicenseApplication.Cancel(SelectedLocalDrivingLicenseApplicationID))
                    {
                        _RefreshLocalDrivingLicenseApplications();
                    }
                    else
                    {
                        MessageBox.Show("Error cancel application operation failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            _AddNewLocalDrivingLicenseApplication();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UpdateLocalDrivingLicenseApplication();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeleteLocalDrivingLicenseApplication();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _CancelLocalDrivingLicenseApplication();
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear filter textBox
            txtFilter.Text = string.Empty;

            if (cbxFilter.SelectedIndex == 0)
            {
                // If comboBox index at None will hide filter textBox
                txtFilter.Visible = false;
            }
            else
            {
                // If comboBox index in any filter will show filter textBox
                txtFilter.Visible = true;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && cbxFilter.Text == "L.D.L.AppID")
            {
                e.Handled = true;// Ensure only digits allowed when L.D.L.AppID selected
            }
        }
    }
}
