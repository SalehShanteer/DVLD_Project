using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsCountryData
    {
        
        public static bool FindCountryByID(int ID, ref string Name)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Countries where CountryID = @ID";

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
                            Name = (string)reader["Name"];

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

        public static bool FindCountryByName(ref int ID, string Name)
        {

            bool IsFound = false;

            string query = "SELECT * FROM Countries where Name = @Name";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Name", Name);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ID = (int)reader["CountryID"];
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

        public static bool IsCountryExist(int ID)
        {
            return clsGenericData.IsRecordExist("Countries", "CountryID", ID);
        }

        public static DataTable GetAllCountries()
        {
           string query = "SELECT * FROM Countries";    
            return clsGenericData.GetDataTable(query);
        }

    }
}
