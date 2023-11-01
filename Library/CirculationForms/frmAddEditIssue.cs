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
    public partial class frmAddEditIssue : Form
    {

        private int _BorrowingRecordID;
        private int _BookID, _MemberID;
        private clsBorrowingRecord _BorrowingRecord;
        private clsBookCopies _BookCopies = new clsBookCopies();
        private int CopyID;

        enum enModeForm { FromMember, FromEmployee }
        enModeForm _ModeForm = enModeForm.FromEmployee;

        enum enModeAddUpdate { AddNew = 0, Update = 1 }
        enModeAddUpdate _ModeAddUpdate = enModeAddUpdate.AddNew;

        public frmAddEditIssue(int BorrowingRecordID)
        {
            InitializeComponent();

            _ModeForm = enModeForm.FromEmployee;

            this._BorrowingRecordID = BorrowingRecordID;

            if (_BorrowingRecordID != -1)
            {
                _ModeAddUpdate = enModeAddUpdate.Update;
            }
            else
            {
                _ModeAddUpdate = enModeAddUpdate.AddNew;
            }

        }

        public frmAddEditIssue(int BookID, int MemberID, int BorrowingRecordID)
        {
            InitializeComponent();

            this._BookID = BookID;
            this._MemberID = MemberID;
            this._BorrowingRecordID = BorrowingRecordID;

            _ModeForm = enModeForm.FromMember;

            if (_BorrowingRecordID != -1)
            {
                _ModeAddUpdate = enModeAddUpdate.Update;
            }
            else
            {
                _ModeAddUpdate = enModeAddUpdate.AddNew;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillTextBoxesWithBorrowingRecordInfo()
        {
            int BookID = clsBookCopies.FindCopyByIDCopy(_BorrowingRecord.CopyID).BookID;

            numericMemberID.Value = _BorrowingRecord.MemberID;
            numericBookID.Value = BookID;
            dtpIssueDate.Value = _BorrowingRecord.BorrowingDate;
            dtpDueDate.Value = _BorrowingRecord.DueDate;

        }

        private void _LoadData()
        {

            if (_ModeAddUpdate == enModeAddUpdate.AddNew)
            {
                lblMode.Text = "ADD NEW ISSUE";
                this.Tag = "ADD NEW ISSUE";

                if (_ModeForm == enModeForm.FromMember)
                {
                    numericMemberID.Value = this._MemberID;
                    numericMemberID.Enabled = false;

                    numericBookID.Value = this._BookID;
                    numericBookID.Enabled = false;

                    //to change the status available
                    if (clsBookCopies.IsThereCopyBookAvailable((int)numericBookID.Value))
                    {
                        btnYesNoAvailable.IconColor = Color.DarkGreen;
                        btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Check;

                    }
                    else
                    {
                        btnYesNoAvailable.IconColor = Color.Red;
                        btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Xmark;
                    }

                }

                _BorrowingRecord = new clsBorrowingRecord();
                return;
            }

            _BorrowingRecord = clsBorrowingRecord.FindByID(this._BorrowingRecordID);

            if (_BorrowingRecord == null)
            {
                MessageBox.Show("This form will be closed because No Borrowing Record with ID = " + _BorrowingRecordID);
                this.Close();

                return;
            }

            lblMode.Text = "UPDATE ISSUE";
            this.Tag = "UPDATE ISSUE";
            _FillTextBoxesWithBorrowingRecordInfo();

            //to change the status available
            if (clsBookCopies.IsThereCopyBookAvailable((int)numericBookID.Value))
            {
                btnYesNoAvailable.IconColor = Color.DarkGreen;
                btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Check;

            }
            else
            {
                btnYesNoAvailable.IconColor = Color.Red;
                btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            }

        }

        private bool _IsBookIDCorrect()
        {
            if (string.IsNullOrWhiteSpace(numericBookID.Text) || numericBookID.Value <= 0)
            {
                MessageBox.Show("Please enter Correct ID.",
                    "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericBookID.Focus();

                btnYesNoAvailable.Visible = false;

                dgvShowBookInfo.DataSource = new DataTable();

                return false;
            }


            if (!clsBook.IsBookExists((int)numericBookID.Value))
            {
                MessageBox.Show("Book ID is not found, Choose another one.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                numericBookID.Focus();

                btnYesNoAvailable.Visible = false;

                dgvShowBookInfo.DataSource = new DataTable();

                return false;
            }
            else
            {
                return true;
            }
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

        private void _FillBorrowingRecordWithInfo()
        {
            _BorrowingRecord.MemberID = (int)numericMemberID.Value;
            _BorrowingRecord.CopyID = _BookCopies.CopyID;
            _BorrowingRecord.BorrowingDate = dtpIssueDate.Value;
            _BorrowingRecord.DueDate = dtpDueDate.Value;
        }

        private void btnShowBookInfo_Click(object sender, EventArgs e)
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
                    //dt.Columns.Add("Quantity", typeof(int));
                    //dt.Columns.Add("AdditionalDetails", typeof(string));

                    string AuthorName = clsAuthor.FindByID(book.AuthorID).FullName;
                    string GenreName = clsGenre.FindByID(book.GenreID).GenreName;

                    //Add Rows to the DataTable
                    dt.Rows.Add(book.BooKID, book.Title,
                        AuthorName, GenreName,
                         book.PublicationDate);

                    dgvShowBookInfo.DataSource = dt;

                    //to determine if there is an available copy or not

                    btnYesNoAvailable.Visible = true;

                    if (clsBookCopies.IsThereCopyBookAvailable(book.BooKID))
                    {
                        btnYesNoAvailable.IconColor = Color.DarkGreen;
                        btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Check;

                    }
                    else
                    {
                        btnYesNoAvailable.IconColor = Color.Red;
                        btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Xmark;
                    }

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

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            //because there is no need to check if I come from member
            if (_ModeForm == enModeForm.FromEmployee)
            {
                if (!_IsBookIDCorrect() || !_IsMemberIDCorrect())
                {
                    MessageBox.Show("The input is not in a valid format.",
                        "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            if (dtpDueDate.Value <= dtpIssueDate.Value)
            {
                MessageBox.Show("The return date should not be before the issue date!",
                     "Due Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDueDate.Focus();
                return;
            }

            _BookCopies = clsBookCopies.GetTheFirstCopyAvailableInfoOfSpecificBook((int)numericBookID.Value);

            int BookID = -1;

            if (_ModeAddUpdate != enModeAddUpdate.AddNew)
            {
                BookID = clsBookCopies.FindCopyByIDCopy(_BorrowingRecord.CopyID).BookID;
            }


            if (_BookCopies != null)
            {
                if (_ModeAddUpdate == enModeAddUpdate.Update && BookID == _BookCopies.BookID && _BorrowingRecord.CopyID != _BookCopies.CopyID)
                {
                    _BookCopies = clsBookCopies.FindCopyByIDCopy(_BorrowingRecord.CopyID);
                }

            }


            if (_BookCopies == null)
            {

                if (btnYesNoAvailable.IconChar == FontAwesome.Sharp.IconChar.Xmark)
                {
                    MessageBox.Show("Sorry, there is no available copy of this book now.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("There is an error in this book copy, try again.",
                   "Book Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }


            _FillBorrowingRecordWithInfo();


            if (_BorrowingRecord.Save())
            {
                MessageBox.Show($"Borrowing Record Saved Successfully," + Environment.NewLine
                    + $"Borrowing Record ID = {_BorrowingRecord.BorrowingRecordID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _BookCopies.AvailabilityStatus = false;
                _BookCopies.Save();

                if (clsBookCopies.IsThereCopyBookAvailable((int)numericBookID.Value))
                {
                    btnYesNoAvailable.IconColor = Color.DarkGreen;
                    btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Check;

                }
                else
                {
                    btnYesNoAvailable.IconColor = Color.Red;
                    btnYesNoAvailable.IconChar = FontAwesome.Sharp.IconChar.Xmark;
                }

                lblMode.Text = "UPDATE ISSUE";
                _ModeAddUpdate = enModeAddUpdate.Update;
                _BorrowingRecord.Mode = clsBorrowingRecord.enMode.Update;
            }

            else
            {

                if (btnYesNoAvailable.IconChar == FontAwesome.Sharp.IconChar.Xmark)
                {
                    MessageBox.Show("Sorry, there is no available copy of this book now.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void frmAddEditIssue_Load(object sender, EventArgs e)
        {
            _LoadData();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
