using DevExpress.DataAccess.DataFederation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamera.Vouchers
{
    public partial class Update_EMI : DevExpress.XtraEditors.XtraForm
    {
        Aggrements.Aggrements_Controller aggrementsController = new Aggrements.Aggrements_Controller();
        Vouchers.Vouchers_Controller vouchersController = new Vouchers.Vouchers_Controller();
        int target_id = -1;
        string source_table = "";
        int emi_no = -1;
        int store_id = -1;
        public Cash_Vouchers_History_Master cash_Vouchers_History_Master { get; set; }
        DateTime date;
        public Update_EMI(int id, string source)
        {
            InitializeComponent();
            this.target_id = id;
            this.source_table = source;
            loadEMIDetails();
        }



        private void loadEMIDetails()
        {
            EMI emi = vouchersController.getEMIDetails(target_id);
            if (emi != null && emi.isReturnFixed < 0)
            {
                due_date_picker.DateTime = emi.dueDate;
                due_amount_inp.Text = emi.dueAmount.ToString();
                rec_date_picker.DateTime = emi.recDate;
                received_amount_inp.Text = emi.recAmount.ToString();
                balance_inp.Text = emi.Balance.ToString();
                string emiNoStr = emi.emiNo > -1 ? " [" + emi_no.ToString() + "]" : "";
                this.Text = "Update EMI " + emiNoStr;
                emi_no_inp.Text = emi.emiNo > -1 ? emi.emiNo.ToString() : "";
                status_cmb.SelectedText = emi.Status;
                remarks_inp.Text = emi.Remarks;
                rec_date_picker.DateTime = this.date;
                due_amount_inp.Text = emi_no > -1 ? emi_no.ToString() : "";
                if (this.source_table == "Aggrements") rec_date_picker.Enabled = false;
                due_amount_inp.Focus();
            }
            else
            {
                this.Close();
            }
        }


        private void update_btn_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            try
            {
                // FIX: Update the local variable with the NEW value from the text box
                if (string.IsNullOrEmpty(due_amount_inp.Text))
                {
                    emi_no = -1;
                }
                else
                {
                    emi_no = Convert.ToInt32(due_amount_inp.Text);
                }

                if (source_table == "Aggrements")
                {
                    if (aggrementsController.Update_Aggrement_EMI_No(target_id, emi_no, date, store_id))
                    {
                        cash_Vouchers_History_Master.refreshData();
                        this.Close();
                    }
                }
                else if (source_table == "Aggrement Dues")
                {
                    // Now emi_no contains what the user typed
                    if (vouchersController.Update_Dues_EMI(store_id, target_id, Convert.ToDateTime(due_date_picker.Text), Convert.ToDouble(due_amount_inp), status_cmb.Text, Convert.ToDateTime(rec_date_picker.Text), emi_no, remarks_inp.Text))
                    {
                        cash_Vouchers_History_Master.refreshData();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        private void emi_no_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                Update();
            }
        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rec_date_picker_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void due_date_picker_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Update_EMI_Load(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}