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
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {
        // Define the delegate
        public delegate void IssueLicenseEventHandler(object sender, bool IsIssued);

        // Define the event
        public event IssueLicenseEventHandler IssueLicense;


        private int _LocalDrivingLicenseApplicationID;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmIssueDriverLicenseForTheFirstTime(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            _LoadScreenInfo();
        }

        private void _LoadScreenInfo()
        {
            ctrlLocalDrivingLicenseApplicationInfo1.DisplayLocalDrivingLicenseApplicationInfoOutside(_LocalDrivingLicenseApplicationID);

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);
        }

        private void _SetDriverInfo(clsLicense License)
        {
            int ApplicantPersonID = _LocalDrivingLicenseApplication.Application.ApplicantPerson.ID;

            if (!clsDriver.IsExist(ApplicantPersonID))
            {
                clsDriver driver = new clsDriver();
                driver.Person = clsPerson.Find(ApplicantPersonID);

                if (!driver.Save())
                {
                    // Close the form when facing add driver error
                    MessageBox.Show("Error for Adding new driver", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }

            License.Driver = clsDriver.FindByPersonID(ApplicantPersonID);
        }

        private void _SetLicenseInfo(clsLicense License)
        {
            _SetDriverInfo(License);

            // Set other license info
            License.Notes = rtxtNotes.Text;

            License.Application = _LocalDrivingLicenseApplication.Application;

            License.LicenseClass = _LocalDrivingLicenseApplication.LicenseClass;
        }

        private void _IssueLicense()
        {
            if (MessageBox.Show("Are you sure you want to issue license?", "Issue"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLicense NewLicense = new clsLicense();

                _SetLicenseInfo(NewLicense);

                if (NewLicense.Save())
                {
                    MessageBox.Show($"License issued successfully with license ID = {NewLicense.ID}", "Succeeded"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Raise the event
                    IssueLicense?.Invoke(this, IsIssued: true);

                    // Close the form after issuing the license
                    this.Close();
                }
                else
                {
                    MessageBox.Show("License issue operation failed!", "Failed"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _IssueLicense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
