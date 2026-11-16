using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using Jamera.Properties;

namespace Jamera.Application_Settings
{
    public partial class Super_Admin_Login : DevExpress.XtraEditors.XtraForm
    {

        public Super_Admin_Login()
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

        private void Super_Admin_Login_Load(object sender, EventArgs e)
        {
            username_inp.Focus();
        }
        public void login()
        {
            string user_name = "supper_admin";
            string pass_word = "@Zalim" + DateTime.Now.ToString("hmMd");

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
                if (username_inp.Text == user_name && password_inp.Text == pass_word)
                {
                    Supper_Admin_Settings settings = new Supper_Admin_Settings();
                    settings.Show();
                    this.Hide();
                }
                else
                {
                    if (username_inp.Text != user_name && password_inp.Text != pass_word)
                    {
                        XtraMessageBox.Show("Incorrect username and password!");
                        username_inp.Text = "";
                        password_inp.Text = "";
                        username_inp.Focus();
                    }
                    else if (username_inp.Text != user_name)
                    {
                        XtraMessageBox.Show("Invalid username!");
                        username_inp.Text = "";
                        username_inp.Focus();
                    }
                    else if (password_inp.Text != pass_word)
                    {
                        XtraMessageBox.Show("Incorrect password!");
                        password_inp.Text = "";
                        password_inp.Focus();
                    }
                }
            }
        }



        private void login_btn_Click(object sender, EventArgs e)
        {
            login();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void Super_Admin_Login_Shown(object sender, EventArgs e)
        {
            username_inp.Focus();
        }

        private void Super_Admin_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}