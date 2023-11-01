using FontAwesome.Sharp;
using LibraryBusinessLayer;
using LibrarySystem_WindowsForms_.LoginScreenForms;
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

namespace LibrarySystem_WindowsForms_.MemberMainMenuForms
{
    public partial class frmMemberMainMenu : Form
    {

        private IconButton currentButton;
        private Form activeForm;
        private clsMember _Member;
        public frmMemberMainMenu(clsMember Member)
        {
            InitializeComponent();

            this._Member = Member;

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;

            lblFullName.Text = _Member.Name;           
            lblEmail.Text = _Member.Email;

            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();

        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (IconButton)btnSender)
                {


                    DisableMenuButton();
                    //Color color = SelectThemeColor();
                    currentButton = (IconButton)btnSender;
                    currentButton.BackColor = Color.WhiteSmoke;
                    currentButton.IconColor = Color.FromArgb(60, 60, 60);
                    currentButton.ForeColor = Color.FromArgb(60, 60, 60);
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //panelTitleBar.BackColor = color;
                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = color;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableMenuButton()
        {
            IconButton iconbutton = new IconButton();

            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(IconButton))
                {
                    iconbutton = (IconButton)previousBtn;

                    previousBtn.BackColor = Color.FromArgb(0, 122, 204);
                    previousBtn.ForeColor = Color.Gainsboro;
                    iconbutton.IconColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                lblTitle.Text = childForm.Tag.ToString();
            }
            else
            {
                lblTitle.Text = childForm.Text;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //hideSubMenu();

            ActivateButton(sender);
            frmLoginScreen Login = new frmLoginScreen();
            Login.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //hideSubMenu();

            ActivateButton(sender);
            frmLoginScreen Login = new frmLoginScreen();
            Login.Show();
            this.Hide();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMemberBook(_Member), sender);
        }

        private void btnBorrowingRecord_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMemberBookBorrowingRecords(_Member), sender);
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMemberReservation(_Member), sender);
        }

        private void btnFines_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMemberFines(_Member), sender);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMemberProfile(_Member), sender);
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 224)
            {
                panelMenu.Width = 65;
            }
            else
                panelMenu.Width = 224;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
