using DVLD_Business;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD
{
    public partial class frmDetainLicense : Form
    {
        // Delegate for detaining license
        public delegate void DetainLicenseEventHandler(object sender, bool IsDetained);

        // Event for detaining license
        public event DetainLicenseEventHandler DetainLicense;

        private clsLicense _License;

        private bool _DetainedNow = false;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            _LoadInitialDetainInfo();
        }

        private void _LoadInitialDetainInfo()
        {
            lblDetainDate.Text = DateTime.Now.ToString("M/dd/yyyy");
            lblCreatedBy.Text = clsUserSetting.GetCurrentUserUsername();
        }

        private void _LoadLicenseInfo(int LicenseID)
        {

            // Enable show licenses history link label
            llblShowLicensesHistory.Enabled = true;

            _License = clsLicense.Find(LicenseID);

            // Display license ID
            lblLicenseID.Text = _License.ID.ToString();

            _CheckIfLicenseDetained(_License.ID);
        }
            
        private void _CheckIfLicenseDetained(int LicenseID)
        {
            if (clsDetainedLicense.IsDetained(LicenseID))
            {
                MessageBox.Show("This license is already detained", "Detain License"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Disable detain button
                btnDetain.Enabled = false;
            }
            else
            {
                // Enable detain button
                btnDetain.Enabled = true;
            }
        }

        private void _SetDetainInfo(clsDetainedLicense detainedLicense)
        {
            detainedLicense.License = _License;
            detainedLicense.FineFees = Convert.ToInt16(txtFineFees.Text);
        }

        private void _RefreshDriverLicenseInfo()
        {
            // Refresh driver license info
            _DetainedNow = true;

            ctrlDriverLicenseInfoWithFilter1.DisplayLicenseInfoFromOutside(_License.ID);
        }

        private void _DetainLicense()
        {
            
            if (MessageBox.Show("Are you sure you want to detain this license?", "Detain License"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsDetainedLicense detainedLicense = new clsDetainedLicense();

                _SetDetainInfo(detainedLicense);

                if (detainedLicense.Save())
                {
                    MessageBox.Show($"License detained successfully with ID = {detainedLicense.ID}", "Detain License"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Raise event
                    DetainLicense?.Invoke(this, true);

                    // Disable detain button
                    btnDetain.Enabled = false;

                    _RefreshDriverLicenseInfo();
                }
                else
                {
                    MessageBox.Show("Failed to detain license", "Detain License"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _ShowLicensesHistoryScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLicensePermissions.ReadLocal + (int)clsSettings.enLicensePermissions.ReadInternational))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmLicenseHistory frm = new frmLicenseHistory(_License.Driver.Person.NationalNumber);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnFindLicenseComplete(int LicenseID)
        {
            if (_DetainedNow)
            {
                _DetainedNow = false;// Reset the flag
            }
            else
            {
                _LoadLicenseInfo(LicenseID);
            }
        }

      
        private bool _ValidateFineFees()
        {
            if (string.IsNullOrWhiteSpace(txtFineFees.Text))
            {
                errorProvider1.SetError(txtFineFees, "Please enter the fine fees");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtFineFees, string.Empty);
                return true;
            }
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicensesHistoryScreen();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (_ValidateFineFees())
            {
                _DetainLicense();
            }
            else
            {
                MessageBox.Show(clsUtility.errorProviderMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ensure that the user can only enter digits
            }
   
        }

    }
}
