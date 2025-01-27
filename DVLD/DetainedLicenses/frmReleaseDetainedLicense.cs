using DVLD_Business;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmReleaseDetainedLicense : Form
    {
        // Delegate for releasing detained license
        public delegate void ReleaseDetainedLicenseEventHandler(object sender, bool IsReleased);

        // Event for releasing detained license
        public event ReleaseDetainedLicenseEventHandler ReleaseDetainedLicense;

        private bool _ReleasedNow = false;

        private int _LicenseID;  

        private clsDetainedLicense _DetainedLicense;

        public frmReleaseDetainedLicense(int LicenseID = -1)
        {
            InitializeComponent();

            if (LicenseID != -1)
            {
                // Load detained license info by license ID
                ctrlDriverLicenseInfoWithFilter1.DisplayLicenseInfoFromOutside(LicenseID);
                ctrlDriverLicenseInfoWithFilter1.DisableFilterFromOutside();
            }
        }
       
        private void _RefreshDriverLicenseInfo()
        {
            // Refresh driver license info
            _ReleasedNow = true;

            // Refresh license info
            ctrlDriverLicenseInfoWithFilter1.DisplayLicenseInfoFromOutside(_DetainedLicense.License.ID);
        }

        private void _ReleaseDetainedLicense()
        {

            if (MessageBox.Show("Are you sure you want to release this license?", "Release License"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
             
                if (_DetainedLicense.Release())
                {
                    MessageBox.Show($"Detained license released successfully", "Release License"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Raise event
                    ReleaseDetainedLicense?.Invoke(this, true);

                    // Disable detain button
                    btnRelease.Enabled = false;

                    // Display release application ID
                    lblApplicationID.Text = _DetainedLicense.ReleaseApplication.ID.ToString();

                    _RefreshDriverLicenseInfo();
                }
                else
                {
                    MessageBox.Show("Failed to release license", "Release License"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void _DisplayDetainInfo()
        {
            short ApplicationFees = clsApplicationType.GetFees(5);
            short TotalFees = (short)(_DetainedLicense.FineFees + ApplicationFees);

            lblDetainID.Text = _DetainedLicense.ID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToString("M/dd/yyyy");
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblApplicationFees.Text = ApplicationFees.ToString();
            lblTotalFees.Text = TotalFees.ToString();
            lblCreatedBy.Text = _DetainedLicense.CreatedByUser.Username;
        }

        private void _DisplayLicenseInfo()
        {
            // Display license ID 
            lblLicenseID.Text = _LicenseID.ToString();

            // Enable show licenses history link label
            llblShowLicensesHistory.Enabled = true;
        }

        private void _LoadDetainedLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;

            _DisplayLicenseInfo();

            if (clsDetainedLicense.IsDetained(LicenseID))
            {
                _DetainedLicense = clsDetainedLicense.FindNonReleasedByLicenseID(LicenseID);

                _DisplayDetainInfo();

                // Enable release button
                btnRelease.Enabled = true;
            }
            else
            {
                MessageBox.Show("This license is not detained", "Release Detained License"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Disable release button
                btnRelease.Enabled = false;
            }
        }

        private void _ShowLicensesHistoryScreen()
        {

            if (!clsSettings.CheckPermission((int)clsSettings.enLicensePermissions.ReadLocal + (int)clsSettings.enLicensePermissions.ReadInternational))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Get the national number of the person
            string NationalNumber = clsPerson.GetPersonNationalNumberByLicenseID(_LicenseID);

            frmLicenseHistory frm = new frmLicenseHistory(NationalNumber);
            frm.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnFindLicenseComplete(int LicenseID)
        {

            if (_ReleasedNow == true)
            {
                // Reset the flag
                _ReleasedNow = false;
            }
            else
            {
                _LoadDetainedLicenseInfo(LicenseID);
            }
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicensesHistoryScreen();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            _ReleaseDetainedLicense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
