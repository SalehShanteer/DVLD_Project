﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;

        public int ID { get; set; }
        public clsLicense License { get; set; }
        public DateTime DetainDate { get; set; }
        public string DetainReason { get; set; }
        public short FineFees { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public clsApplication ReleaseApplication { get; set; }
        public clsUser ReleasedByUser { get; set; }
        public clsUser CreatedByUser { get; set; }

        public clsDetainedLicense()
        {
            this.ID = -1;
            this.License = null;
            this.DetainDate = DateTime.MinValue;
            this.DetainReason = string.Empty;
            this.FineFees = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleaseApplication = null;
            this.ReleasedByUser = null;
            this.CreatedByUser = null;

            _Mode = enMode.AddNew;
        }

        private clsDetainedLicense(int iD, clsLicense license, DateTime detainDate, string detainReason, short fineFees, bool isReleased, DateTime releaseDate, clsApplication releaseApplication, clsUser releasedByUser, clsUser createdByUser)
        {
            this.ID = iD;
            this.License = license;
            this.DetainDate = detainDate;
            this.DetainReason = detainReason;
            this.FineFees = fineFees;
            this.IsReleased = isReleased;
            this.ReleaseDate = releaseDate;
            this.ReleaseApplication = releaseApplication;
            this.ReleasedByUser = releasedByUser;
            this.CreatedByUser = createdByUser;

            _Mode = enMode.Update;
        }

        private bool _AddNewDetainedLicense()
        {
            this.ID = clsDetainedLicenseData.AddNewDetainedLicense(this.License.ID, this.DetainReason, this.FineFees, this.CreatedByUser.ID);

            return this.ID != -1;
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(this.ID, this.DetainReason, this.FineFees, this.IsReleased, this.ReleaseDate, this.ReleaseApplication.ID, this.ReleasedByUser.ID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewDetainedLicense())
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
                        return _UpdateDetainedLicense();                  
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        public static clsDetainedLicense Find(int ID)
        {
            // Prepare the variables
            int LicenseID = -1;
            DateTime DetainDate = DateTime.MinValue;
            string DetainReason = string.Empty;
            short FineFees = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleaseApplicationID = -1;
            int ReleasedByUserID = -1;
            int CreatedByUserID = -1;

            if (clsDetainedLicenseData.FindDetainedLicenseByID(ID, ref LicenseID, ref DetainDate, ref DetainReason, ref FineFees
                , ref IsReleased, ref ReleaseDate, ref ReleaseApplicationID, ref ReleasedByUserID, ref CreatedByUserID))
            {
                // Prepare the objects
                clsLicense license = clsLicense.Find(LicenseID);
                clsApplication releaseApplication = clsApplication.Find(ReleaseApplicationID);
                clsUser releasedByUser = clsUser.Find(ReleasedByUserID);
                clsUser createdByUser = clsUser.Find(CreatedByUserID);

                return new clsDetainedLicense(ID, license, DetainDate, DetainReason, FineFees, IsReleased
                    , ReleaseDate, releaseApplication, releasedByUser, createdByUser);
            }
            else
            {
                return null;
            }

        }

        public static bool IsExist(int LicenseID)
        {
            return clsDetainedLicenseData.IsDetainedLicenseExist(LicenseID);
        }

        public static bool Delete(int ID)
        {
            return clsDetainedLicenseData.DeleteDetainedLicense(ID);
        }

        public static DataTable GetDetainedLicensesList()
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

    }
}