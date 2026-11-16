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

namespace Jamera.Items.Groups
{
    public partial class New_Group : DevExpress.XtraEditors.XtraForm
    {
        public New_Item new_item { get; set; }
        public bool Do_Selection = false;
        public Item_Groups item_groups { get; set; }
        public bool Do_Refresh = false;
        public New_Group()
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

        private void New_Group_Load(object sender, EventArgs e)
        {
            group_description_inp.BackColor = group_name_inp.BackColor;
            group_description_inp.ForeColor = group_name_inp.ForeColor;
            group_name_inp.Focus();
        }

        public void Reset_Fields()
        {
            group_name_inp.Text = null;
            group_description_inp.Text = null;
            group_name_inp.Focus();
        }

        public void Save()
        {
            if (group_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name for group !");
            }
            else
            {
                Item_Groups_Controller groups_controller = new Item_Groups_Controller();
                if (groups_controller.Exists(group_name_inp.Text) != true)
                {
                    int inserted_rec_id = groups_controller.Store(group_name_inp.Text, group_description_inp.Text);
                    if (inserted_rec_id > 0)

                    {
                        Reset_Fields();
                        if (Do_Refresh == true)
                        {
                            item_groups.Refresh_Grid_Data();
                        }
                        if(Do_Selection == true)
                        {
                            new_item.sqlDataSource1.RebuildResultSchema();
                            new_item.sqlDataSource1.Fill();
                            new_item.group_cmb.Refresh();
                            new_item.group_cmb.EditValue = Convert.ToDecimal(inserted_rec_id);
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
                    XtraMessageBox.Show("Group is already exists !");
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Reset_Fields();
        }

        private void New_Group_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Save();
            }
            if (e.KeyCode == Keys.Escape && (group_name_inp.Text != "" || group_description_inp.Text != ""))
            {
                if (XtraMessageBox.Show("Are you sure, you want to cancel !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Reset_Fields();
                }
            }
        }
    }
}