using FontAwesome.Sharp;
using LibraryBusinessLayer;
using LibrarySystem_WindowsForms_.LoginScreenForms;
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
    public partial class frmMembers : Form
    {

        private clsEmployee _Employee;

        public frmMembers(clsEmployee employee)
        {
            InitializeComponent();
            this._Employee = employee;
        }

        private void _RefreshMembersList()
        {
            dgvShowMembersList.DataSource = clsMember.GetAllMembers();
            dgvShowMembersList.EnableHeadersVisualStyles = false;
            dgvShowMembersList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void _SearchDataByID(string Data)
        {
            dgvShowMembersList.DataSource = clsMember.SearchMembersContainsByID(Data);
        }

        private void _SearchDataByName(string Data)
        {
            dgvShowMembersList.DataSource = clsMember.SearchMembersContainsByName(Data);
        }

        private void _SearchDataByUsername(string Data)
        {
            dgvShowMembersList.DataSource = clsMember.SearchMembersContainsByUsername(Data);
        }

        private void _SearchDataByEmail(string Data)
        {
            dgvShowMembersList.DataSource = clsMember.SearchMembersContainsByEmail(Data);
        }

        private void _SearchDataByLibraryCardNumber(string Data)
        {
            dgvShowMembersList.DataSource = clsMember.SearchMembersContainsByLibraryCardNumber(Data);
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            _RefreshMembersList();
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

                case "Library Card":
                    _SearchDataByLibraryCardNumber(txtSearch.Text);
                    break;

            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditMember AddEditMember = new frmAddEditMember(-1);
            AddEditMember.ShowDialog();
            _RefreshMembersList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddEditMember AddEditMember = new frmAddEditMember((int)dgvShowMembersList.CurrentRow.Cells[0].Value);
            AddEditMember.ShowDialog();
            _RefreshMembersList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Employee.Permissions == "Assistant")
            {
                frmAccessDeniedMessage ShowMessage = new frmAccessDeniedMessage();
                ShowMessage.ShowDialog();
                return;
            }

            if (MessageBox.Show("Do you really want to delete this Member?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsMember.DeleteMember((int)dgvShowMembersList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Member Deleted Successfully.", "Delete Member",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshMembersList();
                }
                else
                {
                    MessageBox.Show("Member Deleted Failed!, This member may borrowed or reserved books or has fines, so you cannot delete it.", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnShowCopies_Click(object sender, EventArgs e)
        {

        }
    }
}
