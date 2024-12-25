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
            ID = iD;
            TestAppointment = testAppointment;
            Result = result;
            Notes = notes;
            CreatedByUser = createdByUser;

            _Mode = enMode.Update;
        }


    }
}
