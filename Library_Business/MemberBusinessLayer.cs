using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibraryDataAccessLayer;

namespace LibraryBusinessLayer
{
    public class clsMember
    {

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string LibraryCardNumber { get; set; }


        public clsMember()
        {
            MemberID = -1;
            Name = string.Empty;
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            PhoneNumber = string.Empty;
            LibraryCardNumber = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsMember(int MemberID, string Name, string Username,
                          string Email, string Password, string PhoneNumber,
                          string LibraryCardNumber)
        {
            this.MemberID = MemberID;
            this.Name = Name;
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;
            this.LibraryCardNumber = LibraryCardNumber;

            _Mode = enMode.Update;
        }


        private bool _AddNewMember()
        {
            this.MemberID = clsMemberDataAccessLayer.AddNewMember(this.Name, this.Username,
                this.Email, this.Password, this.PhoneNumber);

            return (this.MemberID != -1);

        }

        private bool _UpdateMember()
        {
            return clsMemberDataAccessLayer.UpdateMember(this.MemberID, this.Name,
                                                         this.Username, this.Email,
                                                         this.Password, this.PhoneNumber);
        }

        public static clsMember FindByID(int MemberID)
        {
            string Name = "", Username = "", Email = "",
                   Password = "", PhoneNumber = "", LibraryCardNumber = "";

            if (clsMemberDataAccessLayer.GetMemberInfoByID(MemberID, ref Name, ref Username,
                                                           ref Email, ref Password, ref PhoneNumber,
                                                           ref LibraryCardNumber))
            {
                return new clsMember(MemberID, Name, Username, Email, Password, PhoneNumber, LibraryCardNumber);
            }

            else
            {
                return null;
            }
        }

        public static clsMember FindByUsername(string Username)
        {
            string Name = "", Email = "",
                   Password = "", PhoneNumber = "", LibraryCardNumber = "";
            int MemberID = -1;

            if (clsMemberDataAccessLayer.GetMemberInfoByUsername(Username, ref MemberID, ref Name,
                                                           ref Email, ref Password, ref PhoneNumber,
                                                           ref LibraryCardNumber))
            {
                return new clsMember(MemberID, Name, Username, Email, Password, PhoneNumber, LibraryCardNumber);
            }

            else
            {
                return null;
            }
        }

        public static clsMember FindByEmail(string Email)
        {
            string Name = "", Password = "", Username = "",
                   PhoneNumber = "", LibraryCardNumber = "";
            int MemberID = -1;

            if (clsMemberDataAccessLayer.GetMemberInfoByEmail(Email, ref MemberID, ref Name,
                                                           ref Username, ref Password, ref PhoneNumber,
                                                           ref LibraryCardNumber))
            {
                return new clsMember(MemberID, Name, Username, Email, Password, PhoneNumber, LibraryCardNumber);
            }

            else
            {
                return null;
            }
        }

        public static clsMember FindByLibraryCardNumber(string LibraryCardNumber)
        {
            string Name = "", Password = "", Username = "",
                   Email = "", PhoneNumber = "";
            int MemberID = -1;

            if (clsMemberDataAccessLayer.GetMemberInfoByLibraryCardNumber(LibraryCardNumber,
                                                                          ref MemberID, ref Name,
                                                                          ref Username, ref Email,
                                                                          ref Password,
                                                                          ref PhoneNumber))
            {
                return new clsMember(MemberID, Name, Username, Email, Password, PhoneNumber, LibraryCardNumber);
            }

            else
            {
                return null;
            }
        }

        public static clsMember FindByUsernameAndPassword(string Username, string Password)
        {
            string Name = "", Email = "",
                    PhoneNumber = "", LibraryCardNumber = "";
            int MemberID = -1;

            if (clsMemberDataAccessLayer.GetMemberInfoByUsernameAndPassword(Username, Password, ref Email,
                                                           ref MemberID, ref Name, ref PhoneNumber,
                                                           ref LibraryCardNumber))
            {
                return new clsMember(MemberID, Name, Username, Email, Password, PhoneNumber, LibraryCardNumber);
            }

            else
            {
                return null;
            }
        }

        public static clsMember FindByEmailAndPassword(string Email, string Password)
        {
            string Name = "", Username = "",
                    PhoneNumber = "", LibraryCardNumber = "";
            int MemberID = -1;

            if (clsMemberDataAccessLayer.GetMemberInfoByEmailAndPassword(Email, Password, ref MemberID,
                                                           ref Username, ref Name, ref PhoneNumber,
                                                           ref LibraryCardNumber))
            {
                return new clsMember(MemberID, Name, Username, Email, Password, PhoneNumber, LibraryCardNumber);
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

                    return _AddNewMember();


                case enMode.Update:
                    return _UpdateMember();

            }

            return false;
        }

        public static bool IsMemberExistsByID(int MemberID)
        {
            return clsMemberDataAccessLayer.IsMemberExistsByID(MemberID);
        }

        public static bool IsMemberExistsByUsername(string Username)
        {
            return clsMemberDataAccessLayer.IsMemberExistsByUsername(Username);
        }

        public static bool IsMemberExistsByEmail(string Email)
        {
            return clsMemberDataAccessLayer.IsMemberExistsByEmail(Email);
        }

        public static bool IsMemberExistsByUsernameAndPassword(string Username, string Password)
        {
            return clsMemberDataAccessLayer.IsMemberExistsByUsernameAndPassword(Username, Password);
        }

        public static bool IsMemberExistsByEmailAndPassword(string Email, string Password)
        {
            return clsMemberDataAccessLayer.IsMemberExistsByEmailAndPassword(Email, Password);
        }

        public static bool DeleteMember(int MemberID)
        {
            return clsMemberDataAccessLayer.DeleteMember(MemberID);
        }

        public static bool DeleteMember(string Username)
        {
            return clsMemberDataAccessLayer.DeleteMember(Username);
        }

        public static DataTable GetAllMembers()
        {
            return clsMemberDataAccessLayer.GetAllMembers();
        }

        public static DataTable SearchMembersContainsByID(string Contains)
        {
            return clsMemberDataAccessLayer.SearchMembersContainsByID(Contains);
        }

        public static DataTable SearchMembersContainsByName(string Contains)
        {
            return clsMemberDataAccessLayer.SearchMembersContainsByName(Contains);
        }

        public static DataTable SearchMembersContainsByUsername(string Contains)
        {
            return clsMemberDataAccessLayer.SearchMembersContainsByUsername(Contains);
        }

        public static DataTable SearchMembersContainsByEmail(string Contains)
        {
            return clsMemberDataAccessLayer.SearchMembersContainsByEmail(Contains);
        }

        public static DataTable SearchMembersContainsByLibraryCardNumber(string Contains)
        {
            return clsMemberDataAccessLayer.SearchMembersContainsByLibraryCardNumber(Contains);
        }

        public static int GetAllNumberOfMembers()
        {
            return clsMemberDataAccessLayer.GetTotalNumberOfMembers();
        }
    }
}
