using FontAwesome.Sharp;
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
using static Guna.UI2.Native.WinApi;

namespace LibrarySystem_WindowsForms_.EmployeeMainMenuForms
{
    public partial class frmAddEditMember : Form
    {   

        private int _MemberID;
        private clsMember _Member;

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public frmAddEditMember(int MemberID)
        {
            InitializeComponent();

            this._MemberID = MemberID;

            if (_MemberID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }

        private void _FillTextBoxesWithMemberInfo()
        {
            string[] arrFirstLastName = _Member.Name.Split();

            txtMemberID.Text = _Member.MemberID.ToString();
            txtFirstName.Text = arrFirstLastName[0];
            txtLastName.Text = arrFirstLastName[1];
            txtUsername.Text = _Member.Username;
            txtEmail.Text = _Member.Email;
            txtPassword.Text = _Member.Password;
            maskedtxtPhoneNumber.Text = _Member.PhoneNumber;
            txtLibraryCardNumber.Text = _Member.LibraryCardNumber;

        }

        private void _FillMemberWithInfoFromTextBoxes()
        {
            _Member.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Member.Username = txtUsername.Text.Trim(); ;
            _Member.Email = txtEmail.Text.Trim();
            _Member.Password = txtPassword.Text.Trim();
            _Member.PhoneNumber = maskedtxtPhoneNumber.Text.Trim();
        }

        private void _LoadData()
        {

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "ADD NEW MEMBER";
                this.Tag = "ADD NEW MEMBER";
                _Member = new clsMember();
                return;
            }

            _Member = clsMember.FindByID(this._MemberID);

            if (_Member == null)
            {
                MessageBox.Show("This form will be closed because No Member with ID = " + _MemberID);
                this.Close();

                return;
            }

            lblMode.Text = "UPDATE MEMBER";
            this.Tag = "UPDATE MEMBER";
            _FillTextBoxesWithMemberInfo();
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
               string.IsNullOrWhiteSpace(txtLastName.Text) ||
               string.IsNullOrWhiteSpace(txtUsername.Text) ||
               string.IsNullOrWhiteSpace(txtEmail.Text) ||
               string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                if (clsMember.IsMemberExistsByUsername(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("This Username already exists, Enter a new one.",
                                        "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }

                if (clsMember.IsMemberExistsByEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("This Email already exists, Enter a new one.",
                                        "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

            }


            _FillMemberWithInfoFromTextBoxes();

            if (_Member.Save())
            {
                //to get Library Card Number
                _Member = clsMember.FindByID(_Member.MemberID);

                MessageBox.Show("Data Saved Successfully" + Environment.NewLine +
                    $"Member ID = {_Member.MemberID}" + Environment.NewLine + 
                    $"Library Card Number = {_Member.LibraryCardNumber}", "Succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Mode = enMode.Update;
                lblMode.Text = "UPDATE MODE";

            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void frmAddEditMember_Load(object sender, EventArgs e)
        {       
            _LoadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
