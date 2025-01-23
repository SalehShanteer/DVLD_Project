using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsInternationalLicenseData
    {

        public static bool FindInternationalLicenseByID(int ID, ref int ApplicationID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate
            , ref DateTime ExpireDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @ID";

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
                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                            IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            ExpireDate = Convert.ToDateTime(reader["ExpireDate"]);
                            IsActive = Convert.ToBoolean(reader["IsActive"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                            IsFound = true;
                        }
                        reader.Close();
                    }
                    catch (Exception ex) { }
                }
            }
            return IsFound;
        }

        public static bool IsInternationalLicenseExist(int ID)
        {
            return clsGenericData.IsRecordExist("InternationalLicenses", "ID", ID);
        }

        public static int AddNewInternationalLicense(int IssuedUsingLocalLicenseID)
        {
            int ID = -1;

            string query = "DECLARE @NewInternationalLicense INT " +
                           "EXEC SP_AddNewInternationalLicenseTransaction " +
                           "@LocalLicenseID = @IssuedUsingLocalLicenseID, @InternationalLicenseID = @NewInternationalLicense OUTPUT " +
                           "SELECT @NewInternationalLicense";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameter to query
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

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
                }
            }
            return ID;
        }

        public static bool UpdateInternationalLicense(int ID, DateTime ExpireDate, bool IsActive)
        {
            bool IsUpdated = false;

            string query = "UPDATE InternationalLicenses SET ExpireDate = @ExpireDate, IsActive = @IsActive WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@ExpireDate", ExpireDate);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    try
                    {
                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();
                        IsUpdated = rowsAffected > 0;
                    }
                    catch (Exception ex) { }
                }
            }
            return IsUpdated;
        }

        public static bool DeleteInternationalLicense(int ID)
        {
            return clsGenericData.DeleteRecord("InternationalLicenses", "InternationalLicenseID", ID);
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            DataTable dtLicenses = new DataTable();

            string query = "EXEC SP_GetDriverInternationalLicenses @DriverID = @SelectedDriverID";

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

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dtLicenses = new DataTable();

            string query = "SELECT * FROM View_InternationalLicenses";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
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

        public static byte CanIssueInternationalLicense(int LocalLicenseID)
        {
            // 0 => cant issue  Reason => license is not active or is not class 3 license
            // 1 => can issue
            // 2 => cant issue  Reason => license has an active international license
            
            byte IssueStatus = 0;

            string query = "EXEC SP_CanIssueInternationalLicense @LicenseID = @LocalLicenseID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to query
                    command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IssueStatus = Convert.ToByte(result);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return IssueStatus;
        }

        public static int GetInternationalLicenseIDByLocalLicenseID(int LocalLicenseID)
        {
            int InternationalLicenseID = -1;

            string query = "SELECT dbo.GetInternationalLicenseIDByLocalLicenseID(@LocalLicenseID)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int internationalLicenseID))
                        {
                            InternationalLicenseID = internationalLicenseID;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return InternationalLicenseID;
        }

        public static int GetInternationalLicensesRecordsCountByDriverID(int DriverID)
        {
            int Count = 0;

            string query = "SELECT dbo.GetInternationalLicensesRecordsCountByDriverID(@DriverID)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
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

        public static int GetInternationalLicensesRecordsCount()
        {
            return clsGenericData.CountRecords("InternationalLicenses");
        }

    }
}
