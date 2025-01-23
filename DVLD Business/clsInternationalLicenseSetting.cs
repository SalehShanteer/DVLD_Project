using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsInternationalLicenseSetting
    {
        public int ID { get; }
        public byte DefaultValidityLength { get; }

        public static byte GetValidityLength()
        {
            return clsInternationLicenseSettingData.GetInternationalLicenseValidityLength();
        }

    }
}
