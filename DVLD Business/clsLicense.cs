using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLicense
    {
        private enum enMode { AddNew = 0, Update = 1}

        private enMode _Mode;

        public int ID { get; set; }
        public clsApplication Application { get; set; }
        public clsDriver Driver { get; set; }
        public clsLicenseClass LicenseClass { get; set; }
        public string Notes { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public short PaidFees { get; set; }
        public bool IsActive { get; set; }  
        public clsUser CreatedByUser { get; set; }


        public clsLicense()
        {
            this.ID = -1;
            this.Application = null;
            this.Driver = null;
            this.LicenseClass = null;
            this.Notes = string.Empty;
            this.IssueDate = DateTime.MinValue;
            this.ExpireDate = DateTime.MinValue;
            this.PaidFees = -1;
            this.IsActive = false;
            this.CreatedByUser = null;

            _Mode = enMode.AddNew;
        }

        private clsLicense(int ID, clsApplication Application, clsDriver Driver, clsLicenseClass LicenseClass, string Notes
            , DateTime IssueDate, DateTime ExpireDate, short PaidFees, bool IsActive, clsUser CreatedByUser)
        {
            this.ID = ID;
            this.Application = Application;
            this.Driver = Driver;
            this.LicenseClass = LicenseClass;
            this.Notes = Notes;
            this.IssueDate = IssueDate;
            this.ExpireDate = ExpireDate;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.CreatedByUser = CreatedByUser;

            _Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            this.ID = clsLicenseData.AddNewLicense(this.Application.ID, this.Driver.ID, this.Notes, this.LicenseClass.ID);

            return this.ID != -1;
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.ID, this.Notes, this.ExpireDate);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLicense())
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
                        return _UpdateLicense();
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        public static clsLicense Find(int ID)
        {
            // Prepare the variables
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClasseID = -1;
            string Notes = string.Empty;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpireDate = DateTime.MinValue;
            short PaidFees = -1;
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsLicenseData.FindLicenseByID(ID, ref ApplicationID, ref DriverID, ref LicenseClasseID, ref Notes, ref IssueDate, ref ExpireDate, ref PaidFees, ref IsActive, ref CreatedByUserID))
            {
                // Find the related objects
                clsApplication application = clsApplication.Find(ApplicationID);
                clsDriver driver = clsDriver.Find(DriverID);
                clsLicenseClass license = clsLicenseClass.Find(LicenseClasseID);
                clsUser user = clsUser.Find(CreatedByUserID);

                return new clsLicense(ID, application, driver, license, Notes, IssueDate, ExpireDate, PaidFees, IsActive, user);
            }
            else
            {
                return null;
            }
        }

        public static clsLicense FindByLDLAppID(int LocalDrivingLicenseApplicationID)
        {
            // Prepare the variables
            int ID = -1;
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClasseID = -1;
            string Notes = string.Empty;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpireDate = DateTime.MinValue;
            short PaidFees = -1;
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsLicenseData.FindLicenseByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID, ref ID, ref ApplicationID
                , ref DriverID, ref LicenseClasseID, ref Notes, ref IssueDate, ref ExpireDate, ref PaidFees, ref IsActive, ref CreatedByUserID))
            {
                // Find the related objects
                clsApplication application = clsApplication.Find(ApplicationID);
                clsDriver driver = clsDriver.Find(DriverID);
                clsLicenseClass license = clsLicenseClass.Find(LicenseClasseID);
                clsUser user = clsUser.Find(CreatedByUserID);

                return new clsLicense(ID, application, driver, license, Notes, IssueDate, ExpireDate, PaidFees, IsActive, user);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int ID)
        {
            return clsLicenseData.IsLicenseExist(ID);
        }

        public static bool IsExistByApplicationID(int ApplicationID)
        {
            return clsLicenseData.IsLicenseExistByApplicationID(ApplicationID);
        }
        public static DataTable GetDriverLocalLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLocalLicenses(DriverID);
        }

        public static int GetLicensesCountByDriverID(int DriverID)
        {
            return clsLicenseData.GetLicensesRecordsCountByDriverID(DriverID);
        }

        public static bool RefreshAllLicensesToCheckActivation()
        {
            return clsLicenseData.RefreshAllLicensesToCheckActivation();
        }

        public static byte IsRenewable(int LicenseID)
        {
            return clsLicenseData.CheckIfDriverLicenseRenewable(LicenseID);
        }

        public static bool IsLicenseActive(int LicenseID)
        {
            return clsLicenseData.IsLicenseActive(LicenseID);
        }

        public static int GetLicenseIDByLocalLicenseApplicationID(int LocalLicenseApplicationID)
        {
            return clsLicenseData.GetLicenseIDByLocalLicenseApplicationID(LocalLicenseApplicationID);
        }

        public static int GetActiveClass3LicenseIDByDriverID(int DriverID)
        {
            return clsLicenseData.GetActiveClass3LicenseIDByDriverID(DriverID);
        }

    }
}
