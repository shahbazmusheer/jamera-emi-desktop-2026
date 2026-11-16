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
using Jamera.Properties;
using System.IO;

namespace Jamera.Items.Models
{
    public partial class Edit_Model : DevExpress.XtraEditors.XtraForm
    {
        public Models models { get; set; }
        int id;
        public bool Do_Refresh = false;
        Model model = new Model();
        public Edit_Model(Model model)
        {
            InitializeComponent();

            this.model = model;

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
            this.id = this.model.Model_Id;
            unit_name_inp.Text = this.model.Model_Name;
        }
        public void Update()
        {
            if (unit_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter unit name !");
            }
            else
            {
                Models_Controller models_controller = new Models_Controller();
                if (models_controller.Model_Exists(this.id, unit_name_inp.Text) != true)
                {
                    if (models_controller.Update(this.id, unit_name_inp.Text) == true)
                    {
                        models.Refresh_Grid_Data();

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
        public void Delete()
        {
            Models_Controller models_controller = new Models_Controller();
            if (models_controller.Delete(this.id))
            {
                if (Do_Refresh == true)
                {
                    models.Refresh_Grid_Data();
                }
                this.Close();
            }
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void Edit_Model_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                if (XtraMessageBox.Show("Are you sure, you want to delete the model !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Delete();
                }
            }
        }
    }
}