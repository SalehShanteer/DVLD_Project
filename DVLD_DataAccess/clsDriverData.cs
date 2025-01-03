using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDriverData
    {
        public static bool FindDriverByID(int ID, ref int PersonID, ref DateTime CreatedDate, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Drivers WHERE DriverID = @ID";

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
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

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

        public static bool IsDriverExist(int ID)
        {
            return clsGenericData.IsRecordExist("Drivers", "DriverID", ID);
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int ID = -1;

            string query = "INSERT INTO Drivers (PersonID, CreatedDate, CreatedByUserID) " +
                "VALUES (@PersonID, GETDATE(), @CreatedByUserID); " +
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        public static bool DeleteDriver(int ID)
        {
            return clsGenericData.DeleteRecord("Drivers", "DriverID", ID);
        }

        public static DataTable GetAllDrivers()
        {
            string query = "SELECT * FROM Drivers";

            return clsGenericData.GetDataTable(query);
        }

        public static int GetNumberOfDrivers()
        {
            return clsGenericData.CountRecords("Drivers");
        }


    }
}
