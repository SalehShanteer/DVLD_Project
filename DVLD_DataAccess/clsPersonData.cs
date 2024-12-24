using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {

        public static bool FindPersonByID(int ID, ref string NationalNumber, ref string FirstName, ref string SecondName
            , ref string ThirdName, ref string LastName, ref bool Gender, ref DateTime DateOfBirth, ref byte Age, ref string Address
            , ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            string query = "SELECT * FROM People WHERE PersonID = @ID";

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
                            //Set values for person
                            NationalNumber = (string)reader["NationalNumber"];
                            FirstName = (string)reader["FirstName"];
                            SecondName = (string)reader["SecondName"];
                            ThirdName = (string)reader["ThirdName"];
                            LastName = (string)reader["LastName"];
                            Gender = (bool)reader["Gender"];
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Age = (byte)reader["Age"];
                            Address = (string)reader["Address"];
                            Phone = (string)reader["Phone"];
                            Email = (string)reader["Email"];
                            NationalityCountryID = (int)reader["NationalityCountryID"];
                            ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : string.Empty;

                            IsFound = true;
                        }

                        reader.Close();
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }

                    return IsFound; 
                }
            }
        }

        public static bool FindPersonByNationalNumber(ref int ID, string NationalNumber, ref string FirstName, ref string SecondName
           , ref string ThirdName, ref string LastName, ref bool Gender, ref DateTime DateOfBirth, ref byte Age, ref string Address
           , ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            string query = "SELECT * FROM People WHERE NationalNumber = @NationalNumber";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            //Set values for person
                            ID = (int)reader["ID"];
                            FirstName = (string)reader["FirstName"];
                            SecondName = (string)reader["SecondName"];
                            ThirdName = (string)reader["ThirdName"];
                            LastName = (string)reader["LastName"];
                            Gender = (bool)reader["Gender"];
                            DateOfBirth = (DateTime)reader["DateOfBirth"];
                            Age = (byte)reader["Age"];
                            Address = (string)reader["Address"];
                            Phone = (string)reader["Phone"];
                            Email = (string)reader["Email"];
                            NationalityCountryID = (int)reader["NationalityCountryID"];
                            ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : string.Empty;

                            IsFound = true;
                        }

                        reader.Close();
                    }
                    catch (Exception ex) { }
                    finally { connection.Close(); }

                    return IsFound;
                }
            }
        }

        public static bool IsPersonExistByPersonID(int PersonID)
        {
            return clsGenericData.IsRecordExist("People", "PersonID", PersonID);
        }

        public static bool IsPersonExistByNationalNumber(string NationalNumber)
        {
            return clsGenericData.IsRecordExist("People", "NationalNumber", NationalNumber);
        }

        public static int AddNewPerson(string NationalNumber, string FirstName, string SecondName, string ThirdName, string LastName
            , bool Gender, DateTime DateOfBirth, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int ID = -1;

            string query = "INSERT INTO People (NationalNumber, FirstName, SecondName, ThirdName, LastName, Gender, DateOfBirth, Address, Phone, Email, NationalityCountryID, ImagePath) " +
                "VALUES (@NationalNumber, @FirstName, @SecondName, @ThirdName, @LastName, @Gender, @DateOfBirth, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath); " +
                "SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", ImagePath != string.Empty ? ImagePath : (object)DBNull.Value);

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

        public static bool UpdatePerson(int ID, string NationalNumber, string FirstName, string SecondName, string ThirdName, string LastName
            , bool Gender, DateTime DateOfBirth, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            bool IsUpdated = false;

            string query = "UPDATE People SET NationalNumber = @NationalNumber, FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName, Gender = @Gender " +
                           ", DateOfBirth = @DateOfBirth, Address = @Address, Phone = @Phone, Email = @Email, NationalityCountryID = @NationalityCountryID, ImagePath = @ImagePath " +
                           "WHERE PersonID = @ID";

            using (SqlConnection connection = new SqlConnection(clsDVLD_Settings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@SecondName", SecondName);
                    command.Parameters.AddWithValue("@ThirdName", ThirdName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
                    command.Parameters.AddWithValue("@ImagePath", ImagePath != string.Empty ? ImagePath : (object)DBNull.Value);

                    try
                    {
                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
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

        public static bool DeletePerson(int ID)
        {
            return clsGenericData.DeleteRecord("People", "PersonID", ID);
        }

        public static DataTable GetAllPeople()
        {
            string query = "SELECT * FROM View_PeopleList";

            return clsGenericData.GetAllRecords(query);
        }


    }
}
