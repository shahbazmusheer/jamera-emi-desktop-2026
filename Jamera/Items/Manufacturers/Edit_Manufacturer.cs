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

namespace Jamera.Items.Manufacturers
{
    public partial class Edit_Manufacturer : DevExpress.XtraEditors.XtraForm
    {
        public bool Do_Refresh = false;
        public Manufacturers manufacturers { get; set; }
        Manufacturer manufacturer = new Manufacturer();
        int id;
        public Edit_Manufacturer(Manufacturer manufacturer)
        {
            InitializeComponent();

            this.manufacturer = manufacturer;

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
            this.id = this.manufacturer.Id;
            manufac_name_inp.Text = this.manufacturer.Name;
            manufac_description_inp.Text = this.manufacturer.Description;
        }

        private void Edit_Manufacturer_Load(object sender, EventArgs e)
        {
            manufac_description_inp.BackColor = manufac_name_inp.BackColor;
            manufac_description_inp.ForeColor = manufac_name_inp.ForeColor;
            manufac_name_inp.Focus();
        }
        public void Reset_Fields()
        {
            manufac_name_inp.Text = null;
            manufac_description_inp.Text = null;
            manufac_name_inp.Focus();
        }
        public void Update()
        {
            if(manufac_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name of manufacturer!");
            }
            else
            {
                Manufacturers_Controller manufacturers_controller = new Manufacturers_Controller();
                if (manufacturers_controller.Exists(this.id,manufac_name_inp.Text) !=true)
                {
                    if (manufacturers_controller.Update(this.id,manufac_name_inp.Text,manufac_description_inp.Text) == true)
                    {
                        
                        if (Do_Refresh == true)
                        {
                            manufacturers.Refresh_Grid_Data();
                        }
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Manufacturer is already exists !");
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        public void Delete()
        {
            Manufacturers_Controller manufacturers_controller = new Manufacturers_Controller();
            if (manufacturers_controller.Delete(this.id) == true)
            {
                if (Do_Refresh == true)
                {
                    manufacturers.Refresh_Grid_Data();
                }
                this.Close();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void Edit_Manufacturer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }
            if (e.Control &&  e.KeyCode == Keys.X)
            {
                if (XtraMessageBox.Show("Are you sure, you want to delete the manufacturer !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Delete();
                }
            }
        }
    }
}