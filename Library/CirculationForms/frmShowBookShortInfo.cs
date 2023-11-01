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

namespace LibrarySystem_WindowsForms_.CirculationForms
{
    public partial class frmShowBookShortInfo : Form
    {
        private int _BookID;
        public frmShowBookShortInfo(int BookID)
        {
            InitializeComponent();

            this._BookID = BookID;
        }

        private void _ShowBookInfo()
        {
            clsBook book = clsBook.FindByID(_BookID);


            if (book != null)
            {
                string AuthorName = clsAuthor.FindByID(_BookID).FullName;
                string GenreName = clsGenre.FindByID(_BookID).GenreName;

                lblBookID.Text = _BookID.ToString();
                lblTitle.Text = book.Title;
                lblAuthor.Text = AuthorName;
                lblGenre.Text = GenreName;
                lblISBN.Text = book.ISBN;
                lblPublicationDate.Text = book.PublicationDate.ToString("dd/MM/yyyy");
                lblQuantity.Text = book.Quantity.ToString();
                lblAdditionalDetails.Text = book.AdditionalDetails;
            }

        }

        private void frmShowBookShortInfo_Load(object sender, EventArgs e)
        {
            _ShowBookInfo();
        }
    }
}
