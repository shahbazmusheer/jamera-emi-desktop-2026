using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Jamera.Items.Groups
{
    class Item_Groups_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Item_Groups_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            conn = db_handler.GetDatabseConnection();
        }

        public int Store(String NAME, String DESCRIPTION)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO item_groups(name,description) values(@name,@description)  SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@description", DESCRIPTION);
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
            conn.Open();
            int result = -1;
            String query = @"SELECT MAX(id) from item_groups;";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj) + 1;
            }
            conn.Close();
            return result;
        }
        public bool Update(int ID, String NAME, String DESCRIPTION)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE item_groups SET name=@name,description=@description WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@description", DESCRIPTION);
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }

        public bool Delete(int ID)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM item_groups WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }

        //public Unit Get_Unit(int ID)
        //{
        //    String query = @"SELECT id,name FROM item_units WHERE id='" + ID + "'";
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    Unit unit = new Unit();
        //    while (reader.Read())
        //    {
        //        unit.Id = Convert.ToInt32(reader["id"]);
        //        unit.Name = Convert.ToString(reader["name"]);
        //    }
        //    reader.Close();
        //    return unit;
        //}

        public bool Exists(String name)
        {
            bool result = false;
            conn.Open();
            String query = @"SELECT id FROM item_groups WHERE name='" + name + "'";
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

        public bool Exists(int id, String name)
        {
            conn.Open();
            bool result = false;
            String query = @"SELECT id FROM item_groups WHERE name='" + name + "' and id !='" + id + "'";
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
    }
}
