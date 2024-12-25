using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseData
    {

        public static bool FindLicenseByID(int ID, ref int ApplicationID, ref int DriverID, ref string Notes, ref DateTime IssueDate
            , ref DateTime ExpireDate, ref short PaidFees, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Licenses WHERE LicesneID = @ID";

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

        public static int AddNewLicense(int ApplicationID, int DriverID, string Notes, DateTime ExpireDate, short PaidFees, int CreatedByUserID)
        {
            int ID = -1;

            string query = "INSERT INTO Licenses (ApplicationID, DriverID, Notes, IssueDate, ExpireDate, PaidFees, IsActive, CreatedByUserID) " +
                           "VALUES (@ApplicationID, @DriverID, @Notes, GETDATE(), @ExpireDate, @PaidFees, 1, @CreatedByUserID); " +
                           "SELECT SCOPE_IDENTITY()";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@Notes", Notes != string.Empty ? Notes : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ExpireDate", ExpireDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
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

        public static bool UpdateLicense(int ID, string Notes, DateTime ExpireDate, short PaidFees)
        {
            bool IsUpdated = false;

            string query = "UPDATE Licenses SET Notes = @Notes, ExpireDate = @ExpireDate, PaidFees = @PaidFees " +
                           "WHERE LicenseID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Notes", Notes != string.Empty ? Notes : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ExpireDate", ExpireDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);

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

        public static DataTable GetAllLicenses()
        {
            string query = "SELECT * FROM Licenses";
            return clsGenericData.GetDataTable(query);
        }

    }
}
