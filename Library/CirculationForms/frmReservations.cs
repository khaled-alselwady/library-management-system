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

namespace LibrarySystem_WindowsForms_.CirculationForms
{
    public partial class frmReservations : Form
    {
        public frmReservations()
        {
            InitializeComponent();
        }

        private void _RefreshReservationsList()
        {
            dgvShowReservationsList.DataSource = clsReservation.GetAllReservations();
            dgvShowReservationsList.EnableHeadersVisualStyles = false;
            dgvShowReservationsList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        

        private void _SearchData(string Data)
        {
            dgvShowReservationsList.DataSource = clsReservation.SearchReservationsContains(Data);
        }

        private void frmReservations_Load(object sender, EventArgs e)
        {
            _RefreshReservationsList();
        }

        

        private void dgvShowReservationsList_Click(object sender, EventArgs e)
        {
           
        }

        private void btnShowMemberInfo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnShowBookCopyInfo_Click(object sender, EventArgs e)
        {
           

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditReservation AddEditReservation = new frmAddEditReservation(-1);
            AddEditReservation.ShowDialog();
            _RefreshReservationsList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddEditReservation AddEditReservation = new frmAddEditReservation((int)dgvShowReservationsList.CurrentRow.Cells[0].Value); ;
            AddEditReservation.ShowDialog();
            _RefreshReservationsList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvShowReservationsList.CurrentCell == null)
            {
                MessageBox.Show("You have to select an record you want to delete first.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Do you really want to delete this record?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsReservation.DeleteReservation((int)dgvShowReservationsList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Reservation Deleted Successfully.", "Delete Reservation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshReservationsList();
                }
                else
                {
                    MessageBox.Show("Reservation Deleted Failed!","Delete Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _SearchData(txtSearch.Text);
        }
    }
}
