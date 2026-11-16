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
    public partial class New_Sale : DevExpress.XtraEditors.XtraUserControl
    {
        int MoveToNextControl_KeyValue = 13;
        //String Message_Title = "Error Alert";
        public New_Sale()
        {
            InitializeComponent();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            UC_Opener_Form form = new UC_Opener_Form("New Sale", new New_Sale());
            form.Show(this);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Reset_Fields();
        }

        public void Reset_Fields()
        {
            sale_type_cmb.SelectedIndex = 0;
            date_picker.Text = null;
            payment_type_cmb.SelectedIndex = 0;
            customer_cmb.Text = "";
            balance_inp.Text = "0.00";
            total_top_lbl.Text = "0.00";
            search_item_cmb.Text = "";
            quantity_inp.Text = "";
            sale_rate_inp.Text = "";
            item_disc_rs_inp.Text = "";
            item_disc_perc_inp.Text = "";
            item_total_inp.Text = "";
            sub_total_inp.Text = "";
            whole_disc_perc_inp.Text = "";
            whole_disc_rs_inp.Text = "";
            total_amount_inp.Text = "";
            paid_amount_inp.Text = "";
            change_amount_inp.Text = "";
            remarks_inp.Text = "";
            search_item_cmb.Focus();
        }

        public void Reset_Item_Entries()
        {
            search_item_cmb.Text = "";
            quantity_inp.Text = "";
            sale_rate_inp.Text = "";
            item_disc_rs_inp.Text = "";
            item_disc_perc_inp.Text = "";
            item_total_inp.Text = "";
            search_item_cmb.Focus();
            search_item_cmb.ShowPopup();
        }

        private void sale_type_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sale_type_cmb.SelectedIndex == 0)
            {
                payment_type_cmb.Enabled = true;
                payment_type_cmb.SelectedIndex = 0;
                paid_amount_inp.Enabled = true;
            }
            else if (sale_type_cmb.SelectedIndex == 1)
            {
                payment_type_cmb.Enabled = false;
                payment_type_cmb.SelectedIndex = -1;
                paid_amount_inp.Text = "";
                paid_amount_inp.Enabled = false;
            }
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

        private void select_btn_Click(object sender, EventArgs e)
        {
            right_panel.HideSliding();
            search_item_cmb.Focus();
        }

        private void New_Sale_Load(object sender, EventArgs e)
        {
            search_item_cmb.Focus();
        }

        private void search_item_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (search_item_cmb.SelectedText != "")
            {
                quantity_inp.Focus();
            }
        }

        private void quantity_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                sale_rate_inp.Focus();
            }
        }

        private void sale_rate_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                item_disc_rs_inp.Focus();
            }
        }

        private void item_disc_rs_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                item_disc_perc_inp.Focus();
            }
        }

        private void item_disc_perc_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                XtraMessageBox.Show("Codes are not available to add item!");
                this.Reset_Item_Entries();
            }
        }

        private void item_total_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                XtraMessageBox.Show("Codes are not available to add item!");
                this.Reset_Item_Entries();
            }
        }

        private void quantity_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                XtraMessageBox.Show("Codes are not available to add item!");
                this.Reset_Item_Entries();
            }
        }

        private void sale_rate_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                XtraMessageBox.Show("Codes are not available to add item!");
                this.Reset_Item_Entries();
            }
        }

        private void item_disc_rs_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                XtraMessageBox.Show("Codes are not available to add item!");
                this.Reset_Item_Entries();
            }
        }

        private void item_disc_perc_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                XtraMessageBox.Show("Codes are not available to add item!");
                this.Reset_Item_Entries();
            }
        }

        private void item_total_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                XtraMessageBox.Show("Codes are not available to add item!");
                this.Reset_Item_Entries();
            }
        }
        private void whole_disc_perc_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                XtraMessageBox.Show("Codes are not available to save invoice!");
                this.Reset_Fields();
            }
        }

        private void whole_disc_perc_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                whole_disc_rs_inp.Focus();
            }
        }

        private void whole_disc_rs_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                XtraMessageBox.Show("Codes are not available to save invoice!");
                this.Reset_Fields();
            }
        }

        private void whole_disc_rs_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                if (sale_type_cmb.SelectedIndex == 0)
                {
                    paid_amount_inp.Focus();
                }
                else
                {
                    remarks_inp.Focus();
                }
            }
        }
        private void paid_amount_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                XtraMessageBox.Show("Codes are not available to save invoice!");
                this.Reset_Fields();
            }
        }

        private void paid_amount_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                remarks_inp.Focus();
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            by_date_check.CheckState = CheckState.Unchecked;
            by_customer_check.CheckState = CheckState.Unchecked;
        }

        private void remarks_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == MoveToNextControl_KeyValue)
            {
                XtraMessageBox.Show("Codes are not available to save invoice!");
                this.Reset_Fields();
            }
        }
    }
}
