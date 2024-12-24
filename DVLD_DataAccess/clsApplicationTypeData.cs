using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationTypeData
    {

        public static bool FindApplicationTypeByID(int ID, ref string Title, ref short Fees)
        {
            bool IsFound = false;

            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ID";

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
                            Title = reader["Title"].ToString();
                            Fees = Convert.ToInt16(reader["Fees"]);

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

        public static bool IsApplicationTypeExists(int ID)
        {
            return clsGenericData.IsRecordExist("ApplicationTypes", "ApplicationTypeID", ID);
        }

        public static bool UpdateApplicationType(int ID, string Title, short Fees)
        {
            bool IsUpdated = false;

            string query = "UPDATE ApplicationTypes SET Title = @Title, Fees = @Fees WHERE ApplicationTypeID = @ID";
            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Fees", Fees);
                    try
                    {
                        connection.Open();
                        int RowsAffected = command.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            IsUpdated = true;
                        }
                    }
                    catch (Exception ex) {}
                    finally { connection.Close(); }
                }
            }
            return IsUpdated;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsGenericData.GetAllRecords("SELECT * FROM ApplicationTypes");
        }

    }
}
