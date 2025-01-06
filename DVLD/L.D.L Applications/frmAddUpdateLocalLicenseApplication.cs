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
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {

        private enum enMode { AddNew = 0, Update= 1 }

        private enMode _Mode;

        private int _LocalDrivingLicenseApplicationID;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private int _PersonID;


        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            if (_LocalDrivingLicenseApplicationID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadLocalDrivingLicenseApplication();
        } 

        private bool _CheckIfPersonAppliedForSameLicenseClass()
        {
            // Check if person applied for local driving license on same license class before
            return clsLocalDrivingLicenseApplication.IsPersonAppliedForLicenseClass(_PersonID, cbxLicenseClass.SelectedIndex + 1);
        }

        private bool _SetApplicationInfo()
        {  
            clsApplication application = new clsApplication();

            application.ApplicationType = clsApplicationType.Find(1); // New Local Driving License Application

            application.ApplicantPerson = clsPerson.Find(_PersonID);

            application.CreatedByUser = clsUser.Find(clsUserSetting.GetCurrentUserID()); // CurrentUser
            

            if(application.Save())
            {
                //clsApplication NewApplication = clsApplication.Find(application.ID);
                _LocalDrivingLicenseApplication.Application = clsApplication.Find(application.ID);

                return true;
            }
            else
            {
                return false;
            }
        }

        private void _SetLicenseClassInfo()
        {
            _LocalDrivingLicenseApplication.LicenseClass = clsLicenseClass.Find(cbxLicenseClass.SelectedIndex + 1);
        }

        private bool _SetLocalDrivingLicenseApplicationInfo()
        {
            _SetLicenseClassInfo();

            return _SetApplicationInfo() ? true : false;
        }

        private void _SaveLocalDrivingLicenseApplication()
        {
            
            if (_SetLocalDrivingLicenseApplicationInfo())
            {
                if (_LocalDrivingLicenseApplication.Save())
                {
                    MessageBox.Show(clsUtility.saveMessage("local driving license application"), clsUtility.saveTitle("Local driving license application")
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _DisplayLocalDrivingLicenseApplicationInfo();
                }
                else
                {
                    MessageBox.Show(clsUtility.errorSaveMessage, clsUtility.errorSaveTitle
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(clsUtility.errorSaveMessage, clsUtility.errorSaveTitle
                   , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _LoadLicenseClassComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetLicenseClassesList();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbxLicenseClass.Items.Add(row["Title"]);
            }

            // Set default license class (Class 3 - ordinary driving)
            cbxLicenseClass.SelectedIndex = 2;
        }


        // Display
        private void _DisplayApplicationInfo()
        {
            lblDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.ID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.Application.ApplicationDate.ToShortDateString();
            lblApplicationFees.Text = _LocalDrivingLicenseApplication.Application.PaidFees.ToString();
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.Application.CreatedByUser.Person.PartialName;

            // Display the license class
            cbxLicenseClass.SelectedIndex = cbxLicenseClass.FindStringExact(_LocalDrivingLicenseApplication.LicenseClass.Title);
        }

        private void _DisplayPersonInfo()
        {
            int PersonID = _LocalDrivingLicenseApplication.Application.ApplicantPerson.ID;
            ctrlPersonInfoWithFilter1.FindPersonFromOutside(PersonID);
           
            // Disable the filter
            ctrlPersonInfoWithFilter1.DisableFilterFromOutside();
        }

        private void _DisplayLocalDrivingLicenseApplicationInfo()
        {
            // Change the title
            this.Text = "Update Local Driving License Application";
            lblAddUpdateLocalDrivingLicenseApplication.Text = "Update Local Driving License Application";

            _DisplayPersonInfo();
            _DisplayApplicationInfo();
        }

        private void _DisplayInitialApplicationInfo()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = clsApplicationType.GetFees(1).ToString();// Fees For New Local Driving License Application 
            lblCreatedBy.Text = clsUserSetting.GetCurrentUserFullName();
        }

        private void _LoadLocalDrivingLicenseApplication()
        {
            _LoadLicenseClassComboBox();

            if (_Mode == enMode.AddNew)
            {
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

                _DisplayInitialApplicationInfo();
            }
            else
            {
                // Retrieve the application information
                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

                _DisplayLocalDrivingLicenseApplicationInfo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(clsUtility.askForSaveMessage("local driving license application"), "Save?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!_CheckIfPersonAppliedForSameLicenseClass())
                {
                    _SaveLocalDrivingLicenseApplication();
                }
                else
                {                   
                    MessageBox.Show("Person already applied for local driving license on the same license class before."
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcDrivingLicenseApplicationInfo.SelectedIndex = 1; // Next
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcDrivingLicenseApplicationInfo.SelectedIndex = 0; // Back
        }

        private void ctrlPersonInfoWithFilter1_OnFindPersonComplete(int personID)
        {
            _PersonID = personID;
        }

        private void tcDrivingLicenseApplicationInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable save button only the tab page at application info page
            btnSave.Enabled = tcDrivingLicenseApplicationInfo.SelectedIndex == 1 ? true : false;
        }

    }
}
