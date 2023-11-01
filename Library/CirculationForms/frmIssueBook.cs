using FontAwesome.Sharp;
using LibraryBusinessLayer;
using LibrarySystem_WindowsForms_.EmployeeMainMenuForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace LibrarySystem_WindowsForms_.CirculationForms
{
    public partial class frmIssueBook : Form
    {

        public frmIssueBook()
        {
            InitializeComponent();
        }

        private void _RefreshBorrowingRecordsList()
        {
            dgvShowBorrowingRecords.DataSource = clsBorrowingRecord.GetAllBorrowingRecords();
            dgvShowBorrowingRecords.EnableHeadersVisualStyles = false;
            dgvShowBorrowingRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void _SearchData(string Data)
        {
            dgvShowBorrowingRecords.DataSource = clsBorrowingRecord.SearchBorrowingRecordsContains(Data);
        }

        private void _ReturnBook()
        {
            if (MessageBox.Show("Are you sure you want to return this book?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

                clsBorrowingRecord borrowingRecord = clsBorrowingRecord.FindByID((int)dgvShowBorrowingRecords.CurrentRow.Cells[0].Value);
                borrowingRecord.ActualReturnDate = DateTime.Today;


                clsBookCopies bookCopies = clsBookCopies.FindCopyByIDCopy((int)dgvShowBorrowingRecords.CurrentRow.Cells[2].Value);
                bookCopies.AvailabilityStatus = true;

                DateTime DueDate = (DateTime)dgvShowBorrowingRecords.CurrentRow.Cells[4].Value;
                if (DueDate < DateTime.Today)
                {
                    TimeSpan Difference = DateTime.Today - DueDate;
                    short DaysDifference = (short)Difference.Days;

                    clsFines Fine = new clsFines();
                    Fine.MemberID = (int)dgvShowBorrowingRecords.CurrentRow.Cells[1].Value;
                    Fine.BorrowingRecordID = (int)dgvShowBorrowingRecords.CurrentRow.Cells[0].Value;
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

        private void frmIssueBook_Load(object sender, EventArgs e)
        {
            _RefreshBorrowingRecordsList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _SearchData(txtSearch.Text);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditIssue AddEditIssue = new frmAddEditIssue(-1);
            AddEditIssue.ShowDialog();
            _RefreshBorrowingRecordsList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddEditIssue AddEditIssue = new frmAddEditIssue((int)dgvShowBorrowingRecords.CurrentRow.Cells[0].Value); ;
            AddEditIssue.ShowDialog();
            _RefreshBorrowingRecordsList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this Borrowing Record?!", "Warning",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsBorrowingRecord.DeleteBorrowingRecord((int)dgvShowBorrowingRecords.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Borrowing Record Deleted Successfully.", "Delete Employee",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshBorrowingRecordsList();
                }
                else
                {
                    MessageBox.Show("Borrowing Record Deleted Failed!, This member has fines, so he has to pay before this record is deleted.", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowBorrowingRecordDetails ShowDetails = new frmShowBorrowingRecordDetails((int)dgvShowBorrowingRecords.CurrentRow.Cells[0].Value);
            ShowDetails.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvShowBorrowingRecords.CurrentRow.Cells[5].Value != DBNull.Value)
            {
                returnToolStripMenuItem.Visible = false;
            }
            else
            {
                returnToolStripMenuItem.Visible = true;
            }
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ReturnBook();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //To check if I returned the book already
            if (dgvShowBorrowingRecords.CurrentRow.Cells[5].Value != DBNull.Value)
            {
                MessageBox.Show("you have already returned this book!");
                return;
            }

            _ReturnBook();

        }
    }
}
