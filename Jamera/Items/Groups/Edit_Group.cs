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
    public partial class Edit_Group : DevExpress.XtraEditors.XtraForm
    {
        int id = -1;
        Item_Group item_group = new Item_Group();
        public bool Do_Refresh = false;
        public Item_Groups item_groups { get; set; }
        public Edit_Group(Item_Group item_group)
        {
            InitializeComponent();
            this.item_group = item_group;
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
            this.id = this.item_group.Id;
            group_name_inp.Text = this.item_group.Name;
            group_description_inp.Text = this.item_group.Description;
        }

        private void Edit_Group_Load(object sender, EventArgs e)
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
        public void Update()
        {
            if (group_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name of group!");
            }
            else
            {
                Item_Groups_Controller groups_controller = new Item_Groups_Controller();
                if (groups_controller.Exists(this.id, group_name_inp.Text) != true)
                {
                    if (groups_controller.Update(this.id, group_name_inp.Text, group_description_inp.Text) == true)
                    {

                        if (Do_Refresh == true)
                        {
                            item_groups.Refresh_Grid_Data();
                        }
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Group is already exists !");
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        public void Delete()
        {
            Item_Groups_Controller item_groups_controller = new Item_Groups_Controller();
            if (item_groups_controller.Delete(this.id) == true)
            {
                if (Do_Refresh == true)
                {
                    item_groups.Refresh_Grid_Data();
                }
                this.Close();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void Edit_Group_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }
            if (e.Control && e.KeyCode == Keys.X)
            {
                if (XtraMessageBox.Show("Are you sure, you want to delete the group !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Delete();
                }
            }
        }
    }
}