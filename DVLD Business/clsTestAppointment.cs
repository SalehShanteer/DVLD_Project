using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;

        public int ID { get; set; }
        public clsTestType TestType { get; set; }
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication { get; set; }
        public DateTime AppointmentDate { get; set; }
        public clsUser CreatedByUser { get; set; }
        public bool IsLocked { get; set; }  

        public clsTestAppointment()
        {
            this.ID = -1;
            this.TestType = null;
            this.LocalDrivingLicenseApplication = null;
            this.AppointmentDate = DateTime.MinValue;
            this.CreatedByUser = null;
            this.IsLocked = false;

            _Mode = enMode.AddNew;
        }

        private clsTestAppointment(int iD, clsTestType testType, clsLocalDrivingLicenseApplication localDrivingLicenseApplication, DateTime appointmentDate, clsUser createdByUser, bool isLocked)
        {
            ID = iD;
            TestType = testType;
            LocalDrivingLicenseApplication = localDrivingLicenseApplication;
            AppointmentDate = appointmentDate;
            CreatedByUser = createdByUser;
            IsLocked = isLocked;

            _Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            this.ID = clsTestAppointmentData.AddNewTestAppointment(this.TestType.ID, this.LocalDrivingLicenseApplication.ID, this.AppointmentDate, this.CreatedByUser.ID);
            return this.ID != -1;
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.ID, this.AppointmentDate, this.IsLocked);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTestAppointment())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        return _UpdateTestAppointment();
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        public static clsTestAppointment FindTestAppointmentByID(int ID)
        {
            // Prepare the variables
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.MinValue;
            int CreatedByUserID = -1;
            bool IsLocked = false;

            if (clsTestAppointmentData.FindTestAppointmentByID(ID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref CreatedByUserID, ref IsLocked))
            {
                clsTestType TestType = clsTestType.Find(TestTypeID);
                clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LocalDrivingLicenseApplicationID);
                clsUser CreatedByUser = clsUser.Find(CreatedByUserID);

                return new clsTestAppointment(ID, TestType, LocalDrivingLicenseApplication, AppointmentDate, CreatedByUser, IsLocked);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int ID)
        {
            return clsTestAppointmentData.IsTestAppointmentExist(ID);
        }

        public static bool Delete(int ID)
        {
            return clsTestAppointmentData.DeleteTestAppointment(ID);
        }

        public static DataTable GetTestAppointmentsList()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }

    }
}
