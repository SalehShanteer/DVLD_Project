using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTest
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;

        public int ID { get; set; }
        public clsTestAppointment TestAppointment { get; set; }
        public bool Result { get; set; }
        public string Notes { get; set; }
        public clsUser CreatedByUser { get; set; }

        public clsTest()
        {
            this.ID = -1;
            this.TestAppointment = null;
            this.Result = false;
            this.Notes = string.Empty;
            this.CreatedByUser = null;

            _Mode = enMode.AddNew;
        }

        private clsTest(int iD, clsTestAppointment testAppointment, bool result, string notes, clsUser createdByUser)
        {
            this.ID = iD;
            this.TestAppointment = testAppointment;
            this.Result = result;
            this.Notes = notes;
            this.CreatedByUser = createdByUser;

            _Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            this.ID = clsTestData.AddNewTest(this.TestAppointment.ID, Result, Notes, CreatedByUser.ID);

            return this.ID != -1;
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (_AddNewTest())
                {
                    _Mode = enMode.Update;
                    return true;
                }
            }
            return false;
        }

        public static clsTest Find(int ID)
        {
            int TestAppointmentID = -1;
            bool Result = false;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if (clsTestData.FindTestByID(ID, ref TestAppointmentID, ref Result, ref Notes, ref CreatedByUserID))
            {
                clsTestAppointment TestAppointment = clsTestAppointment.Find(TestAppointmentID);
                clsUser CreatedByUser = clsUser.Find(CreatedByUserID);

                return new clsTest(ID, TestAppointment, Result, Notes, CreatedByUser);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int ID)
        {
            return clsTestData.IsTestExist(ID);
        }

        public static bool Delete(int ID)
        {
            return clsTestData.DeleteTest(ID);
        }

        public static byte GetTrials(int TestTypeID, int LocalDrivingLicenseApplication)
        {
            return clsTestData.GetTestTrialsByTestTypeIDAndLocalDrivingLicenseApplication(TestTypeID, LocalDrivingLicenseApplication);
        }

        public static bool IsRetake(int TestAppointment, int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestData.CheckIfRetakeTest(TestAppointment, LocalDrivingLicenseApplicationID, TestTypeID);
        }

    }
}
