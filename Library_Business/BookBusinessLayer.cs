using LibraryDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer
{
    public class clsBook
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int BooKID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int GenreID { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AdditionalDetails { get; set; }


        public clsBook()
        {
            BooKID = -1;
            Title = string.Empty;
            AuthorID = -1;
            GenreID = -1;
            ISBN = string.Empty;
            Quantity = 0;
            PublicationDate = DateTime.MinValue;
            AdditionalDetails = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsBook(int BookID, string Title, int AuthorID, int GenreID,
            DateTime PublicationDate, string ISBN, int Quantity, string AdditionalDetails)
        {
            this.BooKID = BookID;
            this.Title = Title;
            this.AuthorID = AuthorID;
            this.GenreID = GenreID;
            this.ISBN = ISBN;
            this.Quantity = Quantity;
            this.PublicationDate = PublicationDate;
            this.AdditionalDetails = AdditionalDetails;

            _Mode = enMode.Update;
        }

        private bool AddNewBook()
        {
            this.BooKID = clsBookDataAccessLayer.AddNewBook(this.Title, this.AuthorID,
                                                            this.GenreID, this.PublicationDate,
                                                            this.ISBN, this.Quantity, this.AdditionalDetails);

            return (this.BooKID != -1);
        }

        private bool UpdateBook()
        {
            return clsBookDataAccessLayer.UpdateBook(this.BooKID, this.Title, this.AuthorID,
                                                     this.GenreID, this.PublicationDate,
                                                     this.ISBN, this.Quantity, this.AdditionalDetails);
        }


        public static clsBook FindByID(int BookID)
        {
            string Title = "", ISBN = "", AdditionalDetails = "";
            DateTime PublicationDate = DateTime.MinValue;
            int AuthorID = -1, GenreID = -1, Quantity = 0;

            if (clsBookDataAccessLayer.GetBooKInfoByID(BookID, ref Title, ref AuthorID, ref GenreID,
                                                        ref PublicationDate, ref ISBN, ref Quantity,
                                                        ref AdditionalDetails))
            {
                return new clsBook(BookID, Title, AuthorID, GenreID,
                    PublicationDate, ISBN, Quantity, AdditionalDetails);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllBooKsWithTheSameTitle(string Title)
        {
            return clsBookDataAccessLayer.GetAllBooKsWithTheSameTitle(Title);
        }

        public static DataTable GetAllBooKsWithTheSameAuthor(int AuthorID)
        {
            return clsBookDataAccessLayer.GetAllBooKsWithTheSameAuthor(AuthorID);
        }

        public static DataTable GetAllBooKsWithTheSameGenre(int GenreID)
        {
            return clsBookDataAccessLayer.GetAllBooKsWithTheSameGenre(GenreID);
        }

        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:
                    return AddNewBook();

                case enMode.Update:
                    return UpdateBook();
            }

            return false;
        }

        public static bool DeleteBook(int BookID)
        {
            return clsBookDataAccessLayer.DeleteBooK(BookID);
        }

        public static bool IsBookExists(int BookID)
        {
            return clsBookDataAccessLayer.IsBookExists(BookID);
        }

        public static bool IsBookExists(string ISBN)
        {
            return clsBookDataAccessLayer.IsBookExists(ISBN);
        }

        public static DataTable GetAllBooks()
        {
            return clsBookDataAccessLayer.GetAllBooks();
        }

        public static DataTable GetAllBooksWithoutQuantity()
        {
            return clsBookDataAccessLayer.GetAllBooksWithoutQuantity();
        }

        public static DataTable SearchBooksContainsByID(string Contains)
        {
            return clsBookDataAccessLayer.SearchBooksContainsByID(Contains);
        }

        public static DataTable SearchBooksContainsByTitle(string Contains)
        {
            return clsBookDataAccessLayer.SearchBooksContainsByTitle(Contains);
        }

        public static DataTable SearchBooksContainsByAuthor(string Contains)
        {
            return clsBookDataAccessLayer.SearchBooksContainsByAuthor(Contains);
        }

        public static DataTable SearchBooksContainsByGenre(string Contains)
        {
            return clsBookDataAccessLayer.SearchBooksContainsByGenre(Contains);
        }

        public static DataTable SearchBooksContainsByIDWithoutQuantity(string Contains)
        {
            return clsBookDataAccessLayer.SearchBooksContainsByIDWithoutQuantity(Contains);
        }

        public static DataTable SearchBooksContainsByTitleWithoutQuantity(string Contains)
        {
            return clsBookDataAccessLayer.SearchBooksContainsByTitleWithoutQuantity(Contains);
        }

        public static DataTable SearchBooksContainsByAuthorWithoutQuantity(string Contains)
        {
            return clsBookDataAccessLayer.SearchBooksContainsByAuthorWithoutQuantity(Contains);
        }

        public static DataTable SearchBooksContainsByGenreWithoutQuantity(string Contains)
        {
            return clsBookDataAccessLayer.SearchBooksContainsByGenreWithoutQuantity(Contains);
        }

        public static int GetTotalNumberOfBooks()
        {
            return clsBookDataAccessLayer.GetTotalNumberOfBooks();
        }

    }
}
