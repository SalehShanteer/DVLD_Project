using System;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsInternationLicenseSettingData
    {

        public static byte GetInternationalLicenseValidityLength()
        {
            byte Length = 0;

            string query = "SELECT dbo.GetInternationalLicenseValidityLength()";
                         
            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    try
                    {
                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null && byte.TryParse(Result.ToString(), out byte length))
                        {
                            Length = length;
                        }
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }
                }
            }
            return Length;
        }
    }
}
