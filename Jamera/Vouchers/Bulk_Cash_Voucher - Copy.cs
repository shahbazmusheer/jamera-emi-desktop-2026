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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamera.Vouchers
{
    public partial class Bulk_Cash_Voucher : DevExpress.XtraEditors.XtraUserControl
    {
        Helper_Class helper_Class = new Helper_Class();
        public DataTable cash_voucher_emi_items_table = new DataTable();
        Vouchers_Controller v_controller = new Vouchers_Controller();
        Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
        DataTable expence_items_table = new DataTable();

        DataTable Default_Customer_Reciept_Table = new DataTable();
        Aggrements.Aggrements_Controller aggrements_controller = new Aggrements.Aggrements_Controller();
        Aggrements.Aggrement aggrement;
        int real_last_row = -1;


        Double reciepts_total = 0;
        Double customer_curr_balance = 0;
        public Bulk_Cash_Voucher()
        {
            InitializeComponent();
            sqlDataSource1.Fill();

        }
        private void store_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (store_cmb.ContainsFocus == true)
            {
                if (store_cmb.Text != "")
                {
                    sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query_1"]);
                    CustomSqlQuery query = new CustomSqlQuery();
                    query.Sql = @"select stores.area_code as 'Area Code',accounts.id as 'Code', accounts.name as 'Name',accounts.father_name as 'Father Name', accounts.balance as 'Balance' from (dbo.accounts accounts left join dbo.stores stores on (stores.id = accounts.store_id)) WHERE accounts.account_group_id='1002' and accounts.store_id='" + Convert.ToInt32(store_cmb.EditValue) + "'";
                    query.Name = "Query_1";
                    sqlDataSource1.Queries.Add(query);
                    sqlDataSource1.RebuildResultSchema();
                    sqlDataSource1.Fill();
                    items_cmb.Refresh();
                    ref_no_inp.Focus();
                }
            }
        }

        public void Load_Customer_Dues()
        {
            // Fetch data and create a copy
            Default_Customer_Reciept_Table = aggrements_controller.Get_Customer_Dues_Table_For_Reciepts_Adjustment(ref_no_inp.Text).Copy();

            // FIX: Remove the Primary Key constraint so multiple '-1' rows can exist
            Default_Customer_Reciept_Table.PrimaryKey = null;

            foreach (DataColumn col in Default_Customer_Reciept_Table.Columns)
            {
                col.ReadOnly = false;
                col.AllowDBNull = true;
                col.Unique = false; // Ensure 'Code' doesn't have a unique constraint
            }

            list.DataSource = Default_Customer_Reciept_Table;
            real_last_row = Default_Customer_Reciept_Table.Rows.Count - 1;
            gridView1.Focus();
        }

        public void Load_Customer_Dues_Old()
        {
            Default_Customer_Reciept_Table = null;
            Default_Customer_Reciept_Table = aggrements_controller.Get_Customer_Dues_Table_For_Reciepts_Adjustment(ref_no_inp.Text).Copy();
            list.DataSource = Default_Customer_Reciept_Table;
            real_last_row = Default_Customer_Reciept_Table.Rows.Count - 1;
            gridView1.Focus();
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
            gridView1.SelectCell(gridView1.FocusedRowHandle, gridView1.Columns["EMI #"]);
        }
        private void items_cmb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                this.Set_Item_To_Cart();
            }
        }


        public void Save()
        {
            try
            {
                // 1. Force the DevExpress Grid to save any active typing into the DataTable
                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();

                // 2. Initial Validations
                if (store_cmb.EditValue == null || store_cmb.Text == "")
                {
                    XtraMessageBox.Show("Please select a store!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    store_cmb.ShowPopup();
                    return;
                }

                if (string.IsNullOrEmpty(ref_no_inp.Text) || aggrement == null || aggrement.Aggrement_Id <= 0)
                {
                    XtraMessageBox.Show("Please select a valid Agreement (Ref.No) first!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ref_no_inp.Focus();
                    return;
                }

                // 3. Check if the user actually entered any amounts
                bool hasPayments = false;
                foreach (DataRow row in Default_Customer_Reciept_Table.Rows)
                {
                    double recAmt = 0;
                    if (row["Recieved Amount"] != DBNull.Value)
                    {
                        double.TryParse(row["Recieved Amount"].ToString(), out recAmt);
                        if (recAmt > 0)
                        {
                            hasPayments = true;
                            // Check if EMI Serial is missing for a paid row
                            if ((row["EMI #"] == DBNull.Value || string.IsNullOrEmpty(row["EMI #"].ToString())) && Settings.Default.check_emi_existence)
                            {
                                XtraMessageBox.Show($"Please provide an EMI Serial Number for the payment of {recAmt}!", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                if (!hasPayments)
                {
                    XtraMessageBox.Show("No payments detected. Please enter a 'Recieved Amount' for at least one installment.", "Empty Voucher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //// 4. Confirm with User
                //if (XtraMessageBox.Show("Are you sure you want to save these bulk receipts and update accounts?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //{
                //    return;
                //}

                // 5. Execution
                this.Enabled = false; // Prevent double clicking

                // Prepare IDs
                int currentStoreId = Convert.ToInt32(store_cmb.EditValue);
                int currentCustomerId = Convert.ToInt32(customers_cmb.EditValue);

                // Handle Item Code (Use -1 if it's a multiple-item agreement)
                int currentItemId = (items_cmb.Tag?.ToString() == "MULTIPLE") ? -1 : Convert.ToInt32(items_cmb.EditValue);

                // Call the Phase-based Controller Method
                int result = v_controller.Store_Receipts_Table(
                    Default_Customer_Reciept_Table,
                    ref_no_inp.Text,
                    currentStoreId,
                    currentCustomerId,
                    currentItemId
                );

                if (result > 0)
                {
                    // Success
                    Reset_Fields();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Critical Error during save: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        public void Reset_Fields()
        {
            ref_no_inp.Text = string.Join("-", ref_no_inp.Text.Split('-').Take(2)) + "-" + (Convert.ToInt32(ref_no_inp.Text.Split('-')[2]) + 1);
            items_cmb.Text = null;
            customers_cmb.Text = null;
            Default_Customer_Reciept_Table.Clear();
            remaining_balance_inp.Text = "";
            ref_no_inp.Focus();
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            this.Save();
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

            double itemCount = 0;
            if (string.IsNullOrEmpty(ref_no_inp.Text))
            {
                XtraMessageBox.Show("Please enter Ref.No of agreement!");
                ref_no_inp.Focus();
                return;
            }

            aggrement = aggrements_controller.Get_Aggrement_By_Ref_No(ref_no_inp.Text);

            if (aggrement.Aggrement_Id <= 0)
            {
                XtraMessageBox.Show("Ref.No is not valid!");
                ref_no_inp.Focus();
                return;
            }
            else
            {
                customers_cmb.EditValue = aggrement.Customer_Id;
                // Balance logic anchor
                customer_curr_balance = aggrement.Current_Balance;
                remaining_balance_inp.Text = customer_curr_balance.ToString();

                // Load Items in Items CMB
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query_2"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT s_i.item_id as 'Code',items.name as 'Item',s_i.sale_rate as 'Sale Rate',s_i.sold_qty as 'Qty' from sale_items as s_i left join items on s_i.item_id=items.id left join aggrements as ag on s_i.agreement_id=ag.id  WHERE ag.ref_no='" + ref_no_inp.Text + "'";
                query.Name = "Query_2";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
                items_cmb.Refresh();

                // Load items for this specific agreement
                DataTable agreementItems = aggrements_controller.Get_Aggrement_Items_Table(aggrement.Aggrement_Id);

                if (agreementItems.Rows.Count > 1)
                {
                    // Calculate real-time total quantity
                    double totalQty = agreementItems.Rows.Count;
                    itemCount = totalQty;
                    //foreach (DataRow row in agreementItems.Rows)
                    //    totalQty += Convert.ToDouble(row["Quantity"]);

                    items_cmb.EditValue = null;
                    items_cmb.Properties.NullText = $"Multiple ({totalQty})"; // Show 'Multiple (3)'
                    items_cmb.Tag = "MULTIPLE";
                }
                else if (agreementItems.Rows.Count == 1)
                {
                    items_cmb.Properties.NullText = "";
                    items_cmb.EditValue = Convert.ToDecimal(agreementItems.Rows[0]["Code"]);
                    items_cmb.Tag = "SINGLE";
                    items_cmb.Focus();
                    itemCount = 1;
                }

                Load_Customer_Dues();

            }
        }

        private void ref_no_inp_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ref_no_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                this.Set_Item_To_Cart();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Reset_Fields();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            Cash_Voucher UC = new Cash_Voucher();
            new UC_Opener_Form("New Cash Voucher", UC) { WindowState = FormWindowState.Maximized, Is_New_Cash_Voucher = true, CASH_VOUCHER = UC }.Show(this);
        }

        private void items_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (items_cmb.Text != "")
            {
                Set_Item_To_Cart();
            }
        }


        private void due_amt_inp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void field_worker_inp_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            // 1. EMI Serial Validation
            if (e.Column.FieldName == "EMI #" && gridView1.GetFocusedRowCellValue("EMI #").ToString() != "")
            {
                helper_Class.IfEMINoExists(Convert.ToInt32(gridView1.GetFocusedRowCellValue("EMI #")),
                    Convert.ToInt32(store_cmb.EditValue),
                    Convert.ToDateTime(gridView1.GetFocusedRowCellValue("Reciept Date")),
                    true, Default_Customer_Reciept_Table, "EMI #", gridView1.FocusedRowHandle);
            }
            
            // 2. Main Payment Logic
            if (e.Column.FieldName == "Recieved Amount")
            {
                double received = 0;
                double due = 0;
                double.TryParse(e.Value?.ToString(), out received);
                double.TryParse(gridView1.GetFocusedRowCellValue("Due Amount")?.ToString(), out due);

                // TRIGGER PARTIAL LOGIC: If paid < due and not zero
                if(Settings.Default.insert_new_row_for_partial_receipt && received > 0 && received < due)
                {
                    HandlePartialPayment(e.RowHandle);
                }


                // 3. Recalculate Balance Waterfall
                // Existing loop to calculate the 'Balance' column for current rows
                Double collected_amt = 0;
                for (int i = 0; i < Default_Customer_Reciept_Table.Rows.Count; i++)
                {
                    if (Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"] != DBNull.Value && Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"].ToString() != "")
                    {
                        collected_amt = collected_amt + Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"]);
                        if (collected_amt > 0 && Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"].ToString() != "0")
                        {
                            Double curr_rem_bal = customer_curr_balance - collected_amt;
                            Default_Customer_Reciept_Table.Rows[i]["Balance"] = curr_rem_bal;
                        }
                        else
                        {
                            Default_Customer_Reciept_Table.Rows[i]["Balance"] = DBNull.Value;
                        }
                    }
                    else
                    {
                        Default_Customer_Reciept_Table.Rows[i]["Balance"] = DBNull.Value;
                    }
                }

                // 4. Update/Add future month rows
                int datasourceIndex = gridView1.GetDataSourceRowIndex(e.RowHandle);
                updateNextRow(datasourceIndex);
            }
        }

        private void resetSerialNumbers()
        {
            for (int i = 0; i < Default_Customer_Reciept_Table.Rows.Count; i++)
            {
                Default_Customer_Reciept_Table.Rows[i]["Sr.No"] = i + 1;
            }
        }
        private void HandlePartialPayment(int currentRowHandle, bool isIsertedRow = false)
        {
            try
            {
                double dueAmt = Convert.ToDouble(gridView1.GetRowCellValue(currentRowHandle, "Due Amount"));
                double recAmt = Convert.ToDouble(gridView1.GetRowCellValue(currentRowHandle, "Recieved Amount"));
                double remainder = dueAmt - recAmt;

                int dsIndex = gridView1.GetDataSourceRowIndex(currentRowHandle);
                int nextDsIndex = -1;
                if (isIsertedRow)
                {
                   nextDsIndex = dsIndex-1;
                }
                else
                {
                    nextDsIndex = dsIndex+1;
                }

                // Check if a next row actually exists in the data table
                bool nextRowExists = nextDsIndex < Default_Customer_Reciept_Table.Rows.Count;

                if (remainder > 0)
                {
                    // IF NEXT ROW IS ALREADY A PARTIAL (-2), JUST UPDATE IT
                    if (nextRowExists && Default_Customer_Reciept_Table.Rows[nextDsIndex]["Code"].ToString() == "-2")
                    {
                        Default_Customer_Reciept_Table.Rows[nextDsIndex]["Due Amount"] = remainder.ToString("0.00");
                    }
                    // OTHERWISE, ASK USER TO INSERT A NEW PARTIAL ROW
                    else
                    {
                        DialogResult dr = XtraMessageBox.Show($"Received amount is less than Due by {remainder:#,##0.00}. \n\nInsert a new partial receipt row for this month?", "Partial Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            gridView1.BeginUpdate();
                            DataRow currentDataRow = Default_Customer_Reciept_Table.Rows[dsIndex];

                            DataRow partialRow = Default_Customer_Reciept_Table.NewRow();
                            
                            partialRow["Code"] = -2; // Partial Month Marker
                            if (isIsertedRow)
                            {
                                partialRow["Due Date"] = Convert.ToDateTime(currentDataRow["Due Date"]).AddMonths(-2).ToShortDateString();
                                partialRow["Reciept Date"] = Convert.ToDateTime(currentDataRow["Due Date"]).AddMonths(-2).ToShortDateString();
                                partialRow["Due Amount"] = aggrement.First_EMI.ToString("0.00");
                            }
                            else
                            {
                                partialRow["Due Date"] = currentDataRow["Due Date"];
                                partialRow["Due Amount"] = remainder.ToString("0.00");
                                partialRow["Reciept Date"] = currentDataRow["Reciept Date"];
                            }

                            // Keep receipt info null for user
                            partialRow["Recieved Amount"] = DBNull.Value;
                            partialRow["EMI #"] = DBNull.Value;
                            partialRow["Balance"] = DBNull.Value;
                            partialRow["Remarks"] = DBNull.Value;
                            if(nextDsIndex < 0) nextDsIndex = 0;
                            Default_Customer_Reciept_Table.Rows.InsertAt(partialRow, nextDsIndex);

                            // Move the boundary of "Real/Database" rows down by one
                            real_last_row++;

                            gridView1.EndUpdate();
                            gridView1.RefreshData();
                        }
                    }
                }
                else if (remainder <= 0)
                {
                    // AUTO-CLEANUP: If the user changed the payment back to FULL or more,
                    // and an empty partial row (-2) exists below, remove it.
                    if (nextRowExists && Default_Customer_Reciept_Table.Rows[nextDsIndex]["Code"].ToString() == "-2")
                    {
                        //double nextRec = 0;
                        //double.TryParse(Default_Customer_Reciept_Table.Rows[nextDsIndex]["Recieved Amount"]?.ToString(), out nextRec);

                        //if (nextRec <= 0) // Only remove if user hasn't typed a payment in it yet
                        //{
                        Default_Customer_Reciept_Table.Rows.RemoveAt(nextDsIndex);
                        real_last_row--;
                        //}
                    }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Partial Logic Error: " + ex.Message); }
            resetSerialNumbers();
        }

        private void HandlePartialPaymentOld(int currentRowHandle)
        {
            try
            {
                double dueAmt = Convert.ToDouble(gridView1.GetRowCellValue(currentRowHandle, "Due Amount"));
                double recAmt = Convert.ToDouble(gridView1.GetRowCellValue(currentRowHandle, "Recieved Amount"));
                double remainder = dueAmt - recAmt;

                int dsIndex = gridView1.GetDataSourceRowIndex(currentRowHandle);
                int nextDsIndex = dsIndex + 1;

                // Check if a next row actually exists in the data table
                bool nextRowExists = nextDsIndex < Default_Customer_Reciept_Table.Rows.Count;

                if (remainder > 0)
                {
                    // IF NEXT ROW IS ALREADY A PARTIAL (-2), JUST UPDATE IT
                    if (nextRowExists && Default_Customer_Reciept_Table.Rows[nextDsIndex]["Code"].ToString() == "-2")
                    {
                        Default_Customer_Reciept_Table.Rows[nextDsIndex]["Due Amount"] = remainder.ToString("0.00");
                    }
                    // OTHERWISE, ASK USER TO INSERT A NEW PARTIAL ROW
                    else
                    {
                        DialogResult dr = XtraMessageBox.Show($"Received amount is less than Due by {remainder:#,##0.00}. \n\nInsert a new partial receipt row for this month?", "Partial Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                            gridView1.BeginUpdate();
                            DataRow currentDataRow = Default_Customer_Reciept_Table.Rows[dsIndex];

                            DataRow partialRow = Default_Customer_Reciept_Table.NewRow();
                            partialRow["Sr.No"] = currentDataRow["Sr.No"];
                            partialRow["Code"] = -2; // Partial Month Marker
                            partialRow["Due Date"] = currentDataRow["Due Date"];
                            partialRow["Due Amount"] = remainder.ToString("0.00");
                            partialRow["Reciept Date"] = currentDataRow["Reciept Date"];

                            // Keep receipt info null for user
                            partialRow["Recieved Amount"] = DBNull.Value;
                            partialRow["EMI #"] = DBNull.Value;
                            partialRow["Balance"] = DBNull.Value;
                            partialRow["Remarks"] = DBNull.Value;

                            Default_Customer_Reciept_Table.Rows.InsertAt(partialRow, nextDsIndex);

                            // Move the boundary of "Real/Database" rows down by one
                            real_last_row++;

                            gridView1.EndUpdate();
                            gridView1.RefreshData();
                        }
                    }
                }
                else if (remainder <= 0)
                {
                    // AUTO-CLEANUP: If the user changed the payment back to FULL or more,
                    // and an empty partial row (-2) exists below, remove it.
                    if (nextRowExists && Default_Customer_Reciept_Table.Rows[nextDsIndex]["Code"].ToString() == "-2")
                    {
                        //double nextRec = 0;
                        //double.TryParse(Default_Customer_Reciept_Table.Rows[nextDsIndex]["Recieved Amount"]?.ToString(), out nextRec);

                        //if (nextRec <= 0) // Only remove if user hasn't typed a payment in it yet
                        //{
                            Default_Customer_Reciept_Table.Rows.RemoveAt(nextDsIndex);
                            real_last_row--;
                        //}
                    }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Partial Logic Error: " + ex.Message); }
        }

        public void updateNextRow(int currentIndex)
        {
            try
            {
                gridView1.BeginUpdate();
                double standardEmi = (aggrement != null) ? aggrement.Rest_EMI : 0;
                if (standardEmi <= 0) return;

                // 1. Calculate Waterfall for ALL existing rows
                double runningBalance = (currentIndex == 0)
                    ? customer_curr_balance
                    : Convert.ToDouble(Default_Customer_Reciept_Table.Rows[currentIndex - 1]["Balance"]);

                for (int i = currentIndex; i < Default_Customer_Reciept_Table.Rows.Count; i++)
                {
                    DataRow row = Default_Customer_Reciept_Table.Rows[i];

                    // Only update Due Amount for extension rows (-1)
                    // Note: -2 (Partial) Due Amount is now managed by HandlePartialPayment
                    if (row["Code"].ToString() == "-1")
                    {
                        double dAmt = (runningBalance > standardEmi) ? standardEmi : runningBalance;
                        row["Due Amount"] = dAmt.ToString("0.00");
                    }

                    double received = 0;
                    double.TryParse(row["Recieved Amount"]?.ToString(), out received);

                    runningBalance -= received;
                    //row["Balance"] = runningBalance;
                }

                // 2. Pruning: Remove empty extension rows if balance is cleared
                for (int i = Default_Customer_Reciept_Table.Rows.Count - 1; i > currentIndex; i--)
                {
                    DataRow rowToPrune = Default_Customer_Reciept_Table.Rows[i];
                    double rowRec = 0; double.TryParse(rowToPrune["Recieved Amount"]?.ToString(), out rowRec);
                    double prevBal = Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i - 1]["Balance"]);

                    if (rowToPrune["Code"].ToString() == "-1" && rowRec <= 0 && prevBal <= 0)
                    {
                        Default_Customer_Reciept_Table.Rows.RemoveAt(i);
                    }
                }
                Default_Customer_Reciept_Table.AcceptChanges();

                // 3. GENERATION: Add new months if balance remains at the absolute bottom
                int loopSafety = 0;
                while (runningBalance > 0 && loopSafety < 100 && currentIndex >= real_last_row)
                {
                    loopSafety++;
                    DataRow currentBottom = Default_Customer_Reciept_Table.Rows[Default_Customer_Reciept_Table.Rows.Count - 1];

                    int lastSrNo = Convert.ToInt32(currentBottom["Sr.No"]);
                    DateTime lastDate = DateTime.ParseExact(currentBottom["Due Date"].ToString(), "dd-MM-yyyy", null);
                    double nextDue = (runningBalance > standardEmi) ? standardEmi : runningBalance;

                    DataRow newRow = Default_Customer_Reciept_Table.NewRow();
                    newRow["Sr.No"] = lastSrNo + 1;
                    newRow["Code"] = -1;
                    newRow["Due Date"] = lastDate.AddMonths(1).ToString("dd-MM-yyyy");
                    newRow["Due Amount"] = nextDue.ToString("0.00");
                    newRow["Reciept Date"] = lastDate.AddMonths(1).ToString("dd-MM-yyyy");
                    newRow["Recieved Amount"] = DBNull.Value;
                    newRow["EMI #"] = DBNull.Value;
                    newRow["Balance"] = DBNull.Value;
                    newRow["Remarks"] = DBNull.Value;

                    Default_Customer_Reciept_Table.Rows.Add(newRow);
                    runningBalance -= nextDue;
                }
            }
            catch (Exception) { }
            finally { gridView1.EndUpdate(); }
        }
       
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void list_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                // 1. Force the active editor to save its current value to the row
                if (gridView1.ActiveEditor != null)
                {
                    gridView1.CloseEditor();
                }

                // 2. Ensure the row is validated and data is pushed to the DataTable
                gridView1.UpdateCurrentRow();

                // 3. Call your Save method
                this.Save();

                // 4. Reset focus to Ref No
                ref_no_inp.Focus();

                // 5. Tell the system we handled this key so it doesn't beep
                e.Handled = true;
            }

        }

        private void view_agreement_btn_Click(object sender, EventArgs e)
        {
            Edit_Aggrement edit_aggrement = new Edit_Aggrement(aggrement.Aggrement_Id);
            UC_Opener_Form form = new UC_Opener_Form("Agreement Details", edit_aggrement);
            edit_aggrement.uc_opener = form;
            form.Show(this);
        }

        private void insert_row_btn_Click(object sender, EventArgs e)
        {
            int focusedRowHandle = gridView1.FocusedRowHandle;
            HandlePartialPayment(focusedRowHandle, true);
            gridView1.FocusedRowHandle = focusedRowHandle--; 
        }

        private void add_row_btn_Click(object sender, EventArgs e)
        {
            int focusedRowHandle = gridView1.FocusedRowHandle;
            HandlePartialPayment(focusedRowHandle);
            gridView1.FocusedRowHandle = focusedRowHandle++;
        }

        private void customers_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if(customers_cmb.Text != "")
            {
                father_name_inp.Text = customers_cmb.Properties.(customers_cmb.GetSelectedDataRow());
            }
        }
    }
}
