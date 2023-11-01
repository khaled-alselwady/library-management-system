using LibraryDataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusinessLayer
{
    public class clsReservation
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int ReservationID { get; set; }
        public int MemberID { get; set; }
        public int CopyID { get; set; }
        public DateTime ReservationDate { get; set; }

        public clsReservation()
        {
            this.ReservationID = -1;
            this.MemberID = -1;
            this.CopyID = -1;
            this.ReservationDate = DateTime.MinValue;

            Mode = enMode.AddNew;
        }

        private clsReservation(int reservationID, int memberID, int copyID, DateTime reservationDate)
        {
            this.ReservationID = reservationID;
            this.MemberID = memberID;
            this.CopyID = copyID;
            this.ReservationDate = reservationDate;

            Mode = enMode.Update;
        }


        private bool _AddNewReservation()
        {
            this.ReservationID = clsReservationsDataAccessLayer.AddNewReservation(this.MemberID,
                this.CopyID, this.ReservationDate);

            return (this.ReservationID != -1);
        }

        private bool _UpdateReservation()
        {
            return clsReservationsDataAccessLayer.UpdateReservation(this.ReservationID,
                this.MemberID, this.CopyID, this.ReservationDate);
        }

        public static clsReservation FindByID(int ReservationID)
        {
            int MemberID = -1, CopyID = -1;
            DateTime ReservationDate = DateTime.MinValue;

            if (clsReservationsDataAccessLayer.GetReservationInfoByID(ReservationID, ref MemberID, ref CopyID, ref ReservationDate))
            {
                return new clsReservation(ReservationID, MemberID, CopyID, ReservationDate);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return _AddNewReservation();

                case enMode.Update:
                    return _UpdateReservation();

            }

            return false;

        }

        public static bool DeleteReservation(int ReservationID)
        {
            return clsReservationsDataAccessLayer.DeleteReservation(ReservationID);
        }

        public static DataTable GetAllReservations()
        {
            return clsReservationsDataAccessLayer.GetAllReservations();
        }

        public static DataTable GetAllReservationsOfSpecificMember(int MemberID)
        {
            return clsReservationsDataAccessLayer.GetAllReservationsOfSpecificMember(MemberID);
        }

        public static DataTable SearchReservationsContains(string Contains)
        {
            return clsReservationsDataAccessLayer.SearchReservationsContains(Contains);
        }

        public static DataTable SearchReservationsContainsOfSpecificMember(string Contains, int MemberID)
        {
            return clsReservationsDataAccessLayer.SearchReservationsContainsOfSpecificMember(Contains, MemberID);
        }

    }
}
