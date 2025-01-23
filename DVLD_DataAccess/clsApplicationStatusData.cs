using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsApplicationStatusData
    {

        public static bool FindApplicationStatusByID(int ID, ref string Title)
        {
            bool IsFound = false;
            string query = "SELECT * FROM ApplicationStatuses where ApplicationStatusID = @ID";
            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            Title = (string)reader["Title"];

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

        public static bool IsApplicationStatusExist(int ID)
        {
            return clsGenericData.IsRecordExist("ApplicationStatuses", "ApplicationStatusID", ID);
        }

        public static DataTable GetAllApplicationStatus()
        {
            string query = "SELECT * FROM ApplicationStatuses";
            return clsGenericData.GetDataTable(query);
        }

    }
}
