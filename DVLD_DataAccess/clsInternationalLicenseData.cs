using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsInternationalLicenseData
    {

        public static bool FindInternationalLicenseByID(int ID, ref int ApplicationID, ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate
            , ref DateTime ExpireDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM InternationalLicenses WHERE ID = @ID";

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
                    finally { connection.Close(); }
                }
            }
            return IsFound;
        }

        public static bool IsInternationalLicenseExist(int ID)
        {
            return clsGenericData.IsRecordExist("InternationalLicenses", "ID", ID);
        }

        public static int AddNewInternationalLicense(int ApplicationID, int IssuedUsingLocalLicenseID, DateTime ExpireDate, int CreatedByUserID)
        {
            int ID = -1;

            // Set IsActive to true by default and IssueDate to current date
            string query = "INSERT INTO InternationalLicenses (ApplicationID, IssuedUsingLocalLicenseID, IssueDate, ExpireDate, IsActive, CreatedByUserID) " +
                           "VALUES (@ApplicationID, @IssuedUsingLocalLicenseID, GETDATE(), @ExpireDate, 1, @CreatedByUserID)" +
                           "; SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                    command.Parameters.AddWithValue("@ExpireDate", ExpireDate);
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
                    finally { connection.Close(); }
                }
            }
            return IsUpdated;
        }

        public static bool DeleteInternationalLicense(int ID)
        {
            return clsGenericData.DeleteRecord("InternationalLicenses", "InternationalLicenseID", ID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            string query = "SELECT * FROM InternationalLicenses";
            return clsGenericData.GetDataTable(query);
        }


    }
}
