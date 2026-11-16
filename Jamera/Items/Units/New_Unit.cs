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
    public partial class New_Unit : DevExpress.XtraEditors.XtraForm
    {
        public Units units { get; set; }
        public int Unit_Id ;
        public New_Item new_item { get; set; }
        public bool Do_Refresh = false;
        public bool Do_Selection = false;
        public New_Unit()
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

        private void New_Unit_Load(object sender, EventArgs e)
        {
            
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            unit_name_inp.Text = null;
            unit_name_inp.Focus();
        }

        public void Save()
        {
            if(unit_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name of unit !");
            }
            else
            {
                Units_Controller units_controller = new Units_Controller();
                if(units_controller.Unit_Exists(unit_name_inp.Text)!=true){
                    int inserted_unit_id = units_controller.Store(unit_name_inp.Text);
                    if (inserted_unit_id > 0)
                    {
                        if (Do_Refresh == true)
                        {
                            units.Refresh_Grid_Data();
                        }
                        if (Do_Selection == true)
                        {
                            new_item.sqlDataSource1.RebuildResultSchema();
                            new_item.sqlDataSource1.Fill();
                            new_item.unit_cmb.Refresh();
                            new_item.unit_cmb.EditValue = Convert.ToDecimal(inserted_unit_id);
                            this.Close();
                        }
                        unit_name_inp.Text = null;
                        unit_name_inp.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Unit is already exists !");
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void New_Unit_Shown(object sender, EventArgs e)
        {
            unit_name_inp.Focus();
        }

        private void New_Unit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.Control && e.KeyCode == Keys.S)
            {
                this.Save();
                unit_name_inp.Text = null;
            }

            if (e.KeyCode == Keys.Escape && unit_name_inp.Text != "")
            {
                if (XtraMessageBox.Show("Are you sure, you want to cancel !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    unit_name_inp.Text = null;
                }
            }
        }
    }
}