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

namespace LibrarySystem_WindowsForms_.MemberMainMenuForms
{
    public partial class frmMemberBookBorrowingRecords : Form
    {
        private clsMember _Member;

        public frmMemberBookBorrowingRecords(clsMember member)
        {
            InitializeComponent();
            this._Member = member;
        }

        private void _RefreshBorrowingRecordsList()
        {
            dgvShowMemberBorrowingRecords.DataSource = clsBorrowingRecord.GetAllBorrowingRecordsOfSpecificMember(_Member.MemberID);
            dgvShowMemberBorrowingRecords.EnableHeadersVisualStyles = false;
            dgvShowMemberBorrowingRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void _SearchData(string Data)
        {
            dgvShowMemberBorrowingRecords.DataSource = clsBorrowingRecord.SearchBorrowingRecordsContainsOfSpecificMember(Data, _Member.MemberID);
        }

        private void _ReturnBook()
        {
            if (MessageBox.Show("Are you sure you want to return this book?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

                clsBorrowingRecord borrowingRecord = clsBorrowingRecord.FindByID((int)dgvShowMemberBorrowingRecords.CurrentRow.Cells[0].Value);
                borrowingRecord.ActualReturnDate = DateTime.Today;


                clsBookCopies bookCopies = clsBookCopies.FindCopyByIDCopy((int)dgvShowMemberBorrowingRecords.CurrentRow.Cells[2].Value);
                bookCopies.AvailabilityStatus = true;

                DateTime DueDate = (DateTime)dgvShowMemberBorrowingRecords.CurrentRow.Cells[4].Value;
                if (DueDate < DateTime.Today)
                {
                    TimeSpan Difference = DateTime.Today - DueDate;
                    short DaysDifference = (short)Difference.Days;

                    clsFines Fine = new clsFines();
                    Fine.MemberID = (int)dgvShowMemberBorrowingRecords.CurrentRow.Cells[1].Value;
                    Fine.BorrowingRecordID = (int)dgvShowMemberBorrowingRecords.CurrentRow.Cells[0].Value;
                    Fine.NumberOfLateDays = DaysDifference;
                    Fine.FineAmount = DaysDifference * clsFines.DefaultFinePerDay;
                    Fine.PaymentStatus = false;


                    if (Fine.Save() && borrowingRecord.Save() && bookCopies.Save())
                    {
                        MessageBox.Show($"Returning Record Saved Successfully," + Environment.NewLine
                       + $"You have to check the Fines Table. the member has fine in record fine ID = {Fine.FineID}",
                       "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshBorrowingRecordsList();
                    }
                    else
                    {
                        MessageBox.Show($"Returning Record Saved Failed. Try again.",
                       "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (borrowingRecord.Save() && bookCopies.Save())
                    {
                        MessageBox.Show($"Returning Record Saved Successfully.",
                       "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshBorrowingRecordsList();
                    }
                    else
                    {
                        MessageBox.Show($"Returning Record Saved Failed. Try again.",
                       "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }


            }
        }

        private void frmMemberBookBorrowingRecords_Load(object sender, EventArgs e)
        {
            _RefreshBorrowingRecordsList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _SearchData(txtSearch.Text);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //To check if I returned the book already
            if (dgvShowMemberBorrowingRecords.CurrentRow.Cells[5].Value != DBNull.Value)
            {
                MessageBox.Show("you have already returned this book!");
                return;
            }

            _ReturnBook();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ReturnBook();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvShowMemberBorrowingRecords.CurrentRow.Cells[5].Value != DBNull.Value)
            {
                returnToolStripMenuItem.Visible = false;
            }
            else
            {
                returnToolStripMenuItem.Visible = true;
            }
        }
    }
}
