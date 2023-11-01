using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using LibraryBusinessLayer;
using LibrarySystem_WindowsForms_.LoginScreenForms;

namespace LibrarySystem_WindowsForms_.EmployeeMainMenuForms
{
    public partial class frmBooks : Form
    {

        private clsEmployee _Employee;

        public frmBooks(clsEmployee Employee)
        {
            InitializeComponent();
            
            this._Employee = Employee;
        }        

        private void _RefreshBooksList()
        {
            dgvShowBooksList.DataSource = clsBook.GetAllBooks();
            dgvShowBooksList.EnableHeadersVisualStyles = false;
            dgvShowBooksList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void _SearchDataByID(string Data)
        {
            dgvShowBooksList.DataSource = clsBook.SearchBooksContainsByID(Data);
        }

        private void _SearchDataByTitle(string Data)
        {
            dgvShowBooksList.DataSource = clsBook.SearchBooksContainsByTitle(Data);
        }

        private void _SearchDataByAuthor(string Data)
        {
            dgvShowBooksList.DataSource = clsBook.SearchBooksContainsByAuthor(Data);
        }

        private void _SearchDataByGenre(string Data)
        {
            dgvShowBooksList.DataSource = clsBook.SearchBooksContainsByGenre(Data);
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {
            
            _RefreshBooksList();
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "BookID":
                    _SearchDataByID(txtSearch.Text);
                    break;

                case "Title":
                    _SearchDataByTitle(txtSearch.Text);
                    break;

                case "Author":
                    _SearchDataByAuthor(txtSearch.Text);
                    break;

                case "Genre":
                    _SearchDataByGenre(txtSearch.Text);
                    break;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

            frmAddEditBook AddEditBook = new frmAddEditBook(-1);
            AddEditBook.ShowDialog();
            _RefreshBooksList();            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            frmAddEditBook AddEditBook = new frmAddEditBook((int)dgvShowBooksList.CurrentRow.Cells[0].Value);
            AddEditBook.ShowDialog();
            _RefreshBooksList();            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (_Employee.Permissions == "Assistant")
            {
                frmAccessDeniedMessage ShowMessage = new frmAccessDeniedMessage();
                ShowMessage.ShowDialog();
                return;
            }

            if (MessageBox.Show("Do you really want to delete this Book?!","Warning",
                MessageBoxButtons.YesNo,MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsBook.DeleteBook((int)dgvShowBooksList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Book Deleted Successfully.", "Delete Book",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshBooksList();
                }
                else
                {
                    MessageBox.Show("Book Deleted Failed!, The book may have been borrowed or reserved", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            frmShowCopies showCopies = new frmShowCopies((int)dgvShowBooksList.CurrentRow.Cells[0].Value, (string)dgvShowBooksList.CurrentRow.Cells[1].Value);
            showCopies.ShowDialog();
        }
    }
}
