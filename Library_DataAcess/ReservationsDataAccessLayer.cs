using LibraryDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAcessLayer
{
    public class clsReservationsDataAccessLayer
    {

        public static bool GetReservationInfoByID(int ReservationID, ref int MemberID,
            ref int CopyID, ref DateTime ReservationDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reservations WHERE ReservationID = @ReservationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    CopyID = (int)reader["CopyID"];
                    ReservationDate = (DateTime)reader["ReservationDate"];

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

        public static int AddNewReservation(int MemberID, int CopyID, DateTime ReservationDate)
        {
            int ReservationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Reservations (MemberID, CopyID, ReservationDate)
                             VALUES (@MemberID, @CopyID, @ReservationDate);
                             SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@CopyID", CopyID);
            command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
            
            
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertID))
                {
                    ReservationID = insertID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ReservationID;


        }

        public static bool UpdateReservation(int ReservationID, int MemberID, int CopyID, DateTime ReservationDate)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Reservations
                             SET    MemberID        = @MemberID,
                                    CopyID          = @CopyID,
                                    ReservationDate = @ReservationDate                                    
                             WHERE  ReservationID   = @ReservationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@CopyID", CopyID);
            command.Parameters.AddWithValue("@ReservationDate", ReservationDate);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);
            

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

        public static bool DeleteReservation(int ReservationID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Reservations WHERE ReservationID = @ReservationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ReservationID", ReservationID);

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

        public static DataTable GetAllReservations()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reservations;";

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

        public static DataTable GetAllReservationsOfSpecificMember(int MemberID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Reservations.ReservationID, Reservations.MemberID, BookCopies.BookID, Reservations.ReservationDate
                             FROM Reservations
                             INNER JOIN BookCopies
                             ON Reservations.CopyID = BookCopies.CopyID
                             WHERE Reservations.MemberID = @MemberID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static DataTable SearchReservationsContains(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reservations
                             WHERE (Reservations.ReservationID) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchReservationsContainsOfSpecificMember(string Contains, int MemberID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Reservations
                             WHERE (Reservations.ReservationID) LIKE '%' + @Contains + '%' AND MemberID = @MemberID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);
            command.Parameters.AddWithValue("@MemberID", MemberID);

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

    }
}
