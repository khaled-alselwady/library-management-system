using LibraryBusinessLayer;
using LibrarySystem_WindowsForms_.CirculationForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem_WindowsForms_.MemberMainMenuForms
{
    public partial class frmMemberReservation : Form
    {

        private clsMember _Member;

        public frmMemberReservation(clsMember Member)
        {
            InitializeComponent();

            this._Member = Member;
        }

        private void _RefreshMemberReservationsList()
        {
            dgvShowMemberReservationsList.DataSource = clsReservation.GetAllReservationsOfSpecificMember(_Member.MemberID);
            dgvShowMemberReservationsList.EnableHeadersVisualStyles = false;
            dgvShowMemberReservationsList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }



        private void _SearchData(string Data)
        {
            dgvShowMemberReservationsList.DataSource = clsReservation.SearchReservationsContainsOfSpecificMember(Data, _Member.MemberID);
        }

        private void frmReservations_Load(object sender, EventArgs e)
        {
            _RefreshMemberReservationsList();
        }



        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditReservation AddEditReservation = new frmAddEditReservation(_Member.MemberID, -1);
            AddEditReservation.ShowDialog();
            _RefreshMemberReservationsList();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddEditReservation AddEditReservation = new frmAddEditReservation(_Member.MemberID, (int)dgvShowMemberReservationsList.CurrentRow.Cells[0].Value); ;
            AddEditReservation.ShowDialog();
            _RefreshMemberReservationsList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvShowMemberReservationsList.CurrentCell == null)
            {
                MessageBox.Show("You have to select an record you want to delete first.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Do you really want to delete this record?!", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                if (clsReservation.DeleteReservation((int)dgvShowMemberReservationsList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Reservation Deleted Successfully.", "Delete Reservation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshMemberReservationsList();
                }
                else
                {
                    MessageBox.Show("Reservation Deleted Failed!", "Delete Failed",
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
