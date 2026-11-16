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

namespace Jamera.Accounts
{
    public partial class Opening_Balances : DevExpress.XtraEditors.XtraForm
    {
        public Opening_Balances()
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

        private void Opening_Balances_Load(object sender, EventArgs e)
        {

        }

        private void date_picker_EditValueChanged(object sender, EventArgs e)
        {
            if (date_picker.Text != "")
            {
                opening_type_cmb.Focus();
            }
        }

        public void Reset_Fields()
        {
            date_picker.Text = "";
            opening_type_cmb.SelectedIndex = 0;
            account_title_cmb.Text = "";
            balance_inp.Text = "0.00";
            description_inp.Text = "";
            amount_inp.Text = "";
        }

        private void opening_type_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            account_title_cmb.Focus();
        }

        private void account_title_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (account_title_cmb.Text != "")
            {
                description_inp.Focus();
            }
        }

        private void description_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                amount_inp.Focus();
            }
        }

        private void amount_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (amount_inp.Text == "" || amount_inp.Text == "0")
                {
                    XtraMessageBox.Show("Please enter the amount!");
                    amount_inp.Focus();
                }
                else
                {
                    XtraMessageBox.Show("Codes are not available to save data!");
                    this.Reset_Fields();
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Reset_Fields();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            Opening_Balances form = new Opening_Balances();
            form.Show();
        }
    }
}