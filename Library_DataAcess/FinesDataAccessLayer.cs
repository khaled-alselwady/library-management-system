using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataAccessLayer
{
    public class clsFinesDataAccessLayer
    {

        public static bool GetFineInfoByID(int FineID, ref int MemberID, ref int BorrowingRecordID, ref short NumberOfLateDays, ref decimal FineAmount, ref bool PaymentStatus)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Fines WHERE FineID = @FineID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FineID", FineID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    BorrowingRecordID = (int)reader["BorrowingRecordID"];
                    NumberOfLateDays = (short)reader["NumberOfLateDays"];
                    FineAmount = (decimal)reader["FineAmount"];
                    PaymentStatus = (bool)reader["PaymentStatus"];

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

        public static int AddNewFine(int MemberID, int BorrowingRecordID, int NumberOfLateDays, decimal FineAmount, bool PaymentStatus)
        {
            int FinesID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Fines (MemberID, BorrowingRecordID, NumberOfLateDays, FineAmount, PaymentStatus)
                             VALUES (@MemberID, @BorrowingRecordID, @NumberOfLateDays, @FineAmount, @PaymentStatus);
                             SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            command.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays);
            command.Parameters.AddWithValue("@FineAmount", FineAmount);
            command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertID))
                {
                    FinesID = insertID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return FinesID;

        }

        public static bool UpdateFines(int FineID, int MemberID, int BorrowingRecordID, int NumberOfLateDays, decimal FineAmount, bool PaymentStatus)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Fines
                             SET    MemberID          = @MemberID,
                                    BorrowingRecordID = @BorrowingRecordID,
                                    NumberOfLateDays  = @NumberOfLateDays,
                                    FineAmount        = @FineAmount,
                                    PaymentStatus     = @PaymentStatus
                             WHERE  FineID            = @FineID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            command.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays);
            command.Parameters.AddWithValue("@FineAmount", FineAmount);
            command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            command.Parameters.AddWithValue("@FineID", FineID);

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

        public static DataTable GetAllFines()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT FineID, MemberID, BorrowingRecordID, NumberOfLateDays, FineAmount,
                             PaymentStatus =
                             CASE
  	                              WHEN PaymentStatus = 0 THEN 'UnPaid'
  	                              ELSE 'Paid'
                             END
                             
                             FROM Fines";

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

        public static DataTable GetAllFinesOfSpecificMember(int MemberID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT FineID, MemberID, BorrowingRecordID, NumberOfLateDays, FineAmount,
                             PaymentStatus =
                             CASE
  	                              WHEN PaymentStatus = 0 THEN 'UnPaid'
  	                              ELSE 'Paid'
                             END
                             
                             FROM Fines WHERE MemberID = @MemberID";

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

        public static DataTable SearchFinesContains(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT FineID, MemberID, BorrowingRecordID, NumberOfLateDays, FineAmount,
                             PaymentStatus =
                             CASE
  	                              WHEN PaymentStatus = 0 THEN 'UnPaid'
  	                              ELSE 'Paid'
                             END

                             FROM Fines
                             WHERE (Fines.FineID) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchFinesContainsOfSpecificMember(string Contains, int MemberID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT FineID, MemberID, BorrowingRecordID, NumberOfLateDays, FineAmount,
                             PaymentStatus =
                             CASE
  	                              WHEN PaymentStatus = 0 THEN 'UnPaid'
  	                              ELSE 'Paid'
                             END

                             FROM Fines
                             WHERE (Fines.FineID) LIKE '%' + @Contains + '%' AND MemberID = @MemberID;";


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
