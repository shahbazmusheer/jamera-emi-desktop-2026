using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Jamera.Items.Units
{
    class Units_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Units_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }

        public int Store(String NAME)
        {
            conn.Open();
            int result = -1;
            using (SqlCommand cmd = new SqlCommand("INSERT INTO item_units(name) values(@name) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@name", NAME);
                object obj =  cmd.ExecuteScalar();
                if(obj != DBNull.Value || obj != null)
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
            String query = @"SELECT MAX(id) from item_units;";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj) + 1;
            }
            conn.Close();
            return result;
        }
        public bool Update(int ID, String NAME)
        {
            conn.Open();
            bool result = false;
            using (SqlCommand cmd = new SqlCommand("UPDATE item_units SET name=@name WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", NAME);
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
            using (SqlCommand cmd = new SqlCommand("DELETE FROM  item_units WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }

        public Unit Get_Unit(int ID)
        {
            conn.Open();
            String query = @"SELECT id,name FROM item_units WHERE id='" + ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Unit unit = new Unit();
            while (reader.Read())
            {
                unit.Id = Convert.ToInt32(reader["id"]);
                unit.Name = Convert.ToString(reader["name"]);
            }
            reader.Close();
            conn.Close();
            return unit;
        }

        public bool Unit_Exists(String name)
        {
            conn.Open();
            bool result = false;
            String query = @"SELECT id FROM item_units WHERE name='" + name + "'";
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

        public bool Unit_Exists(int id, String name)
        {
            conn.Open();
            bool result = false;
            String query = @"SELECT id FROM item_units WHERE name='" + name + "' and id !='" + id + "'";
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
