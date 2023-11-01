using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace LibraryDataAccessLayer
{
    public class clsEmployeeDataAccess
    {
        public static bool GetEmployeeInfoByID(int EmployeeID, ref string FullName, ref string Username,
                                             ref string Email, ref string PhoneNumber, ref string Password,
                                             ref string Permissions)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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

                    Permissions = (string)reader["Permissions"];

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


        public static bool GetEmployeeInfoByUsername(string Username, ref int EmployeeID, ref string FullName,
                                                   ref string Email, ref string PhoneNumber, ref string Password,
                                                    ref string Permissions)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    EmployeeID = (int)reader["EmployeeID"];
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

                    Permissions = (string)reader["Permissions"];

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


        public static bool GetEmployeeInfoByEmail(string Email, ref int EmployeeID, ref string FullName,
                                                ref string Username, ref string Password,
                                                ref string PhoneNumber, ref string Permissions)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees WHERE Email = @Email";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    EmployeeID = (int)reader["EmployeeID"];
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

                    Permissions = (string)reader["Permissions"];

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

        public static bool GetEmployeeInfoByUsernameAndPassword(string Username, string Password,
                                                   ref string Email, ref int EmployeeID, ref string FullName,
                                                   ref string PhoneNumber, ref string Permissions)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees
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

                    EmployeeID = (int)reader["EmployeeID"];
                    FullName = (string)reader["FullName"];
                    Email = (string)reader["Email"];

                    if (reader["PhoneNumber"] != System.DBNull.Value)
                    {
                        PhoneNumber = (string)reader["PhoneNumber"];
                    }
                    else
                    {
                        PhoneNumber = "";
                    }

                    Permissions = (string)reader["Permissions"];

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


        public static bool GetEmployeeInfoByEmailAndPassword(string Email, string Password, ref int EmployeeID,
                                                   ref string Username, ref string FullName,
                                                   ref string PhoneNumber, ref string Permissions)

        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees
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

                    EmployeeID = (int)reader["EmployeeID"];
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

                    Permissions = (string)reader["Permissions"];

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



        public static int AddNewEmployee(string FullName, string Username, string Email,
                                         string Password, string PhoneNumber, string Permissions)
        {

            int EmployeeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"IF NOT EXISTS (SELECT Found = 1 FROM Employees WHERE Username = @Username)
    BEGIN
                                IF NOT EXISTS (SELECT Found = 1 FROM Employees WHERE Email = @Email)
        BEGIN
                                    INSERT INTO Employees (FullName, Username, Email, Password, PhoneNumber, Permissions)
                                    VALUES (@FullName, @Username, @Email, @Password, @PhoneNumber, @Permissions);
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

            command.Parameters.AddWithValue("@Permissions", Permissions);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertID))
                {

                    EmployeeID = insertID;

                }

            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return EmployeeID;

        }


        public static bool UpdateEmployee(int EmployeeID, string FullName, string Username, string Email,
                                          string Password, string PhoneNumber, string Permissions)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Employees
                             SET   FullName        = @FullName, 
                                   Username    = @Username, 
                                   Email       = @Email,
                                   Password    = @Password,
                                   PhoneNumber = @PhoneNumber,
                                   Permissions = @Permissions
                             WHERE EmployeeID  = @EmployeeID;";

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

            command.Parameters.AddWithValue("@Permissions", Permissions);

            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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


        public static bool DeleteEmployee(int EmployeeID)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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

        public static bool DeleteEmployee(string Username)
        {

            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM Employees WHERE Username = @Username";

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


        public static bool IsEmployeeExistsByID(int EmployeeID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Employees WHERE EmployeeID = @EmployeeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

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

        public static bool IsEmployeeExistsByUsername(string Username)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Employees WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS";

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

        public static bool IsEmployeeExistsByEmail(string Email)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Employees WHERE Email = @Email";

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

        public static bool IsEmployeeExistsByUsernameAndPassword(string Username, string Password)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Employees
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

        public static bool IsEmployeeExistsByEmailAndPassword(string Email, string Password)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Employees
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

        public static DataTable GetAllEmployees()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees";

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

        public static DataTable SearchEmployeesContainsByID(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees
                             WHERE (Employees.EmployeeID) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchEmployeesContainsByName(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees
                             WHERE (Employees.FullName) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchEmployeesContainsByUsername(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees
                             WHERE (Employees.Username) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchEmployeesContainsByEmail(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees
                             WHERE (Employees.Email) LIKE '%' + @Contains + '%';";


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

        public static DataTable SearchEmployeesContainsByPermissions(string Contains)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Employees
                             WHERE (Employees.Permissions) LIKE '%' + @Contains + '%';";


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

        public static int GetTotalNumberOfEmployees()
        {

            int TotalNumber = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT COUNT (Employees.EmployeeID) FROM Employees;";

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
