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
using static Guna.UI2.Native.WinApi;

namespace LibrarySystem_WindowsForms_.EmployeeMainMenuForms
{
    public partial class frmAuthors : Form
    {

        clsAuthor _Author;
        clsEmployee _Employee;

        public frmAuthors(clsEmployee Employee)
        {
            InitializeComponent();

            this._Employee = Employee;

        }

       
        private void _RefreshAuthorsList()
        {
            dgvShowAuthorsList.DataSource = clsAuthor.GetAllAuthor();
            dgvShowAuthorsList.EnableHeadersVisualStyles = false;
            dgvShowAuthorsList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void _SearchDataByID(string Data)
        {
            dgvShowAuthorsList.DataSource = clsAuthor.SearchAuthorsContainsByID(Data);
        }

        private void _SearchDataByName(string Data)
        {
            dgvShowAuthorsList.DataSource = clsAuthor.SearchAuthorsContainsByName(Data);
        }

        private void _SearchDataByEducation(string Data)
        {
            dgvShowAuthorsList.DataSource = clsAuthor.SearchAuthorsContainsByEducation(Data);
        }

        private void _FilltxtBoxesWithAuthorInfoFromDGVControl()
        {
            string FullName = (string)dgvShowAuthorsList.CurrentRow.Cells[1].Value;

            string[] arrName = FullName.Split();

            txtAuthorID.Text = ((int)dgvShowAuthorsList.CurrentRow.Cells[0].Value).ToString();
            txtFirstName.Text = arrName[0];
            txtLastName.Text = arrName[1];
            txtEducation.Text = (string)dgvShowAuthorsList.CurrentRow.Cells[2].Value;
            txtBio.Text = (string)dgvShowAuthorsList.CurrentRow.Cells[3].Value;
        }

        private void _FillAuthorWithInfoFromTextBoxes()
        {
            _Author.FullName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Author.Education = txtEducation.Text;
            _Author.Bio = txtBio.Text;
        }

        private void frmAuthors_Load(object sender, EventArgs e)
        {
            _RefreshAuthorsList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (comboSearch.Text)
            {
                case "ID":
                    _SearchDataByID(txtSearch.Text);
                    break;

                case "Name":
                    _SearchDataByName(txtSearch.Text);
                    break;

                case "Education":
                    _SearchDataByEducation(txtSearch.Text);
                    break;
            }
        }

        private void dgvShowAuthorsList_Click(object sender, EventArgs e)
        {
            if (dgvShowAuthorsList.CurrentCell != null)
            {
                _FilltxtBoxesWithAuthorInfoFromDGVControl();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //to show the right side.
            panelSide.Visible = true;
            btnShowHidePanelSide.IconChar = IconChar.EyeSlash;

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Author = clsAuthor.FindByID(Convert.ToInt32(txtAuthorID.Text));

            if (_Author == null)
            {
                MessageBox.Show("This operation will be canceled because No Author with ID = " + txtAuthorID.Text);
                return;
            }

            _FillAuthorWithInfoFromTextBoxes();

            if (_Author.Save())
            {
                MessageBox.Show($"Data Saved Successfully, AuthorID = {_Author.AuthorID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshAuthorsList();
            }

            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {

            //to show the right side.
            panelSide.Visible = true;
            btnShowHidePanelSide.IconChar = IconChar.EyeSlash;

            if (dgvShowAuthorsList.CurrentCell != null)
            {
                MessageBox.Show("You have to press on Clear Fields then fill out fields with new author info.", "Used Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClear.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string AuthorName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            if (clsAuthor.IsAuthorExists(AuthorName))
            {
                MessageBox.Show("This Author Name already exists, Enter a new one.",
                    "Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return;
            }

            _Author = new clsAuthor();

            _FillAuthorWithInfoFromTextBoxes();

            if (_Author.Save())
            {
                MessageBox.Show($"Data Saved Successfully, AuthorID = {_Author.AuthorID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAuthorID.Text = _Author.AuthorID.ToString();;
                _RefreshAuthorsList();
            }

            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //to show the right side.
            panelSide.Visible = true;
            btnShowHidePanelSide.IconChar = IconChar.EyeSlash;

            dgvShowAuthorsList.CurrentCell = null;

            txtAuthorID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEducation.Clear();
            txtBio.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Employee.Permissions == "Assistant")
            {
                frmAccessDeniedMessage ShowMessage = new frmAccessDeniedMessage();
                ShowMessage.ShowDialog();
                return;
            }

            if (dgvShowAuthorsList.CurrentCell == null)
            {
                MessageBox.Show("You have to select an author you want to delete first.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Do you really want to delete this Author?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsAuthor.DeleteAuthor((int)dgvShowAuthorsList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Author Deleted Successfully.", "Delete Author",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAuthorsList();
                }
                else
                {
                    MessageBox.Show("Author Deleted Failed!, This author has a book stored in the books table, so you cannot delete it", "Deleted Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnShowAuthorBook_Click(object sender, EventArgs e)
        {
            if (dgvShowAuthorsList.CurrentCell == null)
            {
                MessageBox.Show("You must select the author whose books you want to view.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowAuthorBooks ShowAuthorBooks = new frmShowAuthorBooks((int)dgvShowAuthorsList.CurrentRow.Cells[0].Value, (string)dgvShowAuthorsList.CurrentRow.Cells[1].Value);
            ShowAuthorBooks.ShowDialog();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (panelSide.Visible)
            {
                panelSide.Visible = false;
                //btnShowHide.Location = new Point(385, 4);
            }

            else
            {
                panelSide.Visible = true;
                //btnShowHide.Location = new Point(758, 4);
            }

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
