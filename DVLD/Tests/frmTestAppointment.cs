using DVLD.Properties;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmTestAppointments : Form
    {

        private enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        private enTestType _TestType;
        
        private int _LocalDrivingLicenseApplicationID;

        private DataView _dvTestAppointments;


        public frmTestAppointments(int LocalDrivingLicenseApplicationID, byte testType)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            if (testType >= 1 && testType <= 3)
            {
                _TestType = (enTestType)testType;
            }
            else
            {
                MessageBox.Show("Error loading test appointments form!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            // Display Local Driving License Application Info
            ctrlLocalDrivingLicenseApplicationInfo1.DisplayLocalDrivingLicenseApplicationInfoOutside(_LocalDrivingLicenseApplicationID);

            _LoadTestAppointmentScreen();
        }

        private void _LoadTestAppointmentScreen()
        {
            _DisplayTitles();
            _Refresh();
        }

        private void _DisplayTitles()
        {
            switch (_TestType)
            {
                case enTestType.VisionTest:
                    {
                        this.Text = "Vision Test Appointments";
                        lblTestAppointmentsTitle.Text = this.Text;
                        pbTestType.Image = Resources.vision_test;

                        break;
                    }

                case enTestType.WrittenTest:
                    {
                        this.Text = "Written Test Appointments";
                        lblTestAppointmentsTitle.Text = this.Text;
                        pbTestType.Image = Resources.written_test;

                        break;
                    }

                case enTestType.StreetTest:
                    {
                        this.Text = "Street Test Appointments";
                        lblTestAppointmentsTitle.Text = this.Text;
                        pbTestType.Image = Resources.street_test;

                        break;
                    }
            }
        }

        private void _Refresh()
        {
            _RefreshTestAppointments();
        }

        private void _RefreshTestAppointments()
        {
            Thread RefreshTestAppointmentThread = new Thread(() =>
            {
                _dvTestAppointments = clsTestAppointment.GetTestAppointmentsListByLDLAppIDAndTestTypeID(_LocalDrivingLicenseApplicationID, (int)_TestType).DefaultView;

                // To ensure that the data grid view is updated from the main thread
                this.Invoke(new Action(() => { dgvTestAppointmentsList.DataSource = _dvTestAppointments; }));
            });
            
            RefreshTestAppointmentThread.Start();
        }

        private void _AddNewTestAppointment()
        {
            if (clsTestAppointment.CheckTestAppointmentAvailability(_LocalDrivingLicenseApplicationID, (int)_TestType))
            {
                frmScheduleTest frm = new frmScheduleTest(-1, _LocalDrivingLicenseApplicationID, (byte)_TestType);

                frm.IsSaved += (sender, IsSaved) =>
                {
                    if (IsSaved)
                    {
                        _RefreshTestAppointments(); // Refresh the test appointments list if the appointment is saved
                    }
                };

                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Person can't book appointment now, because there is an active appointment available", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _UpdateTestAppointment()
        {
            if (dgvTestAppointmentsList.SelectedCells.Count > 0)
            {
                int SelectedAppointmentID = (int)dgvTestAppointmentsList.CurrentRow.Cells["Appointment ID"].Value;

                frmScheduleTest frm = new frmScheduleTest(SelectedAppointmentID, _LocalDrivingLicenseApplicationID, (byte)_TestType);

                frm.IsSaved += (sender, IsSaved) =>
                {
                    if (IsSaved)
                    {
                        _RefreshTestAppointments(); // Refresh the test appointments list if the appointment is saved
                    }
                };

                frm.ShowDialog();
            }
        }

        private void _TakeTest()
        {
            if (dgvTestAppointmentsList.SelectedCells.Count > 0)
            {
                int SelectedAppointmentID = (int)dgvTestAppointmentsList.CurrentRow.Cells["Appointment ID"].Value;

                frmTakeTest frm = new frmTakeTest(SelectedAppointmentID);

                frm.TestSaved += (sender, IsSaved) =>
                {
                    if (IsSaved)
                    {
                        _RefreshTestAppointments(); // Refresh the test appointments list if the test is saved
                    }
                };

                frm.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {
            _AddNewTestAppointment();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UpdateTestAppointment();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _TakeTest();
        }

        private void cmsTestAppointment_Opening(object sender, CancelEventArgs e)
        {
            if (dgvTestAppointmentsList.SelectedCells.Count > 0)
            {
                bool IsLocked = (bool)dgvTestAppointmentsList.CurrentRow.Cells["Is Locked"].Value;

                // Enable (take test) when the appointment is not locked otherwise disable (take test)
                takeTestToolStripMenuItem.Enabled = !IsLocked;
            }
        }
    }
}
