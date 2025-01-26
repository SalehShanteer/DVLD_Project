using System;
using System.Data;
using System.Data.SqlClient;


namespace DVLD_DataAccess
{
    public class clsUserData
    {

        public static bool FindUserByID(int ID, ref int PersonID, ref string Username, ref string Password
            , ref int RoleID, ref DateTime DateCreated, ref bool IsActive)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Users WHERE UserID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            Username = reader["Username"].ToString();
                            Password = reader["Password"].ToString();
                            RoleID = Convert.ToInt32(reader["RoleID"]);
                            DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);

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

        public static bool FindUserByUsername(ref int ID, ref int PersonID, string Username, ref string Password
            , ref int RoleID, ref DateTime DateCreated, ref bool IsActive)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Users WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@Username", Username);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ID = Convert.ToInt32(reader["UserID"]);
                            PersonID = Convert.ToInt32(reader["PersonID"]);
                            Password = reader["Password"].ToString();
                            RoleID = Convert.ToInt32(reader["RoleID"]);
                            DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);

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

        public static bool IsUserExist(int ID)
        {
            return clsGenericData.IsRecordExist("Users", "UserID", ID);
        }

        public static int GetUserID(string Username)
        {
            int ID = -1;

            string query = "SELECT UserID FROM Users WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@Username", Username);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int id))
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

        public static int AddNewUser(int PersonID, string Username, string Password, int RoleID, bool IsActive)
        {
            int ID = -1;

            string query = "INSERT INTO Users (PersonID, Username, Password, RoleID, DateCreated, IsActive) " +
                           "VALUES (@PersonID, @Username, @Password, @RoleID, GETDATE(), @IsActive); " +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        
                        if (result != null && int.TryParse(result.ToString(), out int NewID))
                        {
                            ID = NewID;
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return ID;
        }

        public static bool UpdateUser(int ID, int PersonID, string Username, string Password, int RoleID, bool IsActive)
        {
            bool IsUpdated = false;

            string query = "UPDATE Users SET PersonID = @PersonID, Username = @Username, Password = @Password, RoleID = @RoleID, IsActive = @IsActive " +
                           "WHERE UserID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool DeleteUser(int ID)
        {
            return clsGenericData.DeleteRecord("Users", "UserID", ID);
        }

        public static DataTable GetAllUsers()
        {
            return clsGenericData.GetDataTable("SELECT * FROM VIEW_UsersList");
        }

        public static int CountNumberOfUsers()
        {
            return clsGenericData.CountRecords("Users");
        }

        public static bool IsUsernameExist(string Username)
        {
            return clsGenericData.IsRecordExist("Users", "Username", Username);
        }

    }
}
