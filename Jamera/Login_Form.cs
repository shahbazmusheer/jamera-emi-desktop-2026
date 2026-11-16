using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using System.IO;
using Jamera.Properties;

namespace Jamera
{
    public partial class Login_Form : DevExpress.XtraEditors.XtraForm
    {
        public Login_Form()
        {
            InitializeComponent();

            string icon_path = Settings.Default.company_icon;
            string img_name = Settings.Default.db_name;
            if (icon_path != "")
            {
                FileInfo image = new FileInfo(icon_path);
                if (image.Exists == true)
                {
                    this.Icon = new Icon(icon_path);
                }
            }
            else
            {
                string img_path = Environment.CurrentDirectory + @"\Icons\" + img_name + @".ico";
                FileInfo image = new FileInfo(img_path);
                if (image.Exists == true)
                {
                    this.Icon = new Icon(img_path);
                }
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void login()
        {
            if (username_inp.Text == "" && password_inp.Text == "")
            {
                XtraMessageBox.Show("Please fill all the fields first!");
                username_inp.Focus();
            }
            else if (username_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter the username first!");
                username_inp.Focus();
            }
            else if (password_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter the password first!");
                password_inp.Focus();
            }
            else
            {
                Login_Controller l_c = new Login_Controller();

                if (l_c.Is_User_Valid(username_inp.Text,password_inp.Text) == true)
                {
                    this.Hide();
                    Main main_form = new Main();
                    main_form.Show();
                }
                else
                {
                    XtraMessageBox.Show("Login details not matching the records !");
                    password_inp.Text = "";
                    password_inp.Focus();
                }
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            login();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private void username_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 13)
            {
                password_inp.Focus();
            }
        }

        private void password_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 13)
            {
                login();
            }
        }

        private void Login_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Login_Form_Shown(object sender, EventArgs e)
        {
            this.Opacity = 100;
            password_inp.Focus();
            
        }

        private void Login_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                Application_Settings.Super_Admin_Login form = new Application_Settings.Super_Admin_Login();
                form.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}