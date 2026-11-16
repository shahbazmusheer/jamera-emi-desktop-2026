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
    public partial class New_Manufacturer : DevExpress.XtraEditors.XtraForm
    {
        public bool Do_Refresh = false;
        public bool Do_Selection = false;
        public New_Item new_item { get; set; }
        public Manufacturers manufacturers { get; set; }
        public New_Manufacturer()
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

        private void New_Manufacturer_Load(object sender, EventArgs e)
        {
            manufac_description_inp.BackColor = manufac_name_inp.BackColor;
            manufac_description_inp.ForeColor = manufac_name_inp.ForeColor;
            manufac_name_inp.Focus();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Reset_Fields();
        }

        public void Reset_Fields()
        {
            manufac_name_inp.Text = null;
            manufac_description_inp.Text = null;
            manufac_name_inp.Focus();
        }
        public void Save()
        {
            if(manufac_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name for manufacturer !");
            }
            else
            {
                Manufacturers_Controller manufacturers_controller = new Manufacturers_Controller();
                if (manufacturers_controller.Exists(manufac_name_inp.Text)!= true)
                {
                    int inserted_rec_id = manufacturers_controller.Store(manufac_name_inp.Text, manufac_description_inp.Text);
                    if ( inserted_rec_id > 0)
                    {
                        Reset_Fields();
                        if(Do_Refresh == true)
                        {
                            manufacturers.Refresh_Grid_Data();
                        }
                        if (Do_Selection == true)
                        {
                            new_item.sqlDataSource1.RebuildResultSchema();
                            new_item.sqlDataSource1.Fill();
                            new_item.manufac_cmb.Refresh();
                            new_item.manufac_cmb.EditValue = Convert.ToDecimal(inserted_rec_id);
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
                    XtraMessageBox.Show("Manufacturer is already exists !");
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void New_Manufacturer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Save();
            }

            if (e.KeyCode == Keys.Escape && (manufac_name_inp.Text != "" || manufac_description_inp.Text != ""))
            {
                if (XtraMessageBox.Show("Are you sure, you want to cancel !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Reset_Fields();
                }
            }
        }
    }
}