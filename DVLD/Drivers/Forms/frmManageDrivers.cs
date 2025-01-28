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
    public partial class frmManageDrivers : Form
    {

        private DataView _dvDriversList;
        
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _Refresh()
        {
            cbxFilter.SelectedIndex = 0; // Filter default index at (None)

            _RefreshDriversList();
        }

        private void _RefreshDriversList()
        {
            Thread RefreshThread = new Thread(() =>
            {
                _dvDriversList = clsDriver.GetDriversList().DefaultView;

                this.Invoke(new Action(() =>
                {
                    dgvDriversList.DataSource = _dvDriversList;

                    //Display drivers records count
                    int driversCount = clsDriver.GetDriversCount();
                    lblDriversCount.Text = driversCount.ToString();

                    //Check if there are drivers records
                    if (driversCount != 0)
                    {
                        _PrepareApplicationList();
                    }
                }
                ));
            });
            
            RefreshThread.Start();
        }

        private void _PrepareApplicationList()
        {
            //Adjust columns widths
            dgvDriversList.Columns["Driver ID"].Width = 65;
            dgvDriversList.Columns["Person ID"].Width = 65;
            dgvDriversList.Columns["National No."].Width = 70;
            dgvDriversList.Columns["Full Name"].Width = 345;
            dgvDriversList.Columns["Date"].Width = 170;
            dgvDriversList.Columns["Active Licenses"].Width = 85;          
        }

        private void _Filter()
        {
            string filterAttribute = cbxFilter.Text;
            string filter = txtFilter.Text.Trim();

            if (filterAttribute == "None" || string.IsNullOrEmpty(filter))
            {
                _dvDriversList.RowFilter = string.Empty;
            }
            else
            {
                if (filterAttribute == "Person ID" || filterAttribute == "Driver ID")
                {
                    _dvDriversList.RowFilter = $"[{filterAttribute}] = {filter}";
                }
                else if (filterAttribute == "National No.")
                {
                    _dvDriversList.RowFilter = $"[{filterAttribute}] = '{filter}'";
                }
                else
                {
                    _dvDriversList.RowFilter = $"[{filterAttribute}] LIKE '{filter}%'";
                }
            }
        }

        private void _ShowPersonInfoScreen()
        {
            if (dgvDriversList.SelectedCells.Count > 0)
            {
                int selectedPersonID = Convert.ToInt32(dgvDriversList.CurrentRow.Cells["Person ID"].Value);

                frmPersonDetails frm = new frmPersonDetails(selectedPersonID);
                frm.ShowDialog();
            }
        }

        private void _IssueInternationalLicense()
        {

            if (dgvDriversList.SelectedCells.Count > 0)
            {
                int selectedDriverID = Convert.ToInt32(dgvDriversList.CurrentRow.Cells["Driver ID"].Value);

                int SelectedLicenseID = clsLicense.GetActiveClass3LicenseIDByDriverID(selectedDriverID);

                // Check if driver has a valid license to issue international license and driver has no international license
                if (SelectedLicenseID != -1 && !clsDriver.HasInternationalLicense(selectedDriverID))
                {
                    frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication(SelectedLicenseID);
                    frm.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Driver has no valid license to issue international license", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
            }
        }

        private void _ShowLicensesHistory()
        {
            if (dgvDriversList.SelectedCells.Count > 0)
            {
                string selectedNationalNo = dgvDriversList.CurrentRow.Cells["National No."].Value.ToString();
                frmLicenseHistory frm = new frmLicenseHistory(selectedNationalNo);
                frm.ShowDialog();
            }
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;

            if (cbxFilter.Text == "None")
            {
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = true;
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) 
                &&
                (cbxFilter.Text == "Person ID" || cbxFilter.Text == "Driver ID"))
            {
                e.Handled = true;// Ensure only digits allowed when L.D.L.AppID selected
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonInfoScreen();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _IssueInternationalLicense();
        }

        private void showLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowLicensesHistory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
