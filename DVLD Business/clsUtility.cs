using System;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using DVLD_DataAccess;
using Global_Variables_Data;
using System.Diagnostics;

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

        // Error provider
        public static string errorProviderMessage = "Please ensure all required fields are filled out correctly. Check the error beside the field with the issue.";

        // Permissions messages
        public static string errorPermissionMessage = "You do not have permission to perform this action.";
        public static string errorPermissionTitle = "Permission Denied";




        // Validation

        public static bool ValidatePassword(string Password)
        {
            if (Password.Length < 8)
            {
                return false;
            }
            bool HasUpper = false;
            bool HasLower = false;
            bool HasDigit = false;
            bool HasSpecial = false;

            for (int i = 0; i < Password.Length; i++)
            {
                if (char.IsUpper(Password[i]))
                {
                    HasUpper = true;
                }
                if (char.IsLower(Password[i]))
                {
                    HasLower = true;
                }
                if (char.IsDigit(Password[i]))
                {
                    HasDigit = true;
                }
                if (char.IsSymbol(Password[i]) || char.IsPunctuation(Password[i]))
                {
                    HasSpecial = true;
                }
            }
            return HasUpper && HasLower && HasDigit && HasSpecial;
        }


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


        // Registry
        public static void WriteToRegistry(string Key, string Value)
        {
            try
            {
                // Write the value to the registry
                Registry.SetValue(clsSettingsData.KeyPath, Key, Value);
            }
            catch (Exception ex)
            {
                // Log the error in the event log
                EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
            }
        }

        public static string ReadFromRegistry(string Key)
        {
            if (_CheckIfRegistryKeyExists(Key))
            {
                try
                {
                    // Read the value from the registry
                    object value = Registry.GetValue(clsSettingsData.KeyPath, Key, null);

                    return value?.ToString() ?? string.Empty;
                }
                catch (Exception ex)
                {
                    // Log the error in the event log
                    EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        private static bool _CheckIfRegistryKeyExists(string Key)
        {
            try
            {
                // Check if the key exists
                return Registry.GetValue(clsSettingsData.KeyPath, Key, null) != null;              
            }
            catch (Exception ex)
            {
                // Log the error in the event log
                EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
                return false;
            }
        }

        // Validation

        public static bool ValidateEmail(string Email)
        {
            int Last = Email.Length - 5;

            if (!Email.EndsWith(".com"))
            {
                return false;
            }
            if (Email[Last] == '@' || Email[0] == '@')
            {
                return false;
            }

            bool HasAt = false;

            for (int i = 0; i <= Last; i++)
            {
               
                if (Email[i] == '@')
                {
                    if (HasAt == true)
                    {
                        return false;
                    }
                    HasAt = true;
                }

                if (Email[i] == ' ' || Email[i] == '.' || Email[i] == ',' || Email[i] == ';')
                {
                    return false;
                }
            }

            return true;
        }


    }
}
