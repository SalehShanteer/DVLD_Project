using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypeData
    {

        public static bool FindTestTypeByID(int ID, ref string Title, ref string Description, ref short Fees)
        {
            bool IsFound = false;
            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @ID";

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
                            Description = reader["Description"].ToString();
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

        public static bool IsTestTypeExist(int ID)
        {
            return clsGenericData.IsRecordExist("TestTypes", "TestTypeID", ID);
        }

        public static bool UpdateTestType(int ID, string Title, string Description, short Fees)
        {
            bool IsUpdated = false;
            string query = "UPDATE TestTypes SET Title = @Title, Description = @Description, Fees = @Fees " +
                           "WHERE TestTypeID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Description", Description);
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
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return IsUpdated;
        }

        public static DataTable GetAllTestTypes()
        {
            string query = "SELECT * FROM TestTypes";

            return clsGenericData.GetAllRecords(query);
        }



    }
}
