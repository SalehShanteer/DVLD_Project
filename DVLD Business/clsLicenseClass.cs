using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLicenseClass
    {

        public int ID { get; }
        public string Title { get; }
        public byte MinimumAllowedAge { get; }
        public byte DefaultValidityLength { get; }
        public short Fees { get; }
        public string Description { get; }

        private clsLicenseClass(int ID, string Title, byte MinimumAllowedAge, byte DefaultValidityLength, short Fees, string Description)
        {
            this.ID = ID;
            this.Title = Title;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.Fees = Fees;
            this.Description = Description;
        }

        public static clsLicenseClass Find(int ID)
        {
            //Prepare the data
            string Title = string.Empty;
            string MinimumAllowedAge = string.Empty;
            byte DefaultValidityLength = 0;
            short Fees = 0;
            string Description = string.Empty;

            if (clsLicenseClassData.FindLicenseClassByID(ID, ref Title, ref MinimumAllowedAge, ref DefaultValidityLength, ref Fees, ref Description))
            {
                return new clsLicenseClass(ID, Title, Convert.ToByte(MinimumAllowedAge), DefaultValidityLength, Fees, Description);
            }
            else
                return null;
        }

        public static bool IsExist(int ID)
        {
            return clsLicenseClassData.IsLicenseClassExist(ID);
        }

        public static DataTable GetLicenseClassesList()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }


    }
}
