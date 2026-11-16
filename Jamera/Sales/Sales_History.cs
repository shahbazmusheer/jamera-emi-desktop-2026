using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Jamera.Sales
{
    public partial class Sales_History : DevExpress.XtraEditors.XtraUserControl
    {
        //String Message_Title = "Error Alert";
        public Sales_History()
        {
            InitializeComponent();
        }

        private void by_date_check_CheckedChanged(object sender, EventArgs e)
        {
            if (by_date_check.Checked)
            {
                from_date_picker.Enabled = true;
                to_date_picker.Enabled = true;
            }
            else
            {
                from_date_picker.Enabled = false;
                to_date_picker.Enabled = false;
                from_date_picker.Text = null;
                to_date_picker.Text = null;
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            by_date_check.CheckState = CheckState.Unchecked;
            by_customer_check.CheckState = CheckState.Unchecked;
        }

        private void by_customer_check_CheckedChanged(object sender, EventArgs e)
        {
            if (by_customer_check.Checked)
            {
                customer_search_cmb.Enabled = true;
            }
            else
            {
                customer_search_cmb.Text = "";
                customer_search_cmb.Enabled = false;
            }
        }
    }
}
