using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {

        private enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

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
            
            Thread RefreshThread =  new Thread(() =>
            {
                _dvLocalDrivingLicenseApplicationList = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationsList().DefaultView;
               
                this.Invoke(new Action(()=>
                {
                    dgvLocalDrivingLicenseApplicationsList.DataSource = _dvLocalDrivingLicenseApplicationList;

                    // Display Local Driving License Applications Count
                    lblLocalDrivingLicenseApplicationsCount.Text = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationsCount().ToString();

                    _PrepareApplicationList();
                }));
            });   

            RefreshThread.Start();
        }

        private void _PrepareApplicationList()
        {
            //Adjust columns widths
            dgvLocalDrivingLicenseApplicationsList.Columns["Driving Class"].Width = 250;
            dgvLocalDrivingLicenseApplicationsList.Columns["National No."].Width = 120;
            dgvLocalDrivingLicenseApplicationsList.Columns["Full Name"].Width = 340;
            dgvLocalDrivingLicenseApplicationsList.Columns["Application Date"].Width = 180;
            dgvLocalDrivingLicenseApplicationsList.Columns["Passed Tests"].Width = 98;
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
                else if (filterAttribute == "National No.")
                {
                    _dvLocalDrivingLicenseApplicationList.RowFilter = $"[{filterAttribute}] = '{filter}'";
                }
                else
                {
                    _dvLocalDrivingLicenseApplicationList.RowFilter = $"[{filterAttribute}] LIKE '{filter}%'";
                }
            }
        }


        // Managing L.D.L.App

        private void _ShowApplicationDetails()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLocalLicenseApplicationPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(SelectedLocalDrivingLicenseApplicationID);
                frm.ShowDialog();

                _RefreshLocalDrivingLicenseApplications();
            }
        }

        private void _AddNewLocalDrivingLicenseApplication()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLocalLicenseApplicationPermissions.AddUpdate))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(-1);
            
            frm.IsSaved += (sender, IsSaved) =>
            {
                if (IsSaved)
                {
                    _RefreshLocalDrivingLicenseApplications(); // Refresh if the application saved
                }
            };

            frm.ShowDialog();
        }

        private void _UpdateLocalDrivingLicenseApplication()
        {

            if (!clsSettings.CheckPermission((int)clsSettings.enLocalLicenseApplicationPermissions.AddUpdate))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                
                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(SelectedLocalDrivingLicenseApplicationID);

                frm.IsSaved += (sender, IsSaved) =>
                {
                    if (IsSaved)
                    {
                        _RefreshLocalDrivingLicenseApplications(); // Refresh if the application saved
                    }
                };

                frm.ShowDialog();
            }
        }

        private void _DeleteLocalDrivingLicenseApplication()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLocalLicenseApplicationPermissions.Delete))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {

                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                // Ask for delete confirmation
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

            if (!clsSettings.CheckPermission((int)clsSettings.enLocalLicenseApplicationPermissions.AddUpdate))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                // Ask for cancel confirmation
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

        private void _ShowTestAppointments(enTestType TestType)
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enTestPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                frmTestAppointments frm = new frmTestAppointments(SelectedLocalDrivingLicenseApplicationID, (byte)TestType);
                frm.ShowDialog();

                _RefreshLocalDrivingLicenseApplications();
            }
        }

        private void _ShowIssueDrivingLicenseScreen()
        {

            if (!clsSettings.CheckPermission((int)clsSettings.enLicensePermissions.IssueLocal))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                frmIssueDriverLicenseForTheFirstTime frm = new frmIssueDriverLicenseForTheFirstTime(SelectedLocalDrivingLicenseApplicationID);
                
                frm.IssueLicense += (sender, IsIssued) =>
                {
                    if (IsIssued)
                    {
                        _RefreshLocalDrivingLicenseApplications(); // Refresh if the license issued
                    }
                };

                frm.ShowDialog();
            }
        }

        private void _ShowLicenseScreen()
        {

            if (!clsSettings.CheckPermission((int)clsSettings.enLicensePermissions.ReadLocal))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                int SelectedLocalDrivingLicenseApplicationID = Convert.ToInt32(dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["L.D.L.AppID"].Value);

                int SelectedLicenseID = clsLicense.GetLicenseIDByLocalLicenseApplicationID(SelectedLocalDrivingLicenseApplicationID);

                frmLicenseInfo frm = new frmLicenseInfo(SelectedLicenseID);
                frm.ShowDialog();
            }
        }

        private void _ShowPersonLicenseHistory()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLicensePermissions.ReadLocal + (int)clsSettings.enLicensePermissions.ReadInternational))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                string SelectedNationalNumber = dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["National No."].Value.ToString();

                frmLicenseHistory frm = new frmLicenseHistory(SelectedNationalNumber);
                frm.ShowDialog();
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

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowApplicationDetails();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowTestAppointments(enTestType.VisionTest);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowTestAppointments(enTestType.WrittenTest);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowTestAppointments(enTestType.StreetTest);
        }

        // Context Menu Strip
        private void _CancelledStatus()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            scheduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
        }

        private void _NewStatus()
        {
            byte SelectedPassedTests = (byte)dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["Passed Tests"].Value;

            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = true;
            scheduleTestsToolStripMenuItem.Enabled = true;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;

            switch (SelectedPassedTests)
            {

                case 0:
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled = true;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;

                        break;
                    }

                case 1:
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        scheduleWrittenTestToolStripMenuItem.Enabled = true;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;

                        break;
                    }

                case 2:
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        scheduleWrittenTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = true;

                        break;
                    }

                case 3:
                    {
                        scheduleTestsToolStripMenuItem.Enabled = false;
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;

                        break;
                    }

                default:
                    {
                        // Disable context menu strip
                        cmsLocalDrivingLicenseApplications.Enabled = false;

                        break;
                    }
            }
        }

        private void _CompletedStatus()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            scheduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = true;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
        }

        private void _NoStatus()
        {
            showApplicationDetailsToolStripMenuItem.Enabled = false;
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            scheduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
        }

        private void cmsLocalDrivingLicenseApplications_Opening(object sender, CancelEventArgs e)
        {
            if (dgvLocalDrivingLicenseApplicationsList.SelectedCells.Count > 0)
            {
                string ApplicationStatus = dgvLocalDrivingLicenseApplicationsList.CurrentRow.Cells["Status"].Value.ToString();

                switch (ApplicationStatus)
                {
                    case "Cancelled":
                        {                          
                            _CancelledStatus();

                            break;
                        }

                    case "New":
                        {
                            _NewStatus();

                            break;
                        }

                    case "Completed":
                        {
                            _CompletedStatus();

                            break;
                        }

                    default:

                        {
                            _NoStatus();

                            break;
                        }
                }
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowIssueDrivingLicenseScreen();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowLicenseScreen();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonLicenseHistory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
