using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsUser
    {
        private enum enMode { AddNew = 0, Update = 1}
        
        private enMode _Mode;

        public int ID { get; set; }
        public clsPerson Person { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public clsRole Role { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.ID = -1;
            this.Person = null;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Role = null;
            this.DateCreated = DateTime.MinValue;
            this.IsActive = false;

            _Mode = enMode.AddNew;
        }

        private clsUser(int iD, clsPerson person, string username, string password, clsRole role, DateTime dateCreated, bool isActive)
        {
            ID = iD;
            Person = person;
            Username = username;
            Password = password;
            Role = role;
            DateCreated = dateCreated;
            IsActive = isActive;

            _Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            string EncryptedPassword = clsUtility.Encrypt(this.Password);

            this.ID = clsUserData.AddNewUser(this.Person.ID, this.Username, EncryptedPassword, this.Role.ID, this.IsActive);

            return this.ID != -1;
        }

        private bool _UpdateUser()
        {
            string EncryptedPassword = clsUtility.Encrypt(this.Password);

            return clsUserData.UpdateUser(this.ID, this.Person.ID, this.Username, EncryptedPassword, this.Role.ID, this.IsActive);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                case enMode.Update:
                    {
                        return _UpdateUser();
                    }

                default:
                    return false;
            }
        }

        public static clsUser Find(int ID)
        {
            // Prepare the object
            int PersonID = -1;
            string Username = string.Empty;
            string Password = string.Empty;
            int RoleID = -1;
            DateTime DateCreated = DateTime.MinValue;
            bool IsActive = false;

            if (clsUserData.FindUserByID(ID, ref PersonID, ref Username, ref Password, ref RoleID, ref DateCreated, ref IsActive))
            {
                clsPerson person = clsPerson.Find(PersonID);
                clsRole role = clsRole.Find(RoleID);

                string DecryptedPassword = clsUtility.Decrypt(Password);

                return new clsUser(ID, person, Username, DecryptedPassword, role, DateCreated, IsActive);
            }
            else
                return null;
        }

        public static clsUser Find(string Username)
        {
            //Prepare the object
            int ID = -1;
            int PersonID = -1;
            string Password = string.Empty;
            int RoleID = -1;
            DateTime DateCreated = DateTime.MinValue;
            bool IsActive = false;

            if (clsUserData.FindUserByUsername(ref ID, ref PersonID, Username, ref Password, ref RoleID, ref DateCreated, ref IsActive))
            {
                //Find person and role
                clsPerson person = clsPerson.Find(PersonID);
                clsRole role = clsRole.Find(RoleID);

                string DecryptedPassword = clsUtility.Decrypt(Password);

                return new clsUser(ID, person, Username, DecryptedPassword, role, DateCreated, IsActive);
            }
            else
                return null;
        }

        public static bool IsExist(int ID)
        {
            return clsUserData.IsUserExist(ID);
        }

        public static int GetUserID(string Username)
        {
            return clsUserData.GetUserID(Username);
        }

        public static bool Delete(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }

        public static DataTable GetUsersList()
        {
            return clsUserData.GetAllUsers();
        }

        public static int GetUsersCount()
        {
            return clsUserData.CountNumberOfUsers();
        }

        public static bool IsUsernameExist(string Username)
        {
            return clsUserData.IsUsernameExist(Username);
        }

    }
}
