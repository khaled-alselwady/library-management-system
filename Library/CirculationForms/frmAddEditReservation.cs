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
    public partial class frmAddEditReservation : Form
    {

        private int _ReservationID;
        private clsReservation _Reservation;
        private int _MemberID;

        enum enModeForm { FromMember, FromEmployee }
        enModeForm _ModeForm = enModeForm.FromEmployee;

        enum enModeAddUpdate { AddNew = 0, Update = 1 }
        enModeAddUpdate _ModeAddUpdate = enModeAddUpdate.AddNew;

        

        public frmAddEditReservation(int ReservationID)
        {
            InitializeComponent();

            this._ReservationID = ReservationID;

            if (_ReservationID != -1)
            {
                _ModeAddUpdate = enModeAddUpdate.Update;
            }
            else
            {
                _ModeAddUpdate = enModeAddUpdate.AddNew;
            }

        }

        public frmAddEditReservation(int MemberID, int ReservationID)
        {
            InitializeComponent();

            this._MemberID = MemberID;
            this._ReservationID = ReservationID;

            _ModeForm = enModeForm.FromMember;

            if (_ReservationID != -1)
            {
                _ModeAddUpdate = enModeAddUpdate.Update;
            }
            else
            {
                _ModeAddUpdate = enModeAddUpdate.AddNew;
            }

        }

        private void _FillTextBoxesWithReservationInfo()
        {
            int BookID = clsBookCopies.FindCopyByIDCopy(_Reservation.CopyID).BookID;

            numericMemberID.Value = _Reservation.MemberID;
            numericBookID.Value = BookID;
            dtpReservationDate.Value = _Reservation.ReservationDate;
        }

        private void _LoadData()
        {

            if (_ModeForm == enModeForm.FromMember)
            {
                numericMemberID.Enabled = false;
                numericMemberID.Value = _MemberID;
            }

            if (_ModeAddUpdate == enModeAddUpdate.AddNew)
            {
                lblMode.Text = "ADD NEW RESERVATION";
                this.Tag = "ADD NEW RESERVATION";      
                _Reservation = new clsReservation();
                return;
            }
            

            _Reservation = clsReservation.FindByID(this._ReservationID);

            if (_Reservation == null)
            {
                MessageBox.Show("This form will be closed because No Borrowing Record with ID = " + _ReservationID);
                this.Close();

                return;
            }

            lblMode.Text = "UPDATE RESERVATION";
            this.Tag = "UPDATE RESERVATION";
            _FillTextBoxesWithReservationInfo();
        }

        private bool _IsMemberIDCorrect()
        {
            if (string.IsNullOrWhiteSpace(numericMemberID.Text) || numericMemberID.Value <= 0)
            {
                MessageBox.Show("Please enter Correct ID.",
                    "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericMemberID.Focus();

                dgvShowMemberInfo.DataSource = new DataTable();

                return false;
            }


            if (!clsMember.IsMemberExistsByID((int)numericMemberID.Value))
            {
                MessageBox.Show("Member ID is not found, Choose another one.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericMemberID.Focus();

                dgvShowMemberInfo.DataSource = new DataTable();

                return false;
            }
            else
            {
                return true;
            }
        }

        private bool _IsBookIDCorrect()
        {
            if (string.IsNullOrWhiteSpace(numericBookID.Text) || numericBookID.Value <= 0)
            {
                MessageBox.Show("Please enter Correct ID.",
                    "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericBookID.Focus();

                dgvShowBookInfo.DataSource = new DataTable();

                return false;
            }


            if (!clsBook.IsBookExists((int)numericBookID.Value))
            {
                MessageBox.Show("Book ID is not found, Choose another one.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericBookID.Focus();

                dgvShowBookInfo.DataSource = new DataTable();

                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditReservation_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsBookIDCorrect() || !_IsMemberIDCorrect())
            {
                MessageBox.Show("The input is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpReservationDate.Value < DateTime.Today)
            {
                MessageBox.Show("The Reservation Date is old. Choose the newest date!",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);

                dtpReservationDate.Focus();

                return;
            }

            if (clsBookCopies.IsThereCopyBookAvailable((int)numericBookID.Value))
            {
                MessageBox.Show("There is already a copy of this book available, so there is no need to reserve it.", "Available Copy");
                return;
            }

            clsBookCopies copy = clsBookCopies.GetTheFirstCopyInfoOfSpecificBook((int)numericBookID.Value);

            _Reservation.MemberID = (int)numericMemberID.Value;
            _Reservation.CopyID = copy.CopyID;
            _Reservation.ReservationDate = dtpReservationDate.Value;

            if (_Reservation.Save())
            {
                MessageBox.Show("Reservation Done Successfully.",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMode.Text = "UPDATE RESERVATION";
                _ModeAddUpdate = enModeAddUpdate.Update;
                _Reservation.Mode = clsReservation.enMode.Update;
            }

            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnShowMemberInfo_Click(object sender, EventArgs e)
        {
            if (btnShowMemberInfo.Text == "Show Info")
            {
                dgvShowMemberInfo.Visible = true;

                if (!_IsMemberIDCorrect())
                {
                    return;
                }

                else
                {

                    clsMember member = clsMember.FindByID((int)numericMemberID.Value);

                    //frmShowMemberShortInfo membershortinfoform = new frmShowMemberShortInfo(member.MemberID);
                    //membershortinfoform.ShowDialog();

                    DataTable dt = new DataTable();

                    //Add Columns to DataTable
                    dt.Columns.Add("MemberID", typeof(int));
                    dt.Columns.Add("FullName", typeof(string));
                    dt.Columns.Add("Username", typeof(string));
                    dt.Columns.Add("Email", typeof(string));
                    dt.Columns.Add("Password", typeof(string));
                    //dt.Columns.Add("PhoneNumber", typeof(string));
                    dt.Columns.Add("LibraryCardNumber", typeof(string));


                    //Add Rows to the DataTable
                    dt.Rows.Add(member.MemberID, member.Name,
                                member.Username, member.Email,
                                member.Password,
                                member.LibraryCardNumber);

                    dgvShowMemberInfo.DataSource = dt;
                }

                //to change mode of show info button
                btnShowMemberInfo.Text = "Hide Info";
                btnShowMemberInfo.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }

            else
            {
                dgvShowMemberInfo.Visible = false;

                //to change mode of show info button
                btnShowMemberInfo.Text = "Show Info";
                btnShowMemberInfo.IconChar = FontAwesome.Sharp.IconChar.Eye;

            }
        }

        private void btnShowBookCopyInfo_Click(object sender, EventArgs e)
        {
            if (btnShowBookInfo.Text == "Show Info")
            {
                dgvShowBookInfo.Visible = true;

                if (!_IsBookIDCorrect())
                {
                    return;
                }

                else
                {

                    clsBook book = clsBook.FindByID((int)numericBookID.Value);

                    //frmShowBookShortInfo bookInfoForm = new frmShowBookShortInfo(book.BooKID);
                    //bookInfoForm.ShowDialog();

                    DataTable dt = new DataTable();

                    //Add Columns to DataTable
                    dt.Columns.Add("BookID", typeof(int));
                    dt.Columns.Add("Title", typeof(string));
                    dt.Columns.Add("Author", typeof(string));
                    dt.Columns.Add("Genre", typeof(string));
                    //dt.Columns.Add("ISBN", typeof(string));
                    dt.Columns.Add("PublicationDate", typeof(DateTime));
                    dt.Columns.Add("Quantity", typeof(int));
                    //dt.Columns.Add("AdditionalDetails", typeof(string));

                    string AuthorName = clsAuthor.FindByID(book.AuthorID).FullName;
                    string GenreName = clsGenre.FindByID(book.GenreID).GenreName;

                    //Add Rows to the DataTable
                    dt.Rows.Add(book.BooKID, book.Title,
                        AuthorName, GenreName,
                         book.PublicationDate, book.Quantity);

                    dgvShowBookInfo.DataSource = dt;

                    //to determine if there is an available copy or not

                    //to change mode of show info button
                    btnShowBookInfo.Text = "Hide Info";
                    btnShowBookInfo.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;

                }

            }

            else
            {
                dgvShowBookInfo.Visible = false;

                //to change mode of show info button
                btnShowBookInfo.Text = "Show Info";
                btnShowBookInfo.IconChar = FontAwesome.Sharp.IconChar.Eye;

            }
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
    }
}
