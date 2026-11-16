using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Jamera.Properties;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace Jamera.Items
{
    public partial class Stock_Transfer : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable carts_table = new DataTable();
        DataTable Thread_Table = new DataTable();
        bool should_print = false;
        Items_Controller items_controller = new Items_Controller();
        string from_store = null;
        string to_Store = null;
        string From_Store_Message_Text = null;
        string To_Store_Message_Text = null;
        string from_store_phone = null;
        string to_store_phone = null;
        string transfer_date = null;
        int from_store_id_glob = -1;
        int to_store_id_glob = -1;
        delegate void Clear_Table();
        Thread STS_Thread;
        public Stock_Transfer()
        {
            InitializeComponent();
            //Load_Popup_Settings();
            date_picker.EditValue = DateTime.Now;
            carts_table.Columns.Add("Sr.No", typeof(Int32));
            carts_table.Columns.Add("Item Code", typeof(Int32));
            carts_table.Columns.Add("Item Name", typeof(String));
            carts_table.Columns.Add("Model", typeof(String));
            carts_table.Columns.Add("Sale Rate", typeof(Double));
            carts_table.Columns.Add("Quantity", typeof(Double));
            carts_table.Columns.Add("Remarks", typeof(String));
            Cart_Items_Container.DataSource = carts_table;
            sqlDataSource1.Fill();
            gridView6.Columns["Sr.No"].Visible = false;
            STS_Thread = new Thread(Send_Message);
            

        }

        public void Load_Popup_Settings()
        {
            int width = this.Width;
            int height = 280;
            from_store_cmb.Properties.PopupFormSize = new Size(width,height);
            to_store_cmb.Properties.PopupFormSize = new Size(width, height);
            search_item_cmb.Properties.PopupFormSize = new Size(width, height);
            model_cmb.Properties.PopupFormSize = new Size(width, height);
            fuel_expenses_paid_account_cmb.Properties.PopupFormSize = new Size(width, height);
        }
        public void Send_Message()
        {
            
            DateTime msg_date = Convert.ToDateTime(transfer_date);
            if (to_store_phone != null)
            {
                Messages.Messages_Controller messages_controller = new Messages.Messages_Controller();
                Messages.Message message = new Messages.Message();
                message.Group = "Employees";
                message.SMS_Gateway = sms_gateway_cmb.Text;
                message.Message_Text = To_Store_Message_Text;
                message.Message_Type = "English";
                message.RECIEVER_NUMBER = to_store_phone;
                goto send_message_start;
            send_message_start:
                int is_sent = -1;
                is_sent = messages_controller.Send_Message(message);
                if (is_sent == 1)
                {
                    message.Status = "Sent";
                    Console.WriteLine("Message sent susscessfuly !");
                }
                else if (is_sent == -3)
                {
                    Thread.Sleep(2000);
                    goto send_message_start;
                }
                else
                {
                    message.Status = "Draft";
                    Console.WriteLine("Message Drafted !");
                }
                messages_controller.Store_Message(message);
            }

            if (from_store != null)
            {
                if (from_store_phone != null)
                {
                    Messages.Messages_Controller messages_controller = new Messages.Messages_Controller();
                    Messages.Message message = new Messages.Message();
                    message.Group = "Employees";
                    message.SMS_Gateway = sms_gateway_cmb.Text;
                    message.Message_Type = "English";
                    message.Message_Text = From_Store_Message_Text;
                    message.RECIEVER_NUMBER = from_store_phone;
                    goto send_message_start;
                send_message_start:
                    int is_sent = -1;
                    is_sent = messages_controller.Send_Message(message);
                    if (is_sent == 1)
                    {
                        message.Status = "Sent";
                        Console.WriteLine("Message sent susscessfuly !");
                    }
                    else if (is_sent == -3)
                    {
                        Thread.Sleep(2000);
                        goto send_message_start;
                    }
                    else
                    {
                        message.Status = "Draft";
                        Console.WriteLine("Message Drafted !");
                    }
                    messages_controller.Store_Message(message);
                }
            }
            from_store = null;
            to_Store = null;
            transfer_date = null;
            from_store_phone = null;
            to_store_phone = null;
            STS_Thread.Abort();
        }

        public bool If_Item_Exists_In_Cart()
        {
            if (gridView6.DataRowCount > 0)
            {
                bool check_exists = false;

                for (int i = 0; i < gridView6.DataRowCount; i++)
                {
                    if (Convert.ToInt32(gridView6.GetRowCellValue(i, gridView6.Columns["Sr.No"])) == Convert.ToInt32(search_item_cmb.EditValue))
                    {
                        check_exists = true;
                        break;
                    }
                }
                return check_exists;
            }
            else
            {
                return false;
            }
        }
        public void Calculate_Total_Qty()
        {
            GridSummaryItem summery_item_qty = gridView6.Columns["Quantity"].SummaryItem;
            summery_item_qty.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Double total_qty = Convert.ToDouble(summery_item_qty.SummaryValue);
            total_qty_lbl.Text = string.Format("{0:#,##0}", Double.Parse(total_qty.ToString()));
        }
        public void Set_Item_To_Cart()
        {
            if(If_Item_Exists_In_Cart() != true)
            {
                if (from_store_cmb.Text == "")
                {
                    int sr_no = Convert.ToInt32(search_item_cmb.EditValue.ToString());
                    Double stock_in = Convert.ToDouble(search_item_cmb.Properties.View.GetFocusedRowCellValue("Stock"));
                    Double req_qty = Convert.ToDouble(quantity_inp.Text);
                    if (stock_in >= req_qty)
                    {
                        DataRow dr = carts_table.NewRow();
                        GridView view = search_item_cmb.Properties.View;
                        string fieldName = "Code"; // or other field name  
                        int item_code = Convert.ToInt32(view.GetRowCellValue(search_item_cmb.Properties.GetIndexByKeyValue(search_item_cmb.EditValue), fieldName));
                        dr["Item Code"] = item_code;
                        dr["Sr.No"] = sr_no;
                        dr["Item Name"] = search_item_cmb.Text;
                        dr["Model"] = model_cmb.Text;
                        dr["Quantity"] = req_qty;
                        dr["Remarks"] = item_remarks_inp.Text;
                        string sale_rate_fieldName = "Sale Rate"; // or other field name  
                        Double Sale_Rate = Convert.ToDouble(view.GetRowCellValue(search_item_cmb.Properties.GetIndexByKeyValue(search_item_cmb.EditValue), sale_rate_fieldName));
                        dr["Sale Rate"] = Sale_Rate;
                        carts_table.Rows.Add(dr);
                        search_item_cmb.Text = null;
                        model_cmb.Text = null;
                        quantity_inp.Text = null;
                        item_remarks_inp.Text = null;
                        Calculate_Total_Qty();
                        search_item_cmb.ShowPopup();
                    }
                    else
                    {
                        XtraMessageBox.Show("Stock is not enough available for required quantity !");
                        quantity_inp.Focus();
                    }
                }
                else
                {
                    //store to store
                    int sr_no = Convert.ToInt32(search_item_cmb.EditValue.ToString());
                    Stocks_Controller stocks_controller = new Stocks_Controller();
                    Double stock_in = Convert.ToDouble(search_item_cmb.Properties.View.GetFocusedRowCellValue("Stock"));
                    Double req_qty = Convert.ToDouble(quantity_inp.Text);
                    if (stock_in >= req_qty)
                    {
                        DataRow dr = carts_table.NewRow();
                        GridView view = search_item_cmb.Properties.View;
                        string fieldName = "Code"; // or other field name  
                        int item_code = Convert.ToInt32(view.GetRowCellValue(search_item_cmb.Properties.GetIndexByKeyValue(search_item_cmb.EditValue), fieldName));
                        dr["Item Code"] = item_code;
                        dr["Item Name"] = search_item_cmb.Text;
                        dr["Model"] = model_cmb.Text;
                        dr["Quantity"] = req_qty;
                        dr["Remarks"] = item_remarks_inp.Text;
                        dr["Sr.No"] = sr_no;
                        string sale_rate_fieldName = "Sale Rate"; // or other field name  
                        Double Sale_Rate = Convert.ToDouble(view.GetRowCellValue(search_item_cmb.Properties.GetIndexByKeyValue(search_item_cmb.EditValue), sale_rate_fieldName));
                        dr["Sale Rate"] = Sale_Rate;
                        carts_table.Rows.Add(dr);
                        search_item_cmb.Text = null;
                        model_cmb.Text = null;
                        quantity_inp.Text = null;
                        item_remarks_inp.Text = null;
                        Calculate_Total_Qty();
                        search_item_cmb.ShowPopup();
                    }
                    else
                    {
                        XtraMessageBox.Show("Stock is not enough available at " + from_store_cmb.Text + " for required quantity. \nAvailable Stock:" + stock_in + ".");
                        quantity_inp.Focus();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Item already exists in cart !");
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Reset_Fields();
        }

        private void search_item_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (search_item_cmb.ContainsFocus == true)
            {
                if (search_item_cmb.EditValue != null)
                {
                    GridView view = search_item_cmb.Properties.View;
                    string fieldName = "Code";
                    int item_code = Convert.ToInt32(view.GetRowCellValue(search_item_cmb.Properties.GetIndexByKeyValue(search_item_cmb.EditValue), fieldName));
                    Item item = items_controller.Get_Item(item_code);
                    model_cmb.EditValue = item.Model_Id;
                    quantity_inp.Focus();
                }
            }
        }

        private void add_item_btn_Click(object sender, EventArgs e)
        {
            UC_Opener_Form form = new UC_Opener_Form("New Item",new New_Item());
            form.ShowDialog(this);
        }

        private void quantity_inp_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void quantity_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                if(search_item_cmb.Text != "")
                {
                    Set_Item_To_Cart();
                }
            }
            else
            {
                Controls_List(sender, e);
            }
        }

        private void gridView6_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Delete)
            {
                int row_ind = gridView6.GetFocusedDataSourceRowIndex();
                carts_table.Rows.RemoveAt(row_ind);
                Calculate_Total_Qty();

            }

            if (e.Control && e.KeyCode == Keys.E)
            {
                if (gridView6.DataRowCount > 0)
                {
                    search_item_cmb.EditValue = Convert.ToInt32(gridView6.GetFocusedRowCellValue("Sr.No"));
                    search_item_cmb.Focus();

                    Item item = items_controller.Get_Item(Convert.ToInt32(gridView6.GetFocusedRowCellValue("Item Code")));
                    model_cmb.EditValue = item.Model_Id;
                    quantity_inp.Text = gridView6.GetFocusedRowCellValue("Quantity").ToString();
                    item_remarks_inp.Text = gridView6.GetFocusedRowCellValue("Remarks").ToString();
                    int row_ind = gridView6.GetFocusedDataSourceRowIndex();
                    carts_table.Rows.RemoveAt(row_ind);
                    Calculate_Total_Qty();
                    quantity_inp.Focus();
                }
            }
        }
        public void Save()
        {
            int from_store_id = -1;
            int to_store_id = -1;
            int paid_ac_id = -1;
            Double fuel_expenses = 0;
            if(fuel_expenses_inp.Text != "")
            {
                fuel_expenses = Convert.ToDouble(fuel_expenses_inp.Text);
            }
            if(fuel_expenses_paid_account_cmb.Text != "")
            {
                paid_ac_id = Convert.ToInt32(fuel_expenses_paid_account_cmb.EditValue);
            }
            if (date_picker.Text == "")
            {
                XtraMessageBox.Show("Please select date !");
                date_picker.ShowPopup();
            }
            else if (to_store_cmb.Text == from_store_cmb.Text)
            {
                XtraMessageBox.Show("Please select different stores for stock transaction !");
            }
            else if (to_store_cmb.Text == "" && from_store_cmb.Text == "")
            {
                XtraMessageBox.Show("Please select to store for stock transaction !");
            }
            else if (carts_table.Rows.Count <= 0 && search_item_cmb.Text != "")
            {
                XtraMessageBox.Show("Please add item to list !");
                quantity_inp.Focus();
            }
            else if (carts_table.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Please select items to transfer !");
                search_item_cmb.ShowPopup();
            }
            else
            {
                if (from_store_cmb.Text != "")
                {
                    from_store_id = Convert.ToInt32(from_store_cmb.EditValue);
                    from_store_id_glob = from_store_id;
                }
                else
                {
                    from_store_id_glob = -1;
                }
                if (to_store_cmb.Text != "")
                {
                    to_store_id = Convert.ToInt32(to_store_cmb.EditValue);
                    to_store_id_glob = to_store_id;
                }
                else
                {
                    to_store_id_glob = -1;
                }
                Stocks_Controller stocks_controller = new Stocks_Controller();
                int transaction_id = stocks_controller.Store_Stock_Transaction(Convert.ToDateTime(date_picker.Text), from_store_id, to_store_id, name_inp.Text, remarks_inp.Text, carts_table, paid_ac_id, fuel_expenses, gatepass_no_inp.Text);
                if (transaction_id > 0)
                {
                    if (should_print == true)
                    {
                        Stock_Transfer_Print stock_transfer_print = new Stock_Transfer_Print(transaction_id);
                        ReportPrintTool print_tool = new ReportPrintTool(stock_transfer_print);
                        print_tool.Print();
                        should_print = false;
                    }

                    if (send_msg_chkbx.CheckState == CheckState.Checked)
                    {
                        if (from_store_cmb.Text != "")
                        {
                            from_store = from_store_cmb.Properties.View.GetFocusedRowCellValue("Area Code").ToString();
                            if (from_store_cmb.Properties.View.GetFocusedRowCellValue("Phone") != DBNull.Value)
                            {
                                from_store_phone = from_store_cmb.Properties.View.GetFocusedRowCellValue("Phone").ToString();
                            }
                        }
                        to_Store = to_store_cmb.Properties.View.GetFocusedRowCellValue("Area Code").ToString();
                        if (to_store_cmb.Properties.View.GetFocusedRowCellValue("Phone") != DBNull.Value)
                        {
                            to_store_phone = to_store_cmb.Properties.View.GetFocusedRowCellValue("Phone").ToString();
                        }
                        string to_message_text = "Dear ";
                        string from_message_text = "Dear ";
                        string items_container_text = null;
                        if (to_Store != null)
                        {
                            to_message_text = to_message_text + to_Store + " Area Manager :";
                        }
                        if (from_store != null)
                        {
                            from_message_text = from_message_text + from_store + " Area Manager :";
                        }
                        int t_qty = 0;
                        for (int i = 0; i < carts_table.Rows.Count; i++)
                        {
                            int i_qty = Convert.ToInt32(carts_table.Rows[i]["Quantity"]);
                            items_container_text = items_container_text + "\n" + carts_table.Rows[i]["Item Name"].ToString() + " " + i_qty.ToString();
                            t_qty = t_qty + i_qty;
                        }
                        items_container_text = items_container_text + "\n Total Qty:" + t_qty;
                        to_message_text = to_message_text + items_container_text;
                        to_message_text = to_message_text + "\n Stock Transfered from ";

                        if (from_store != null)
                        {
                            from_message_text = from_message_text + items_container_text;
                            from_message_text = from_message_text + "\n Stock Transfered from " + from_store + " to " + to_Store + " at date " + transfer_date + ". Please consider it.";
                            to_message_text = to_message_text + from_store + " to " + to_Store + " at date " + transfer_date + ". Please consider it.";
                        }
                        else
                        {
                            to_message_text = to_message_text + "Head Office at date " + transfer_date + ". Please consider it.";
                        }
                        From_Store_Message_Text = from_message_text;
                        To_Store_Message_Text = to_message_text;
                        transfer_date = date_picker.Text;
                        if (STS_Thread.ThreadState == ThreadState.Unstarted)
                        {
                            Console.WriteLine("Thread state is unstarted !");
                            STS_Thread.Start();
                        }
                        if (STS_Thread.ThreadState == ThreadState.Aborted || STS_Thread.ThreadState == ThreadState.Stopped)
                        {
                            Console.WriteLine("Thread state aborted or stopped !");
                            STS_Thread = new Thread(Send_Message);
                            STS_Thread.Start();
                        }
                    }
                    Reset_Fields();
                    sqlDataSource1.RebuildResultSchema();
                    sqlDataSource1.Fill();
                    search_item_cmb.Update();
                    search_item_cmb.Refresh();
                }
            }
        }

        public void Reset_Fields()
        {
            name_inp.Text = null;
            remarks_inp.Text = null;
            carts_table.Clear();
            to_store_cmb.Text = null;
            from_store_cmb.Text = null;
            search_item_cmb.Text = null;
            total_qty_lbl.Text = "0";
            fuel_expenses_inp.Text = null;
            fuel_expenses_paid_account_cmb.Text = null;
            model_cmb.Text = null;
            quantity_inp.Text = null;
            item_remarks_inp.Text = null;
            gatepass_no_inp.Text = null;
            Update_From_Stores_List();
            Update_To_Stores_List();
            Update_Items_List();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        public void Update_Items_List()
        {
            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Sql = @"SELECT rank() over(order by items.id,items.name,y.sale_rate) as 'Sr.No',items.id as 'Code',items.name as 'Item',models.name as 'Model',y.sale_rate as 'Sale Rate',i_u.name as 'Unit',items.packing as 'Packing',COALESCE(SUM(y.items_stock_in - (y.items_stock_out + y.returned_quantity)),0) as 'Stock' from items left join item_manufacturers  i_m on i_m.id=items.manufacturer_id left join item_groups  i_g on i_g.id=items.group_id left join item_categories as i_g_s on i_g_s.id=items.category_id left join item_units as i_u on i_u.id=items.unit_id left join purchase_items as y on items.id=y.item_id left join item_models as models on items.model_id=models.id WHERE y.status='unblocked' and (y.items_stock_in - (y.items_stock_out + y.returned_quantity)) > 0  group by items.id ,items.name,i_u.name,Y.sale_rate,items.packing,models.name";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
            search_item_cmb.Refresh();
        }

        public void Update_From_Stores_List()
        {
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
            from_store_cmb.Refresh();
        }
        public void Update_To_Stores_List()
        {
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
            to_store_cmb.Refresh();
        }

        private void quantity_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;

            if (!(Char.IsDigit(ch) || ch == 13 || ch == 8 || ch == 46))
            {
                e.Handled = true;
            }

            int dot_counter = quantity_inp.Text.Count(f => f == '.');

            if ((quantity_inp.Text.Length <= 0 && ch == 46) || (dot_counter > 0 && ch == 46))
            {
                e.Handled = true;
            }

        }

        private void save_and_print_btn_Click(object sender, EventArgs e)
        {
            should_print = true;
            Save();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            search_item_cmb.Focus();
            UC_Opener_Form stock_transfer = new UC_Opener_Form("Stock Transfer",new Stock_Transfer());
            stock_transfer.Show();
        }

        private void from_store_cmb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int i = e.Button.Index;
            if (i == 1)
            {
                Update_From_Stores_List();
            }
            else if ( i == 2 )
            {
                Stores.New_Store form = new Stores.New_Store();
                form.is_closeable = true;
                form.is_from_store = true;
                form.stock_transfer = this;
                form.ShowDialog();
            }
        }

        private void to_store_cmb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int i = e.Button.Index;
            if (i == 1)
            {
                Update_To_Stores_List();
            }
            else if (i == 2)
            {
                Stores.New_Store form = new Stores.New_Store();
                form.is_closeable = true;
                form.is_to_store = true;
                form.stock_transfer = this;
                form.ShowDialog();
            }
        }

        private void search_item_cmb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int i = e.Button.Index;

            if (i == 1)
            {
                Update_Items_List();
            }
        }

        public void Controls_List(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && (gridView1.DataRowCount > 0 || search_item_cmb.Text != "" || from_store_cmb.Text != "" || to_store_cmb.Text != ""))
            {
                if (XtraMessageBox.Show("Are you sure, You want to cancel the purchase !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    Reset_Fields();
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                gridView1.Focus();
            }
            else if ((e.KeyCode == Keys.F5) || (e.Control && e.KeyCode == Keys.R))
            {
                Update_Items_List();
                Update_From_Stores_List();
                Update_To_Stores_List();
            }
            else if (e.KeyCode == Keys.F6 || (e.Control && e.KeyCode == Keys.N))
            {
                UC_Opener_Form form = new UC_Opener_Form("Stock Transfer", new Stock_Transfer());
                form.Show(this);
            }
            else if (e.KeyCode == Keys.F9)
            {
                search_item_cmb.Focus();
                search_item_cmb.ShowPopup();
            }
            else if (e.Control && e.KeyCode == Keys.F && e.KeyCode == Keys.S)
            {
                Stores.New_Store form = new Stores.New_Store();
                form.is_closeable = true;
                form.is_from_store = true;
                form.stock_transfer = this;
                form.ShowDialog();
            }
            else if (e.Control && e.KeyCode == Keys.T && e.KeyCode == Keys.S)
            {
                Stores.New_Store form = new Stores.New_Store();
                form.is_closeable = true;
                form.is_to_store = true;
                form.stock_transfer = this;
                form.ShowDialog();
            }
            else if (e.Control && e.KeyCode == Keys.W)
            {
                remarks_inp.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {
                should_print = true;
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }

        }

        private void date_picker_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender,e);
        }

        private void from_store_cmb_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void to_store_cmb_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void name_inp_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void search_item_cmb_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void remarks_inp_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void from_store_cmb_EditValueChanged(object sender, EventArgs e)
        {
            if (from_store_cmb.ContainsFocus == true)
            {
                if (from_store_cmb.Text != "")
                {
                    sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                    CustomSqlQuery query = new CustomSqlQuery();
                    query.Sql = @"SELECT rank() over(order by sti.item_id,items.name,models.name,sti.sale_rate) as 'Sr.No',sti.item_id as 'Code',items.name as 'Item',models.name as 'Model',sti.sale_rate as 'Sale Rate',i_u.name as 'Unit',items.packing as 'Packing',SUM((sti.stock_in + sti.sales_return ) - (sti.sold_out + sti.returned + sti.transfered)) as 'Stock' FROM stock_transaction_items as sti left join items on sti.item_id=items.id left join item_units as i_u on items.unit_id=i_u.id left join item_models as models on items.model_id=models.id WHERE (((sti.stock_in + sti.sales_return ) - (sti.sold_out + sti.returned + sti.transfered) ) > 0) and sti.store_id='" + Convert.ToInt32(from_store_cmb.EditValue) + "' GROUP BY sti.item_id,items.name,sti.sale_rate,i_u.name,items.packing,models.name";
                    query.Name = "Query";
                    sqlDataSource1.Queries.Add(query);
                    sqlDataSource1.RebuildResultSchema();
                    sqlDataSource1.Fill();
                    search_item_cmb.Refresh();
                }
                else
                {
                    Update_Items_List();
                }
            }
        }

        private void Stock_Transfer_Load(object sender, EventArgs e)
        {
            panelControl3.Size = new Size(panelControl3.Width, panelControl3.Height - panelControl11.Height);
            if (Settings.Default.default_sms_gateway == "API")
            {
                sms_gateway_cmb.Text = Settings.Default.default_sms_gateway;

            }
            else if (Settings.Default.default_sms_gateway == "Android Wifi")
            {
                sms_gateway_cmb.Text = Settings.Default.default_sms_gateway;
            }
            else if (Settings.Default.default_sms_gateway == "None")
            {
                sms_gateway_cmb.Text = Settings.Default.default_sms_gateway;
                sms_gateway_cmb.Enabled = false;
                send_msg_chkbx.Enabled = false;

            }
            messages_type_cmb.Text = Settings.Default.default_sms_language;
            if (Settings.Default.default_sms_language != "English")
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "Urdu (Islamic Republic of Pakistan)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = System.Windows.Forms.RightToLeft.No;
                message_inp.Text = Settings.Default.customer_dues_urd_template;
            }
            else
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "English (United States)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft =System.Windows.Forms.RightToLeft.No;
                message_inp.Text = Settings.Default.customer_dues_eng_template;
            }
        }

        private void search_item_cmb_Click(object sender, EventArgs e)
        {
            search_item_cmb.Properties.View.Columns["Sr.No"].Visible = false;
        }

        private void model_cmb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void supplier_cmb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void shortcuts_right_panel_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            string button = e.Button.Properties.Caption;
            if (button == "Hide Panel")
            {
                shortcuts_right_panel.HideSliding();
                gridView1.Focus();
            }
        }

        private void view_sms_template_btn_Click(object sender, EventArgs e)
        {
            if (panelControl11.Visible == true)
            {
                panelControl11.Visible = false;
                panelControl3.Size = new Size(panelControl3.Width, panelControl3.Height - panelControl11.Height);
            }
            else
            {

                panelControl11.Visible = true;
                panelControl3.Size = new Size(panelControl3.Width, panelControl3.Height + panelControl11.Height);
                characters_count_lbl.Text = message_inp.Text.Length.ToString();
            }
        }

        private void message_inp_TextChanged(object sender, EventArgs e)
        {
            characters_count_lbl.Text = message_inp.Text.Length.ToString();
        }

        private void sms_gateway_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Stock_Transfer_Leave(object sender, EventArgs e)
        {

        }

        private void message_inp_Leave(object sender, EventArgs e)
        {
            foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
            {
                if (lng.Culture.DisplayName == "English (United States)")
                {
                    InputLanguage.CurrentInputLanguage = lng;
                }
            }
            if (messages_type_cmb.Text != "English")
            {
                message_inp.RightToLeft =System.Windows.Forms.RightToLeft.Yes;
            }
            else
            {
                message_inp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            }
        }

        private void message_inp_Enter(object sender, EventArgs e)
        {
            if (messages_type_cmb.Text != "English")
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "Urdu (Islamic Republic of Pakistan)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            }
            else
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "English (United States)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            }
        }

        private void messages_type_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (messages_type_cmb.Text != "English")
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "Urdu (Islamic Republic of Pakistan)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft =System.Windows.Forms.RightToLeft.Yes;
                message_inp.Text = Settings.Default.customer_dues_urd_template;
            }
            else
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "English (United States)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = System.Windows.Forms.RightToLeft.No;
                message_inp.Text = Settings.Default.customer_dues_eng_template;
            }
        }

        private void Stock_Transfer_SizeChanged(object sender, EventArgs e)
        {
            Load_Popup_Settings();
        }

        private void item_remarks_inp_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void item_remarks_inp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D || e.KeyCode == Keys.Enter)
            {
                if (search_item_cmb.Text != "")
                {
                    Set_Item_To_Cart();
                }
            }
            else
            {
                Controls_List(sender, e);
            }
        }

        private void item_remarks_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
