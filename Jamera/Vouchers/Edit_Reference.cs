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

namespace Jamera.Vouchers
{
    public partial class Edit_Reference : DevExpress.XtraEditors.XtraForm
    {
        int vouch_id = -1;
        public Edit_Reference(int voucher_id,String ref_no)
        {
            InitializeComponent();
            vouch_id = voucher_id;
            ref_no_inp.Text = ref_no;
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

        private void Edit_Reference_Load(object sender, EventArgs e)
        {

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_Reference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.Control && e.KeyCode == Keys.S)
            {
                this.Update();
            }

            if (e.KeyCode == Keys.Escape && ref_no_inp.Text != "")
            {
                if (XtraMessageBox.Show("Are you sure, you want to cancel !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    ref_no_inp.Text = null;
                    ref_no_inp.Focus();
                }
            }
        }

        public void Update()
        {
            if(ref_no_inp.Text == "")
            {
                if (XtraMessageBox.Show("Are you sure, you want to remove Ref.No in voucher !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    Vouchers_Controller vouchers_controller = new Vouchers_Controller();
                    vouchers_controller.Update_Voucher_Ref_No(vouch_id, ref_no_inp.Text);
                    this.Close();
                }
            }
            else
                {
                Vouchers_Controller vouchers_controller = new Vouchers_Controller();
                vouchers_controller.Update_Voucher_Ref_No(vouch_id, ref_no_inp.Text);
                this.Close();
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}