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
using System.IO;
using Jamera.Properties;

namespace Jamera.Items.Catagories
{
    public partial class New_Catagory : DevExpress.XtraEditors.XtraForm
    {
        public Catagories categories { get; set; }
        public New_Item new_item { get; set; }
        public bool Do_Selection = false;
        public bool Do_Refresh = false;
        public New_Catagory()
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

        private void New_Catagory_Load(object sender, EventArgs e)
        {
            catagory_description_inp.BackColor = catagory_name_inp.BackColor;
            catagory_description_inp.ForeColor = catagory_name_inp.ForeColor;
            catagory_name_inp.Focus();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            catagory_name_inp.Text = "";
            catagory_description_inp.Text = "";
            catagory_name_inp.Focus();
        }
        public void Reset_Fields()
        {
            catagory_name_inp.Text = null;
            catagory_description_inp.Text = null;
            catagory_name_inp.Focus();
        }
        public void Save()
        {
            if (catagory_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name for category !");
            }
            else
            {
                Categories_Controller categories_controller = new Categories_Controller();
                if (categories_controller.Exists(catagory_name_inp.Text) != true)
                {
                    int inserted_category_id = categories_controller.Store(catagory_name_inp.Text, catagory_description_inp.Text);
                    if ( inserted_category_id > 0)
                    {
                        Reset_Fields();
                        if (Do_Refresh == true)
                        {
                            categories.Refresh_Grid_Data();
                        }
                        if(Do_Selection == true)
                        {
                            new_item.sqlDataSource1.RebuildResultSchema();
                            new_item.sqlDataSource1.Fill();
                            new_item.category_cmb.Refresh();
                            new_item.category_cmb.EditValue = Convert.ToDecimal(inserted_category_id);
                            this.Close();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Some thing went wrong !");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Catgory is already exists !");
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void New_Catagory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Save();
            }

            if (e.KeyCode == Keys.Escape && (catagory_name_inp.Text != "" || catagory_description_inp.Text != ""))
            {
                if (XtraMessageBox.Show("Are you sure, you want to cancel !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Reset_Fields();
                }
            }
        }
    }
}