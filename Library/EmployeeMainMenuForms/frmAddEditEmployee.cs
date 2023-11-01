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
    public partial class frmAddEditEmployee : Form
    {
        private int _EmployeeID;
        private clsEmployee _Employee;

        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        public frmAddEditEmployee(int EmployeeID)
        {
            InitializeComponent();
            this._EmployeeID = EmployeeID;

            if (_EmployeeID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }

        private void _FillTextBoxesWithEmployeeInfo()
        {
            string[] arrFirstLastName = _Employee.Name.Split();

            txtEmployeeID.Text = _Employee.EmployeeID.ToString();
            txtFirstName.Text = arrFirstLastName[0];
            txtLastName.Text = arrFirstLastName[1];
            txtUsername.Text = _Employee.Username;
            txtEmail.Text = _Employee.Email;
            txtPassword.Text = _Employee.Password;
            maskedtxtPhoneNumber.Text = _Employee.PhoneNumber;
            comboPermissions.SelectedIndex = comboPermissions.FindString(_Employee.Permissions);
        }

        private void _FillEmployeeWithInfoFromTextBoxes()
        {
            _Employee.Name = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            _Employee.Username = txtUsername.Text.Trim(); ;
            _Employee.Email = txtEmail.Text.Trim();
            _Employee.Password = txtPassword.Text.Trim();
            _Employee.PhoneNumber = maskedtxtPhoneNumber.Text.Trim();
            _Employee.Permissions = comboPermissions.Text;
        }

        private void _LoadData()
        {
            comboPermissions.SelectedIndex = 1;

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "ADD NEW EMPLOYEE";
                this.Tag = "ADD NEW EMPLOYEE";
                _Employee = new clsEmployee();
                return;
            }

            _Employee = clsEmployee.FindByID(this._EmployeeID);

            if (_Employee == null)
            {
                MessageBox.Show("This form will be closed because No Employee with ID = " + _EmployeeID);
                this.Close();

                return;
            }

            lblMode.Text = "UPDATE EMPLOYEE";
            this.Tag = "UPDATE EMPLOYEE";
            _FillTextBoxesWithEmployeeInfo();
        }
        
        private void frmAddEditEmployee_Load(object sender, EventArgs e)
        {            
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
               string.IsNullOrWhiteSpace(txtLastName.Text) ||
               string.IsNullOrWhiteSpace(txtUsername.Text) ||
               string.IsNullOrWhiteSpace(txtEmail.Text) ||
               string.IsNullOrWhiteSpace(txtPassword.Text) ||
               string.IsNullOrWhiteSpace(comboPermissions.Text))
            {
                MessageBox.Show("The input string is not in a valid format.",
                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                if (clsEmployee.IsEmployeeExistsByUsername(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("This Username already exists, Enter a new one.",
                                        "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Focus();
                    return;
                }

                if (clsEmployee.IsEmployeeExistsByEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("This Email already exists, Enter a new one.",
                                        "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

            }

            _FillEmployeeWithInfoFromTextBoxes();

            if (_Employee.Save())
            {
               

                MessageBox.Show("Data Saved Successfully," + Environment.NewLine +
                    $"Employee ID = {_Employee.EmployeeID}", "Succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Mode = enMode.Update;
                lblMode.Text = "UPDATE MODE";
            }

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
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

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
