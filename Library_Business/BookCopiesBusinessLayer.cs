using LibraryDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer
{
    public class clsBookCopies
    {

        enum enMode { AddNew = 0, Update = 1}
        enMode _Mode = enMode.AddNew;

        public int CopyID { get; set; }
        public int BookID { get; set; }
        public bool AvailabilityStatus { get; set; }

        public clsBookCopies()
        {
            CopyID = -1;
            BookID = -1;
            AvailabilityStatus = false;

            _Mode = enMode.AddNew;
        }

        private clsBookCopies(int CopyID, int BookID, bool AvailabilityStatus)
        {
            this.CopyID = CopyID;
            this.BookID = BookID;
            this.AvailabilityStatus = AvailabilityStatus;

            _Mode = enMode.Update;
        }

        //private bool AddNewBoolCopies()
        //{
        //    return clsBookCopiesDataAccessLayer.UpdateBookCopies(this.CopyID,
        //           this.BookID, this.AvailabilityStatus);
        //}

        private bool _UpdateBoolCopies()
        {
            return clsBookCopiesDataAccessLayer.UpdateBookCopies(this.CopyID,
                   this.BookID, this.AvailabilityStatus);
        }

        public static clsBookCopies FindCopyByIDCopy(int CopyID)
        {
            int BookID = -1;
            bool AvailabilityStatus = false;

            if (clsBookCopiesDataAccessLayer.GetBookCopiesInfoByCopyID(CopyID,ref BookID,ref AvailabilityStatus))
            {
                return new clsBookCopies(CopyID, BookID, AvailabilityStatus);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllCopiesOfSpecificBook(int BookID)
        {
            return clsBookCopiesDataAccessLayer.GetAllCopiesOfSpecificBook(BookID);
        }

        public static clsBookCopies GetTheFirstCopyAvailableInfoOfSpecificBook(int BookID)
        {
            int CopyID = -1;
            bool AvailabilityStatus = false;

            if (clsBookCopiesDataAccessLayer.GetTheFirstCopyAvailableInfoOfSpecificBook(BookID,ref CopyID,ref AvailabilityStatus))
            {
                return new clsBookCopies(CopyID, BookID, AvailabilityStatus);
            }
            else
            {
                return null;
            }

        }

        public static clsBookCopies GetTheFirstCopyInfoOfSpecificBook(int BookID)
        {
            int CopyID = -1;
            bool AvailabilityStatus = false;

            if (clsBookCopiesDataAccessLayer.GetTheFirstCopyInfoOfSpecificBook(BookID, ref CopyID, ref AvailabilityStatus))
            {
                return new clsBookCopies(CopyID, BookID, AvailabilityStatus);
            }
            else
            {
                return null;
            }

        }

        public static bool IsThereCopyBookAvailable(int BookID)
        {
            return clsBookCopiesDataAccessLayer.IsThereCopyBookAvailable(BookID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Update:
                    return _UpdateBoolCopies();


            }

            return false;
        }

    }
}
