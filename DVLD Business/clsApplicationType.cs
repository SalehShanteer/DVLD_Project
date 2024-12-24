using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplicationType
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public short Fees { get; set; }


        public clsApplicationType()
        {
            this.ID = -1;
            this.Title = string.Empty;
            this.Fees = -1;
        }

        private clsApplicationType(int iD, string title, short fees)
        {
            ID = iD;
            Title = title;
            Fees = fees;
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ID, this.Title, this.Fees);
        }

        public bool Save()
        {
            if (this.ID == -1)
            {
                return false;
            }
            return _UpdateApplicationType();
        }

        public static clsApplicationType Find(int ID)
        {
            string Title = string.Empty;
            short Fees = 0;
            if (clsApplicationTypeData.FindApplicationTypeByID(ID, ref Title, ref Fees))
            {
                return new clsApplicationType(ID, Title, Fees);
            }
            return null;
        }

        public static bool IsExists(int ID)
        {
            return clsApplicationTypeData.IsApplicationTypeExists(ID);
        }

        public static DataTable GetList()
        {
            return clsGenericData.GetAllRecords("SELECT * FROM ApplicationTypes");
        }


    }
}
