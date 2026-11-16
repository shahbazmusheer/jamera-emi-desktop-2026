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

namespace Jamera.Employees
{
    public partial class Advance_Payment : DevExpress.XtraEditors.XtraForm
    {
        String Message_Title = "Error Alert";
        public Advance_Payment()
        {
            InitializeComponent();
        }

        private void Employee_Payment_Load(object sender, EventArgs e)
        {

        }

        private void date_picker_EditValueChanged(object sender, EventArgs e)
        {
            if (date_picker.Text != null || date_picker.Text != "")
            {
                employee_cmb.ShowPopup();
            }
        }

        private void employee_accnt_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (employee_cmb.Text != "")
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
                XtraMessageBox.Show("Codes are not available to save employee payment!",Message_Title);
                this.Reset_Entries();
            }
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            Advance_Payment form = new Advance_Payment();
            form.Show();
        }

        public void Reset_Entries()
        {
            date_picker.Text = null;
            employee_cmb.Text = null;
            employee_balance_lbl.Text = null;
            description_inp.Text = null;
            amount_inp.Text = null;
            date_picker.Focus();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Reset_Entries();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {

            XtraMessageBox.Show("Codes are not available to save employee payment!", Message_Title);
            this.Reset_Entries();
        }

        private void Employee_Payment_Shown(object sender, EventArgs e)
        {
            date_picker.Focus();
        }
    }
}