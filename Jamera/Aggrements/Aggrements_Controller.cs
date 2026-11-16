using DevExpress.CodeParser;
using DevExpress.Utils.Gesture;
using DevExpress.XtraEditors;
using Jamera.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jamera.Aggrements
{
    class Aggrements_Controller
    {
        SqlConnection conn = new SqlConnection();
        Items.Stores.Stores_Controller stores_controller = new Items.Stores.Stores_Controller();
        int aggrement_id = -1;
        String aggrement_status_temp = null;
        Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
        Collections.VoucherCollection voucherCollection = new Collections.VoucherCollection();
        Thread STS_Thread;
        public Aggrements_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
            //STS_Thread = new Thread(Send_Update_Status_Message);
        }

        public void Delete_Aggrement_Components(int aggrement_id)
        {

            String query = @"DELETE FROM aggrement_dues WHERE aggrement_id='" + aggrement_id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public DataTable Get_Customer_Dues_Table_For_Reciepts_Adjustment(String ref_no_)
        {
            DataTable customer_dues_table = new DataTable();
            conn.Open();
            String query = @"SELECT ROW_NUMBER() OVER (ORDER BY ad.id) AS 'Sr.No',ad.id as 'Code',emi_date as 'Due Date',emi_amount as 'Due Amount',0 as 'Recieved Amount',emi_date as 'Reciept Date','' as 'EMI #','' as 'Balance', ad.remarks as 'Remarks' FROM aggrement_dues as ad right join aggrements as ag on ad.aggrement_id=ag.id WHERE ag.ref_no='" + ref_no_ + "' and ad.paid_amount <= 0 and ad.is_return_fixed < 1  ORDER BY CONVERT(datetime, ad.emi_date,105) ASC, ad.is_return_fixed DESC";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.Fill(customer_dues_table);
            conn.Close();
            return customer_dues_table;
        }
        public bool Delete(int aggrement_id)
        {
            bool result = false;
            Delete_Aggrement_Return_By_Aggrement_Id(aggrement_id);

            Delete_Aggrement_Components(aggrement_id);

            Delete_Agreement_Items(aggrement_id);

            Aggrement aggrement = Get_Aggrement(aggrement_id);

            //Items.Stocks_Controller stocks_controller = new Items.Stocks_Controller();
            //stocks_controller.Update_Store_Returned_Aggrement_Stock(aggrement.Stock_Transaction_Item_Id);

            //Items.Stores.Stores_Controller stores_controller = new Items.Stores.Stores_Controller();
            //Items.Stores.Store_Item store_item = new Items.Stores.Store_Item();
            //stores_controller.Get_Stock_Item(aggrement.Stock_Transaction_Item_Id);

            //Accounts.Account inventory_account = accounts_controller.Get_Account(2011);
            //accounts_controller.Insert_Account_Transaction(inventory_account.Account_Id, inventory_account.Account_Name, inventory_account.Account_Type, inventory_account.Account_Nature, "Sales Return", "Returned Aggrement", 0, 0, store_item.Purchase_Rate, 0, (inventory_account.Balance + store_item.Purchase_Rate), DateTime.Now, null, store_item.Name, 1);

            //Accounts.Account cost_of_goods_sales = accounts_controller.Get_Account(2016);
            //accounts_controller.Insert_Account_Transaction(cost_of_goods_sales.Account_Id, cost_of_goods_sales.Account_Name, cost_of_goods_sales.Account_Type, cost_of_goods_sales.Account_Nature, "Sales Return", "Returned Aggrement", 0, 0, 0, store_item.Purchase_Rate, (cost_of_goods_sales.Balance - store_item.Purchase_Rate), DateTime.Now, null, store_item.Name, 1);
            Accounts.Account sales_account = accounts_controller.Get_Account(2008);
            accounts_controller.Insert_Account_Transaction(sales_account.Account_Id, sales_account.Account_Name, sales_account.Account_Type, sales_account.Account_Nature, "Sales Return", "Returned Aggrement", 0, 0, aggrement.Total_Amount, 0, (sales_account.Balance - aggrement.Total_Amount), DateTime.Now);

            Accounts.Account customer_account = accounts_controller.Get_Account(aggrement.Customer_Id);
            accounts_controller.Insert_Account_Transaction(customer_account.Account_Id, customer_account.Account_Name, customer_account.Account_Type, customer_account.Account_Nature, "Sales Return", "Returned Aggrement", 0, 0, 0, aggrement.Current_Balance, (customer_account.Balance - aggrement.Current_Balance), DateTime.Now);
            Double Total_Cash_Amount = aggrement.Total_Amount - aggrement.Current_Balance;
            Accounts.Account cash_account = accounts_controller.Get_Account(2001);
            accounts_controller.Insert_Account_Transaction(cash_account.Account_Id, cash_account.Account_Name, cash_account.Account_Type, cash_account.Account_Nature, "Sales Return", "Returned Aggrement", 0, 0, 0, Total_Cash_Amount, (cash_account.Balance - Total_Cash_Amount), DateTime.Now);


            String query = @"DELETE FROM aggrements WHERE id='" + aggrement_id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            conn.Close();
            String _query = @"UPDATE vouchers SET ref_no='prev_" + aggrement.Ref_No + "' WHERE ref_no='" + aggrement.Ref_No + "'";
            conn.Open();
            SqlCommand _cmd = new SqlCommand(_query, conn);
            if (_cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            conn.Close();

            return result;
        }

        public bool Delete_Agreement_Items(int Aggrement_Id)
        {
            List<Agreement_Item> agreement_items_list = Get_Aggrement_Items_List(Aggrement_Id);
            for (int i = 0; i < agreement_items_list.Count; i++)
            {


                //here stock will be maintained to store after retruned
                Items.Stores.Store_Item store_item = stores_controller.Get_Stock_Item(agreement_items_list[i].Stock_Transaction_Item_Id);

                Double updated_qty = (store_item.Sold_out - (agreement_items_list[i].Sold_Quantity - agreement_items_list[i].Returned_Quantity));

                conn.Open();
                String update_qty_query = @"UPDATE stock_transaction_items set sold_out='" + updated_qty + "' WHERE id='" + agreement_items_list[i].Stock_Transaction_Item_Id + "'";
                SqlCommand cmd_qty = new SqlCommand(update_qty_query, conn);
                cmd_qty.ExecuteNonQuery();
                conn.Close();

                Double stock_value = (agreement_items_list[i].Purchase_Rate * agreement_items_list[i].Sold_Quantity);
                double inventory_curr_balance = 0;
                double inventory_close_balance = 0;
                inventory_curr_balance = accounts_controller.Get_Account_Balance(2011);
                inventory_close_balance = inventory_curr_balance + stock_value;
                accounts_controller.Insert_Account_Transaction(2011, "Inventory", accounts_controller.Get_Account_Type(2011), accounts_controller.Get_Account_Nature(2011), "delete agreement", "delete Aggrement", 0, 0, stock_value, 0, inventory_close_balance, DateTime.Now, Aggrement_Id.ToString(), store_item.Name, agreement_items_list[i].Sold_Quantity);

                double goods_sold_close_balance = 0;
                double goods_sold_curr_balance = 0;
                goods_sold_curr_balance = accounts_controller.Get_Account_Balance(2016);
                goods_sold_close_balance = (goods_sold_curr_balance - stock_value);
                accounts_controller.Insert_Account_Transaction(2016, "Cost of Goods Sold", accounts_controller.Get_Account_Type(2016), accounts_controller.Get_Account_Nature(2016), "delete agreement", "delete Aggrement", 0, 0, 0, stock_value, goods_sold_close_balance, DateTime.Now, null, store_item.Name, agreement_items_list[i].Sold_Quantity);
            }
            bool result = false;
            String query = @"DELETE FROM sale_items WHERE agreement_id='" + Aggrement_Id + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            conn.Close();
            return result;
        }
        public bool Is_Aggrement_Deletable(String ref_no)
        {
            bool result = true;
            conn.Open();
            String query = @"SELECT ref_no FROM cash_voucher_items WHERE ref_no='" + ref_no + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {


                if (Convert.ToString(reader["ref_no"]) == ref_no)
                {
                    result = false;
                }

            }
            reader.Close();
            conn.Close();
            return result;
        }
        public bool Store_Dues(int AGGREMENT_ID, DataTable EMIS_TABLE, String Ref_No = "")
        {
            bool result = false;
            conn.Open();
            for (int i = 0; i < EMIS_TABLE.Rows.Count; i++)
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO aggrement_dues(aggrement_id, ref_no, emi_no,emi_date,emi_amount,before_due_messages,after_due_messages,cash_voucher_messages,paid_amount) values(@aggrement_id,@ref_no, @emi_no,@emi_date,@emi_amount,@before_due_messages,@after_due_messages,@cash_voucher_messages,@paid_amount) SELECT CAST(scope_identity() AS int)", conn))
                {
                    cmd.Parameters.AddWithValue("@aggrement_id", AGGREMENT_ID);
                    cmd.Parameters.AddWithValue("@ref_no", Ref_No);
                    cmd.Parameters.AddWithValue("@emi_date", Convert.ToDateTime(EMIS_TABLE.Rows[i]["Due Date"]).ToString("dd-MM-yyy"));
                    cmd.Parameters.AddWithValue("@before_due_messages", 0);
                    cmd.Parameters.AddWithValue("@after_due_messages", 0);
                    cmd.Parameters.AddWithValue("@cash_voucher_messages", 0);
                    cmd.Parameters.AddWithValue("@paid_amount", 0);
                    cmd.Parameters.AddWithValue("@emi_no", EMIS_TABLE.Rows[i]["EMI No"]);
                    cmd.Parameters.AddWithValue("@emi_amount", EMIS_TABLE.Rows[i]["Due Amount"]);
                    cmd.ExecuteNonQuery();
                }
            }
            result = true;
            conn.Close();
            return result;
        }
        public bool Store_Dues_New(int AGGREMENT_ID, DataTable EMIS_TABLE, String Ref_No = "")
        {
            bool result = false;
            conn.Open();
            for (int i = 0; i < EMIS_TABLE.Rows.Count; i++)
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO aggrement_dues(aggrement_id,ref_no,emi_date,emi_amount,before_due_messages,after_due_messages,cash_voucher_messages) values(@aggrement_id,@ref_no,@emi_date,@emi_amount,@before_due_messages,@after_due_messages,@cash_voucher_messages)", conn))
                {
                    cmd.Parameters.AddWithValue("@aggrement_id", AGGREMENT_ID);
                    if (Ref_No == "")
                    {
                        cmd.Parameters.AddWithValue("@ref_no", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ref_no", Ref_No);
                    }
                    cmd.Parameters.AddWithValue("@emi_date", Convert.ToDateTime(EMIS_TABLE.Rows[i]["Due Date"]).ToString("dd-MM-yyy"));
                    cmd.Parameters.AddWithValue("@before_due_messages", 0);
                    cmd.Parameters.AddWithValue("@after_due_messages", 0);
                    cmd.Parameters.AddWithValue("@cash_voucher_messages", 0);
                    cmd.Parameters.AddWithValue("@emi_amount", Convert.ToInt32(EMIS_TABLE.Rows[i]["EMI Amount"]));

                    cmd.ExecuteNonQuery();
                }
            }
            result = true;
            conn.Close();
            return result;
        }
        public bool Update_Aggrement_Ref_No(int aggrement_id, String ref_no)
        {
            bool result = false;
            String query = null;
            conn.Open();
            if (ref_no != "")
            {
                query = @"UPDATE aggrements SET ref_no='" + ref_no + "' WHERE id='" + aggrement_id + "'";
            }
            else
            {
                query = @"UPDATE aggrements SET ref_no=NULL WHERE id='" + aggrement_id + "'";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            result = true;
            conn.Close();
            return result;
        }

        public bool Update_Aggrement_Current_Balance_New(String ref_no, Double current_balance, SqlTransaction trans = null)
        {
            bool result = false;
            // Only open if we aren't part of an existing transaction
            if (trans == null && conn.State != ConnectionState.Open) conn.Open();

            string query = @"UPDATE aggrements SET current_balance=@bal WHERE ref_no=@ref";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (trans != null) cmd.Transaction = trans; // Link to the bulk process
                cmd.Parameters.AddWithValue("@bal", current_balance);
                cmd.Parameters.AddWithValue("@ref", ref_no);
                cmd.ExecuteNonQuery();
                result = true;
            }

            if (trans == null) conn.Close();
            return result;
        }


        public bool Update_Aggrement_Current_Balance(String ref_no, Double current_balance)
        {
            bool result = false;
            String query = null;
            conn.Open();
            if (ref_no != "")
            {
                query = @"UPDATE aggrements SET current_balance='" + current_balance + "' WHERE ref_no='" + ref_no + "'";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            result = true;
            conn.Close();
            return result;
        }
        public bool Update_Aggrement_Remarks(int aggrement_id, String remarks)
        {
            bool result = false;
            conn.Open();
            String query = @"UPDATE aggrements SET remarks='" + remarks + "' WHERE id='" + aggrement_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            result = true;
            conn.Close();
            return result;
        }
        public bool Update_Aggrement_EMI_No(int aggrement_id, int emi_no, DateTime date, int store_id)
        {
            if (emi_no > -1)
            {
                Helper_Class helper_Class = new Helper_Class();
                if (helper_Class.IfEMINoExists(emi_no, store_id, date)) return false;

            }
            bool result = false;
            String query = null;
            conn.Open();
            if (emi_no != -1)
            {
                query = @"UPDATE aggrements SET emi_no='" + emi_no + "' WHERE id='" + aggrement_id + "'";
            }
            else
            {
                query = @"UPDATE aggrements SET emi_no=NULL WHERE id='" + aggrement_id + "'";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            result = true;
            conn.Close();
            return result;
        }
        public bool Update_Aggrement_Guardian_Id(int aggrement_id, int guardian_id)
        {
            bool result = false;
            String query = null;
            conn.Open();
            if (guardian_id == -1)
            {
                query = @"UPDATE aggrements SET guardian_id=NULL WHERE id='" + aggrement_id + "'";
            }
            else
            {
                query = @"UPDATE aggrements SET guardian_id='" + guardian_id + "' WHERE id='" + aggrement_id + "'";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            result = true;
            conn.Close();
            return result;
        }
        public bool Aggrement_Ref_No_Exists(string ref_no)
        {
            bool exists = false;

            // 1. Ensure connection is open
            if (conn.State != ConnectionState.Open) conn.Open();

            try
            {
                // 2. Query to check Ref.No within a specific store
                // We use COUNT(*) for efficiency
                string query = @"SELECT COUNT(*) FROM aggrements 
                         WHERE ref_no = @ref_no ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // 3. Use parameters to prevent SQL injection and handle special characters
                    cmd.Parameters.AddWithValue("@ref_no", ref_no);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        exists = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error checking Reference Number: " + ex.Message);
            }
            finally
            {
                // 4. Always close connection
                conn.Close();
            }

            return exists;
        }
        public bool Aggrement_Ref_No_Exists(int aggrement_id, String ref_no)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT id FROM aggrements WHERE ref_no='" + ref_no + "' and id!='" + aggrement_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value && obj != null)
            {
                if (Convert.ToInt32(obj) != -1)
                {
                    result = true;
                }
            }
            conn.Close();
            return result;
        }
        public bool Update_Before_Dues_Message(int AGGREMENT_DUES_ID, int messages_inc)
        {
            bool result = false;
            int get_dues_sent_messages = Get_Before_Dues_Sent_Messages(AGGREMENT_DUES_ID);
            int sent_messages = get_dues_sent_messages + messages_inc;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE aggrement_dues SET before_due_messages=@before_due_messages WHERE id='" + AGGREMENT_DUES_ID + "'", conn))
            {
                cmd.Parameters.AddWithValue("@before_due_messages", sent_messages);
                cmd.ExecuteNonQuery();
            }

            result = true;
            conn.Close();
            return result;
        }

        public bool Update_After_Dues_Message(int AGGREMENT_DUES_ID, int messages_inc)
        {
            bool result = false;
            int get_dues_sent_messages = Get_After_Dues_Sent_Messages(AGGREMENT_DUES_ID);
            int sent_messages = get_dues_sent_messages + messages_inc;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE aggrement_dues SET after_due_messages=@after_due_messages WHERE id='" + AGGREMENT_DUES_ID + "'", conn))
            {
                cmd.Parameters.AddWithValue("@after_due_messages", sent_messages);
                cmd.ExecuteNonQuery();
            }

            result = true;
            conn.Close();
            return result;
        }

        public bool Update_Cash_Vouchers_Sent_Message(int AGGREMENT_DUES_ID, int messages_inc)
        {
            bool result = false;
            int get_dues_sent_messages = Get_Cash_Vouchers_Sent_Messages(AGGREMENT_DUES_ID);
            int sent_messages = get_dues_sent_messages + messages_inc;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE aggrement_dues SET cash_voucher_messages=@cash_voucher_messages WHERE id='" + AGGREMENT_DUES_ID + "'", conn))
            {
                cmd.Parameters.AddWithValue("@cash_voucher_messages", sent_messages);
                cmd.ExecuteNonQuery();
            }

            result = true;
            conn.Close();
            return result;
        }
        public int Get_Before_Dues_Sent_Messages(int AGGREMENT_DUES_ID)
        {
            int result = 0;
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT before_due_messages from aggrement_dues WHERE id='" + AGGREMENT_DUES_ID + "'", conn))
            {
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }
        public int Get_After_Dues_Sent_Messages(int AGGREMENT_DUES_ID)
        {
            int result = 0;
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT after_due_messages from aggrement_dues WHERE id='" + AGGREMENT_DUES_ID + "'", conn))
            {
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }
        public int Get_Cash_Vouchers_Sent_Messages(int AGGREMENT_DUES_ID)
        {
            int result = 0;
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT cash_voucher_messages from aggrement_dues WHERE id='" + AGGREMENT_DUES_ID + "'", conn))
            {
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }

        public int Store(DateTime DATE, int CUSTOMER_ID, int STORE_ID, int GUARDIAN_ID, Double TOTAL_AMOUNT, Double ADVANCE_PAYMENT, Double BALANCE, DataTable agreement_items_table, int NO_Of_Installments, Double First_Emi, Double Rest_Emi, String Start_Date, int EMI_NO, String Ref_No = "", String Remarks = "", int team_id = -1)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO aggrements(date,customer_id,store_id,guardian_id,total_amount,advance_amount,balance,no_of_installments,first_emi,rest_emi,start_date,current_balance,status,emi_no,ref_no,remarks,team_id) values(@date,@customer_id,@store_id,@guardian_id,@total_amount,@advance_amount,@balance,@no_of_installments,@first_emi,@rest_emi,@start_date,@current_balance,@status,@emi_no,@ref_no,@remarks,@team_id) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@date", DATE);
                cmd.Parameters.AddWithValue("@customer_id", CUSTOMER_ID);
                cmd.Parameters.AddWithValue("@remarks", Remarks);
                if (Ref_No == "")
                {
                    cmd.Parameters.AddWithValue("@ref_no", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ref_no", Ref_No);
                }
                if (team_id == -1)
                {
                    cmd.Parameters.AddWithValue("@team_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@team_id", team_id);
                }
                cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                if (EMI_NO != -1)
                {
                    cmd.Parameters.AddWithValue("@emi_no", EMI_NO);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@emi_no", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@status", "In-Progress");
                if (GUARDIAN_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@guardian_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@guardian_id", GUARDIAN_ID);
                }
                cmd.Parameters.AddWithValue("@total_amount", TOTAL_AMOUNT);
                cmd.Parameters.AddWithValue("@advance_amount", ADVANCE_PAYMENT);
                cmd.Parameters.AddWithValue("@balance", BALANCE);
                cmd.Parameters.AddWithValue("@current_balance", BALANCE);
                cmd.Parameters.AddWithValue("@no_of_installments", NO_Of_Installments);
                cmd.Parameters.AddWithValue("@first_emi", First_Emi);
                cmd.Parameters.AddWithValue("@rest_emi", Rest_Emi);
                cmd.Parameters.AddWithValue("@start_date", Start_Date);
                Object obj = cmd.ExecuteScalar();
                conn.Close();
                if (obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);

                    double recievable_account_close_balance = 0;
                    double recievable_account_curr_balance = 0;
                    recievable_account_curr_balance = accounts_controller.Get_Account_Balance(CUSTOMER_ID);
                    recievable_account_close_balance = (recievable_account_curr_balance + TOTAL_AMOUNT);
                    accounts_controller.Insert_Account_Transaction(CUSTOMER_ID, accounts_controller.Get_Account_Name(CUSTOMER_ID), accounts_controller.Get_Account_Type(CUSTOMER_ID), accounts_controller.Get_Account_Nature(CUSTOMER_ID), "Sale", "New Aggrement", 0, 0, TOTAL_AMOUNT, 0, recievable_account_close_balance, DATE, null, null, 1);

                    double sales_close_balance = 0;
                    double sales_curr_balance = 0;
                    sales_curr_balance = accounts_controller.Get_Account_Balance(2008);
                    sales_close_balance = (sales_curr_balance + TOTAL_AMOUNT);
                    accounts_controller.Insert_Account_Transaction(2008, "Sales", accounts_controller.Get_Account_Type(2008), accounts_controller.Get_Account_Nature(2008), "Sale", "New Aggrement", 0, 0, 0, TOTAL_AMOUNT, sales_close_balance, DATE, null, null, 1);

                    if (ADVANCE_PAYMENT > 0)
                    {
                        //recievable_account_close_balance = 0;
                        //recievable_account_curr_balance = 0;
                        //recievable_account_curr_balance = accounts_controller.Get_Account_Balance(CUSTOMER_ID);
                        //recievable_account_close_balance = (recievable_account_curr_balance - ADVANCE_PAYMENT);
                        //accounts_controller.Insert_Account_Transaction(CUSTOMER_ID, accounts_controller.Get_Account_Name(CUSTOMER_ID), accounts_controller.Get_Account_Type(CUSTOMER_ID), accounts_controller.Get_Account_Nature(CUSTOMER_ID), "Sale", "New Aggrement", 0, 0, 0, ADVANCE_PAYMENT, recievable_account_close_balance, DATE, null, null, 1);

                        //advance payment should be saved as reciept
                        //vouchers should be saved as reciepts
                        Vouchers.Vouchers_Controller vouchers_controller = new Vouchers.Vouchers_Controller();
                        vouchers_controller.Store_Reciept_Voucher(DATE, CUSTOMER_ID, accounts_controller.Get_Account_Name(CUSTOMER_ID), ADVANCE_PAYMENT, "Agreement advance payment", "Cash", Ref_No);

                        //Double cash_account_close_balance = 0;
                        //Double cash_account_curr_balance = 0;
                        //cash_account_curr_balance = accounts_controller.Get_Account_Balance(2001);
                        //cash_account_close_balance = (cash_account_curr_balance + ADVANCE_PAYMENT);
                        //accounts_controller.Insert_Account_Transaction(2001, accounts_controller.Get_Account_Name(2001), accounts_controller.Get_Account_Type(2001), accounts_controller.Get_Account_Nature(2001), "Sale", "New Aggrement", 0, 0, ADVANCE_PAYMENT, 0, cash_account_close_balance, DATE, null, null, 1);
                    }

                    Store_Agreement_Items(DATE, STORE_ID, result, agreement_items_table);
                }
            }
            return result;
        }


        public void Update_Store_Stock(int id, Double final_stocked_out)
        {
            conn.Open();
            String query = @"UPDATE stock_transaction_items SET sold_out='" + final_stocked_out + "' WHERE id='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Send_Update_Status_Message()
        {
            if (aggrement_id != -1)
            {
                Aggrement aggrement = Get_Aggrement(aggrement_id);
                Accounts.Account customer_account = accounts_controller.Get_Customer(aggrement.Customer_Id);
                Items.Stores.Stores_Controller stores_controller = new Items.Stores.Stores_Controller();
                Items.Stores.Store store = stores_controller.Get_Store(aggrement.Store_Id); ;
                Items.Items_Controller items_controller = new Items.Items_Controller();
                //Items.Item item = items_controller.Get_Item(aggrement.Item_Id);
                Messages.Messages_Controller messages_controller = new Messages.Messages_Controller();
                Messages.Message message = new Messages.Message();
                if (aggrement_status_temp == "Defaulter")
                {
                    //message.Message_Text = "Dear " + customer_account.Account_Name + ", \n You are listed as defaulter with balance R.s." + aggrement.Current_Balance + " by " + store.Company_Name + ". You had purchased " + item.Name + " with R.s." + aggrement.Total_Amount + ". Your remaing balance was " + aggrement.Current_Balance + ".";
                }
                else
                {
                    //message.Message_Text = "Dear " + customer_account.Account_Name + ", \n You have returned " + item.Name + " to "+store.Company_Name+" with balance " + aggrement.Current_Balance + ". Please consider it."; ;
                }

                if (Settings.Default.phone_number_options_home_office == 1)
                {
                    if (customer_account.Office_Phone != "")
                    {
                        message.RECIEVER_NUMBER = customer_account.Office_Phone;
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
                            Thread.Sleep(1000);
                            goto send_message_start;
                        }
                        else
                        {
                            message.Status = "Draft";
                            Console.WriteLine("Message Drafted !");
                        }

                        //messages_controller.Store_Message(customer_account.Office_Phone, message.Message_Text, customer_account.Account_Id, aggrement.Store_Id);
                        //messages_controller.Store_Message(DateTime.Now, customer_account.Office_Phone, message.Message_Text, customer_account.Account_Id, aggrement.Store_Id);
                    }

                }
                else if (Settings.Default.phone_number_options_home_office == 2)
                {
                    if (customer_account.Home_Phone != "")
                    {
                        message.RECIEVER_NUMBER = customer_account.Home_Phone;
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
                            Thread.Sleep(1000);
                            goto send_message_start;
                        }
                        else
                        {
                            message.Status = "Draft";
                            Console.WriteLine("Message Drafted !");
                        }
                        //messages_controller.Store_Message(DateTime.Now, customer_account.Home_Phone, message.Message_Text, customer_account.Account_Id, aggrement.Store_Id);
                    }
                }
                else if (Settings.Default.phone_number_options_home_office == 3)
                {
                    if (customer_account.Office_Phone != "")
                    {
                        message.RECIEVER_NUMBER = customer_account.Office_Phone;
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
                            Thread.Sleep(1000);
                            goto send_message_start;
                        }
                        else
                        {
                            message.Status = "Draft";
                            Console.WriteLine("Message Drafted !");
                        }
                        //messages_controller.Store_Message(DateTime.Now, customer_account.Home_Phone, message.Message_Text, customer_account.Account_Id, aggrement.Store_Id);
                    }

                    if (customer_account.Home_Phone != "")
                    {
                        message.RECIEVER_NUMBER = customer_account.Home_Phone;
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
                            Thread.Sleep(1000);
                            goto send_message_start;
                        }
                        else
                        {
                            message.Status = "Draft";
                            Console.WriteLine("Message Drafted !");
                        }
                        //messages_controller.Store_Message(DateTime.Now, customer_account.Home_Phone, message.Message_Text, customer_account.Account_Id, aggrement.Store_Id);
                    }
                }
            }
            aggrement_id = -1;
        }
        public bool Update_Status(int Aggrement_Id, String Status)
        {
            bool result = false;
            Aggrement aggrement = Get_Aggrement(Aggrement_Id);
            conn.Open();
            String query = @"UPDATE aggrements SET status='" + Status + "' WHERE id='" + Aggrement_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            if (Status == "Returned")
            {
                //update store stock
                //update inventory balance
                //update customer balance
                //update sales balance

                Items.Stocks_Controller stocks_controller = new Items.Stocks_Controller();
                //stocks_controller.Update_Store_Returned_Aggrement_Stock(aggrement.Stock_Transaction_Item_Id);

                Items.Stores.Stores_Controller stores_controller = new Items.Stores.Stores_Controller();
                Items.Stores.Store_Item store_item = new Items.Stores.Store_Item();
                //stores_controller.Get_Stock_Item(aggrement.Stock_Transaction_Item_Id);

                Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();

                Accounts.Account inventory_account = accounts_controller.Get_Account(2011);
                accounts_controller.Insert_Account_Transaction(inventory_account.Account_Id, inventory_account.Account_Name, inventory_account.Account_Type, inventory_account.Account_Nature, "Sales Return", "Returned Aggrement", 0, 0, store_item.Purchase_Rate, 0, (inventory_account.Balance + store_item.Purchase_Rate), DateTime.Now, null, store_item.Name, 1);

                Accounts.Account cost_of_goods_sales = accounts_controller.Get_Account(2016);
                accounts_controller.Insert_Account_Transaction(cost_of_goods_sales.Account_Id, cost_of_goods_sales.Account_Name, cost_of_goods_sales.Account_Type, cost_of_goods_sales.Account_Nature, "Sales Return", "Returned Aggrement", 0, 0, 0, store_item.Purchase_Rate, (cost_of_goods_sales.Balance - store_item.Purchase_Rate), DateTime.Now, null, store_item.Name, 1);


                Accounts.Account customer_account = accounts_controller.Get_Account(aggrement.Customer_Id);
                accounts_controller.Insert_Account_Transaction(customer_account.Account_Id, customer_account.Account_Name, customer_account.Account_Type, customer_account.Account_Nature, "Sales Return", "Returned Aggrement", 0, 0, 0, aggrement.Current_Balance, (customer_account.Balance - aggrement.Current_Balance), DateTime.Now, null, store_item.Name, 1);

                Accounts.Account sales_account = accounts_controller.Get_Account(2008);
                accounts_controller.Insert_Account_Transaction(sales_account.Account_Id, sales_account.Account_Name, sales_account.Account_Type, sales_account.Account_Nature, "Sales Return", "Returned Aggrement", 0, 0, aggrement.Current_Balance, 0, (sales_account.Balance - aggrement.Current_Balance), DateTime.Now, null, store_item.Name, 1);
                result = true;
            }

            if (Status == "Defaulter")
            {
                //update customer balance
                Items.Stores.Stores_Controller stores_controller = new Items.Stores.Stores_Controller();
                Items.Stores.Store_Item store_item = new Items.Stores.Store_Item();
                //stores_controller.Get_Stock_Item(aggrement.Stock_Transaction_Item_Id);

                Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
                Accounts.Account customer_account = accounts_controller.Get_Account(aggrement.Customer_Id);
                accounts_controller.Insert_Account_Transaction(customer_account.Account_Id, customer_account.Account_Name, customer_account.Account_Type, customer_account.Account_Nature, "Defaulter Marked", "Aggrements", 0, 0, 0, aggrement.Current_Balance, (customer_account.Balance - aggrement.Current_Balance), DateTime.Now, null, store_item.Name, 1);

                Accounts.Account defaulters_inventory_ac = accounts_controller.Get_Account(2019);
                accounts_controller.Insert_Account_Transaction(defaulters_inventory_ac.Account_Id, defaulters_inventory_ac.Account_Name, defaulters_inventory_ac.Account_Type, defaulters_inventory_ac.Account_Nature, "Defaulter Marked", "Aggrements", 0, 0, aggrement.Current_Balance, 0, (defaulters_inventory_ac.Balance + aggrement.Current_Balance), DateTime.Now, null, store_item.Name, 1);
                //update defaulters inventory balance
                result = true;

            }
            if (Settings.Default.send_message_on_update_aggrement_status == true)
            {
                //aggrement_status_temp = Status;
                //aggrement_id = Aggrement_Id;
                //if (STS_Thread.ThreadState == ThreadState.Unstarted)
                //{
                //    STS_Thread.Start();
                //}
                //if (STS_Thread.ThreadState == ThreadState.Aborted)
                //{
                //    //STS_Thread = new Thread(Send_Update_Status_Message);
                //    //STS_Thread.Start();
                //}
            }
            return result;
        }
        public DataTable Get_Aggrement_Dues_Table(Aggrement aggrement, bool insertAdvanceRow = true)
        {

            DataTable aggrement_dues_table = new DataTable();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            String query = voucherCollection.ReceiptsQueryString(aggrement.Aggrement_Id);
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.Fill(aggrement_dues_table);
            conn.Close();


            if (insertAdvanceRow)
            {
                DataRow advanceRow = aggrement_dues_table.NewRow();
                voucherCollection.LoadAdvanceRow(advanceRow, Convert.ToDateTime(aggrement.Date).ToShortDateString(), aggrement.Advance_Payment.ToString("0,#"), Convert.ToDateTime(aggrement.Date).ToShortDateString(), aggrement.Advance_Payment.ToString("0,#"), aggrement.EMI_No.ToString(), aggrement.Balance, "Advance Payment", 0);
                aggrement_dues_table.Rows.InsertAt(advanceRow, 0);
            }

            return aggrement_dues_table;
        }

        public DataTable Get_Aggrement_Paid_Dues_Table(Aggrement aggrement, bool insertAdvanceRow = true)
        {
            DataTable aggrement_dues_table = new DataTable();
            conn.Open();
            String query = voucherCollection.PaidReceiptsQueryString(aggrement.Aggrement_Id);
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.Fill(aggrement_dues_table);
            conn.Close();

            if (insertAdvanceRow)
            {
                DataRow advanceRow = aggrement_dues_table.NewRow();
                voucherCollection.LoadAdvanceRow(advanceRow, Convert.ToDateTime(aggrement.Date).ToShortDateString(), aggrement.Advance_Payment.ToString("0,#"), Convert.ToDateTime(aggrement.Date).ToShortDateString(), aggrement.Advance_Payment.ToString("0,#"), aggrement.EMI_No.ToString(), aggrement.Balance, "Advance Payment", 0);
                aggrement_dues_table.Rows.InsertAt(advanceRow, 0);
            }
            return aggrement_dues_table;
        }

        public DataTable Get_Aggrement_Items_Table(int aggrement_id)
        {
            DataTable aggrement_items_table = new DataTable();
            conn.Open();
            String query = @"SELECT s_i.item_id as 'Code',items.name as 'Item',models.name as 'Model',s_i.sold_qty as 'Quantity',s_i.returned_quantity as 'Returned Quantity',s_i.defaulted_quantity as 'Defaulted Quantity',s_i.sale_rate as 'Sale Rate',s_i.discount_rs as 'Disc(%)',s_i.discount_percent 'Disc(R.S)',s_i.net_total as 'Total' from sale_items as s_i left join items on s_i.item_id=items.id left join item_models as models on items.model_id=models.id WHERE s_i.agreement_id='" + aggrement_id + "'";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.Fill(aggrement_items_table);
            conn.Close();
            return aggrement_items_table;
        }
        public List<Agreement_Item> Get_Aggrement_Items_List(int aggrement_id)
        {
            DataTable aggrement_items_table = new DataTable();
            List<Agreement_Item> agreement_items_list = new List<Agreement_Item>();
            conn.Open();
            String query = @"SELECT s_i.id as 'agreement_item_id',s_i.item_id,s_i.stock_transaction_id as 'stock_transaction_item_id',s_i.purchase_item_id,s_i.purchase_rate,s_i.sale_rate,s_i.discount_percent,s_i.discount_rs,s_i.sold_qty,s_i.returned_quantity,s_i.defaulted_quantity,s_i.net_total from sale_items as s_i left join items on s_i.item_id=items.id WHERE s_i.agreement_id='" + aggrement_id + "'";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.Fill(aggrement_items_table);
            conn.Close();
            for (int i = 0; i < aggrement_items_table.Rows.Count; i++)
            {
                Agreement_Item agreement_item = new Agreement_Item();
                agreement_item.Agreement_Item_Id = Convert.ToInt32(aggrement_items_table.Rows[i]["agreement_item_id"]);
                agreement_item.Item_Id = Convert.ToInt32(aggrement_items_table.Rows[i]["item_id"]);
                agreement_item.Stock_Transaction_Item_Id = Convert.ToInt32(aggrement_items_table.Rows[i]["stock_transaction_item_id"]);
                agreement_item.Purchase_Item_Id = Convert.ToInt32(aggrement_items_table.Rows[i]["purchase_item_id"]);
                agreement_item.Purchase_Rate = Convert.ToDouble(aggrement_items_table.Rows[i]["purchase_rate"]);
                agreement_item.Sale_Rate = Convert.ToDouble(aggrement_items_table.Rows[i]["sale_rate"]);
                agreement_item.Disc_Percent = Convert.ToDouble(aggrement_items_table.Rows[i]["discount_percent"]);
                agreement_item.Disc_Rs = Convert.ToDouble(aggrement_items_table.Rows[i]["discount_rs"]);
                agreement_item.Sold_Quantity = Convert.ToDouble(aggrement_items_table.Rows[i]["sold_qty"]);
                agreement_item.Returned_Quantity = Convert.ToDouble(aggrement_items_table.Rows[i]["returned_quantity"]);
                agreement_item.Defaulted_Quantity = Convert.ToDouble(aggrement_items_table.Rows[i]["defaulted_quantity"]);
                agreement_item.Net_Total = Convert.ToDouble(aggrement_items_table.Rows[i]["net_total"]);
                agreement_items_list.Add(agreement_item);
            }
            return agreement_items_list;
        }
        public void Store_Agreement_Items(DateTime DATE, int Store_Id, int Aggrement_Id, DataTable Aggrement_Items)
        {
            for (int i = 0; i < Aggrement_Items.Rows.Count; i++)
            {
                Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
                Double ITEM_QTY = Convert.ToDouble(Aggrement_Items.Rows[i]["Quantity"]);
                int itemCode = Convert.ToInt32(Aggrement_Items.Rows[i]["Code"]);
                Double originalRate = Convert.ToDouble(Aggrement_Items.Rows[i]["Original Sale Rate"]);

            update_items_sold_out:
                // 1. Get the batch
                Items.Stores.Store_Item store_item = stores_controller.Get_Current_Stock_Item_By_Sale_Rate(itemCode, Store_Id, originalRate);

                if (store_item == null)
                {
                    XtraMessageBox.Show("Stock discrepancy detected! Item Code " + itemCode + " has no available batches but is requested in the agreement.");
                    return; // Safety break: Stop the loop if no batch is found
                }

                // 2. FIXED MATH: Include sales_return in the availability check
                // Formula: (In + SalesReturn) - (Out + Returned + Transferred)
                Double available_stock = (store_item.Stock_in + store_item.Sales_Return) - (store_item.Sold_out + store_item.Returned_Items + store_item.Transfered_Items);

                // 3. Safety Check: If math results in 0 or less, we cannot fulfill from this batch
                if (available_stock <= 0)
                {
                    // This is a data error (Get_Current_Stock_Item returned a full batch)
                    // We must break to avoid infinite loop
                    XtraMessageBox.Show("Infinite loop prevented. Batch ID " + store_item.Store_Item_Id + " reports availability but math results in 0.");
                    return;
                }

                Double current_req_qty = 0;
                if (available_stock >= ITEM_QTY)
                {
                    current_req_qty = ITEM_QTY;
                }
                else
                {
                    current_req_qty = available_stock;
                }

                // 4. Update the Batch Out Count
                Double updated_sold_qty = store_item.Sold_out + current_req_qty;

                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO sale_items(date,agreement_id,item_id,stock_transaction_id,sale_rate, advance_rate, emi_price,purchase_rate,purchase_item_id,sold_qty,returned_qty,discount_percent,discount_rs,net_total, sub_total,defaulted_quantity,returned_quantity) values(@date,@agreement_id,@item_id,@stock_transaction_id,@sale_rate, @advance_rate, @emi_price,@purchase_rate,@purchase_item_id,@sold_qty,@returned_qty,@discount_percent,@discount_rs,@net_total, @sub_total,@defaulted_quantity,@returned_quantity) SELECT CAST(scope_identity() AS int)", conn))
                {
                    cmd.Parameters.AddWithValue("@date", DATE);
                    cmd.Parameters.AddWithValue("@agreement_id", Aggrement_Id);
                    cmd.Parameters.AddWithValue("@item_id", itemCode);
                    cmd.Parameters.AddWithValue("@defaulted_quantity", 0);
                    cmd.Parameters.AddWithValue("@returned_quantity", 0);
                    cmd.Parameters.AddWithValue("@stock_transaction_id", store_item.Store_Item_Id);
                    cmd.Parameters.AddWithValue("@advance_rate", Convert.ToDouble(Aggrement_Items.Rows[i]["Advance"]));
                    cmd.Parameters.AddWithValue("@emi_price", Convert.ToDouble(Aggrement_Items.Rows[i]["Monthly EMI"]));
                    cmd.Parameters.AddWithValue("@sale_rate", Convert.ToDouble(Aggrement_Items.Rows[i]["Sale Rate"]));
                    cmd.Parameters.AddWithValue("@purchase_rate", store_item.Purchase_Rate);
                    cmd.Parameters.AddWithValue("@purchase_item_id", store_item.Purchase_Item_Id);
                    cmd.Parameters.AddWithValue("@sold_qty", current_req_qty);
                    cmd.Parameters.AddWithValue("@returned_qty", 0);
                    cmd.Parameters.AddWithValue("@discount_percent", Convert.ToDouble(Aggrement_Items.Rows[i]["Disc(%)"]));
                    cmd.Parameters.AddWithValue("@discount_rs", Convert.ToDouble(Aggrement_Items.Rows[i]["Disc(R.S)"]));
                    cmd.Parameters.AddWithValue("@sub_total", Convert.ToDouble(Aggrement_Items.Rows[i]["Total"]));
                    cmd.Parameters.AddWithValue("@net_total", Convert.ToDouble(Aggrement_Items.Rows[i]["Total"]));
                    cmd.ExecuteScalar();
                    conn.Close();

                    double inventory_curr_balance = 0;
                    double inventory_close_balance = 0;
                    inventory_curr_balance = accounts_controller.Get_Account_Balance(2011);
                    inventory_close_balance = inventory_curr_balance - (store_item.Purchase_Rate * current_req_qty);
                    accounts_controller.Insert_Account_Transaction(2011, "Inventory", accounts_controller.Get_Account_Type(2011), accounts_controller.Get_Account_Nature(2011), "Sale", "New Aggrement", 0, 0, 0, (store_item.Purchase_Rate * current_req_qty), inventory_close_balance, DATE, Aggrement_Id.ToString(), store_item.Name, 1);

                    double goods_sold_close_balance = 0;
                    double goods_sold_curr_balance = 0;
                    goods_sold_curr_balance = accounts_controller.Get_Account_Balance(2016);
                    goods_sold_close_balance = (goods_sold_curr_balance + (store_item.Purchase_Rate * current_req_qty));
                    accounts_controller.Insert_Account_Transaction(2016, "Cost of Goods Sold", accounts_controller.Get_Account_Type(2016), accounts_controller.Get_Account_Nature(2016), "Sale", "New Aggrement", 0, 0, (store_item.Purchase_Rate * current_req_qty), 0, goods_sold_close_balance, DATE, null, store_item.Name, 1);
                    //here will be change
                    Update_Store_Stock(store_item.Store_Item_Id, updated_sold_qty);

                    // 6. Reduce required quantity
                    ITEM_QTY = ITEM_QTY - current_req_qty;

                    if (ITEM_QTY > 0)
                    {
                        goto update_items_sold_out;
                    }
                }
            }
        }
        public void Store_Agreement_Items_oLD(DateTime DATE, int Store_Id, int Aggrement_Id, DataTable Aggrement_Items)
        {
            for (int i = 0; i < Aggrement_Items.Rows.Count; i++)
            {
                Items.Stores.Store_Item store_item = new Items.Stores.Store_Item();
                Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
                Double ITEM_QTY = 0;
                ITEM_QTY = Convert.ToDouble(Aggrement_Items.Rows[i]["Quantity"]);
                goto update_items_sold_out;
            // here will start loop for available stock
            update_items_sold_out:
                double updated_qty = 0;
                //XtraMessageBox.Show("orignal sale rate:" + Convert.ToDouble(Aggrement_Items.Rows[i]["Original Sale Rate"]));
                store_item = stores_controller.Get_Current_Stock_Item_By_Sale_Rate(Convert.ToInt32(Aggrement_Items.Rows[i]["Code"]), Store_Id, Convert.ToDouble(Aggrement_Items.Rows[i]["Original Sale Rate"]));
                //XtraMessageBox.Show("Item Code:" + Convert.ToInt32(Aggrement_Items.Rows[i]["Code"]));
                Double available_stock = ((store_item.Stock_in + store_item.Sales_Return) - (store_item.Sold_out + store_item.Returned_Items + store_item.Transfered_Items));
                Double current_req_qty = 0;
                if (available_stock >= ITEM_QTY)
                {
                    updated_qty = (store_item.Sold_out + ITEM_QTY);
                    current_req_qty = ITEM_QTY;
                }
                else
                {
                    updated_qty = (store_item.Sold_out + available_stock);
                    current_req_qty = available_stock;
                }
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO sale_items(date,agreement_id,item_id,stock_transaction_id,sale_rate, advance_rate, emi_price,purchase_rate,purchase_item_id,sold_qty,returned_qty,discount_percent,discount_rs,net_total, sub_total,defaulted_quantity,returned_quantity) values(@date,@agreement_id,@item_id,@stock_transaction_id,@sale_rate, @advance_rate, @emi_price,@purchase_rate,@purchase_item_id,@sold_qty,@returned_qty,@discount_percent,@discount_rs,@net_total, @sub_total,@defaulted_quantity,@returned_quantity) SELECT CAST(scope_identity() AS int)", conn))
                {
                    cmd.Parameters.AddWithValue("@date", DATE);
                    cmd.Parameters.AddWithValue("@agreement_id", Aggrement_Id);
                    cmd.Parameters.AddWithValue("@item_id", Convert.ToInt32(Aggrement_Items.Rows[i]["Code"]));
                    //XtraMessageBox.Show("item is saving to sale items:code=" + Convert.ToInt32(Aggrement_Items.Rows[i]["Code"]));
                    cmd.Parameters.AddWithValue("@defaulted_quantity", 0);
                    cmd.Parameters.AddWithValue("@returned_quantity", 0);
                    cmd.Parameters.AddWithValue("@stock_transaction_id", store_item.Store_Item_Id);
                    cmd.Parameters.AddWithValue("@advance_rate", Convert.ToDouble(Aggrement_Items.Rows[i]["Advance"]));
                    cmd.Parameters.AddWithValue("@emi_price", Convert.ToDouble(Aggrement_Items.Rows[i]["Monthly EMI"]));
                    cmd.Parameters.AddWithValue("@sale_rate", Convert.ToDouble(Aggrement_Items.Rows[i]["Sale Rate"]));
                    cmd.Parameters.AddWithValue("@purchase_rate", store_item.Purchase_Rate);
                    cmd.Parameters.AddWithValue("@purchase_item_id", store_item.Purchase_Item_Id);
                    cmd.Parameters.AddWithValue("@sold_qty", current_req_qty);
                    cmd.Parameters.AddWithValue("@returned_qty", 0);
                    cmd.Parameters.AddWithValue("@discount_percent", Convert.ToDouble(Aggrement_Items.Rows[i]["Disc(%)"]));
                    cmd.Parameters.AddWithValue("@discount_rs", Convert.ToDouble(Aggrement_Items.Rows[i]["Disc(R.S)"]));
                    cmd.Parameters.AddWithValue("@sub_total", Convert.ToDouble(Aggrement_Items.Rows[i]["Total"]));
                    cmd.Parameters.AddWithValue("@net_total", Convert.ToDouble(Aggrement_Items.Rows[i]["Total"]));
                    Object obj = cmd.ExecuteScalar();
                    conn.Close();

                    double inventory_curr_balance = 0;
                    double inventory_close_balance = 0;
                    inventory_curr_balance = accounts_controller.Get_Account_Balance(2011);
                    inventory_close_balance = inventory_curr_balance - (store_item.Purchase_Rate * current_req_qty);
                    accounts_controller.Insert_Account_Transaction(2011, "Inventory", accounts_controller.Get_Account_Type(2011), accounts_controller.Get_Account_Nature(2011), "Sale", "New Aggrement", 0, 0, 0, (store_item.Purchase_Rate * current_req_qty), inventory_close_balance, DATE, Aggrement_Id.ToString(), store_item.Name, 1);

                    double goods_sold_close_balance = 0;
                    double goods_sold_curr_balance = 0;
                    goods_sold_curr_balance = accounts_controller.Get_Account_Balance(2016);
                    goods_sold_close_balance = (goods_sold_curr_balance + (store_item.Purchase_Rate * current_req_qty));
                    accounts_controller.Insert_Account_Transaction(2016, "Cost of Goods Sold", accounts_controller.Get_Account_Type(2016), accounts_controller.Get_Account_Nature(2016), "Sale", "New Aggrement", 0, 0, (store_item.Purchase_Rate * current_req_qty), 0, goods_sold_close_balance, DATE, null, store_item.Name, 1);
                    //here will be change
                    Update_Store_Stock(store_item.Store_Item_Id, updated_qty);

                    ITEM_QTY = ITEM_QTY - available_stock;

                    if (ITEM_QTY > 0)
                    {
                        goto update_items_sold_out;
                    }
                }
            }
        }
        public Aggrement Get_Aggrement(int Aggrement_Id)
        {
            Aggrement aggrement = new Aggrement();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            String query = @"SELECT TOP 1 ag.id as 'Aggrement Id',ag.remarks,ag.ref_no,ag.emi_no,ag.current_balance as 'Current Balance',ag.date as 'Date',ag.customer_id as 'Customer Id',ag.total_amount as 'Total Amount',ag.guardian_id as 'Guardian Id',ag.store_id as 'Store Id',ag.advance_amount as 'Advance Payment',ag.balance as 'Balance',ag.no_of_installments as 'No Of Installments',ag.first_emi as 'First Emi',ag.rest_emi as 'Rest Emi',ag.start_date as 'Start Date',ag.status as 'Status' from aggrements as ag WHERE ag.id='" + Aggrement_Id + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                aggrement.Aggrement_Id = Convert.ToInt32(reader["Aggrement Id"]);
                aggrement.Customer_Id = Convert.ToInt32(reader["Customer Id"]);
                aggrement.Store_Id = Convert.ToInt32(reader["Store Id"]);
                if (reader["Guardian Id"] != DBNull.Value)
                {
                    aggrement.Guardian_Id = Convert.ToInt32(reader["Guardian Id"]);
                }
                if (reader["ref_no"] != DBNull.Value)
                {
                    aggrement.Ref_No = Convert.ToString(reader["ref_no"]);
                }
                aggrement.Date = reader["Date"].ToString();
                aggrement.Remarks = reader["remarks"].ToString();
                aggrement.Status = reader["Status"].ToString();
                aggrement.Advance_Payment = Convert.ToDouble(reader["Advance Payment"]);
                aggrement.Balance = Convert.ToDouble(reader["Balance"]);
                aggrement.Current_Balance = Convert.ToDouble(reader["Current Balance"]);
                aggrement.No_Of_Installments = Convert.ToInt32(reader["No Of Installments"]);
                if (reader["emi_no"] != DBNull.Value)
                {
                    aggrement.EMI_No = Convert.ToInt32(reader["emi_no"]);
                }
                else
                {
                    aggrement.EMI_No = -1;
                }
                aggrement.First_EMI = Convert.ToDouble(reader["First Emi"]);
                aggrement.Rest_EMI = Convert.ToDouble(reader["Rest Emi"]);
                aggrement.Total_Amount = Convert.ToDouble(reader["Total Amount"]);
                aggrement.Start_Date = reader["Start Date"].ToString();
            }
            reader.Close();
            conn.Close();
            aggrement.Aggrement_Items_Table = Get_Aggrement_Items_Table(Aggrement_Id);
            aggrement.Aggrement__Return_Items_Table = Get_Aggrement_Return_Items_Table_By_Aggrement_Id(Aggrement_Id);
            aggrement.Aggrement_Dues_Table = Get_Aggrement_Dues_Table(aggrement);
            return aggrement;
        }

        public Aggrement Get_Aggrement_By_Ref_No(String Ref_No)
        {
            Items.Stores.Stores_Controller stores_Controller = new Items.Stores.Stores_Controller();
            Items.Stores.Store store = new Items.Stores.Store();
            Aggrement aggrement = new Aggrement();
            conn.Open();
            String query = @"SELECT TOP 1 ag.id as 'Aggrement Id',ag.ref_no, ag.sale_return_amount,ag.emi_no,ag.current_balance as 'Current Balance',ag.date as 'Date',ag.customer_id as 'Customer Id',ag.total_amount as 'Total Amount',ag.guardian_id as 'Guardian Id',ag.store_id as 'Store Id',ag.advance_amount as 'Advance Payment',ag.balance as 'Balance',ag.no_of_installments as 'No Of Installments',ag.first_emi as 'First Emi',ag.rest_emi as 'Rest Emi',ag.start_date as 'Start Date',ag.status as 'Status' from aggrements as ag WHERE ag.ref_no='" + Ref_No + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int aggrement_id = Convert.ToInt32(reader["Aggrement Id"]);
                aggrement.Aggrement_Id = aggrement_id;
                aggrement.Customer_Id = Convert.ToInt32(reader["Customer Id"]);
                //aggrement.Item_Id = Convert.ToInt32(reader["Item Id"]);
                aggrement.Store_Id = Convert.ToInt32(reader["Store Id"]);
                store = stores_controller.Get_Store(aggrement.Store_Id);
                aggrement.Store_Name = store.Name;
                //aggrement.Stock_Transaction_Item_Id = Convert.ToInt32(reader["stock_transaction_item_id"]);
                if (reader["Guardian Id"] != DBNull.Value)
                {
                    aggrement.Guardian_Id = Convert.ToInt32(reader["Guardian Id"]);
                }
                else
                {
                    aggrement.Guardian_Id = -1;
                }
                if (reader["ref_no"] != DBNull.Value)
                {
                    aggrement.Ref_No = Convert.ToString(reader["ref_no"]);
                }
                aggrement.Date = reader["Date"].ToString();
                aggrement.Status = reader["Status"].ToString();
                //aggrement.Sale_Rate = Convert.ToDouble(reader["Sale Rate"]);
                aggrement.Advance_Payment = Convert.ToDouble(reader["Advance Payment"]);
                aggrement.Balance = Convert.ToDouble(reader["Balance"]);
                aggrement.Current_Balance = Convert.ToDouble(reader["Current Balance"]);
                aggrement.No_Of_Installments = Convert.ToInt32(reader["No Of Installments"]);
                if (reader["emi_no"] != DBNull.Value)
                {
                    aggrement.EMI_No = Convert.ToInt32(reader["emi_no"]);
                }
                else
                {
                    aggrement.EMI_No = -1;
                }
                aggrement.First_EMI = Convert.ToDouble(reader["First Emi"]);
                aggrement.Rest_EMI = Convert.ToDouble(reader["Rest Emi"]);
                aggrement.Total_Amount = Convert.ToDouble(reader["Total Amount"]);
                aggrement.Sale_Return_Amount = Convert.ToDouble(reader["sale_return_amount"]);
                aggrement.Start_Date = reader["Start Date"].ToString();
            }
            reader.Close();
            conn.Close();

            //aggrement.Aggrement_Dues_Table = Get_Aggrement_Dues_Table(aggrement_id);
            aggrement.Aggrement_Dues_Table = Get_Aggrement_Dues_Table(aggrement);
            return aggrement;
        }

        public bool Store_Agreement_Return_Final(int aggId, string RefNo, DateTime returnDate, DataTable returnItems, double totalPaidAmountKept, double newEmiAmount, DataTable emiAmountsTable, double finalNewBalance, double aggrementPrevBalance, double totalReturningAmount, double totalPaidAmount, double totalRemainingAmount, String EMINo)
        {
            // System IDs for Accounts (from your DatabaseHandler.cs)
            const int ACC_INVENTORY = 2011;
            const int ACC_COGS = 2016;
            const int ACC_SALES_RETURN = 2020;
            const int ACC_USAGE_INCOME = 2021;

            Aggrement agg = Get_Aggrement(aggId);
            if (agg.Aggrement_Id <= 0)
            {
                XtraMessageBox.Show("Agreement not found.");
                return false;
            }

            double totalPurchValueReversal = 0;
            double creditToCustomer = totalReturningAmount - totalPaidAmountKept;

            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                // 1. LOG THE RETURN MASTER (Audit Trail)
                string insMaster = @"INSERT INTO agreement_returns 
            (agreement_id, customer_id, guardian_id, store_id, return_date, ref_no, emi_no, aggrement_total_amount, aggrement_adv_amount, prev_balance, total_return_value, total_paid_value, total_remaining_value, fee_kept, credit_to_customer, new_balance, remarks) 
            VALUES (@aid, @cid, @gid, @stid, @rdate, @ref, @emi_no, @aggtotamt, @aggadvamt, @pbal, @trv, @tpv, @tremv, @fee, @credit, @nbal, @rem); 
            SELECT CAST(scope_identity() AS int);";

                SqlCommand cmdMaster = new SqlCommand(insMaster, conn, trans);
                cmdMaster.Parameters.AddWithValue("@aid", aggId);
                cmdMaster.Parameters.AddWithValue("@cid", agg.Customer_Id);
                if (agg.Guardian_Id > -1)
                {
                    cmdMaster.Parameters.AddWithValue("@gid", agg.Guardian_Id);
                }
                else
                {
                    cmdMaster.Parameters.AddWithValue("@gid", DBNull.Value);
                }
                cmdMaster.Parameters.AddWithValue("@stid", agg.Store_Id);
                cmdMaster.Parameters.AddWithValue("@rdate", returnDate);
                cmdMaster.Parameters.AddWithValue("@ref", RefNo);
                if(EMINo == "" || EMINo == null)
                {
                    cmdMaster.Parameters.AddWithValue("@emi_no", "-1");
                }
                else
                {

                    cmdMaster.Parameters.AddWithValue("@emi_no", EMINo);
                }
                    cmdMaster.Parameters.AddWithValue("@aggtotamt", agg.Total_Amount);
                cmdMaster.Parameters.AddWithValue("@aggadvamt", agg.Advance_Payment);
                cmdMaster.Parameters.AddWithValue("@pbal", aggrementPrevBalance);
                cmdMaster.Parameters.AddWithValue("@trv", totalReturningAmount);
                cmdMaster.Parameters.AddWithValue("@tpv", totalPaidAmount);
                cmdMaster.Parameters.AddWithValue("@tremv", totalRemainingAmount);
                cmdMaster.Parameters.AddWithValue("@fee", totalPaidAmountKept);
                cmdMaster.Parameters.AddWithValue("@credit", creditToCustomer);
                cmdMaster.Parameters.AddWithValue("@nbal", finalNewBalance);
                cmdMaster.Parameters.AddWithValue("@rem", "Processed Return for Ref: " + RefNo);

                int returnMasterId = Convert.ToInt32(cmdMaster.ExecuteScalar());

                // 2. PROCESS ITEMS & LOG ITEM DETAILS
                foreach (DataRow row in returnItems.Rows)
                {
                    int itemCode = Convert.ToInt32(row["Code"]);
                    double qty = Convert.ToDouble(row["Quantity"]);
                    double sRate = Convert.ToDouble(row["Sale Rate"]);
                    double totalPaid = Convert.ToDouble(row["Paid"]);
                    double totalRemaining = Convert.ToDouble(row["Remaining"]);

                    string findSql = "SELECT stock_transaction_id, purchase_rate FROM sale_items WHERE agreement_id=@aid AND item_id=@iid";
                    SqlCommand cmdFind = new SqlCommand(findSql, conn, trans);
                    cmdFind.Parameters.AddWithValue("@aid", aggId);
                    cmdFind.Parameters.AddWithValue("@iid", itemCode);

                    int stItemId = 0;
                    double pRate = 0;
                    using (SqlDataReader dr = cmdFind.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            stItemId = Convert.ToInt32(dr["stock_transaction_id"]);
                            pRate = Convert.ToDouble(dr["purchase_rate"]);
                        }
                    }
                    totalPurchValueReversal += (qty * pRate);

                    // Log item-wise return detail
                    string insDetail = @"INSERT INTO agreement_return_items (aggrement_id, aggrement_return_id, ref_no, item_id, stock_transaction_id, quantity, sale_rate, total_paid, total_remaining, purchase_rate, sub_total) 
                                VALUES (@agid, @rid, @ref, @iid, @stid, @qty, @srate, @total_paid, @total_remaining, @prate, @sub)";
                    SqlCommand cmdDet = new SqlCommand(insDetail, conn, trans);
                    cmdDet.Parameters.AddWithValue("@agid", aggId);
                    cmdDet.Parameters.AddWithValue("@rid", returnMasterId);
                    cmdDet.Parameters.AddWithValue("@ref", RefNo);
                    cmdDet.Parameters.AddWithValue("@iid", itemCode);
                    cmdDet.Parameters.AddWithValue("@stid", stItemId);
                    cmdDet.Parameters.AddWithValue("@qty", qty);
                    cmdDet.Parameters.AddWithValue("@srate", sRate);
                    cmdDet.Parameters.AddWithValue("@total_paid", totalPaid);
                    cmdDet.Parameters.AddWithValue("@total_remaining", totalRemaining);
                    cmdDet.Parameters.AddWithValue("@prate", pRate);
                    cmdDet.Parameters.AddWithValue("@sub", qty * sRate);
                    cmdDet.ExecuteNonQuery();

                    // Update original agreement items
                    string updSale = "UPDATE sale_items SET returned_value = @ret_val,net_total = net_total - @ret_val ,returned_quantity = returned_quantity + @qty WHERE agreement_id=@aid AND item_id=@iid";
                    SqlCommand cmdU1 = new SqlCommand(updSale, conn, trans);
                    cmdU1.Parameters.AddWithValue("@qty", qty);
                    cmdU1.Parameters.AddWithValue("@aid", aggId);
                    cmdU1.Parameters.AddWithValue("@iid", itemCode);
                    cmdU1.Parameters.AddWithValue("@ret_val", qty * sRate);
                    cmdU1.ExecuteNonQuery();

                    // Update physical stock
                    string updStock = "UPDATE stock_transaction_items SET sales_return = sales_return + @qty WHERE id=@stid";
                    SqlCommand cmdU2 = new SqlCommand(updStock, conn, trans);
                    cmdU2.Parameters.AddWithValue("@qty", qty);
                    cmdU2.Parameters.AddWithValue("@stid", stItemId);
                    cmdU2.ExecuteNonQuery();
                }

                // 3. RE-BUILD EMI SCHEDULE
                string delSql = "DELETE FROM aggrement_dues WHERE aggrement_id=@aid AND (paid_amount IS NULL OR paid_amount = 0) AND is_return_fixed != 1";
                SqlCommand delCmd = new SqlCommand(delSql, conn, trans);
                delCmd.Parameters.AddWithValue("@aid", aggId);
                delCmd.ExecuteNonQuery();

                if (emiAmountsTable != null && emiAmountsTable.Rows.Count > 0)
                {
                    foreach (DataRow row in emiAmountsTable.Rows)
                    {
                        string insEmi = @"INSERT INTO aggrement_dues (aggrement_id, ref_no, status, emi_no, is_return_fixed, emi_date, emi_amount, paid_amount, balance, remarks) 
                                VALUES (@aid, @ref, @status, @eno, @is_return_fixed, @edate, @eamt, 0, @bal, @rem)";
                        SqlCommand cmdEmi = new SqlCommand(insEmi, conn, trans);
                        cmdEmi.Parameters.AddWithValue("@aid", aggId);
                        cmdEmi.Parameters.AddWithValue("@ref", RefNo);
                        cmdEmi.Parameters.AddWithValue("@status", row["Status"].ToString());
                        cmdEmi.Parameters.AddWithValue("@eno", row["EMI No"]);
                        cmdEmi.Parameters.AddWithValue("@edate", row["Due Date"]);
                        cmdEmi.Parameters.AddWithValue("@is_return_fixed", Convert.ToInt32(row["Is Return Fixed"]));
                        cmdEmi.Parameters.AddWithValue("@eamt", row["Due Amount"]);
                        cmdEmi.Parameters.AddWithValue("@bal", row["Balance"]);
                        cmdEmi.Parameters.AddWithValue("@rem", row["Remarks"] ?? DBNull.Value);
                        cmdEmi.ExecuteNonQuery();
                    }
                }

                // 4. UPDATE AGREEMENT HEADER
                string updAgg = "UPDATE aggrements SET current_balance = @nb, sale_return_amount = sale_return_amount + @sra, status = @st WHERE id=@aid";
                SqlCommand cmdAgg = new SqlCommand(updAgg, conn, trans);
                cmdAgg.Parameters.AddWithValue("@nb", finalNewBalance);
                cmdAgg.Parameters.AddWithValue("@sra", totalReturningAmount);
                cmdAgg.Parameters.AddWithValue("@st", finalNewBalance <= 0 ? "Returned" : "In-Progress");
                cmdAgg.Parameters.AddWithValue("@aid", aggId);
                cmdAgg.ExecuteNonQuery();

                // 5. FINANCIAL ACCOUNTING (DYNAMICALY FETCHED VIA CONTROLLER)

                // A. Sales Return (Reverse Revenue)
                double curSRBal = accounts_controller.Get_Account_Balance(ACC_SALES_RETURN);
                accounts_controller.Insert_Account_Transaction(
                    ACC_SALES_RETURN,
                    accounts_controller.Get_Account_Name(ACC_SALES_RETURN),
                    accounts_controller.Get_Account_Type(ACC_SALES_RETURN),
                    accounts_controller.Get_Account_Nature(ACC_SALES_RETURN),
                    "Sale Return", "Sale Return (" + agg.Ref_No + ")", 0, 0, totalReturningAmount, 0, curSRBal + totalReturningAmount, returnDate);

                // B. Customer Balance Adjustment
                double curCustBal = accounts_controller.Get_Account_Balance(agg.Customer_Id);
                accounts_controller.Insert_Account_Transaction(
                    agg.Customer_Id,
                    accounts_controller.Get_Account_Name(agg.Customer_Id),
                    accounts_controller.Get_Account_Type(agg.Customer_Id),
                    accounts_controller.Get_Account_Nature(agg.Customer_Id),
                    "Sale Return", "Balance Fixed via Sale Return", 0, 0, 0, creditToCustomer, curCustBal - creditToCustomer, returnDate);

                // C. Usage Income (Fee Kept)
                if (totalPaidAmountKept > 0)
                {
                    double curUsageBal = accounts_controller.Get_Account_Balance(ACC_USAGE_INCOME);
                    accounts_controller.Insert_Account_Transaction(
                        ACC_USAGE_INCOME,
                        accounts_controller.Get_Account_Name(ACC_USAGE_INCOME),
                        accounts_controller.Get_Account_Type(ACC_USAGE_INCOME),
                        accounts_controller.Get_Account_Nature(ACC_USAGE_INCOME),
                        "Sale Return", "Sale Retrun Usage Fee Kept", 0, 0, 0, totalPaidAmountKept, curUsageBal + totalPaidAmountKept, returnDate);
                }

                // D. Inventory Reversal (Stock back to Asset)
                double curInvBal = accounts_controller.Get_Account_Balance(ACC_INVENTORY);
                accounts_controller.Insert_Account_Transaction(
                    ACC_INVENTORY,
                    accounts_controller.Get_Account_Name(ACC_INVENTORY),
                    accounts_controller.Get_Account_Type(ACC_INVENTORY),
                    accounts_controller.Get_Account_Nature(ACC_INVENTORY),
                    "Sale Return", "Sale Return Stock Restored", 0, 0, totalPurchValueReversal, 0, curInvBal + totalPurchValueReversal, returnDate);

                // E. COGS Reversal (Reduce Expense)
                double curCogsBal = accounts_controller.Get_Account_Balance(ACC_COGS);
                accounts_controller.Insert_Account_Transaction(
                    ACC_COGS,
                    accounts_controller.Get_Account_Name(ACC_COGS),
                    accounts_controller.Get_Account_Type(ACC_COGS),
                    accounts_controller.Get_Account_Nature(ACC_COGS),
                    "Sale Return", "COGS Reversal via Sale Return", 0, 0, 0, totalPurchValueReversal, curCogsBal - totalPurchValueReversal, returnDate);

                trans.Commit();
                //XtraMessageBox.Show("Agreement Return processed successfully!", "Success");
                return true;
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                XtraMessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally { conn.Close(); }
        }

        public Aggrement_Return Get_Aggrement_Return_Details(int returnId)
        {
            Aggrement_Return ret = new Aggrement_Return();
            conn.Open();
            string query = @"SELECT * FROM agreement_returns WHERE id = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", returnId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ret.Aggrement_Return_Id = returnId;
                ret.Aggrement_Id = Convert.ToInt32(reader["agreement_id"]);
                ret.Customer_Id = Convert.ToInt32(reader["customer_id"]);
                ret.Guardian_Id = Convert.ToInt32(reader["guardian_id"]);
                ret.Store_Id = Convert.ToInt32(reader["store_id"]);
                ret.Date = Convert.ToDateTime(reader["return_date"]).ToString("dd-MM-yyyy");
                ret.Ref_No = reader["ref_no"].ToString();
                ret.EMI_No = (reader["emi_no"] != DBNull.Value) ? Convert.ToInt32(reader["emi_no"]) : -1;
                ret.Aggrement_Total_Amount = Convert.ToDouble(reader["aggrement_total_amount"]);
                ret.Total_Returning_Amount = Convert.ToDouble(reader["total_return_value"]);
                ret.Total_Paid_Amount = Convert.ToDouble(reader["total_paid_value"]);
                ret.Total_Remaining_Amount = Convert.ToDouble(reader["total_remaining_value"]);
                ret.Advance_Payment = Convert.ToDouble(reader["aggrement_adv_amount"]);
                ret.Prev_Balance = Convert.ToDouble(reader["prev_balance"]);
                ret.New_Balance = Convert.ToDouble(reader["new_balance"]);
                ret.Fee_Kept = Convert.ToDouble(reader["fee_kept"]);
                ret.Remarks = reader["remarks"].ToString();
            }
            reader.Close();
            conn.Close();

            ret.Aggrement_Return_Items_Table = Get_Aggrement_Return_Items_Table(returnId);
            return ret;
        }

        public DataTable Get_Aggrement_Return_Items_Table(int returnId)
        {
            DataTable dt = new DataTable();
            conn.Open();
            string query = @"SELECT ari.item_id as 'Code', itm.name as 'Item', m.name as 'Model', 
                     ari.quantity as 'Quantity', ari.sale_rate as 'Sale Rate', ari.sub_total as 'Total', ari.total_paid as 'Paid', ari.total_remaining as 'Remaining'
                     FROM agreement_return_items ari
                     LEFT JOIN items itm ON ari.item_id = itm.id
                     LEFT JOIN item_models m ON itm.model_id = m.id
                     WHERE ari.aggrement_return_id = @rid";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.SelectCommand.Parameters.AddWithValue("@rid", returnId);
            adp.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable Get_Aggrement_Return_Items_Table_By_Aggrement_Id(int aggId)
        {
            DataTable dt = new DataTable();
            conn.Open();
            string query = @"SELECT FORMAT(ar.return_date, 'dd-MM-yyyy') as 'Date', ari.item_id as 'Code', itm.name as 'Item', m.name as 'Model', 
                     ari.quantity as 'Quantity', ari.sale_rate as 'Sale Rate', ari.sub_total as 'Total', ari.total_paid as 'Paid', ari.total_remaining as 'Remaining', ar.remarks as 'Remarks'
                     FROM JAMERA_EMI.dbo.agreement_return_items ari
                     LEFT JOIN JAMERA_EMI.dbo.agreement_returns ar ON ari.aggrement_return_id = ar.id
                     LEFT JOIN JAMERA_EMI.dbo.items itm ON ari.item_id = itm.id
                     LEFT JOIN JAMERA_EMI.dbo.item_models m ON itm.model_id = m.id
                     WHERE ari.aggrement_id = @rid";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.SelectCommand.Parameters.AddWithValue("@rid", aggId);
            adp.Fill(dt);
            conn.Close();
            return dt;
        }

        public bool Aggrement_Return_Exists_By_Aggrement_Id(int aggId)
        {
            bool exists = false;
            conn.Open();
            string query = "SELECT COUNT(*) FROM agreement_returns WHERE agreement_id = @aid";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@aid", aggId);
            exists = (int)cmd.ExecuteScalar() > 0;
            conn.Close();
            return exists;
        }

        public bool Delete_Aggrement_Return_By_Aggrement_Id(int aggId)
        {
            bool result = false;
            if (Aggrement_Return_Exists_By_Aggrement_Id(aggId))
            {
                List<int> returnIds = new List<int>();

                // 1. Find all Return IDs associated with this Agreement
                // We use a list in case there are multiple partial returns for one agreement
                conn.Open();
                string query = "SELECT id FROM agreement_returns WHERE agreement_id = @aid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@aid", aggId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnIds.Add(Convert.ToInt32(reader["id"]));
                        }
                    }
                }
                conn.Close(); // Connection must be closed here because Delete_Aggrement_Return opens its own

                // 2. Execute the full reversal for each return found
                if (returnIds.Count > 0)
                {
                    foreach (int rid in returnIds)
                    {
                        // Call your main logic method (the one we fixed for transaction safety)
                        result = Delete_Aggrement_Return(rid);

                        // If any reversal fails, stop and return false
                        if (!result) return false;
                    }
                }
                else
                {
                    // No returns found to delete
                    return false;
                }
            }
            else
            {
                return false;
            }

            return result;
        }

        public bool Delete_Aggrement_Return(int returnId)
        {
            // Account Constants from your DatabaseHandler
            const int ACC_INVENTORY = 2011;
            const int ACC_COGS = 2016;
            const int ACC_SALES_RETURN = 2020;
            const int ACC_USAGE_INCOME = 2021;

            // 1. Fetch full details of the return record to know what to reverse
            Aggrement_Return retRecord = Get_Aggrement_Return_Details(returnId);
            if (retRecord.Aggrement_Id <= 0) return false;

            Aggrement originalAggData = Get_Aggrement(retRecord.Aggrement_Id);

            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                DateTime revDate = DateTime.Now;
                double totalPurchValueReversal = 0;

                // 2. REVERSE STOCK & ITEM QUANTITIES
                foreach (DataRow row in retRecord.Aggrement_Return_Items_Table.Rows)
                {
                    int itemCode = Convert.ToInt32(row["Code"]);
                    double qty = Convert.ToDouble(row["Quantity"]);

                    // Link back to the original stock transaction
                    string findSql = "SELECT stock_transaction_id, purchase_rate FROM sale_items WHERE agreement_id=@aid AND item_id=@iid";
                    SqlCommand cmdFind = new SqlCommand(findSql, conn, trans);
                    cmdFind.Parameters.AddWithValue("@aid", retRecord.Aggrement_Id);
                    cmdFind.Parameters.AddWithValue("@iid", itemCode);

                    int stItemId = 0;
                    double pRate = 0;
                    using (SqlDataReader dr = cmdFind.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            stItemId = Convert.ToInt32(dr["stock_transaction_id"]);
                            pRate = Convert.ToDouble(dr["purchase_rate"]);
                        }
                    }
                    totalPurchValueReversal += (qty * pRate);

                    // A. Update Sale Items: Remove from the returned_quantity count
                    string updSale = "UPDATE sale_items SET returned_value=0, net_total=sub_total,returned_quantity = returned_quantity - @qty WHERE agreement_id=@aid AND item_id=@iid";
                    SqlCommand cmdU1 = new SqlCommand(updSale, conn, trans);
                    cmdU1.Parameters.AddWithValue("@qty", qty);
                    cmdU1.Parameters.AddWithValue("@aid", retRecord.Aggrement_Id);
                    cmdU1.Parameters.AddWithValue("@iid", itemCode);
                    cmdU1.ExecuteNonQuery();

                    // B. Update Store Stock: Remove items from sales_return (they are going back to the customer)
                    string updStock = "UPDATE stock_transaction_items SET sales_return = sales_return - @qty WHERE id=@stid";
                    SqlCommand cmdU2 = new SqlCommand(updStock, conn, trans);
                    cmdU2.Parameters.AddWithValue("@qty", qty);
                    cmdU2.Parameters.AddWithValue("@stid", stItemId);
                    cmdU2.ExecuteNonQuery();
                }

                // 3. RESTORE AGREEMENT BALANCE
                // We restore current_balance to the 'prev_balance' (the state before return)
                string updAgg = @"UPDATE aggrements SET 
                          current_balance = @pbal, 
                          sale_return_amount = sale_return_amount - @tra, 
                          status = 'In-Progress' 
                          WHERE id=@aid";
                SqlCommand cmdAgg = new SqlCommand(updAgg, conn, trans);
                cmdAgg.Parameters.AddWithValue("@pbal", (originalAggData.Current_Balance + retRecord.Total_Remaining_Amount));
                cmdAgg.Parameters.AddWithValue("@tra", (retRecord.Total_Returning_Amount)); // Reversing return value
                cmdAgg.Parameters.AddWithValue("@aid", retRecord.Aggrement_Id);
                cmdAgg.ExecuteNonQuery();


                // 3. RE-BUILD ORIGINAL DUES (Helper method implemented below)
                double restoredDebt = originalAggData.Current_Balance + retRecord.Total_Remaining_Amount;
                Restore_Aggrement_Dues(originalAggData, restoredDebt, trans);


                // 4. REVERSE ACCOUNTING (JOURNAL TRANSACTIONS)

                // A. Sales Return Reversal (Credit to reduce the return account)
                double curSRBal = accounts_controller.Get_Account_Balance(ACC_SALES_RETURN);
                accounts_controller.Insert_Account_Transaction(ACC_SALES_RETURN, accounts_controller.Get_Account_Name(ACC_SALES_RETURN),
                    accounts_controller.Get_Account_Type(ACC_SALES_RETURN), accounts_controller.Get_Account_Nature(ACC_SALES_RETURN),
                    "Reversed Sale Return", "Reversed Sale Return(" + retRecord.Ref_No + ")", 0, 0, 0, (retRecord.Total_Returning_Amount), curSRBal - (retRecord.Total_Returning_Amount), revDate);

                // B. Restore Customer Debt (Debit to increase debt)
                double creditBackToCustomer = retRecord.Prev_Balance - retRecord.New_Balance;
                double curCustBal = accounts_controller.Get_Account_Balance(retRecord.Customer_Id);
                accounts_controller.Insert_Account_Transaction(retRecord.Customer_Id, accounts_controller.Get_Account_Name(retRecord.Customer_Id),
                    accounts_controller.Get_Account_Type(retRecord.Customer_Id), accounts_controller.Get_Account_Nature(retRecord.Customer_Id),
                    "Reversed Sale Return", "Reversed Sale Return", 0, 0, creditBackToCustomer, 0, curCustBal + creditBackToCustomer, revDate);

                // C. Usage Income Reversal (Debit to reduce revenue)
                if (retRecord.Fee_Kept > 0)
                {
                    double curUsageBal = accounts_controller.Get_Account_Balance(ACC_USAGE_INCOME);
                    accounts_controller.Insert_Account_Transaction(ACC_USAGE_INCOME, accounts_controller.Get_Account_Name(ACC_USAGE_INCOME),
                        accounts_controller.Get_Account_Type(ACC_USAGE_INCOME), accounts_controller.Get_Account_Nature(ACC_USAGE_INCOME),
                        "Reversed Sale Return", "Reversed Sale Return Usage Fee", 0, 0, retRecord.Fee_Kept, 0, curUsageBal - retRecord.Fee_Kept, revDate);
                }

                // D. Inventory & COGS Reversal (Move from Asset back to Expense)
                double curInvBal = accounts_controller.Get_Account_Balance(ACC_INVENTORY);
                double curCogsBal = accounts_controller.Get_Account_Balance(ACC_COGS);

                accounts_controller.Insert_Account_Transaction(ACC_INVENTORY, accounts_controller.Get_Account_Name(ACC_INVENTORY), accounts_controller.Get_Account_Type(ACC_INVENTORY), accounts_controller.Get_Account_Nature(ACC_INVENTORY), "Reversed Sale Return", "Reversed Sale Return", 0, 0, 0, totalPurchValueReversal, curInvBal - totalPurchValueReversal, revDate);
                accounts_controller.Insert_Account_Transaction(ACC_COGS, accounts_controller.Get_Account_Name(ACC_COGS), accounts_controller.Get_Account_Type(ACC_COGS), accounts_controller.Get_Account_Nature(ACC_COGS), "Reversed Sale Return", "COGS Re-established by Reversed Sale Return", 0, 0, totalPurchValueReversal, 0, curCogsBal + totalPurchValueReversal, revDate);

                // 5. DELETE RECORD
                SqlCommand cmdDelItems = new SqlCommand("DELETE FROM agreement_return_items WHERE aggrement_return_id = @id", conn, trans);
                cmdDelItems.Parameters.AddWithValue("@id", returnId);
                cmdDelItems.ExecuteNonQuery();

                SqlCommand cmdDelMaster = new SqlCommand("DELETE FROM agreement_returns WHERE id = @id", conn, trans);
                cmdDelMaster.Parameters.AddWithValue("@id", returnId);
                cmdDelMaster.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                XtraMessageBox.Show("Delete Failed: " + ex.Message);
                return false;
            }
            finally { conn.Close(); }
        }

        private void Restore_Aggrement_Dues(Aggrement orig, double totalNewBalance, SqlTransaction trans)
        {
            // 1. Delete all rows created by the return fix (unpaid and adjustments)
            string sqlClean = "DELETE FROM aggrement_dues WHERE aggrement_id=@aid AND paid_amount = 0 AND (is_return_fixed = 1 OR is_return_fixed = -1)";
            using (SqlCommand cmdClean = new SqlCommand(sqlClean, conn, trans))
            {
                cmdClean.Parameters.AddWithValue("@aid", orig.Aggrement_Id);
                cmdClean.ExecuteNonQuery();
            }

            // 2. Determine the starting point (Last Paid EMI)
            int lastEmiNo = 0;
            DateTime nextDueDate;

            string sqlLastPaid = "SELECT TOP 1 emi_no, emi_date FROM aggrement_dues WHERE aggrement_id=@aid AND paid_amount > 0 ORDER BY id DESC";
            using (SqlCommand cmdLast = new SqlCommand(sqlLastPaid, conn, trans))
            {
                cmdLast.Parameters.AddWithValue("@aid", orig.Aggrement_Id);
                using (SqlDataReader dr = cmdLast.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        //lastEmiNo = Convert.ToInt32(dr["emi_no"]);
                        // Add 1 month to the last paid date
                        nextDueDate = Convert.ToDateTime(dr["emi_date"]).AddMonths(1);
                    }
                    else
                    {
                        // No EMIs paid yet, start from original Agreement Start Date
                        //lastEmiNo = 0;
                        nextDueDate = Convert.ToDateTime(orig.Start_Date);
                    }
                }
            }

            // 3. Reschedule based on the Restored Balance
            double tempBal = totalNewBalance;
            double emiAmount = orig.Rest_EMI;
            int monthsToAdd = 0;

            // IMPORTANT: while loop prevents extra rows with 0 balance
            while (tempBal > 0)
            {
                double currentEmiValue = (tempBal > emiAmount) ? emiAmount : tempBal;
                tempBal -= currentEmiValue;

                string sqlIns = @"INSERT INTO aggrement_dues 
            (aggrement_id, ref_no, emi_no, emi_date, emi_amount, paid_amount, balance, is_return_fixed, remarks) 
            VALUES (@aid, @ref, @eno, @edate, @eamt, 0, @bal, 0, @rem)";

                using (SqlCommand cmdIns = new SqlCommand(sqlIns, conn, trans))
                {
                    cmdIns.Parameters.AddWithValue("@aid", orig.Aggrement_Id);
                    cmdIns.Parameters.AddWithValue("@ref", orig.Ref_No);
                    cmdIns.Parameters.AddWithValue("@eno", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@edate", nextDueDate.AddMonths(monthsToAdd).ToString("dd-MM-yyyy"));
                    cmdIns.Parameters.AddWithValue("@eamt", currentEmiValue);
                    cmdIns.Parameters.AddWithValue("@bal", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@rem", "");
                    cmdIns.ExecuteNonQuery();
                }

                monthsToAdd++;
            }
        }

        private void Restore_Aggrement_Dues_oLD(Aggrement orig, double totalNewBalane, SqlTransaction trans)
        {
            // A. Delete all schedule rows created by the return process (Adjustments and New Plans)
            // We target rows where paid_amount is 0 AND they were part of a return fix
            string sqlClean = "DELETE FROM aggrement_dues WHERE aggrement_id=@aid AND paid_amount = 0 AND (is_return_fixed = 1 OR is_return_fixed = -1)";
            SqlCommand cmdClean = new SqlCommand(sqlClean, conn, trans);
            cmdClean.Parameters.AddWithValue("@aid", orig.Aggrement_Id);
            cmdClean.ExecuteNonQuery();

            // B. Get original agreement parameters
            //Aggrement orig = Get_Aggrement(aggId); // Using your existing method

            double totalBalanceToSchedule = totalNewBalane;
            double firstEmi = orig.First_EMI;
            double restEmi = orig.Rest_EMI;
            int totalInstallments = orig.No_Of_Installments;
            DateTime startDate = Convert.ToDateTime(orig.Start_Date);

            // C. Loop through the original installment count and restore missing ones
            double tempBal = totalBalanceToSchedule;
            for (int i = 0; i < totalInstallments; i++)
            {
                int emiNo = i + 1;
                double currentEmiAmt = (emiNo == 1) ? firstEmi : restEmi;
                DateTime currentDueDate = startDate.AddMonths(i);

                // Check if this EMI # already exists (Customer might have paid it before the return)
                string sqlCheck = "SELECT COUNT(*) FROM aggrement_dues WHERE aggrement_id=@aid AND emi_no=@eno AND paid_amount > 0";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn, trans);
                cmdCheck.Parameters.AddWithValue("@aid", orig.Aggrement_Id);
                cmdCheck.Parameters.AddWithValue("@eno", emiNo.ToString());

                if ((int)cmdCheck.ExecuteScalar() == 0)
                {
                    // EMI doesn't exist as paid, so we restore it as an unpaid row
                    tempBal -= currentEmiAmt;

                    string sqlIns = @"INSERT INTO aggrement_dues 
                (aggrement_id, ref_no, emi_no, emi_date, emi_amount, paid_amount, balance, is_return_fixed, remarks) 
                VALUES (@aid, @ref, @eno, @edate, @eamt, 0, @bal, 0, @rem)";

                    SqlCommand cmdIns = new SqlCommand(sqlIns, conn, trans);
                    cmdIns.Parameters.AddWithValue("@aid", orig.Aggrement_Id);
                    cmdIns.Parameters.AddWithValue("@ref", orig.Ref_No);
                    cmdIns.Parameters.AddWithValue("@eno", emiNo.ToString());
                    cmdIns.Parameters.AddWithValue("@edate", currentDueDate.ToString("dd-MM-yyyy"));
                    cmdIns.Parameters.AddWithValue("@eamt", currentEmiAmt);
                    cmdIns.Parameters.AddWithValue("@bal", tempBal < 0 ? 0 : tempBal);
                    cmdIns.Parameters.AddWithValue("@rem", "");
                    cmdIns.ExecuteNonQuery();
                }
                else
                {
                    // Update temp balance even if skipped to keep running balance accurate
                    tempBal -= currentEmiAmt;
                }
            }
        }

    }
}

