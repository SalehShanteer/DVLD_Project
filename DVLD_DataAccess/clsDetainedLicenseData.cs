using System;
using System.Diagnostics;
using Global_Variables_Data;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsDetainedLicenseData
    {
        public static bool FindDetainedLicenseByID(int ID, ref int LicenseID, ref DateTime DetainDate
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

        public static bool FindNonReleasedDetainedLicenseByLicenseID(ref int ID, int LicenseID, ref DateTime DetainDate
            , ref short FineFees, ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleaseApplicationID
            , ref int ReleasedByUserID, ref int CreatedByUserID)
        {
            
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetNonReleasedDetainedLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ID = Convert.ToInt32(reader["DetainID"]);
                                DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                                FineFees = Convert.ToInt16(reader["FineFees"]);
                                IsReleased = Convert.ToBoolean(reader["IsReleased"]);
                                ReleaseDate = reader["ReleaseDate"] != DBNull.Value ? Convert.ToDateTime(reader["ReleaseDate"]) : DateTime.MinValue;
                                ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ? Convert.ToInt32(reader["ReleaseApplicationID"]) : -1;
                                ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["ReleasedByUserID"]) : -1;
                                CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);

                                IsFound = true;
                            }
                        }
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

        public static bool IsDetainedLicenseExist(int ID)
        {
            return clsGenericData.IsRecordExist("DetainedLicenses", "DetainedLicenseID", ID);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            string query = "EXEC SP_IsLicenseDetained @LicenseID = @SelectedLicenseID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@SelectedLicenseID", LicenseID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            IsDetained = Convert.ToBoolean(result);
                        }
                    }
                    catch (Exception ex) 
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsDetained;
        }

        public static int AddNewDetainedLicense(int LicenseID, short FineFees)
        {
            int ID = -1;

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewDetainLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@FineFees", FineFees);

                    // Add the output parameter
                    SqlParameter outputIDParameter = new SqlParameter("@NewDetainID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIDParameter);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        ID = (int)command.Parameters["@NewDetainID"].Value;

                        // Log the event to the event log
                        EventLog.WriteEntry(clsSettingsData.SourceName, "New Detained License Added Successfully", EventLogEntryType.Information);
                    }
                    catch (Exception ex) 
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return ID;
        }

        public static bool ReleaseDetainedLicense(int ID, ref int ReleaseApplicationID)
        {
            bool IsReleased = false;

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_ReleaseDetainedLicense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add the parameters
                    command.Parameters.AddWithValue("@DetainID", ID);
                    
                    SqlParameter outputParameter1 = new SqlParameter("@IsReleased", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output,
                    };

                    SqlParameter outputParameter2 = new SqlParameter("@ReleaseApplicationID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output,
                    };

                    command.Parameters.Add(outputParameter1);
                    command.Parameters.Add(outputParameter2);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Get the output parameters
                        IsReleased = (bool)command.Parameters["@IsReleased"].Value;
                        ReleaseApplicationID = (int)command.Parameters["@ReleaseApplicationID"].Value;

                        // Log the event to the event log
                        EventLog.WriteEntry(clsSettingsData.SourceName, "Detained License Released Successfully", EventLogEntryType.Information);
                    }
                    catch (Exception ex) 
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsReleased;
        }

        public static bool DeleteDetainedLicense(int ID)
        {
            return clsGenericData.DeleteRecord("DetainedLicenses", "ID", ID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            string query = "SELECT * FROM VIEW_DetainedLicensesList";

            return clsGenericData.GetDataTable(query);
        }

        public static int GetNumberOfDetainedLicenses()
        {
            return clsGenericData.CountRecords("DetainedLicenses");
        }

    }
}
