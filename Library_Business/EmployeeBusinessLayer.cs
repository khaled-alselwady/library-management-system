using LibraryDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryBusinessLayer
{
    public class clsEmployee
    {

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public enum enAssistantPermissions
        {
            //ShowBooksList = 1,
            //AddNewBook = 2,
            //EditBook = 4,
            //ShowBookCopies = 8,
            //ShowAuthorList = 16,
            //AddNewAuthor = 32,
            //EditAuthor = 64,
            //ShowAuthorBooks = 128,
            //ShowGenreList = 265,
            //AddNewGenre = 512,
            //EditGenre = 1024,
            //ShowGenreBooks = 2048,
            //ShowMember

            DeleteBook = 1,
            DeleteAuthor = 2,
            DeleteGenre = 4,
            DeleteMember = 8,
            ShowEmployeesList = 16,
            PayFines = 32


        }
        
        public enum enLibrarianPermissions
        {
            ShowEmployeesList = 1,
        }

        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Permissions { get; set; }


        public clsEmployee()
        {
            EmployeeID = -1;
            Name = string.Empty;
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            PhoneNumber = string.Empty;
            Permissions = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsEmployee(int EmployeeID, string Name, string Username,
                          string Email, string Password, string PhoneNumber,
                          string Permissions)
        {
            this.EmployeeID = EmployeeID;
            this.Name = Name;
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            this.Permissions = Permissions;

            _Mode = enMode.Update;
        }


        private bool _AddNewEmployee()
        {
            this.EmployeeID = clsEmployeeDataAccess.AddNewEmployee(this.Name, this.Username,
                this.Email, this.Password, this.PhoneNumber, this.Permissions);

            return (this.EmployeeID != -1);
        }

        private bool _UpdateEmployee()
        {

            return clsEmployeeDataAccess.UpdateEmployee(this.EmployeeID, this.Name, this.Username,
                this.Email, this.Password, this.PhoneNumber, this.Permissions);

        }

        public static clsEmployee FindByID(int EmployeeID)
        {
            string Name = "", Username = "", Email = "",
                   Password = "", PhoneNumber = "", Permissions = "";


            if (clsEmployeeDataAccess.GetEmployeeInfoByID(EmployeeID, ref Name, ref Username,
                                                           ref Email, ref PhoneNumber, ref Password,
                                                           ref Permissions))
            {
                return new clsEmployee(EmployeeID, Name, Username, Email, Password, PhoneNumber, Permissions);
            }

            else
            {
                return null;
            }
        }

        public static clsEmployee FindByUsername(string Username)
        {
            string Name = "", Email = "",
                   Password = "", PhoneNumber = "", Permissions = "";
            int EmployeeID = -1;

            if (clsEmployeeDataAccess.GetEmployeeInfoByUsername(Username, ref EmployeeID, ref Name,
                                                           ref Email, ref PhoneNumber, ref Password,
                                                           ref Permissions))
            {
                return new clsEmployee(EmployeeID, Name, Username, Email, Password, PhoneNumber, Permissions);
            }

            else
            {
                return null;
            }
        }

        public static clsEmployee FindByEmail(string Email)
        {
            string Name = "", Password = "", Username = "",
                   PhoneNumber = "", Permissions = "";
            int EmployeeID = -1;

            if (clsEmployeeDataAccess.GetEmployeeInfoByEmail(Email, ref EmployeeID, ref Name,
                                                           ref Username, ref Password, ref PhoneNumber,
                                                           ref Permissions))
            {
                return new clsEmployee(EmployeeID, Name, Username, Email, Password, PhoneNumber, Permissions);
            }

            else
            {
                return null;
            }
        }

        public static clsEmployee FindByUsernameAndPassword(string Username, string Password)
        {
            string Name = "", Email = "",
                    PhoneNumber = "", Permissions = "";
            int EmployeeID = -1;

            if (clsEmployeeDataAccess.GetEmployeeInfoByUsernameAndPassword(Username, Password, ref Email,
                                                           ref EmployeeID, ref Name, ref PhoneNumber,
                                                           ref Permissions))
            {
                return new clsEmployee(EmployeeID, Name, Username, Email, Password, PhoneNumber, Permissions);
            }

            else
            {
                return null;
            }
        }

        public static clsEmployee FindByEmailAndPassword(string Email, string Password)
        {
            string Name = "", Username = "",
                    PhoneNumber = "", Permissions = "";
            int EmployeeID = -1;

            if (clsEmployeeDataAccess.GetEmployeeInfoByEmailAndPassword(Email, Password, ref EmployeeID,
                                                           ref Username, ref Name, ref PhoneNumber,
                                                           ref Permissions))
            {
                return new clsEmployee(EmployeeID, Name, Username, Email, Password, PhoneNumber, Permissions);
            }

            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (_Mode)
            {

                case enMode.AddNew:
                    return _AddNewEmployee();


                case enMode.Update:
                    return _UpdateEmployee();

            }

            return false;
        }


        public static bool IsEmployeeExistsByID(int EmployeeID)
        {
            return clsEmployeeDataAccess.IsEmployeeExistsByID(EmployeeID);
        }

        public static bool IsEmployeeExistsByUsername(string Username)
        {
            return clsEmployeeDataAccess.IsEmployeeExistsByUsername(Username);
        }

        public static bool IsEmployeeExistsByEmail(string Email)
        {
            return clsEmployeeDataAccess.IsEmployeeExistsByEmail(Email);
        }

        public static bool IsEmployeeExistsByUsernameAndPassword(string Username, string Password)
        {
            return clsEmployeeDataAccess.IsEmployeeExistsByUsernameAndPassword(Username, Password);
        }

        public static bool IsEmployeeExistsByEmailAndPassword(string Email, string Password)
        {
            return clsEmployeeDataAccess.IsEmployeeExistsByEmailAndPassword(Email, Password);
        }

        public static bool DeleteEmployee(int EmployeeID)
        {
            return clsEmployeeDataAccess.DeleteEmployee(EmployeeID);
        }

        public static bool DeleteEmployee(string Username)
        {
            return clsEmployeeDataAccess.DeleteEmployee(Username);
        }

        public static DataTable GetAllEmployees()
        {
            return clsEmployeeDataAccess.GetAllEmployees();
        }

        public static DataTable SearchEmployeesContainsByID(string Contains)
        {
            return clsEmployeeDataAccess.SearchEmployeesContainsByID(Contains);
        }

        public static DataTable SearchEmployeesContainsByName(string Contains)
        {
            return clsEmployeeDataAccess.SearchEmployeesContainsByName(Contains);
        }

        public static DataTable SearchEmployeesContainsByUsername(string Contains)
        {
            return clsEmployeeDataAccess.SearchEmployeesContainsByUsername(Contains);
        }

        public static DataTable SearchEmployeesContainsByEmail(string Contains)
        {
            return clsEmployeeDataAccess.SearchEmployeesContainsByEmail(Contains);
        }

        public static DataTable SearchEmployeesContainsByPermissions(string Contains)
        {
            return clsEmployeeDataAccess.SearchEmployeesContainsByPermissions(Contains);
        }

        public static int GetTotalNumberOfEmployees()
        {
            return clsEmployeeDataAccess.GetTotalNumberOfEmployees();
        }


    }
}
