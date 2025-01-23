using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsUtility
    {

        // Encryption and decryption
        private static readonly string key = clsKeySettingsData.GetDecryptionKey(1);// Essential key

        private static readonly string iv = clsKeySettingsData.GetDecryptionKey(2);// IV Key 

        public static string Encrypt(string Text)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(Text);
                        }
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string EncryptedText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(EncryptedText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }

            }
        }


        // Message boxes messages
        
        // Form
        public static string errorOpenFormMessag(string FormTitle)
        {
            return $"Error: Failed to {FormTitle} Form.";
        }

        // Saving
        public static string errorSaveMessage = "An error occurred while saving the data.";
       
        public static string errorSaveTitle = "Save error";

        public static string saveMessage(string entity)
        {
            return $"The {entity} has been saved successfully.";
        }
        public static string saveTitle(string entity)
        {
            return $"{entity} saved";
        }

        public static string askForSaveMessage(string entity)
        {
            return $"Are you sure you want to save {entity}?";
        }

        //Deleting

        public static string errorDeleteMessage = "An error occurred while deleting the data.";

        public static string errorDeleteTitle = "Delete error";

        public static string deleteMessage(string entity, int ID)
        {
            return $"The {entity} with ID = ({ID}) has been Deleted successfully.";
        }

        public static string deleteTitle(string entity)
        {
            return $"{entity} Deleted";
        }

        public static string askForDeleteMessage(string entity, int ID)
        {
            return $"Are you sure you want to delete {entity} with ID = ({ID})?";
        }

        //Login

        public static string errorLoginWrongPassword = "Inserted password is wrong";

        public static string errorLoginNotActiveUser = "User account is not active";

        public static string errorLoginUsernameNotFound = "Username not found!";

        public static string errorLoginRegisterCurrentUser = "Error: Failed to register current user";


        // License
        
        public static string GetLicenseIssueReason(byte ApplicationTypeID)
        {
            switch (ApplicationTypeID)
            {

                case 1: { return "First Time"; }
                case 2: { return "Renew"; }
                case 3: { return "Replacement For Lost"; }
                case 4: { return "Replacement For Damaged"; }
                case 5: { return "Release Detained"; }
                case 6: { return "International License"; }
                default: { return "No Result"; }
            }
        }

        //public static string GetLicenseRenewStatus(byte Status)
        //{
        //    switch (Status)
        //    {

        //        case 1: { return "Not Latest Driver license"; }

        //        case 2: { return "The license is already active"; }

        //        case 3: { return "The license need to renew"; }

        //        default: { return "No Result"; }
        //    }
        //}
    }
}
