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
    public partial class New_Model : DevExpress.XtraEditors.XtraForm
    {
        public Models models { get; set; }
        public int Model_Id;
        public New_Item new_item { get; set; }
        public Edit_Item edit_item { get; set; }
        public bool Do_Refresh = false;
        public bool Do_Selection = false;
        public bool Do_Selection_In_Edit_Item = false;
        public New_Model()
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
        public void Save()
        {
            if (model_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name of model !");
            }
            else
            {
                Models_Controller models_controller = new Models_Controller();
                if (models_controller.Model_Exists(model_name_inp.Text) != true)
                {
                    int inserted_model_id = models_controller.Store(model_name_inp.Text);
                    if (inserted_model_id > 0)
                    {
                        if (Do_Refresh == true)
                        {
                            models.Refresh_Grid_Data();
                        }
                        if (Do_Selection == true)
                        {
                            new_item.sqlDataSource1.RebuildResultSchema();
                            new_item.sqlDataSource1.Fill();
                            new_item.model_cmb.Refresh();
                            new_item.model_cmb.EditValue = Convert.ToDecimal(inserted_model_id);
                            this.Close();
                        }
                        if (Do_Selection_In_Edit_Item == true)
                        {
                            edit_item.sqlDataSource1.RebuildResultSchema();
                            edit_item.sqlDataSource1.Fill();
                            edit_item.model_cmb.Refresh();
                            edit_item.model_cmb.EditValue = Convert.ToDecimal(inserted_model_id);
                            this.Close();
                        }
                        model_name_inp.Text = null;
                        model_name_inp.Focus();
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

        private void New_Model_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.Control && e.KeyCode == Keys.S)
            {
                this.Save();
                model_name_inp.Text = null;
            }

            if (e.KeyCode == Keys.Escape && model_name_inp.Text != "")
            {
                if (XtraMessageBox.Show("Are you sure, you want to cancel !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    model_name_inp.Text = null;
                    model_name_inp.Focus();
                }
            }
        }
    }
}