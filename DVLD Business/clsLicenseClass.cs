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

        private clsLicenseClass(int ID, string Title, byte MinimumAllowedAge, byte DefaultValidityLength, short Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.Fees = Fees;
        }

        public static clsLicenseClass Find(int ID)
        {
            //Prepare the data
            string Title = string.Empty;
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            short Fees = 0;

            if (clsLicenseClassData.FindLicenseClassByID(ID, ref Title, ref MinimumAllowedAge, ref DefaultValidityLength, ref Fees))
            {
                return new clsLicenseClass(ID, Title, Convert.ToByte(MinimumAllowedAge), DefaultValidityLength, Fees);
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

        public static bool CanPersonApplyForLicense(int PersonID, int LicenseClassID)
        {
            return clsLicenseClassData.CanPersonApplyForLicense(PersonID, LicenseClassID);
        }

    }
}
