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

namespace LibrarySystem_WindowsForms_.CirculationForms
{
    public partial class frmFines : Form
    {
        private clsEmployee _Employee;

        public frmFines(clsEmployee employee)
        {
            InitializeComponent();
            this._Employee = employee;
        }

        private void _RefreshFinesList()
        {
            dgvShowFinesList.DataSource = clsFines.GetAllFines();
            dgvShowFinesList.EnableHeadersVisualStyles = false;
            dgvShowFinesList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void _SearchData(string Data)
        {
            dgvShowFinesList.DataSource = clsFines.SearchFinesContains(Data);
        }

        private void _Pay()
        {

            clsFines fine = clsFines.FindByID((int)dgvShowFinesList.CurrentRow.Cells[0].Value);

            if (fine == null)
            {
                MessageBox.Show("Record is not found!");
                return;
            }

            //Update Status of paying
            fine.PaymentStatus = true;

            if (fine.Save())
            {
                MessageBox.Show($"[{fine.FineAmount} $] has been successfully paid,", "Succeeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshFinesList();
            }
            else
            {
                MessageBox.Show($"Paying Failed. Try again.",
                   "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmFines_Load(object sender, EventArgs e)
        {
            _RefreshFinesList();
        }
        
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (_Employee.Permissions == "Assistant")
            {
                frmAccessDeniedMessage ShowMessage = new frmAccessDeniedMessage();
                ShowMessage.ShowDialog();
                return;
            }

            if ((string)dgvShowFinesList.CurrentRow.Cells[5].Value == "Paid")
            {
                MessageBox.Show("you have already paid this record!");
                return;
            }

            _Pay();


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _SearchData(txtSearch.Text);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((string)dgvShowFinesList.CurrentRow.Cells[5].Value == "Paid")
            {
                payToolStripMenuItem.Visible = false;
            }
            else
            {
                payToolStripMenuItem.Visible = true;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowFineDetails ShowFineDetails = new frmShowFineDetails((int)dgvShowFinesList.CurrentRow.Cells[0].Value);
            ShowFineDetails.ShowDialog();
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_Employee.Permissions == "Assistant")
            {
                frmAccessDeniedMessage ShowMessage = new frmAccessDeniedMessage();
                ShowMessage.ShowDialog();
                return;
            }

            _Pay();
        }
    }
}
