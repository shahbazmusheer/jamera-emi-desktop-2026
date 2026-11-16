using DevExpress.Printing.Utils.DocumentStoring;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Accounts
{
    class Accounts_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Accounts_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }

        public void Update_Account_Balance(int ac_id, double balance)
        {
            conn.Open();
            String query = @"UPDATE accounts SET balance='" + balance + "' WHERE id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Update_Opening_Debit(int ac_id, double balance)
        {
            conn.Open();
            String query = @"UPDATE journal_transactions SET opening_debit="+balance+" WHERE account_id='"+ac_id+"' and id=(SELECT TOP 1 MIN(id) FROM journal_transactions WHERE account_id='"+ac_id+"')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Update_Opening_Credit(int ac_id, double balance)
        {
            conn.Open();
            String query = @"UPDATE journal_transactions SET opening_credit=" + balance + " WHERE account_id='" + ac_id + "' and id=(SELECT TOP 1 MIN(id) FROM journal_transactions WHERE account_id='" + ac_id + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public int Exists_Transaction(int ac_id)
        {
            int result = -1;
            conn.Open();
            String query = @"SELECT COUNT(account_id) FROM journal_transactions WHERE account_id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj);
            }
            conn.Close();
            return result;
        }
        public int Exists_Ref_No(String ref_no)
        {
            int result = -1;
            conn.Open();
            String query = @"SELECT TOP 1 debit_account_id FROM vouchers WHERE ref_no='"+ref_no+ "' and debit_description='Opening Sales'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj);
            }
            conn.Close();
            return result;
        }
        public Double Get_Opening_Balance_Ref_No(String ref_no)
        {
            Double result = -1;
            conn.Open();
            String query = @"SELECT TOP 1 amount FROM vouchers WHERE ref_no='" + ref_no + "' and debit_description='Opening Sales'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToDouble(obj);
            }
            conn.Close();
            return result;
        }
        public Double Get_Current_Balance_Opening_Entries_Ref_No(int customer_id,String ref_no)
        {
            Double result =0;
            Double total_credit = 0;
            conn.Open();
            String query = @"SELECT SUM(amount) FROM vouchers WHERE ref_no='"+ref_no+ "' and voucher_type='Reciept Voucher'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                total_credit = Convert.ToDouble(obj);
            }
            conn.Close();
            Double opening_balance= Get_Opening_Balance_Ref_No(ref_no);
            result = (opening_balance - total_credit);
            return result;
        }
        public String Get_Account_Type(int ac_id)
        {
            conn.Open();
            String query = @"SELECT account_type FROM accounts WHERE id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            String res = null;
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value || obj != null)
            {
                res = Convert.ToString(obj);
            }
            conn.Close();
            return res;
        }
        public bool Is_Account_Editable(int ac_id)
        {
            bool result= true;
            conn.Open();
            String query = @"SELECT created_type FROM accounts WHERE id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value || obj != null)
            {
                if(Convert.ToString(obj) == "System")
                {
                    result = false;
                }
            }
            conn.Close();
            return result;
        }
        public String Get_Office_Phone(int ac_id)
        {
            conn.Open();
            String query = @"SELECT phone FROM accounts WHERE id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            String res = null;
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value || obj != null)
            {
                res = Convert.ToString(obj);
            }
            conn.Close();
            return res;
        }
        public String Get_Home_Phone(int ac_id)
        {
            conn.Open();
            String query = @"SELECT home_phone FROM accounts WHERE id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            String res = null;
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value || obj != null)
            {
                res = Convert.ToString(obj);
            }
            conn.Close();
            return res;
        }
        public String Get_Account_Name(int ac_id)
        {
            conn.Open();
            String query = @"SELECT name FROM accounts WHERE id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            String res = null;
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value || obj != null)
            {
                res = Convert.ToString(obj);
            }
            conn.Close();
            return res;
        }

        public double Get_Account_Balance(int ac_id)
        {
            conn.Open();
            String query = @"SELECT balance FROM accounts WHERE id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            double res = 0;
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value || obj != null)
            {
                res = Convert.ToDouble(obj);
            }
            conn.Close();
            return res;            
        }
        public int Store(String NAME,String EMAIL,int AC_GROUP_ID,String AC_GROUP,String AC_TYPE,String PHONE,String ADDRESS, String DESCRIPTION,Double BALANCE)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO accounts(name,email,phone,address,account_group_id,account_group,remarks,account_type,balance,created_type) values(@name,@email,@phone,@address,@account_group_id,@account_group,@remarks,@account_type,@balance,@created_type)  SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@name", NAME);
                if(EMAIL == null)
                {
                    cmd.Parameters.AddWithValue("@email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@email", EMAIL);
                }
                cmd.Parameters.AddWithValue("@account_group_id", AC_GROUP_ID);
                cmd.Parameters.AddWithValue("@account_group", AC_GROUP);
                cmd.Parameters.AddWithValue("@remarks", DESCRIPTION);
                cmd.Parameters.AddWithValue("@phone", PHONE);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                cmd.Parameters.AddWithValue("@account_type", AC_TYPE);
                cmd.Parameters.AddWithValue("@balance", BALANCE);
                cmd.Parameters.AddWithValue("@created_type", "Custom");
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }

        public int Store(String NAME, String EMAIL, int AC_GROUP_ID, String AC_GROUP, String AC_TYPE, String PHONE, String ADDRESS, String DESCRIPTION, Double BALANCE, int STORE_ID, String FATHER_NAME,int AGE,String COST,String PROFESSION,String ID_CARD_NO,String BUSINESS_ADDRESS,String HOME_ADDRESS,String HOME_PHONE)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO accounts(name,email,phone,address,account_group_id,account_group,remarks,account_type,store_id,father_name,age,cost,profession,id_card_no,business_address,home_address,home_phone,balance,created_type) values(@name,@email,@phone,@address,@account_group_id,@account_group,@remarks,@account_type,@store_id,@father_name,@age,@cost,@profession,@id_card_no,@business_address,@home_address,@home_phone,@balance,@created_type)  SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@name", NAME);
                if (EMAIL == null)
                {
                    cmd.Parameters.AddWithValue("@email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@email", EMAIL);
                }
                cmd.Parameters.AddWithValue("@account_group_id", AC_GROUP_ID);
                cmd.Parameters.AddWithValue("@account_group", AC_GROUP);
                cmd.Parameters.AddWithValue("@remarks", DESCRIPTION);
                cmd.Parameters.AddWithValue("@phone", PHONE);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                cmd.Parameters.AddWithValue("@account_type", AC_TYPE);
                cmd.Parameters.AddWithValue("@balance", BALANCE);
                cmd.Parameters.AddWithValue("@created_type", "Custom");
                if(STORE_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@store_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                }
                cmd.Parameters.AddWithValue("@father_name", FATHER_NAME);
                if(AGE != -1)
                {
                    cmd.Parameters.AddWithValue("@age", AGE);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@age", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@cost", COST);
                cmd.Parameters.AddWithValue("@profession", PROFESSION);
                cmd.Parameters.AddWithValue("@id_card_no", ID_CARD_NO);
                cmd.Parameters.AddWithValue("@business_address", BUSINESS_ADDRESS);
                cmd.Parameters.AddWithValue("@home_address", HOME_ADDRESS);
                cmd.Parameters.AddWithValue("@home_phone",HOME_PHONE);
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }

        
        public int Get_Serial_Number()
        {
            int result = -1;
            conn.Open();
            String query = @"SELECT MAX(id) from accounts;";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj) + 1;
            }
            conn.Close();
            return result;
        }
        public bool Update(int ID, String NAME, String EMAIL, int AC_GROUP_ID, String AC_GROUP, String AC_TYPE, String PHONE, String ADDRESS, String DESCRIPTION,int STORE_ID, String FATHER_NAME, int AGE, String COST, String PROFESSION, String ID_CARD_NO, String BUSINESS_ADDRESS, String HOME_ADDRESS, String HOME_PHONE)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE accounts SET name=@name,email=@email,phone=@phone,address=@address,account_group_id=@account_group_id,account_group=@account_group,remarks=@remarks,account_type=@account_type,store_id=@store_id,father_name=@father_name,age=@age,cost=@cost,profession=@profession,id_card_no=@id_card_no,business_address=@business_address,home_address=@home_address,home_phone=@home_phone WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id",ID);
                cmd.Parameters.AddWithValue("@name", NAME);
                if (EMAIL == null)
                {
                    cmd.Parameters.AddWithValue("@email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@email", EMAIL);
                }
                cmd.Parameters.AddWithValue("@account_group_id", AC_GROUP_ID);
                cmd.Parameters.AddWithValue("@account_group", AC_GROUP);
                cmd.Parameters.AddWithValue("@remarks", DESCRIPTION);
                cmd.Parameters.AddWithValue("@phone", PHONE);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                cmd.Parameters.AddWithValue("@account_type", AC_TYPE);
                cmd.Parameters.AddWithValue("@created_type", "Custom");
                if(STORE_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@store_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                }
                
                cmd.Parameters.AddWithValue("@father_name", FATHER_NAME);
                if (AGE != -1)
                {
                    cmd.Parameters.AddWithValue("@age", AGE);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@age", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@cost", COST);
                cmd.Parameters.AddWithValue("@profession", PROFESSION);
                cmd.Parameters.AddWithValue("@id_card_no", ID_CARD_NO);
                cmd.Parameters.AddWithValue("@business_address", BUSINESS_ADDRESS);
                cmd.Parameters.AddWithValue("@home_address", HOME_ADDRESS);
                cmd.Parameters.AddWithValue("@home_phone", HOME_PHONE);
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }
        public bool Update(int ID, String NAME, String EMAIL, int AC_GROUP_ID, String AC_GROUP, String AC_TYPE, String PHONE, String ADDRESS, String DESCRIPTION)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE accounts SET name=@name,email=@email,phone=@phone,address=@address,account_group_id=@account_group_id,account_group=@account_group,remarks=@remarks,account_type=@account_type WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", NAME);
                if (EMAIL == null)
                {
                    cmd.Parameters.AddWithValue("@email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@email", EMAIL);
                }
                cmd.Parameters.AddWithValue("@account_group_id", AC_GROUP_ID);
                cmd.Parameters.AddWithValue("@account_group", AC_GROUP);
                cmd.Parameters.AddWithValue("@remarks", DESCRIPTION);
                cmd.Parameters.AddWithValue("@phone", PHONE);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                cmd.Parameters.AddWithValue("@account_type", AC_TYPE);
                cmd.Parameters.AddWithValue("@created_type", "Custom");
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }
        public bool Delete(int ID)
        {
            conn.Open();
            bool result = false;
            using (SqlCommand cmd = new SqlCommand("DELETE FROM accounts WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }

        public bool Exists(String name)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT id FROM accounts WHERE name='" + name + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object query_results = cmd.ExecuteScalar();
            if (query_results == DBNull.Value || query_results == null)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            conn.Close();
            return result;
        }
        public bool Exists(int ac_id,String name)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT id FROM accounts WHERE name='" + name + "' and id !='"+ac_id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object query_results = cmd.ExecuteScalar();
            if (query_results != DBNull.Value && query_results != null)
            {
                 if(Convert.ToInt32(query_results) == ac_id)
                {
                    result = true;
                }
            }
            else
            {
                result = false;
            }
            conn.Close();
            return result;
        }
        public bool Id_Card_Exists(string id_card_no, int group_id = -1, int store_id = -1)
        {
            bool exists = false;

            // Ensure connection is managed safely
            if (conn.State != ConnectionState.Open) conn.Open();

            try
            {
                // Use COUNT(*) - it is faster and clearer for checking existence
                string query = "SELECT COUNT(*) FROM accounts WHERE id_card_no = @id_card AND id_card_no != '--'";

                if (group_id > -1)
                {
                    query += " AND account_group_id = @group_id";
                }


                if (store_id > -1)
                {
                    query += " AND store_id = @store_id";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_card", id_card_no);
                    if (group_id > -1) cmd.Parameters.AddWithValue("@group_id", group_id);
                    if (store_id > -1) cmd.Parameters.AddWithValue("@store_id", store_id);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        exists = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error checking ID card: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return exists;
        }

        public Account Get_Last_Saved_Account(int group_id, int store_id)
        {
            Account account = null;

            if (conn.State != ConnectionState.Open) conn.Open();

            try
            {
                // Select the latest record based on the highest ID
                string query = @"SELECT TOP 1 
                            id, name, father_name, age, cost, profession, 
                            id_card_no, business_address, home_address, 
                            phone as 'office_phone', home_phone, address as 'permanent_address', 
                            store_id, balance, remarks 
                         FROM accounts 
                         WHERE account_group_id = @group_id 
                         AND store_id = @store_id 
                         ORDER BY id DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@group_id", group_id);
                    cmd.Parameters.AddWithValue("@store_id", store_id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new Account();
                            account.Account_Id = Convert.ToInt32(reader["id"]);
                            account.Account_Name = reader["name"].ToString();
                            account.Father_Name = reader["father_name"].ToString();
                            account.Age = reader["age"] != DBNull.Value ? Convert.ToInt32(reader["age"]) : -1;
                            account.Cast = reader["cost"].ToString();
                            account.Profession = reader["profession"].ToString();
                            account.Id_Card_No = reader["id_card_no"].ToString();
                            account.Office_Address = reader["business_address"].ToString();
                            account.Home_Address = reader["home_address"].ToString();
                            account.Permanent_Address = reader["permanent_address"].ToString();
                            account.Office_Phone = reader["office_phone"].ToString();
                            account.Home_Phone = reader["home_phone"].ToString();
                            account.Store_Id = Convert.ToInt32(reader["store_id"]);
                            account.Balance = Convert.ToDouble(reader["balance"]);
                            account.Account_Remarks = reader["remarks"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error fetching last saved account: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return account;
        }

        public Account Get_Full_Account_Details(int account_id)
        {
            Account account = null;

            if (conn.State != ConnectionState.Open) conn.Open();

            try
            {
                // Select the latest record based on the highest ID
                string query = @"SELECT TOP 1 
                            id, name, father_name, age, cost, profession, 
                            id_card_no, business_address, home_address, 
                            phone as 'office_phone', home_phone, address as 'permanent_address', 
                            store_id, balance, remarks 
                         FROM accounts 
                         WHERE id = @id ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", account_id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new Account();
                            account.Account_Id = Convert.ToInt32(reader["id"]);
                            account.Account_Name = reader["name"].ToString();
                            account.Father_Name = reader["father_name"].ToString();
                            account.Age = reader["age"] != DBNull.Value ? Convert.ToInt32(reader["age"]) : -1;
                            account.Cast = reader["cost"].ToString();
                            account.Profession = reader["profession"].ToString();
                            account.Id_Card_No = reader["id_card_no"].ToString();
                            account.Office_Address = reader["business_address"].ToString();
                            account.Home_Address = reader["home_address"].ToString();
                            account.Permanent_Address = reader["permanent_address"].ToString();
                            account.Office_Phone = reader["office_phone"].ToString();
                            account.Home_Phone = reader["home_phone"].ToString();
                            account.Store_Id = Convert.ToInt32(reader["store_id"]);
                            account.Balance = Convert.ToDouble(reader["balance"]);
                            account.Account_Remarks = reader["remarks"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error fetching last saved account: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return account;
        }

        public int Get_Existing_Account_Id_By_IDCard(string id_card_no, int group_id = -1, int store_id = -1)
        {
            int existingId = -1; // Default to -1 if not found

            if (conn.State != ConnectionState.Open) conn.Open();

            try
            {
                // Change COUNT(*) to TOP 1 id
                string query = "SELECT TOP 1 id FROM accounts WHERE id_card_no = @id_card AND id_card_no != '--'";

                if (group_id > -1)
                {
                    query += " AND account_group_id = @group_id";
                }

                if (store_id > -1)
                {
                    query += " AND store_id = @store_id";
                }

                // It is good practice to order by ID to ensure you truly get the 'first' one
                query += " ORDER BY id ASC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_card", id_card_no);
                    if (group_id > -1) cmd.Parameters.AddWithValue("@group_id", group_id);
                    if (store_id > -1) cmd.Parameters.AddWithValue("@store_id", store_id);

                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        existingId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error retrieving existing account ID: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return existingId;
        }
        public bool Id_Card_Exists_Old(String id_card_no, int group_id = -1)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT id FROM accounts WHERE id_card_no='" + id_card_no + "' and id_card_no!='--'";
            if(group_id > -1)
            {
                query += " and account_group_id = '"+group_id+"' ";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            object query_results = cmd.ExecuteScalar();
            if (query_results != DBNull.Value && query_results != null)
            {
                if (Convert.ToString(query_results) == id_card_no)
                {
                    result = true;
                }
            }
            else
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        public bool Id_Card_Exists(int exclude_id, string id_card_no, int group_id = -1, int store_id = -1)
        {
            bool exists = false;

            if (conn.State != ConnectionState.Open) conn.Open();

            try
            {
                // 1. We look for the ID Card number
                // 2. We EXCLUDE the current person's ID (exclude_id)
                // 3. We exclude dummy values like '--'
                string query = @"SELECT COUNT(*) FROM accounts 
                         WHERE id_card_no = @id_card 
                         AND id != @id 
                         AND id_card_no != '--'";

                if (group_id > -1)
                {
                    query += " AND account_group_id = @group_id";
                }

                if (store_id > -1)
                {
                    query += " AND store_id = @store_id";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_card", id_card_no);
                    cmd.Parameters.AddWithValue("@id", exclude_id);
                    if (group_id > -1) cmd.Parameters.AddWithValue("@group_id", group_id);
                    if (store_id > -1) cmd.Parameters.AddWithValue("@store_id", store_id);

                    int count = (int)cmd.ExecuteScalar();

                    // If count > 0, it means another record already has this CNIC
                    if (count > 0)
                    {
                        exists = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error checking ID card for update: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return exists;
        }
        public bool Id_Card_Exists_Old(int guardian_id,String id_card_no)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT id FROM accounts WHERE id_card_no='" + id_card_no + "' and id !='"+guardian_id+ "'and id_card_no!='--'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object query_results = cmd.ExecuteScalar();
            if (query_results != DBNull.Value && query_results != null)
            {
                if (Convert.ToString(query_results) == id_card_no)
                {
                    result = true;
                }
            }
            else
            {
                result = false;
            }
            conn.Close();
            return result;
        }
        public String Get_Account_Nature(int ac_id)
        {
            conn.Open();
            String query = @"SELECT ac_gps.nature from accounts right join account_groups as ac_gps on accounts.account_group_id=ac_gps.id where accounts.id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            String res = "";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                res = reader["nature"].ToString();
            }
            reader.Close();
            conn.Close();
            return res;
        }
        public Account Get_Account(int ac_id)
        {
            Account account = new Account();
            conn.Open();
            String query = @"SELECT TOP 1 accounts.id as 'ID',accounts.name as 'Name',accounts.father_name as 'Father Name',accounts.id_card_no as 'ID Card No',accounts.phone as 'Phone',accounts.office_phone as 'Office Phone',accounts.home_phone as 'Home Phone',accounts.address as 'Address',accounts.business_address as 'Business Address',accounts.home_address as 'Home Address',ac_gps.id as 'Group Id',ac_gps.name as 'Group Name',ac_gps.nature as 'Nature',ac_gps.account_type as 'Account Type',accounts.balance as 'Balance',accounts.remarks as 'Remarks' from accounts left join account_groups as ac_gps on accounts.account_group_id=ac_gps.id where accounts.id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                account.Account_Id = ac_id;
                account.Account_Name = reader["Name"].ToString();
                account.Father_Name = reader["Father Name"].ToString();
                account.Account_Group_Id = Convert.ToInt32(reader["Group Id"]);
                account.Account_Group_Name = reader["Group Name"].ToString();
                account.Phone = reader["Phone"].ToString();
                account.Id_Card_No = reader["ID Card No"].ToString();
                account.Home_Phone = reader["Home Phone"].ToString();
                account.Office_Phone = reader["Office Phone"].ToString();
                account.Address = reader["Address"].ToString();
                account.Business_Address = reader["Business Address"].ToString();
                account.Home_Address = reader["Home Address"].ToString();
                account.Account_Nature = reader["Nature"].ToString();
                account.Account_Type = reader["Account Type"].ToString();
                account.Balance = Convert.ToDouble(reader["Balance"]);
                account.Account_Remarks = reader["Remarks"].ToString();
            }
            reader.Close();
            conn.Close();
            return account;
        }

        public Account Get_Customer(int ac_id)
        {
            Account account = new Account();
            conn.Open();
            String query = @"SELECT TOP 1 accounts.id as 'ID',accounts.store_id as 'Store Id',accounts.name as 'Name',accounts.father_name as 'Father Name',accounts.age as 'Age',accounts.cost as 'Cast',accounts.profession as 'Profession',accounts.id_card_no as 'Id Card',accounts.business_address as 'Business Address',accounts.home_address as 'Home Address',accounts.phone as 'Office Phone',accounts.home_phone as 'Home Phone',accounts.address as 'Permanent Address',accounts.balance as 'Balance',accounts.remarks as 'Remarks' from accounts left join account_groups as ac_gps on accounts.account_group_id=ac_gps.id where accounts.id='" + ac_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                account.Account_Id = ac_id;
                if(reader["Store Id"] != DBNull.Value)
                {
                    account.Store_Id = Convert.ToInt32(reader["Store Id"]);
                }
                else
                {
                    account.Store_Id = -1;
                }
                if(reader["Age"] != DBNull.Value)
                {
                    account.Age = Convert.ToInt32(reader["Age"]);
                }
                else
                {
                    account.Age = -1;
                }                
                account.Account_Name = reader["Name"].ToString();
                account.Father_Name = reader["Father Name"].ToString();
                account.Cast = reader["Cast"].ToString();
                account.Profession = reader["Profession"].ToString();
                account.Id_Card_No = reader["Id Card"].ToString();
                account.Office_Phone = reader["Office Phone"].ToString();
                account.Home_Phone = reader["Home Phone"].ToString();
                account.Home_Address = reader["Home Address"].ToString();
                account.Office_Address = reader["Business Address"].ToString();
                account.Permanent_Address = reader["Permanent Address"].ToString();
                account.Balance = Convert.ToDouble(reader["Balance"]);
                account.Account_Remarks = reader["Remarks"].ToString();
            }
            reader.Close();
            conn.Close();
            return account;
        }

        public void Insert_Account_Transaction(int AC_ID, String AC_NAME,String AC_TYPE,String AC_NATURE, String SOURCE, String DESCRIPTION, double OPENING_DEBIT, double OPENING_CREDIT, double DEBIT, double CREDIT, double BALANCE, DateTime DATE, String INVOICE_NO = null, String ITEM_NAME = null, double ITEM_QUANTITY = 0,int CASH_VOUCHER_ID=-1,int STORE_ID=-1)
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("Insert into journal_transactions(account_type,description,source,system_date,entry_date,account_id,account_name,opening_debit,opening_credit,debit,credit,closing_balance,invoice_no,item_name,item_quantity,account_nature,cash_voucher_id,store_id) values(@account_type,@description,@source,@system_date,@entry_date,@account_id,@account_name,@opening_debit,@opening_credit,@debit,@credit,@closing_balance,@invoice_no,@item_name,@item_quantity,@account_nature,@cash_voucher_id,@store_id)", conn))
            {
                cmd.Parameters.AddWithValue("@account_type", AC_TYPE);
                cmd.Parameters.AddWithValue("@account_nature", AC_NATURE);
                cmd.Parameters.AddWithValue("@description", DESCRIPTION);
                cmd.Parameters.AddWithValue("@source", SOURCE);
                cmd.Parameters.AddWithValue("@system_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@entry_date", DATE);
                cmd.Parameters.AddWithValue("@account_id", AC_ID);
                cmd.Parameters.AddWithValue("@account_name", AC_NAME);
                cmd.Parameters.AddWithValue("@opening_debit", OPENING_DEBIT);
                cmd.Parameters.AddWithValue("@opening_credit", OPENING_CREDIT);
                cmd.Parameters.AddWithValue("@debit", DEBIT);
                cmd.Parameters.AddWithValue("@credit", CREDIT);
                cmd.Parameters.AddWithValue("@closing_balance", BALANCE);
                if(CASH_VOUCHER_ID != -1)
                {
                    cmd.Parameters.AddWithValue("@cash_voucher_id", CASH_VOUCHER_ID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cash_voucher_id", DBNull.Value);
                }

                if(STORE_ID != -1)
                {
                    cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@store_id",DBNull.Value);
                }

                if (INVOICE_NO != null)
                {
                    cmd.Parameters.AddWithValue("@invoice_no", INVOICE_NO);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@invoice_no", DBNull.Value);
                }
                if (ITEM_NAME != null)
                {
                    cmd.Parameters.AddWithValue("@item_name", ITEM_NAME);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@item_name", DBNull.Value);
                }

                if (ITEM_QUANTITY != 0)
                {
                    cmd.Parameters.AddWithValue("@item_quantity", ITEM_QUANTITY);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@item_quantity", DBNull.Value);
                }

                cmd.ExecuteNonQuery();
                conn.Close();
                Update_Account_Balance(AC_ID, BALANCE);
            }
        }
        public bool Customer_Exists(String name,int store_id)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT id FROM accounts WHERE name='" + name + "' and store_id ='" + store_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object query_results = cmd.ExecuteScalar();
            if (query_results == DBNull.Value || query_results == null)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            conn.Close();
            return result;
        }
        public bool Customer_Exists(int customer_id,String name, int store_id)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT id FROM accounts WHERE name='" + name + "' and store_id ='" + store_id + "' and id!='"+customer_id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object query_results = cmd.ExecuteScalar();
            if (query_results == DBNull.Value || query_results == null)
            {
                result = false;
            }
            else
            {
                if(Convert.ToInt32(query_results) == customer_id)
                {
                    result = true;
                }
            }
            conn.Close();
            return result;
        }
    }
}
