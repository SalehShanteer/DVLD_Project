using System;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsKeySettingsData
    {
        public static string GetDecryptionKey(int ID)
        {
            string DecryptionKey = string.Empty;

            string query = "SELECT DecryptionKey FROM Keys WHERE KeyID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter to query
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            DecryptionKey = result.ToString();
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return DecryptionKey;
        }
    }
}
