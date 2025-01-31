﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {

        public static bool FindLocalDrivingLicenseApplicationByID(int ID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool IsFound = false;

            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @ID";

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
                            LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);

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

        public static bool IsLocalDrivingLicenseApplicationExists(int ID)
        {
            return clsGenericData.IsRecordExist("LocalDrivingLicenseApplications", "LocalDrivingLicenseApplicationID", ID);
        }

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int ID = -1;

            string query = "INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) " +
                "VALUES (@ApplicationID, @LicenseClassID); " +
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool UpdateLocalDrivingLicenseApplication(int ID, int ApplicationID, int LicenseClassID)
        {
            bool IsUpdated = false;

            string query = "UPDATE LocalDrivingLicenseApplications SET ApplicationID = @ApplicationID, LicenseClassID = @LicenseClassID " +
                           "WHERE LocalDrivingLicenseApplicationID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool DeleteLocalDrivingLicenseApplication(int ID)
        {
            int RowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteLocalDrivingLicenseApplication", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);
                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }
            return RowsAffected > 1;// Two records should affected 1- application 2- L.D.L.App
        }

        public static bool CancelLocalDrivingLicenseApplication(int ID)
        {
            int RowsAffected = 0;

            string query = "EXEC SP_CancelApplicationByLocalDrivingLicenseApplicationID " +
                           "@LocalDrivingLicenseApplicationID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return RowsAffected > 0;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            string query = "SELECT * FROM VIEW_LocalDrivingLicenseApplicationsList";
            return clsGenericData.GetDataTable(query);
        }

        public static bool CheckIfPersonAppliedForLicenseClass(int ApplicantPersonID, int SelectedLicenseClassID)
        {
            bool IsFound = false;

            string query = "DECLARE @Result BIT " +
                           "EXEC @Result = SP_CheckIfPersonAppliedForLicenseClass @PersonID = @ApplicantPersonID, @LicenseClassID = @SelectedLicenseClassID " +
                           "SELECT @Result AS Result";
            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add the parameters
                    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                    command.Parameters.AddWithValue("@SelectedLicenseClassID", SelectedLicenseClassID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsFound = Convert.ToBoolean(result);
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return IsFound;
        }

        public static int CountNumberOfLocalDrivingLicenseApplications()
        {
            return clsGenericData.CountRecords("LocalDrivingLicenseApplications");
        }

        public static byte GetLocalDrivingLicenseApplicationPassedTests(int ID)
        {
            byte PassedTests = 255;

            string query = "SELECT dbo.GetLocalDrivingLicenseApplicationPassedTests(@ID)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to query
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(), out byte passedTests))
                        {
                            PassedTests = passedTests;
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return PassedTests;
        }

    }
}
