using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAccessLayer
{
    public class clsBookCopiesDataAccessLayer
    {
        public static bool GetBookCopiesInfoByCopyID(int CopyID, ref int BookID, ref bool AvailabilityStatus)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM BookCopies WHERE CopyID = @CopyID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CopyID", CopyID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;


                    BookID = (int)reader["BookID"];
                    AvailabilityStatus = (bool)reader["AvailabilityStatus"];

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

        public static DataTable GetAllCopiesOfSpecificBook(int BookID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT CopyID,
                             AvailabilityStatus =
                             
                             CASE
	                           	   WHEN AvailabilityStatus = 0 THEN 'UnAvailable'
	                           	   ELSE 'Available'
                             END
                             
                             
                             FROM BookCopies WHERE BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookID", BookID);

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

        public static bool GetTheFirstCopyAvailableInfoOfSpecificBook(int BookID, ref int CopyID, ref bool AvailabilityStatus)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 * FROM BookCopies WHERE BookID = @BookID AND AvailabilityStatus = 1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("BookID", BookID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CopyID = (int)reader["CopyID"];
                    AvailabilityStatus = (bool)reader["AvailabilityStatus"];

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

        public static bool GetTheFirstCopyInfoOfSpecificBook(int BookID, ref int CopyID, ref bool AvailabilityStatus)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 * FROM BookCopies WHERE BookID = @BookID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("BookID", BookID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    CopyID = (int)reader["CopyID"];
                    AvailabilityStatus = (bool)reader["AvailabilityStatus"];

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

        public static bool IsThereCopyBookAvailable(int BookID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 Found = 1 FROM BookCopies WHERE BookID = @BookID AND AvailabilityStatus = 1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("BookID", BookID);

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

        public static bool UpdateBookCopies(int CopyID, int BookID, bool AvailabilityStatus)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE BookCopies
                             SET    BookID            = @BookID,
                                    AvailabilityStatus = @AvailabilityStatus                                  
                             WHERE  CopyID = @CopyID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CopyID", CopyID);
            command.Parameters.AddWithValue("@BookID", BookID);
            command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);


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

    }
}
