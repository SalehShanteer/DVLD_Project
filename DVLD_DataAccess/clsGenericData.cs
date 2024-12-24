using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;    
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    catch (Exception ex) { }
                    finally { connection.Close(); }
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
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return IsDeleted;
        }

        public static DataTable GetAllRecords(string query)
        {
            DataTable dt = new DataTable();

            //Ensure table and filter are valid to prevent SQL injection
            if (string.IsNullOrWhiteSpace(query) || !IsSelectQuery(query))
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
                    catch (Exception ex) { }
                    finally { connection.Close(); }                  
                }
            }
            return dt;
        }


        // Helper method to validate identifiers (table and column names)
        private static bool IsValidIdentifier(string identifier)
        {
            // Simple validation; you can enhance it based on your requirements
            return !string.IsNullOrWhiteSpace(identifier) && identifier.All(char.IsLetterOrDigit);
        }

        // Helper method to validate that the query is a SELECT statement
        private static bool IsSelectQuery(string query)
        {
            // Simple validation to ensure the query starts with "SELECT"
            return query.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase);
        }

    }
}
