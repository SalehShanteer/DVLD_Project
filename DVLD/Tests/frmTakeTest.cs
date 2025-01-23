using DVLD.Properties;
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
    public partial class frmTakeTest : Form
    {
        // Event handler for test saved
        public delegate void TestSavedEventHandler(object sender, bool IsSaved);

        // Event for test saved
        public event TestSavedEventHandler TestSaved;

        private enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        private int _TestAppointmentID;

        private clsTestAppointment _TestAppointment;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadTestInfo();
        }

        private void _SaveTest()
        {
            if (MessageBox.Show(clsUtility.askForSaveMessage("test result"), "Save?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsTest test = new clsTest();

                _SetTestInfo(test);

                if (test.Save())
                {
                    MessageBox.Show(clsUtility.saveMessage("test result"), clsUtility.saveTitle("Test result")
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Raise event for test saved
                    TestSaved?.Invoke(this, IsSaved : true);
                }
                else
                {
                    MessageBox.Show(clsUtility.errorSaveMessage, clsUtility.errorSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);    
                }

                // Close form after saving
                this.Close();
            }
        }

        private void _SetTestInfo(clsTest test)
        {
            int UserID = clsUserSetting.GetCurrentUserID();

            test.TestAppointment = _TestAppointment;
            test.Result = (rbPass.Checked == true);
            test.Notes = rtxtNotes.Text;
            test.CreatedByUser = clsUser.Find(UserID);
        }

        private void _LoadTestInfo()
        {
            // Retrieve test appointment info
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment != null)
            {
                _DisplayTestImageAndGroupBoxTitle();
                _DisplayTestInfo();
            }
            else
            {
                MessageBox.Show(clsUtility.errorOpenFormMessag("take test"), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Close form if any error happen when find test appointment
                this.Close();
            }
        }

        private void _DisplayTestImageAndGroupBoxTitle()
        {
            switch ((enTestType)_TestAppointment.TestType.ID)
            {
                case enTestType.VisionTest:
                    {
                        pbTestType.Image = Resources.vision_test;
                        gbTestTitle.Text = "Vision Test";
                        break;
                    }

                case enTestType.WrittenTest:
                    {
                        pbTestType.Image = Resources.written_test;
                        gbTestTitle.Text = "Written Test";
                        break;
                    }

                case enTestType.StreetTest:
                    {
                        pbTestType.Image = Resources.street_test;
                        gbTestTitle.Text = "Street Test";
                        break;
                    }

                default:
                    {
                        pbTestType.Image = Resources.vision_test;
                        gbTestTitle.Text = "Vision Test";
                        break;
                    }
            }
        }

        private void _DisplayTestInfo()
        {
            lblLocalDrivingLicenseApplicationID.Text = _TestAppointment.LocalDrivingLicenseApplication.ID.ToString();
            lblDrivingClass.Text = _TestAppointment.LocalDrivingLicenseApplication.LicenseClass.Title;
            lblName.Text = _TestAppointment.LocalDrivingLicenseApplication.Application.ApplicantPerson.FullName;
            lblTrial.Text = clsTest.GetTrials(_TestAppointment.TestType.ID, _TestAppointment.LocalDrivingLicenseApplication.ID).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString("M/dd/yyyy");
            lblFees.Text = clsTestType.GetFees(_TestAppointment.TestType.ID).ToString();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveTest();
        }
    }
}
