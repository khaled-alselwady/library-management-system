using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;
using System.Net;

namespace LibraryDataAccessLayer
{
    public class clsBookDataAccessLayer
    {

        public static bool GetBooKInfoByID(int BookID, ref string Title, ref int AuthorID,
                                           ref int GenreID, ref DateTime PublicationDate,
                                           ref string ISBN, ref int Quantity, ref string AdditionalDetails)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Books WHERE BookID = @BookID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookID", BookID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFound = true;

                    Title = (string)reader["Title"];
                    AuthorID = (int)reader["AuthorID"];
                    GenreID = (int)reader["GenreID"];
                    ISBN = (string)reader["ISBN"];
                    Quantity = (int)reader["Quantity"];

                    if (reader["PublicationDate"] != DBNull.Value)
                    {
                        PublicationDate = (DateTime)reader["PublicationDate"];
                    }
                    else
                    {
                        PublicationDate = default;
                    }


                    if (reader["AdditionalDetails"] != DBNull.Value)
                    {
                        AdditionalDetails = (string)reader["AdditionalDetails"];
                    }
                    else
                    {
                        AdditionalDetails = "";
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

        public static DataTable GetAllBooKsWithTheSameTitle(string Title)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Books WHERE Title = @Title";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);

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

        public static DataTable GetAllBooKsWithTheSameGenre(int GenreID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Books WHERE GenreID = @GenreID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@GenreID", GenreID);

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

        public static DataTable GetAllBooKsWithTheSameAuthor(int AuthorID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Books WHERE AuthorID = @AuthorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);

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

        public static int AddNewBook(string Title, int AuthorID, int GenreID,
                                     DateTime PublicationDate, string ISBN, int Quantity, string AdditionalDetails)
        {
            int BookID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"IF NOT EXISTS (SELECT Found = 'gg' FROM Books WHERE ISBN = @ISBN)
                             BEGIN 
                             
                             			INSERT INTO Books (Title, AuthorID, GenreID, ISBN, PublicationDate, Quantity, AdditionalDetails)
                                        VALUES (@Title, @AuthorID, @GenreID, @ISBN, @PublicationDate, @Quantity, @AdditionalDetails);
                             
                                  
                                        DECLARE @BookID INT;
                                        SET @BookID = SCOPE_IDENTITY();
                                        
                                        
                                        DECLARE @CopyQuantity INT;
                                        SELECT @CopyQuantity = Quantity
                                        FROM Books
                                        WHERE BookID = @BookID;
                                        
                                        
                                        DECLARE @Counter INT = 1;
                                        
                                        
                                        WHILE @Counter <= @CopyQuantity
                                        BEGIN
                                            INSERT INTO BookCopies (BookID, AvailabilityStatus)
                                            VALUES (@BookID, 1);
                                            
                                            SET @Counter = @Counter + 1;
                                        END;
                                           
                                   
                                       SELECT @BookID
                                  
                             				   
                             END;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);
            command.Parameters.AddWithValue("@GenreID", GenreID);
            command.Parameters.AddWithValue("@ISBN", ISBN);
            command.Parameters.AddWithValue("@Quantity", Quantity);

            if (PublicationDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@PublicationDate", PublicationDate);
            }
            else
            {
                command.Parameters.AddWithValue("@PublicationDate", System.DBNull.Value);
            }


            if (string.IsNullOrWhiteSpace(AdditionalDetails))
            {
                command.Parameters.AddWithValue("@AdditionalDetails", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);
            }


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertID))
                {
                    BookID = insertID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return BookID;
        }


        public static bool UpdateBook(int BookID, string Title, int AuthorID, int GenreID,
                                     DateTime PublicationDate, string ISBN, int Quantity, string AdditionalDetails)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Books
                             SET    Title             = @Title,
                                    AuthorID            = @AuthorID,
                                    GenreID             = @GenreID,
                                    PublicationDate   = @PublicationDate,
                                    ISBN              = @ISBN,
                                    Quantity              = @Quantity,
                                    AdditionalDetails = @AdditionalDetails
                             WHERE  BookID = @BookID



                             DECLARE @CopyQuantity INT;
                             SELECT @CopyQuantity = Quantity
                             FROM Books
                             WHERE BookID = @BookID;
                             
                             
                             DECLARE @Counter INT;
                             SELECT @Counter = COUNT(BookCopies.BookID) + 1
                             FROM BookCopies
                             WHERE BookCopies.BookID = @BookID;
                             
                             
                             WHILE @Counter <= @CopyQuantity
                             BEGIN
                                 INSERT INTO BookCopies (BookID, AvailabilityStatus)
                                 VALUES (@BookID, 1);
                                 
                                 SET @Counter = @Counter + 1;
                             END;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@AuthorID", AuthorID);
            command.Parameters.AddWithValue("@GenreID", GenreID);
            command.Parameters.AddWithValue("@ISBN", ISBN);
            command.Parameters.AddWithValue("@Quantity", Quantity);

            if (PublicationDate != DateTime.MinValue)
            {
                command.Parameters.AddWithValue("@PublicationDate", PublicationDate);
            }
            else
            {
                command.Parameters.AddWithValue("@PublicationDate", System.DBNull.Value);
            }


            if (string.IsNullOrWhiteSpace(AdditionalDetails))
            {
                command.Parameters.AddWithValue("@AdditionalDetails", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);
            }

            command.Parameters.AddWithValue("@BookID", BookID);

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

        public static bool DeleteBooK(int BookID)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"IF NOT EXISTS(SELECT Found = 1 FROM BookCopies WHERE BookID = @BookID AND AvailabilityStatus = 0)
                             BEGIN
                             		
                             		IF NOT EXISTS(SELECT Found = 1 FROM BookCopies INNER JOIN Reservations ON Reservations.CopyID = BookCopies.CopyID)
                             		BEGIN
                                            
                                            DELETE FROM BookCopies WHERE BookID = @BookID;
                             				DELETE FROM Books WHERE BookID = @BookID;
                             
                             		END
                             
                             END";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("BookID", BookID);

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

        public static bool IsBookExists(int BookID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Books WHERE BookID = @BookID";

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

        public static bool IsBookExists(string ISBN)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Books WHERE ISBN = @ISBN";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("ISBN", ISBN);

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

        public static DataTable GetAllBooks()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate,  Books.Quantity,Books.AdditionalDetails 
                             FROM Books 
                             INNER JOIN Authors 
                             ON Books.AuthorID = Authors.AuthorID
                             INNER JOIN Genres
                             ON Books.GenreID = Genres.GenreID;";

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

        public static DataTable GetAllBooksWithoutQuantity()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate, Books.AdditionalDetails 
                             FROM Books 
                             INNER JOIN Authors 
                             ON Books.AuthorID = Authors.AuthorID
                             INNER JOIN Genres
                             ON Books.GenreID = Genres.GenreID;";

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

        public static DataTable SearchBooksContainsByID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate,  Books.Quantity, Books.AdditionalDetails 
                                 FROM Books 
                                 INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                                 INNER JOIN Genres ON Books.GenreID = Genres.GenreID
                                 WHERE (Books.BookID) LIKE '%' + @Contains + '%'
                             ) AS subQuery;";
                  

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

        public static DataTable SearchBooksContainsByTitle(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate,  Books.Quantity, Books.AdditionalDetails 
                                 FROM Books 
                                 INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                                 INNER JOIN Genres ON Books.GenreID = Genres.GenreID
                                 WHERE (Books.Title) LIKE '%' + @Contains + '%'
                             ) AS subQuery;";


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

        public static DataTable SearchBooksContainsByAuthor(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate,  Books.Quantity, Books.AdditionalDetails 
                                 FROM Books 
                                 INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                                 INNER JOIN Genres ON Books.GenreID = Genres.GenreID
                                 WHERE (Authors.FullName) LIKE '%' + @Contains + '%'
                             ) AS subQuery;";


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

        public static DataTable SearchBooksContainsByGenre(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate,  Books.Quantity, Books.AdditionalDetails 
                                 FROM Books 
                                 INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                                 INNER JOIN Genres ON Books.GenreID = Genres.GenreID
                                 WHERE (Genres.GenreName) LIKE '%' + @Contains + '%'
                             ) AS subQuery;";


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


        public static DataTable SearchBooksContainsByIDWithoutQuantity(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate, Books.AdditionalDetails 
                                 FROM Books 
                                 INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                                 INNER JOIN Genres ON Books.GenreID = Genres.GenreID
                                 WHERE (Books.BookID) LIKE '%' + @Contains + '%'
                             ) AS subQuery;";


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

        public static DataTable SearchBooksContainsByTitleWithoutQuantity(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate, Books.AdditionalDetails 
                                 FROM Books 
                                 INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                                 INNER JOIN Genres ON Books.GenreID = Genres.GenreID
                                 WHERE (Books.Title) LIKE '%' + @Contains + '%'
                             ) AS subQuery;";


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

        public static DataTable SearchBooksContainsByAuthorWithoutQuantity(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate, Books.AdditionalDetails 
                                 FROM Books 
                                 INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                                 INNER JOIN Genres ON Books.GenreID = Genres.GenreID
                                 WHERE (Authors.FullName) LIKE '%' + @Contains + '%'
                             ) AS subQuery;";


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

        public static DataTable SearchBooksContainsByGenreWithoutQuantity(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                 SELECT Books.BookID, Books.Title, Authors.FullName AS Author, Genres.GenreName AS Genre, Books.ISBN, Books.PublicationDate, Books.AdditionalDetails 
                                 FROM Books 
                                 INNER JOIN Authors ON Books.AuthorID = Authors.AuthorID
                                 INNER JOIN Genres ON Books.GenreID = Genres.GenreID
                                 WHERE (Genres.GenreName) LIKE '%' + @Contains + '%'
                             ) AS subQuery;";


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

        public static int GetTotalNumberOfBooks()
        {

            int TotalNumber = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT COUNT (Books.BookID) FROM Books;";

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

            catch(Exception ex)
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
