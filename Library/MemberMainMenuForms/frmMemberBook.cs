using LibraryBusinessLayer;
using LibrarySystem_WindowsForms_.CirculationForms;
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
    public partial class frmMemberBook : Form
    {
        private clsMember _Member;

        public frmMemberBook(clsMember member)
        {
            InitializeComponent();
            this._Member = member;
        }

        private void _RefreshMemberBooksList()
        {
            dgvShowMemberBooksList.DataSource = clsBook.GetAllBooksWithoutQuantity();
            dgvShowMemberBooksList.EnableHeadersVisualStyles = false;
            dgvShowMemberBooksList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void _SearchDataByIDWithoutQuantity(string Data)
        {
            dgvShowMemberBooksList.DataSource = clsBook.SearchBooksContainsByIDWithoutQuantity(Data);
        }

        private void _SearchDataByTitleWithoutQuantity(string Data)
        {
            dgvShowMemberBooksList.DataSource = clsBook.SearchBooksContainsByTitleWithoutQuantity(Data);
        }

        private void _SearchDataByAuthorWithoutQuantity(string Data)
        {
            dgvShowMemberBooksList.DataSource = clsBook.SearchBooksContainsByAuthorWithoutQuantity(Data);
        }

        private void _SearchDataByGenreWithoutQuantity(string Data)
        {
            dgvShowMemberBooksList.DataSource = clsBook.SearchBooksContainsByGenreWithoutQuantity(Data);
        }

        private void frmMemberBook_Load(object sender, EventArgs e)
        {
            _RefreshMemberBooksList();
            comboSearch.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "BookID":
                    _SearchDataByIDWithoutQuantity(txtSearch.Text);
                    break;

                case "Title":
                    _SearchDataByTitleWithoutQuantity(txtSearch.Text);
                    break;

                case "Author":
                    _SearchDataByAuthorWithoutQuantity(txtSearch.Text);
                    break;

                case "Genre":
                    _SearchDataByGenreWithoutQuantity(txtSearch.Text);
                    break;
            }


        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            frmAddEditIssue AddEditIssue = new frmAddEditIssue((int)dgvShowMemberBooksList.CurrentRow.Cells[0].Value, _Member.MemberID, -1);
            AddEditIssue.ShowDialog();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditIssue AddEditIssue = new frmAddEditIssue((int)dgvShowMemberBooksList.CurrentRow.Cells[0].Value, _Member.MemberID, -1);
            AddEditIssue.ShowDialog();
        }
    }
}
