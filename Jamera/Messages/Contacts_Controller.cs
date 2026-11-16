using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
namespace Jamera.Messages
{
    public class Contacts_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Contacts_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }
        public bool Exists(int id, int group_id, String Name)
        {
            conn.Open();
            bool result = false;
            String query = @"SELECT id FROM group_contacts WHERE name='" + Name + "' and id !='" + id + "' and group_id='"+group_id+"'";
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
        
        public bool Exists(int group_id,String name)
        {
            conn.Open();
            bool result = false;
            String query = @"SELECT id FROM group_contacts WHERE name='" + name + "' and group_id='"+group_id+"'";
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
        public int Store(int group_id,String NAME,String OFFICE_PHONE,String HOME_PHONE,String ADDRESS,String REMARKS, int store_id)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO group_contacts(store_id,group_id,name,office_phone,home_phone,address,remarks) values(@store_id,@group_id,@name,@office_phone,@home_phone,@address,@remarks) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@office_phone", OFFICE_PHONE);
                cmd.Parameters.AddWithValue("@group_id", group_id);
                if(store_id == -1)
                {
                    cmd.Parameters.AddWithValue("@store_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@store_id", store_id);
                }
                cmd.Parameters.AddWithValue("@home_phone", HOME_PHONE);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                cmd.Parameters.AddWithValue("@remarks", REMARKS);
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }

        public int Update(int group_id,int Id, String NAME, String OFFICE_PHONE, String HOME_PHONE, String ADDRESS,String REMARKS,int store_id)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE group_contacts SET group_id=@group_id,name=@name,store_id=@store_id,office_phone=@office_phone,home_phone=@home_phone,address=@address,remarks=@remarks WHERE id='" + Id + "'", conn))
            {
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@office_phone", OFFICE_PHONE);
                cmd.Parameters.AddWithValue("@group_id", group_id);
                if(store_id == -1)
                {
                    cmd.Parameters.AddWithValue("@store_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@store_id", store_id);
                }
                cmd.Parameters.AddWithValue("@home_phone", HOME_PHONE);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                cmd.Parameters.AddWithValue("@remarks", REMARKS);
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }
        public Contact Get_Contact(int Id)
        {
            Contact contact = new Contact();
            String query = @"SELECT TOP 1 group_id,store_id,name,office_phone,home_phone,address,remarks FROM group_contacts WHERE id='" + Id + "';";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contact.Member_Id = Id;
                contact.Name = Convert.ToString(reader["name"]);
                contact.Group_Id = Convert.ToInt32(reader["group_id"]);
                if (reader["store_id"] != DBNull.Value)
                {
                    contact.Store_Id = Convert.ToInt32(reader["store_id"]);
                }
                else
                {
                    contact.Store_Id = -1;
                }
                contact.Office_Phone = Convert.ToString(reader["office_phone"]);
                contact.Home_Phone = Convert.ToString(reader["home_phone"]);
                contact.Address = Convert.ToString(reader["address"]);
                contact.Remarks = Convert.ToString(reader["remarks"]);
            }
            reader.Close();
            conn.Close();
            return contact;
        }
        public bool Delete_Contact(int Id)
        {
            bool result = false;

            String query = @"delete FROM group_contacts WHERE id='" + Id + "';";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            result = true;
            return result;
        }
    }
}
