using System;
using System.Data;
using System.Data.SqlClient;

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

        public static bool FindDriverByPersonID(ref int ID, int PersonID, ref DateTime CreatedDate, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ID = Convert.ToInt32(reader["DriverID"]);
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

        public static bool IsDriverExistByPersonID(int PersonID)
        {
            return clsGenericData.IsRecordExist("Drivers", "PersonID", PersonID);
        }

        public static int AddNewDriver(int PersonID)
        {
            int ID = -1;

            string query = "EXEC SP_AddNewDriver @PersonID = @Person_ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameter to query
                    command.Parameters.AddWithValue("@Person_ID", PersonID);

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
            string query = "SELECT * FROM View_DriversList";

            return clsGenericData.GetDataTable(query);
        }

        public static int GetNumberOfDrivers()
        {
            return clsGenericData.CountRecords("Drivers");
        }

        public static int GetDriverIDByNationalNumber(string NationalNumber)
        {
            int ID = -1;

            string query = "SELECT dbo.GetDriverIDByNationalNumber(@NationalNumber)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int iD))
                        {
                            ID = iD;
                        }
                    }
                    catch(Exception ex) { } 
                }
            }
            return ID;
        }

        public static bool IsDriverHasActiveInternationalLicense(int DriverID)
        {
            bool HasLicense = false;

            string query = "SELECT dbo.IsDriverHasActiveInternationalLicense(@DriverID)";

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

                        if (result != null)
                        {
                            HasLicense = Convert.ToBoolean(result);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return HasLicense;
        }

    }
}
