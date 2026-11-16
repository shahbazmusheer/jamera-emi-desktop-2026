using DevExpress.XtraEditors;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Jamera.Aggrements;
using Jamera.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamera.Vouchers
{
    public partial class Receipts_Adjustment : DevExpress.XtraEditors.XtraForm
    {
        Helper_Class helper_Class = new Helper_Class();
        Aggrements.Aggrements_Controller agreements_controller = new Aggrements.Aggrements_Controller();
        DataTable Default_Customer_Reciept_Table = new DataTable();
        public Cash_Voucher reciepts_entry { get; set; }
        int store_id = -1;
        String store_name = null;
        String ref_no = null;
        int customer_id = -1;
        int item_id = -1;
        String item_name = null;
        String customer_name = null;
        Double reciepts_total = 0;
        Double customer_curr_balance = 0;
        Aggrements.Aggrements_Controller aggrements_controller = new Aggrements.Aggrements_Controller();
        Aggrements.Aggrement aggrement;
        int real_last_row = -1;
        public Receipts_Adjustment(int store_id,String store_name,int customer_id,String customer_name,String ref_no,String Rec_Date,String Due_Date,Double Due_Amount,Double Current_Balance,int item_id,String item_name)
        {
            InitializeComponent();
            this.customer_id = customer_id;
            this.aggrement = aggrements_controller.Get_Aggrement_By_Ref_No(ref_no);
            this.customer_name = customer_name;
            this.store_id = store_id;
            this.store_name = store_name;
            store_name_lbl.Text = store_name;
            cust_name_lbl.Text = customer_name;
            this.item_id = item_id;
            this.item_name = item_name;
            ref_lbl.Text = ref_no;
            this.ref_no = ref_no;
            prev_bal_lbl.Text = Current_Balance.ToString();
            this.customer_curr_balance = Current_Balance;
            Load_Customer_Dues();
        }

        public void Load_Customer_Dues()
        {
            // Fetch data and create a copy
            Default_Customer_Reciept_Table = aggrements_controller.Get_Customer_Dues_Table_For_Reciepts_Adjustment(this.ref_no).Copy();

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

        private void Receipts_Adjustment_Load(object sender, EventArgs e)
        {
            gridView1.Focus();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Double reciepts_totals = this.reciepts_total;
            for (int i = 0; i < Default_Customer_Reciept_Table.Rows.Count; i++)
            {
                Double coled_amt = Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"]);
                int code = Convert.ToInt32(Default_Customer_Reciept_Table.Rows[i]["Code"]);
                if (coled_amt > 0 || code < 0)
                {
                    DataRow dr = reciepts_entry.cash_voucher_emi_items_table.NewRow();
                    if (ref_lbl.Text != "")
                    {
                        dr["Ref.No"] = ref_lbl.Text;
                    }
                    else
                    {
                        dr["Ref.No"] = DBNull.Value;
                    }
                    dr["Item Code"] = this.item_id;
                    dr["Item"] = this.item_name;
                    dr["Customer Code"] = this.customer_id;
                    dr["Customer"] = this.customer_name;
                    dr["Due Date"] = Convert.ToString(Default_Customer_Reciept_Table.Rows[i]["Due Date"]);
                    dr["EMI #"] = Convert.ToString(Default_Customer_Reciept_Table.Rows[i]["EMI #"]);
                    dr["Code"] = Convert.ToString(Default_Customer_Reciept_Table.Rows[i]["Code"]);
                    dr["Date"] = Convert.ToString(Default_Customer_Reciept_Table.Rows[i]["Reciept Date"]);
                    dr["Due Amount"] = Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i]["Due Amount"]);
                    //dr["Recieved Date"] = Convert.ToString(Default_Customer_Reciept_Table.Rows[i]["Paid Date"]);
                    dr["Recieved Amt"] = Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"]);
                    dr["Balance"] = Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i]["Balance"]);
                    reciepts_entry.cash_voucher_emi_items_table.Rows.Add(dr);
                }
            }
            reciepts_entry.Reset_Emi_Item_Entries();
            reciepts_entry.Refresh_Final_Values();
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Double collected_amt = Convert.ToDouble("0");
            //if (collected_amt > 0)
            //{
            //    Double selected_amt = 0;
            //    for (int i = 0; i < gridView1.RowCount; i++)
            //    {

            //        Double paid_amt = Convert.ToDouble(gridView1.GetRowCellValue(i, gridView1.Columns[5]));
            //        Double due_amt = Convert.ToDouble(gridView1.GetRowCellValue(i, gridView1.Columns[3]));
            //        int code = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns[1]));
            //        if (collected_amt > 0)
            //        {
            //            if (gridView1.IsRowSelected(i) == true)
            //            {
            //                if (collected_amt <= due_amt)
            //                {
            //                    gridView1.SetRowCellValue(i, gridView1.Columns[4], DateTime.Now.ToString("dd-MM-yyyy"));
            //                    gridView1.SetRowCellValue(i, "Paid Amount", collected_amt);
            //                    gridView1.SelectRow(i);
            //                    selected_amt = selected_amt + collected_amt;
            //                    collected_amt = 0;
            //                }
            //                else
            //                {
            //                    gridView1.SetRowCellValue(i, gridView1.Columns[4], DateTime.Now.ToString("dd-MM-yyyy"));
            //                    gridView1.SelectRow(i);
            //                    gridView1.SetRowCellValue(i, gridView1.Columns[5], due_amt);
            //                    collected_amt = collected_amt - due_amt;
            //                    selected_amt = selected_amt + due_amt;
            //                }
            //            }
            //            else
            //            {
            //                gridView1.SetRowCellValue(i, gridView1.Columns[4], null);
            //                gridView1.SetRowCellValue(i, "Paid Amount", 0);
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    selected_amt_inp.Text = selected_amt.ToString();
            //    entries_counter.Text = "Selected Committees Count : " + gridView1.SelectedRowsCount;
            //}
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(list.ContainsFocus == true)
            {
                int ind = gridView1.GetFocusedDataSourceRowIndex();
                GridView view = sender as GridView;
                if(e.Column.FieldName == "Reciept Date")
                {
                    Default_Customer_Reciept_Table.Rows[ind]["Reciept Date"] = e.Value;
                }
                if (e.Column.FieldName == "EMI #")
                {
                    Default_Customer_Reciept_Table.Rows[ind]["EMI #"] = e.Value;
                }
                if (e.Column.FieldName == "Recieved Amount")
                {
                    if(e.Value != DBNull.Value && e.Value.ToString() != "")
                    {
                        Default_Customer_Reciept_Table.Rows[ind]["Recieved Amount"] = e.Value;
                    }
                }
            }

        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void gridView1_ColumnChanged(object sender, EventArgs e)
        {
            
        }


        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            // 1. EMI Serial Validation
            if (e.Column.FieldName == "EMI #" && gridView1.GetFocusedRowCellValue("EMI #").ToString() != "")
            {
                helper_Class.IfEMINoExists(Convert.ToInt32(gridView1.GetFocusedRowCellValue("EMI #")),
                    Convert.ToInt32(this.store_id),
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
                HandlePartialPayment(e.RowHandle);


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

                //if (e.Column.FieldName == "EMI #" && gridView1.GetFocusedRowCellValue("EMI #").ToString() != "") 
                //{
                //    helper_Class.IfEMINoExists(Convert.ToInt32(gridView1.GetFocusedRowCellValue("EMI #")), this.store_id, Convert.ToDateTime(gridView1.GetFocusedRowCellValue("Reciept Date")), true, Default_Customer_Reciept_Table, "EMI #", gridView1.FocusedRowHandle);
                //}
                //Double collected_amt = 0;
                //for (int i = 0; i < Default_Customer_Reciept_Table.Rows.Count; i++)

                //{
                //    if (Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"] != DBNull.Value && Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"].ToString() != "")
                //    {
                //        collected_amt = collected_amt + Convert.ToDouble(Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"]);
                //        if (collected_amt > 0 && Default_Customer_Reciept_Table.Rows[i]["Recieved Amount"].ToString() != "0")
                //        {
                //            Double curr_rem_bal = customer_curr_balance - collected_amt;
                //            Default_Customer_Reciept_Table.Rows[i]["Balance"] = curr_rem_bal;
                //        }
                //        else
                //        {
                //            Default_Customer_Reciept_Table.Rows[i]["Balance"] = DBNull.Value;
                //        }
                //    }
                //    else
                //    {
                //        Default_Customer_Reciept_Table.Rows[i]["Balance"] = DBNull.Value;
                //    }
                //}
            }
        }

        private void HandlePartialPayment(int currentRowHandle)
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

        private void list_Click(object sender, EventArgs e)
        {

        }
    }
}