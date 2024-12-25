using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            this.Notes = string.Empty;
            this.IssueDate = DateTime.MinValue;
            this.ExpireDate = DateTime.MinValue;
            this.PaidFees = -1;
            this.IsActive = false;
            this.CreatedByUser = null;

            _Mode = enMode.AddNew;
        }

        private clsLicense(int ID, clsApplication application, clsDriver Driver, string Notes, DateTime IssueDate
            , DateTime ExpireDate, short PaidFees, bool IsActive, clsUser CreatedByUser)
        {
            this.ID = ID;
            this.Application = application;
            this.Driver = Driver;
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
            this.ID = clsLicenseData.AddNewLicense(this.Application.ID, this.Driver.ID, this.Notes, this.ExpireDate, this.PaidFees, this.CreatedByUser.ID);

            return this.ID != -1;
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.ID, this.Notes, this.ExpireDate, this.PaidFees);
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
            string Notes = string.Empty;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpireDate = DateTime.MinValue;
            short PaidFees = -1;
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsLicenseData.FindLicenseByID(ID, ref ApplicationID, ref DriverID, ref Notes, ref IssueDate, ref ExpireDate, ref PaidFees, ref IsActive, ref CreatedByUserID))
            {
                // Find the related objects
                clsApplication application = clsApplication.Find(ApplicationID);
                clsDriver driver = clsDriver.Find(DriverID);
                clsUser user = clsUser.Find(CreatedByUserID);

                return new clsLicense(ID, application, driver, Notes, IssueDate, ExpireDate, PaidFees, IsActive, user);
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

        public static DataTable GetLicensesList()
        {
            return clsLicenseData.GetAllLicenses();
        }


    }
}
