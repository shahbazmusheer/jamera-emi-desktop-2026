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

namespace Jamera
{
    public partial class UC_Opener_Form : DevExpress.XtraEditors.XtraForm
    {
        String form_name = "";
        UserControl user_control;
        public bool Is_New_Cash_Voucher = false;
        public Vouchers.Cash_Voucher CASH_VOUCHER { get; set; }
        public UC_Opener_Form(String Form_Name , UserControl User_Control)
        {
            InitializeComponent();
            form_name = Form_Name;
            user_control = User_Control;
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

        private void Larger_Second_Window_Load(object sender, EventArgs e)
        {
            user_control.Dock = DockStyle.Fill;
            this.Text = form_name;
            contents_container.Controls.Clear();
            contents_container.Controls.Add(user_control);
        }


        private void UC_Opener_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Is_New_Cash_Voucher == true)
            {
                if (CASH_VOUCHER.cash_voucher_emi_items_table.Rows.Count > 0)
                {
                    if (XtraMessageBox.Show("You have not save the voucher entries!\nAre you sure, you want to exit?", "Warning Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        e.Cancel = true; // To prevent form closing...
                    }
                }
            }
        }
    }
}