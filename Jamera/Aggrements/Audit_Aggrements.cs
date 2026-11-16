using DevExpress.CodeParser;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Sql.DataApi;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Senders;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Jamera.Aggrements;
using Jamera.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamera.Aggrements
{
    public partial class Audit_Aggrements : DevExpress.XtraEditors.XtraUserControl
    {
        Helper_Class helper_Class = new Helper_Class();
        public DataTable cash_voucher_emi_items_table = new DataTable();
        Vouchers.Vouchers_Controller v_controller = new Vouchers.Vouchers_Controller();
        Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
        DataTable expence_items_table = new DataTable();
        private EventHandler auto_pilot_mode_event;
        Collections.VoucherCollection voucherCollection = new Collections.VoucherCollection();

        DataTable Default_Customer_Reciept_Table = new DataTable();
        DataTable DeletedRows_Table = new DataTable();
        Aggrements_Controller aggrements_controller = new Aggrements_Controller();
        Aggrement aggrement;
        int real_last_row = -1;
        int maxLockedRowIndex = -1;
        Timer timer = new Timer();

        private SpeechSynthesizer speech;

        Double reciepts_total = 0;
        Double customer_curr_balance = 0;
        public Audit_Aggrements()
        {
            InitializeComponent();
            sqlDataSource1.Fill();
            timer.Tick += timer_Tick;
            Default_Customer_Reciept_Table = voucherCollection.RecieptsTable().Clone();
            list.DataSource = Default_Customer_Reciept_Table;

            InitializeSpeech();
        }

        private void InitializeSpeech()
        {
            try
            {
                speech = new SpeechSynthesizer();

                speech.Rate = 3;
                speech.Volume = 100;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Speech initialization failed:\n" + ex.Message);
                speech = null;
            }
        }

        private void SpeakBalance()
        {
            try
            {
                if (aggrement == null)
                    return;

                double balance = aggrement.Current_Balance;

                speech.SpeakAsyncCancelAll();
                speech.SpeakAsync(
                    $"{balance:N0}"
                );
            }catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        public void Load_Customer_Dues()
        {
            // Fetch data and create a copy
            //Default_Customer_Reciept_Table = aggrements_controller.Get_Customer_Dues_Table_For_Reciepts_Adjustment(ref_no_inp.Text).Copy();
            Default_Customer_Reciept_Table = aggrements_controller.Get_Aggrement_Dues_Table(aggrement).Copy();


            //// FIX: Remove the Primary Key constraint so multiple '-1' rows can exist
            //Default_Customer_Reciept_Table.PrimaryKey = null;

            // 3. Logic: Set Receipt Date and Find the Last Locked Row Index
            maxLockedRowIndex = -1;

            for (int i = Default_Customer_Reciept_Table.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = Default_Customer_Reciept_Table.Rows[i];

                if (row["Balance"] != DBNull.Value)
                {
                    if (Convert.ToDouble(row["Balance"]) > 0 ||
                        Convert.ToDouble(row["Is Return Fixed"]) > 0)
                    {
                        maxLockedRowIndex = i;
                    }
                }
                else
                {
                    Default_Customer_Reciept_Table.Rows.RemoveAt(i);
                }
            }

            list.DataSource = Default_Customer_Reciept_Table;


        }



        private void remaining_balance_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.D) || e.KeyCode == Keys.Enter)
            {
                this.Set_Item_To_Cart();
            }
        }

        private void customers_cmb_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public void Set_Item_To_Cart()
        {
            gridView1.Focus();
            gridView1.SelectCell(gridView1.FocusedRowHandle, gridView1.Columns["EMI No"]);
        }
        private void items_cmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                this.Set_Item_To_Cart();
            }
        }

        

        public void updateRefNo(int value = 1)
        {
            if(!helper_Class.validateRefNo(ref_no_inp.Text))
            {
                ref_no_inp.Focus();
                return;
            }

            listBoxControl1.Items.Clear();
            customer_name_lbl.Text = null;
            Default_Customer_Reciept_Table.Clear();
            total_amount_lbl.Text = "";
            remaining_balance_lbl.Text = "";


            int refNo = (Convert.ToInt32(ref_no_inp.Text.Split('-')[2])+value);
            string finalRefNo = (refNo < 10) ? "0" + (refNo).ToString() : (refNo).ToString();

            finalRefNo = finalRefNo.Replace(" ", "");
            ref_no_lbl.Text = (refNo > 0) ? refNo.ToString() : "";
            ref_no_inp.Text = string.Join("-", ref_no_inp.Text.Split('-').Take(2)) + "-" + finalRefNo;
            loadDetails();
            //ref_no_inp.Focus();
            //ref_no_inp.SelectionStart = ref_no_inp.Text.Length;

        }

        public void Reset_Fields()
        {
            //items_cmb.Text = null;
            //customers_cmb.Text = null;
            //Default_Customer_Reciept_Table.Clear();
            //remaining_balance_inp.Text = "";
            updateRefNo();
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void recieved_amount_total_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;

            if (!(Char.IsDigit(ch) || ch == 13 || ch == 8 || ch == 46))
            {
                e.Handled = true;
                e.Handled = true;
            }

        }

        private void ref_no_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter Key
            {
                loadDetails();

            }
        }

        private void loadDetails()
        {

            if (!helper_Class.validateRefNo(ref_no_inp.Text))
            {
                return;
            }

            aggrement = aggrements_controller.Get_Aggrement_By_Ref_No(ref_no_inp.Text);

            if (aggrement.Aggrement_Id <= 0)
            {
                auto_pilot_check.Checked = false;
                XtraMessageBox.Show("Ref.No is not valid!");
                ref_no_inp.Focus();
                return;
            }
            else
            {
                if (aggrement.Customer_Id > 0)
                {
                    Accounts.Account customer = accounts_controller.Get_Account(Convert.ToInt32(aggrement.Customer_Id));
                    customer_name_lbl.Text = customer.Account_Name;
                    father_name_lbl.Text = customer.Father_Name;
                    cnic_no_lbl.Text = customer.Id_Card_No;

                    // Balance logic anchor
                    remaining_balance_lbl.Text = aggrement.Current_Balance.ToString("0,#");
                    total_amount_lbl.Text = aggrement.Total_Amount.ToString("0,#");
                    string Phone = customer.Phone;
                    string officePhone = customer.Phone;
                    string homePhone = customer.Home_Phone;

                    phone_no_inp.Text = !string.IsNullOrWhiteSpace(homePhone)
                        ? homePhone
                        : !string.IsNullOrWhiteSpace(officePhone)
                        ? officePhone
                        : Phone;


                    string homeAddress = customer.Home_Address;
                    string officeAddress = customer.Office_Address;
                    string PermanentAddress = customer.Permanent_Address;
                    address_lbl.Text = !string.IsNullOrEmpty(homeAddress)
                        ? homeAddress
                        : !string.IsNullOrEmpty(PermanentAddress)
                        ? PermanentAddress
                        : officeAddress;

                }
                else
                {
                    customer_name_lbl.Text = "";
                    father_name_lbl.Text = "";
                    cnic_no_lbl.Text = "";
                    phone_no_inp.Text = "";
                    address_lbl.Text = "";
                    XtraMessageBox.Show("Customer not found for this agreement!");
                    Reset_Fields();
                    return;
                }
                
                // Load Items in Items CMB
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query_2"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT 
                    s_i.item_id AS 'Code',
                    CASE 
                        WHEN s_i.sold_qty > 1 
                        THEN CONCAT(items.name, ' (', CAST(s_i.sold_qty AS INT), ')')
                        ELSE items.name
                    END AS 'Item',
                    s_i.sale_rate AS 'Sale Rate',
                    s_i.sold_qty AS 'Qty'
                FROM sale_items AS s_i
                LEFT JOIN items ON s_i.item_id = items.id
                LEFT JOIN aggrements AS ag ON s_i.agreement_id = ag.id WHERE ag.ref_no='" + ref_no_inp.Text + "'";
                
                query.Name = "Query_2";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();


                // Load items for this specific agreement
                DataTable agreementItems = aggrements_controller.Get_Aggrement_Items_Table(aggrement.Aggrement_Id);

                Load_Customer_Dues();
                if(speak_mode_check.Checked)
                    SpeakBalance();

            }
        }

        private void ref_no_inp_EditValueChanged(object sender, EventArgs e)
        {

        }


        private void new_btn_Click(object sender, EventArgs e)
        {
            Audit_Aggrements UC = new Audit_Aggrements();
            new UC_Opener_Form("Audit Aggrements", UC) { WindowState = FormWindowState.Maximized }.Show(this);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void list_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if(ref_no_inp.ContainsFocus && e.KeyCode == Keys.Down)
            {
                gridView1.Focus();
            }
            if (list.ContainsFocus && e.KeyCode == Keys.Up && gridView1.FocusedRowHandle == 0)
            {
                ref_no_inp.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                this.updateRefNo();
            }
            if (e.KeyCode == Keys.Left)
            {
                this.updateRefNo(-1);
            }

            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (auto_pilot_check.Checked)
                {
                    auto_pilot_check.Checked = false;
                }
                else
                {
                    auto_pilot_check.Checked = true;
                }
            }

        }

        private void view_agreement_btn_Click(object sender, EventArgs e)
        {
            if (helper_Class.validateRefNo(ref_no_inp.Text))
            {
                Edit_Aggrement edit_aggrement = new Edit_Aggrement(aggrement.Aggrement_Id);
                UC_Opener_Form form = new UC_Opener_Form("Agreement Details", edit_aggrement);
                edit_aggrement.uc_opener = form;
                form.Show(this);
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;

            // Get current row
            int dataSourceIndex = view.GetDataSourceRowIndex(view.FocusedRowHandle);

            // Locked rows cannot be edited
            if (dataSourceIndex <= maxLockedRowIndex)
            {
                e.Cancel = true;
                return;
            }

            // Only apply this behavior to Receipt Date
            if (view.FocusedColumn != null &&
                (view.FocusedColumn.FieldName == "Receipt Date" || view.FocusedColumn.FieldName == "Due Date"))
            {
                // Let DevExpress open the editor first
                BeginInvoke(new Action(() =>
                {

                    view.ShowEditor();

                    TextEdit editor = view.ActiveEditor as TextEdit;

                    if (editor != null)
                    {
                        editor.Focus();

                        // Select only DD
                        editor.SelectionStart = 0;
                        editor.SelectionLength = 2;
                    }
                }));
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int dataSourceIndex = view.GetDataSourceRowIndex(e.RowHandle);
                if (dataSourceIndex <= maxLockedRowIndex)
                {
                    e.Appearance.BackColor = Color.LightGray;
                    e.Appearance.ForeColor = Color.DimGray;
                }
            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void prev_ref_btn_Click(object sender, EventArgs e)
        {
            updateRefNo(-1);
        }

        private void next_ref_no_btn_Click(object sender, EventArgs e)
        {
            updateRefNo();
        }

        private void auto_pilot_check_CheckedChanged(object sender, EventArgs ev)
        {
            auto_pilot_mode_cmb.Enabled = auto_pilot_check.Checked;
            auto_pilot_timer_inp.Enabled = auto_pilot_check.Checked;

            if (auto_pilot_check.Checked)
                updateAutoPilotModeEvent();
            else
                timer.Stop();
        }


        private void auto_pilot_timer_inp_EditValueChanged(object sender, EventArgs e)
        {
            updateAutoPilotModeEvent();
        }

        private void auto_pilot_mode_cmb_SelectedIndexChanged(object sender, EventArgs ev)
        {
            updateAutoPilotModeEvent();
        }

        private void updateAutoPilotModeEvent()
        {
            timer.Stop();

            int seconds = !string.IsNullOrEmpty(auto_pilot_timer_inp.Text)
                ? Convert.ToInt32(auto_pilot_timer_inp.Text)
                : 5;

            if (seconds <= 0)
                return;

            timer.Interval = seconds * 1000;

            if (auto_pilot_check.Checked)
                timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (auto_pilot_mode_cmb.SelectedIndex == 0)
                updateRefNo();
            else
                updateRefNo(-1);
        }
    }
    
}
