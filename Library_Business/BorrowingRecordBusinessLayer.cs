using LibraryDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer
{
    public class clsBorrowingRecord
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int BorrowingRecordID { get; set; }
        public int MemberID { get; set; }
        public int CopyID { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ActualReturnDate { get; set; }

        public clsBorrowingRecord()
        {
            this.BorrowingRecordID = -1;
            this.MemberID = -1;
            this.CopyID = -1;
            this.BorrowingDate = DateTime.MinValue;
            this.DueDate = DateTime.MinValue;
            this.ActualReturnDate = DateTime.MinValue;

            Mode = enMode.AddNew;
        }

        private clsBorrowingRecord(int borrowingRecordID, int memberID, int copyID,
            DateTime borrowingDate, DateTime dueDate, DateTime actualReturnDate)
        {
            this.BorrowingRecordID = borrowingRecordID;
            this.MemberID = memberID;
            this.CopyID = copyID;
            this.BorrowingDate = borrowingDate;
            this.DueDate = dueDate;
            this.ActualReturnDate = actualReturnDate;

            Mode = enMode.Update;
        }

        private bool _AddNewBorrowingRecord()
        {
            this.BorrowingRecordID = clsBorrowingRecordDataAccessLayer.AddNewBorrowingRecord(this.MemberID, this.CopyID, this.BorrowingDate, this.DueDate, this.ActualReturnDate);

            return (this.BorrowingRecordID != -1);
        }

        private bool _UpdateBorrowingRecord()
        {
            return clsBorrowingRecordDataAccessLayer.UpdateBorrowingRecord(this.BorrowingRecordID,
                this.MemberID, this.CopyID, this.BorrowingDate, this.DueDate, this.ActualReturnDate);
        }

        public bool Save()
        {
            switch (Mode)
            {

                case enMode.AddNew:
                    return _AddNewBorrowingRecord();

                case enMode.Update:
                    return _UpdateBorrowingRecord();

            }

            return false;
        }


        public static clsBorrowingRecord FindByID(int BorrowingRecordID)
        {
            int MemberID = -1, CopyID = -1;

            DateTime borrowingDate = DateTime.MinValue,
                dueDate = DateTime.MinValue,
                actualReturnDate = DateTime.MinValue;

            if (clsBorrowingRecordDataAccessLayer.GetBorrowingRecordInfoByID(BorrowingRecordID,
                ref MemberID, ref CopyID, ref borrowingDate, ref dueDate, ref actualReturnDate))
            {
                return new clsBorrowingRecord(BorrowingRecordID, MemberID, CopyID,
                    borrowingDate, dueDate, actualReturnDate);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteBorrowingRecord(int BorrowingRecordID)
        {
            return clsBorrowingRecordDataAccessLayer.DeleteBorrowingRecord(BorrowingRecordID);
        }

        public static DataTable GetAllBorrowingRecords()
        {
            return clsBorrowingRecordDataAccessLayer.GetAllBorrowingRecords();
        }

        public static DataTable GetAllBorrowingRecordsOfSpecificMember(int MemberID)
        {
            return clsBorrowingRecordDataAccessLayer.GetAllBorrowingRecordsOfSpecificMember(MemberID);
        }

        public static DataTable SearchBorrowingRecordsContains(string Contains)
        {
            return clsBorrowingRecordDataAccessLayer.SearchBorrowingRecordsContains(Contains);
        }

        public static DataTable SearchBorrowingRecordsContainsOfSpecificMember(string Contains, int MemberID)
        {
            return clsBorrowingRecordDataAccessLayer.SearchBorrowingRecordsContainsOfSpecificMember(Contains, MemberID);
        }

    }
}
