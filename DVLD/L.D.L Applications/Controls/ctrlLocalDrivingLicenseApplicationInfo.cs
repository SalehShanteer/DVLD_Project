using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControl
    {

        private int _LocalDrivingLicenseApplicationID;

        private int _PersonID;

        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private bool _DisplayLocalDrivingLicenseApplicationInfo()
        {
           
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                lblLocalDrivingLicenseApplicationID.Text = LocalDrivingLicenseApplication.ID.ToString();
                lblAppliedForLicense.Text = LocalDrivingLicenseApplication.LicenseClass.Title;

                byte PassedTests = clsLocalDrivingLicenseApplication.GetPassedTests(LocalDrivingLicenseApplication.ID);
                lblPassedTests.Text = $"{PassedTests}/3";

                if (clsLicense.IsExistByApplicationID(LocalDrivingLicenseApplication.Application.ID))
                {
                    // Enable show license link label
                    llblShowLicenseInfo.Enabled = true;
                }
                else
                {
                    // Disable show license link label
                    llblShowLicenseInfo.Enabled = false;
                }
                
                _DisplayApplicationInfo(LocalDrivingLicenseApplication.Application);

                return true;
            }
            else
            {
                MessageBox.Show("L.D.L.App does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        private void _DisplayApplicationInfo(clsApplication Application)
        {
            lblID.Text = Application.ID.ToString();
            lblStatus.Text = Application.Status.Title;
            lblFees.Text = Application.PaidFees.ToString();
            lblType.Text = Application.ApplicationType.Title;
            lblApplicant.Text = Application.ApplicantPerson.FullName;
            lblDate.Text = Application.ApplicationDate.ToString("M/dd/yyyy");
            lblStatusDate.Text = Application.LastStatusDate.ToString("M/dd/yyyy");
            lblCreatedBy.Text = Application.CreatedByUser.Username;

            _PersonID = Application.ApplicantPerson.ID;

            // Enable show person link label
            llblShowPersonInfo.Enabled = true;
        }

        public bool DisplayLocalDrivingLicenseApplicationInfoOutside(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            return (_DisplayLocalDrivingLicenseApplicationInfo()) ? true : false;
        }

        private void _ShowPersonInfo()
        {
            // Check permission
            if (!clsSettings.CheckPermission((int)clsSettings.enPeoplePermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmPersonDetails frm = new frmPersonDetails(_PersonID);
            frm.ShowDialog();
        }

        private void _ShowLicenseInfo()
        {
            // Check permission
            if (!clsSettings.CheckPermission((int)clsSettings.enLicensePermissions.ReadLocal))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int LicenseID = clsLicense.GetLicenseIDByLocalLicenseApplicationID(_LocalDrivingLicenseApplicationID);
            if (LicenseID != -1)
            {
                frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("License does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowPersonInfo();
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ShowLicenseInfo();
        }
    }
}
