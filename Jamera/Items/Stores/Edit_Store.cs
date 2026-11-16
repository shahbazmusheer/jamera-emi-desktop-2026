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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using Jamera.Properties;

namespace Jamera.Items.Stores
{
    public partial class Edit_Store : DevExpress.XtraEditors.XtraForm
    {
        public Stores stores { get; set; }
        SqlConnection conn = new SqlConnection();
        Store store = new Store();
        public bool Do_Refresh = false;
        public Edit_Store(Store store)
        {
            InitializeComponent();
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();

            this.store = store;

            Load_Data();

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

        public void Load_Data()
        {
            area_code_inp.Text = this.store.Area_Code;
            store_name_inp.Text = this.store.Name;
            phone_inp.Text = this.store.Phone;
            if(this.store.Description != "")
            {
                description_inp.Text = this.store.Description;
            }
            else
            {
                description_inp.Text = null;
            }

            if(this.store.Address != "")
            {
                address_inp.Text = this.store.Address;
            }
            else
            {
                address_inp.Text = null;
            }
            company_name_inp.Text = this.store.Company_Name;
        }

        private void Edit_Store_Load(object sender, EventArgs e)
        {
            store_name_inp.Focus();
        }

        private void store_name_inp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void address_inp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void description_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }
        }

        public void Delete()
        {
            if (area_code_inp.Text != "")
            {
                Stores_Controller stores_controller = new Stores_Controller();
                if (stores_controller.Delete(store.Id))
                {
                    stores.Refresh_Grid_Data();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Something went wrong !");
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            this.Delete();
        }
        public void Reset_Fields()
        {
            store_name_inp.Text = null;
            address_inp.Text = null;
            company_name_inp.Text = null;
            description_inp.Text = null;
            phone_inp.Text = null;
            area_code_inp.Text = null;
            store_name_inp.Focus();
        }

        public void Update()
        {
            if (area_code_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter area code !");
                area_code_inp.Focus();
            }
            else if (store_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter store name !");
                store_name_inp.Focus();
            }
            else
            {
                Stores_Controller stores_controller = new Stores_Controller();
                if (stores_controller.Store_Exists(this.store.Id,store_name_inp.Text) == true)
                {
                    XtraMessageBox.Show("Store already exists !");
                    store_name_inp.Focus();
                }
                else
                {
                    if (stores_controller.Update(this.store.Id, store_name_inp.Text,area_code_inp.Text,company_name_inp.Text,phone_inp.Text, address_inp.Text, description_inp.Text))
                    {
                        Reset_Fields();
                        if(Do_Refresh == true)
                        {
                            stores.Refresh_Grid_Data();
                        }
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Something went wrong !");
                    }
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        private void Edit_Store_Shown(object sender, EventArgs e)
        {
            store_name_inp.Focus();
        }

        private void phone_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            phone_inp.Properties.MaxLength = 13;
            Char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 13 && ch != 8 && ch != 127 && ch != 45 && ch != 43)
            {
                e.Handled = true;
            }
            if (phone_inp.Text.Contains("+92") && phone_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{6}\-\d{7}");
                phone_inp.Properties.MaxLength = 14;
                if (phone_inp != null)
                    if (r.IsMatch(phone_inp.Text))
                    {

                    }
            }
            else if (phone_inp.Text.Contains("+92"))
            {
                phone_inp.Properties.MaxLength = 13;
            }
            else if (phone_inp.Text.Contains("03") && phone_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{4}\-\d{7}");
                phone_inp.Properties.MaxLength = 12;
            }
            else if (phone_inp.Text.Contains("03"))
            {
                phone_inp.Properties.MaxLength = 11;
            }
        }

        private void Edit_Store_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                if (XtraMessageBox.Show("Are you sure, you want to delete the store !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Delete();
                }
            }
        }
    }
}