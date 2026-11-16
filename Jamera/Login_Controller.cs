using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace Jamera
{
    class Login_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Login_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            conn = db_handler.GetDatabseConnection();
        }

        public bool Is_User_Valid(String USER_NAME,String PASSWORD)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT login_id,login_password FROM accounts WHERE login_id='"+USER_NAME+"'";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader =  cmd.ExecuteReader();
            while (reader.Read())
            {
                if(reader["login_password"].ToString() == PASSWORD)
                {
                    result = true;
                }
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public bool Update_Password(String USER_NAME, String PASSWORD)
        {
            conn.Open();
            bool result = false;
            String query = @"UPDATE accounts SET login_password='"+PASSWORD+"' WHERE login_id='"+USER_NAME+"'";
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();
            result = true;
            conn.Close();            
            return result;
        }
    }
}
