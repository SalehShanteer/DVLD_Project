using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDetainedLicenseData
    {
        public static bool FindDetainedLicenseByID(int ID, ref int LicenseID, ref DateTime DetainDate, ref string DetainReason
            , ref short FineFees, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleaseApplicationID
            , ref int ReleasedByUserID, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM DetainedLicenses WHERE ID = @ID";

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
                            LicenseID = Convert.ToInt32(reader["LicenseID"]);
                            DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                            DetainReason = reader["DetainReason"].ToString();
                            FineFees = Convert.ToInt16(reader["FineFees"]);
                            IsReleased = Convert.ToBoolean(reader["IsReleased"]);
                            ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue;
                            ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["ReleaseApplicationID"]) : -1;
                            ReleasedByUserID =  reader["ReleasedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["ReleasedByUserID"]) : -1;
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

        public static bool IsDetainedLicenseExist(int ID)
        {
            return clsGenericData.IsRecordExist("DetainedLicenses", "DetainedLicenseID", ID);
        }

        public static int AddNewDetainedLicense(int LicenseID, string DetainReason, short FineFees, int CreatedByUserID)
        {
            int ID = -1;

            string query = "INSERT INTO DetainedLicenses (LicenseID, DetainDate, DetainReason, FineFees, IsReleased, ReleaseDate, ReleaseApplicationID, ReleasedByUserID, CreatedByUserID) " +
                "VALUES (@LicenseID, GETDATE(), @DetainReason, @FineFees, 0, NULL, NULL, NULL, @CreatedByUserID); " +
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainReason", DetainReason);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
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

        public static bool UpdateDetainedLicense(int ID, string DetainReason, short FineFees, bool IsReleased, DateTime ReleaseDate, int ReleaseApplicationID, int ReleasedByUserID)
        {
            bool IsUpdated = false;

            string query = "UPDATE DetainedLicenses SET DetainReason = @DetainReason, FineFees = @FineFees, IsReleased = @IsReleased" +
                           ", ReleaseDate = @ReleaseDate, ReleaseApplicationID = @ReleaseApplicationID, ReleasedByUserID = @ReleasedByUserID " +
                           "WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@DetainReason", DetainReason);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@IsReleased", IsReleased);
                    command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                    command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                    command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);

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

        public static bool DeleteDetainedLicense(int ID)
        {
            return clsGenericData.DeleteRecord("DetainedLicenses", "ID", ID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            string query = "SELECT * FROM DetainedLicenses";

            return clsGenericData.GetDataTable(query);
        }


    }
}
