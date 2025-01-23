using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmRenewLocalDrivingLicense : Form
    {
        
        private clsLicense _OldLicense;

        private clsLicense _NewLicense;
        
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _DisplayInitialRenewApplicationInfo();
        }

        private void _DisplayInitialRenewApplicationInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("M/dd/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("M/dd/yyyy");
            lblApplicationFees.Text = clsApplicationType.GetFees(2).ToString();// 2 for Renew application type
            lblCreatedBy.Text = clsUserSetting.GetCurrentUserUsername();
        }

        private void _DisplayInitialLicenseInfo()
        {
            byte DefaultValidtyLength = _OldLicense.LicenseClass.DefaultValidityLength;
            short LicenseFees = _OldLicense.LicenseClass.Fees;
            short ApplicationFees = clsApplicationType.GetFees(2);

            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidtyLength).ToString("M/dd/yyyy");
            lblLicenseFees.Text = LicenseFees.ToString();
            lblOldLicenseID.Text = _OldLicense.ID.ToString();
            lblTotalFees.Text = (LicenseFees + ApplicationFees).ToString();
        }

        private void _SetApplicationInfo()
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPerson = _OldLicense.Driver.Person;
            Application.ApplicationType = clsApplicationType.Find(2);// Set renew 

            if (Application.Save())
            {
                _NewLicense.Application = clsApplication.Find(Application.ID);
            }
            else
            {
                MessageBox.Show("Error while save application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Close the form
                this.Close();
            }
        }

        private void _SetOtherLicenseInfo()
        {
            _NewLicense.Driver = _OldLicense.Driver;
            _NewLicense.LicenseClass = _OldLicense.LicenseClass;
            _NewLicense.Notes = rtxtNotes.Text.Trim();
        }

        private void _SetNewLicenseInfo()
        {
            _SetApplicationInfo();
            _SetOtherLicenseInfo();
        }

        private void _RenewLicense()
        {
            _NewLicense = new clsLicense();

            _SetNewLicenseInfo();

            if (_NewLicense.Save())
            {
                MessageBox.Show($"License renewed successfully with ID = {_NewLicense.ID}", "License Issued"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Disable renew button
                btnRenew.Enabled = false;

                // Enable show new license info
                llblShowNewLicenseInfo.Enabled = true;  

                _DisplayAfterRenewInfo();
            }
            else
            {
                // Delete the application if the license is not saved
                clsApplication.Delete(_NewLicense.Application.ID);

                MessageBox.Show("Error: License renew operation failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DisplayAfterRenewInfo()
        {
            lblRenewedLicenseID.Text = _NewLicense.ID.ToString();
            lblRenewApplication.Text = _NewLicense.Application.ID.ToString();
        }

        private void _DisplayOldLicenseInfo()
        {
            byte Status = 0;

            _DisplayInitialLicenseInfo();

            if (_CheckIfTheLicenseIsRenewable(_OldLicense.ID, ref Status))
            {
                // Enable renew button
                btnRenew.Enabled = true;
            }
            else
            {
                string ErrorMesssage = Status == 1 ? "Current license is not latest driver license please bring the current one"
                    : $"Selected lincense is already active, it will expire on: {_OldLicense.ExpireDate.ToString("M/dd/yyyy")}";

                MessageBox.Show(ErrorMesssage, "Not allowed!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Disable renew button
                btnRenew.Enabled = false;
            }

        }

        private bool _CheckIfTheLicenseIsRenewable(int LicenseID, ref byte Status)
        {
            Status = clsLicense.IsRenewable(LicenseID);

            return Status == 3;// 3 => renewable
        }

        private void _ShowLicensesHistoryScreen()
        {
            frmLicenseHistory frm = new frmLicenseHistory(_OldLicense.Driver.Person.NationalNumber);
            frm.ShowDialog();
        }

        private void _ShowNewLicenseInfoScreen()
        {
            frmLicenseInfo frm = new frmLicenseInfo(_NewLicense.ID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnFindLicenseComplete(int LicenseID)
        {
            // Retreive old license info
            _OldLicense = clsLicense.Find(LicenseID);

            //Enable show license history link label
            llblShowLicensesHistory.Enabled = true;

            _DisplayOldLicenseInfo();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            _RenewLicense();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicensesHistoryScreen();
        }

        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowNewLicenseInfoScreen();
        }

    }
}
