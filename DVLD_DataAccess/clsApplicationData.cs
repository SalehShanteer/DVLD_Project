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
            , ref short PaidFees, ref DateTime LastStatusDate, ref int StatusID, ref int CreatedByUserID)
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

        public static int AddNewApplication(int ApplicantPersonID, int ApplicationTypeID, int CreatedByUserID)
        {
            int ID = -1;

            string query = "DECLARE @PaidFees SMALLINT " +
                           "EXEC SP_GetApplicationTypeFees " +
                           "@ApplicationTypeID = @ApplicationTypeId, " +
                           "@Fees = @PaidFees OUTPUT " +
                           "INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, PaidFees, LastStatusDate, StatusID, CreatedByUserID) " +
                           "VALUES (@ApplicantPersonID, GETDATE(), @ApplicationTypeId, @PaidFees, GETDATE(), @StatusID, @CreatedByUserID); " +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@ApplicationTypeId", ApplicationTypeID);
                    command.Parameters.AddWithValue("@StatusID", 0);// 0 : (New)
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

        public static bool UpdateApplication(int ID, DateTime LastStatusDate, int StatusID)
        {
            bool IsUpdated = false;
            string query = "UPDATE Applications SET LastStatusDate = @LastStatusDate, StatusID = @StatusID WHERE ApplicationID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
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

        public static bool CancelApplication(int ID)
        {
            int RowsAffected = 0;

            string query = "EXEC SP_CancelApplication @ApplicationID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand (query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    
                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch(Exception ex) { }
                    finally { connection.Close(); }
                }
            }
             return RowsAffected > 0;
        }

        public static DataTable GetAllApplications()
        {
            string query = "SELECT * FROM Applications";

            return clsGenericData.GetDataTable(query);
        }


    }
}
