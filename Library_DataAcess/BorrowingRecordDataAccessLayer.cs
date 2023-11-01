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
    public class clsBorrowingRecordDataAccessLayer
    {

        public static bool GetBorrowingRecordInfoByID(int BorrowingRecordID, ref int MemberID, ref int CopyID,
            ref DateTime BorrowingDate, ref DateTime DueDate, ref DateTime ActualReturnDate)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM BorrowingRecords WHERE BorrowingRecordID = @BorrowingRecordID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    CopyID = (int)reader["CopyID"];
                    BorrowingDate = (DateTime)reader["BorrowingDate"];
                    DueDate = (DateTime)reader["DueDate"];

                    if (reader["ActualReturnDate"] != DBNull.Value)
                    {
                        ActualReturnDate = (DateTime)reader["ActualReturnDate"];
                    }
                    else
                    {
                        ActualReturnDate = DateTime.MinValue;
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

        public static int AddNewBorrowingRecord(int MemberID, int CopyID,
            DateTime BorrowingDate, DateTime DueDate, DateTime ActualReturnDate)
        {
            int BorrowingRecordID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO BorrowingRecords (MemberID, CopyID, BorrowingDate, DueDate, ActualReturnDate)
                             VALUES (@MemberID, @CopyID, @BorrowingDate, @DueDate, @ActualReturnDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@CopyID", CopyID);
            command.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);
            command.Parameters.AddWithValue("@DueDate", DueDate);

            if (ActualReturnDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualReturnDate", System.DBNull.Value);
            }



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(),out int insertID))
                {
                    BorrowingRecordID = insertID;
                }

            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return BorrowingRecordID;
        }

        public static bool UpdateBorrowingRecord(int BorrowingRecordID, int MemberID, int CopyID,
            DateTime BorrowingDate, DateTime DueDate, DateTime ActualReturnDate)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE BorrowingRecords
                             SET    MemberID          = @MemberID,
                                    CopyID            = @CopyID,
                                    BorrowingDate     = @BorrowingDate,
                                    DueDate           = @DueDate,
                                    ActualReturnDate  = @ActualReturnDate                                                     
                             WHERE  BorrowingRecordID = @BorrowingRecordID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@CopyID", CopyID);
            command.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);
            command.Parameters.AddWithValue("@DueDate", DueDate);
            command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

            if (ActualReturnDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualReturnDate", System.DBNull.Value);
            }

            
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

        public static bool DeleteBorrowingRecord(int BorrowingRecordID)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"IF NOT EXISTS(SELECT Found = 1 FROM Fines WHERE Fines.BorrowingRecordID = @BorrowingRecordID)
                             BEGIN
                             	       
                             		DELETE FROM BorrowingRecords WHERE BorrowingRecordID = @BorrowingRecordID;
                             
                                                          
                             END";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("BorrowingRecordID", BorrowingRecordID);

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

        public static DataTable GetAllBorrowingRecords()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM BorrowingRecords;";

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

        public static DataTable GetAllBorrowingRecordsOfSpecificMember(int MemberID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT BorrowingRecords.BorrowingRecordID, BorrowingRecords.MemberID, BookCopies.BookID AS BookID, BorrowingRecords.BorrowingDate, BorrowingRecords.DueDate, BorrowingRecords.ActualReturnDate
                             FROM BorrowingRecords
                             INNER JOIN BookCopies
                             ON BorrowingRecords.CopyID = BookCopies.CopyID
                             WHERE BorrowingRecords.MemberID = @MemberID;";

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


        public static DataTable SearchBorrowingRecordsContains(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM BorrowingRecords
                             WHERE (BorrowingRecords.BorrowingRecordID) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchBorrowingRecordsContainsOfSpecificMember(string Contains,int MemberID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM BorrowingRecords
                             WHERE (BorrowingRecords.BorrowingRecordID) LIKE '%' + @Contains + '%' AND MemberID = @MemberID;";


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
