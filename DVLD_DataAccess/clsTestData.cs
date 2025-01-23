using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsTestData
    {
        public static bool  FindTestByID(int ID, ref int TestAppointmentID, ref bool Result, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Tests WHERE TestID = @ID";

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
                            TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                            Result = Convert.ToBoolean(reader["Result"]);
                            Notes = reader["Notes"].ToString();
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

        public static bool IsTestExist(int ID)
        {
           return clsGenericData.IsRecordExist("Tests", "TestID", ID);
        }

        public static int AddNewTest(int TestAppointmentID, bool Result, string Notes, int CreatedByUserID)
        {
            int ID = -1;

            string query = "INSERT INTO Tests (TestAppointmentID, Result, Notes, CreatedByUserID) " +
                "VALUES (@TestAppointmentID, @Result, @Notes, @CreatedByUserID); " +
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@Result", Result);
                    command.Parameters.AddWithValue("@Notes", Notes);
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

        public static bool DeleteTest(int ID)
        {
            return clsGenericData.DeleteRecord("Tests", "TestID", ID);
        }

        public static DataTable GetAllTests()
        {
            string query = "SELECT * FROM Tests";

            return clsGenericData.GetDataTable(query);
        }

        public static byte GetTestTrialsByTestTypeIDAndLocalDrivingLicenseApplication(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            byte Trials = 0;

            string query = "SELECT dbo.GetTestTrials(@TestTypeID, @LocalDrivingLicenseApplication)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters for query
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplication", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(),out byte trials))
                        {
                            Trials = trials;
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return Trials;
        }

        public static bool CheckIfRetakeTest(int TestAppointmentID, int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsRetakeTest = false;

            string query = "SELECT dbo.CheckIfRetakeTest(@TestAppointmentID, @LocalDrivingLicenseApplicationID, @TestTypeID)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to query
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsRetakeTest = Convert.ToBoolean(result);
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return IsRetakeTest;
        }
    }
}
