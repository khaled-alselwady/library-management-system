using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Data;

namespace LibraryDataAccessLayer
{
    public class clsMemberDataAccessLayer
    {

        public static bool GetMemberInfoByID(int MemberID, ref string FullName, ref string Username,
                                             ref string Email, ref string Password, ref string PhoneNumber,
                                             ref string LibraryCardNumber)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members WHERE MemberID = @MemberID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    FullName = (string)reader["FullName"];
                    Username = (string)reader["Username"];
                    Email = (string)reader["Email"];
                    Password = (string)reader["Password"];

                    if (reader["PhoneNumber"] != System.DBNull.Value)
                    {
                        PhoneNumber = (string)reader["PhoneNumber"];
                    }
                    else
                    {
                        PhoneNumber = "";
                    }

                    LibraryCardNumber = (string)reader["LibraryCardNumber"];

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


        public static bool GetMemberInfoByUsername(string Username, ref int MemberID, ref string FullName,
                                                   ref string Email, ref string Password,
                                                   ref string PhoneNumber, ref string LibraryCardNumber)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    FullName = (string)reader["FullName"];
                    Email = (string)reader["Email"];
                    Password = (string)reader["Password"];

                    if (reader["PhoneNumber"] != System.DBNull.Value)
                    {
                        PhoneNumber = (string)reader["PhoneNumber"];
                    }
                    else
                    {
                        PhoneNumber = "";
                    }

                    LibraryCardNumber = (string)reader["LibraryCardNumber"];

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


        public static bool GetMemberInfoByEmail(string Email, ref int MemberID, ref string FullName,
                                                ref string Username, ref string Password,
                                                ref string PhoneNumber, ref string LibraryCardNumber)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members WHERE Email = @Email";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    FullName = (string)reader["FullName"];
                    Username = (string)reader["Username"];
                    Email = (string)reader["Email"];
                    Password = (string)reader["Password"];

                    if (reader["PhoneNumber"] != System.DBNull.Value)
                    {
                        PhoneNumber = (string)reader["PhoneNumber"];
                    }
                    else
                    {
                        PhoneNumber = "";
                    }

                    LibraryCardNumber = (string)reader["LibraryCardNumber"];

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



        public static bool GetMemberInfoByLibraryCardNumber(string LibraryCardNumber, ref int MemberID,
                                                            ref string FullName, ref string Username,
                                                            ref string Email, ref string Password,
                                                            ref string PhoneNumber)


        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members
                    WHERE LibraryCardNumber = @LibraryCardNumber COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LibraryCardNumber", LibraryCardNumber);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    FullName = (string)reader["FullName"];
                    Username = (string)reader["Username"];
                    Email = (string)reader["Email"];
                    Password = (string)reader["Password"];

                    if (reader["PhoneNumber"] != System.DBNull.Value)
                    {
                        PhoneNumber = (string)reader["PhoneNumber"];
                    }
                    else
                    {
                        PhoneNumber = "";
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


        public static bool GetMemberInfoByUsernameAndPassword(string Username, string Password,
                                                   ref string Email, ref int MemberID, ref string Name,
                                                   ref string PhoneNumber, ref string LibraryCardNumber)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members
                             WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS
                             AND   Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    Name = (string)reader["FullName"];
                    Email = (string)reader["Email"];

                    if (reader["PhoneNumber"] != System.DBNull.Value)
                    {
                        PhoneNumber = (string)reader["PhoneNumber"];
                    }
                    else
                    {
                        PhoneNumber = "";
                    }

                    LibraryCardNumber = (string)reader["LibraryCardNumber"];

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



        public static bool GetMemberInfoByEmailAndPassword(string Email, string Password, ref int MemberID,
                                                   ref string Username, ref string FullName,
                                                   ref string PhoneNumber, ref string LibraryCardNumber)

        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members
                             WHERE Email = @Email
                             AND   Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    FullName = (string)reader["FullName"];
                    Username = (string)reader["Username"];

                    if (reader["PhoneNumber"] != System.DBNull.Value)
                    {
                        PhoneNumber = (string)reader["PhoneNumber"];
                    }
                    else
                    {
                        PhoneNumber = "";
                    }

                    LibraryCardNumber = (string)reader["LibraryCardNumber"];

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



        public static int AddNewMember(string FullName, string Username,
                                              string Email, string Password, string PhoneNumber)
        {
            int MemberID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"IF NOT EXISTS (SELECT * FROM Members WHERE Username = @Username)
    BEGIN
                                IF NOT EXISTS (SELECT * FROM Members WHERE Email = @Email)
        BEGIN
                                    INSERT INTO Members (FullName, Username, Email, Password, PhoneNumber)
                                    VALUES (@FullName, @Username, @Email, @Password, @PhoneNumber);

                                    DECLARE @LibraryCardNumber NVARCHAR(50); 
                                    SELECT TOP 1 @LibraryCardNumber = LibraryCardNumber
                                    FROM LibraryCardNumbers
                                    WHERE AvailabilityStatus = 1
                                    ORDER BY CardNumberID;
                             
                                    UPDATE Members
                                    SET LibraryCardNumber = @LibraryCardNumber
                                    WHERE Username = @Username;
                             
                                    UPDATE LibraryCardNumbers
                                    SET AvailabilityStatus = 0
                                    WHERE LibraryCardNumber = @LibraryCardNumber;

                                    SELECT SCOPE_IDENTITY();
        END;
    END;
";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);

            if (PhoneNumber != "")
            {
                command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            }
            else
            {
                command.Parameters.AddWithValue("@PhoneNumber", System.DBNull.Value);
            }



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result!= null && int.TryParse(result.ToString(), out int insertID))
                {
                    MemberID = insertID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return MemberID;
        }


        public static bool UpdateMember(int MemberID, string FullName, string Username,
                                              string Email, string Password, string PhoneNumber)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Members
                             SET FullName        = @FullName, 
                                 Username    = @Username, 
                                 Email       = @Email,
                                 Password    = @Password,
                                 PhoneNumber = @PhoneNumber
                             WHERE MemberID  = @MemberID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);

            if (PhoneNumber != "")
            {
                command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            }
            else
            {
                command.Parameters.AddWithValue("@PhoneNumber", System.DBNull.Value);
            }

            command.Parameters.AddWithValue("@MemberID", MemberID);

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


        public static bool DeleteMember(int MemberID)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"IF NOT EXISTS(SELECT Found = 1 FROM BorrowingRecords WHERE BorrowingRecords.MemberID = @MemberID)
                             BEGIN
                             		
                             		IF NOT EXISTS(SELECT Found = 1 FROM Fines WHERE Fines.MemberID = @MemberID)
                             		BEGIN
                                            
                                              IF NOT EXISTS(SELECT Found = 1 FROM Reservations WHERE Reservations.MemberID = @MemberID)
                             				 BEGIN
                             				         DECLARE @LibraryCardNumber NVARCHAR(50); 
                             
                                                     SELECT @LibraryCardNumber = LibraryCardNumber FROM Members
                                                     WHERE MemberID = @MemberID;
                             
                                                     UPDATE LibraryCardNumbers
                                                     SET AvailabilityStatus = 1
                                                     WHERE LibraryCardNumber = @LibraryCardNumber;
                             
                                                     DELETE FROM Members WHERE MemberID = @MemberID
                             				 END
                             
                             
                             		END
                             
                             END";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static bool DeleteMember(string Username)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"   DECLARE @LibraryCardNumber NVARCHAR(50); 

                                SELECT @LibraryCardNumber = LibraryCardNumber FROM Members
                                WHERE Username = @Username;

                                UPDATE LibraryCardNumbers
                                SET AvailabilityStatus = 1
                                WHERE LibraryCardNumber = @LibraryCardNumber;

                                DELETE FROM Members WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);

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


        public static bool IsMemberExistsByID(int MemberID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Members WHERE MemberID = @MemberID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static bool IsMemberExistsByUsername(string Username)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Members WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);

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

        public static bool IsMemberExistsByEmail(string Email)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Members WHERE Email = @Email";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);

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

        public static bool IsMemberExistsByUsernameAndPassword(string Username, string Password)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Members
                             WHERE    Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS 
                             AND
                                      Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);

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

        public static bool IsMemberExistsByEmailAndPassword(string Email, string Password)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Members
                             WHERE    Email = @Email
                             AND
                                      Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);

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

        public static DataTable GetAllMembers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members";

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

        public static DataTable SearchMembersContainsByID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members
                             WHERE (Members.MemberID) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchMembersContainsByName(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members
                             WHERE (Members.FullName) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchMembersContainsByUsername(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members
                             WHERE (Members.Username) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchMembersContainsByEmail(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members
                             WHERE (Members.Email) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchMembersContainsByLibraryCardNumber(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Members
                             WHERE (Members.LibraryCardNumber) LIKE '%' + @Contains + '%';";


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

        public static int GetTotalNumberOfMembers()
        {

            int TotalNumber = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT COUNT (Members.MemberID) FROM Members;";

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
