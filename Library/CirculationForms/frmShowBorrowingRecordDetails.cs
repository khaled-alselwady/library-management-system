using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem_WindowsForms_.CirculationForms
{
    public partial class frmShowBorrowingRecordDetails : Form
    {

        private int _BorrowingRecordID;
        private clsBorrowingRecord _BorrowingRecord;

        public frmShowBorrowingRecordDetails(int BorrowingRecordID)
        {
            InitializeComponent();

            this._BorrowingRecordID = BorrowingRecordID;

            _BorrowingRecord = clsBorrowingRecord.FindByID(this._BorrowingRecordID);

        }

        private void _ShowBookInfo()
        {
            int BookID = clsBookCopies.FindCopyByIDCopy(_BorrowingRecord.CopyID).BookID;

            clsBook book = clsBook.FindByID(BookID);


            if (book != null)
            {
                string AuthorName = clsAuthor.FindByID(BookID).FullName;
                string GenreName = clsGenre.FindByID(BookID).GenreName;

                lblBookID.Text = BookID.ToString();
                lblCopyID.Text = _BorrowingRecord.CopyID.ToString();
                lblTitle.Text = book.Title;
                lblAuthor.Text = AuthorName;
                lblGenre.Text = GenreName;
                lblISBN.Text = book.ISBN;
                lblPublicationDate.Text = book.PublicationDate.ToString("dd/MM/yyyy");
                lblQuantity.Text = book.Quantity.ToString();
            }

        }

        private void _ShowMemberInfo()
        {
            clsMember member = clsMember.FindByID(_BorrowingRecord.MemberID);

            if (member != null)
            {
                lblMemberID.Text = member.MemberID.ToString();
                lblFullName.Text = member.Name;
                lblUsername.Text = member.Username;
                lblEmail.Text = member.Email;
                lblPassword.Text = member.Password;
                lblPhoneNumber.Text = member.PhoneNumber;
                lblCardNumber.Text = member.LibraryCardNumber;
            }

        }

        private void _ShowBorrowingRecordInfo()
        {

            if (_BorrowingRecord != null)
            {
                lblBorrowingRecordID.Text = _BorrowingRecordID.ToString();

                lblBorrowingDate.Text = _BorrowingRecord.BorrowingDate.ToString("dd/MM/yyyy");
                lblDueDate.Text = _BorrowingRecord.DueDate.ToString("dd/MM/yyyy");

                if (_BorrowingRecord.ActualReturnDate == DateTime.MinValue)
                {
                    lblActualReturnDate.Text = "";

                    btnYesNoAvailable.IconColor = Color.Red;
                    btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Xmark;
                }
                else
                {
                    lblActualReturnDate.Text = _BorrowingRecord.ActualReturnDate.ToString("dd/MM/yyyy");
                    btnYesNoAvailable.IconColor = Color.DarkGreen;
                    btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Check;

                }

            }

        }

        private void _LoadDate()
        {
            _ShowBookInfo();
            _ShowMemberInfo();
            _ShowBorrowingRecordInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmShowBorrowingRecordDetails_Load(object sender, EventArgs e)
        {
            _LoadDate();
        }
    }
}
