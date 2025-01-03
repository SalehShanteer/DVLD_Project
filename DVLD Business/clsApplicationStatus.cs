using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplicationStatus
    {

        public int ID { get; }// -1 : Cancelled | 0 : New | 1 : Complete
        public string Title { get; }

        private clsApplicationStatus(int ID, string Title)
        {
            this.ID = ID;
            this.Title = Title;
        }

        public static clsApplicationStatus Find(int ID)
        {
            //Prepare the data
            string Title = string.Empty;

            if (clsApplicationStatusData.FindApplicationStatusByID(ID, ref Title))
            {
                return new clsApplicationStatus(ID, Title);
            }
            else
                return null;
        }

        public static bool IsExist(int ID)
        {
            return clsApplicationStatusData.IsApplicationStatusExist(ID);
        }

        public static DataTable GetApplicationStatusList()
        {
            return clsApplicationStatusData.GetAllApplicationStatus();
        }

    }
}
