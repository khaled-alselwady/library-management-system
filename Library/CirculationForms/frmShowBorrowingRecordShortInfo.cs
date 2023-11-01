using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem_WindowsForms_.CirculationForms
{
    public partial class frmShowBorrowingRecordShortInfo : Form
    {

        private int _BorrowingRecordID;

        public frmShowBorrowingRecordShortInfo(int BorrowingRecordID)
        {
            InitializeComponent();

            this._BorrowingRecordID = BorrowingRecordID;
        }

        private void _ShowBorrowingRecordInfo()
        {
            clsBorrowingRecord borrowingrecord = clsBorrowingRecord.FindByID(_BorrowingRecordID);

            if (borrowingrecord != null)
            {
                lblBorrowingRecordID.Text = _BorrowingRecordID.ToString();
                lblMemberID.Text = borrowingrecord.MemberID.ToString();
                lblCopyID.Text = borrowingrecord.CopyID.ToString();
                lblBorrowingDate.Text = borrowingrecord.BorrowingDate.ToString("dd/MM/yyyy");
                lblDueDate.Text = borrowingrecord.DueDate.ToString("dd/MM/yyyy");
                lblActualReturnDate.Text = borrowingrecord.ActualReturnDate.ToString("dd/MM/yyyy");
            }

        }

        private void frmShowBorrowingRecordShortInfo_Load(object sender, EventArgs e)
        {
            _ShowBorrowingRecordInfo();
        }
    }
}
