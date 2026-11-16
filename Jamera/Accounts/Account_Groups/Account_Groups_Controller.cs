using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace Jamera.Accounts.Account_Groups
{
    public class Account_Groups_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Account_Groups_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }

        public int Store(String NAME,int NATURE_ID,String NATURE,String ACCOUNT_TYPE)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO account_groups(name,nature_id,nature,account_type,created_type) values(@name,@nature_id,@nature,@account_type,@created_type)  SELECT CAST(scope_identity() AS int)", conn))
            {
                //nature_id,nature,account_type,created_type
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@nature_id", NATURE_ID);
                cmd.Parameters.AddWithValue("@nature", NATURE);
                cmd.Parameters.AddWithValue("@account_type",ACCOUNT_TYPE);
                cmd.Parameters.AddWithValue("@created_type","Custom");
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }

        public bool Update(int Group_Id,String NAME, int NATURE_ID, String NATURE, String ACCOUNT_TYPE)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE account_groups SET name=@name,nature_id=@nature_id,nature=@nature,account_type=@account_type,created_type=@created_type WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", Group_Id);
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@nature_id", NATURE_ID);
                cmd.Parameters.AddWithValue("@nature", NATURE);
                cmd.Parameters.AddWithValue("@account_type", ACCOUNT_TYPE);
                cmd.Parameters.AddWithValue("@created_type", "Custom");
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
            String query = @"SELECT id FROM account_groups WHERE name='" + name + "'";
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
        public bool Exists(int Group_Id,String name)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT id FROM account_groups WHERE name='" + name + "' and id !='"+Group_Id+"'";
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

        public bool Is_Group_Editable(int group_id)
        {
            bool result = true;
            conn.Open();
            String query = @"SELECT created_type FROM account_groups WHERE id='" + group_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value || obj != null)
            {
                if (Convert.ToString(obj) == "System")
                {
                    result = false;
                }
            }
            conn.Close();
            return result;
        }
        public bool Delete(int group_id)
        {
            bool result = false;
            conn.Open();
            String query = @"DELETE  FROM account_groups WHERE id='" + group_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            result = true;
            conn.Close();
            return result;
        }
    }
}
