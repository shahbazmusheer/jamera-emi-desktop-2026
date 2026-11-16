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
using System.Text.RegularExpressions;
using System.IO;
using Jamera.Properties;

namespace Jamera.Accounts
{
    public partial class Edit_Account : DevExpress.XtraEditors.XtraForm
    {
        int MoveToNextControl_KeyValue = 13;
        public bool is_closeable = false;
        public int ac_id=-1;
        Accounts_Controller accounts_controller = new Accounts_Controller();
        public Edit_Account(int ac_id)
        {
            InitializeComponent();
            this.ac_id = ac_id;
            sqlDataSource1.Fill();
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
            Account account = accounts_controller.Get_Account(this.ac_id);
            group_cmb.EditValue= account.Account_Group_Id;
            name_inp.Text = account.Account_Name;
            phone_inp.Text = account.Phone;
            address_inp.Text = account.Address;
            description_inp.Text = account.Account_Remarks;            
        }
        private void Edit_Account_Load(object sender, EventArgs e)
        {
            Color back_color = name_inp.BackColor;
            Color fore_color = name_inp.ForeColor;
            description_inp.BackColor = back_color;
            description_inp.ForeColor = fore_color;
            name_inp.Focus();
            group_cmb.Properties.PopupFormSize = new Size(group_cmb.Size.Width, 280);
        }

        //private void choose_itm_img_btn_Click(object sender, EventArgs e)
        //{
            //OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            //if (open.ShowDialog() == DialogResult.OK)
            //{
            //    string img_path = open.FileName.ToString();
            //    item_picbox.Image = Image.FromFile(img_path);
            //}
        //}

        private void name_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void uni_code_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                phone_inp.Focus();
            }
        }

        private void phone_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            phone_inp.Properties.MaxLength = 13;
            Char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 13 && ch != 8 && ch != 127 && ch != 45 && ch != 43)
            {
                e.Handled = true;
            }
            if (phone_inp.Text.StartsWith("+92", StringComparison.CurrentCulture) && phone_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{6}\-\d{7}");
                phone_inp.Properties.MaxLength = 14;
            }
            else if (phone_inp.Text.StartsWith("+92", StringComparison.CurrentCulture))
            {
                phone_inp.Properties.MaxLength = 13;
            }
            else if (phone_inp.Text.StartsWith("03", StringComparison.CurrentCulture) && phone_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{4}\-\d{7}");
                phone_inp.Properties.MaxLength = 12;
            }
            else if (phone_inp.Text.StartsWith("03", StringComparison.CurrentCulture))
            {
                phone_inp.Properties.MaxLength = 11;
            }
            else if (phone_inp.Text.StartsWith("92", StringComparison.CurrentCulture) && phone_inp.Text.Contains("-"))
            {
                phone_inp.Properties.MaxLength = 13;
            }
            else if (phone_inp.Text.StartsWith("92", StringComparison.CurrentCulture))
            {
                phone_inp.Properties.MaxLength = 12;
            }

        }

        private void address_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                group_cmb.Focus();
                group_cmb.ShowPopup();
            }
        }

        private void group_cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void description_inp_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        public void Update()
        {
            if (name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter account name !");
                name_inp.Focus();
            }
            else if (group_cmb.Text == "")
            {
                XtraMessageBox.Show("Please select account group !");
                group_cmb.Focus();
            }
            else
            {
                Double amount = 0;
                
                    Accounts_Controller accounts_controller = new Accounts_Controller();
                    if (accounts_controller.Exists(this.ac_id,name_inp.Text) != true)
                    {
                        String ac_type = null;
                        int Group_Id;
                        String Group_Name = null;
                        Group_Id = Convert.ToInt32(group_cmb.EditValue);
                        Group_Name = group_cmb.Text;
                        ac_type = Convert.ToString(group_cmb.Properties.View.GetFocusedRowCellValue("A/C Type"));
                        String nature = Convert.ToString(group_cmb.Properties.View.GetFocusedRowCellValue("Nature"));
                        bool inserted_record_id = accounts_controller.Update(this.ac_id,name_inp.Text, null,Convert.ToInt32(group_cmb.EditValue),group_cmb.Text,ac_type,phone_inp.Text,address_inp.Text,description_inp.Text);
                        if (inserted_record_id == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("Something went wrong !");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Account already exists with same name !");
                    }
                
            }
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            Update();
        }

        public void Delete()
        {
            if (accounts_controller.Exists_Transaction(ac_id) > 0)
            {
                XtraMessageBox.Show("Some transactions are relating with this account. Account can not be deleted!");
            }
            else
            {
                accounts_controller.Delete(this.ac_id);
                this.Close();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void Edit_Account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
                if (XtraMessageBox.Show("Are you sure, you want to delete the account !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    this.Delete();
                }
            }
        }
    }
}