using Global_Variables_Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsLicenseClassData
    {

        public static bool FindLicenseClassByID(int ID, ref string Title, ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref short Fees)
        {
            bool IsFound = false;

            string query = "SELECT * FROM LicenseClasses where LicenseClassID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@ID", ID);
                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            Title = (string)reader["Title"];
                            MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                            DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                            Fees = (short)reader["Fees"];

                            IsFound = true;
                        }
                        reader.Close();
                    }
                    catch (Exception ex) 
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsFound;

        }

        public static bool IsLicenseClassExist(int ID)
        {
            return clsGenericData.IsRecordExist("LicenseClasses", "LicenseClassID", ID);
        }

        public static DataTable GetAllLicenseClasses()
        {
            string query = "SELECT * FROM LicenseClasses";
            return clsGenericData.GetDataTable(query);
        }

        public static bool CanPersonApplyForLicense(int PersonID, int LicenseClassID)
        {
            bool CanApply = false;

            string query = "SELECT dbo.CanPersonApplyForLicense(@PersonID, @LicenseClassID)";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            CanApply = (bool)result;
                        }

                    }
                    catch (Exception ex) 
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return CanApply;
        }

    }
}
