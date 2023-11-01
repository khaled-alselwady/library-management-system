using FontAwesome.Sharp;
using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem_WindowsForms_.EmployeeMainMenuForms
{
    public partial class frmAddEditBook : Form
    {

      

        private int _BookID = -1;
        private clsBook _Book;
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public frmAddEditBook(int BookID)
        {
            InitializeComponent();

            this._BookID = BookID;

            if (this._BookID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }

        }

        private string _GetAuthorNameByID(int AuthorID)
        {
            clsAuthor _Author = clsAuthor.FindByID(AuthorID);

            if (_Author != null)
            {
                return _Author.FullName;
            }
            else
            {
                return "";
            }
        }

        private string _GetGenreNameByID(int GenreID)
        {
            clsGenre _Genre = clsGenre.FindByID(GenreID);

            if (_Genre != null)
            {
                return _Genre.GenreName;
            }
            else
            {
                return "";
            }
        }

        private int _GetAuthorIDByName(string AuthorName)
        {
            clsAuthor Author = clsAuthor.FindByAuthorName(AuthorName);

            if (Author != null)
            {
                return Author.AuthorID;
            }
            else
            {
                return -1;
            }
        }

        private int _GetGenreIDByName(string GenreName)
        {
            clsGenre Genre = clsGenre.FindByGenreName(GenreName);

            if (Genre != null)
            {
                return Genre.GenreID;
            }
            else
            {
                return -1;
            }
        }

        private void _FillTextBoxesWithBookInfo()
        {

            txtBoolID.Text = _Book.BooKID.ToString();
            txtTitle.Text = _Book.Title;
            lblAuthorID.Text = _Book.AuthorID.ToString();
            txtAuthorName.Text = _GetAuthorNameByID(_Book.AuthorID);
            comboGenre.Text = _GetGenreNameByID(_Book.GenreID);
            masktxtISBN.Text = _Book.ISBN;
            dtpPublicationDate.Value = _Book.PublicationDate;
            numericQuantity.Value = _Book.Quantity;
            txtAdditionalDetails.Text = _Book.AdditionalDetails;

        }

        private void _FillGenresInComboBox()
        {

            DataTable dt = clsGenre.GetAllGenres();

            foreach (DataRow row in dt.Rows)
            {
                comboGenre.Items.Add(row["GenreName"]);
            }

        }

        private void _FillAuthorsInListBox()
        {

            DataTable dt = clsAuthor.GetAllAuthor();

            foreach (DataRow row in dt.Rows)
            {
                listboxAuthorsList.Items.Add(row["FullName"]);
            }

        }

        private void _FillBookWithInfoFromTextBoxes()
        {
            int GenreID = _GetGenreIDByName(comboGenre.Text);
            int AuthorID = _GetAuthorIDByName(txtAuthorName.Text);

            _Book.Title = txtTitle.Text;
            _Book.AuthorID = AuthorID;
            _Book.GenreID = GenreID;
            _Book.ISBN = masktxtISBN.Text.Trim();
            _Book.PublicationDate = dtpPublicationDate.Value;
            _Book.Quantity = (int)numericQuantity.Value;
            _Book.AdditionalDetails = txtAdditionalDetails.Text;
        }

        private void _LoadData()
        {
            _FillGenresInComboBox();
            comboGenre.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "ADD NEW BOOK";
                this.Tag = "ADD NEW BOOK";
                _Book = new clsBook();
                return;
            }

            _Book = clsBook.FindByID(this._BookID);

            if (_Book == null)
            {
                MessageBox.Show("This form will be closed because No Book with ID = " + _BookID);
                this.Close();

                return;
            }

            lblMode.Text = "UPDATE BOOK";
            this.Tag = "UPDATE BOOK";
            _FillTextBoxesWithBookInfo();

            //this will select the genre in the combo box.
            comboGenre.SelectedIndex = comboGenre.FindString(clsGenre.FindByID(_Book.GenreID).GenreName);

        }

        private void frmAddEditBook_Load(object sender, EventArgs e)
        {
            
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthorName.Text) ||
                string.IsNullOrWhiteSpace(comboGenre.Text) ||
                string.IsNullOrWhiteSpace(masktxtISBN.Text) ||
                string.IsNullOrWhiteSpace(dtpPublicationDate.Text) ||
                (numericQuantity.Value <= 0))
            {
                MessageBox.Show("The input string is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew && clsBook.IsBookExists(masktxtISBN.Text.Trim()))
            {
                MessageBox.Show("This Book ISBN already exists, Enter a new one.",
                    "ISBN Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                masktxtISBN.Focus();
                return;
            }


            _FillBookWithInfoFromTextBoxes();

            if (_Book.Save())
            {
                MessageBox.Show($"Data Saved Successfully, BookID = {_Book.BooKID}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            panelAuthorsList.Visible = false;
        }

        private void btnSelectAuthor_Click(object sender, EventArgs e)
        {
            _FillAuthorsInListBox();

            //To make sure the AuthorID is correct
            if (_Mode != enMode.AddNew)
            {

                listboxAuthorsList.SelectedIndex = listboxAuthorsList.FindString(_GetAuthorNameByID(_Book.AuthorID));
            }

            panelAuthorsList.Visible = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            panelAuthorsList.Visible = false;

            txtAuthorName.Text = listboxAuthorsList.Text;
            lblAuthorID.Text = _GetAuthorIDByName(txtAuthorName.Text).ToString();
        }

        private void iconButton2_Click(object sender, EventArgs e)
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
    }
}
