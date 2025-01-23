using DVLD_Business;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmInternationalLicenseApplications : Form
    {

        private DataView _dvInternationalLicensesList;
        
        public frmInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        // using async/await instead of Thread
        private async void _Refresh()
        {
            await _RefreshInternationalLicenses();

            cbxFilter.SelectedIndex = 0; // Filter default index at (none)
        }

        private async Task _RefreshInternationalLicenses()
        {
            try
            {
                _dvInternationalLicensesList = await Task.Run(() => clsInternationalLicense.GetInternationalLicensesList().DefaultView);

                dgvInternationalLicenseApplicationsList.DataSource = _dvInternationalLicensesList;

                // Display international licenses records count
                lblInternationalLicenseApplicationsCount.Text = clsInternationalLicense.GetRecordsCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _Filter()
        {
            string FilterAttribute = cbxFilter.Text;
            string FilterValue = txtFilter.Text.Trim();

            if (FilterAttribute == "None" || FilterValue == string.Empty)
            {
                _dvInternationalLicensesList.RowFilter = string.Empty; 
            }
            else
            {
                _CorrectFilterAttributeTitle(ref FilterAttribute);
                
                _dvInternationalLicensesList.RowFilter = $"[{FilterAttribute}] = {FilterValue}";
            }
        }

        private void _CorrectFilterAttributeTitle(ref string filterAttributeTitle)
        {
            switch (filterAttributeTitle)
            {
                case "International License ID":
                    {
                        filterAttributeTitle = "Int.License ID";
                        break;
                    }

                case "Local License ID":
                    {
                        filterAttributeTitle = "L.License ID";
                        break;
                    }
            }
        }

        private void _IsActiveFilter()
        {
            switch (cbxIsActive.SelectedIndex)
            {
                case 0:
                    {
                        // All
                        _dvInternationalLicensesList.RowFilter = string.Empty;
                        break;
                    }

                case 1:
                    {
                        // Yes
                        _dvInternationalLicensesList.RowFilter = "[Is Active] = 1";
                        break;
                    }
                case 2:
                    {
                        // No
                        _dvInternationalLicensesList.RowFilter = "[Is Active] = 0";
                        break;
                    }
            }
        }

        private void _ShowAddNewInternationalLicenseApplicationScreen()
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void _ShowPersonDetailsScreen()
        {
            if (dgvInternationalLicenseApplicationsList.SelectedCells.Count > 0)
            {
                int DriverID = (int)dgvInternationalLicenseApplicationsList.CurrentRow.Cells["Driver ID"].Value;

                int PersonID = clsDriver.Find(DriverID).Person.ID;
                frmPersonDetails frm = new frmPersonDetails(PersonID);
                frm.ShowDialog();
            }
        }

        private void _ShowLicenseDetailsScreen()
        {
            if (dgvInternationalLicenseApplicationsList.SelectedCells.Count > 0)
            {
                int SelectedInternationalLicenseID = (int)dgvInternationalLicenseApplicationsList.CurrentRow.Cells["Int.License ID"].Value;

                frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(SelectedInternationalLicenseID);
                frm.ShowDialog();
            }
        }

        private void _ShowPersonLicenseHistoryScreen()
        {
            if (dgvInternationalLicenseApplicationsList.SelectedCells.Count > 0)
            {
                int DriverID = (int)dgvInternationalLicenseApplicationsList.CurrentRow.Cells["Driver ID"].Value;

                string NationalNumber = clsDriver.Find(DriverID).Person.NationalNumber;
                frmLicenseHistory frm = new frmLicenseHistory(NationalNumber);
                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewInternationalLicenseApplication_Click(object sender, EventArgs e)
        {
            _ShowAddNewInternationalLicenseApplicationScreen();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonDetailsScreen();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowLicenseDetailsScreen();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonLicenseHistoryScreen();
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear filter textBox
            txtFilter.Text = string.Empty;
            cbxIsActive.SelectedIndex = 0;// Is active filter default index at (All)

            switch (cbxFilter.Text)
            {
                case "None":
                    {
                        txtFilter.Visible = false;
                        cbxIsActive.Visible = false;
                        break;
                    }

                case "Is Active":
                    {

                        txtFilter.Visible = false;
                        cbxIsActive.Visible = true;
                        break;
                    }

                default:
                    {
                        txtFilter.Visible = true;
                        cbxIsActive.Visible = false;
                        break;
                    }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void cbxIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IsActiveFilter();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ensure only digits are allowed
            }
        }
    }
}
