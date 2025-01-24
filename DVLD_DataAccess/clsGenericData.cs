using System;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;    
using System.Linq;
using Global_Variables_Data;

namespace DVLD_DataAccess
{
    public class clsGenericData
    {
        
        public static bool IsRecordExist<T>(string table, string filter, T Value)
        {
            bool IsFound = false;

            // Ensure table and filter are valid to prevent SQL injection
            if (!IsValidIdentifier(table) || !IsValidIdentifier(filter))
            {
                throw new ArgumentException("Invalid table or column name.");
            }

            string query = $"SELECT Found = 1 FROM {table} Where {filter} = @{filter}";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue($"@{filter}", Value);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            IsFound = true;
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

        public static bool DeleteRecord<T>(string table, string filter, T value)
        {
            bool IsDeleted = false;

            // Ensure table and filter are valid to prevent SQL injection
            if (!IsValidIdentifier(table) || !IsValidIdentifier(filter))
            {
                throw new ArgumentException("Invalid table or column name.");
            }

            string query = $"DELETE FROM {table} WHERE {filter} = @{filter}";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue($"@{filter}", value);
                    try
                    {
                        connection.Open();

                        int RowsAffected = command.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            IsDeleted = true;
                        }
                    }
                    catch (Exception ex) 
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return IsDeleted;
        }

        public static DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();

            //Ensure table and filter are valid to prevent SQL injection
            if (string.IsNullOrWhiteSpace(query))
            { 
                throw new ArgumentException("Invalid or unsafe SQL query.", nameof(query));
            }

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);// Fill dataTable with all rows
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
            return dt;
        }

        public static int CountRecords(string table)
        {          
            int count = 0;
            
            // Ensure table is valid to prevent SQL injection
            if (!IsValidIdentifier(table))
            {
                throw new ArgumentException("Invalid table or column name.");
            }

            string query = $"SELECT COUNT(*) FROM {table}";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int TotalRecords))
                        {
                            count = TotalRecords;
                        }
                    }
                    catch (Exception ex) 
                    {
                        // Log the exception to the event log
                        EventLog.WriteEntry(clsSettingsData.SourceName, ex.Message, EventLogEntryType.Error);
                    }
                }
            }
            return count;
        }

        // Helper method to validate identifiers (table and column names)
        private static bool IsValidIdentifier(string identifier)
        {
            // Simple validation; you can enhance it based on your requirements
            return !string.IsNullOrWhiteSpace(identifier) && identifier.All(char.IsLetterOrDigit);
        }

       

    }
}
