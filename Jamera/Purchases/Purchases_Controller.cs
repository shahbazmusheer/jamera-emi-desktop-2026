using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace Jamera.Purchases
{
    class Purchases_Controller
    {
        SqlConnection conn = new SqlConnection();
        Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
        Items.Items_Controller items_controller = new Items.Items_Controller();
        public Purchases_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }
        public Purchase_Item Get_Current_Purchase_Item(int ITEM_ID)
        {
            conn.Open();
            Purchase_Item purchase_item = new Purchase_Item();
            String query = @"SELECT TOP 1 id,purchase_id,purchase_rate,sale_rate,items_stock_in,items_stock_out,returned_quantity FROM purchase_items WHERE item_id='" + ITEM_ID + "' and items_stock_in > (items_stock_out + returned_quantity)";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                purchase_item.Purchase_Item_Id = Convert.ToInt32(reader["id"]);
                purchase_item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                purchase_item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                purchase_item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                purchase_item.Stock_In = Convert.ToDouble(reader["items_stock_in"]);
                purchase_item.Stock_Out = Convert.ToDouble(reader["items_stock_out"]);
                purchase_item.Returned_Items = Convert.ToDouble(reader["returned_quantity"]);
            }
            reader.Close();
            conn.Close();
            return purchase_item;
        }

        public Purchase_Item Get_Current_Purchase_Item_By_Sale_Rate(int ITEM_ID,Double Sale_Rate)
        {
            conn.Open();
            Purchase_Item purchase_item = new Purchase_Item();
            String query = @"SELECT TOP 1 id,purchase_id,purchase_rate,sale_rate,items_stock_in,items_stock_out,returned_quantity FROM purchase_items WHERE item_id='" + ITEM_ID + "' and sale_rate='"+Sale_Rate+"' and items_stock_in > (items_stock_out + returned_quantity)";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                purchase_item.Purchase_Item_Id = Convert.ToInt32(reader["id"]);
                purchase_item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                purchase_item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                purchase_item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                purchase_item.Stock_In = Convert.ToDouble(reader["items_stock_in"]);
                purchase_item.Stock_Out = Convert.ToDouble(reader["items_stock_out"]);
                purchase_item.Returned_Items = Convert.ToDouble(reader["returned_quantity"]);
            }
            reader.Close();
            conn.Close();
            return purchase_item;
        }

        public bool Delete_New_Purchase(int Purchase_Id)
        {
            bool result = true;
            Purchase purchase = Get_Purchase(Purchase_Id);
            Double total_inventory_balance = 0;
            List<Purchase_Item> purchase_items_list = Get_Purchase_Items_List(Purchase_Id);
            for(int i =0;i < purchase_items_list.Count;i++)
            {
                double sub_total = (purchase_items_list[i].Purchase_Rate * purchase_items_list[i].Stock_In);
                double discounted_value =0;
                double discounted_amount = purchase_items_list[i].Discount_RS;
                if (discounted_value > 0)
                {
                    discounted_value = (sub_total - discounted_amount);
                }
                Items.Item item = items_controller.Get_Item(purchase_items_list[i].Item_Id);
                double inventory_curr_balance = 0;
                double inventory_closing_balance = 0;
                inventory_curr_balance = accounts_controller.Get_Account_Balance(2011);
                total_inventory_balance = (total_inventory_balance + sub_total);
                inventory_closing_balance = (inventory_curr_balance - sub_total);
                accounts_controller.Insert_Account_Transaction(2011, "Inventory", accounts_controller.Get_Account_Type(2011), accounts_controller.Get_Account_Nature(2011), "#Purchase Return","", 0, 0, 0,sub_total, inventory_closing_balance,purchase.Purchase_Date, purchase.Invoice_No,item.Name, (item.Packing * Convert.ToDouble(purchase_items_list[i].Stock_In)));

                if (discounted_amount > 0)
                {

                    double discount_taken_account_current_balance = 0;
                    double discount_taken_account_curr_balance = 0;
                    discount_taken_account_curr_balance = accounts_controller.Get_Account_Balance(2012);
                    discount_taken_account_current_balance = discount_taken_account_curr_balance - discounted_amount;
                    accounts_controller.Insert_Account_Transaction(2012, "Disount Taken", accounts_controller.Get_Account_Type(2012), accounts_controller.Get_Account_Nature(2012), "#Purchase Bill", "", 0, 0, discounted_amount,0, discount_taken_account_current_balance, purchase.Purchase_Date,purchase.Invoice_No);
                }

                Delete_Purchase_Item_Through_Purchase_Item_Id(purchase_items_list[i].Purchase_Item_Id);

            }

            double payable_account_current_balance = 0;
            double payable_account_curr_balance = 0;
            payable_account_curr_balance = accounts_controller.Get_Account_Balance(purchase.Supplier_ID);
            payable_account_current_balance = (payable_account_curr_balance - total_inventory_balance);
            accounts_controller.Insert_Account_Transaction(purchase.Supplier_ID, accounts_controller.Get_Account_Name(purchase.Supplier_ID), accounts_controller.Get_Account_Type(purchase.Supplier_ID), accounts_controller.Get_Account_Nature(purchase.Supplier_ID), "#Purchase Return", "", 0, 0, total_inventory_balance,0, payable_account_current_balance, purchase.Purchase_Date);

            if (purchase.Total_Discount_RS > 0)
            {
                double discount_taken_account_current_balance = 0;
                double discount_taken_account_curr_balance = 0;
                discount_taken_account_curr_balance = accounts_controller.Get_Account_Balance(2012);
                discount_taken_account_current_balance = discount_taken_account_curr_balance - purchase.Total_Discount_RS;
                accounts_controller.Insert_Account_Transaction(2012, "Disount Taken", accounts_controller.Get_Account_Type(2012), accounts_controller.Get_Account_Nature(2012), "#Purchase Return", "", 0, 0, purchase.Total_Discount_RS,0, discount_taken_account_current_balance, purchase.Purchase_Date,purchase.Invoice_No);

                payable_account_current_balance = 0;
                payable_account_curr_balance = 0;
                payable_account_curr_balance = accounts_controller.Get_Account_Balance(purchase.Supplier_ID);
                payable_account_current_balance = (payable_account_curr_balance - purchase.Total_Discount_RS);
                accounts_controller.Insert_Account_Transaction(purchase.Supplier_ID, accounts_controller.Get_Account_Name(purchase.Supplier_ID), accounts_controller.Get_Account_Type(purchase.Supplier_ID), accounts_controller.Get_Account_Nature(purchase.Supplier_ID), "#Purchase Return", "", 0, 0,purchase.Total_Discount_RS, 0, payable_account_current_balance, purchase.Purchase_Date,purchase.Invoice_No);

            }
            if (purchase.Payment_Method == "Cash")
            {
                double cash_account_current_balance = 0;
                double cash_account_curr_balance = 0;
                cash_account_curr_balance = accounts_controller.Get_Account_Balance(2001);
                cash_account_current_balance = (cash_account_curr_balance + (total_inventory_balance - purchase.Total_Discount_RS));
                accounts_controller.Insert_Account_Transaction(2001, "Cash", accounts_controller.Get_Account_Type(2001), accounts_controller.Get_Account_Nature(2001), "Supplier Payment","", 0, 0, 0, (total_inventory_balance - purchase.Total_Discount_RS), cash_account_current_balance, purchase.Purchase_Date);

                payable_account_current_balance = 0;
                payable_account_curr_balance = 0;
                payable_account_curr_balance = accounts_controller.Get_Account_Balance(purchase.Supplier_ID);
                payable_account_current_balance = (payable_account_curr_balance - (total_inventory_balance - purchase.Total_Discount_RS));
                accounts_controller.Insert_Account_Transaction(purchase.Supplier_ID, accounts_controller.Get_Account_Name(purchase.Supplier_ID), accounts_controller.Get_Account_Type(purchase.Supplier_ID), accounts_controller.Get_Account_Nature(purchase.Supplier_ID), "Supplier Payment Voucher", "", 0, 0, (total_inventory_balance - purchase.Total_Discount_RS), 0, payable_account_current_balance, purchase.Purchase_Date);
            }
            if (purchase.Payment_Method == "Bank")
            {
                double cash_account_current_balance = 0;
                double cash_account_curr_balance = 0;
                cash_account_curr_balance = accounts_controller.Get_Account_Balance(2002);
                cash_account_current_balance = (cash_account_curr_balance - (total_inventory_balance - purchase.Total_Discount_RS));
                accounts_controller.Insert_Account_Transaction(2002, "Bank", accounts_controller.Get_Account_Type(2002), accounts_controller.Get_Account_Nature(2002), "Supplier Payment", "", 0, 0, 0, (total_inventory_balance - purchase.Total_Discount_RS), cash_account_current_balance, purchase.Purchase_Date);

                payable_account_current_balance = 0;
                payable_account_curr_balance = 0;
                payable_account_curr_balance = accounts_controller.Get_Account_Balance(purchase.Supplier_ID);
                payable_account_current_balance = (payable_account_curr_balance - (total_inventory_balance - purchase.Total_Discount_RS));
                accounts_controller.Insert_Account_Transaction(purchase.Supplier_ID, accounts_controller.Get_Account_Name(purchase.Supplier_ID), accounts_controller.Get_Account_Type(purchase.Supplier_ID), accounts_controller.Get_Account_Nature(purchase.Supplier_ID), "Supplier Payment", "", 0, 0, (total_inventory_balance - purchase.Supplier_ID), 0, payable_account_current_balance, purchase.Purchase_Date);
            }

            this.conn.Open();
            Purchase_Item purchase_item = new Purchase_Item();
            String query = @"DELETE FROM purchases WHERE id='" + Purchase_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();
            return result;
        }
        public List<Purchase_Item> Get_Purchase_Items_List(int Purchase_Id)
        {
            conn.Open();
            List<Purchase_Item> purchase_items_list = new List<Purchase_Item>();
            String query = @"SELECT id,discount_rs,discount_percent,purchase_id,purchase_rate,sale_rate,items_stock_in,items_stock_out,returned_quantity FROM purchase_items WHERE purchase_id='" + Purchase_Id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Purchase_Item purchase_item = new Purchase_Item();
                purchase_item.Purchase_Item_Id = Convert.ToInt32(reader["id"]);
                purchase_item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                purchase_item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                purchase_item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                purchase_item.Discount_RS = Convert.ToDouble(reader["discount_rs"]);
                purchase_item.Discount_Percent = Convert.ToDouble(reader["discount_percent"]);
                purchase_item.Stock_In = Convert.ToDouble(reader["items_stock_in"]);
                purchase_item.Stock_Out = Convert.ToDouble(reader["items_stock_out"]);
                purchase_item.Returned_Items = Convert.ToDouble(reader["returned_quantity"]);
                purchase_items_list.Add(purchase_item);
            }
            reader.Close();
            conn.Close();
            return purchase_items_list;
        }
        public Purchase_Item Get_Current_Purchase_Item(int ITEM_ID,Double Purchase_Rate,Double Sale_Rate)
        {
            conn.Open();
            Purchase_Item purchase_item = new Purchase_Item();
            String query = @"SELECT TOP 1 id,discount_rs,discount_percent,purchase_id,purchase_rate,sale_rate,items_stock_in,items_stock_out,returned_quantity FROM purchase_items WHERE item_id='" + ITEM_ID + "' and (purchase_rate='"+Purchase_Rate+"' and sale_rate='"+Sale_Rate+ "') and items_stock_in > (items_stock_out + returned_quantity)";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                purchase_item.Purchase_Item_Id = Convert.ToInt32(reader["id"]);
                purchase_item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                purchase_item.Discount_RS = Convert.ToDouble(reader["discount_rs"]);
                purchase_item.Discount_Percent = Convert.ToDouble(reader["discount_percent"]);
                purchase_item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                purchase_item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                purchase_item.Stock_In = Convert.ToDouble(reader["items_stock_in"]);
                purchase_item.Stock_Out = Convert.ToDouble(reader["items_stock_out"]);
                purchase_item.Returned_Items = Convert.ToDouble(reader["returned_quantity"]);
            }
            reader.Close();
            conn.Close();
            return purchase_item;
        }
        public bool Delete_Purchase_Item_Through_Purchase_Item_Id(int Purchase_Item_Id)
        {
            bool result = false;
            this.conn.Open();
            Purchase_Item purchase_item = new Purchase_Item();
            String query = @"DELETE FROM purchase_items WHERE id='"+Purchase_Item_Id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();
            result = true;
            return result;
        }
        public Purchase_Item Get_Purchase_Item_Through_Purchase_Item_Id(int Purchase_Item_Id)
        {
            this.conn.Open();
            Purchase_Item purchase_item = new Purchase_Item();
            String query = @"SELECT TOP 1 id,purchase_id,purchase_rate,sale_rate,items_stock_in,items_stock_out,returned_quantity FROM purchase_items WHERE id='" + Purchase_Item_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                purchase_item.Purchase_Item_Id = Convert.ToInt32(reader["id"]);
                purchase_item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                purchase_item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                purchase_item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                purchase_item.Stock_In = Convert.ToDouble(reader["items_stock_in"]);
                purchase_item.Stock_Out = Convert.ToDouble(reader["items_stock_out"]);
                purchase_item.Returned_Items = Convert.ToDouble(reader["returned_quantity"]);
            }
            reader.Close();
            this.conn.Close();
            return purchase_item;
        }
        public Double Get_Purchase_Stocked_Out(int ITEM_ID, int PURCHASE_ID)
        {
            this.conn.Open();
            Double result = -1;
            String query = @"SELECT items_stock_out FROM purchase_items WHERE purchase_id='" + PURCHASE_ID + "' and item_id='" + ITEM_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            Object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToDouble(obj);
            }
            this.conn.Close();
            return result;
        }

        public Double Get_Purchase_Stocked_Out(int ID)
        {
            this.conn.Open();
            Double result = -1;
            String query = @"SELECT items_stock_out FROM purchase_items WHERE id='" + ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            Object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToDouble(obj);
            }
            this.conn.Close();
            return result;
        }

        public int Store_Purchase_Return(DateTime PURCHASE_DATE,int PURCHASE_ID, String PURCHASE_TYPE, String PAYMENT_METHOD, int SUPPLIER_ID, DataTable CART_ITEMS_TABLE, String REMARKS, Double SUB_TOTAL, Double DISCOUNT_PERCENT, Double DISCOUNT_RS, Double NET_TOTAL, String INVOICE_ID)
        {
            this.conn.Open();
            int purchase_ret_id = -1;
            using (SqlCommand cmd = new SqlCommand("INSERT INTO purchases_return(purchase_id,purchase_type,payment_method,supplier_id,invoice_no,date,status,discount_percent,discount_rs,remarks,total_amount) VALUES(@purchase_id,@purchase_type,@payment_method,@supplier_id,@invoice_no,@date,@status,@discount_percent,@discount_rs,@remarks,@total_amount) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@purchase_type", PURCHASE_TYPE);
                cmd.Parameters.AddWithValue("@purchase_id", PURCHASE_ID);
                if (INVOICE_ID == null)
                {
                    cmd.Parameters.AddWithValue("@invoice_no", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@invoice_no", INVOICE_ID);
                }
                cmd.Parameters.AddWithValue("@payment_method", PAYMENT_METHOD);

                if (DISCOUNT_PERCENT != 0)
                {
                    cmd.Parameters.AddWithValue("@discount_percent", DISCOUNT_PERCENT);
                    cmd.Parameters.AddWithValue("@discount_rs", DISCOUNT_RS);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@discount_percent", 0);
                    cmd.Parameters.AddWithValue("@discount_rs", 0);
                }
                cmd.Parameters.AddWithValue("@date", PURCHASE_DATE);
                cmd.Parameters.AddWithValue("@remarks", REMARKS);
                cmd.Parameters.AddWithValue("@status", "unblocked");
                if (SUPPLIER_ID != -1)
                {
                    cmd.Parameters.AddWithValue("@supplier_id", SUPPLIER_ID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@supplier_id", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@total_amount", NET_TOTAL);
                object res_id = cmd.ExecuteScalar();
                this.conn.Close();
                if (res_id != null && res_id != DBNull.Value)
                {
                    purchase_ret_id = (int)res_id;
                    this.Store_Purchase_return_Items(purchase_ret_id,PURCHASE_ID, PURCHASE_DATE, CART_ITEMS_TABLE, INVOICE_ID, REMARKS, SUPPLIER_ID, DISCOUNT_RS, PAYMENT_METHOD);
                }
            }
            return purchase_ret_id;
        }

        public void Store_Purchase_return_Items(int PURCHASE_RET_ID,int PURCHASE_ID, DateTime PURCHASE_DATE, DataTable PURCHASE_ITEMS_TABLE, String INVOICE_NO, String DESCRIPTION, int SUPPLIER_ID = -1, Double TOTAL_DISCOUNT = 0, String PAYMENT_METHOD = "Cash")
        {
            Items.Items_Controller i_c = new Items.Items_Controller();
            int items_rows_count = PURCHASE_ITEMS_TABLE.Rows.Count;
            double total_inventory_balance = 0;
            Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
            for (int i = 0; i < items_rows_count; i++)
            {
                Items.Item item = i_c.Get_Item(Convert.ToInt32(PURCHASE_ITEMS_TABLE.Rows[i]["Code"].ToString()));
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO purchases_return_items(purchases_return_id,date,item_id,status,unit_id,category_id,manufacturer_id,product_group_id,purchase_rate,sale_rate,discount_percent,discount_rs,sub_total,net_total,returned_quantity) VALUES(@purchases_return_id,@date,@item_id,@status,@unit_id,@category_id,@manufacturer_id,@group_id,@purchase_rate,@sale_rate,@discount_percent,@discount_rs,@sub_total,@net_total,@returned_quantity)", conn))
                {
                    cmd.Parameters.AddWithValue("@purchases_return_id", PURCHASE_RET_ID);
                    cmd.Parameters.AddWithValue("@date", PURCHASE_DATE);
                    cmd.Parameters.AddWithValue("@status", "unblocked");
                    cmd.Parameters.AddWithValue("@unit_id", item.Unit_Id);
                    cmd.Parameters.AddWithValue("@item_id", item.Id);
                    cmd.Parameters.AddWithValue("@category_id", item.Category_Id);
                    cmd.Parameters.AddWithValue("@manufacturer_id", item.Manufacturer_Id);
                    cmd.Parameters.AddWithValue("@group_id", item.Group_id);
                    cmd.Parameters.AddWithValue("@sub_total", (Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Packing Qty"])) * Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Purchase Rate"]));
                    cmd.Parameters.AddWithValue("@purchase_rate", PURCHASE_ITEMS_TABLE.Rows[i]["Purchase Rate"].ToString());
                    cmd.Parameters.AddWithValue("@sale_rate", PURCHASE_ITEMS_TABLE.Rows[i]["Sale Rate"].ToString());
                    cmd.Parameters.AddWithValue("@discount_percent", PURCHASE_ITEMS_TABLE.Rows[i]["Disc(%)"].ToString());
                    cmd.Parameters.AddWithValue("@discount_rs", PURCHASE_ITEMS_TABLE.Rows[i]["Disc(R.S)"].ToString());
                    cmd.Parameters.AddWithValue("@net_total", PURCHASE_ITEMS_TABLE.Rows[i]["Total"].ToString());
                    cmd.Parameters.AddWithValue("@returned_quantity", Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Unit Qty"].ToString()));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //accounting code -----------
                    double sub_total = (Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Packing Qty"])) * Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Purchase Rate"]);
                    double discounted_value = 0;
                    double discounted_amount = 0;
                    if (Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Disc(R.S)"]) > 0)
                    {
                        discounted_amount = Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Disc(R.S)"]);
                        discounted_value = (sub_total - discounted_amount);
                    }
                    else
                    {
                        discounted_value = sub_total;
                    }

                    double inventory_curr_balance = 0;
                    double inventory_closing_balance = 0;
                    inventory_curr_balance = accounts_controller.Get_Account_Balance(2011);
                    total_inventory_balance = (total_inventory_balance + sub_total);
                    inventory_closing_balance = (inventory_curr_balance - sub_total);
                    accounts_controller.Insert_Account_Transaction(2011, "Inventory", accounts_controller.Get_Account_Type(2011), accounts_controller.Get_Account_Nature(2011), "#Purchase Bill", DESCRIPTION, 0, 0,0, sub_total, inventory_closing_balance, PURCHASE_DATE, INVOICE_NO, item.Name, (item.Packing * Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Packing Qty"].ToString())));

                    if (discounted_amount > 0)

                    {

                        double discount_taken_account_current_balance = 0;
                        double discount_taken_account_curr_balance = 0;
                        discount_taken_account_curr_balance = accounts_controller.Get_Account_Balance(2012);
                        discount_taken_account_current_balance = discount_taken_account_curr_balance - discounted_amount;
                        accounts_controller.Insert_Account_Transaction(2012, "Disount Taken", accounts_controller.Get_Account_Type(2012), accounts_controller.Get_Account_Nature(2012), "#Purchase Bill", DESCRIPTION, 0, 0, discounted_amount,0, discount_taken_account_current_balance, PURCHASE_DATE, INVOICE_NO);
                    }
                    this.Update_Purchase_Returned_Stock(item.Id,PURCHASE_ID, Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Unit Qty"].ToString()));
                }
            }
            double payable_account_current_balance = 0;
            double payable_account_curr_balance = 0;
            payable_account_curr_balance = accounts_controller.Get_Account_Balance(SUPPLIER_ID);
            payable_account_current_balance = (payable_account_curr_balance - total_inventory_balance);
            accounts_controller.Insert_Account_Transaction(SUPPLIER_ID, accounts_controller.Get_Account_Name(SUPPLIER_ID), accounts_controller.Get_Account_Type(SUPPLIER_ID), accounts_controller.Get_Account_Nature(SUPPLIER_ID), "#Purchase Bill", DESCRIPTION, 0, 0, total_inventory_balance, 0, payable_account_current_balance, PURCHASE_DATE);

            if (PAYMENT_METHOD == "Cash")
            {
                double cash_account_current_balance = 0;
                double cash_account_curr_balance = 0;
                cash_account_curr_balance = accounts_controller.Get_Account_Balance(2001);
                cash_account_current_balance = (cash_account_curr_balance + (total_inventory_balance - TOTAL_DISCOUNT));
                accounts_controller.Insert_Account_Transaction(2001, "Cash", accounts_controller.Get_Account_Type(2001), accounts_controller.Get_Account_Nature(2001), "Supplier Payment", DESCRIPTION, 0, 0, (total_inventory_balance - TOTAL_DISCOUNT),0, cash_account_current_balance, PURCHASE_DATE);

                payable_account_current_balance = 0;
                payable_account_curr_balance = 0;
                payable_account_curr_balance = accounts_controller.Get_Account_Balance(SUPPLIER_ID);
                payable_account_current_balance = (payable_account_curr_balance + (total_inventory_balance - TOTAL_DISCOUNT));
                accounts_controller.Insert_Account_Transaction(SUPPLIER_ID, accounts_controller.Get_Account_Name(SUPPLIER_ID), accounts_controller.Get_Account_Type(SUPPLIER_ID), accounts_controller.Get_Account_Nature(SUPPLIER_ID), "Supplier Payment Voucher", DESCRIPTION, 0, 0,0, (total_inventory_balance - TOTAL_DISCOUNT), payable_account_current_balance, PURCHASE_DATE);
            }
            if (PAYMENT_METHOD == "Bank")
            {
                double cash_account_current_balance = 0;
                double cash_account_curr_balance = 0;
                cash_account_curr_balance = accounts_controller.Get_Account_Balance(2002);
                cash_account_current_balance = (cash_account_curr_balance + (total_inventory_balance - TOTAL_DISCOUNT));
                accounts_controller.Insert_Account_Transaction(2002, "Bank", accounts_controller.Get_Account_Type(2002), accounts_controller.Get_Account_Nature(2002), "Supplier Payment", DESCRIPTION, 0, 0, (total_inventory_balance - TOTAL_DISCOUNT),0, cash_account_current_balance, PURCHASE_DATE);

                payable_account_current_balance = 0;
                payable_account_curr_balance = 0;
                payable_account_curr_balance = accounts_controller.Get_Account_Balance(SUPPLIER_ID);
                payable_account_current_balance = (payable_account_curr_balance + (total_inventory_balance - TOTAL_DISCOUNT));
                accounts_controller.Insert_Account_Transaction(SUPPLIER_ID, accounts_controller.Get_Account_Name(SUPPLIER_ID), accounts_controller.Get_Account_Type(SUPPLIER_ID), accounts_controller.Get_Account_Nature(SUPPLIER_ID), "Supplier Payment Voucher", DESCRIPTION, 0, 0, 0, (total_inventory_balance - TOTAL_DISCOUNT), payable_account_current_balance, PURCHASE_DATE);
            }
        }

        public void Update_Purchase_Returned_Stock(int ITEM_ID,int PURCHASE_ID,Double RETURN_QTY)
        {
            Double already_returned_qty = Get_Returned_Stock(PURCHASE_ID,ITEM_ID);
            Double returning_qty = already_returned_qty + RETURN_QTY;
            this.conn.Open();
            String query = @"UPDATE purchase_items set returned_quantity='"+returning_qty+"' WHERE purchase_id='"+PURCHASE_ID+"' and item_id='"+ITEM_ID+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();
        }
        public void Update_Purchase_Damaged_Stock(int ITEM_ID, Double Purchase_Rate,Double Sale_Rate,Double Packing, Double ITEM_QTY)
        {
            Purchase_Item purchase_item = Get_Current_Purchase_Item(ITEM_ID,Purchase_Rate,Sale_Rate);
            Double available_stock = (purchase_item.Stock_In - (purchase_item.Stock_Out + purchase_item.Returned_Items));

            Double updated_qty = 0;
            if (available_stock >= ITEM_QTY)
            {
                updated_qty = (purchase_item.Stock_Out + ITEM_QTY);
            }
            else
            {
                updated_qty = (purchase_item.Stock_Out + available_stock);
            }
            this.conn.Open();
            String query = @"UPDATE purchase_items set items_stock_out='" + updated_qty + "' WHERE id='" + purchase_item.Purchase_Item_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            this.conn.Close();

            Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
            Accounts.Account inventory_account = accounts_controller.Get_Account(2011);
            Accounts.Account damage_inventory_account = accounts_controller.Get_Account(2017);
            //account Transactions
            accounts_controller.Insert_Account_Transaction(inventory_account.Account_Id,inventory_account.Account_Name,inventory_account.Account_Type,inventory_account.Account_Nature,"Damaged Stock","Damaged entry",0,0,0,((Purchase_Rate / Packing) * ITEM_QTY),(inventory_account.Balance - ((Purchase_Rate / Packing) * ITEM_QTY)),DateTime.Now);
            accounts_controller.Insert_Account_Transaction(damage_inventory_account.Account_Id, damage_inventory_account.Account_Name, damage_inventory_account.Account_Type, damage_inventory_account.Account_Nature, "Damaged Stock", "Damaged entry", 0, 0, ((Purchase_Rate / Packing) * ITEM_QTY),0, (damage_inventory_account.Balance + ((Purchase_Rate / Packing) * ITEM_QTY)), DateTime.Now);
            ITEM_QTY = ITEM_QTY - available_stock;
            if(ITEM_QTY > 0)
            {
                Update_Purchase_Damaged_Stock(ITEM_ID, Purchase_Rate, Sale_Rate, Packing, ITEM_QTY);
            }
        }
        public Double Get_Returned_Stock(int PURCHASE_ID, int ITEM_ID)
        {
            this.conn.Open();
            Double result = -1;
            String query = @"SELECT p_i.returned_quantity as 'returned_stock' from purchase_items as p_i where purchase_id='" + PURCHASE_ID + "' and item_id='" + ITEM_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            Object obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                result = Convert.ToDouble(obj);
            }
            this.conn.Close();
            return result;
        }
        public Double Get_Returnable_Stock(int PURCHASE_ID,int ITEM_ID)
        {
            this.conn.Open();
            Double result = -1;
            String query = @"SELECT (p_i.items_stock_in - (p_i.items_stock_out + p_i.returned_quantity)) as 'returnable_stock' from purchase_items as p_i where purchase_id='"+PURCHASE_ID+"' and item_id='"+ITEM_ID+"'";
            SqlCommand cmd = new SqlCommand(query,conn);
            Object obj = cmd.ExecuteScalar();
            if(obj != null)
            {
                result = Convert.ToDouble(obj);
            }
            this.conn.Close();
            return result;
        }

        public Double Get_Available_Stock(int ID,Double Purchase_Rate,Double Sale_Rate)
        {
            this.conn.Open();
            Double result = -1;
            String query = @"SELECT SUM(p_i.items_stock_in - (p_i.items_stock_out + p_i.returned_quantity)) as 'returnable_stock' from purchase_items as p_i where p_i.item_id='" + ID + "' and p_i.purchase_rate='"+Purchase_Rate+"' and p_i.sale_rate='"+Sale_Rate+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            Object obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                result = Convert.ToDouble(obj);
            }
            this.conn.Close();
            return result;
        }

        public Double Get_Available_Stock(int ID)
        {
            this.conn.Open();
            Double result = -1;
            String query = @"SELECT (p_i.items_stock_in - (p_i.items_stock_out + p_i.returned_quantity)) as 'returnable_stock' from purchase_items as p_i where id='" + ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            Object obj = cmd.ExecuteScalar();
            if (obj != null)
            {
                result = Convert.ToDouble(obj);
            }
            this.conn.Close();
            return result;
        }

        public int Store(DateTime PURCHASE_DATE, String PURCHASE_TYPE, String PAYMENT_METHOD, int SUPPLIER_ID, DataTable CART_ITEMS_TABLE, String REMARKS, Double SUB_TOTAL, Double DISCOUNT_PERCENT, Double DISCOUNT_RS, Double NET_TOTAL, String INVOICE_ID, Double Paid_Amount, bool is_opening_stock = false, Double Balance = 0, int Fuel_Expenses_Account_Id = -1,Double Fuel_Expenses_Amount=0) {
            int purchase_id = -1;
            double remaining_bal = NET_TOTAL - Paid_Amount;
            //Fuel expense account id will change
            Extra_Resources.Extra_Veriables extra_veriables = new Extra_Resources.Extra_Veriables();
            int Fuel_Expense_Ac_Id = extra_veriables.Fuel_Expnses_Ac_Id;
            //here will be change...

            this.conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO purchases(purchase_type,payment_method,supplier_id,invoice_no,date,status,discount_percent,discount_rs,remarks,total_amount,paid, remaining,fuel_expenses_amount,fuel_expenses_account_id) VALUES(@purchase_type,@payment_method,@supplier_id,@invoice_no,@date,@status,@discount_percent,@discount_rs,@remarks,@total_amount,@paid, @remaining,@fuel_expenses_amount,@fuel_expenses_account_id) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@purchase_type", PURCHASE_TYPE);
                if (INVOICE_ID ==null)
                {
                    cmd.Parameters.AddWithValue("@invoice_no", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@invoice_no", INVOICE_ID);
                }
                if(Fuel_Expenses_Amount > 0)
                {
                    if(Fuel_Expenses_Account_Id == -1)
                    {
                        double payable_account_current_balance = 0;
                        double payable_account_curr_balance = 0;
                        payable_account_curr_balance = accounts_controller.Get_Account_Balance(SUPPLIER_ID);
                        payable_account_current_balance = (payable_account_curr_balance + Fuel_Expenses_Amount);
                        accounts_controller.Insert_Account_Transaction(SUPPLIER_ID, accounts_controller.Get_Account_Name(SUPPLIER_ID), accounts_controller.Get_Account_Type(SUPPLIER_ID), accounts_controller.Get_Account_Nature(SUPPLIER_ID), "#Purchase Bill", "Fuel Expenses", 0, 0, 0, Fuel_Expenses_Amount, payable_account_current_balance, PURCHASE_DATE);
                        //supplier paid

                        double fuel_expense_account_current_balance = 0;
                        double fuel_expense_account_curr_balance = 0;
                        fuel_expense_account_curr_balance = accounts_controller.Get_Account_Balance(Fuel_Expense_Ac_Id);
                        fuel_expense_account_current_balance = (fuel_expense_account_curr_balance + Fuel_Expenses_Amount);
                        accounts_controller.Insert_Account_Transaction(Fuel_Expense_Ac_Id, accounts_controller.Get_Account_Name(Fuel_Expense_Ac_Id), accounts_controller.Get_Account_Type(Fuel_Expense_Ac_Id), accounts_controller.Get_Account_Nature(Fuel_Expense_Ac_Id), "#Purchase Bill", "Fuel Expenses", 0, 0,Fuel_Expenses_Amount,0, fuel_expense_account_current_balance, PURCHASE_DATE);
                        //fuel_expenses_amount,fuel_expenses_account_id
                        cmd.Parameters.AddWithValue("@fuel_expenses_amount", Fuel_Expenses_Amount);
                        cmd.Parameters.AddWithValue("@fuel_expenses_account_id", SUPPLIER_ID);
                    }
                    else
                    {
                        //paid by other account !
                        cmd.Parameters.AddWithValue("@fuel_expenses_amount", Fuel_Expenses_Amount);
                        cmd.Parameters.AddWithValue("@fuel_expenses_account_id", Fuel_Expenses_Account_Id);
                        //Accounting transactions remains

                        double payable_account_current_balance = 0;
                        double payable_account_curr_balance = 0;
                        Accounts.Account fuel_account = accounts_controller.Get_Account(Fuel_Expenses_Account_Id);
                        //XtraMessageBox.Show("A/C:"+Fuel_Expenses_Account_Id + " && Type:"+account.Account_Type);
                        if(fuel_account.Account_Type == "CR")
                        {
                            payable_account_curr_balance = fuel_account.Balance;
                            payable_account_current_balance = (payable_account_curr_balance + Fuel_Expenses_Amount);
                            accounts_controller.Insert_Account_Transaction(Fuel_Expenses_Account_Id,fuel_account.Account_Name,fuel_account.Account_Type, fuel_account.Account_Nature, "#Purchase Bill", "Fuel Expenses", 0, 0, 0, Fuel_Expenses_Amount, payable_account_current_balance, PURCHASE_DATE);
                        }
                        else
                        {
                            payable_account_curr_balance = fuel_account.Balance;
                            payable_account_current_balance = (payable_account_curr_balance - Fuel_Expenses_Amount);
                            accounts_controller.Insert_Account_Transaction(Fuel_Expenses_Account_Id, fuel_account.Account_Name, fuel_account.Account_Type, fuel_account.Account_Nature, "#Purchase Bill", "Fuel Expenses", 0, 0, 0, Fuel_Expenses_Amount, payable_account_current_balance, PURCHASE_DATE);
                        }

                        double fuel_expense_account_current_balance = 0;
                        double fuel_expense_account_curr_balance = 0;
                        fuel_expense_account_curr_balance = accounts_controller.Get_Account_Balance(Fuel_Expense_Ac_Id);
                        fuel_expense_account_current_balance = (fuel_expense_account_curr_balance + Fuel_Expenses_Amount);
                        accounts_controller.Insert_Account_Transaction(Fuel_Expense_Ac_Id, accounts_controller.Get_Account_Name(Fuel_Expense_Ac_Id), accounts_controller.Get_Account_Type(Fuel_Expense_Ac_Id), accounts_controller.Get_Account_Nature(Fuel_Expense_Ac_Id), "#Purchase Bill", "Fuel Expenses", 0, 0, Fuel_Expenses_Amount, 0, fuel_expense_account_current_balance, PURCHASE_DATE);
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fuel_expenses_amount",0);
                    cmd.Parameters.AddWithValue("@fuel_expenses_account_id", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@payment_method", PAYMENT_METHOD);

                if(is_opening_stock != true)
                {
                    if (DISCOUNT_PERCENT != 0)
                    {
                        cmd.Parameters.AddWithValue("@discount_percent", DISCOUNT_PERCENT);
                        cmd.Parameters.AddWithValue("@discount_rs", DISCOUNT_RS);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@discount_percent", 0);
                        cmd.Parameters.AddWithValue("@discount_rs", 0);
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@discount_percent", 0);
                    cmd.Parameters.AddWithValue("@discount_rs", 0);
                }
                cmd.Parameters.AddWithValue("@date", PURCHASE_DATE);
                cmd.Parameters.AddWithValue("@remarks", REMARKS);
                cmd.Parameters.AddWithValue("@status", "unblocked");
                if (SUPPLIER_ID != -1)
                {
                    cmd.Parameters.AddWithValue("@supplier_id", SUPPLIER_ID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@supplier_id", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@total_amount", NET_TOTAL); 
                cmd.Parameters.AddWithValue("@paid", Paid_Amount);
                cmd.Parameters.AddWithValue("@remaining", remaining_bal);
                object res_id = cmd.ExecuteScalar();
                this.conn.Close();
                if (res_id != null && res_id != DBNull.Value)
                {
                    purchase_id = (int)res_id;
                    this.Store_Purchase_Items(purchase_id,PURCHASE_DATE,CART_ITEMS_TABLE,INVOICE_ID,REMARKS,Paid_Amount,SUPPLIER_ID,DISCOUNT_RS,PAYMENT_METHOD,is_opening_stock);
                }                    
            }
            return purchase_id;
        }

        public void Store_Purchase_Items(int PURCHASE_ID, DateTime PURCHASE_DATE, DataTable PURCHASE_ITEMS_TABLE,String INVOICE_NO,String DESCRIPTION,Double Paid_Amount,int SUPPLIER_ID=-1,Double TOTAL_DISCOUNT=0,String PAYMENT_METHOD="Cash",bool is_opening_stock=false)        {
            Items.Items_Controller i_c = new Items.Items_Controller();
            int items_rows_count = PURCHASE_ITEMS_TABLE.Rows.Count;
            double total_inventory_balance = 0;
            Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
            for (int i = 0; i < items_rows_count; i++)
            {
                Items.Item item = i_c.Get_Item(Convert.ToInt32(PURCHASE_ITEMS_TABLE.Rows[i]["Code"].ToString()));
                this.conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO purchase_items(purchase_id,date,item_id,status,unit_id,category_id,manufacturer_id,product_group_id,purchase_rate,sale_rate,discount_percent,discount_rs,quantity,items_stock_in,items_stock_out,sub_total,net_total,returned_quantity) VALUES(@purchase_id,@date,@item_id,@status,@unit_id,@category_id,@manufacturer_id,@group_id,@purchase_rate,@sale_rate,@discount_percent,@discount_rs,@quantity,@items_stock_in,@items_stock_out,@sub_total,@net_total,@returned_quantity)", conn))
                {
                    
                    cmd.Parameters.AddWithValue("@purchase_id", PURCHASE_ID);
                    cmd.Parameters.AddWithValue("@date", PURCHASE_DATE);
                    cmd.Parameters.AddWithValue("@status", "unblocked");
                    cmd.Parameters.AddWithValue("@unit_id", item.Unit_Id);
                    cmd.Parameters.AddWithValue("@item_id", item.Id);
                    cmd.Parameters.AddWithValue("@category_id", item.Category_Id);
                    cmd.Parameters.AddWithValue("@manufacturer_id", item.Manufacturer_Id);
                    cmd.Parameters.AddWithValue("@group_id", item.Group_id);
                    cmd.Parameters.AddWithValue("@items_stock_out", 0);
                    cmd.Parameters.AddWithValue("@items_stock_in", (item.Packing * Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Packing Qty"].ToString())));
                    cmd.Parameters.AddWithValue("@sub_total", (Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Packing Qty"])) * Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Purchase Rate"]));
                    cmd.Parameters.AddWithValue("@purchase_rate", PURCHASE_ITEMS_TABLE.Rows[i]["Purchase Rate"].ToString());
                    cmd.Parameters.AddWithValue("@sale_rate", PURCHASE_ITEMS_TABLE.Rows[i]["Sale Rate"].ToString());
                    if(is_opening_stock == false)
                    {
                        cmd.Parameters.AddWithValue("@discount_percent", PURCHASE_ITEMS_TABLE.Rows[i]["Disc(%)"].ToString());
                        cmd.Parameters.AddWithValue("@discount_rs", PURCHASE_ITEMS_TABLE.Rows[i]["Disc(R.S)"].ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@discount_percent", 0);
                        cmd.Parameters.AddWithValue("@discount_rs", 0);
                    }
                    cmd.Parameters.AddWithValue("@quantity", PURCHASE_ITEMS_TABLE.Rows[i]["Packing Qty"].ToString());
                    cmd.Parameters.AddWithValue("@net_total", PURCHASE_ITEMS_TABLE.Rows[i]["Total"].ToString());
                    cmd.Parameters.AddWithValue("@returned_quantity", 0);
                    cmd.ExecuteNonQuery();
                    this.conn.Close();
                    //accounting code -----------
                    double sub_total = (Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Packing Qty"])) * Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Purchase Rate"]);
                    double discounted_value = 0;
                    double discounted_amount = 0;
                    if(is_opening_stock == false)
                    {
                        if (Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Disc(R.S)"]) > 0)
                        {
                            discounted_amount = Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Disc(R.S)"]);
                            discounted_value = (sub_total - discounted_amount);
                        }
                        else
                        {
                            discounted_value = sub_total;
                        }
                    }

                    double inventory_curr_balance = 0;
                    double inventory_closing_balance = 0;
                    inventory_curr_balance = accounts_controller.Get_Account_Balance(2011);
                    total_inventory_balance = (total_inventory_balance + sub_total);
                    inventory_closing_balance = (sub_total + inventory_curr_balance);
                    accounts_controller.Insert_Account_Transaction(2011, "Inventory",accounts_controller.Get_Account_Type(2011),accounts_controller.Get_Account_Nature(2011),"#Purchase Bill",DESCRIPTION, 0, 0, sub_total,0,inventory_closing_balance,PURCHASE_DATE,INVOICE_NO,item.Name, (item.Packing * Convert.ToDouble(PURCHASE_ITEMS_TABLE.Rows[i]["Packing Qty"].ToString())));

                    if (discounted_amount > 0)

                    {
                       
                        double discount_taken_account_current_balance = 0;
                        double discount_taken_account_curr_balance = 0;
                        discount_taken_account_curr_balance = accounts_controller.Get_Account_Balance(2012);
                        discount_taken_account_current_balance = discount_taken_account_curr_balance + discounted_amount;
                        accounts_controller.Insert_Account_Transaction(2012, "Disount Taken",accounts_controller.Get_Account_Type(2012),accounts_controller.Get_Account_Nature(2012),"#Purchase Bill", DESCRIPTION, 0,0, 0,discounted_amount,discount_taken_account_current_balance,PURCHASE_DATE,INVOICE_NO);
                    }
                }
            }

            double payable_account_current_balance = 0;
            double payable_account_curr_balance = 0;
            payable_account_curr_balance =accounts_controller.Get_Account_Balance(SUPPLIER_ID);
            payable_account_current_balance = (payable_account_curr_balance + total_inventory_balance);
            accounts_controller.Insert_Account_Transaction(SUPPLIER_ID, accounts_controller.Get_Account_Name(SUPPLIER_ID),accounts_controller.Get_Account_Type(SUPPLIER_ID),accounts_controller.Get_Account_Nature(SUPPLIER_ID), "#Purchase Bill",DESCRIPTION, 0, 0, 0, total_inventory_balance, payable_account_current_balance,PURCHASE_DATE);
            if (TOTAL_DISCOUNT > 0)
            {
                double discount_taken_account_current_balance = 0;
                double discount_taken_account_curr_balance = 0;
                discount_taken_account_curr_balance = accounts_controller.Get_Account_Balance(2012);
                discount_taken_account_current_balance = discount_taken_account_curr_balance + TOTAL_DISCOUNT;
                accounts_controller.Insert_Account_Transaction(2012, "Disount Taken",accounts_controller.Get_Account_Type(2012),accounts_controller.Get_Account_Nature(2012), "#Purchase Bill",DESCRIPTION, 0,0, 0, TOTAL_DISCOUNT, discount_taken_account_current_balance, PURCHASE_DATE,INVOICE_NO);

                payable_account_current_balance = 0;
                payable_account_curr_balance = 0;
                payable_account_curr_balance =accounts_controller.Get_Account_Balance(SUPPLIER_ID);
                payable_account_current_balance = (payable_account_curr_balance - TOTAL_DISCOUNT);
                accounts_controller.Insert_Account_Transaction(SUPPLIER_ID,accounts_controller.Get_Account_Name(SUPPLIER_ID),accounts_controller.Get_Account_Type(SUPPLIER_ID),accounts_controller.Get_Account_Nature(SUPPLIER_ID), "#Purchase Bill",DESCRIPTION,0, 0, TOTAL_DISCOUNT,0, payable_account_current_balance,PURCHASE_DATE,INVOICE_NO);
                
            }
            if ( PAYMENT_METHOD != "Bank" && Paid_Amount > 0)
            {
                payable_account_current_balance = 0;
                payable_account_curr_balance = 0;
                payable_account_curr_balance =accounts_controller.Get_Account_Balance(SUPPLIER_ID);
                if (payable_account_curr_balance > Paid_Amount)
                {
                    payable_account_current_balance = (payable_account_curr_balance - Paid_Amount);
                }
                else
                {
                    payable_account_current_balance = ( Paid_Amount - payable_account_curr_balance);
                }

                Vouchers.Vouchers_Controller vouchers_controller = new Vouchers.Vouchers_Controller();
                vouchers_controller.Store_Payment_Voucher(PURCHASE_DATE,SUPPLIER_ID, accounts_controller.Get_Account_Name(SUPPLIER_ID), Paid_Amount,"Paid to supplier", "Cash");
            }
            if (PAYMENT_METHOD == "Bank")
            {
                payable_account_current_balance = 0;
                payable_account_curr_balance = 0;
                payable_account_curr_balance = accounts_controller.Get_Account_Balance(SUPPLIER_ID);
                payable_account_current_balance = (payable_account_curr_balance - Paid_Amount);
                accounts_controller.Insert_Account_Transaction(SUPPLIER_ID, accounts_controller.Get_Account_Name(SUPPLIER_ID), accounts_controller.Get_Account_Type(SUPPLIER_ID), accounts_controller.Get_Account_Nature(SUPPLIER_ID), "Supplier Payment", DESCRIPTION, 0, 0, Paid_Amount, 0, payable_account_current_balance, PURCHASE_DATE);

                //
                Vouchers.Vouchers_Controller vouchers_controller = new Vouchers.Vouchers_Controller();
                vouchers_controller.Store_Payment_Voucher(PURCHASE_DATE, SUPPLIER_ID, accounts_controller.Get_Account_Name(SUPPLIER_ID), Paid_Amount, "Paid to supplier", "Bank");
            }
        }

        public Items.Item Get_Item(int item_id)
        {
            Items.Items_Controller items_controller = new Items.Items_Controller();
            Items.Item item = items_controller.Get_Item(item_id);
            String query = "SELECT TOP 1 purchase_rate,sale_rate FROM purchase_items WHERE item_id='" + item_id + "' and date = (SELECT MAX(date) FROM purchase_items WHERE item_id='" + item_id + "');";
            this.conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                    item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                }
                reader.Close();
            }
            this.conn.Close();
            return item;
        }
        public Items.Item Get_Item(int purchase_id,int item_id)
        {
            Items.Items_Controller items_controller = new Items.Items_Controller();
            Items.Item item = items_controller.Get_Item(item_id);
            String query = "SELECT TOP 1 purchase_rate,sale_rate FROM purchase_items WHERE item_id='" + item_id + "' and purchase_items.purchase_id='"+purchase_id+"' and date = (SELECT MAX(date) FROM purchase_items WHERE item_id='" + item_id + "');";
            this.conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                    item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                }
                reader.Close();
            }
            this.conn.Close();
            return item;
        }
        //Optional 
        public bool Item_In_Purchases_Exists(int Item_Id)
        {
            bool result = false;
            String query = "SELECT item_id FROM purchase_items WHERE item_id='" + Item_Id +"';";
            this.conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            Object obj = cmd.ExecuteScalar();
            if(obj != DBNull.Value && obj != null)
            {
                if(obj.ToString() == Item_Id.ToString())
                {
                    result = true;
                }
            }
            this.conn.Close();
            return result;
        }
        public Purchase Get_Purchase_Return(int Purchase_return_Id)
        {
            Purchase purchase = new Purchase();
            String query = "SELECT purchases_return.id as 'Code',purchases_return.date as 'Date',suppliers.id as 'Supplier Code',suppliers.name as 'Supplier',purchases_return.purchase_type as 'Purchase Type',purchases_return.payment_method as 'Mode',purchases_return.invoice_no as 'Invoice No',purchases_return.discount_percent as 'Disc(%)',purchases_return.discount_rs as 'Disc(R.S)',purchases_return.total_amount as 'Net Total'  FROM purchases_return left join accounts as suppliers on purchases_return.supplier_id=suppliers.id WHERE purchases_return.id='"+Purchase_return_Id+"';";
            this.conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    if (reader["Invoice No"].ToString() != "")
                    {
                        purchase.Invoice_No = Convert.ToString(reader["Invoice No"]);
                    }
                    purchase.Purchase_ID = Convert.ToInt32(reader["Code"]);
                    purchase.Supplier_ID = Convert.ToInt32(reader["Supplier Code"]);
                    purchase.Supplier_Name = reader["Supplier"].ToString();
                    purchase.Purchase_Date = Convert.ToDateTime(reader["Date"].ToString());
                    purchase.Purchase_Type = reader["Purchase Type"].ToString();
                    purchase.Payment_Method = reader["Mode"].ToString();
                    purchase.Total_Discount_Percent = Convert.ToDouble(reader["Disc(%)"]);
                    purchase.Total_Discount_RS = Convert.ToDouble(reader["Disc(R.S)"]);
                    purchase.Net_Total = Convert.ToDouble(reader["Net Total"]);
                }
                reader.Close();
            }
            this.conn.Close();

            return purchase;
        }
        public Purchase Get_Purchase(int Purchase_Id)
        {
            Purchase purchase = new Purchase();
            String query = "SELECT purchases.id as 'Code',purchases.remarks,purchases.fuel_expenses_amount,purchases.fuel_expenses_account_id,purchases.date as 'Date',suppliers.id as 'Supplier Code',suppliers.name as 'Supplier',purchases.purchase_type as 'Purchase Type',purchases.payment_method as 'Mode',purchases.invoice_no as 'Invoice No',purchases.discount_percent as 'Disc(%)',purchases.discount_rs as 'Disc(R.S)',purchases.total_amount as 'Net Total', purchases.paid as 'Paid', purchases.remaining as 'Balance'  FROM purchases left join accounts as suppliers on purchases.supplier_id=suppliers.id WHERE purchases.id='" + Purchase_Id+ "';";
            this.conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    if(reader["Invoice No"].ToString() != "")
                    {
                        purchase.Invoice_No = Convert.ToString(reader["Invoice No"]);
                    }
                    if (reader["remarks"].ToString() != "")
                    {
                        purchase.Remarks = Convert.ToString(reader["remarks"]);
                    }
                    if (reader["fuel_expenses_account_id"] != DBNull.Value)
                    {
                        purchase.Expense_Paid_Ac_ID = Convert.ToInt32(reader["fuel_expenses_account_id"]);
                    }
                    purchase.Purchase_ID = Convert.ToInt32(reader["Code"]);
                    purchase.Supplier_ID = Convert.ToInt32(reader["Supplier Code"]);
                    purchase.Supplier_Name = reader["Supplier"].ToString();
                    purchase.Purchase_Date  = Convert.ToDateTime(reader["Date"].ToString());
                    purchase.Purchase_Type = reader["Purchase Type"].ToString();
                    purchase.Payment_Method = reader["Mode"].ToString();
                    purchase.Fuel_Expense_Amount = Convert.ToDouble(reader["fuel_expenses_amount"]);
                    purchase.Total_Discount_Percent = Convert.ToDouble(reader["Disc(%)"]);
                    purchase.Total_Discount_RS = Convert.ToDouble(reader["Disc(R.S)"]);
                    purchase.Net_Total = Convert.ToDouble(reader["Net Total"]);
                    purchase.Paid = Convert.ToDouble(reader["Paid"]);
                    purchase.Balance = Convert.ToDouble(reader["Balance"]);
                }
                reader.Close();
            }
            this.conn.Close();

            return purchase;
        }
    }
}
