using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;

        public int ID { get; set; }
        public clsApplication Application { get; set; }
        public clsLicenseClass LicenseClass { get; set; }

        public clsLocalDrivingLicenseApplication()
        {
            this.ID = -1;
            this.Application = null;
            this.LicenseClass = null;

            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int iD, clsApplication application, clsLicenseClass licenseClass)
        {
            this.ID = iD;
            this.Application = application;
            this.LicenseClass = licenseClass;

            _Mode = enMode.Update; 
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.ID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.Application.ID, this.LicenseClass.ID);
            return this.ID != -1;
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.ID, this.Application.ID, this.LicenseClass.ID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLocalDrivingLicenseApplication())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    {
                        return _UpdateLocalDrivingLicenseApplication();
                    }

                default:
                    return false;
            }
        }

        public static clsLocalDrivingLicenseApplication Find(int ID)
        {
            // Prepare the variables
            int ApplicationID = -1;
            int LicenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationData.FindLocalDrivingLicenseApplicationByID(ID, ref ApplicationID, ref LicenseClassID))
            {
                // Find the application and license class
                clsApplication application = clsApplication.Find(ApplicationID);
                clsLicenseClass licenseClass = clsLicenseClass.Find(LicenseClassID);

                return new clsLocalDrivingLicenseApplication(ID, application, licenseClass);
            }
            else
                return null;
        }

        public static bool IsLocalDrivingLicenseApplicationExists(int ID)
        {
            return clsLocalDrivingLicenseApplicationData.IsLocalDrivingLicenseApplicationExists(ID);
        }

        public static bool Delete(int ID)
        {
            return clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(ID);
        }

        public static bool Cancel(int ID)
        {
            return clsLocalDrivingLicenseApplicationData.CancelLocalDrivingLicenseApplication(ID);
        }

        public static DataTable GetLocalDrivingLicenseApplicationsList()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public static bool IsPersonAppliedForLicenseClass(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.CheckIfPersonAppliedForLicenseClass(PersonID, LicenseClassID);
        }

        public static int GetLocalDrivingLicenseApplicationsCount()
        {
            return clsLocalDrivingLicenseApplicationData.CountNumberOfLocalDrivingLicenseApplications();
        }

    }
}   
