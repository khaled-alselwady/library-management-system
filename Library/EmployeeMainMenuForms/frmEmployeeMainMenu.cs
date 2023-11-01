using FontAwesome.Sharp;
using LibraryBusinessLayer;
using LibrarySystem_WindowsForms_.CirculationForms;
using LibrarySystem_WindowsForms_.EmployeeMainMenuForms;
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

namespace LibrarySystem_WindowsForms_
{
    public partial class frmEmployeeMainMenu : Form
    {

        private IconButton currentButton;
        
        private Form activeForm;

        private clsEmployee _Employee;

        public frmEmployeeMainMenu(clsEmployee Employee)
        {
            InitializeComponent();

            this._Employee = Employee;

            
            hideSubMenu();
        
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;

            lblFullName.Text = _Employee.Name;
            lblPermissions.Text = _Employee.Permissions;
            lblEmail.Text = _Employee.Email;


            GetTotalNumber();

            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();

            lblTitle.Text = "         HOME";
        }


        private void GetTotalNumber()
        {
            lblNumberOfBooks.Text = clsBook.GetTotalNumberOfBooks().ToString();
            lblNumberOfAuthors.Text = clsAuthor.GetTotalNumberOfAuthors().ToString();
            lblNumberOfMembers.Text = clsMember.GetAllNumberOfMembers().ToString();
            lblNumberOfEmployees.Text = clsEmployee.GetTotalNumberOfEmployees().ToString();
        }

        private void hideSubMenu()
        {
            panelSubMenuCirculation.Visible = false;

            panelLogOut.Location = new Point(0, 491);
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;

                panelLogOut.Location = new Point(0, 656);
            }
            else
            {
                subMenu.Visible = false;
                panelLogOut.Location = new Point(0, 491);
            }



        }           

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (IconButton)btnSender)
                {


                    DisableMenuButton();
                    DisableSubMenuButton();
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

        private void DisableSubMenuButton()
        {
            IconButton iconbutton = new IconButton();

            foreach (Control previousBtn in panelSubMenuCirculation.Controls)
            {
                if (previousBtn.GetType() == typeof(IconButton))
                {
                    iconbutton = (IconButton)previousBtn;

                    previousBtn.BackColor = Color.FromArgb(0, 146, 244);
                    previousBtn.ForeColor = Color.Gainsboro;
                    iconbutton.IconColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
             
        private void btnBooks_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenChildForm(new frmBooks(_Employee), sender);
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenChildForm(new frmAuthors(_Employee), sender);
        }

        private void btnGenres_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            OpenChildForm(new frmGenres(_Employee), sender);
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //ActivateButton(sender);
            OpenChildForm(new frmMembers(_Employee), sender);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            if (_Employee.Permissions == "Assistant" || _Employee.Permissions == "Librarian")
            {
                frmAccessDeniedMessage ShowMessage = new frmAccessDeniedMessage();
                ShowMessage.ShowDialog();
                return;
            }

            hideSubMenu();
            //ActivateButton(sender);
            OpenChildForm(new frmEmployees(), sender);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            ActivateButton(sender);
            frmLoginScreen Login = new frmLoginScreen();
            Login.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            hideSubMenu();

            ActivateButton(sender);
            frmLoginScreen Login = new frmLoginScreen();
            Login.Show();
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                //panelEmployees.Location = new Point(panelBooks.Location.X + 298, panelBooks.Location.Y);
                //panelMembers.Location = new Point(panelAuthors.Location.X - 298, panelAuthors.Location.Y);
            }

            else
            {
                WindowState = FormWindowState.Normal;
                //panelEmployees.Location = new Point(396, 32);
                //panelMembers.Location = new Point(703, 32);
            }

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void IconCurrentChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableMenuButton();
            lblTitle.Text = "         HOME";
            //panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            //panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            //btnCloseChildForm.Visible = false;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           
            if (panelMenu.Width == 224)
            {
                panelMenu.Width = 65;
            }
            else
                panelMenu.Width = 224;

        }

        private void btnCirculation_Click(object sender, EventArgs e)
        {
            //lblTitle.Text = "Circulation";
            //ActivateButton(sender);

            showSubMenu(panelSubMenuCirculation);

            //if (activeForm != null)
            //{
            //    activeForm.Close();
            //}
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {

            DisableSubMenuButton();
            OpenChildForm(new frmIssueBook(), sender);
        }

        private void btnReservation_Click_1(object sender, EventArgs e)
        {
            DisableSubMenuButton();
            OpenChildForm(new frmReservations(), sender);
        }

        private void btnFines_Click_1(object sender, EventArgs e)
        {
            DisableSubMenuButton();
            OpenChildForm(new frmFines(_Employee), sender);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }
    }
}
