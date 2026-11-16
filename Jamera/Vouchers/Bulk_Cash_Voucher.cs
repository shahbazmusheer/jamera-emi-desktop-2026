using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Sql.DataApi;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Senders;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Jamera.Aggrements;
using Jamera.Collections;
using Jamera.Items.Stores;
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
        Collections.AggrementsCollection aggrementsCollection = new Collections.AggrementsCollection();
        public DataTable cash_voucher_emi_items_table = new DataTable();
        Vouchers_Controller v_controller = new Vouchers_Controller();
        Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
        DataTable expence_items_table = new DataTable();

        DataTable Default_Customer_Reciept_Table = new DataTable();
        DataTable DeletedRows_Table = new DataTable();
        Collections.VoucherCollection voucherCollection = new Collections.VoucherCollection();
        Aggrements.Aggrements_Controller aggrements_controller = new Aggrements.Aggrements_Controller();
        Aggrements.Aggrement aggrement;
        int real_last_row = -1;
        int maxLockedRowIndex = -1;
        Store selectedStore = null;


        Double reciepts_total = 0;
        Double customer_curr_balance = 0;
        public Bulk_Cash_Voucher()
        {
            InitializeComponent();
            sqlDataSource1.Fill();

            Default_Customer_Reciept_Table = voucherCollection.RecieptsTable().Clone();
            list.DataSource = Default_Customer_Reciept_Table;
            DeletedRows_Table = Default_Customer_Reciept_Table.Clone();
            loadReceiptStatusItems();
            receipts_month_datepicker.DateTime = DateTime.Now.AddMonths(-1);
        }

        public void loadReceiptStatusItems()
        {

            emi_status_cmb.Items.Clear();
            foreach( string item in voucherCollection.ReceiptStatusItems())
            {
                emi_status_cmb.Items.Add(item);
            }
        }
        private void store_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (store_cmb.ContainsFocus == true)
            {
                if (store_cmb.Text != "")
                {
                    int storeId = Convert.ToInt32(store_cmb.EditValue);
                    selectedStore = new Stores_Controller().Get_Store(storeId);
                    sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query_1"]);
                    CustomSqlQuery query = new CustomSqlQuery();
                    query.Sql = @"select stores.area_code as 'Area Code',accounts.id as 'Code', accounts.name as 'Name',accounts.father_name as 'Father Name', accounts.id_card_no as 'CNIC', accounts.phone as 'Office Phone', accounts.home_phone as 'Home Phone', accounts.balance as 'Balance' from (dbo.accounts accounts left join dbo.stores stores on (stores.id = accounts.store_id)) WHERE accounts.account_group_id='1002' and accounts.store_id='" + storeId + "'";
                    query.Name = "Query_1";
                    sqlDataSource1.Queries.Add(query);
                    sqlDataSource1.RebuildResultSchema();
                    sqlDataSource1.Fill();
                    items_cmb.Refresh();
                    ref_no_inp.Text = aggrementsCollection.getRefPrefix(selectedStore); ;
                    ref_no_inp.Focus();
                    ref_no_inp.SelectionStart = ref_no_inp.Text.Length;
                }
            }
        }


        public void Load_Customer_Dues()
        {
            // Fetch data and create a copy
            //Default_Customer_Reciept_Table = aggrements_controller.Get_Customer_Dues_Table_For_Reciepts_Adjustment(ref_no_inp.Text).Copy();
            Default_Customer_Reciept_Table = aggrements_controller.Get_Aggrement_Dues_Table(aggrement).Copy();

            // Initialize the deleted rows tracker with the exact same columns
            DeletedRows_Table = Default_Customer_Reciept_Table.Clone();

            // FIX: Remove the Primary Key constraint so multiple '-1' rows can exist
            Default_Customer_Reciept_Table.PrimaryKey = null;

            foreach (DataColumn col in Default_Customer_Reciept_Table.Columns)
            {
                if (col.Caption != "Sr.No" || col.Caption != "Balance")
                {
                    col.ReadOnly = false;
                    col.AllowDBNull = true;
                }
                col.Unique = false; // Ensure 'Code' doesn't have a unique constraint
            }

            // 3. Logic: Set Receipt Date and Find the Last Locked Row Index
            maxLockedRowIndex = -1; // Reset
            for (int i = 0; i < Default_Customer_Reciept_Table.Rows.Count; i++)
            {
                DataRow row = Default_Customer_Reciept_Table.Rows[i];

                // Set Receipt Date = Due Date if null
                if (row["Receipt Date"] == DBNull.Value || string.IsNullOrWhiteSpace(row["Receipt Date"].ToString()))
                {
                    row["Receipt Date"] = row["Due Date"];
                    row["Received Amount"] = DBNull.Value;
                }

                // Check if this row is fixed (Value is "1")
                // Note: Using .ToString() to handle potential int or string types from DB
                //if (row["Is Return Fixed"] != DBNull.Value && row["Is Return Fixed"].ToString() == "1")
                if (row["Balance"] != DBNull.Value)
                {
                    if(Convert.ToDouble(row["Balance"]) > 0 || Convert.ToDouble(row["Is Return Fixed"]) > 0)
                        maxLockedRowIndex = i; // This stores the latest row that is fixed
                }

            }

            list.DataSource = Default_Customer_Reciept_Table;
            setFocusableRowIndex();
            

        }

        public void setFocusableRowIndex()
        {
            if (remaining_balance_inp.Text != "")
            {
                if (Convert.ToDouble(remaining_balance_inp.Text) > 0)
                {
                    gridView1.Focus();
                    bool isCurrentMonthRowFound = false;
                    for (int i = maxLockedRowIndex + 1; i < Default_Customer_Reciept_Table.Rows.Count; i++)
                    {
                        DateTime receiptDate = Convert.ToDateTime(Default_Customer_Reciept_Table.Rows[i]["Receipt Date"]);
                        int receiptMonth = receiptDate.Month;
                        int receiptYear = receiptDate.Year;

                        DateTime currentDate = receipts_month_datepicker.DateTime;
                        int currentMonth = currentDate.Month;
                        int currentYear = currentDate.Year;
                        if (receiptMonth == currentMonth && receiptYear == currentYear)
                        {
                            gridView1.FocusedRowHandle = i;
                            isCurrentMonthRowFound = true;
                            break;
                        }
                        else if (receiptMonth < currentMonth && receiptYear <= currentYear && Default_Customer_Reciept_Table.Rows[i]["Status"].ToString() == "Normal")
                        {
                            Default_Customer_Reciept_Table.Rows[i]["Status"] = "Skipped";
                        }
                    }

                    if (!isCurrentMonthRowFound)
                    {
                        gridView1.FocusedRowHandle = maxLockedRowIndex + 1;
                    }

                    gridView1.FocusedColumn = gridView1.Columns["Receipt Date"];
                    gridView1.ShowEditor();
                }
            }
        }


        private void remaining_balance_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.D) || e.KeyCode == Keys.Enter)
            {
                this.Set_Item_To_Cart();
            }
        }

        public void Set_Item_To_Cart()
        {
            gridView1.Focus();
            gridView1.SelectCell(gridView1.FocusedRowHandle, gridView1.Columns["EMI No"]);
        }
        private void items_cmb_KeyDown(object sender, KeyEventArgs e)
        {

        }

        public void Save()
        {
            try
            {
                gridView1.CloseEditor();
                gridView1.UpdateCurrentRow();

                // 1. Basic Validations
                if (store_cmb.EditValue == null) { XtraMessageBox.Show("Select Store!"); store_cmb.Focus(); return; }
                if (aggrement == null) { XtraMessageBox.Show("Load Ref.No first!"); ref_no_inp.Focus(); return; }

                //// 2. Filter Table: Skip advance row
                DataTable entriesToProcess = Default_Customer_Reciept_Table.Clone();
                if (Default_Customer_Reciept_Table.Rows.Count > 0)
                {
                    entriesToProcess = Default_Customer_Reciept_Table.Copy();
                    entriesToProcess.Rows.RemoveAt(0);
                }


                if (entriesToProcess.Rows.Count == 0 && DeletedRows_Table.Rows.Count == 0)
                {
                    //XtraMessageBox.Show("No new changes to save.");
                    //return;
                    Reset_Fields();
                    return;
                }

                // 3. Send to Controller
                int currentStoreId = Convert.ToInt32(store_cmb.EditValue);
                int currentCustomerId = Convert.ToInt32(customers_cmb.EditValue);
                int currentItemId = (items_cmb.Tag?.ToString() == "MULTIPLE") ? -1 : Convert.ToInt32(items_cmb.EditValue);

                int result = v_controller.Store_Receipts_Table(
                    entriesToProcess,
                    DeletedRows_Table,
                    ref_no_inp.Text,
                    currentStoreId,
                    currentCustomerId,
                    currentItemId,
                    maxLockedRowIndex
                );

                if (result > 0)
                {
                    //XtraMessageBox.Show("Voucher Saved Successfully");
                    Reset_Fields();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error: " + ex.Message);
            }
        }

        public void updateRefNo(int value = 1, bool autoLoadDetails = true)
        {

            items_cmb.Text = null;
            customers_cmb.Text = null;
            Default_Customer_Reciept_Table.Clear();
            remaining_balance_inp.Text = "";


            int refNo = (Convert.ToInt32(ref_no_inp.Text.Split('-')[2])+value);
            string finalRefNo = (refNo < 10) ? "0" + (refNo).ToString() : (refNo).ToString();
            ref_no_inp.Text = string.Join("-", ref_no_inp.Text.Split('-').Take(2)) + "-" + finalRefNo;
            ref_no_inp.Focus();
            ref_no_inp.SelectionStart = ref_no_inp.Text.Length;

            if (autoLoadDetails)
            {
                loadDetails(value);
            }
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

        private void loadDetails(int next_value = 1)
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
                ignore_zero_balances_check.Checked = false;
                return;
            }
            else if (ignore_zero_balances_check.Checked && aggrement.Current_Balance <= 0)
            {
                updateRefNo(next_value);
                return;
            }
            else
            {
                customers_cmb.EditValue = aggrement.Customer_Id;
                if (customers_cmb.Text == "")
                {
                    XtraMessageBox.Show("Customer not found for this agreement!");
                    //Reset_Fields();
                    ignore_zero_balances_check.Checked = false;
                    return;
                }
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
            Bulk_Cash_Voucher UC = new Bulk_Cash_Voucher();
            new UC_Opener_Form("Bulk Cash Voucher", UC) { WindowState = FormWindowState.Maximized }.Show(this);
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
            try
            {
                // 1. EMI Serial Validation
                if (e.Column.FieldName == "EMI No" && gridView1.GetFocusedRowCellValue("EMI No").ToString() != "")
                {
                    helper_Class.IfEMINoExists(Convert.ToInt32(gridView1.GetFocusedRowCellValue("EMI No")),
                        Convert.ToInt32(store_cmb.EditValue),
                        Convert.ToDateTime(gridView1.GetFocusedRowCellValue("Receipt Date")),
                        true, Default_Customer_Reciept_Table, "EMI No", gridView1.FocusedRowHandle);
                }

                // 2. Main Payment Logic
                if (e.Column.FieldName == "Received Amount" || e.Column.FieldName == "Status")
                {
                    double received = 0;
                    double due = 0;
                    int lastBalanceIndex = -1;
                    double.TryParse(e.Value?.ToString(), out received);
                    double.TryParse(gridView1.GetFocusedRowCellValue("Due Amount")?.ToString(), out due);

                    // 3. Recalculate Balance Waterfall
                    // Existing loop to calculate the 'Balance' column for current rows
                    Double collected_amt = 0;
                    for (int i = maxLockedRowIndex + 1; i < Default_Customer_Reciept_Table.Rows.Count; i++)
                    {
                        if (Default_Customer_Reciept_Table.Rows[i]["Received Amount"] != DBNull.Value || Default_Customer_Reciept_Table.Rows[i]["Received Amount"].ToString() != "")
                        {
                            collected_amt = collected_amt + Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i]["Received Amount"]);
                            if (collected_amt > 0 && Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i]["Received Amount"]) > 0)
                            {
                                double actualBalance = aggrement.Balance;
                                if (maxLockedRowIndex > -1)
                                {
                                    actualBalance = Convert.ToDouble(Default_Customer_Reciept_Table.Rows[maxLockedRowIndex]["Balance"]);
                                }
                                Double curr_rem_bal = actualBalance - collected_amt;
                                Default_Customer_Reciept_Table.Rows[i]["Received Amount"] = Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i]["Received Amount"]).ToString("0.00");
                                Default_Customer_Reciept_Table.Rows[i]["Balance"] = Convert.ToDouble(curr_rem_bal).ToString("0.00");
                                lastBalanceIndex = i;
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
                    autoCalculateEMI();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void resetSerialNumbers()
        {
            for (int i = 0; i < Default_Customer_Reciept_Table.Rows.Count; i++)
            {
                Default_Customer_Reciept_Table.Rows[i]["Sr.No"] = i + 1;
            }
        }
        private void HandleNewRow(int currentRowHandle, bool isIsertedRow = false, double dueAmount = 0)
        {
            try
            {
                int dsIndex = gridView1.GetDataSourceRowIndex(currentRowHandle);
                int nextDsIndex = currentRowHandle;

                // Check if a next row actually exists in the data table
                bool nextRowExists = nextDsIndex < Default_Customer_Reciept_Table.Rows.Count;

                DataRow currentDataRow = Default_Customer_Reciept_Table.Rows[dsIndex];
                string date;
                if (isIsertedRow)
                {

                    date = Convert.ToDateTime(currentDataRow["Due Date"]).AddMonths(-1).ToShortDateString();
                    nextDsIndex = dsIndex; // Insert above the current row
                }
                else
                {
                    date = Convert.ToDateTime(currentDataRow["Due Date"]).AddMonths(1).ToShortDateString();
                    nextDsIndex = dsIndex + 1;
                }

                if (nextDsIndex <= maxLockedRowIndex || aggrement.Current_Balance <= 0) return;

                gridView1.BeginUpdate();

                DataRow newRow = Default_Customer_Reciept_Table.NewRow();

                newRow["Code"] = -2; // Partial Month Marker

                // Keep receipt info null for user
                newRow["Due Date"] = date;
                newRow["Receipt Date"] = date;
                if(dueAmount > 0)
                {
                    newRow["Due Amount"] = dueAmount.ToString("0.00");
                }
                else
                {
                    newRow["Due Amount"] = aggrement.First_EMI.ToString("0.00");
                }
                newRow["Status"] = "Normal";
                newRow["Received Amount"] = DBNull.Value;
                newRow["EMI No"] = DBNull.Value;
                newRow["Balance"] = DBNull.Value;
                newRow["Remarks"] = DBNull.Value;
                if (nextDsIndex < 0) nextDsIndex = 0;
                Default_Customer_Reciept_Table.Rows.InsertAt(newRow, nextDsIndex);
                real_last_row++;
                gridView1.EndUpdate();
                gridView1.RefreshData();
                gridView1.FocusedRowHandle = isIsertedRow ? nextDsIndex : nextDsIndex + 1;

            }
            catch (Exception ex) { XtraMessageBox.Show("Row Addition Error: " + ex.Message); }
            resetSerialNumbers();
            autoCalculateEMI();
        }
        private void HandleRowDelete(int RowHandle)
        {
            try
            {
                int dsIndex = gridView1.GetDataSourceRowIndex(RowHandle);
                if (dsIndex < 0) return;

                // Validation: Block deleting fixed/locked rows
                if (dsIndex <= maxLockedRowIndex)
                {
                    XtraMessageBox.Show("This row is locked and cannot be deleted.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DataRow dataRow = Default_Customer_Reciept_Table.Rows[dsIndex];

                // Ensure we don't try to delete something already deleted
                if (dataRow.RowState == DataRowState.Deleted) return;

                // Confirmation logic
                //if (XtraMessageBox.Show("Are you sure you want to delete the selected row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                //{

                //}

                gridView1.BeginUpdate();

                // If it's a real row from the database (Code > 0)
                if (dataRow["Code"] != DBNull.Value && Convert.ToInt32(dataRow["Code"]) > 0 && dataRow["Status"].ToString() != "Skipped")
                {
                    // CRITICAL: Ensure table is initialized before importing
                    if (DeletedRows_Table == null || DeletedRows_Table.Columns.Count == 0)
                    {
                        DeletedRows_Table = Default_Customer_Reciept_Table.Clone();
                        real_last_row--;
                    }

                    DeletedRows_Table.ImportRow(dataRow);
                }

                // Perform the deletion
                Default_Customer_Reciept_Table.Rows.Remove(dataRow);

                gridView1.EndUpdate();

                // Refresh visuals and math
                resetSerialNumbers();

                // Update waterfall for the row that now occupies this position
                autoCalculateEMI();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Delete Logic Error: " + ex.Message);
            }
        }
        public void autoCalculateEMI()
        {
            int currentIndex = getLastBalanceRowIndex();
            try
            {
                double standardEmi = (aggrement != null) ? aggrement.Rest_EMI : 0;
                if (standardEmi <= 0) return;

                // 1. Calculate Waterfall for ALL existing rows
                double runningBalance = (currentIndex == 0) ? aggrement.Balance : Convert.ToDouble(Default_Customer_Reciept_Table.Rows[currentIndex]["Balance"]);
                for (int i = currentIndex+1; i < Default_Customer_Reciept_Table.Rows.Count; i++)
                {
                    DataRow row = Default_Customer_Reciept_Table.Rows[i];
                    if (row["Status"].ToString() == "Skipped")
                    {
                        continue;
                    }

                    // Only update Due Amount for extension rows (-1)
                    // Note: -2 (Partial) Due Amount is now managed by HandlePartialPayment
                    double nextDue = (runningBalance > standardEmi) ? standardEmi : runningBalance;
                    row["Due Amount"] = nextDue.ToString("0.00");

                    double received = 0;
                    double.TryParse(row["Received Amount"]?.ToString(), out received);


                    double balance = 0;
                    double.TryParse(row["Balance"]?.ToString(), out balance);
                    
                    //row["Balance"] = runningBalance;

                    if (runningBalance <= 0 && received <= 0 && auto_calculate_emi_check.Checked)
                    {
                        //XtraMessageBox.Show($"Row {row["Sr.No"].ToString()} has {runningBalance} running balance and has no received amount and the running balance is zero. This row will be deleted.", "Auto Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HandleRowDelete(i);
                    }

                    runningBalance -= nextDue;
                }

                if(!auto_calculate_emi_check.Checked) return;
                // 3. GENERATION: Add new months if balance remains at the absolute bottom
                int loopSafety = 0;
                int lastRowIndex = Default_Customer_Reciept_Table.Rows.Count - 1;
                while (runningBalance > 0 && loopSafety < 100)
                {
                    loopSafety++;
                    DataRow currentBottom = Default_Customer_Reciept_Table.Rows[Default_Customer_Reciept_Table.Rows.Count - 1];


                    int lastSrNo = Convert.ToInt32(currentBottom["Sr.No"]);
                    DateTime lastDate = DateTime.ParseExact(currentBottom["Due Date"].ToString(), "dd-MM-yyyy", null);
                    double nextDue = (runningBalance > standardEmi) ? standardEmi : runningBalance;
                    HandleNewRow(lastRowIndex, false, nextDue);
                    lastRowIndex++;
                    
                    runningBalance -= nextDue;
                }
            }
            catch (Exception) { }
            //finally { gridView1.EndUpdate(); }
        }

        private int getLastBalanceRowIndex()
        {
            int index = -1;
            for (int i = 0; i < Default_Customer_Reciept_Table.Rows.Count; i++)
            {
                DataRow row = Default_Customer_Reciept_Table.Rows[i];

                double balance = 0;
                double.TryParse(row["Balance"]?.ToString(), out balance);
                if (balance > 0 )
                {
                    index = i;
                }
            }

            return index;
        }

        private void list_ProcessGridKey(object sender, KeyEventArgs e)
        {
            int focuedRow = gridView1.FocusedRowHandle;
            if (ref_no_inp.ContainsFocus && e.KeyCode == Keys.Down)
            {
                gridView1.Focus();
            }
            if (list.ContainsFocus && e.KeyCode == Keys.Up && gridView1.FocusedRowHandle == 0)
            {
                ref_no_inp.Focus();
            }
            if (ref_no_inp.ContainsFocus && e.KeyCode == Keys.Up)
            {
                store_cmb.Focus();
            }
            if (list.ContainsFocus && e.KeyCode == Keys.Enter)
            {
                if(gridView1.FocusedColumn == gridView1.Columns["Received Amount"])
                {
                    gridView1.FocusedRowHandle = focuedRow + 1;
                    gridView1.FocusedColumn = gridView1.Columns["Receipt Date"];
                }
                else
                {
                    gridView1.FocusedColumn = gridView1.Columns[gridView1.FocusedColumn.VisibleIndex + 1];
                }
            }
            if (e.Control && (e.KeyCode == Keys.N || e.KeyCode == Keys.Right))
            {
                this.updateRefNo();
            }
            if (list.ContainsFocus && e.Control && e.KeyCode == Keys.I)
            {
                HandleNewRow(gridView1.FocusedRowHandle, true);
            }
            if (list.ContainsFocus && e.Control && (e.KeyCode == Keys.D || e.KeyCode == Keys.Delete))
            {
                HandleRowDelete(gridView1.FocusedRowHandle);
            }
            if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
            {
                loadDetails();
            }
            if (e.Control && (e.KeyCode == Keys.P || e.KeyCode == Keys.Left))
            {
                this.updateRefNo(-1);
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                // 1. Force the active editor to save its current value to the row
                if (gridView1.ActiveEditor != null)
                {
                    gridView1.CloseEditor();
                    // 2. Ensure the row is validated and data is pushed to the DataTable
                    gridView1.UpdateCurrentRow();
                }


                // 3. Call your Save method
                this.Save();

                // 4. Reset focus to Ref No
                //ref_no_inp.Focus();

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
            HandleNewRow(focusedRowHandle, true);
            gridView1.FocusedRowHandle = focusedRowHandle--;
        }

        private void add_row_btn_Click(object sender, EventArgs e)
        {
            int focusedRowHandle = gridView1.FocusedRowHandle;
            HandleNewRow(focusedRowHandle);
            gridView1.FocusedRowHandle = focusedRowHandle++;
        }

        private void customers_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (customers_cmb.Text != "")
            {
                Accounts.Account customer = accounts_controller.Get_Account(Convert.ToInt32(customers_cmb.EditValue));

                father_name_inp.Text = customer.Father_Name;
                cnic_no_inp.Text = customer.Id_Card_No;

                string Phone = customer.Phone;
                string officePhone = customer.Phone;
                string homePhone = customer.Home_Phone;

                phone_no_inp.Text = !string.IsNullOrWhiteSpace(homePhone)
                    ? homePhone
                    : !string.IsNullOrWhiteSpace(officePhone)
                    ? officePhone
                    : Phone;

            }
            else
            {
                father_name_inp.Text = "";
                cnic_no_inp.Text = "";
                phone_no_inp.Text = "";
                return;
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
                
                //&& gridView1.GetFocusedRowCellValue(gridView1.Columns["Status"]).ToString() != "Short List"
                if (gridView1.FocusedColumn == gridView1.Columns["Received Amount"])
                {
                    e.Cancel = true;
                    return;
                }
                else if((gridView1.GetFocusedRowCellValue(gridView1.Columns["Status"]).ToString() == "Item Returned"))
                {
                    if(gridView1.FocusedColumn != gridView1.Columns["EMI No"]){

                        e.Cancel = true;
                        return;
                    }
                }
            }

            if(gridView1.FocusedColumn == gridView1.Columns["Sr.No"] || gridView1.FocusedColumn == gridView1.Columns["Balance"] || dataSourceIndex == 0)
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
                        editor.SelectionLength = editor.Text.Split('-')[0].Length;
                    }
                }));
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    int dataSourceIndex = view.GetDataSourceRowIndex(e.RowHandle);
            //    if (dataSourceIndex <= maxLockedRowIndex)
            //    {

            //        e.Appearance.BackColor = Color.LightGray;
            //        e.Appearance.ForeColor = Color.DimGray;
                    
            //    }
            //}
        }

        private void delete_row_btn_Click(object sender, EventArgs e)
        {
            int focusedRowHandle = gridView1.FocusedRowHandle;
            HandleRowDelete(focusedRowHandle);
        }

        private void ignore_zero_balances_check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void emi_status_cmb_EditValueChanged(object sender, EventArgs e)
        {
            int focusedRow = gridView1.FocusedRowHandle;
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            gridView1.FocusedRowHandle = focusedRow;
        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle < 0) return;

            int dataSourceIndex = view.GetDataSourceRowIndex(e.RowHandle);

            // Short List check - applies to whole row
            object statusValue = view.GetRowCellValue(e.RowHandle, "Status");
            if (statusValue != null && (statusValue.ToString() != "Normal"))
            {
                if(statusValue.ToString() == "Discount Given")
                {
                    e.Appearance.BackColor = Color.DarkGray;
                    e.Appearance.BackColor2 = Color.DarkGray;
                    e.Appearance.ForeColor = Color.DimGray;
                    return;
                }
                if (statusValue.ToString() == "Skipped")
                {
                    e.Appearance.BackColor = Color.LightYellow; // or Color.FromArgb(255, 205, 210)
                    e.Appearance.BackColor2 = Color.LightYellow;
                    e.Appearance.ForeColor = Color.FromArgb(100,100, 0);
                    return;
                }

                e.Appearance.BackColor = Color.LightPink; // or Color.FromArgb(255, 205, 210)
                e.Appearance.BackColor2 = Color.LightPink;
                e.Appearance.ForeColor = Color.DarkRed;
                return;
            }

            // Locked row styling - skip Status and Remarks
            if (e.Column.FieldName != "Received Amount" && e.Column.FieldName != "Balance" && e.Column.FieldName != "Sr.No" && dataSourceIndex > 0)
                return;


            if (dataSourceIndex > maxLockedRowIndex && e.Column.FieldName != "Sr.No" && e.Column.FieldName != "Balance") return; // not locked row

            e.Appearance.BackColor = Color.LightGray;
            e.Appearance.BackColor2 = Color.LightGray;
            e.Appearance.ForeColor = Color.DimGray;
        }

        private void auto_calculate_emi_check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void emi_status_cmb_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void emi_status_cmb_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
