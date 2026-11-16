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
    public partial class Edit_Catagory : DevExpress.XtraEditors.XtraForm
    {
        int id = -1;
        Category category = new Category();
        public Catagories categories { get; set; }
        public bool Do_Refresh = false;
        public Edit_Catagory(Category category)
        {
            InitializeComponent();
            this.category = category;
            this.Load_Data();

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
            this.id = this.category.Id;
            catagory_name_inp.Text = this.category.Name;
            catagory_description_inp.Text = this.category.Description;
        }
        private void Edit_Catagory_Load(object sender, EventArgs e)
        {
            catagory_description_inp.BackColor = catagory_name_inp.BackColor;
            catagory_description_inp.ForeColor = catagory_name_inp.ForeColor;

            catagory_name_inp.Focus();
        }

        public void Reset_Fields()
        {
            catagory_name_inp.Text = null;
            catagory_description_inp.Text = null;
            catagory_name_inp.Focus();
        }

        public void Update()
        {
            if (catagory_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name of Category!");
            }
            else
            {
                Categories_Controller categories_controller = new Categories_Controller();
                if (categories_controller.Exists(this.id, catagory_name_inp.Text) != true)
                {
                    if (categories_controller.Update(this.id, catagory_name_inp.Text, catagory_description_inp.Text) == true)
                    {

                        if (Do_Refresh == true)
                        {
                            categories.Refresh_Grid_Data();
                        }
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Category is already exists !");
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        public void Delete()
        {
            Categories_Controller categories_controller = new Categories_Controller();
            if (categories_controller.Delete(this.id) == true)
            {
                if (Do_Refresh == true)
                {
                    categories.Refresh_Grid_Data();
                }
                this.Close();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void Edit_Catagory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }
            if ( e.Control && e.KeyCode == Keys.X)
            {
                if (XtraMessageBox.Show("Are you sure, you want to delete the catagory !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Delete();
                }
            }
        }
    }
}