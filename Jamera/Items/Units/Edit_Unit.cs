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

namespace Jamera.Items.Units
{
    public partial class Edit_Unit : DevExpress.XtraEditors.XtraForm
    {
        public Units units { get; set; }
        int id;
        public bool Do_Refresh = false;
        Unit unit = new Unit();
        public Edit_Unit(Unit unit)
        {
            InitializeComponent();
            this.unit = unit;

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
            this.id = this.unit.Id;
            unit_name_inp.Text = this.unit.Name;
        }

        private void Edit_Unit_Load(object sender, EventArgs e)
        {
            unit_name_inp.Focus();
        }

        private void unit_name_inp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void Update()
        {
            if(unit_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter unit name !");
            }
            else
            {
                Units_Controller units_controller = new Units_Controller();
                if (units_controller.Unit_Exists(this.id, unit_name_inp.Text) != true){
                    if (units_controller.Update(this.id, unit_name_inp.Text) == true)
                    {
                        units.Refresh_Grid_Data();

                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Something went wrong !");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Unit is exists !");
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        public void Delete()
        {
            Units_Controller units_controller = new Units_Controller();
            if (units_controller.Delete(this.id))
            {
                if (Do_Refresh == true)
                {
                    units.Refresh_Grid_Data();
                }
                this.Close();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void Edit_Unit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                if (XtraMessageBox.Show("Are you sure, you want to delete the unit !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Delete();
                }
            }
        }
    }
}