using LibraryDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer
{
    public class clsFines
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public const decimal DefaultFinePerDay = 3m;

        public int FineID { get; set; }
        public int MemberID { get; set; }
        public int BorrowingRecordID { get; set; }
        public short NumberOfLateDays { get; set; }
        public decimal FineAmount { get; set; }
        public bool PaymentStatus { get; set; }

        public clsFines()
        {
            this.FineID = -1;
            this.MemberID = -1;
            this.BorrowingRecordID = -1;
            this.NumberOfLateDays = -1;
            this.FineAmount = -1;
            this.PaymentStatus = false;

            _Mode = enMode.AddNew;
        }

        private clsFines(int fineID, int memberID, int borrowingRecordID,
            short numberOfLateDays, decimal fineAmount, bool paymentStatus)
        {

            this.FineID = fineID;
            this.MemberID = memberID;
            this.BorrowingRecordID = borrowingRecordID;
            this.NumberOfLateDays = numberOfLateDays;
            this.FineAmount = fineAmount;
            this.PaymentStatus = paymentStatus;

            _Mode = enMode.Update;
        }


        private bool _UpdateFine()
        {
            return clsFinesDataAccessLayer.UpdateFines(this.FineID, this.MemberID, this.BorrowingRecordID,
                this.NumberOfLateDays, this.FineAmount, this.PaymentStatus);
        }

        private bool _AddNewFine()
        {
            this.FineID = clsFinesDataAccessLayer.AddNewFine(this.MemberID, this.BorrowingRecordID,
                this.NumberOfLateDays, this.FineAmount, this.PaymentStatus);

            return (this.FineID != -1);
        }

        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNewFine();

                case enMode.Update:
                    return _UpdateFine();

            }

            return false;
        }

        public static clsFines FindByID(int FineID)
        {
            int memberID = -1, borrowingRecordID = -1;
            short numberOfLateDays = -1;
            decimal fineAmount = 0;
            bool paymentStatus = false;

            if (clsFinesDataAccessLayer.GetFineInfoByID(FineID,ref  memberID,ref borrowingRecordID,ref numberOfLateDays,ref fineAmount,ref paymentStatus))
            {
                return new clsFines(FineID,memberID, borrowingRecordID, numberOfLateDays, fineAmount,paymentStatus); ;
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllFines()
        {
            return clsFinesDataAccessLayer.GetAllFines();
        }

        public static DataTable GetAllFinesOfSpecificMember(int MemberID)
        {
            return clsFinesDataAccessLayer.GetAllFinesOfSpecificMember(MemberID);
        }

        public static DataTable SearchFinesContains(string Contains)
        {
            return clsFinesDataAccessLayer.SearchFinesContains(Contains);
        }

        public static DataTable SearchFinesContainsOfSpecificMember(string Contains, int MemberID)
        {
            return clsFinesDataAccessLayer.SearchFinesContainsOfSpecificMember(Contains, MemberID);
        }

    }
}
