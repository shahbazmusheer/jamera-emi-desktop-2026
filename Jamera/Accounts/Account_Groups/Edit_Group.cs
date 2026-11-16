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

namespace Jamera.Accounts.Account_Groups
{
    public partial class Edit_Group : DevExpress.XtraEditors.XtraForm
    {
        int MoveToNextControl_KeyValue = 13;
        int group_id = -1;
        Group group = new Group();
        public Edit_Group(Group group)
        {
            InitializeComponent();
            this.group_id = group.Group_Id;
            this.group = group;
            Load_Data();

            sqlDataSource1.Fill();

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
                string img_path = Environment.CurrentDirectory + @"\Icons\"+img_name+@".ico";
                FileInfo image = new FileInfo(img_path);
                if (image.Exists == true)
                {
                    this.Icon = new Icon(img_path);
                }
            }
        }
        public void Load_Data()
        {
            group_name_inp.Text = group.Grou_Name;
            accnt_nature_cmb.EditValue=group.Nature_Id;
            accnt_type_cmb.Text = group.Group_Type;
        }

        private void Edit_Group_Load(object sender, EventArgs e)
        {
            group_name_inp.Focus();
        }

        private void group_name_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                accnt_nature_cmb.Focus();
                accnt_nature_cmb.ShowPopup();
            }
        }

        private void accnt_nature_cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                accnt_type_cmb.Focus();
                accnt_type_cmb.ShowPopup();
            }
        }

        private void accnt_type_cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                XtraMessageBox.Show("Codes are not available to update data!");
            }
        }

        public void Delete()
        {
            Account_Groups_Controller account_group_controller = new Account_Groups_Controller();
            if (account_group_controller.Delete(this.group_id) == true)
            {
                this.Close();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            this.Delete();
        }
        public void Update()
        {
            if (group_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter group name !");
                group_name_inp.Focus();
            }
            else if (accnt_nature_cmb.Text == "")
            {
                XtraMessageBox.Show("Please select group nature !");
                accnt_nature_cmb.ShowPopup();
            }
            else if (accnt_type_cmb.Text == "")
            {
                XtraMessageBox.Show("Please select group type !");
                accnt_type_cmb.ShowPopup();
            }
            else
            {
                Account_Groups_Controller account_groups_controller = new Account_Groups_Controller();
                if (account_groups_controller.Exists(this.group_id,group_name_inp.Text) == true)
                {
                    XtraMessageBox.Show("This account group already exists !");
                    group_name_inp.Focus();
                }
                else
                {
                    bool is_updated = account_groups_controller.Update(this.group_id,group_name_inp.Text, Convert.ToInt32(accnt_nature_cmb.EditValue), accnt_nature_cmb.Text, accnt_type_cmb.Text);
                    if (is_updated == true)
                    {
                        this.Close();
                    }
                }
            }
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Edit_Group_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                if (XtraMessageBox.Show("Are you sure, you want to delete the store !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Delete();
                }
            }
        }
    }
}