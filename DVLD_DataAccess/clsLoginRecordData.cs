using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLoginRecordData
    {

        public static bool IsLoginRecordExist(int ID)
        {
            return clsGenericData.IsRecordExist("LoginRecords", "LoginRecordID", ID);
        }

        public static int AddNewLoginRecord(int UserID, bool LoginStatus, string FailureReason) 
        {
            int ID = -1;
            string query = "INSERT INTO LoginRecords (UserID, LoginTime, LoginStatus, FailureReason)" +
                           " VALUES (@UserID, GETDATE(), @LoginStatus, @FailureReason); " +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@LoginStatus", LoginStatus);
                    command.Parameters.AddWithValue("@FailureReason", FailureReason != string.Empty ? FailureReason : (object)DBNull.Value);

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
    
        public static DataTable GetAllLoginRecords()
        {
            DataTable dt = new DataTable();

            string query = "EXEC SP_GetLoginRecordsList";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);// Fill dataTable with all rows
                        }

                        reader.Close();
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return dt;
        }

        public static int GetLoginRecordsCount()
        {
            return clsGenericData.CountRecords("LoginRecords");
        }

    }
}
