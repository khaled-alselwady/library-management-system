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
    public partial class frmMemberFines : Form
    {
        private clsMember _Member;

        public frmMemberFines(clsMember Member)
        {
            InitializeComponent();

            this._Member = Member;
        }

        private void _RefreshFinesList()
        {
            dgvShowMemberFinesList.DataSource = clsFines.GetAllFinesOfSpecificMember(_Member.MemberID);
            dgvShowMemberFinesList.EnableHeadersVisualStyles = false;
            dgvShowMemberFinesList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(98, 191, 255);
        }

        private void _SearchData(string Data)
        {
            dgvShowMemberFinesList.DataSource = clsFines.SearchFinesContainsOfSpecificMember(Data, _Member.MemberID);
        }

        private void _Pay()
        {

            clsFines fine = clsFines.FindByID((int)dgvShowMemberFinesList.CurrentRow.Cells[0].Value);

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
            if ((string)dgvShowMemberFinesList.CurrentRow.Cells[5].Value == "Paid")
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
            if ((string)dgvShowMemberFinesList.CurrentRow.Cells[5].Value == "Paid")
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
            frmShowFineDetails ShowFineDetails = new frmShowFineDetails((int)dgvShowMemberFinesList.CurrentRow.Cells[0].Value);
            ShowFineDetails.ShowDialog();
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Pay();
        }
    }
}
