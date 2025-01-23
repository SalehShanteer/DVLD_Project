using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplication
    {
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;

        public int ID { get; set; }
        public clsPerson ApplicantPerson { get; set; }
        public DateTime ApplicationDate { get; set; }
        public clsApplicationType ApplicationType { get; set; }
        public short PaidFees { get; set; }
        public DateTime LastStatusDate { get; set; }
        public clsApplicationStatus Status { get; set; }
        public clsUser CreatedByUser { get; set; }

        public clsApplication()
        {
            this.ID = -1;
            this.ApplicantPerson = null;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationType = null;
            this.PaidFees = -1;
            this.LastStatusDate = DateTime.MinValue;
            this.Status = null;
            this.CreatedByUser = null;

            _Mode = enMode.AddNew;
        }

        public clsApplication(int iD, clsPerson applicantPerson, DateTime applicationDate, clsApplicationType applicationType, short paidFees, DateTime lastStatusDate, clsApplicationStatus status, clsUser createdByUser)
        {
            this.ID = iD;
            this.ApplicantPerson = applicantPerson;
            this.ApplicationDate = applicationDate;
            this.ApplicationType = applicationType;
            this.PaidFees = paidFees;
            this.LastStatusDate = lastStatusDate;
            this.Status = status;
            this.CreatedByUser = createdByUser;

            _Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            this.ID = clsApplicationData.AddNewApplication(this.ApplicantPerson.ID, this.ApplicationType.ID);

            return this.ID != -1;
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ID, this.LastStatusDate, this.Status.ID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewApplication())
                        {
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateApplication();
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        public static clsApplication Find(int ID)
        {
            // Prepare the object
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.MinValue;
            int ApplicationTypeID = -1;
            short PaidFees = -1;
            DateTime LastStatusDate = DateTime.MinValue;
            int StatusID = -1;
            int CreatedByUserID = -1;

            if (clsApplicationData.FindApplicationByID(ID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref PaidFees
                , ref LastStatusDate, ref StatusID, ref CreatedByUserID))
            {
                // Find the related objects
                clsPerson Person = clsPerson.Find(ApplicantPersonID);
                clsApplicationType ApplicationType = clsApplicationType.Find(ApplicationTypeID);
                clsApplicationStatus Status = clsApplicationStatus.Find(StatusID);
                clsUser CreatedByUser = clsUser.Find(CreatedByUserID);

                return new clsApplication(ID, Person, ApplicationDate, ApplicationType
                    , PaidFees, LastStatusDate, Status, CreatedByUser);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int ID)
        {
            return clsApplicationData.IsApplicationExists(ID);
        }

        public static bool Delete(int ID)
        {
            return clsApplicationData.DeleteApplication(ID);
        }

        public static bool Cancel(int ID)
        {
            return clsApplicationData.CancelApplication(ID);
        }

       
        public static DataTable GetApplicationsList()
        {
            return clsApplicationData.GetAllApplications();
        }


    }
}
