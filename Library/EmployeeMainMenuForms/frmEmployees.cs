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

namespace LibrarySystem_WindowsForms_.EmployeeMainMenuForms
{
    public partial class frmEmployees : Form
    {

        frmEmployeeMainMenu main = Application.OpenForms.OfType<frmEmployeeMainMenu>().FirstOrDefault();

        public frmEmployees()
        {
            InitializeComponent();
        }

        private void _RefreshEmployeesList()
        {
            dgvShowEmployeesList.DataSource = clsEmployee.GetAllEmployees();
            dgvShowEmployeesList.EnableHeadersVisualStyles = false;
            dgvShowEmployeesList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void _SearchDataByID(string Data)
        {
            dgvShowEmployeesList.DataSource = clsEmployee.SearchEmployeesContainsByID(Data);
        }

        private void _SearchDataByName(string Data)
        {
            dgvShowEmployeesList.DataSource = clsEmployee.SearchEmployeesContainsByName(Data);
        }

        private void _SearchDataByUsername(string Data)
        {
            dgvShowEmployeesList.DataSource = clsEmployee.SearchEmployeesContainsByUsername(Data);
        }

        private void _SearchDataByEmail(string Data)
        {
            dgvShowEmployeesList.DataSource = clsEmployee.SearchEmployeesContainsByEmail(Data);
        }

        private void _SearchDataByPermissions(string Data)
        {
            dgvShowEmployeesList.DataSource = clsEmployee.SearchEmployeesContainsByPermissions(Data);
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {           
            _RefreshEmployeesList();
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

                case "Username":
                    _SearchDataByUsername(txtSearch.Text);
                    break;

                case "Email":
                    _SearchDataByEmail(txtSearch.Text);
                    break;

                case "Permissions":
                    _SearchDataByPermissions(txtSearch.Text);
                    break;

            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditEmployee AddEditEmployee = new frmAddEditEmployee(-1);
            AddEditEmployee.ShowDialog();
            _RefreshEmployeesList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddEditEmployee AddEditEmployee = new frmAddEditEmployee((int)dgvShowEmployeesList.CurrentRow.Cells[0].Value);
            AddEditEmployee.ShowDialog();
            _RefreshEmployeesList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this Employee?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsEmployee.DeleteEmployee((int)dgvShowEmployeesList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Employee Deleted Successfully.", "Delete Employee",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshEmployeesList();
                }
                else
                {
                    MessageBox.Show("Employee Deleted Failed!, Try again.", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
