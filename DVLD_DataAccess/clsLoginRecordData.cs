using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLoginRecordData
    {

        public static bool IsLoginRecordExist(int ID)
        {
            return clsGenericData.IsRecordExist("LoginRecords", "LoginRecordID", ID);
        }

        public static int AddNewLoginRecord(int UserID, DateTime LoginTime, bool LoginStatus, string FailureReason)
        {
            int ID = -1;
            string query = "INSERT INTO LoginRecords (UserID, LoginTime, LoginStatus, FailureReason)" +
                           " VALUES (@UserID, @LoginTime, @LoginStatus, @FailureReason); " +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@LoginTime", LoginTime);
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
            return clsGenericData.GetDataTable("LoginRecords");
        }

    }
}
