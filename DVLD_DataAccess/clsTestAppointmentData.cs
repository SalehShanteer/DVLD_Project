using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace DVLD_DataAccess
{
    public class clsTestAppointmentData
    {
        public static bool FindTestAppointmentByID(int ID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID
            , ref DateTime AppointmentDate, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool IsFound = false;
            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @ID";

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
                            TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                            LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                            AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            IsLocked = Convert.ToBoolean(reader["IsLocked"]);

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

        public static bool IsTestAppointmentExist(int ID)
        {
            return clsGenericData.IsRecordExist("TestAppointments", "TestAppointmentID", ID);
        }

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, int CreatedByUserID)
        {
            int ID = -1;
            string query = "INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, CreatedByUserID, IsLocked) " +
                           "VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @CreatedByUserID, 0); " +
                           "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
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

        public static bool UpdateTestAppointment(int ID, DateTime AppointmentDate, bool IsLocked)
        {
            bool IsUpdated = false;
            string query = "UPDATE TestAppointments SET TestTypeID = @TestTypeID, " +
                           "AppointmentDate = @AppointmentDate, IsLocked = @IsLocked " +
                           "WHERE TestAppointmentID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);

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

        public static bool DeleteTestAppointment(int ID)
        {
            return clsGenericData.DeleteRecord("TestAppointments", "TestAppointmentID", ID);
        }

        public static DataTable GetAllTestAppointments()
        {
            string query = "SELECT * FROM TestAppointments";
            return clsGenericData.GetAllRecords(query);
        }

    }
}
