using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTestType
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Fees { get; set; }


        public clsTestType()
        {
            this.ID = -1;
            this.Title = string.Empty;
            this.Description = string.Empty;
            this.Fees = -1;
        }

        private clsTestType(int iD, string title, string description, short fees)
        {
            ID = iD;
            Title = title;
            Description = description;
            Fees = fees;
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType(this.ID, this.Title, this.Description, this.Fees);
        }

        public bool Save()
        {
            return _UpdateTestType();
        }

        public static clsTestType Find(int ID)
        {
            string Title = string.Empty;
            string Description = string.Empty;
            short Fees = -1;

            if (clsTestTypeData.FindTestTypeByID(ID, ref Title, ref Description, ref Fees))
            {
                return new clsTestType(ID, Title, Description, Fees);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int ID)
        {
            return clsTestTypeData.IsTestTypeExist(ID);
        }

        public static DataTable GetTestTypesList()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        public static int GetTestTypesCount()
        {
            return clsTestTypeData.CountNumberOfTestTypes();
        }

        public static short GetFees(int ID)
        {
            return clsTestTypeData.GetTestTypeFees(ID);
        }

    }
}
