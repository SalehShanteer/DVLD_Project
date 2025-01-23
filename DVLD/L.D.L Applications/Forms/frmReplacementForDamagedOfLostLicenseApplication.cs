using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmReplacementForDamagedOfLostLicenseApplication : Form
    {

        private enum enReplacementType { Damaged = 4, Lost = 3 }

        private enReplacementType _ReplacementType = enReplacementType.Damaged;

        private clsLicense _OldLicense;

        private clsLicense _NewLicense;

        public frmReplacementForDamagedOfLostLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmReplacementForDamagedOfLostLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadInitialApplicationInfo();
        }

        private void _DisplayApplicationFees()
        {
            lblApplicationFees.Text = clsApplicationType.GetFees((int)_ReplacementType).ToString();// 3 for Lost | 4 For Damaged
        }

        private void _LoadInitialApplicationInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("M/dd/yyyy");
            lblCreatedBy.Text = clsUserSetting.GetCurrentUserUsername();

            _DisplayApplicationFees();
        }

        private void _LoadOldLicense(int LicenseID)
        {
            lblOldLicenseID.Text = LicenseID.ToString();

            // Show licenses history link label
            llblShowLicensesHistory.Enabled = true;

            // retrieve the old license
            _OldLicense = clsLicense.Find(LicenseID);

            if (_OldLicense != null && _OldLicense.IsActive == true)
            {
                // Enable the issue replacement button
                btnIssueReplacement.Enabled = true;

            }
            else
            {
                MessageBox.Show("Selecte license is not active, Please choose an active license.", "Not Allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Disable the issue replacement button if the license is not found or not active
                btnIssueReplacement.Enabled = false;
            }
        }

        private void _SetApplicationInfo()
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPerson = _OldLicense.Driver.Person;
            Application.ApplicationType = clsApplicationType.Find((int)_ReplacementType); // Setting replacement type 

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
            _NewLicense.Notes = string.Empty;
        }

        private void _SetReplacementLicenseInfo()
        {
            _SetApplicationInfo();
            _SetOtherLicenseInfo();
        }

        private void _UpdateReplacementUI()
        {
            // Disable the issue replacement button
            btnIssueReplacement.Enabled = false;

            // Disable the replacement options groupBox
            gbReplacementOptions.Enabled = false;

            // Disable the find license filter
            ctrlDriverLicenseInfoWithFilter1.DisableFilterFromOutside();

            // Show new license info link label
            llblShowNewLicenseInfo.Enabled = true;
        }

        private void _DisplayAfterRenewInfo()
        {
            lblReplacedLicenseID.Text = _NewLicense.ID.ToString();
            lblReplacementApplication.Text = _NewLicense.Application.ID.ToString();
        }

        private void _UpdateReplacementTypeAndTitle()
        {
            if (rbDamaged.Checked == true)
            {
                _ReplacementType = enReplacementType.Damaged;

                // Set title
                lblApplicationTitle.Text = "Replacement For Damaged License";
                this.Text = lblApplicationTitle.Text;
            }
            else
            {
                _ReplacementType = enReplacementType.Lost;

                // Set title
                lblApplicationTitle.Text = "Replacement For Lost License";
                this.Text = lblApplicationTitle.Text;
            }
        }

        //private void _DeactivateOldLicense()
        //{
        //    _OldLicense.IsActive = false;
        //    if (!_OldLicense.Save())
        //    {
        //        MessageBox.Show("Error happen when deactivate old license", "Error"
        //            , MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void _IssueReplacement()
        {
            
            _NewLicense = new clsLicense();

            _SetReplacementLicenseInfo();

            if (_NewLicense.Save())
            {
                MessageBox.Show($"License replaced successfully with ID = {_NewLicense.ID}", "License Issued"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                //_DeactivateOldLicense();
                
                // I used trigger to deactivate damaged or lost licenses automatically in data base

                _UpdateReplacementUI();
                _DisplayAfterRenewInfo();

            }
            else
            {
                // Delete the application if the license is not saved
                clsApplication.Delete(_NewLicense.Application.ID);

                MessageBox.Show("Error happen when issue replacement operation", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            _UpdateReplacementTypeAndTitle();

            _DisplayApplicationFees();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnFindLicenseComplete(int LicenseID)
        {
            _LoadOldLicense(LicenseID);
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            _IssueReplacement();
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
