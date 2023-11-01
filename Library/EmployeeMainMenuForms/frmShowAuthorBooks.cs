using FontAwesome.Sharp;
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
    public partial class frmShowAuthorBooks : Form
    {
        private int _AuthorID;
        private string _AuthorName;
        public frmShowAuthorBooks(int AuthorID, string AuthorName)
        {
            InitializeComponent();

            this._AuthorID = AuthorID;
            this._AuthorName = AuthorName;
        }

        private void _RefreshBooksAuthorList()
        {
            dgvShowAuthorBooksList.DataSource = clsBook.GetAllBooKsWithTheSameAuthor(_AuthorID);
            dgvShowAuthorBooksList.EnableHeadersVisualStyles = false;
            dgvShowAuthorBooksList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void frmShowAuthorBooks_Load(object sender, EventArgs e)
        {
           
            _RefreshBooksAuthorList();
            lblAuthorID.Text = _AuthorID.ToString();
            lblNameAuthor.Text = _AuthorName;
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
