using LibraryBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem_WindowsForms_.MemberMainMenuForms
{
    public partial class frmMemberProfile : Form
    {

        private clsMember _Member;

        public frmMemberProfile(clsMember Member)
        {
            InitializeComponent();

            this._Member = Member;

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

        private void _DisableReadOnlyFromTheTextBoxes()
        {
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtUsername.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPassword.ReadOnly = false;
            maskedtxtPhoneNumber.ReadOnly = false;
        }

        private void _EnableReadOnlyFromTheTextBoxes()
        {
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPassword.ReadOnly = true;
            maskedtxtPhoneNumber.ReadOnly = true;


        }

        private bool _IsInfoCorrect()
        {

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                   "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_Member.Username != txtUsername.Text && clsMember.IsMemberExistsByUsername(txtUsername.Text.Trim()))
            {
                MessageBox.Show("This Username already exists, Enter a new one.",
                                    "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;
            }

            if (_Member.Email != txtEmail.Text && clsMember.IsMemberExistsByEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("This Email already exists, Enter a new one.",
                                    "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            else
            {
                return true;
            }

        }

        private void frmMemberProfile_Load(object sender, EventArgs e)
        {
            _FillTextBoxesWithMemberInfo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            this.Tag = "EDIT INFORMATION";

            _DisableReadOnlyFromTheTextBoxes();
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;

            //btnSave.Location = new Point(8, 582);
            //btnCancel.Location = new Point(159, 582);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Tag = "SHOW INFORMATION";

            if (!_IsInfoCorrect())
            {
                return;
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

                txtLibraryCardNumber.Text = _Member.LibraryCardNumber;

            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnEdit.Visible = true;
            _EnableReadOnlyFromTheTextBoxes();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Tag = "SHOW INFORMATION";
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnEdit.Visible = true;
            _EnableReadOnlyFromTheTextBoxes();
        }

        private void txtboxMouseDown(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).ReadOnly)
            {
                ((TextBox)sender).SelectionLength = 0;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            }
        }

        private void txtboxMouseUp(object sender, MouseEventArgs e)
        {
            if (((TextBox)sender).ReadOnly)
            {
                ((TextBox)sender).SelectionLength = 0;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                ((TextBox)sender).Focus();
            }
        }
    }
}
