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

namespace LibrarySystem_WindowsForms_.CirculationForms
{
    public partial class frmShowFineDetails : Form
    {
        private int _FineID;
        private clsFines _Fine;

        public frmShowFineDetails(int FineID)
        {
            InitializeComponent();

            this._FineID = FineID;
            _Fine = clsFines.FindByID(this._FineID);
        }

        private void _ShowMemberInfo()
        {
            clsMember member = clsMember.FindByID(_Fine.MemberID);

            if (member != null)
            {
                lblMemberID.Text = member.MemberID.ToString();
                lblFullName.Text = member.Name;
                lblUsername.Text = member.Username;
                lblEmail.Text = member.Email;
                lblPassword.Text = member.Password;
                lblPhoneNumber.Text = member.PhoneNumber;
                lblCardNumber.Text = member.LibraryCardNumber;
            }

        }

        private void _ShowBorrowingRecordInfo()
        {

            clsBorrowingRecord BorrowingRecord = clsBorrowingRecord.FindByID(_Fine.BorrowingRecordID);

            lblBorrowingRecordID.Text = BorrowingRecord.BorrowingRecordID.ToString();

            lblBorrowingDate.Text = BorrowingRecord.BorrowingDate.ToString("dd/MM/yyyy");
            lblDueDate.Text = BorrowingRecord.DueDate.ToString("dd/MM/yyyy");

            if (BorrowingRecord.ActualReturnDate == DateTime.MinValue)
            {
                lblActualReturnDate.Text = "";
            }
            else
            {
                lblActualReturnDate.Text = BorrowingRecord.ActualReturnDate.ToString("dd/MM/yyyy");
            }

        }

        private void _ShowFineInfo()
        {

            if (_Fine != null)
            {
                lblFineID.Text = _FineID.ToString();

                lblFineAmount.Text = _Fine.FineAmount.ToString() + " $";                

                if (_Fine.PaymentStatus)
                {
                    btnIsPaid.IconColor = Color.DarkGreen;
                    btnIsPaid.IconChar = FontAwesome.Sharp.IconChar.Check;
                }
                else
                {
                    btnIsPaid.IconColor = Color.Red;
                    btnIsPaid.IconChar = FontAwesome.Sharp.IconChar.Xmark;
                }

            }

        }

        private void _LoadData()
        {
            _ShowMemberInfo();
            _ShowBorrowingRecordInfo();
            _ShowFineInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowFineDetails_Load(object sender, EventArgs e)
        {
            _LoadData();
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
