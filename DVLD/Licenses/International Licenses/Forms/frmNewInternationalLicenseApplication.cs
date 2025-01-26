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
    public partial class frmNewInternationalLicenseApplication : Form
    {

        private int _LocalLicenseID;

        private clsInternationalLicense _InternationalLicense;

        public frmNewInternationalLicenseApplication(int LicenseID = -1)
        {
            InitializeComponent();

            if (LicenseID != -1)
            {
                ctrlDriverLicenseInfoWithFilter1.DisplayLicenseInfoFromOutside(LicenseID);
            }
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _DisplayInitialLicenseInfo();
        }

        private void _DisplayInitialLicenseInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("M/dd/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("M/dd/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(clsInternationalLicenseSetting.GetValidityLength()).ToString("M/dd/yyyy");
            lblFees.Text = clsApplicationType.GetFees(6).ToString(); // 6 => New international license
            lblCreatedBy.Text = clsUserSetting.GetCurrentUserFullName();
        }

        private bool _CheckIfCanIssueInternationalLicense(int LicenseID, ref string ErrorMessage)
        {
            
            byte IssueStatus = clsInternationalLicense.CanIssueInternationalLicense(LicenseID);

            switch (IssueStatus)
            {
                case 0:
                    {
                        ErrorMessage = "Person license is not active or is not license class 3 (Ordinary driving license).";
                        break;
                    }

                case 1:
                        {
                        return true;
                    }

                case 2:
                    {
                        int InternationalLicenseID = clsInternationalLicense.GetIDByLocalLicenseID(LicenseID);

                        ErrorMessage = $"Person already have an active international license with ID = {InternationalLicenseID}.";
                        break;
                    }       
            }

            return false;
        }

        private void _IssueInternationalLicense()
        {

            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                _InternationalLicense = new clsInternationalLicense();

                // Set international license info
                clsLicense LocalLicense = clsLicense.Find(_LocalLicenseID);
                _InternationalLicense.IssuedUsingLocalLicense = LocalLicense;

                if (_InternationalLicense.Save())
                {
                    _InternationalLicense = clsInternationalLicense.Find(_InternationalLicense.ID);
                    MessageBox.Show($"International license issued successfully with ID = {_InternationalLicense.ID}", "License Issued"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _DisplayIssuingInfo(_InternationalLicense.Application.ID);
                }
                else
                {
                    MessageBox.Show("Error happens when issuing license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _DisplayIssuingInfo(int ApplicationID)
        {
            lblApplicationID.Text = ApplicationID.ToString();
            lblInternationaLicenseID.Text = _InternationalLicense.ID.ToString();

            // Enable show license info link label
            llblShowLicenseInfo.Enabled = true;

            // Disable issue button
            btnIssue.Enabled = false;
        }

        private void _DisplayLocalLicenseID()
        {
            lblLocalLicenseID.Text = _LocalLicenseID.ToString();
        }

        private void _ShowInternationalLicenseInfoScreen()
        {
            if (_InternationalLicense != null)
            {
                frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(_InternationalLicense.ID);
                frm.ShowDialog();
            }
        }
        
        private void _ShowLicensesHistoryScreen()
        {
            string NationalNumber = clsPerson.GetPersonNationalNumberByLicenseID(_LocalLicenseID);

            frmLicenseHistory frm = new frmLicenseHistory(NationalNumber);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnFindLicenseComplete(int LicenseID)
        {
            // Set local license ID to be used in issuing international license
            _LocalLicenseID = LicenseID;

            string ErrorMessage = string.Empty;

            //Enable show licenses history link label
            llblShowLicensesHistory.Enabled = true;

            if (_CheckIfCanIssueInternationalLicense(LicenseID, ref ErrorMessage))
            {
                _DisplayLocalLicenseID();

                btnIssue.Enabled = true;
            }
            else
            {
                MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnIssue.Enabled = false;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _IssueInternationalLicense();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowInternationalLicenseInfoScreen();
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicensesHistoryScreen();
        }
    }
}
