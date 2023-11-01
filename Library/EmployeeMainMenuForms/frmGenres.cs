using FontAwesome.Sharp;
using LibraryBusinessLayer;
using LibrarySystem_WindowsForms_.LoginScreenForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem_WindowsForms_.EmployeeMainMenuForms
{
    public partial class frmGenres : Form
    {
        private clsGenre _Genre;

        private clsEmployee _Employee;

        public frmGenres(clsEmployee employee)
        {
            InitializeComponent();
            this._Employee = employee;
        }

        private void _RefreshGenresList()
        {
            dgvShowGenresList.DataSource = clsGenre.GetAllGenres();
            dgvShowGenresList.EnableHeadersVisualStyles = false;
            dgvShowGenresList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }



        private void _SearchData(string Data)
        {
            dgvShowGenresList.DataSource = clsGenre.SearchGenresContains(Data);
        }


        private void _FilltxtBoxesWithGenreInfoFromDGVControl()
        {
            txtGenreID.Text = ((int)dgvShowGenresList.CurrentRow.Cells[0].Value).ToString();
            txtName.Text = (string)dgvShowGenresList.CurrentRow.Cells[1].Value;
        }

        private void frmGenres_Load(object sender, EventArgs e)
        {
            _RefreshGenresList();
        }

        private void dgvShowGenresList_Click(object sender, EventArgs e)
        {
            if (dgvShowGenresList.CurrentCell != null)
            {
                _FilltxtBoxesWithGenreInfoFromDGVControl();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _SearchData(txtSearch.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //to show the right side.
            panelSide.Visible = true;
            btnShowHidePanelSide.IconChar = IconChar.EyeSlash;

            dgvShowGenresList.CurrentCell = null;
            txtGenreID.Clear();
            txtName.Clear();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //to show the right side.
            panelSide.Visible = true;
            btnShowHidePanelSide.IconChar = IconChar.EyeSlash;

            if (dgvShowGenresList.CurrentCell != null)
            {
                MessageBox.Show("You have to press on Clear Fields then fill out fields with new Genre info.", "Used Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClear.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsGenre.IsGenreExists(txtName.Text))
            {
                MessageBox.Show("This Genre Name already exists, Enter a new one.",
                    "Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            _Genre = new clsGenre();

            _Genre.GenreName = txtName.Text;

            if (_Genre.Save())
            {
                MessageBox.Show($"Data Saved Successfully, GenreID = {_Genre.GenreID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGenreID.Text = _Genre.GenreID.ToString(); ;
                _RefreshGenresList();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            //to show the right side.
            panelSide.Visible = true;
            btnShowHidePanelSide.IconChar = IconChar.EyeSlash;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Genre = clsGenre.FindByID(Convert.ToInt32(txtGenreID.Text));

            if (_Genre == null)
            {
                MessageBox.Show("This operation will be canceled because No Genre with ID = " + txtGenreID.Text);
                return;
            }

            _Genre.GenreName = txtName.Text;

            if (_Genre.Save())
            {
                MessageBox.Show($"Data Saved Successfully, GenreID = {_Genre.GenreID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGenreID.Text = _Genre.GenreID.ToString(); ;
                _RefreshGenresList();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (_Employee.Permissions == "Assistant")
            {
                frmAccessDeniedMessage ShowMessage = new frmAccessDeniedMessage();
                ShowMessage.ShowDialog();
                return;
            }

            if (dgvShowGenresList.CurrentCell == null)
            {
                MessageBox.Show("You have to select a genre you want to delete first.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Do you really want to delete this Genre?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsGenre.DeleteGenre((int)dgvShowGenresList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Genre Deleted Successfully.", "Delete Genre",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshGenresList();
                }
                else
                {
                    MessageBox.Show("Genre Deleted Failed!, This Genre is associated with a book, so you cannot delete it.", "Deleted Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnShowAuthorBook_Click(object sender, EventArgs e)
        {
            if (dgvShowGenresList.CurrentCell == null)
            {
                MessageBox.Show("You must select the Genre whose books you want to view.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowGenreBooks ShowGenreBooks = new frmShowGenreBooks((int)dgvShowGenresList.CurrentRow.Cells[0].Value, (string)dgvShowGenresList.CurrentRow.Cells[1].Value);
            ShowGenreBooks.ShowDialog();

        }

        private void btnShowHidePanelSide_Click(object sender, EventArgs e)
        {
            if (panelSide.Visible)
            {
                panelSide.Visible = false;
                btnShowHidePanelSide.IconChar = IconChar.Eye;
            }
            else
            {
                panelSide.Visible = true;
                btnShowHidePanelSide.IconChar = IconChar.EyeSlash;
            }
        }
    }
}
