using LibraryDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer
{
    public class clsGenre
    {

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public int GenreID { get; set; }
        public string GenreName { get; set; }

        public clsGenre()
        {
            GenreID = -1;
            GenreName = string.Empty;

            _Mode = enMode.AddNew;
        }

        private clsGenre(int BookID, string GenreName)
        {
            this.GenreID = BookID;
            this.GenreName = GenreName;
           
            _Mode = enMode.Update;
        }

        private bool AddNewGenre()
        {
            this.GenreID = clsGenreDataAccessLayer.AddNewGenre(this.GenreName);
                                                          

            return (this.GenreID != -1);
        }

        private bool UpdateBook()
        {
            return clsGenreDataAccessLayer.UpdateGenre(this.GenreID, this.GenreName);
        }


        public static clsGenre FindByID(int GenreID)
        {
            string GenreName = "";

            if (clsGenreDataAccessLayer.GetGenreInfoByID(GenreID, ref GenreName))
            {
                return new clsGenre(GenreID, GenreName);
            }
            else
            {
                return null;
            }

        }

        public static clsGenre FindByGenreName(string GenreName)
        {
            int GenreID = -1;

            if (clsGenreDataAccessLayer.GetGenreInfoByGenreName(GenreName, ref GenreID))
            {
                return new clsGenre(GenreID, GenreName);
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
                    return AddNewGenre();

                case enMode.Update:
                    return UpdateBook();
            }

            return false;
        }

        public static bool DeleteGenre(int GenreID)
        {
            return clsGenreDataAccessLayer.DeleteGenre(GenreID);
        }
       
        public static DataTable GetAllGenres()
        {
            return clsGenreDataAccessLayer.GetAllGenres();
        }

        public static DataTable SearchGenresContains(string Contains)
        {
            return clsGenreDataAccessLayer.SearchGenresContains(Contains);
        }

        public static bool IsGenreExists(int GenreID)
        {
            return clsGenreDataAccessLayer.IsGenreExists(GenreID);
        }

        public static bool IsGenreExists(string GenreName)
        {
            return clsGenreDataAccessLayer.IsGenreExists(GenreName);
        }

    }
}
