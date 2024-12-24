using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public  class clsRole
    {
        
        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode = enMode.AddNew;

        public int ID { get; set; }
        public string Title { get; set; }
        public int Permissions { get; set; }
        public string Description { get; set; }

        public clsRole() 
        {
            this.ID = -1;
            this.Title = string.Empty;
            this.Permissions = 0;
            this.Description = string.Empty;  
            
            _Mode = enMode.AddNew;
        }

        private clsRole(int ID, string Title, int Permissions, string Description)
        {
            this.ID = ID;
            this.Title = Title;
            this.Permissions = Permissions;
            this.Description = Description;

            _Mode = enMode.Update;
        }

        public static clsRole Find(int ID)
        {
            //Prepare the data
            string Title = string.Empty;
            int Permissions = 0;
            string Description = string.Empty;

            if (clsRoleData.FindRoleByID(ID, ref Title, ref Permissions, ref Description))
            {
                return new clsRole(ID, Title, Permissions, Description);
            }
            else
                return null;
        }

        public static bool IsExist(int ID)
        {
            return clsRoleData.IsRoleExist(ID);
        }

        public static DataTable GetRolesList()
        {
            return clsRoleData.GetAllRoles();
        }

    }
}
