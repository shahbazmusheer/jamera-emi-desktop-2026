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

namespace Jamera.Messages
{
    public partial class Edit_Group : DevExpress.XtraEditors.XtraForm
    {
        int id = -1;
        Message_Group message_group = new Message_Group();
        Message_Groups_Controller groups_controller = new Message_Groups_Controller();
        public Edit_Group(int group_id)
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
            Load_Data(group_id);
        }

        private void Edit_Message_Group_Load(object sender, EventArgs e)
        {

        }
        public void Load_Data(int id)
        {
            this.id = id;
            message_group = groups_controller.Get_Message_Group(id);
            name_inp.Text = this.message_group.Name;
            description_inp.Text = this.message_group.Description;
        }
        public void Update()
        {
            if (name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name of group!");
            }
            else
            {
                Message_Groups_Controller groups_controller = new Message_Groups_Controller();
                if (groups_controller.Exists(this.id, name_inp.Text) != true)
                {
                    if (groups_controller.Update(this.id, name_inp.Text, description_inp.Text) == true)
                    {
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Group is already exists !");
                }
            }
        }
        public void Reset_Fields()
        {
            name_inp.Text = null;
            description_inp.Text = null;
            name_inp.Focus();
        }
        public void Delete()
        {
            Message_Groups_Controller groups_controller = new Message_Groups_Controller();
            if (groups_controller.Delete(this.id) == true)
            {
                this.Close();
            }
        }

        private void Edit_Group_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Update();
            }
            if (e.Control && e.KeyCode == Keys.X)
            {
                if (XtraMessageBox.Show("Are you sure, you want to delete the group !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    Delete();
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}