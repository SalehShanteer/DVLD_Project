using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLicenseData
    {

        public static bool FindLicenseByID(int ID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref string Notes
            , ref DateTime IssueDate, ref DateTime ExpireDate, ref short PaidFees, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Licenses WHERE LicenseID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameter
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ApplicationID = (int)reader["ApplicationID"];
                            DriverID = (int)reader["DriverID"];
                            LicenseClassID = (int)reader["LicenseClassID"];
                            Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : string.Empty;
                            IssueDate = (DateTime)reader["IssueDate"];
                            ExpireDate = (DateTime)reader["ExpireDate"];
                            PaidFees = (short)reader["PaidFees"];
                            IsActive = (bool)reader["IsActive"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static bool FindLicenseByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID, ref int ID
            , ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref string Notes, ref DateTime IssueDate
            , ref DateTime ExpireDate, ref short PaidFees, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "EXEC SP_GetLicenseByLocalDrivingLicenseApplicationID " +
                           "@LocalDrivingLicenseApplicationID = @LDLAppID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameter to query
                    command.Parameters.AddWithValue("@LDLAppID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ID = (int)reader["LicenseID"];
                            ApplicationID = (int)reader["ApplicationID"];
                            DriverID = (int)reader["DriverID"];
                            LicenseClassID = (int)reader["LicenseClassID"];
                            Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : string.Empty;
                            IssueDate = (DateTime)reader["IssueDate"];
                            ExpireDate = (DateTime)reader["ExpireDate"];
                            PaidFees = (short)reader["PaidFees"];
                            IsActive = (bool)reader["IsActive"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];

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

        public static bool IsLicenseExist(int ID)
        {
            return clsGenericData.IsRecordExist("Licenses", "LicenseID", ID); 
        }

        public static bool IsLicenseExistByApplicationID(int ApplicationID)
        {
            return clsGenericData.IsRecordExist("Licenses", "ApplicationID", ApplicationID);
        }

        public static bool IsLicenseActive(int LicenseID)
        {
            bool IsActive = false;

            string query = "SELECT dbo.IsLocalLicenseActive(@LicenseID)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameter
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && bool.TryParse(result.ToString(), out bool isActive))
                        {
                            IsActive = isActive;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return IsActive;
        }

        public static int AddNewLicense(int ApplicationID, int DriverID, string Notes, int LicenseClassID)
        {
            int ID = -1;

            string query = "EXEC SP_AddNewLincense @ApplicationID = @AppID, @DriverID = @DrvID, @Notes = @Note, @LicenseClassID = @LicClassID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@AppID", ApplicationID);
                    command.Parameters.AddWithValue("@DrvID", DriverID);
                    command.Parameters.AddWithValue("@Note", Notes != string.Empty ? Notes : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LicClassID", LicenseClassID);

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

        public static bool UpdateLicense(int ID, string Notes, DateTime ExpireDate)
        {
            bool IsUpdated = false;

            string query = "UPDATE Licenses SET Notes = @Notes, ExpireDate = @ExpireDate " +
                           "WHERE LicenseID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Notes", Notes != string.Empty ? Notes : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ExpireDate", ExpireDate);

                    try
                    {
                        connection.Open();
                        int RowsAffected = command.ExecuteNonQuery();

                        if (RowsAffected > 0)
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

        public static bool DeleteLicense(int ID)
        {
            return clsGenericData.DeleteRecord("Licenses", "LicenseID", ID);
        }

        public static DataTable GetDriverLocalLicenses(int DriverID)
        {
            DataTable dtLicenses = new DataTable();

            string query = "EXEC SP_GetDriverLocalLicenses @DriverID = @SelectedDriverID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@SelectedDriverID", DriverID);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtLicenses.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return dtLicenses;
        }

        public static int GetLicensesRecordsCountByDriverID(int DriverID)
        {
            int Count = 0; 

            string query = "SELECT dbo.GetLocalLicensesRecordsCountByDriverID(@DriverID)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int count))
                        {
                            Count = count;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return Count;
        }

        public static bool RefreshAllLicensesToCheckActivation()
        {
            int RowsAffected = 0;

            string query = "EXEC SP_RefreshAllLicensesToCheckActivation";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }
            return RowsAffected > 0;
        }

        public static byte CheckIfDriverLicenseRenewable(int LicenseID)
        {
            byte RenewStatus = 0;

            string query = "EXEC SP_CheckIfDriverLicenseRenewable @LicenseID = @SelectedLicenseID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@SelectedLicenseID", LicenseID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(), out byte status))
                        {
                            RenewStatus = status;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return RenewStatus;
        }

        public static int GetLicenseIDByLocalLicenseApplicationID(int LocalLicenseApplicationID)
        {
            int LicenseID = -1;

            string query = "SELECT dbo.GetLicenseIDByLocalLicenseApplicationID(@LocalLicenseApplicationID)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            LicenseID = ID;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return LicenseID;
        }

        public static int GetActiveClass3LicenseIDByDriverID(int DriverID)
        {
            int LicenseID = -1;

            string query = "SELECT dbo.GetActiveClass3LocalLicenseByDriverID(@DriverID)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ID))
                        {
                            LicenseID = ID;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return LicenseID;
        }

    }
}
