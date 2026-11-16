using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Jamera
{
    public class Dashboard_Controller
    {
        Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
        SqlConnection conn = new SqlConnection();
        public Dashboard_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }
        public Double Get_Sales_Balance()
        {
            return accounts_controller.Get_Account_Balance(2008);
        }
        public Double Get_Cash_Balance()
        {
            return accounts_controller.Get_Account_Balance(2001);
        }
        public Double Get_Bank_Balance()
        {
            return accounts_controller.Get_Account_Balance(2002);
        }
        public Double Get_Inventory_Balance()
        {
            return accounts_controller.Get_Account_Balance(2011);
        }
        public int Get_No_Of_Cash_Vouchers()
        {
            conn.Open();
            int result = 0;
            String query = @"SELECT COUNT(id) FROM cash_vouchers;";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj);
            }
            conn.Close();
            return result;
        }
        public int Get_No_Of_Emi_Vouchers()
        {
            conn.Open();
            int result = 0;
            String query = @"SELECT MAX(end_serial) FROM emi_vouchers;";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj) ;
            }
            conn.Close();
            return result;
        }
        public int Get_No_Of_Sent_Messages()
        {
            conn.Open();
            int result = 0;
            String query = @"SELECT COUNT(id) FROM messages;";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj) ;
            }
            conn.Close();
            return result;
        }
        public int Get_No_Of_Aggrements()
        {
            conn.Open();
            int result = 0;
            String query = @"SELECT COUNT(id) FROM aggrements;";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj) ;
            }
            conn.Close();
            return result;
        }
        public int Get_No_Of_Customers()
        {
            conn.Open();
            int result = 0;
            String query = @"SELECT COUNT(id) FROM accounts WHERE account_group_id='1002';";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj) ;
            }
            conn.Close();
            return result;
        }
        public int Get_No_Of_Guardians()
        {
            conn.Open();
            int result = 0;
            String query = @"SELECT COUNT(id) FROM accounts WHERE account_group_id='1010';";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj);
            }
            conn.Close();
            return result;
        }
    }

}
