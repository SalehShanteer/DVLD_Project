using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDriver
    {

        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;

        public int ID { get; set; }
        public clsPerson Person { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsUser CreatedByUser { get; set; }

        public clsDriver()
        {
            this.ID = -1;
            this.Person = null;
            this.CreatedDate = DateTime.MinValue;
            this.CreatedByUser = null;

            _Mode = enMode.AddNew;
        }

        private clsDriver(int iD, clsPerson person, DateTime createdDate, clsUser createdByUser)
        {
            ID = iD;
            Person = person;
            CreatedDate = createdDate;
            CreatedByUser = createdByUser;

            _Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            this.ID = clsDriverData.AddNewDriver(this.Person.ID, this.CreatedByUser.ID);

            return this.ID != -1;
        }

        public bool Save()
        {
            if (_AddNewDriver())
            {
                _Mode = enMode.Update;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static clsDriver Find(int ID)
        {
            // Prepare the variables
            int PersonID = -1;
            DateTime CreatedDate = DateTime.MinValue;
            int CreatedByUserID = -1;

            if (clsDriverData.FindDriverByID(ID, ref PersonID, ref CreatedDate, ref CreatedByUserID))
            {
                clsPerson person = clsPerson.Find(PersonID);
                clsUser user = clsUser.Find(CreatedByUserID);

                return new clsDriver(ID, person, CreatedDate, user);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int ID)
        {
            return clsDriverData.IsDriverExist(ID);
        }

        public static bool Delete(int ID)
        {
            return clsDriverData.DeleteDriver(ID);
        }

        public static DataTable GetDriversList()
        {
            return clsDriverData.GetAllDrivers();
        }



    }
}
