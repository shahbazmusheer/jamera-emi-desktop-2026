using DevExpress.DashboardCommon.Native;
using DevExpress.Data.Async;
using DevExpress.Printing.Utils.DocumentStoring;
using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraEditors;
using Jamera.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace Jamera.Vouchers
{
    class Vouchers_Controller
    {
        //SqlConnection conn = new SqlConnection();
        Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
        Aggrements.Aggrements_Controller aggrements_controller = new Aggrements.Aggrements_Controller();
        Aggrements.Aggrement aggrement = new Aggrements.Aggrement();
        SqlConnection conn = new SqlConnection();
        public Vouchers_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            conn = db_handler.GetDatabseConnection();
        }
        public int Store_Journal_Voucher(DateTime DATE,int DEBIT_ACCOUNT_ID,String DEBIT_ACCOUNT_NAME,String DEBIT_ACCOUNT_DESCRIPTION,int CREDIT_ACCOUNT_ID,String CREDIT_ACCOUNT_NAME,String CREDIT_ACCOUNT_DESCRIPTON,Double VOUCHER_AMOUNT,String ref_no)
        {
            int result = -1;
            double credit_account_balance = accounts_controller.Get_Account_Balance(CREDIT_ACCOUNT_ID);
            double debit_account_balance = accounts_controller.Get_Account_Balance(DEBIT_ACCOUNT_ID);
            double final_balance_for_credit_account = 0;
            double final_balance_for_debit_account = 0;
            if (accounts_controller.Get_Account_Type(CREDIT_ACCOUNT_ID) == "DR")
            {
                // credited account type is debit
                if (credit_account_balance > 0)
                {
                    final_balance_for_credit_account = credit_account_balance - VOUCHER_AMOUNT;
                }
                else if (credit_account_balance == 0)
                {
                    final_balance_for_credit_account = VOUCHER_AMOUNT;
                }
                else
                {
                    final_balance_for_credit_account = credit_account_balance + VOUCHER_AMOUNT;
                }

            }
            else
            {
                final_balance_for_credit_account = credit_account_balance + VOUCHER_AMOUNT;
            }
            if (accounts_controller.Get_Account_Type(DEBIT_ACCOUNT_ID) == "DR")
            {
                //if debited account is debit
                final_balance_for_debit_account = debit_account_balance + VOUCHER_AMOUNT;
            }
            else
            {
                if (debit_account_balance > 0)
                {
                    final_balance_for_debit_account = debit_account_balance - VOUCHER_AMOUNT;
                }
                else if (debit_account_balance == 0)
                {
                    final_balance_for_debit_account = VOUCHER_AMOUNT;
                }
                else
                {
                    final_balance_for_debit_account = debit_account_balance + VOUCHER_AMOUNT;
                }
            }
            accounts_controller.Insert_Account_Transaction(CREDIT_ACCOUNT_ID,CREDIT_ACCOUNT_NAME,accounts_controller.Get_Account_Type(CREDIT_ACCOUNT_ID),accounts_controller.Get_Account_Nature(CREDIT_ACCOUNT_ID),"J_V",CREDIT_ACCOUNT_DESCRIPTON, 0,0, 0, VOUCHER_AMOUNT, final_balance_for_credit_account,DATE);
            accounts_controller.Insert_Account_Transaction(DEBIT_ACCOUNT_ID,DEBIT_ACCOUNT_NAME,accounts_controller.Get_Account_Type(DEBIT_ACCOUNT_ID),accounts_controller.Get_Account_Nature(DEBIT_ACCOUNT_ID),"J_V",DEBIT_ACCOUNT_DESCRIPTION,0, 0,VOUCHER_AMOUNT, 0, final_balance_for_debit_account, DATE);

            result = Store(DATE,1001, "Journal Voucher", DEBIT_ACCOUNT_ID,CREDIT_ACCOUNT_ID,DEBIT_ACCOUNT_NAME,CREDIT_ACCOUNT_NAME,DEBIT_ACCOUNT_DESCRIPTION,CREDIT_ACCOUNT_DESCRIPTON,VOUCHER_AMOUNT,ref_no);
            return result;
        }

        public int Store(DateTime ISSUE_DATE,int VOUCHER_TYPE_ID,String VOUCHER_TYPE,int DEBIT_ACCOUNT_ID,int CREDIT_ACCOUNT_ID,String DEBIT_ACCOUNT_NAME,String CREDIT_ACCOUNT_NAME,String DEBIT_DESCRIPTION,String CREDIT_DESCRIPTION,Double AMOUNT,String ref_no, int ref_id = -1, string ref_type = "")
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO vouchers(issue_date,voucher_type_id,voucher_type,debit_account_id,debit_account_name,debit_description,credit_account_id,credit_account_name,credit_description,amount,ref_no) values(@issue_date,@voucher_type_id,@voucher_type,@debit_account_id,@debit_account_name,@debit_description,@credit_account_id,@credit_account_name,@credit_description,@amount,@ref_no)  SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@issue_date",ISSUE_DATE);
                if(ref_no == "")
                {
                    cmd.Parameters.AddWithValue("@ref_no", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ref_no", ref_no);
                }
                cmd.Parameters.AddWithValue("@voucher_type_id", VOUCHER_TYPE_ID);
                cmd.Parameters.AddWithValue("@voucher_type", VOUCHER_TYPE);
                cmd.Parameters.AddWithValue("@debit_account_id", DEBIT_ACCOUNT_ID);
                cmd.Parameters.AddWithValue("@debit_account_name", DEBIT_ACCOUNT_NAME);
                cmd.Parameters.AddWithValue("@debit_description", DEBIT_DESCRIPTION);
                cmd.Parameters.AddWithValue("@credit_account_id", CREDIT_ACCOUNT_ID);
                cmd.Parameters.AddWithValue("@credit_account_name", CREDIT_ACCOUNT_NAME);
                cmd.Parameters.AddWithValue("@credit_description", CREDIT_DESCRIPTION);
                cmd.Parameters.AddWithValue("@amount",AMOUNT);
                cmd.Parameters.AddWithValue("@ref_id", ref_id == -1 ? (object)DBNull.Value : ref_id);
                cmd.Parameters.AddWithValue("@ref_type", ref_type);

                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }
        public int Store_EMI_Voucher(DateTime DATE,int STORE_ID,String START_SERIAL,String END_SERIAL,String DESCRIPTION)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO emi_vouchers(date,store_id,start_serial,end_serial,description) values(@date,@store_id,@start_serial,@end_serial,@description)  SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@date", DATE.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                cmd.Parameters.AddWithValue("@start_serial", START_SERIAL);
                cmd.Parameters.AddWithValue("@end_serial", END_SERIAL);
                cmd.Parameters.AddWithValue("@description",DESCRIPTION);
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }
        public int Get_Valid_Emi_Start_Serial()
        {
            int result = -1;
            conn.Open();
            String query = @"SELECT MAX(end_serial) as 'end_serial' FROM emi_vouchers";
            SqlCommand cmd = new SqlCommand(query,conn);
            Object obj = cmd.ExecuteScalar();
            if(obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj);
            }
            conn.Close();
            return result;
        }
        public bool Update_Voucher_Ref_No(int voucher_id,String Ref_No)
        {
            bool result = false;
            conn.Open();
            String query = @"UPDATE vouchers set ref_no='"+Ref_No+"' WHERE id='"+voucher_id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            result = true;
            conn.Close();
            return result;
        }

        public EMI getEMIDetails(int dueId)
        {

            EMI emi = new EMI();
            conn.Open();
            String query = @"SELECT ROW_NUMBER() OVER (ORDER BY CONVERT(datetime, emi_date,105) ASC) AS 'Sr.No', id as 'Code', emi_no as 'EMI No',emi_amount as 'Due Amount',emi_date as 'Due Date', status as 'Status', is_return_fixed as 'Is Return Fixed', paid_date as 'Receipt Date', paid_amount as 'Received Amount', balance as 'Balance', remarks as 'Remarks' from aggrement_dues WHERE id='" + dueId + "'";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                emi.dueId = Convert.ToInt32(reader["Code"]);
                emi.dueDate = Convert.ToDateTime(reader["Due Date"]);
                emi.dueAmount = Convert.ToDouble(reader["Due Amount"]);
                emi.recDate = Convert.ToDateTime(reader["Receipt Date"]);
                emi.recAmount = Convert.ToDouble(reader["Received Amount"]);
                emi.emiNo = Convert.ToInt32(reader["EMI No"]);
                emi.isReturnFixed = Convert.ToInt32(reader["Is Return Fixed"]);
                emi.Status = reader["Status"].ToString();
                emi.Remarks = reader["Remarks"].ToString();
                emi.Balance = Convert.ToDouble(reader["Balance"]);
            }
            reader.Close();
            conn.Close();
            return emi;
        }


        //dueId, emiNo, recDate, recStatus, remarks, isReturnFixed, storeId
        public bool Update_Dues_EMI(int storeId, int dueId, DateTime dueDate, double dueAmount, string Status, DateTime recDate, int emiNo, string Remarks)
        {
            // 1. Pre-update validation
            
            //if (emi_no > -1)
            //{
            //    Helper_Class helper_Class = new Helper_Class();
            //    // Ensure this method doesn't conflict with the connection used below
            //    if (helper_Class.IfEMINoExists(emi_no, store_id, date)) return false;
            //}

            bool result = false;
            // Standardize date format to match your database VARCHAR format
            string dueDateFormatted = dueDate.ToString("dd-MM-yyyy");
            string recDateFormatted = recDate.ToString("dd-MM-yyyy");

            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                // 2. Update the record in aggrement_dues
                // Fixed: Added @pdate parameter logic
                string query = "UPDATE aggrement_dues SET emi_date=@edate, emi_amount=@eamt,emi_no = @eno, paid_date = @pdate, status=@status, remarks=@remarks WHERE id = @id and is_return_fixed = -1";
                using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@eno", emiNo == -1 ? (object)DBNull.Value : emiNo.ToString());
                    cmd.Parameters.AddWithValue("@edate", dueDateFormatted);
                    cmd.Parameters.AddWithValue("@eamt", dueAmount);
                    cmd.Parameters.AddWithValue("@pdate", recDateFormatted);
                    cmd.Parameters.AddWithValue("@status", Status);
                    cmd.Parameters.AddWithValue("@remarks", Remarks == "" ? (object)DBNull.Value : Remarks);
                    cmd.Parameters.AddWithValue("@id", dueId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0) result = true;
                }

                // 3. CRITICAL SYNC: Update the corresponding record in cash_voucher_items
                // We use the 'trans' object to ensure this happens inside the same 'bubble'
                string syncQuery = @"
            UPDATE cvi 
            SET cvi.emi_voucher_id = @eno, 
                cvi.date = @pdate
            FROM cash_voucher_items cvi
            INNER JOIN aggrement_dues ad ON cvi.ref_no = ad.ref_no AND cvi.date = ad.paid_date
            WHERE ad.id = @id";

                using (SqlCommand cmdSync = new SqlCommand(syncQuery, conn, trans))
                {
                    // Note: In cash_voucher_items, emi_voucher_id is numeric, so we use 0 or emi_no
                    cmdSync.Parameters.AddWithValue("@eno", emiNo == -1 ? 0 : emiNo);
                    cmdSync.Parameters.AddWithValue("@pdate", recDate);
                    cmdSync.Parameters.AddWithValue("@id", dueId);
                    cmdSync.ExecuteNonQuery();
                }

                // commit if both updates succeeded
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                XtraMessageBox.Show("Database Sync Error: " + ex.Message);
                result = false;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public bool Update_Dues_EMI_No_Old(int dueId, int emi_no)
        {
            bool result = false;
            String query = null;
            conn.Open();
            query = @"UPDATE aggrement_dues SET emi_no='" + emi_no.ToString() + "' WHERE id='" + dueId + "'";
            if(emi_no == -1)
            {
                query = @"UPDATE aggrement_dues SET emi_no=NULL WHERE id='" + dueId + "'";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            XtraMessageBox.Show("EMI No updated in Aggrement Dues for Id:" + dueId + "!");
            result = true;
            conn.Close();
            return result;
        }

        public double Get_Active_EMI_Amount(int agg_id)
        {
            double result = 0;
            if (conn.State != ConnectionState.Open) conn.Open();
            try
            {
                // Logic: Find the most recent 'fixed' point (usually from a return)
                // If no fixed point exists, get the Rest_EMI from the master agreement.
                string query = @"
            DECLARE @LastFixedID INT = (SELECT MAX(id) FROM aggrement_dues WHERE aggrement_id = @aid AND is_return_fixed = 1);
            
            IF @LastFixedID IS NOT NULL
                SELECT TOP 1 emi_amount FROM aggrement_dues WHERE aggrement_id = @aid AND id > @LastFixedID ORDER BY id ASC;
            ELSE
                SELECT rest_emi FROM aggrements WHERE id = @aid;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@aid", agg_id);
                    object val = cmd.ExecuteScalar();
                    if (val != null && val != DBNull.Value) result = Convert.ToDouble(val);
                }
            }
            finally { conn.Close(); }
            return result;
        }
        public bool Update_Reciept_Aggrement_Dues(int dueId, String Date, String Emi_No, Double Reciept_Amount, Double Balance, SqlTransaction trans = null)
        {
            bool result = false;
            if (trans == null && conn.State != ConnectionState.Open) conn.Open();

            // Use the 'id' (Code) for perfect precision in bulk entries
            String query = @"UPDATE aggrement_dues 
                     SET paid_amount=@pamt, emi_no=@eno, paid_date=@pdate, balance=@bal, remarks='Paid via Bulk' 
                     WHERE id=@id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (trans != null) cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@pamt", Reciept_Amount);
                cmd.Parameters.AddWithValue("@eno", Emi_No);
                cmd.Parameters.AddWithValue("@pdate", Date);
                cmd.Parameters.AddWithValue("@bal", Balance);
                cmd.Parameters.AddWithValue("@id", dueId);
                cmd.ExecuteNonQuery();
                result = true;
            }

            if (trans == null) conn.Close();
            return result;
        }
        public bool Update_Reciept_Aggrement_Dues_Old(int Aggrement_Id, String Date, String Emi_No,Double Reciept_Amount,Double Balance)
        {
            bool result = false;
            conn.Open();
            String query = @"UPDATE aggrement_dues SET paid_amount='"+Reciept_Amount+"', emi_no='"+Emi_No+"',paid_date='"+Date+"',balance='"+Balance+"' WHERE DATEADD(MONTH,DATEDIFF(MONTH,0,convert(datetime,emi_date,103)),0)= DATEADD(MONTH,DATEDIFF(MONTH,0,convert(datetime,'"+Date+"',103)),0) and aggrement_id='"+Aggrement_Id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            result = true;
            conn.Close();
            return result;
        }
        public int Get_Valid_Emi_Store_Serial(int store_id,int emi_serial, DateTime date)
        {
            int result = -1;
            conn.Open();
            String query = @"SELECT id FROM emi_vouchers WHERE store_id='" + store_id + "' and Convert(NUMERIC,start_serial) <= " + emi_serial + " and Convert(NUMERIC,end_serial) >=" + emi_serial + "  AND RIGHT(date, 4) = "+date.Year.ToString();
            SqlCommand cmd = new SqlCommand(query, conn);
            Object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj);
            }
            conn.Close();
            return result;
        }
        public int Store_Payment_Voucher(DateTime DATE,int ACCOUNT_ID,String ACCOUNT_NAME,Double VOUCHER_AMOUNT,String REMARKS, String MODE, int purchase_id = -1)
        {
            int result = -1;
            Accounts.Account Mode_Account;
            Accounts.Account Debit_Account = accounts_controller.Get_Account(ACCOUNT_ID);
            if (MODE == "Cash")
            {
                Mode_Account = accounts_controller.Get_Account(2001);
            }
            else
            {
                Mode_Account = accounts_controller.Get_Account(2002);
            }
            accounts_controller.Insert_Account_Transaction(Mode_Account.Account_Id, Mode_Account.Account_Name, Mode_Account.Account_Type, Mode_Account.Account_Nature, "R_V", REMARKS, 0, 0, VOUCHER_AMOUNT, 0, (Mode_Account.Balance - VOUCHER_AMOUNT), DATE);
            if (Debit_Account.Account_Type == "DR")
            {
                accounts_controller.Insert_Account_Transaction(Debit_Account.Account_Id, Debit_Account.Account_Name, Debit_Account.Account_Type, Debit_Account.Account_Nature, "R_V", REMARKS, 0, 0, 0, VOUCHER_AMOUNT, (Debit_Account.Balance + VOUCHER_AMOUNT), DATE);
                result = Store(DATE, 1002, "Payment Voucher", Debit_Account.Account_Id,Mode_Account.Account_Id, Debit_Account.Account_Name,Mode_Account.Account_Name,REMARKS,REMARKS,VOUCHER_AMOUNT,"", purchase_id, "Purchase");
            }
            else
            {
                accounts_controller.Insert_Account_Transaction(Debit_Account.Account_Id, Debit_Account.Account_Name, Debit_Account.Account_Type, Debit_Account.Account_Nature, "R_V", REMARKS, 0, 0, 0, VOUCHER_AMOUNT, (Debit_Account.Balance - VOUCHER_AMOUNT), DATE);
                result = Store(DATE, 1002, "Payment Voucher", Debit_Account.Account_Id, Mode_Account.Account_Id, Debit_Account.Account_Name, Mode_Account.Account_Name, REMARKS, REMARKS, VOUCHER_AMOUNT,"", purchase_id, "Purchase");
            }
            return result;
        }
        public int Store_Reciept_Voucher(DateTime DATE, int ACCOUNT_ID, String ACCOUNT_NAME, Double VOUCHER_AMOUNT,String REMARKS, String MODE,String ref_no,String Item_Name=null,int CASH_VOUCHER_ID=-1,int STORE_ID=-1)
        {
            int result = -1;
            Accounts.Account Mode_Account;
            Accounts.Account Credit_Account=accounts_controller.Get_Account(ACCOUNT_ID);
            if(MODE == "Cash")
            {
                Mode_Account = accounts_controller.Get_Account(2001);
            }
            else
            {
                Mode_Account = accounts_controller.Get_Account(2002);
            }
            if(Credit_Account.Account_Type == "DR")
            {
                if(CASH_VOUCHER_ID != -1)
                {
                    accounts_controller.Insert_Account_Transaction(Mode_Account.Account_Id, Mode_Account.Account_Name, Mode_Account.Account_Type, Mode_Account.Account_Nature, "R_V", REMARKS, 0, 0, VOUCHER_AMOUNT, 0, (Mode_Account.Balance + VOUCHER_AMOUNT), DATE, null, Item_Name, 0, CASH_VOUCHER_ID, STORE_ID);
                    accounts_controller.Insert_Account_Transaction(Credit_Account.Account_Id, Credit_Account.Account_Name, Credit_Account.Account_Type, Credit_Account.Account_Nature, "R_V", REMARKS, 0, 0, 0, VOUCHER_AMOUNT, (Credit_Account.Balance - VOUCHER_AMOUNT), DATE, null, Item_Name, 0, CASH_VOUCHER_ID, STORE_ID);
                }
                else
                {
                    accounts_controller.Insert_Account_Transaction(Mode_Account.Account_Id, Mode_Account.Account_Name, Mode_Account.Account_Type, Mode_Account.Account_Nature, "R_V", REMARKS, 0, 0, VOUCHER_AMOUNT, 0, (Mode_Account.Balance + VOUCHER_AMOUNT), DATE);
                    accounts_controller.Insert_Account_Transaction(Credit_Account.Account_Id, Credit_Account.Account_Name, Credit_Account.Account_Type, Credit_Account.Account_Nature, "R_V", REMARKS, 0, 0, 0, VOUCHER_AMOUNT, (Credit_Account.Balance - VOUCHER_AMOUNT), DATE);
                }
                result = Store(DATE, 1003, "Reciept Voucher", Credit_Account.Account_Id,Mode_Account.Account_Id,Credit_Account.Account_Name,Mode_Account.Account_Name, REMARKS, REMARKS, VOUCHER_AMOUNT,ref_no);
            }
            else
            {
                accounts_controller.Insert_Account_Transaction(Mode_Account.Account_Id, Mode_Account.Account_Name, Mode_Account.Account_Type, Mode_Account.Account_Nature, "R_V", REMARKS, 0, 0, VOUCHER_AMOUNT, 0, (Mode_Account.Balance + VOUCHER_AMOUNT), DATE);
                accounts_controller.Insert_Account_Transaction(Credit_Account.Account_Id, Credit_Account.Account_Name, Credit_Account.Account_Type, Credit_Account.Account_Nature, "R_V", REMARKS, 0, 0, 0, VOUCHER_AMOUNT, (Credit_Account.Balance + VOUCHER_AMOUNT), DATE);
                result = Store(DATE, 1003, "Reciept Voucher", Credit_Account.Account_Id, Mode_Account.Account_Id, Credit_Account.Account_Name, Mode_Account.Account_Name, REMARKS, REMARKS, VOUCHER_AMOUNT,ref_no);
            }
            return result;
        }

        public int Store_Cash_Voucher(String DATE, int STORE_ID, String FIELD_WORKER, String DESCRIPTION, String AREA_NAME, String VEHICLE_NO, Double TOTAL_AMOUNT, Double USED_AMOUNT, Double VOUCHER_BALANCE, int TOTAL_ACCOUNTS, int FINALIZED_ACCOUNTS, int REMAINING_ACCOUNTS, DataTable CASH_VOUCHER_ITEMS_TABLE, DataTable EXP_VOUCHER_ITEMS_TABLE)
        {
            int voucher_id = -1;
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                // 1. Insert Master Record
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO cash_vouchers (date, store_id, field_worker, description, area_name, vehicle_number, total_Amount, used_amount, voucher_balance, total_accounts, finalized_accounts, remaining_accounts) 
                                               VALUES (@date, @store_id, @field_worker, @description, @area_name, @vehicle_number, @total_Amount, @used_amount, @voucher_balance, @total_accounts, @finalized_accounts, @remaining_accounts); 
                                               SELECT CAST(scope_identity() AS int)", conn, trans))
                {
                    cmd.Parameters.AddWithValue("@date", DATE);
                    cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                    cmd.Parameters.AddWithValue("@field_worker", FIELD_WORKER ?? "");
                    cmd.Parameters.AddWithValue("@description", DESCRIPTION ?? "");
                    cmd.Parameters.AddWithValue("@area_name", AREA_NAME ?? "");
                    cmd.Parameters.AddWithValue("@vehicle_number", VEHICLE_NO ?? "");
                    cmd.Parameters.AddWithValue("@total_Amount", TOTAL_AMOUNT);
                    cmd.Parameters.AddWithValue("@used_amount", USED_AMOUNT);
                    cmd.Parameters.AddWithValue("@voucher_balance", VOUCHER_BALANCE);
                    cmd.Parameters.AddWithValue("@total_accounts", TOTAL_ACCOUNTS);
                    cmd.Parameters.AddWithValue("@finalized_accounts", FINALIZED_ACCOUNTS);
                    cmd.Parameters.AddWithValue("@remaining_accounts", REMAINING_ACCOUNTS);

                    voucher_id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2. Save EMI Items (Handling -1 and -2 logic)
                foreach (DataRow row in CASH_VOUCHER_ITEMS_TABLE.Rows)
                {
                    Store_Cash_Voucher_Items(Convert.ToDateTime(row["Date"]), voucher_id, row["Due Date"].ToString(), row["Due Amount"].ToString(), row["Ref.No"].ToString(), Convert.ToInt32(row["EMI #"]), Convert.ToInt32(row["Code"]), Convert.ToInt32(row["Customer Code"]), Convert.ToInt32(row["Item Code"]), Convert.ToDouble(row["Recieved Amt"]), Convert.ToDouble(row["Balance"]), STORE_ID, "Installment Paid", trans);
                }

                // 3. Save Expenses
                foreach (DataRow row in EXP_VOUCHER_ITEMS_TABLE.Rows)
                {
                    Store_Cash_Voucher_Expenses(Convert.ToInt32(row["Code"]), Convert.ToDateTime(DATE), STORE_ID, voucher_id, Convert.ToDouble(row["Amount"]), trans);
                }

                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                XtraMessageBox.Show("Error saving: " + ex.Message);
                return -1;
            }
            finally { conn.Close(); }

            // PHASE 2: External Accounting (Outside transaction to avoid connection errors)
            if (voucher_id > 0)
            {
                foreach (DataRow row in CASH_VOUCHER_ITEMS_TABLE.Rows)
                {
                    double amt = Convert.ToDouble(row["Recieved Amt"]);
                    if (amt > 0)
                    {
                        Store_Reciept_Voucher(Convert.ToDateTime(row["Date"]), Convert.ToInt32(row["Customer Code"]), row["Customer"].ToString(), amt, "Monthly Installment Recovery", "Cash", row["Ref.No"].ToString(), null, voucher_id, STORE_ID);
                    }
                }
            }
            return voucher_id;
        }
        
        public int Store_Cash_Voucher_Old(String DATE,int STORE_ID,String FIELD_WORKER,String DESCRIPTION ,String AREA_NAME,String VEHICLE_NO,Double TOTAL_AMOUNT,Double USED_AMOUNT,Double VOUCHER_BALANCE,int TOTAL_ACCOUNTS,int FINALIZED_ACCOUNTS,int REMAINING_ACCOUNTS,DataTable CASH_VOUCHER_ITEMS_TABLE, DataTable EXP_VOUCHER_ITEMS_TABLE)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO  cash_vouchers(date,store_id,field_worker,description,area_name,vehicle_number,total_Amount,used_amount,voucher_balance,total_accounts,finalized_accounts,remaining_accounts) values(@date,@store_id,@field_worker,@description,@area_name,@vehicle_number,@total_Amount,@used_amount,@voucher_balance,@total_accounts,@finalized_accounts,@remaining_accounts)  SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@date", DATE);
                cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                cmd.Parameters.AddWithValue("@field_worker", FIELD_WORKER);
                cmd.Parameters.AddWithValue("@description", DESCRIPTION);
                cmd.Parameters.AddWithValue("@area_name",AREA_NAME);
                cmd.Parameters.AddWithValue("@vehicle_number", VEHICLE_NO);
                cmd.Parameters.AddWithValue("@total_Amount", TOTAL_AMOUNT);
                if(USED_AMOUNT > 0)
                {
                    cmd.Parameters.AddWithValue("@used_amount", USED_AMOUNT);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@used_amount", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@voucher_balance", VOUCHER_BALANCE);
                if(TOTAL_ACCOUNTS > 0)
                {
                    cmd.Parameters.AddWithValue("@total_accounts", TOTAL_ACCOUNTS);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@total_accounts", DBNull.Value);
                }
                if(FINALIZED_ACCOUNTS > 0)
                {
                    cmd.Parameters.AddWithValue("@finalized_accounts", FINALIZED_ACCOUNTS);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@finalized_accounts", DBNull.Value);
                }
                if(REMAINING_ACCOUNTS > 0)
                {
                    cmd.Parameters.AddWithValue("@remaining_accounts", REMAINING_ACCOUNTS);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@remaining_accounts", DBNull.Value);
                }

                object obj = cmd.ExecuteScalar();
                conn.Close();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                    for (int i=0;i < CASH_VOUCHER_ITEMS_TABLE.Rows.Count; i++)
                    {
                        Store_Cash_Voucher_Items(Convert.ToDateTime(Convert.ToString(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["Date"])), result, Convert.ToString(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["Due Date"]), Convert.ToString(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["Due Amount"]), Convert.ToString(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["Ref.No"]), Convert.ToInt32(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["EMI #"]), Convert.ToInt32(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["Code"]), Convert.ToInt32(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["Customer Code"]),Convert.ToInt32(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["Item Code"]),Convert.ToDouble(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["Recieved Amt"]),Convert.ToDouble(CASH_VOUCHER_ITEMS_TABLE.Rows[i]["Balance"]),STORE_ID, "Installment Paid");
                    }
                    if(EXP_VOUCHER_ITEMS_TABLE.Rows.Count > 0)
                    {
                        for(int i = 0; i < EXP_VOUCHER_ITEMS_TABLE.Rows.Count; i++)
                        {
                            Store_Cash_Voucher_Expenses(Convert.ToInt32(EXP_VOUCHER_ITEMS_TABLE.Rows[i]["Code"]),Convert.ToDateTime(DATE),STORE_ID,result,Convert.ToDouble(EXP_VOUCHER_ITEMS_TABLE.Rows[i]["Amount"]));
                        }
                    }
                }
            }
            return result;
        }
        public int Store_Cash_Voucher_Items(DateTime DATE, int CASH_VOUCHER_ID, string DUE_DATE, string DUE_AMOUNT, string REF_NO, int EMI_VOUCHER_ID, int DUE_ID, int CUSTOMER_ID, int ITEM_ID, double RECIEVED_AMOUNT, double BALANCE, int STORE_ID, String REMARKS, SqlTransaction trans = null)
        {
            int result = -1;
            if (trans == null && conn.State != ConnectionState.Open) conn.Open();

            // 1. Sync Installment Record (aggrement_dues)
            if (DUE_ID < 0) // New Insert for -1 or -2
            {
                Aggrements.Aggrement agg = aggrements_controller.Get_Aggrement_By_Ref_No(REF_NO);
                string ins = @"INSERT INTO aggrement_dues (aggrement_id, ref_no, emi_no, emi_date, emi_amount, paid_amount, paid_date, balance, remarks, is_return_fixed) 
                       VALUES (@aid, @ref, @eno, @edate, @eamt, @pamt, @pdate, @bal, @rem, @flag); SELECT CAST(scope_identity() AS int)";
                using (SqlCommand cmd = new SqlCommand(ins, conn))
                {
                    if (trans != null) cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@aid", agg.Aggrement_Id);
                    cmd.Parameters.AddWithValue("@ref", REF_NO);
                    cmd.Parameters.AddWithValue("@eno", EMI_VOUCHER_ID);
                    cmd.Parameters.AddWithValue("@edate", DUE_DATE);
                    cmd.Parameters.AddWithValue("@eamt", DUE_AMOUNT);
                    cmd.Parameters.AddWithValue("@pamt", RECIEVED_AMOUNT);
                    cmd.Parameters.AddWithValue("@pdate", RECIEVED_AMOUNT > 0 ? DATE.ToString("dd-MM-yyyy") : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@bal", BALANCE);
                    cmd.Parameters.AddWithValue("@rem", REMARKS);
                    cmd.Parameters.AddWithValue("@flag", DUE_ID);
                    DUE_ID = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            else // Existing Update
            {
                string upd = "UPDATE aggrement_dues SET paid_amount=@pamt, emi_no=@eno, paid_date=@pdate, balance=@bal, remarks=@rem WHERE id=@id";
                using (SqlCommand cmd = new SqlCommand(upd, conn))
                {
                    if (trans != null) cmd.Transaction = trans;
                    cmd.Parameters.AddWithValue("@pamt", RECIEVED_AMOUNT);
                    cmd.Parameters.AddWithValue("@eno", EMI_VOUCHER_ID);
                    cmd.Parameters.AddWithValue("@pdate", DATE.ToString("dd-MM-yyyy"));
                    cmd.Parameters.AddWithValue("@bal", BALANCE);
                    cmd.Parameters.AddWithValue("@rem", REMARKS);
                    cmd.Parameters.AddWithValue("@id", DUE_ID);
                    cmd.ExecuteNonQuery();
                }
            }

            // 2. Insert Audit Entry (cash_voucher_items)
            string query = @"INSERT INTO cash_voucher_items (date, emi_voucher_id, store_id, cash_voucher_id, customer_id, item_id, RECIEVED_AMOUNT, BALANCE, ref_no, due_date, due_amount, remarks) 
                     VALUES (@date, @emi, @sid, @cvid, @cid, @iid, @ramt, @bal, @ref, @ddate, @damt, @rem)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (trans != null) cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@date", DATE.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@emi", EMI_VOUCHER_ID);
                cmd.Parameters.AddWithValue("@cvid", CASH_VOUCHER_ID);
                cmd.Parameters.AddWithValue("@sid", STORE_ID);
                cmd.Parameters.AddWithValue("@cid", CUSTOMER_ID);
                cmd.Parameters.AddWithValue("@iid", ITEM_ID <= 0 ? (object)DBNull.Value : ITEM_ID);
                cmd.Parameters.AddWithValue("@ramt", RECIEVED_AMOUNT);
                cmd.Parameters.AddWithValue("@bal", BALANCE);
                cmd.Parameters.AddWithValue("@ref", REF_NO);
                cmd.Parameters.AddWithValue("@ddate", DUE_DATE);
                cmd.Parameters.AddWithValue("@damt", DUE_AMOUNT);
                cmd.Parameters.AddWithValue("@rem", REMARKS);
                cmd.ExecuteNonQuery();
            }

            // 3. Update Agreement Balance Helper
            aggrements_controller.Update_Aggrement_Current_Balance_New(REF_NO, BALANCE, trans);

            if (trans == null) conn.Close();
            return 1;
        }
        public int Store_Cash_Voucher_Items_Old(DateTime DATE, int CASH_VOUCHER_ID, string DUE_DATE, string DUE_AMOUNT, string REF_NO, int EMI_VOUCHER_ID, int DUE_ID, int CUSTOMER_ID, int ITEM_ID, double RECIEVED_AMOUNT, double BALANCE, int STORE_ID, String REMARKS)
        {
            int result = -1;
            conn.Open();
            // Corrected Query with due_date and due_amount
            using (SqlCommand cmd = new SqlCommand(@"INSERT INTO cash_voucher_items
           (date, emi_voucher_id, store_id,cash_voucher_id, customer_id, item_id, RECIEVED_AMOUNT, BALANCE, ref_no, due_date, due_amount, remarks) 
           VALUES (@date, @emi_voucher_id, @store_id, @cash_voucher_id, @customer_id, @item_id, @RECIEVED_AMOUNT, @BALANCE, @ref_no, @due_date, @due_amount, @remarks) 
           SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@date", DATE.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@emi_voucher_id", EMI_VOUCHER_ID);
                cmd.Parameters.AddWithValue("@cash_voucher_id", CASH_VOUCHER_ID);
                cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                cmd.Parameters.AddWithValue("@customer_id", CUSTOMER_ID);

                // Handle Multiple Items (Item ID 0) as NULL in DB
                cmd.Parameters.AddWithValue("@item_id", ITEM_ID <= 0 ? (object)DBNull.Value : ITEM_ID);

                cmd.Parameters.AddWithValue("@RECIEVED_AMOUNT", RECIEVED_AMOUNT);
                cmd.Parameters.AddWithValue("@BALANCE", BALANCE);
                cmd.Parameters.AddWithValue("@ref_no", REF_NO);
                cmd.Parameters.AddWithValue("@due_date", (object)DUE_DATE ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@due_amount", (object)DUE_AMOUNT ?? 0);
                if(REMARKS != null || REMARKS != "")
                {
                    cmd.Parameters.AddWithValue("@remarks", REMARKS);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@remarks", DBNull.Value);
                }

                // 2. Update aggrement_dues (Marking as paid)
                string dueSql = "UPDATE aggrement_dues SET paid_amount=@pamt, emi_no=@eno, paid_date=@pdate, balance=@bal, remarks=@rem WHERE id=@id";
                using (SqlCommand cmdDue = new SqlCommand(dueSql, conn))
                {
                    if (RECIEVED_AMOUNT > 0)
                        cmdDue.Parameters.AddWithValue("@pamt", RECIEVED_AMOUNT);
                    else
                        cmdDue.Parameters.AddWithValue("@pamt", DBNull.Value);
                    cmdDue.Parameters.AddWithValue("@eno", EMI_VOUCHER_ID);
                    cmdDue.Parameters.AddWithValue("@pdate", DATE.ToString("dd-MM-yyyy"));
                    cmdDue.Parameters.AddWithValue("@bal", BALANCE);
                    cmdDue.Parameters.AddWithValue("@id", DUE_ID);
                    cmdDue.Parameters.AddWithValue("@rem", REMARKS);
                    cmdDue.ExecuteNonQuery();
                }

                object obj = cmd.ExecuteScalar();
                conn.Close();
                if (obj != null && obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);

                    // 1. Create the Receipt Voucher for Accounting
                    string itemName = ITEM_ID <= 0 ? "Multiple Items" : "Installment Recovery";
                    Store_Reciept_Voucher(DATE, CUSTOMER_ID, accounts_controller.Get_Account_Name(CUSTOMER_ID), RECIEVED_AMOUNT, "Monthly Installment Recovery", "Cash", REF_NO, itemName, CASH_VOUCHER_ID, STORE_ID);

                    // 2. Update Agreement Current Balance
                    aggrement = aggrements_controller.Get_Aggrement_By_Ref_No(REF_NO);
                    if (aggrement.Aggrement_Id > 0)
                    {
                        double updated_balance = (aggrement.Current_Balance - RECIEVED_AMOUNT);
                        aggrements_controller.Update_Aggrement_Current_Balance(REF_NO, updated_balance);

                        // 3. Mark the due as paid
                        Update_Reciept_Aggrement_Dues(aggrement.Aggrement_Id, DATE.ToString("dd-MM-yyyy"), EMI_VOUCHER_ID.ToString(), RECIEVED_AMOUNT, updated_balance);
                    }
                }
            }
            return result;
        }

        public int Store_Receipts_Table(DataTable receiptsTable, DataTable DeletedReceiptsTable, string refNo, int storeId, int customerId, int itemId, int currentReceiptIndex)
        {
            int lastId = -1;
            bool leasingDataSaved = false;
            double finalAgreementBalance = 0;

            // 0. Fetch Agreement ID
            Aggrements.Aggrement aggObj = aggrements_controller.Get_Aggrement_By_Ref_No(refNo);
            int agg_id = aggObj.Aggrement_Id;

            for(int i=0; i <= currentReceiptIndex; i++)
            {
                DataRow row = receiptsTable.Rows[i];
                int dueId = Convert.ToInt32(row["Code"]);
                
                DateTime dueDate = Convert.ToDateTime(row["Due Date"]);
                double dueAmount = Convert.ToDouble(row["Due Amount"]);
                DateTime recDate = Convert.ToDateTime(row["Receipt Date"]);
                string recStatus = (row["Status"] == DBNull.Value) ? "Normal" : row["Status"].ToString();
                string remarks = row["Remarks"].ToString();
                int isReturnFixed = row["Is Return Fixed"] == DBNull.Value ? -1 : Convert.ToInt32(row["Is Return Fixed"]);
                int emiNo = (!string.IsNullOrEmpty(row["EMI No"].ToString())) ? Convert.ToInt32(row["EMI No"].ToString()) : -1;
                Update_Dues_EMI(storeId, dueId, dueDate, dueAmount, recStatus, recDate, emiNo, remarks);
            }

            if (agg_id <= 0) return -1;

            // --- PHASE 1: LEASING DATA UPDATES (Transactional) ---
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                //Delete Selected Receipts Rows
                foreach (DataRow row in DeletedReceiptsTable.Rows)
                {
                    int dueId = Convert.ToInt32(row["Code"]);
                    string insDueSql = @"DELETE FROM aggrement_dues WHERE id = @dueId";

                    using (SqlCommand cmdIns = new SqlCommand(insDueSql, conn, trans))
                    {
                        cmdIns.Parameters.AddWithValue("@dueId", dueId); 
                        cmdIns.ExecuteNonQuery();
                    }

                    //string DelCashVocuherItem = @"DELETE FROM cash_voucher_items WHERE store_id = @storeId AND customer_id = @custId AND ref_no = @refNo";

                    //using (SqlCommand cmdDelVoucher = new SqlCommand(DelCashVocuherItem, conn, trans))
                    //{
                    //    cmdDelVoucher.Parameters.AddWithValue("@refNo", refNo);
                    //    cmdDelVoucher.Parameters.AddWithValue("@custId", customerId);
                    //    cmdDelVoucher.Parameters.AddWithValue("@storeId", storeId);
                    //    cmdDelVoucher.ExecuteNonQuery();
                    //}

                }                
                
                int rowIndex = 0;
                foreach (DataRow row in receiptsTable.Rows)
                {
                    int dueId = Convert.ToInt32(row["Code"]);
                    string srNo = row["Sr.No"].ToString();
                    double receivedAmt = 0;
                    double.TryParse(row["Received Amount"]?.ToString(), out receivedAmt);

                    string recDate = row["Receipt Date"].ToString();
                    string recStatus = (row["Status"] == DBNull.Value) ? "Normal" : row["Status"].ToString();
                    string remarks = row["Remarks"] == DBNull.Value ? "" : row["Remarks"].ToString();
                    int isReturnFixed = row["Is Return Fixed"] == DBNull.Value ? -1 : Convert.ToInt32(row["Is Return Fixed"]);
                    int emiNo = (!string.IsNullOrEmpty(row["EMI No"]?.ToString())) ? Convert.ToInt32(row["EMI No"]) : -1;
                    string emiNoStr = row["EMI No"]?.ToString();
                    double currentBalance = row["Balance"] == DBNull.Value ? 0 : Convert.ToDouble(row["Balance"]);
                    double dueAmount = Convert.ToDouble(row["Due Amount"]);
                    string dueDate = row["Due Date"].ToString();
                    // Track the most recent calculated balance for the agreement header
                    if (row["Balance"] != DBNull.Value) finalAgreementBalance = currentBalance;

                    // --- STEP 1: MANAGE INSTALLMENT RECORDS (aggrement_dues) ---

                    //// Logic for NEW rows (Auto-added bottom rows -1 OR Partial split rows -2)
                    //if(rowIndex <= currentReceiptIndex)
                    //{
                    //    string dueSql = "UPDATE aggrement_dues SET status=@status, remarks=@rem WHERE id=@id";
                    //    using (SqlCommand cmdDue = new SqlCommand(dueSql, conn, trans))
                    //    {

                    //        cmdDue.Parameters.AddWithValue("@eno", emiNoStr);
                    //        cmdDue.Parameters.AddWithValue("@status", recStatus);
                    //        cmdDue.Parameters.AddWithValue("@rem", remarks);
                    //        cmdDue.Parameters.AddWithValue("@id", dueId);
                            
                    //        cmdDue.ExecuteNonQuery();
                    //    }
                    //}
                    //else 
                    if (dueId < 0)
                    {
                        // We use the dueId value (-1 or -2) to populate 'is_return_fixed' 
                        // This preserves your logic in the database for tracking.
                        string insDueSql = @"INSERT INTO aggrement_dues 
                    (aggrement_id, ref_no, status, emi_no, emi_date, emi_amount, paid_amount, paid_date, balance, remarks, is_return_fixed) 
                    VALUES (@aid, @ref, @status, @eno, @edate, @eamt, @pamt, @pdate, @bal, @rem, @flag);
                    SELECT CAST(scope_identity() AS int)";

                        using (SqlCommand cmdIns = new SqlCommand(insDueSql, conn, trans))
                        {
                            cmdIns.Parameters.AddWithValue("@aid", agg_id);
                            cmdIns.Parameters.AddWithValue("@ref", refNo);
                            if (receivedAmt > 0)
                            {
                                cmdIns.Parameters.AddWithValue("@pamt", receivedAmt);
                                cmdIns.Parameters.AddWithValue("@bal", currentBalance);
                                cmdIns.Parameters.AddWithValue("@pdate", recDate);
                            }
                            else
                            {
                                cmdIns.Parameters.AddWithValue("@pamt", DBNull.Value);
                                cmdIns.Parameters.AddWithValue("@bal", DBNull.Value);
                                cmdIns.Parameters.AddWithValue("@pdate",DBNull.Value);
                            }
                            if(emiNo > 0)
                            {

                                cmdIns.Parameters.AddWithValue("@eno", emiNoStr);
                            }
                            else
                            {

                                cmdIns.Parameters.AddWithValue("@eno", DBNull.Value);
                            }
                                cmdIns.Parameters.AddWithValue("@edate", dueDate);
                            cmdIns.Parameters.AddWithValue("@eamt", dueAmount);
                            cmdIns.Parameters.AddWithValue("@rem", remarks);
                            cmdIns.Parameters.AddWithValue("@status", recStatus);
                            cmdIns.Parameters.AddWithValue("@flag", dueId); // Saves -1 or -2

                            // Update dueId for this loop so the cash_voucher_items can link to a real ID
                            dueId = Convert.ToInt32(cmdIns.ExecuteScalar());
                        }
                    }
                    // Logic for EXISTING rows (dueId > 0)
                    else
                    {
                        string dueSql = "UPDATE aggrement_dues SET emi_date=@ddate, emi_amount=@damt, status=@status, paid_amount=@pamt, emi_no=@eno, paid_date=@pdate, balance=@bal, remarks=@rem WHERE id=@id";
                        using (SqlCommand cmdDue = new SqlCommand(dueSql, conn, trans))
                        {


                            if (emiNo > 0)
                            {

                                cmdDue.Parameters.AddWithValue("@eno", emiNoStr);
                            }
                            else
                            {

                                cmdDue.Parameters.AddWithValue("@eno", DBNull.Value);
                            }
                            cmdDue.Parameters.AddWithValue("@pdate", recDate);
                            cmdDue.Parameters.AddWithValue("@status", recStatus);
                            cmdDue.Parameters.AddWithValue("@rem", remarks);
                            cmdDue.Parameters.AddWithValue("@id", dueId);
                            cmdDue.Parameters.AddWithValue("@ddate", dueDate);
                            cmdDue.Parameters.AddWithValue("@damt", dueAmount);
                            if (receivedAmt > 0)
                            {
                                cmdDue.Parameters.AddWithValue("@pamt", receivedAmt);
                                cmdDue.Parameters.AddWithValue("@bal", currentBalance);
                            }
                            else
                            {
                                if (isReturnFixed == 1)
                                {
                                    cmdDue.Parameters.AddWithValue("@pamt", "0");
                                    cmdDue.Parameters.AddWithValue("@bal", currentBalance);
                                }
                                else
                                {
                                    cmdDue.Parameters.AddWithValue("@pamt", DBNull.Value);
                                    cmdDue.Parameters.AddWithValue("@bal", DBNull.Value);
                                }
                            }
                            cmdDue.ExecuteNonQuery();
                        }
                    }

                    // --- STEP 2: AUDIT TRAIL (cash_voucher_items) ---
                    // Only create an audit record if actual cash was collected in this row
                    if (receivedAmt > 0)
                    {
                        string query = @"INSERT INTO cash_voucher_items
                    (date, emi_voucher_id, store_id, cash_voucher_id, customer_id, item_id, RECIEVED_AMOUNT, BALANCE, ref_no, due_date, due_amount, remarks) 
                    VALUES (@date, @emi, @sid, -1, @cid, @iid, @ramt, @bal, @ref, @ddate, @damt, @rem);
                    SELECT CAST(scope_identity() AS int)";

                        using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@date", recDate);
                            cmd.Parameters.AddWithValue("@emi", string.IsNullOrEmpty(emiNoStr) ? -1 : emiNo);
                            cmd.Parameters.AddWithValue("@sid", storeId);
                            cmd.Parameters.AddWithValue("@cid", customerId);
                            cmd.Parameters.AddWithValue("@iid", itemId <= 0 ? (object)DBNull.Value : itemId);
                            cmd.Parameters.AddWithValue("@ramt", receivedAmt);
                            cmd.Parameters.AddWithValue("@bal", currentBalance);
                            cmd.Parameters.AddWithValue("@ref", refNo);
                            cmd.Parameters.AddWithValue("@ddate", dueDate);
                            cmd.Parameters.AddWithValue("@damt", dueAmount);
                            cmd.Parameters.AddWithValue("@rem", "Bulk Entry: " + remarks);
                            lastId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    rowIndex++;

                }

                // --- STEP 3: UPDATE AGREEMENT TOTAL BALANCE ---
                string status = "In-Progress";
                if(finalAgreementBalance <= 0)
                {
                    status = "Completed";
                    
                    
                }
                string aggSql = "UPDATE aggrements SET current_balance = @bal, status = @status WHERE ref_no = @ref";
                using (SqlCommand cmdAgg = new SqlCommand(aggSql, conn, trans))
                {
                    cmdAgg.Parameters.AddWithValue("@bal", finalAgreementBalance);
                    cmdAgg.Parameters.AddWithValue("@status", status);
                    cmdAgg.Parameters.AddWithValue("@ref", refNo);
                    cmdAgg.ExecuteNonQuery();
                }

                trans.Commit();
                leasingDataSaved = true;
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                XtraMessageBox.Show("Leasing Save Error: " + ex.Message);
                return -1;
            }
            finally { conn.Close(); }

            // --- PHASE 2: ACCOUNTING ENTRIES (Outside Transaction) ---
            if (leasingDataSaved)
            {
                foreach (DataRow row in receiptsTable.Rows)
                {
                    double amt = 0; double.TryParse(row["Received Amount"]?.ToString(), out amt);
                    if (amt <= 0) continue;

                    DateTime rDate = Convert.ToDateTime(row["Receipt Date"]);
                    string custName = accounts_controller.Get_Account_Name(customerId);

                    // This method opens its own connection and handles its own logic
                    Store_Reciept_Voucher(rDate, customerId, custName, amt, "Bulk Recovery", "Cash", refNo);
                }
            }

            return 1; // Success
        }
        public int Store_Receipts_Table_LD(DataTable receiptsTable, string refNo, int storeId, int customerId, int itemId)
        {
            int lastId = -1;
            bool leasingDataSaved = false;
            double finalAgreementBalance = 0;
            int agg_id = -1;

            // 0. Fetch the internal Numeric ID of the agreement using the RefNo
            // We need this for the INSERT into aggrement_dues if dueId is -1
            Aggrements.Aggrement aggObj = aggrements_controller.Get_Aggrement_By_Ref_No(refNo);
            agg_id = aggObj.Aggrement_Id;

            if (agg_id <= 0)
            {
                XtraMessageBox.Show("Could not find internal Agreement ID for Ref: " + refNo);
                return -1;
            }

            // --- PHASE 1: LEASING DATA UPDATES (Transactional) ---
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                foreach (DataRow row in receiptsTable.Rows)
                {
                    int dueId = Convert.ToInt32(row["Code"]);
                    double receivedAmt = 0;
                    double.TryParse(row["Recieved Amount"]?.ToString(), out receivedAmt);

                    string recDate = row["Reciept Date"].ToString();
                    string remarks = row["Remarks"].ToString();
                    string emiNoStr = row["EMI #"]?.ToString();
                    double currentBalance = row["Balance"] == DBNull.Value ? 0 :Convert.ToDouble(row["Balance"]);
                    double dueAmount = Convert.ToDouble(row["Due Amount"]);
                    string dueDate = row["Due Date"].ToString();

                    finalAgreementBalance = row["Balance"] == DBNull.Value ? finalAgreementBalance : currentBalance; // Track the most recent balance for the header update

                    // 1. IF NEW ROW (dueId == -1): Create the installment in the database
                    if (dueId == -1)
                    {
                        string insDueSql = @"INSERT INTO aggrement_dues 
                    (aggrement_id, ref_no, emi_no, emi_date, emi_amount, paid_amount, paid_date, balance, remarks, is_return_fixed) 
                    VALUES (@aid, @ref, @eno, @edate, @eamt, @pamt, @pdate, @bal, @rem, -1);
                    SELECT CAST(scope_identity() AS int)";

                        using (SqlCommand cmdIns = new SqlCommand(insDueSql, conn, trans))
                        {
                            cmdIns.Parameters.AddWithValue("@aid", agg_id);
                            cmdIns.Parameters.AddWithValue("@ref", refNo);
                            cmdIns.Parameters.AddWithValue("@eno", string.IsNullOrEmpty(emiNoStr) ? (object)DBNull.Value : emiNoStr);
                            cmdIns.Parameters.AddWithValue("@edate", dueDate);
                            cmdIns.Parameters.AddWithValue("@eamt", dueAmount);
                            cmdIns.Parameters.AddWithValue("@pamt", receivedAmt > 0 ? receivedAmt : 0);
                            cmdIns.Parameters.AddWithValue("@pdate", receivedAmt > 0 ? recDate : (object)DBNull.Value);
                            cmdIns.Parameters.AddWithValue("@bal", currentBalance);
                            cmdIns.Parameters.AddWithValue("@rem", remarks);

                            // Update dueId for the rest of this loop iteration so cash_voucher_items can link to it
                            dueId = Convert.ToInt32(cmdIns.ExecuteScalar());
                        }
                    }
                    // 2. IF EXISTING ROW (dueId > 0): Update if money was paid
                    else if (receivedAmt > 0)
                    {
                        string dueSql = "UPDATE aggrement_dues SET paid_amount=@pamt, emi_no=@eno, paid_date=@pdate, balance=@bal, remarks=@rem WHERE id=@id";
                        using (SqlCommand cmdDue = new SqlCommand(dueSql, conn, trans))
                        {
                            cmdDue.Parameters.AddWithValue("@pamt", receivedAmt);
                            cmdDue.Parameters.AddWithValue("@eno", emiNoStr);
                            cmdDue.Parameters.AddWithValue("@pdate", recDate);
                            cmdDue.Parameters.AddWithValue("@bal", currentBalance);
                            cmdDue.Parameters.AddWithValue("@rem", remarks);
                            cmdDue.Parameters.AddWithValue("@id", dueId);
                            cmdDue.ExecuteNonQuery();
                        }
                    }

                    // 3. Create Audit Trail Entry in cash_voucher_items (ONLY IF MONEY WAS PAID)
                    if (receivedAmt > 0)
                    {
                        string query = @"INSERT INTO cash_voucher_items
                    (date, emi_voucher_id, store_id, cash_voucher_id, customer_id, item_id, RECIEVED_AMOUNT, BALANCE, ref_no, due_date, due_amount, remarks) 
                    VALUES (@date, @emi, @sid, -1, @cid, @iid, @ramt, @bal, @ref, @ddate, @damt, @rem);
                    SELECT CAST(scope_identity() AS int)";

                        using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@date", recDate);
                            cmd.Parameters.AddWithValue("@emi", string.IsNullOrEmpty(emiNoStr) ? 0 : Convert.ToInt32(emiNoStr));
                            cmd.Parameters.AddWithValue("@sid", storeId);
                            cmd.Parameters.AddWithValue("@cid", customerId);
                            cmd.Parameters.AddWithValue("@iid", itemId <= 0 ? (object)DBNull.Value : itemId);
                            cmd.Parameters.AddWithValue("@ramt", receivedAmt);
                            cmd.Parameters.AddWithValue("@bal", currentBalance);
                            cmd.Parameters.AddWithValue("@ref", refNo);
                            cmd.Parameters.AddWithValue("@ddate", dueDate);
                            cmd.Parameters.AddWithValue("@damt", dueAmount);
                            cmd.Parameters.AddWithValue("@rem", "Bulk Entry: " + remarks);
                            lastId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                }

                // 4. Update the Main Agreement Header Balance
                string aggSql = "UPDATE aggrements SET current_balance = @bal WHERE ref_no = @ref";
                using (SqlCommand cmdAgg = new SqlCommand(aggSql, conn, trans))
                {
                    cmdAgg.Parameters.AddWithValue("@bal", finalAgreementBalance);
                    cmdAgg.Parameters.AddWithValue("@ref", refNo);
                    cmdAgg.ExecuteNonQuery();
                }

                trans.Commit();
                leasingDataSaved = true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                XtraMessageBox.Show("Leasing Data Error: " + ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }

            // --- PHASE 2: ACCOUNTING ENTRIES (Outside the transaction) ---
            if (leasingDataSaved)
            {
                try
                {
                    foreach (DataRow row in receiptsTable.Rows)
                    {
                        double receivedAmt = 0;
                        double.TryParse(row["Recieved Amount"]?.ToString(), out receivedAmt);
                        if (receivedAmt <= 0) continue;

                        DateTime rDate = Convert.ToDateTime(row["Reciept Date"]);
                        string custName = accounts_controller.Get_Account_Name(customerId);

                        // Call your existing method which handles its own conn.Open/Close
                        Store_Reciept_Voucher(rDate, customerId, custName, receivedAmt, "Monthly Recovery (Bulk)", "Cash", refNo);
                    }
                    //XtraMessageBox.Show("All receipts and accounting entries processed successfully!", "Success");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Accounting Error (Leasing data was saved, but vouchers failed): " + ex.Message);
                }
            }

            return lastId;
        }

        public int Store_Receipts_Table_Old(DataTable receiptsTable, string refNo, int storeId, int customerId, int itemId)
        {
            int lastId = -1;
            bool leasingDataSaved = false;
            double finalAgreementBalance = 0;

            // --- PHASE 1: LEASING DATA UPDATES (Transactional) ---
            if (conn.State != ConnectionState.Open) conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                foreach (DataRow row in receiptsTable.Rows)
                {
                    double receivedAmt = 0;
                    double.TryParse(row["Recieved Amount"]?.ToString(), out receivedAmt);
                    if (receivedAmt <= 0)
                    { 
                        continue; 
                    }

                    int dueId = Convert.ToInt32(row["Code"]);
                    string recDate = row["Reciept Date"].ToString();
                    string remarks = row["Remarks"].ToString();
                    int emiNo = Convert.ToInt32(row["EMI #"]);
                    double currentBalance = Convert.ToDouble(row["Balance"]);
                    finalAgreementBalance = currentBalance; // Keep track of the very last balance

                    // 1. Insert into cash_voucher_items
                    string query = @"INSERT INTO cash_voucher_items
                (date, emi_voucher_id, store_id, cash_voucher_id, customer_id, item_id, RECIEVED_AMOUNT, BALANCE, ref_no, due_date, due_amount, remarks) 
                VALUES (@date, @emi, @sid, -1, @cid, @iid, @ramt, @bal, @ref, @ddate, @damt, 'Bulk Entry');
                SELECT CAST(scope_identity() AS int)";

                    using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@date", recDate);
                        cmd.Parameters.AddWithValue("@emi", emiNo);
                        cmd.Parameters.AddWithValue("@sid", storeId);
                        cmd.Parameters.AddWithValue("@cid", customerId);
                        cmd.Parameters.AddWithValue("@iid", itemId <= 0 ? (object)DBNull.Value : itemId);
                        cmd.Parameters.AddWithValue("@ramt", receivedAmt);
                        cmd.Parameters.AddWithValue("@bal", currentBalance);
                        cmd.Parameters.AddWithValue("@ref", refNo);
                        cmd.Parameters.AddWithValue("@ddate", row["Due Date"].ToString());
                        cmd.Parameters.AddWithValue("@damt", row["Due Amount"].ToString());
                        lastId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2. Update aggrement_dues (Marking as paid)
                    string dueSql = "UPDATE aggrement_dues SET paid_amount=@pamt, emi_no=@eno, paid_date=@pdate, balance=@bal, remarks=@rem WHERE id=@id";
                    using (SqlCommand cmdDue = new SqlCommand(dueSql, conn, trans))
                    {
                        if(receivedAmt > 0)
                            cmdDue.Parameters.AddWithValue("@pamt", receivedAmt);
                        else
                            cmdDue.Parameters.AddWithValue("@pamt", DBNull.Value);
                        cmdDue.Parameters.AddWithValue("@eno", emiNo);
                        cmdDue.Parameters.AddWithValue("@pdate", recDate);
                        cmdDue.Parameters.AddWithValue("@bal", currentBalance);
                        cmdDue.Parameters.AddWithValue("@id", dueId);
                        cmdDue.Parameters.AddWithValue("@rem", remarks);
                        cmdDue.ExecuteNonQuery();
                    }
                }

                // 3. Update the Main Agreement Balance
                string aggSql = "UPDATE aggrements SET current_balance = @bal WHERE ref_no = @ref";
                using (SqlCommand cmdAgg = new SqlCommand(aggSql, conn, trans))
                {
                    cmdAgg.Parameters.AddWithValue("@bal", finalAgreementBalance);
                    cmdAgg.Parameters.AddWithValue("@ref", refNo);
                    cmdAgg.ExecuteNonQuery();
                }

                trans.Commit();
                leasingDataSaved = true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                XtraMessageBox.Show("Leasing Data Error: " + ex.Message);
                return -1;
            }
            finally
            {
                conn.Close(); // IMPORTANT: Close connection before Phase 2
            }

            // --- PHASE 2: ACCOUNTING ENTRIES (Outside the transaction) ---
            if (leasingDataSaved)
            {
                try
                {
                    foreach (DataRow row in receiptsTable.Rows)
                    {
                        double receivedAmt = 0;
                        double.TryParse(row["Recieved Amount"]?.ToString(), out receivedAmt);
                        if (receivedAmt <= 0) continue;

                        DateTime rDate = Convert.ToDateTime(row["Reciept Date"]);
                        string custName = accounts_controller.Get_Account_Name(customerId);

                        // Call your existing method which handles its own conn.Open/Close
                        Store_Reciept_Voucher(rDate, customerId, custName, receivedAmt, "Monthly Recovery (Bulk)", "Cash", refNo);
                    }
                    //XtraMessageBox.Show("All receipts and accounting entries processed successfully!", "Success");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Accounting Error (Leasing data was saved, but vouchers failed): " + ex.Message);
                }
            }

            return lastId;
        }

        public int Store_Receipts_Table_Old(DataTable receipts_table, String RefNo, int Store_ID)
        {
            int result = -1;
            for (int i = 0; i < receipts_table.Rows.Count; i++)
            {

                conn.Open();
                // Corrected Query with due_date and due_amount
                using (SqlCommand cmd = new SqlCommand(@"INSERT INTO cash_voucher_items
           (date, emi_voucher_id, store_id,cash_voucher_id, customer_id, item_id, RECIEVED_AMOUNT, BALANCE, ref_no, due_date, due_amount, remarks) 
           VALUES (@date, @emi_voucher_id, @store_id, @cash_voucher_id, @customer_id, @item_id, @RECIEVED_AMOUNT, @BALANCE, @ref_no, @due_date, @due_amount, @remarks) 
           SELECT CAST(scope_identity() AS int)", conn))
                {
                    cmd.Parameters.AddWithValue("@date", receipts_table.Rows[i]["Date"].ToString());
                    cmd.Parameters.AddWithValue("@emi_voucher_id", Convert.ToInt32(receipts_table.Rows[i]["EMI #"]));
                    cmd.Parameters.AddWithValue("@cash_voucher_id", -1);
                    cmd.Parameters.AddWithValue("@store_id", Store_ID);
                    cmd.Parameters.AddWithValue("@customer_id", Convert.ToInt32(receipts_table.Rows[i]["Customer Code"]));

                    // Handle Multiple Items (Item ID 0) as NULL in DB
                    cmd.Parameters.AddWithValue("@item_id", Convert.ToInt32(receipts_table.Rows[i]["Item Code"]));

                    cmd.Parameters.AddWithValue("@RECIEVED_AMOUNT", Convert.ToDouble(receipts_table.Rows[i]["Recieved Amt"]));
                    cmd.Parameters.AddWithValue("@BALANCE", Convert.ToDouble(receipts_table.Rows[i]["Balance"]));
                    cmd.Parameters.AddWithValue("@ref_no", Convert.ToString(receipts_table.Rows[i]["Ref.No"]));
                    cmd.Parameters.AddWithValue("@due_date", Convert.ToString(receipts_table.Rows[i]["Due Date"]));
                    cmd.Parameters.AddWithValue("@due_amount", Convert.ToString(receipts_table.Rows[i]["Due Amount"]));
                    cmd.Parameters.AddWithValue("@remarks", Convert.ToString(receipts_table.Rows[i]["Due Amount"]));

                    object obj = cmd.ExecuteScalar();

                    conn.Close();
                    if (obj != null && obj != DBNull.Value)
                    {
                        result = Convert.ToInt32(obj);

                        // 1. Create the Receipt Voucher for Accounting
                        DateTime DATE = Convert.ToDateTime(receipts_table.Rows[i]["Date"].ToString());
                        int CUSTOMER_ID = Convert.ToInt32(receipts_table.Rows[i]["Customer Code"]);
                        int ITEM_ID = Convert.ToInt32(receipts_table.Rows[i]["Item Code"]);
                        int EMI_VOUCHER_ID = Convert.ToInt32(receipts_table.Rows[i]["EMI #"]);
                        String REF_NO = Convert.ToString(receipts_table.Rows[i]["Ref.No"]);
                        int STORE_ID = Store_ID;
                        double RECIEVED_AMOUNT = Convert.ToDouble(receipts_table.Rows[i]["Recieved Amt"]);
                        string itemName = Convert.ToInt32(receipts_table.Rows[i]["Item Code"]) <= 0 ? "Multiple Items" : "Installment Recovery";
                        Store_Reciept_Voucher(DATE, CUSTOMER_ID, accounts_controller.Get_Account_Name(CUSTOMER_ID), RECIEVED_AMOUNT, "Monthly Installment Recovery", "Cash", REF_NO, itemName, -1, STORE_ID);

                        // 2. Update Agreement Current Balance
                        aggrement = aggrements_controller.Get_Aggrement_By_Ref_No(REF_NO);
                        if (aggrement.Aggrement_Id > 0)
                        {
                            double updated_balance = (aggrement.Current_Balance - RECIEVED_AMOUNT);
                            aggrements_controller.Update_Aggrement_Current_Balance(REF_NO, updated_balance);

                            // 3. Mark the due as paid
                            Update_Reciept_Aggrement_Dues(aggrement.Aggrement_Id, DATE.ToString("dd-MM-yyyy"), EMI_VOUCHER_ID.ToString(), RECIEVED_AMOUNT, updated_balance);
                        }
                    }
                }
            }
            
            return result;
        }
        public int Store_Cash_Voucher_Items_ol(DateTime DATE, int CASH_VOUCHER_ID, string DUE_DATE, string DUE_AMOUNT, string REF_NO, int EMI_VOUCHER_ID, int CUSTOMER_ID, int ITEM_ID, double RECIEVED_AMOUNT, double BALANCE, int STORE_ID)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(@"INSERT INTO cash_voucher_items
           (date, emi_voucher_id, cash_voucher_id, customer_id, item_id, RECIEVED_AMOUNT, BALANCE, ref_no, due_date, due_amount) 
           VALUES (@date, @emi_voucher_id, @cash_voucher_id, @customer_id, @item_id, @RECIEVED_AMOUNT, @BALANCE, @ref_no, @due_date, @due_amount) 
           SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@date", DATE.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@emi_voucher_id", EMI_VOUCHER_ID);
                cmd.Parameters.AddWithValue("@cash_voucher_id", CASH_VOUCHER_ID);
                cmd.Parameters.AddWithValue("@customer_id", CUSTOMER_ID);
                cmd.Parameters.AddWithValue("@item_id", ITEM_ID);
                cmd.Parameters.AddWithValue("@RECIEVED_AMOUNT", RECIEVED_AMOUNT);
                cmd.Parameters.AddWithValue("@BALANCE", BALANCE);
                cmd.Parameters.AddWithValue("@ref_no", REF_NO);
                cmd.Parameters.AddWithValue("@due_date", DUE_DATE ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@due_amount", DUE_AMOUNT ?? "0");

                object obj = cmd.ExecuteScalar();
                if (obj != null && obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);
                    // ... (your existing receipt voucher and balance update logic)
                }
            }
            conn.Close();
            return result;
        }
        public int Store_Cash_Voucher_Items_Old(DateTime DATE,int CASH_VOUCHER_ID,String DUE_DATE,String DUE_AMOUNT, String REF_NO,int EMI_VOUCHER_ID,int CUSTOMER_ID,int ITEM_ID,Double RECIEVED_AMOUNT,Double BALANCE,int STORE_ID)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO  cash_voucher_items(date,emi_voucher_id,cash_voucher_id,customer_id,item_id,RECIEVED_AMOUNT,BALANCE,ref_no,due_date,due_amount) values(@date,@emi_voucher_id,@cash_voucher_id,@customer_id,@item_id,@RECIEVED_AMOUNT,@BALANCE,@ref_no,@due_date,@due_amount)  SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@date", DATE.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@due_date", DUE_DATE);
                cmd.Parameters.AddWithValue("@due_amount", DUE_AMOUNT);
                cmd.Parameters.AddWithValue("@cash_voucher_id", CASH_VOUCHER_ID);
                cmd.Parameters.AddWithValue("@customer_id", CUSTOMER_ID);
                cmd.Parameters.AddWithValue("@item_id", ITEM_ID);
                cmd.Parameters.AddWithValue("@ref_no", REF_NO);
                cmd.Parameters.AddWithValue("@emi_voucher_id", EMI_VOUCHER_ID);
                cmd.Parameters.AddWithValue("@RECIEVED_AMOUNT",RECIEVED_AMOUNT);
                cmd.Parameters.AddWithValue("@BALANCE",BALANCE);
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                    Items.Items_Controller items_controller = new Items.Items_Controller();
                    Items.Item item = new Items.Item();
                    item= items_controller.Get_Item(ITEM_ID);
                    //Double cash_account_current_balance = accounts_controller.Get_Account_Balance(2001);
                    //Double cash_account_closing_balance = cash_account_current_balance + RECIEVED_AMOUNT;
                    //accounts_controller.Insert_Account_Transaction(CUSTOMER_ID,accounts_controller.Get_Account_Name(CUSTOMER_ID),accounts_controller.Get_Account_Type(CUSTOMER_ID),accounts_controller.Get_Account_Nature(CUSTOMER_ID),"Cash Voucher","",0,0,0,RECIEVED_AMOUNT,BALANCE,DATE,null,item.Name,0,CASH_VOUCHER_ID,STORE_ID);
                    //accounts_controller.Insert_Account_Transaction(2001, accounts_controller.Get_Account_Name(2001), accounts_controller.Get_Account_Type(2001), accounts_controller.Get_Account_Nature(2001), "Cash Voucher", "", 0, 0, 0, RECIEVED_AMOUNT, BALANCE, DATE, null, item.Name, 0, CASH_VOUCHER_ID, STORE_ID);
                    //vouchers should be saved as reciepts
                    Vouchers_Controller vouchers_controller = new Vouchers_Controller();
                    vouchers_controller.Store_Reciept_Voucher(DATE, CUSTOMER_ID, accounts_controller.Get_Account_Name(CUSTOMER_ID), RECIEVED_AMOUNT, "Cash voucher payment reciept", "Cash", REF_NO,item.Name,CASH_VOUCHER_ID,STORE_ID);
                    aggrement = aggrements_controller.Get_Aggrement_By_Ref_No(REF_NO);
                    conn.Close();
                    if (aggrement.Aggrement_Id > 0)
                    {
                        double updated_balance=(aggrement.Current_Balance - RECIEVED_AMOUNT);
                        aggrements_controller.Update_Aggrement_Current_Balance(REF_NO,updated_balance);
                        Update_Reciept_Aggrement_Dues(aggrement.Aggrement_Id, DATE.ToString("dd-MM-yyyy"), EMI_VOUCHER_ID.ToString(),RECIEVED_AMOUNT,updated_balance);
                    }
                }
            }
            return result;
        }

        public void Store_Cash_Voucher_Expenses(int EXPENSE_ID, DateTime DATE, int STORE_ID, int CASH_VOUCHER_ID, Double EXPENSE_AMOUNT, SqlTransaction trans = null)
        {
            if (trans == null && conn.State != ConnectionState.Open) conn.Open();

            // 1. Get current balances inside transaction scope
            double curExpBal = accounts_controller.Get_Account_Balance(EXPENSE_ID);
            double curCashBal = accounts_controller.Get_Account_Balance(2001);

            // 2. Update Expense Account (Debit)
            string sqlExp = "UPDATE accounts SET balance = balance + @amt WHERE id = @id";
            using (SqlCommand cmd = new SqlCommand(sqlExp, conn))
            {
                if (trans != null) cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@amt", EXPENSE_AMOUNT);
                cmd.Parameters.AddWithValue("@id", EXPENSE_ID);
                cmd.ExecuteNonQuery();
            }

            // 3. Update Cash Account (Credit)
            string sqlCash = "UPDATE accounts SET balance = balance - @amt WHERE id = 2001";
            using (SqlCommand cmd = new SqlCommand(sqlCash, conn))
            {
                if (trans != null) cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@amt", EXPENSE_AMOUNT);
                cmd.ExecuteNonQuery();
            }

            // 4. Log to Journal transactions (Manual SQL to avoid controller connection conflicts)
            string sqlJrnl = @"INSERT INTO journal_transactions (account_id, description, source, debit, credit, closing_balance, entry_date, system_date, cash_voucher_id, store_id) 
                       VALUES (@id, 'Voucher Expense', 'Cash Voucher', @deb, @cre, @cbal, @date, GETDATE(), @cvid, @sid)";

            // Log for Expense A/C
            using (SqlCommand cmd = new SqlCommand(sqlJrnl, conn))
            {
                if (trans != null) cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@id", EXPENSE_ID);
                cmd.Parameters.AddWithValue("@deb", EXPENSE_AMOUNT);
                cmd.Parameters.AddWithValue("@cre", 0);
                cmd.Parameters.AddWithValue("@cbal", curExpBal + EXPENSE_AMOUNT);
                cmd.Parameters.AddWithValue("@date", DATE);
                cmd.Parameters.AddWithValue("@cvid", CASH_VOUCHER_ID);
                cmd.Parameters.AddWithValue("@sid", STORE_ID);
                cmd.ExecuteNonQuery();
            }

            if (trans == null) conn.Close();
        }

        public void Store_Cash_Voucher_Expenses_Old(int EXPENSE_ID,DateTime DATE,int STORE_ID,int CASH_VOUCHER_ID,Double EXPENSE_AMOUNT)
        {
            Double current_balance_exp_account = accounts_controller.Get_Account_Balance(EXPENSE_ID);
            Double closing_balance_exp_account = current_balance_exp_account + EXPENSE_AMOUNT;
            accounts_controller.Insert_Account_Transaction(EXPENSE_ID, accounts_controller.Get_Account_Name(EXPENSE_ID), accounts_controller.Get_Account_Type(EXPENSE_ID), accounts_controller.Get_Account_Nature(EXPENSE_ID), "Cash Voucher", "", 0, 0, 0, EXPENSE_AMOUNT, closing_balance_exp_account, DATE, null, "", 0, CASH_VOUCHER_ID, STORE_ID);

            Double cash_account_current_balance = accounts_controller.Get_Account_Balance(2001);
            Double cash_account_closing_balance = cash_account_current_balance - EXPENSE_AMOUNT;
            accounts_controller.Insert_Account_Transaction(2001, accounts_controller.Get_Account_Name(2001), accounts_controller.Get_Account_Type(2001), accounts_controller.Get_Account_Nature(2001), "Cash Voucher", "", 0, 0,0, EXPENSE_AMOUNT,cash_account_closing_balance, DATE);
        }

        public string Get_EMI_Serial_Existence_Details(int serial_number, int store_id, DateTime date)
        {
            string result = null;
            string targetYear = date.Year.ToString();
            // Convert int serial to string for matching varchar(20) in DB
            string serialStr = serial_number.ToString();

            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                string query = @"
                    SELECT Source, ref_no, [date] FROM (
                        -- 1. Check Monthly Recovery in aggrement_dues (Joined with aggrements for store_id)
                        -- We check paid_date (VARCHAR) and emi_no (VARCHAR)
                        SELECT 'Monthly Recovery' as Source, ad.ref_no, ad.paid_date as [date] 
                        FROM aggrement_dues ad
                        INNER JOIN aggrements ag ON ad.aggrement_id = ag.id
                        WHERE ad.emi_no = @serial 
                        AND ag.store_id = @store_id 
                        AND RIGHT(ad.paid_date, 4) = @year
                        AND ad.paid_amount > 0

                        UNION ALL
        
                        -- 2. Check New Agreements (date column is DATETIME)
                        SELECT 'New Agreement' as Source, ref_no, FORMAT(date, 'dd-MM-yyyy') as [date] 
                        FROM aggrements 
                        WHERE emi_no = @serial 
                        AND store_id = @store_id 
                        AND YEAR(date) = @year
        
                        UNION ALL
        
                        -- 3. Check Agreement Returns (return_date column is DATETIME)
                        SELECT 'Agreement Return' as Source, ref_no, FORMAT(return_date, 'dd-MM-yyyy') as [date] 
                        FROM agreement_returns 
                        WHERE emi_no = @serial 
                        AND store_id = @store_id 
                        AND YEAR(return_date) = @year
                    ) as ExistenceCheck";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Note: serial_number (int) will be implicitly cast to varchar by SQL Server
                    cmd.Parameters.AddWithValue("@serial", serialStr);
                    cmd.Parameters.AddWithValue("@store_id", store_id);
                    cmd.Parameters.AddWithValue("@year", targetYear);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string source = reader["Source"].ToString();
                            string refNo = reader["ref_no"].ToString();
                            string dateEx = reader["date"] != DBNull.Value ? reader["date"].ToString() : "N/A";

                            result = $"Serial exists in '{source}' with Ref. No: {refNo} on date: {dateEx}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error checking EMI serial details: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public bool If_Emi_Serial_Already_Exists(int serial_number, int store_id, DateTime date)
        {
            bool result = false;
            string targetYear = date.Year.ToString();

            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                // We check across 3 tables using UNION ALL. 
                // If the sum of counts is > 0, the serial is taken.
                string query = @"
            SELECT SUM(TotalCount) FROM (
                -- 1. Check Monthly Recovery Items
                SELECT COUNT(*) as TotalCount FROM cash_voucher_items 
                WHERE emi_voucher_id = @serial AND store_id = @store_id AND RIGHT(date, 4) = @year
                
                UNION ALL
                
                -- 2. Check New Agreements
                SELECT COUNT(*) FROM aggrements 
                WHERE emi_no = @serial AND store_id = @store_id AND YEAR(date) = @year
                
                UNION ALL
                
                -- 3. Check Agreement Returns
                SELECT COUNT(*) FROM agreement_returns 
                WHERE emi_no = @serial AND store_id = @store_id AND YEAR(return_date) = @year
            ) as ExistenceCheck";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@serial", serial_number);
                    cmd.Parameters.AddWithValue("@store_id", store_id);
                    cmd.Parameters.AddWithValue("@year", targetYear);

                    object obj = cmd.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                    {
                        if (Convert.ToInt32(obj) > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error checking comprehensive EMI serial availability: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public bool If_Emi_Serial_Already_Exists_Old_Recent(int serial_number, int store_id, DateTime date)
        {
            bool result = false;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                // Extract the year from the DateTime object provided
                string targetYear = date.Year.ToString();

                // We use COUNT to check if a record exists for:
                // 1. The specific serial number
                // 2. The specific store
                // 3. The specific year (extracting the last 4 characters from the VARCHAR date)
                string query = @"SELECT COUNT(*) 
                         FROM cash_voucher_items 
                         WHERE emi_voucher_id = @serial 
                         AND store_id = @store_id 
                         AND RIGHT(date, 4) = @year";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@serial", serial_number);
                    cmd.Parameters.AddWithValue("@store_id", store_id);
                    cmd.Parameters.AddWithValue("@year", targetYear);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error checking EMI serial availability: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public bool If_Emi_Serial_Already_Exists_Old(int serial_number, int store_id, DateTime date)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT emi_voucher_id, date FROM cash_voucher_items WHERE emi_voucher_id='"+serial_number+"' and store_id = '@store_id'";
            SqlCommand cmd = new SqlCommand(query, conn);
            Object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                int emi_sr = Convert.ToInt32(obj);
                if(emi_sr == serial_number)
                {
                    result = true;
                }
            }
            conn.Close();
            return result;
        }
    }
}
