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

namespace LibrarySystem_WindowsForms_.EmployeeMainMenuForms
{
    public partial class frmShowGenreBooks : Form
    {
        private int _GenreID;
        private string _GenreName;

        public frmShowGenreBooks(int genreID, string genreName)
        {
            InitializeComponent();
            this._GenreID = genreID;
            this._GenreName = genreName;
        }

        private void _RefreshBooksGenreList()
        {
            dgvShowGenreBooksList.DataSource = clsBook.GetAllBooKsWithTheSameGenre(_GenreID);
            
        }

        

        private void frnShowGenreBooks_Load(object sender, EventArgs e)
        {
           
            _RefreshBooksGenreList();
            lblGenreID.Text = _GenreID.ToString();
            lblNameGenre.Text = _GenreName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
