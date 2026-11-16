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

namespace Jamera.Messages
{
    public partial class New_Group : DevExpress.XtraEditors.XtraForm
    {
        public Add_Contact add_group_contact  { get; set; }
        public bool Do_Selection = false;
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

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Reset_Fields();
        }

        public void Reset_Fields()
        {
            name_inp.Text = null;
            description_inp.Text = null;
            name_inp.Focus();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name for group !");
            }
            else
            {
                Message_Groups_Controller groups_controller = new Message_Groups_Controller();
                if (groups_controller.Exists(name_inp.Text) != true)
                {
                    int inserted_rec_id = groups_controller.Store(name_inp.Text, description_inp.Text);
                    if (inserted_rec_id > 0)

                    {
                        if(Do_Selection == true)
                        {
                            add_group_contact.sqlDataSource1.RebuildResultSchema();
                            add_group_contact.sqlDataSource1.Fill();
                            add_group_contact.messages_groups_cmb.Refresh();
                            add_group_contact.messages_groups_cmb.EditValue=inserted_rec_id;
                            this.Close();
                        }
                        Reset_Fields();
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
    }
}