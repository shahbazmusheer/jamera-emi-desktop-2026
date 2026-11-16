using DevExpress.XtraEditors;
using Jamera.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamera.Employees.Commissions
{
    public partial class Edit_Item_Commission : DevExpress.XtraEditors.XtraForm
    {

        int commission_id = -1;
        Item_Commission item_Commission = new Item_Commission();
        Commission_Controller commission_controller = new Commission_Controller();
        public Edit_Item_Commission(int COMMISSION_ID)
        {
            InitializeComponent();

            this.commission_id = COMMISSION_ID;

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

            sqlDataSource1.Fill();

            Load_Data();
        }

        public void Load_Data()
        {
            item_Commission = commission_controller.Get_Item_Commission(commission_id);
            
            item_cmb.EditValue = item_Commission.Item_Id;
            am_inp.Text = item_Commission.Area_Manager.ToString();
            ss_inp.Text = item_Commission.Senior_Secretary.ToString();
            js_inp.Text = item_Commission.Junior_Secretary.ToString();
            sm_inp.Text = item_Commission.Salesman.ToString();
            desc_inp.Text = item_Commission.Description;
        }

        private void item_cmb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int i = e.Button.Index;

            if (i == 1)
            {
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
                item_cmb.Refresh();
            }
        }

        public void Update()
        {
            if (item_cmb.Text == "")
            {
                XtraMessageBox.Show("Please select item !");
                item_cmb.ShowPopup();
            }
            else if (am_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter commission for area manager !");
                am_inp.Focus();
            }
            else if (ss_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter commission for senior secretary !");
                ss_inp.Focus();
            }
            else if (js_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter commission for junior secretary !");
                js_inp.Focus();
            }
            else
            {
                bool com_item_exists = commission_controller.Commission_Item_Exists(this.commission_id , Convert.ToInt32(item_cmb.EditValue));
                if (com_item_exists == false)
                {
                    Double salesman = 0;
                    if (sm_inp.Text != "")
                    {
                        salesman = Convert.ToDouble(sm_inp.Text);
                    }

                    bool is_updated = commission_controller.Update(this.commission_id, Convert.ToInt32(item_cmb.EditValue), Convert.ToDouble(am_inp.Text), Convert.ToDouble(ss_inp.Text), Convert.ToDouble(js_inp.Text), salesman, desc_inp.Text);
                    if (is_updated == true)
                    {
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Commission already exists for this item!");
                    item_cmb.Focus();
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            this.Update();
        }


        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure, you want to delete " + item_cmb.Text + " commission?", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                if (commission_controller.Item_Commission_Delete(this.commission_id))
                {
                    if (XtraMessageBox.Show("Item commission deleted, successfully!", "Info", MessageBoxButtons.OK) == DialogResult.OK)
                        this.Close();
                }
            }
        }
    }
}