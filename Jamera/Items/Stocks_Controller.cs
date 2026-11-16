using DevExpress.DashboardCommon.Native;
using DevExpress.XtraEditors;
using Jamera.Purchases;
using Jamera.Reports.Stocks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Items
{
    class Stocks_Controller
    {
        SqlConnection conn = new SqlConnection();
        Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
        public Stocks_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }

        public Double Get_Items_Stock_At_Store(int ITEM_ID, int STORE_ID)
        {
            conn.Open();
            Double result = 0;
            // Updated calculation: add sales_return, subtract others
            String query = @"SELECT SUM((sti.stock_in + sti.sales_return) - (sti.sold_out + sti.returned + sti.transfered)) 
                     FROM stock_transaction_items as sti 
                     WHERE sti.item_id='" + ITEM_ID + "' and sti.store_id='" + STORE_ID + "';";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            conn.Close();
            if (obj != DBNull.Value && obj != null) result = Convert.ToDouble(obj);
            return result;
        }

        public DataTable Get_Available_Stock_At_Store(int STORE_ID)
        {
            DataTable available_Stock_Table = new DataTable();
            conn.Open();

            // Updated calculation: add sales_return, subtract others
            String query = @"SELECT rank() over(order by sti.item_id,items.name,sti.sale_rate) as 'Sr.No',sti.item_id as 'Code',items.name as 'Item',models.name as 'Model',sti.sale_rate as 'Sale Rate',SUM((sti.stock_in + sti.sales_return) - (sti.sold_out + sti.returned + sti.transfered)) as 'Stock',i_u.name as 'U.O.M' FROM stock_transaction_items as sti left join items on sti.item_id=items.id left join item_units as i_u on items.unit_id=i_u.id left join item_models as models on items.model_id=models.id WHERE ((sti.stock_in - (sti.sold_out + sti.returned + sti.transfered) ) > 0) and sti.store_id='" + STORE_ID + "' GROUP BY sti.item_id,items.name,sti.sale_rate,i_u.name,models.name";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.Fill(available_Stock_Table);
            conn.Close();
            return available_Stock_Table;
        }

        public Stock_Transfer_Instance Get_Stock_Transfer_Instance(int Stock_Transfer_Instance_Id)
        {
            Stock_Transfer_Instance stock_transfer_instance = new Stock_Transfer_Instance();
            conn.Open();
            String query = @"SELECT st.id,st.from_store,from_stores.name as from_store_name,from_stores.area_code as from_area_code,st.to_store,to_stores.name as to_store_name,to_stores.area_code as to_area_code,st.date as date,st.name as name,st.remarks FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id WHERE st.id='"+Stock_Transfer_Instance_Id+"';";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stock_transfer_instance.Stock_Transfer_Id=Convert.ToInt32(reader["id"]);
                if(reader["from_store_name"] != DBNull.Value)
                {
                    stock_transfer_instance.From_Store = reader["from_store_name"].ToString();
                }
                if (reader["from_area_code"] != DBNull.Value)
                {
                    stock_transfer_instance.From_Area_Code = reader["from_area_code"].ToString();
                }
                if (reader["from_store"] != DBNull.Value)
                {
                    stock_transfer_instance.From_Store_Id =Convert.ToInt32(reader["from_store"]);
                }

                if (reader["to_store_name"] != DBNull.Value)
                {
                    stock_transfer_instance.To_Store = reader["to_store_name"].ToString();
                }
                if (reader["to_area_code"] != DBNull.Value)
                {
                    stock_transfer_instance.To_Area_Code = reader["to_area_code"].ToString();
                }
                if (reader["to_store"] != DBNull.Value)
                {
                    stock_transfer_instance.To_Store_Id = Convert.ToInt32(reader["to_store"]);
                }
                if (reader["remarks"] != DBNull.Value)
                {
                    stock_transfer_instance.Remarks = Convert.ToString(reader["remarks"]);
                }
                if (reader["date"] != DBNull.Value)
                {
                    stock_transfer_instance.Remarks = Convert.ToString(reader["date"]);
                }
            }
            reader.Close();
            conn.Close();
            //stock_transfer_instance.Stock_Transfer_Items_Table = Get_Stock_Transaction_Items(Stock_Transfer_Instance_Id);
            return stock_transfer_instance;
        }
        public int Store_Stock_Transaction(DateTime DATE, int FROM_STORE, int TO_STORE, String NAME, String REMARKS, DataTable ITEMS_TABLE, int Paid_Ac_Id = -1, Double Fuel_Expenses_Amount = 0, String GatePassNo = "")
        {
            conn.Open();
            int result = -1;
            using (SqlCommand cmd = new SqlCommand("INSERT INTO stock_transactions(date,from_store,to_store,name,remarks,paid_by_ac_id,fuel_expenses_amount, gate_pass_no) values(@date,@from_store,@to_store,@name,@remarks,@paid_by_ac_id,@fuel_expenses_amount, @gate_pass_no) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@remarks", REMARKS);
                cmd.Parameters.AddWithValue("@gate_pass_no", GatePassNo);
                if (FROM_STORE != -1)
                {
                    cmd.Parameters.AddWithValue("@from_store", FROM_STORE);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@from_store", DBNull.Value);
                }
                if (TO_STORE != -1) {
                    cmd.Parameters.AddWithValue("@to_store", TO_STORE);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@to_store", DBNull.Value);
                }
                if (Paid_Ac_Id == -1)
                {
                    cmd.Parameters.AddWithValue("@paid_by_ac_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@paid_by_ac_id", Paid_Ac_Id);
                }
                cmd.Parameters.AddWithValue("fuel_expenses_amount",Fuel_Expenses_Amount);
                if(Fuel_Expenses_Amount > 0)
                {
                    double payable_account_current_balance = 0;
                    double payable_account_curr_balance = 0;
                    if (accounts_controller.Get_Account_Type(Paid_Ac_Id) == "CR")
                    {
                        payable_account_curr_balance = accounts_controller.Get_Account_Balance(Paid_Ac_Id);
                        payable_account_current_balance = (payable_account_curr_balance + Fuel_Expenses_Amount);
                        accounts_controller.Insert_Account_Transaction(Paid_Ac_Id, accounts_controller.Get_Account_Name(Paid_Ac_Id), accounts_controller.Get_Account_Type(Paid_Ac_Id), accounts_controller.Get_Account_Nature(Paid_Ac_Id), "#Stock Transfer", "Fuel Expenses", 0, 0, 0, Fuel_Expenses_Amount, payable_account_current_balance, DateTime.Now);
                    }
                    else
                    {
                        payable_account_curr_balance = accounts_controller.Get_Account_Balance(Paid_Ac_Id);
                        payable_account_current_balance = (payable_account_curr_balance - Fuel_Expenses_Amount);
                        accounts_controller.Insert_Account_Transaction(Paid_Ac_Id, accounts_controller.Get_Account_Name(Paid_Ac_Id), accounts_controller.Get_Account_Type(Paid_Ac_Id), accounts_controller.Get_Account_Nature(Paid_Ac_Id), "#Stock Transfer", "Fuel Expenses", 0, 0, 0, Fuel_Expenses_Amount, payable_account_current_balance, DateTime.Now);
                    }
                    Extra_Resources.Extra_Veriables extra_veriables = new Extra_Resources.Extra_Veriables();
                    int Fuel_Expense_Ac_Id = extra_veriables.Fuel_Expnses_Ac_Id;
                    // here will be change
                    double fuel_expense_account_current_balance = 0;
                    double fuel_expense_account_curr_balance = 0;
                    fuel_expense_account_curr_balance = accounts_controller.Get_Account_Balance(Fuel_Expense_Ac_Id);
                    fuel_expense_account_current_balance = (fuel_expense_account_curr_balance + Fuel_Expenses_Amount);
                    accounts_controller.Insert_Account_Transaction(Fuel_Expense_Ac_Id, accounts_controller.Get_Account_Name(Fuel_Expense_Ac_Id), accounts_controller.Get_Account_Type(Fuel_Expense_Ac_Id), accounts_controller.Get_Account_Nature(Fuel_Expense_Ac_Id), "#Purchase Bill", "Fuel Expenses", 0, 0, Fuel_Expenses_Amount, 0, fuel_expense_account_current_balance, DateTime.Now);
                }
                cmd.Parameters.AddWithValue("@date", DATE.ToString("dd-MM-yyyy"));
                object obj = cmd.ExecuteScalar();
                conn.Close();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);

                    if(FROM_STORE == -1 && TO_STORE != -1)
                    {
                        //If FROM store is null 
                        for (int i = 0; i < ITEMS_TABLE.Rows.Count; i++)
                        {
                            int item_id = Convert.ToInt32(ITEMS_TABLE.Rows[i][1]);
                            Double item_qty = Convert.ToDouble(ITEMS_TABLE.Rows[i]["Quantity"]);
                            String item_remarks = ITEMS_TABLE.Rows[i]["Remarks"].ToString();
                            Update_Purchase_Stock(DATE,item_id, Convert.ToDouble(ITEMS_TABLE.Rows[i]["Sale Rate"]), TO_STORE,result,item_qty, item_remarks);
                        }
                    }
                    else if (FROM_STORE != -1 && TO_STORE == -1)
                    {
                        //If To store is null 
                        for (int i = 0; i < ITEMS_TABLE.Rows.Count; i++)
                        {
                            int item_id = Convert.ToInt32(ITEMS_TABLE.Rows[i][1]);
                            Double item_qty = Convert.ToDouble(ITEMS_TABLE.Rows[i]["Quantity"]);
                            Double saleRate = Convert.ToDouble(ITEMS_TABLE.Rows[i]["Sale Rate"]);
                            String item_remarks = ITEMS_TABLE.Rows[i]["Remarks"].ToString();
                            Update_Store_Returned_Stock(DATE, result, item_id, FROM_STORE, saleRate, item_qty, item_remarks );
                        }
                    }
                    else
                    {
                        // if store to store
                        for (int i = 0; i < ITEMS_TABLE.Rows.Count; i++)
                        {
                            int item_id = Convert.ToInt32(ITEMS_TABLE.Rows[i][1]);
                            Double item_qty = Convert.ToDouble(ITEMS_TABLE.Rows[i]["Quantity"]);
                            String item_remarks = ITEMS_TABLE.Rows[i]["Remarks"].ToString();
                            Update_Store_Stock(DATE, item_id, Convert.ToDouble(ITEMS_TABLE.Rows[i]["Sale Rate"]), FROM_STORE, TO_STORE, result, item_qty, item_remarks);
                        }
                    }
                }
            }
            return result;
        }

        public void Update_Store_Returned_Stock(DateTime DATE, int trasnsaction_id, int item_id, int store_id, Double Sale_Rate, Double items_qty, String item_remarks = "")
        {
            Purchases.Purchases_Controller p_controller = new Purchases.Purchases_Controller();
            Purchases.Purchase_Item p_item = p_controller.Get_Current_Purchase_Item_By_Sale_Rate(item_id, Sale_Rate);

            Stores.Stores_Controller s_controller = new Stores.Stores_Controller();
            Stores.Store_Item s_item = s_controller.Get_Current_Stock_Item_By_Sale_Rate(item_id, store_id, Sale_Rate);

            if (s_item == null) return;

            Double available_in_store_batch = (s_item.Stock_in - (s_item.Sold_out + s_item.Transfered_Items + s_item.Returned_Items));
            Double qtyToReturn = (available_in_store_batch >= items_qty) ? items_qty : available_in_store_batch;

            // 1. Update Store Record
            conn.Open();
            String query = @"UPDATE stock_transaction_items SET returned = returned + @qty WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@qty", qtyToReturn);
            cmd.Parameters.AddWithValue("@id", s_item.Store_Item_Id);
            cmd.ExecuteNonQuery();
            conn.Close();

            // 2. Log History (Store -1 means returned to pool)
            // Set stock_in to 0, and returned to qtyToReturn
            Store_Stock_Transaction_Item(DATE, trasnsaction_id, -1, p_item.Purchase_Id, p_item.Purchase_Item_Id, item_id, p_item.Purchase_Rate, p_item.Sale_Rate, 0, 0, qtyToReturn, 0, item_remarks);

            // 3. Update Purchase Pool Availability
            Update_Purchase_Returned_Stock(s_item.Purchase_Item_Id, qtyToReturn);

            // 4. Recurse
            double remaining = items_qty - qtyToReturn;
            if (remaining > 0)
            {
                this.Update_Store_Returned_Stock(DATE, trasnsaction_id, item_id, store_id, Sale_Rate, remaining, item_remarks);
            }
        }

        public void Update_Store_Returned_Stock_Old_Last(DateTime DATE, int trasnsaction_id, int item_id, int store_id, Double Sale_Rate, Double items_qty, String item_remarks = "", bool is_Recursive = false)
        {
            Purchases.Purchases_Controller purchases_controller = new Purchases.Purchases_Controller();
            Purchases.Purchase_Item purchase_item = new Purchases.Purchase_Item();
            purchase_item = purchases_controller.Get_Current_Purchase_Item_By_Sale_Rate(item_id, Sale_Rate);
            Stores.Stores_Controller stores_controller = new Stores.Stores_Controller();
            Stores.Store_Item store_item = stores_controller.Get_Current_Stock_Item_By_Sale_Rate(item_id, store_id, Sale_Rate);
            Double available_qty = (store_item.Stock_in - (store_item.Sold_out + store_item.Transfered_Items + store_item.Returned_Items));
            Double updated_qty = 0;
            Double curr_stock_qty = 0;
            Double Org_Items_Qty = items_qty;
            if (available_qty >= items_qty)
            {
                updated_qty = (store_item.Returned_Items + items_qty);
                curr_stock_qty = items_qty;
            }
            else
            {
                updated_qty = (store_item.Returned_Items + available_qty);
                curr_stock_qty = available_qty;
            }

            conn.Open();
            String query = @"UPDATE stock_transaction_items SET returned='" + updated_qty + "' WHERE id='" + store_item.Store_Item_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            
                Update_Purchase_Returned_Stock(store_item.Purchase_Item_Id, curr_stock_qty);
            //Store Transaction Item History
            if (!is_Recursive)
            {
                Store_Stock_Transaction_Item(DATE, trasnsaction_id, -1, purchase_item.Purchase_Id, purchase_item.Purchase_Item_Id, item_id, purchase_item.Purchase_Rate, purchase_item.Sale_Rate, items_qty, 0, 0, 0, item_remarks);
            }

            items_qty = items_qty - available_qty;

            if (items_qty > 0)
            {
                this.Update_Store_Returned_Stock(DATE, trasnsaction_id, item_id, store_id, Sale_Rate, items_qty, item_remarks);
            }
        }

        public void Update_Purchase_Stock(DateTime DATE, int item_id, Double Sale_Rate, int store_id, int trasnsaction_id, Double items_qty, String item_remarks)
        {
            Purchases.Purchases_Controller purchases_controller = new Purchases.Purchases_Controller();
            Purchases.Purchase_Item purchase_item = purchases_controller.Get_Current_Purchase_Item_By_Sale_Rate(item_id, Sale_Rate);

            if (purchase_item == null) return;

            Double available_in_purchase_batch = (purchase_item.Stock_In - (purchase_item.Stock_Out + purchase_item.Returned_Items));
            Double qtyToTake = (available_in_purchase_batch >= items_qty) ? items_qty : available_in_purchase_batch;
            Double updatedOutQty = purchase_item.Stock_Out + qtyToTake;

            // 1. Update Purchase Record
            this.conn.Open();
            String query = @"UPDATE purchase_items SET items_stock_out=@out WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@out", updatedOutQty);
            cmd.Parameters.AddWithValue("@id", purchase_item.Purchase_Item_Id);
            cmd.ExecuteNonQuery();
            this.conn.Close();

            // 2. Log Store Entry (Only the portion taken)
            Store_Stock_Transaction_Item(DATE, trasnsaction_id, store_id, purchase_item.Purchase_Id, purchase_item.Purchase_Item_Id, item_id, purchase_item.Purchase_Rate, purchase_item.Sale_Rate, qtyToTake, 0, 0, 0, item_remarks);

            // 3. Recurse
            double remainingNeeded = items_qty - qtyToTake;
            if (remainingNeeded > 0)
            {
                this.Update_Purchase_Stock(DATE, item_id, Sale_Rate, store_id, trasnsaction_id, remainingNeeded, item_remarks);
            }
        }

        public void Update_Purchase_Stock_Old_Last(DateTime DATE,int item_id,Double Sale_Rate,int store_id,int trasnsaction_id, Double items_qty, String item_remarks)
        {
            Purchases.Purchases_Controller purchases_controller = new Purchases.Purchases_Controller();
            Purchases.Purchase_Item purchase_item = new Purchases.Purchase_Item();
            purchase_item = purchases_controller.Get_Current_Purchase_Item_By_Sale_Rate(item_id,Sale_Rate);
            Double available_stock = (purchase_item.Stock_In - (purchase_item.Stock_Out + purchase_item.Returned_Items));
            Double updated_qty = 0;
            if( available_stock >= items_qty)
            {
                updated_qty = (purchase_item.Stock_Out +  items_qty);
            }
            else
            {
                updated_qty = (purchase_item.Stock_Out + available_stock);
            }
            //Updating Purchases Stock Which required
            this.conn.Open();
            String query = @"UPDATE purchase_items SET items_stock_out='" + updated_qty + "' WHERE id='" + purchase_item.Purchase_Item_Id+ "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();
            //Store Transaction Item History
            if (available_stock >= items_qty)
            {
                Store_Stock_Transaction_Item(DATE, trasnsaction_id, store_id, purchase_item.Purchase_Id, purchase_item.Purchase_Item_Id, item_id, purchase_item.Purchase_Rate, purchase_item.Sale_Rate, items_qty, 0, 0, 0, item_remarks);
            }
            else
            {
                Store_Stock_Transaction_Item(DATE, trasnsaction_id, store_id, purchase_item.Purchase_Id, purchase_item.Purchase_Item_Id, item_id, purchase_item.Purchase_Rate, purchase_item.Sale_Rate, available_stock, 0, 0, 0, item_remarks);
            }
            items_qty = items_qty - available_stock;
            //if required qty is greater then available in record then check next
            if (items_qty > 0)
            {
                this.Update_Purchase_Stock(DATE,item_id,Sale_Rate,store_id,trasnsaction_id,items_qty, item_remarks);
            }
        }

        public void Update_Purchase_Returned_Stock(int purchase_item_id, Double items_qty)
        {
            Purchases.Purchases_Controller purchases_controller = new Purchases.Purchases_Controller();
            Purchases.Purchase_Item purchase_item = new Purchases.Purchase_Item();
            purchase_item = purchases_controller.Get_Purchase_Item_Through_Purchase_Item_Id(purchase_item_id);
            Double updated_qty = (purchase_item.Stock_Out - items_qty);
            //Updating Purchases Stock Which required
            this.conn.Open();
            String query = @"UPDATE purchase_items SET items_stock_out='" + updated_qty + "' WHERE id='" + purchase_item.Purchase_Item_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();
            //Store Transaction Item History
            
        }

        public Stock_Transaction Get_Stock_Transaction(int Stock_Transaction_Id)
        {
            Stock_Transaction stock_transaction = new Stock_Transaction();
            conn.Open();
            String query= @"select st.date as 'Date',st.id as 'Code',st.name as 'Name',st.remarks as 'Remarks', st.gate_pass_no as 'Gatepass.No',from_stores.id as 'From.Store.Id',from_stores.name as 'From.Store',from_stores.area_code as 'From.Area.Code',to_stores.id as 'To.Store.Id',to_stores.name as 'To.Store',to_stores.area_code as 'To.Area.Code' FROM stock_transactions as st left join stores as from_stores on  st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id WHERE st.id='" + Stock_Transaction_Id+"';";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                stock_transaction.Date = reader["Date"].ToString();
                stock_transaction.Stock_Transaction_Id = Convert.ToInt32(reader["Code"]);
                if(reader["Name"] != DBNull.Value)
                {
                    stock_transaction.Name = reader["Name"].ToString();
                }
                if (reader["Remarks"] != DBNull.Value)
                {
                    stock_transaction.Remarks = reader["Remarks"].ToString();
                }
                if (reader["Gatepass.No"] != DBNull.Value)
                {
                    stock_transaction.GatePassNo = reader["Gatepass.No"].ToString();
                }
                if (reader["From.Store.Id"] != DBNull.Value)
                {
                    stock_transaction.From_Store_Id=Convert.ToInt32(reader["From.Store.Id"]);
                }
                if (reader["From.Store"] != DBNull.Value)
                {
                    stock_transaction.From_Store_Name = Convert.ToString(reader["From.Store"]);
                }
                if (reader["From.Area.Code"] != DBNull.Value)
                {
                    stock_transaction.From_Area_Code = Convert.ToString(reader["From.Area.Code"]);
                }

                if(reader["To.Store.Id"] != DBNull.Value)
                {
                    stock_transaction.To_Store_Id = Convert.ToInt32(reader["To.Store.Id"]);
                }

                if(reader["To.Store"] != DBNull.Value)
                {
                    stock_transaction.To_Store_Name = Convert.ToString(reader["To.Store"]);
                }
                if(reader["To.Area.Code"] != DBNull.Value)
                {
                    stock_transaction.To_Area_Code = Convert.ToString(reader["To.Area.Code"]);
                }
            }
            reader.Close();
            conn.Close();
            stock_transaction.Stock_Transaction_Items_Table = Get_Stock_Transaction_Items(Stock_Transaction_Id);
            return stock_transaction;
        }
        public DataTable Get_Stock_Transaction_Items(int Stock_Transaction_Id)
        {
            DataTable Stock_Transaction_Items_Table = new DataTable();
            conn.Open();
            String query = @"SELECT items.id as 'Item Code',items.name as 'Item Name',models.name as 'Model',sti.sale_rate as 'Sale Rate',SUM(sti.stock_in) as 'Quantity', SUM(sti.returned) as 'Returned', sti.remarks as 'Remarks' FROM stock_transaction_items as sti left join items on sti.item_id=items.id left join item_models as models on items.model_id=models.id WHERE sti.stock_transaction_id='" + Stock_Transaction_Id + "' group by items.id,items.name,sti.sale_rate, sti.remarks,models.name;";
            SqlDataAdapter adp = new SqlDataAdapter(query,conn);
            adp.Fill(Stock_Transaction_Items_Table);
            conn.Close();
            return Stock_Transaction_Items_Table;
        }
        public void Update_Store_Stock(DateTime DATE, int item_id, Double Sale_Rate, int from_store, int store_id, int trasnsaction_id, Double items_qty, String item_remarks)
        {
            Stores.Stores_Controller stores_controller = new Stores.Stores_Controller();
            Stores.Store_Item store_item = stores_controller.Get_Current_Stock_Item_By_Sale_Rate(item_id, from_store, Sale_Rate);

            if (store_item == null) return; // Safety check

            Double available_in_batch = ((store_item.Stock_in + store_item.Sales_Return) - (store_item.Sold_out + store_item.Transfered_Items + store_item.Returned_Items));

            // Determine how much to take from THIS specific batch
            Double qtyToTake = (available_in_batch >= items_qty) ? items_qty : available_in_batch;
            Double newTransferedTotal = store_item.Transfered_Items + qtyToTake;

            // 1. Update the 'From' Store Batch
            conn.Open();
            String query = @"UPDATE stock_transaction_items SET transfered=@trans WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@trans", newTransferedTotal);
            cmd.Parameters.AddWithValue("@id", store_item.Store_Item_Id);
            cmd.ExecuteNonQuery();
            conn.Close();

            // 2. Log the 'To' Store Entry (Only the amount taken from this batch)
            // This creates the 'Stock In' for the receiving store tied to the correct purchase price
            Store_Stock_Transaction_Item(DATE, trasnsaction_id, store_id, store_item.Purchase_Id, store_item.Purchase_Item_Id, item_id, store_item.Purchase_Rate, store_item.Sale_Rate, qtyToTake, 0, 0, 0, item_remarks);

            // 3. Recurse if there is still quantity remaining
            double remainingNeeded = items_qty - qtyToTake;
            if (remainingNeeded > 0)
            {
                this.Update_Store_Stock(DATE, item_id, Sale_Rate, from_store, store_id, trasnsaction_id, remainingNeeded, item_remarks);
            }
        }
        public void Update_Store_Stock_Old_Last(DateTime DATE, int item_id,Double Sale_Rate,int from_store, int store_id, int trasnsaction_id, Double items_qty, String item_remarks, bool is_recursive = false)
        {
            Stores.Stores_Controller stores_controller = new Stores.Stores_Controller();
            Stores.Store_Item store_item = stores_controller.Get_Current_Stock_Item_By_Sale_Rate(item_id,from_store,Sale_Rate);
            Double available_qty = (store_item.Stock_in - (store_item.Sold_out + store_item.Transfered_Items + store_item.Returned_Items));
            Double updated_qty = 0;
            if(available_qty > items_qty)
            {
                updated_qty = (store_item.Transfered_Items + items_qty);
            }
            else
            {
                updated_qty = (store_item.Transfered_Items + available_qty);
            }
            conn.Open();
            String query = @"UPDATE stock_transaction_items SET transfered='" + updated_qty + "' WHERE id='" + store_item.Store_Item_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (!is_recursive)
            {
                if (available_qty > items_qty)
                {
                    Store_Stock_Transaction_Item(DATE, trasnsaction_id, store_id, store_item.Purchase_Id, store_item.Purchase_Item_Id, item_id, store_item.Purchase_Rate, store_item.Sale_Rate, items_qty, 0, 0, 0, item_remarks);
                }
                else
                {
                    Store_Stock_Transaction_Item(DATE, trasnsaction_id, store_id, store_item.Purchase_Id, store_item.Purchase_Item_Id, item_id, store_item.Purchase_Rate, store_item.Sale_Rate, items_qty, 0, 0, 0, item_remarks);
                }
            }
            items_qty = items_qty - available_qty;
            if (items_qty > 0)
            {
                this.Update_Store_Stock(DATE, item_id,Sale_Rate,from_store, store_id, trasnsaction_id, items_qty, item_remarks);
            }
            
        }
        public void Update_Store_Returned_Aggrement_Stock(int STOCK_TRANSACTION_ITEM_ID)
        {
            Stores.Stores_Controller stores_controller = new Stores.Stores_Controller();
            Stores.Store_Item store_item = stores_controller.Get_Stock_Item(STOCK_TRANSACTION_ITEM_ID);
            Double updated_qty = (store_item.Sold_out - 1);
            conn.Open();
            String query = @"UPDATE stock_transaction_items SET sold_out='" + updated_qty + "' WHERE id='" + STOCK_TRANSACTION_ITEM_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Update_Store_Returned_Stock_Old(DateTime DATE,int stock_return_id, int item_id,int store_id,Double Sale_Rate, Double items_qty)
        {
            Stores.Stores_Controller stores_controller = new Stores.Stores_Controller();
            Stores.Store_Item store_item = stores_controller.Get_Current_Stock_Item_By_Sale_Rate(item_id, store_id,Sale_Rate);
            Double available_qty = (store_item.Stock_in - (store_item.Sold_out + store_item.Transfered_Items + store_item.Returned_Items));
            Double updated_qty = 0;
            Double curr_stock_qty = 0;
            if (available_qty >= items_qty)
            {
                updated_qty = (store_item.Returned_Items + items_qty);
                curr_stock_qty = items_qty;
            }
            else
            {
                updated_qty = (store_item.Returned_Items + available_qty);
                curr_stock_qty = available_qty;
            }
            
            conn.Open();
            String query = @"UPDATE stock_transaction_items SET returned='" + updated_qty + "' WHERE id='" + store_item.Store_Item_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Store_Stock_Returned_Item(DATE,stock_return_id,store_item.Stock_Transaction_Id,store_id, store_item.Purchase_Id, store_item.Purchase_Item_Id, item_id, store_item.Purchase_Rate, store_item.Sale_Rate,curr_stock_qty);
            Update_Purchase_Returned_Stock(store_item.Purchase_Item_Id,curr_stock_qty);
            items_qty = items_qty - available_qty;
            if (items_qty > 0)
            {
                this.Update_Store_Returned_Stock_Old(DATE,stock_return_id,item_id,store_id,Sale_Rate,items_qty);
            }
        }

        public void Store_Stock_Transaction_Item(DateTime DATE,int STOCK_TRANSACTION_ID,int STORE_ID, int PURCHASE_ID,int PURCHASE_ITEM_ID,int ITEM_ID,Double PURCHASE_RATE,Double SALE_RATE,Double STOCK_IN,Double SOLD_OUT,Double RETURNED,Double TRANSFERED, String REMARKS)
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO stock_transaction_items(date,stock_transaction_id,purchase_id,store_id,item_id,purchase_rate,sale_rate,stock_in,sold_out,returned,transfered,purchase_item_id, remarks) values(@date,@stock_transaction_id,@purchase_id,@store_id,@item_id,@purchase_rate,@sale_rate,@stock_in,@sold_out,@returned,@transfered,@purchase_item_id, @remarks) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@date", DATE);
                cmd.Parameters.AddWithValue("@stock_transaction_id", STOCK_TRANSACTION_ID);
                if(STORE_ID != -1)
                {
                    cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@store_id", DBNull.Value);
                }
                    cmd.Parameters.AddWithValue("@purchase_id", PURCHASE_ID);
                cmd.Parameters.AddWithValue("@item_id", ITEM_ID);
                cmd.Parameters.AddWithValue("@purchase_rate", PURCHASE_RATE);
                cmd.Parameters.AddWithValue("@sale_rate",SALE_RATE);
                cmd.Parameters.AddWithValue("@stock_in", STOCK_IN);
                cmd.Parameters.AddWithValue("@sold_out", SOLD_OUT);
                cmd.Parameters.AddWithValue("@returned", RETURNED);
                cmd.Parameters.AddWithValue("@transfered", TRANSFERED);
                cmd.Parameters.AddWithValue("@purchase_item_id",PURCHASE_ITEM_ID);
                cmd.Parameters.AddWithValue("@remarks",REMARKS);
                object obj = cmd.ExecuteScalar();
            }
            conn.Close();
        }
        public void Store_Stock_Returned_Item(DateTime DATE,int STOCK_RETURN_ID, int STOCK_TRANSACTION_ID, int STORE_ID, int PURCHASE_ID, int PURCHASE_ITEM_ID, int ITEM_ID, Double PURCHASE_RATE, Double SALE_RATE, Double QUANTIY)
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO stock_return_items(date,stock_return_id,stock_transaction_id,purchase_id,store_id,item_id,purchase_rate,sale_rate,quantity,purchase_item_id) values(@date,@stock_return_id,@stock_transaction_id,@purchase_id,@store_id,@item_id,@purchase_rate,@sale_rate,@quantity,@purchase_item_id) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@date", DATE);
                cmd.Parameters.AddWithValue("@stock_return_id",STOCK_RETURN_ID);
                cmd.Parameters.AddWithValue("@stock_transaction_id", STOCK_TRANSACTION_ID);
                cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                cmd.Parameters.AddWithValue("@purchase_id", PURCHASE_ID);
                cmd.Parameters.AddWithValue("@item_id", ITEM_ID);
                cmd.Parameters.AddWithValue("@purchase_rate", PURCHASE_RATE);
                cmd.Parameters.AddWithValue("@sale_rate", SALE_RATE);
                cmd.Parameters.AddWithValue("@quantity", QUANTIY);
                cmd.Parameters.AddWithValue("@purchase_item_id", PURCHASE_ITEM_ID);
                object obj = cmd.ExecuteScalar();
            }
            conn.Close();
        }
        public int Store_Stock_Return(DateTime DATE,int STORE_ID,String NAME,String DESCRIPTION,DataTable ITEMS_TABLE, int Paid_Ac_Id = -1, Double Fuel_Expenses_Amount = 0, String GatePassNo = "")
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO stock_returns(date,store_id,name,description,paid_by_ac_id,fuel_expenses_amount, gate_pass_no) values(@date,@store_id,@name,@description,@paid_by_ac_id,@fuel_expenses_amount, @gate_pass_no) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@gate_pass_no", GatePassNo);
                cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                cmd.Parameters.AddWithValue("@description",DESCRIPTION);
                cmd.Parameters.AddWithValue("@date", DATE.ToString("dd-MM-yyyy"));
                if (Paid_Ac_Id == -1)
                {
                    cmd.Parameters.AddWithValue("@paid_by_ac_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@paid_by_ac_id", Paid_Ac_Id);
                }
                cmd.Parameters.AddWithValue("fuel_expenses_amount", Fuel_Expenses_Amount);
                if (Fuel_Expenses_Amount > 0)
                {
                    double payable_account_current_balance = 0;
                    double payable_account_curr_balance = 0;
                    if (accounts_controller.Get_Account_Type(Paid_Ac_Id) == "CR")
                    {
                        payable_account_curr_balance = accounts_controller.Get_Account_Balance(Paid_Ac_Id);
                        payable_account_current_balance = (payable_account_curr_balance + Fuel_Expenses_Amount);
                        accounts_controller.Insert_Account_Transaction(Paid_Ac_Id, accounts_controller.Get_Account_Name(Paid_Ac_Id), accounts_controller.Get_Account_Type(Paid_Ac_Id), accounts_controller.Get_Account_Nature(Paid_Ac_Id), "#Stock Return", "Fuel Expenses", 0, 0, 0, Fuel_Expenses_Amount, payable_account_current_balance, DateTime.Now);
                    }
                    else
                    {
                        payable_account_curr_balance = accounts_controller.Get_Account_Balance(Paid_Ac_Id);
                        payable_account_current_balance = (payable_account_curr_balance - Fuel_Expenses_Amount);
                        accounts_controller.Insert_Account_Transaction(Paid_Ac_Id, accounts_controller.Get_Account_Name(Paid_Ac_Id), accounts_controller.Get_Account_Type(Paid_Ac_Id), accounts_controller.Get_Account_Nature(Paid_Ac_Id), "#Stock Return", "Fuel Expenses", 0, 0, 0, Fuel_Expenses_Amount, payable_account_current_balance, DateTime.Now);
                    }

                    Extra_Resources.Extra_Veriables extra_veriables = new Extra_Resources.Extra_Veriables();
                    int Fuel_Expense_Ac_Id = extra_veriables.Fuel_Expnses_Ac_Id;
                    // here will be change
                    double fuel_expense_account_current_balance = 0;
                    double fuel_expense_account_curr_balance = 0;
                    fuel_expense_account_curr_balance = accounts_controller.Get_Account_Balance(Fuel_Expense_Ac_Id);
                    fuel_expense_account_current_balance = (fuel_expense_account_curr_balance + Fuel_Expenses_Amount);
                    accounts_controller.Insert_Account_Transaction(Fuel_Expense_Ac_Id, accounts_controller.Get_Account_Name(Fuel_Expense_Ac_Id), accounts_controller.Get_Account_Type(Fuel_Expense_Ac_Id), accounts_controller.Get_Account_Nature(Fuel_Expense_Ac_Id), "#Stock Return", "Fuel Expenses", 0, 0, Fuel_Expenses_Amount, 0, fuel_expense_account_current_balance, DateTime.Now);
                }
                object obj = cmd.ExecuteScalar();
                conn.Close();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                    //If store returned items
                    for (int i = 0; i < ITEMS_TABLE.Rows.Count; i++)
                    {
                        Update_Store_Returned_Stock(DATE,result, Convert.ToInt32(ITEMS_TABLE.Rows[i][1]), STORE_ID, Convert.ToDouble(ITEMS_TABLE.Rows[i]["Sale Rate"]), Convert.ToDouble(ITEMS_TABLE.Rows[i]["Quantity"]));
                    }
                }
            }

            return result;
        }
    }
}
