using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsUserSetting
    {
        public string Title { get; set; }
        public clsUser User { get; set; }
        public int Permissions { get; set; }

        private clsUserSetting(string Title, clsUser User, int Permissions) 
        {
            this.Title = Title;
            this.User = User;
            this.Permissions = Permissions;
        }

        private bool _UpdateUserSetting()
        {
            if (this.User == null)
            {
                return clsUserSettingData.UpdateUserSetting(this.Title, -1, 0);
            }
            return clsUserSettingData.UpdateUserSetting(this.Title, this.User.ID, this.Permissions);
        }   

        public bool Save()
        {
            return _UpdateUserSetting();
        }

        public static clsUserSetting Find(string Title)
        {
            int UserID = -1;
            int Permissions = 0;
            clsUserSetting UserSetting = null;

            if (clsUserSettingData.FindUserSettingByTitle(Title, ref UserID, ref Permissions))
            {
                clsUser User = clsUser.Find(UserID);
                UserSetting = new clsUserSetting(Title, User, Permissions);
            }
            return UserSetting;
        }

        public static int GetCurrentUserID()
        {
            return clsUserSettingData.GetCurrentUserID();
        }

        public static int GetCurrentUserPermissions()
        {
            return clsUserSettingData.GetCurrentUserPermissions();
        }

        public static string GetCurrentUserFullName()
        {
            return clsUserSettingData.GetCurrentUserFullName();
        }
    }
}
