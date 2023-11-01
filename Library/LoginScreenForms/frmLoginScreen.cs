using LibraryBusinessLayer;
using LibrarySystem_WindowsForms_.MemberMainMenuForms;
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

namespace LibrarySystem_WindowsForms_.LoginScreenForms
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void txtEmailorUsername_Enter(object sender, EventArgs e)
        {
            if (txtEmailorUsername.Text == "Email or Username")
            {

                txtEmailorUsername.Text = "";
                txtEmailorUsername.ForeColor = Color.LightGray;

            }
        }

        private void txtEmailorUsername_Leave(object sender, EventArgs e)
        {
            if (txtEmailorUsername.Text == "")
            {
                txtEmailorUsername.Text = "Email or Username";
                txtEmailorUsername.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {

                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void frmLoginScreen_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (clsEmployee.IsEmployeeExistsByEmailAndPassword(txtEmailorUsername.Text,txtPassword.Text))
            {
                lblInvalid.Visible = true;
                clsEmployee Employee = clsEmployee.FindByEmail(txtEmailorUsername.Text);
                frmEmployeeMainMenu OpenEmployeeMainMenu = new frmEmployeeMainMenu(Employee);
                OpenEmployeeMainMenu.Show();
                this.Hide();
               
            }

            if (clsEmployee.IsEmployeeExistsByUsernameAndPassword(txtEmailorUsername.Text, txtPassword.Text))
            {
                lblInvalid.Visible = true;
                clsEmployee Employee = clsEmployee.FindByUsername(txtEmailorUsername.Text);
                frmEmployeeMainMenu OpenEmployeeMainMenu = new frmEmployeeMainMenu(Employee);
                OpenEmployeeMainMenu.Show();
                this.Hide();
                
            }


            if (clsMember.IsMemberExistsByEmailAndPassword(txtEmailorUsername.Text, txtPassword.Text))
            {
                lblInvalid.Visible = true;
                clsMember Member = clsMember.FindByEmail(txtEmailorUsername.Text);
                frmMemberMainMenu OpenMemberMainMenu = new frmMemberMainMenu(Member);
                OpenMemberMainMenu.Show();
                this.Hide();
            }

            if (clsMember.IsMemberExistsByUsernameAndPassword(txtEmailorUsername.Text, txtPassword.Text))
            {
                lblInvalid.Visible = true;
                clsMember Member = clsMember.FindByUsername(txtEmailorUsername.Text);
                frmMemberMainMenu OpenMemberMainMenu = new frmMemberMainMenu(Member);
                OpenMemberMainMenu.Show();
                this.Hide();
            }


            //If the input was wrong
            lblInvalid.Visible = true;

        }
    }
}
