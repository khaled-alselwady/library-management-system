using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAccessLayer
{
    public class clsAuthorDataAccessLayer
    {
        public static bool GetAuthorInfoByID(int AuthorID, ref string FullName, ref string Education, ref string Bio)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Authors WHERE AuthorID = @AuthorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    FullName = (string)reader["FullName"];

                    if (reader["Education"] != DBNull.Value)
                    {
                        Education = (string)reader["Education"];
                    }
                    else
                    {
                        Education = "";
                    }

                    if (reader["Bio"] != DBNull.Value)
                    {
                        Bio = (string)reader["Bio"];
                    }
                    else
                    {
                        Bio = "";
                    }

                }

                else
                {
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;

            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetAuthorInfoByAuthorName(string FullName, ref int AuthorID, ref string Education, ref string Bio)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Authors WHERE FullName = @FullName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", FullName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    AuthorID = (int)reader["AuthorID"];

                    if (reader["Education"] != DBNull.Value)
                    {
                        Education = (string)reader["Education"];
                    }
                    else
                    {
                        Education = "";
                    }

                    if (reader["Bio"] != DBNull.Value)
                    {
                        Bio = (string)reader["Bio"];
                    }
                    else
                    {
                        Bio = "";
                    }

                }

                else
                {
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;

            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int AddNewAuthor(string FullName, string Education, string Bio)
        {
            int AuthorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Authors (FullName, Education, Bio)
                             VALUES (@FullName, @Education, @Bio);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", FullName);

            if (string.IsNullOrWhiteSpace(Education))
            {
                command.Parameters.AddWithValue("@Education", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Education", Education);
            }


            if (string.IsNullOrWhiteSpace(Bio))
            {
                command.Parameters.AddWithValue("@Bio", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Bio", Bio);
            }


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertID))
                {
                    AuthorID = insertID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return AuthorID;
        }

        public static bool UpdateAuthor(int AuthorID, string FullName, string Education, string Bio)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Authors
                             SET FullName       = @FullName,
                                 Education      = @Education,
                                 Bio            = @Bio
                                 WHERE AuthorID = @AuthorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", FullName);

            if (string.IsNullOrWhiteSpace(Education))
            {
                command.Parameters.AddWithValue("@Education", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Education", Education);
            }


            if (string.IsNullOrWhiteSpace(Bio))
            {
                command.Parameters.AddWithValue("@Bio", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Bio", Bio);
            }

            command.Parameters.AddWithValue("@AuthorID", AuthorID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }

        public static bool DeleteAuthor(int AuthorID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"IF NOT EXISTS (SELECT Found = 1 From Books WHERE Books.AuthorID = @AuthorID)
                             BEGIN
                                    DELETE FROM Authors WHERE AuthorID = @AuthorID
                             END";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);


        }

        public static bool IsAuthorExists(int AuthorID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Authors WHERE AuthorID = @AuthorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsAuthorExists(string FullName)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Authors WHERE FullName = @FullName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", FullName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllAuthors()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Authors";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;


        }

        public static DataTable SearchAuthorsContainsByID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Authors
                             WHERE (Authors.AuthorID) LIKE '%' + @Contains + '%';";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable SearchAuthorsContainsByName(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Authors
                             WHERE (Authors.FullName) LIKE '%' + @Contains + '%';";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable SearchAuthorsContainsByEducation(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Authors
                             WHERE (Authors.Education) LIKE '%' + @Contains + '%';";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int GetTotalNumberOfAuthors()
        {

            int TotalNumber = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT COUNT (Authors.AuthorID) FROM Authors;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Total))
                {
                    TotalNumber = Total;
                }

            }

            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return TotalNumber;
        }

    }
}
