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
    public partial class frmScheduleTest : Form
    {

        public delegate void IsSavedEventHandler(object sender, bool IsSaved);

        public event IsSavedEventHandler IsSaved;

        private enum enMode { AddNew = 0, Update = 1}

        private enum enTestMode { FirstTime = 0, Retake = 1}

        private enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        private struct stScheduleTest
        {
            public enMode Mode;

            public enTestMode TestMode;
            
            public enTestType TestType;

            public int LocalDrivingLicenseApplicationID;

            public int TestAppointmentID;

            public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;

            public clsTestAppointment TestAppointment;
        }

        private stScheduleTest _ScheduleTest;


        public frmScheduleTest(int TestAppointmentID, int LocalDrivingLicenseApplicationID, byte testType)
        {
            InitializeComponent();

            // Initialize Schedule Test struct
            _ScheduleTest.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _ScheduleTest.TestAppointmentID = TestAppointmentID;

            _ScheduleTest.Mode = TestAppointmentID == -1 ? enMode.AddNew : enMode.Update;

            if (testType >= 1 && testType <= 3)
            {
                _ScheduleTest.TestType = (enTestType)testType;

                _CheckIfRetake();
            }
            else
            {
                MessageBox.Show("Error loading test appointments form!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _LoadScheduleTestScreen();
        }

        private void _CheckIfRetake()
        {
            if (_ScheduleTest.Mode == enMode.AddNew)
            {
                // If trials > 0 that means the test will be (Retake) otherwise the test will be (First time test)
                _ScheduleTest.TestMode = clsTest.GetTrials((int)_ScheduleTest.TestType, _ScheduleTest.LocalDrivingLicenseApplicationID) > 0 ? enTestMode.Retake : enTestMode.FirstTime;
            }
            else
            {
                if (clsTest.IsRetake(_ScheduleTest.TestAppointmentID, _ScheduleTest.LocalDrivingLicenseApplicationID, (int)_ScheduleTest.TestType))
                {
                    _ScheduleTest.TestMode = enTestMode.Retake;
                }
                else
                {
                    _ScheduleTest.TestMode = enTestMode.FirstTime;
                }
            }
        }

        private void _LoadScheduleTestScreen()
        {
            // Retrieve L.D.L.App info
            _ScheduleTest.LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_ScheduleTest.LocalDrivingLicenseApplicationID);

            _DisplayTestImage();
            _DisplayTestInfo();
            _DisplayRetakeTestInfo();

            //Set min date for test date
            dtpTestDate.MinDate = DateTime.Now;

            if (_ScheduleTest.Mode == enMode.AddNew)
            {
                _ScheduleTest.TestAppointment = new clsTestAppointment();
            }
            else
            {
                // Retrieve test appointment info
                _ScheduleTest.TestAppointment = clsTestAppointment.Find(_ScheduleTest.TestAppointmentID);

                _DisplayUpdatedInfo();
                _CheckedIfTestAppintmentIsLocked();
            }
        }

        private void _CheckedIfTestAppintmentIsLocked()
        {
            // If the appointment is locked (means the test is taken) you cant edit on the test appointment
            if (_ScheduleTest.TestAppointment.IsLocked == true)
            {
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;

                //Show message for user
                lblLockedTestMessage.Enabled = true;
            }
        }

        private void _SetTestAppointmentInfo()
        {
            if (_ScheduleTest.Mode == enMode.AddNew)
            {
                // Retrieve objects info
                clsTestType TestType = clsTestType.Find((int)_ScheduleTest.TestType);
                clsUser User = clsUser.Find(clsUserSetting.GetCurrentUserID());

                // Set the objects info
                _ScheduleTest.TestAppointment.TestType = TestType;
                _ScheduleTest.TestAppointment.LocalDrivingLicenseApplication = _ScheduleTest.LocalDrivingLicenseApplication;
                _ScheduleTest.TestAppointment.CreatedByUser = User;
            }
            _ScheduleTest.TestAppointment.AppointmentDate = dtpTestDate.Value;
        }

        private void _SaveTestAppointment()
        {
            if (MessageBox.Show(clsUtility.askForSaveMessage("test appointment"), "Save?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _SetTestAppointmentInfo();

                if (_ScheduleTest.TestAppointment.Save())
                {
                    MessageBox.Show(clsUtility.saveMessage("test appointment"), clsUtility.saveTitle("Test Appointment")
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Raise the event
                    IsSaved?.Invoke(this, IsSaved : true);

                    // Close the form after saving
                    this.Close();
                }
                else
                {
                    MessageBox.Show(clsUtility.errorSaveMessage, clsUtility.errorSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _DisplayUpdatedInfo()
        {
            // Set minimum date
            if (_ScheduleTest.TestAppointment.AppointmentDate < dtpTestDate.MinDate)
            {
                dtpTestDate.MinDate = _ScheduleTest.TestAppointment.AppointmentDate;
            }
            // Display appointment date
            dtpTestDate.Value = _ScheduleTest.TestAppointment.AppointmentDate;

            if (_ScheduleTest.TestMode == enTestMode.Retake)
            {
                // Display repeat test appointment ID in retake mode
                lblRepeatTestAppID.Text = _ScheduleTest.TestAppointment.ID.ToString();
            }
            if (_ScheduleTest.TestAppointment.IsLocked == true)
            {
                // Show the message when the appointment is locked
                lblLockedTestMessage.Visible = true;
            }
        }

        private void _DisplayTestImage()
        {
            switch (_ScheduleTest.TestType)
            {
                case enTestType.VisionTest:
                    {
                        pbTestType.Image = Resources.vision_test;
                        break;
                    }

                case enTestType.WrittenTest:
                    {
                        pbTestType.Image = Resources.written_test;
                        break;
                    }

                case enTestType.StreetTest:
                    {
                        pbTestType.Image = Resources.street_test;
                        break;
                    }

                default:
                    {
                        pbTestType.Image = Resources.vision_test;
                        break;
                    }
            }
        }

        private void _DisplayTestInfo()
        {
            lblLocalDrivingLicenseApplicationID.Text = _ScheduleTest.LocalDrivingLicenseApplication.ID.ToString();
            lblDrivingClass.Text = _ScheduleTest.LocalDrivingLicenseApplication.LicenseClass.Title;
            lblName.Text = _ScheduleTest.LocalDrivingLicenseApplication.Application.ApplicantPerson.FullName;
            lblTrial.Text = clsTest.GetTrials((int)_ScheduleTest.TestType, _ScheduleTest.LocalDrivingLicenseApplication.ID).ToString();
            lblFees.Text = clsTestType.GetFees((short)_ScheduleTest.TestType).ToString();
        }

        private void _DisplayRetakeTestInfo()
        {
            if (_ScheduleTest.TestMode == enTestMode.FirstTime)
            {
                // Set title
                lblTitle.Text = "Schedule Test";

                // Disable retake test info groupBox
                gbRetakeTestInfo.Enabled = false;

                lblRepeatTestFees.Text = "0";
                lblTotalFees.Text = lblFees.Text;
            }
            else
            {
                // Set title
                lblTitle.Text = "Schedule Retake Test";
                
                // Enable retake test info groupBox
                gbRetakeTestInfo.Enabled = true;

                // Retrieve retake test fees
                short RetakeFees = clsTestAppointment.GetRetakeFees();

                lblRepeatTestFees.Text = RetakeFees.ToString();
                lblTotalFees.Text = (RetakeFees + Convert.ToInt16(lblFees.Text)).ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SaveTestAppointment();
        }

        private void dtpTestDate_ValueChanged(object sender, EventArgs e)
        {
            // Check if the date changed than before when updating the appointment
            //if (_ScheduleTest.Mode == enMode.Update && dtpTestDate.Value == _ScheduleTest.TestAppointment.AppointmentDate)
            //{
            //    btnSave.Enabled = false;
            //}
            //else
            //{
            //    btnSave.Enabled = true;
            //}
        }
    }
}
