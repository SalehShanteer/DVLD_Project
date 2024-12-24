using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationData
    {

        public static bool FindApplicationByID(int ID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID
            , ref int LicenseClassID, ref short PaidFees, ref DateTime LastStatusDate, ref int StatusID, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Applications WHERE ApplicationID = @ID";

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
                            ApplicantPersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                            ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                            ApplicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                            LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                            PaidFees = Convert.ToInt16(reader["PaidFees"]);
                            LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                            StatusID = Convert.ToInt32(reader["StatusID"]);
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

        public static bool IsApplicationExists(int ID)
        {
            return clsGenericData.IsRecordExist("Applications", "ApplicationID", ID);
        }

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID
            , int LicenseClassID, short PaidFees, DateTime LastStatusDate, int StatusID, int CreatedByUserID)
        {
            int ID = -1;

            string query = "INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, LicenseClassID, PaidFees, LastStatusDate, StatusID, CreatedByUserID) " +
                "VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @LicenseClassID, @PaidFees, @LastStatusDate, @StatusID, @CreatedByUserID); " +
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@StatusID", StatusID);
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

        public static bool UpdateApplication(int ID, short PaidFees, DateTime LastStatusDate, int StatusID)
        {
            bool IsUpdated = false;
            string query = "UPDATE Applications SET PaidFees = @PaidFees, LastStatusDate = @LastStatusDate, StatusID = @StatusID WHERE ApplicationID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                    command.Parameters.AddWithValue("@StatusID", StatusID);

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

        public static bool DeleteApplication(int ID)
        {
            return clsGenericData.DeleteRecord("Applications", "ApplicationID", ID);
        }

        public static DataTable GetAllApplications()
        {
            string query = "SELECT * FROM Applications";

            return clsGenericData.GetAllRecords(query);
        }


    }
}
