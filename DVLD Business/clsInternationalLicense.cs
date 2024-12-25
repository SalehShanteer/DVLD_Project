using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;  

namespace DVLD_Business
{
    public class clsInternationalLicense
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;

        public int ID { get; set; }
        public clsApplication Application { get; set; }
        public clsLocalDrivingLicenseApplication IssuedUsingLocalLicense { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
        public clsUser CreatedByUser { get; set; }

        public clsInternationalLicense()
        {
            this.ID = -1;
            this.Application = null;
            this.IssuedUsingLocalLicense = null;
            this.IssueDate = DateTime.MinValue;
            this.ExpireDate = DateTime.MinValue;
            this.IsActive = false;
            this.CreatedByUser = null;

            _Mode = enMode.AddNew;
        }

        private clsInternationalLicense(int iD, clsApplication application, clsLocalDrivingLicenseApplication issuedUsingLocalLicense
            , DateTime issueDate, DateTime expireDate, bool isActive, clsUser createdByUser)
        {
            ID = iD;
            Application = application;
            IssuedUsingLocalLicense = issuedUsingLocalLicense;
            IssueDate = issueDate;
            ExpireDate = expireDate;
            IsActive = isActive;
            CreatedByUser = createdByUser;

            _Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            this.ID = clsInternationalLicenseData.AddNewInternationalLicense(this.Application.ID, this.IssuedUsingLocalLicense.ID
                , this.ExpireDate, this.CreatedByUser.ID);

            return this.ID != -1;
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(this.ID, this.ExpireDate, this.IsActive);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewInternationalLicense())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }

                case enMode.Update:
                    {
                        return _UpdateInternationalLicense();
                    }

                default:
                    return false;
            }
        }

        public static clsInternationalLicense Find(int ID)
        {
            // Prepare the variables
            int ApplicationID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpireDate = DateTime.MinValue;
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsInternationalLicenseData.FindInternationalLicenseByID(ID, ref ApplicationID, ref IssuedUsingLocalLicenseID,
                ref IssueDate, ref ExpireDate, ref IsActive, ref CreatedByUserID))
            {
                // Prepare the objects
                clsApplication application = clsApplication.Find(ApplicationID);
                clsLocalDrivingLicenseApplication issuedUsingLocalLicense = clsLocalDrivingLicenseApplication.Find(IssuedUsingLocalLicenseID);
                clsUser createdByUser = clsUser.Find(CreatedByUserID);

                return new clsInternationalLicense(ID, application, issuedUsingLocalLicense, IssueDate, ExpireDate, IsActive, createdByUser);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int ApplicationID)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExist(ApplicationID);
        }

        public static bool Delete(int ID)
        {
            return clsInternationalLicenseData.DeleteInternationalLicense(ID);
        }

        public static DataTable GetInternationalLicensesList()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }



    }
}
