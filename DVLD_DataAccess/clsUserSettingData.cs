using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsUserSettingData
    {
        public static bool FindUserSettingByTitle(string Title, ref int UserID, ref int Permissions)
        {
            bool IsFound = false;

            string query = "SELECT * FROM UserSettings WHERE Title = @Title";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Title", Title);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            UserID = reader["UserID"] != DBNull.Value ? (int)reader["UserID"] : -1;
                            Permissions = reader["Permissions"] != DBNull.Value ? (int)reader["Permissions"] : 0;

                            IsFound = true;
                        }
                        reader.Close();

                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return IsFound;
        }

        public static bool UpdateUserSetting(string Title, int UserID, int Permissions)
        {
            bool IsUpdated = false;
            string query = "UPDATE UserSettings SET UserID = @UserID, Permissions = @Permissions WHERE Title = @Title";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@UserID", UserID != -1 ? UserID : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Permissions", Permissions);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            IsUpdated = true;
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return IsUpdated;
        }

        public static int GetCurrentUserPermissions()
        {
            int Permissions = 0;
            string query = "SELECT Permissions FROM UserSettings WHERE Title = 'Current User'";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int permissions))
                        {
                            Permissions = permissions;
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return Permissions;
        }

        public static int GetCurrentUserID()
        {
            int ID = -1;
            string query = "SELECT UserID FROM UserSettings WHERE Title = 'Current User'";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int id))
                        {
                            ID = id;
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return ID;
        }

    }
}
