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
    public partial class frmShowCopies : Form
    {

        private int _BookID;
        private string _BookName;

        public frmShowCopies(int BookID, string BookName)
        {
            InitializeComponent();

            this._BookID = BookID;
            this._BookName = BookName;
        }

        private void _RefreshCopyBooksList()
        {
            dgvShowBooksCopiesList.DataSource = clsBookCopies.GetAllCopiesOfSpecificBook(_BookID);
            dgvShowBooksCopiesList.EnableHeadersVisualStyles = false;
            dgvShowBooksCopiesList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowCopies_Load(object sender, EventArgs e)
        {
           
            _RefreshCopyBooksList();
            lblNameBook.Text = _BookName;
            lblBookID.Text = _BookID.ToString();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
