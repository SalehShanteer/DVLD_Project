using System;
using System.Data.SqlClient;

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

        public static string GetCurrentUserFullName()
        {
            string FullName = string.Empty;

            string query = "DECLARE @Name NVARCHAR(101) " +
                           "EXEC SP_GetCurrentUserFullName @FullName = @Name OUTPUT " +
                           "SELECT @Name AS FullName";
                
            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null)
                        {
                            FullName = Result.ToString();
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return FullName;
        }

        public static string GetCurrentUserUsername()
        {
            string Username = string.Empty;

            string query = "SELECT dbo.GetCurrentUserUsername()";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null)
                        {
                            Username = Result.ToString();
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return Username;
        }

    }
}
