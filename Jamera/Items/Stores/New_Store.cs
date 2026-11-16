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
using System.Text.RegularExpressions;
using System.IO;
using Jamera.Properties;

namespace Jamera.Items.Stores
{
    public partial class New_Store : DevExpress.XtraEditors.XtraForm
    {
        public Stores stores { get; set; }
        public bool Do_Refresh = false;
        public bool is_closeable = false;
        public bool is_from_store = false;
        public bool is_to_store = false;
        public Stock_Transfer stock_transfer { get; set; }
        public New_Store()
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

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Reset_Fields();
        }

        public void Reset_Fields()
        {
            store_name_inp.Text = null;
            address_inp.Text = null;
            description_inp.Text = null;
            company_name_inp.Text = null;
            area_code_inp.Text = null;
            phone_inp.Text = null;
            store_name_inp.Focus();
        }

        private void New_Store_Load(object sender, EventArgs e)
        {

        }

        public void Save()
        {
            if (store_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter store name !");
                store_name_inp.Focus();
            }
            else if(area_code_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter area code !");
                area_code_inp.Focus();
            }
            else
            {
                Stores_Controller stores_controller = new Stores_Controller();
                if (stores_controller.Store_Exists(store_name_inp.Text) == true)
                {
                    XtraMessageBox.Show("Store already exists !");
                    store_name_inp.Focus();
                }
                else
                {
                    int store_rec_id = stores_controller.Store(store_name_inp.Text, area_code_inp.Text, company_name_inp.Text, phone_inp.Text, address_inp.Text, description_inp.Text);
                    if (store_rec_id > 0)
                    {
                        Reset_Fields();
                        Stores_Controller store_controller = new Stores_Controller();
                        if(Do_Refresh == true)
                        {
                            stores.Refresh_Grid_Data();
                            this.Close();
                        }
                        if(is_from_store == true)
                        {
                            stock_transfer.sqlDataSource1.RebuildResultSchema();
                            stock_transfer.sqlDataSource1.Fill();
                            stock_transfer.from_store_cmb.Refresh();
                            stock_transfer.from_store_cmb.EditValue = store_rec_id;
                        }
                        if (is_to_store == true)
                        {
                            stock_transfer.sqlDataSource1.RebuildResultSchema();
                            stock_transfer.sqlDataSource1.Fill();
                            stock_transfer.to_store_cmb.Refresh();
                            stock_transfer.to_store_cmb.EditValue = store_rec_id;
                        }
                        if (is_closeable == true)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Something went wrong !");
                    }
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void New_Store_Shown(object sender, EventArgs e)
        {
            Stores_Controller store_controller = new Stores_Controller();
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

        private void New_Store_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Save();
            }
            if (e.KeyCode == Keys.Escape && (store_name_inp.Text != "" || area_code_inp.Text != "" || company_name_inp.Text != ""))
            {
                if (XtraMessageBox.Show("Are you sure, you want to cancel !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Reset_Fields();
                }
            }
        }
    }
}