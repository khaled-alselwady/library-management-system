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
    public partial class frmShowMemberShortInfo : Form
    {
        private int _MemberID;

        public frmShowMemberShortInfo(int MemberID)
        {
            InitializeComponent();

            this._MemberID = MemberID;
        }

        private void _ShowMemberInfo()
        {
            clsMember member = clsMember.FindByID(_MemberID);

            if (member != null)
            {
                lblMemberID.Text = _MemberID.ToString();
                lblFullName.Text = member.Name;
                lblUsername.Text = member.Username;
                lblEmail.Text = member.Email;
                lblPassword.Text = member.Password;
                lblPhoneNumber.Text = member.PhoneNumber;
                lblCardNumber.Text = member.LibraryCardNumber;
            }

        }

        private void frmShowMemberShortInfo_Load(object sender, EventArgs e)
        {
            _ShowMemberInfo();
        }
    }
}
