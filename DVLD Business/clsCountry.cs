using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;


namespace DVLD_Business
{
    public class clsCountry
    {
        public int ID { get; }
        public string Name { get; }

        private clsCountry(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public static clsCountry Find(int ID)
        {
            //Prepare the data
            string Name = string.Empty;

            if (clsCountryData.FindCountryByID(ID, ref Name))
            {
                return new clsCountry(ID, Name);
            }
            else
                return null;
        }

        public static bool IsExist(int ID)
        {
            return clsCountryData.IsCountryExist(ID);
        }

        public static clsCountry Find(string Name)
        {
            int ID = -1;
            if (clsCountryData.FindCountryByName(ref ID, Name))
            {
                return new clsCountry(ID, Name);
            }
            else
                return null;
        }

        public static DataTable GetCountriesList()
        {
            return clsCountryData.GetAllCountries();
        }

    }
}
