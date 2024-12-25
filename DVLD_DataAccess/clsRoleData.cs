using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsRoleData
    {

        public static bool FindRoleByID(int ID, ref string Title, ref int Permissions, ref string Description)
        {
            bool IsFound = false;

            string query = "SELECT * FROM Roles WHERE RoleID = @ID";

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
                            Permissions = (int)reader["Permissions"];
                            Description = reader["Description"] != DBNull.Value ? (string)reader["Description"] : string.Empty;

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

        public static bool IsRoleExist(int ID)
        {
            return clsGenericData.IsRecordExist("Roles", "RoleID", ID);
        }

        public static DataTable GetAllRoles()
        {
            string query = "SELECT * FROM Roles";

            return clsGenericData.GetDataTable(query);
        }

    }
}
