using LibraryDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryBusinessLayer
{
    public class clsAuthor
    {

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int AuthorID { get; set; }
        public string FullName { get; set; }
        public string Education { get; set; }
        public string Bio { get; set; }

        public clsAuthor()
        {
            AuthorID = -1;
            FullName = string.Empty;
            Education = string.Empty;
            Bio = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsAuthor(int AuthorID, string FullName, string Education, string Bio)
        {
            this.AuthorID = AuthorID;
            this.FullName = FullName;
            this.Education = Education;
            this.Bio = Bio;

            _Mode = enMode.Update;
        }

        private bool _AddNewAuthor()
        {
            this.AuthorID = clsAuthorDataAccessLayer.AddNewAuthor(this.FullName,
                this.Education, this.Bio);

            return (this.AuthorID != -1);
        }

        private bool _UpdateAuthor()
        {

            return clsAuthorDataAccessLayer.UpdateAuthor(this.AuthorID, this.FullName, this.Education,
                this.Bio);

        }

        public static clsAuthor FindByID(int AuthorID)
        {
            string FullName = "", Education = "", Bio = "";


            if (clsAuthorDataAccessLayer.GetAuthorInfoByID(AuthorID, ref FullName, ref Education,
                                                           ref Bio))
            {
                return new clsAuthor(AuthorID, FullName, Education, Bio);
            }

            else
            {
                return null;
            }
        }

        public static clsAuthor FindByAuthorName(string AuthorName)
        {
            string Education = "", Bio = "";
            int AuthorID = -1;


            if (clsAuthorDataAccessLayer.GetAuthorInfoByAuthorName(AuthorName, ref AuthorID, ref Education,
                                                           ref Bio))
            {
                return new clsAuthor(AuthorID, AuthorName, Education, Bio);
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
                    return _AddNewAuthor();


                case enMode.Update:
                    return _UpdateAuthor();

            }

            return false;
        }

        public static bool IsAuthorExists(int AuthorID)
        {
            return clsAuthorDataAccessLayer.IsAuthorExists(AuthorID);
        }

        public static bool IsAuthorExists(string FullName)
        {
            return clsAuthorDataAccessLayer.IsAuthorExists(FullName);
        }

        public static bool DeleteAuthor(int AuthorID)
        {
            return clsAuthorDataAccessLayer.DeleteAuthor(AuthorID);
        }

        public static DataTable GetAllAuthor()
        {
            return clsAuthorDataAccessLayer.GetAllAuthors();
        }

        public static DataTable SearchAuthorsContainsByID(string Contains)
        {
            return clsAuthorDataAccessLayer.SearchAuthorsContainsByID(Contains);
        }

        public static DataTable SearchAuthorsContainsByName(string Contains)
        {
            return clsAuthorDataAccessLayer.SearchAuthorsContainsByName(Contains);
        }

        public static DataTable SearchAuthorsContainsByEducation(string Contains)
        {
            return clsAuthorDataAccessLayer.SearchAuthorsContainsByEducation(Contains);
        }

        public static int GetTotalNumberOfAuthors()
        {
            return clsAuthorDataAccessLayer.GetTotalNumberOfAuthors();
        }
    }
}
