using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Data;

namespace Jamera.Items
{
    class Items_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Items_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }

        public int Store(String NAME, String UNICODE, Double PURCHASE_RATE , Double SALE_RATE , Double UNIT_COST , Double PACKING, int BARCODE_ID=-1, Byte PICTURE=Byte.MinValue,int UNIT_ID=-1,int GROUP_ID=-1,int CATEGORY_ID=-1,int MANUFACTURER_ID=-1,int DEFAULT_VENDOR_ID=-1,Double GST_PERCENT=0,Double SALE_DISCOUNT=0,Double REORDER_LEVEL=0,Double QUANTITY_DEMAND=0,bool IS_EXPIREABLE=false,bool IS_IMPORTED=false,bool IS_ACTIVE=true,bool IS_COUNTER_SALE=false,int RACK_ID=-1,Double LOCATION=-1,int Model_Id=-1, int NO_OF_INSTALLMENTS = 0, double ADVANCE_RATE = 0, double EMI_RATE = 0, double CASH_RATE = 0)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO items(name,unicode_name,barcode_id,picture,unit_id,packing,group_id,category_id,manufacturer_id,vendor_id,purchase_rate,advance_rate,emi_price, no_of_installments, cash_rate,sale_rate,unit_cost,gst,sale_discount,reorder_level,demand,is_expireable,is_imported,is_active,is_counter_sale,rack_id,location,model_id) values(@name,@unicode_name,@barcode_id,@picture,@unit_id,@packing,@group_id,@category_id,@manufacturer_id,@vendor_id,@purchase_rate,@advance_rate,@emi_price, @no_of_installments, @cash_rate,@sale_rate,@unit_cost,@gst,@sale_discount,@reorder_level,@demand,@is_expireable,@is_imported,@is_active,@is_counter_sale,@rack_id,@location,@model_id) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@unicode_name", UNICODE);
                cmd.Parameters.AddWithValue("@purchase_rate", PURCHASE_RATE);
                cmd.Parameters.AddWithValue("@advance_rate", ADVANCE_RATE);
                cmd.Parameters.AddWithValue("@emi_price", EMI_RATE);
                cmd.Parameters.AddWithValue("@no_of_installments", NO_OF_INSTALLMENTS);
                cmd.Parameters.AddWithValue("@cash_rate", CASH_RATE);
                cmd.Parameters.AddWithValue("@sale_rate", SALE_RATE);
                cmd.Parameters.AddWithValue("@unit_cost", UNIT_COST);
                cmd.Parameters.AddWithValue("@packing", PACKING);
                if (BARCODE_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@barcode_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@barcode_id", BARCODE_ID);
                }
                if (Model_Id == -1)
                {
                    cmd.Parameters.AddWithValue("@model_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@model_id", Model_Id);
                }
                if (PICTURE == Byte.MinValue)
                {
                    cmd.Parameters.AddWithValue("@picture", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@picture", PICTURE);
                }
                if(UNIT_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@unit_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@unit_id", UNIT_ID);
                }
                if (GROUP_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@group_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@group_id", GROUP_ID);
                }
                if (CATEGORY_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@category_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@category_id", CATEGORY_ID);
                }
                if (MANUFACTURER_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@manufacturer_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@manufacturer_id", MANUFACTURER_ID);
                }

                if (DEFAULT_VENDOR_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@vendor_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@vendor_id", DEFAULT_VENDOR_ID);
                }
                if (RACK_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@rack_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rack_id", RACK_ID);
                }
                if (LOCATION == -1)
                {
                    cmd.Parameters.AddWithValue("@location", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@location", LOCATION);
                }
                cmd.Parameters.AddWithValue("@gst", GST_PERCENT);
                cmd.Parameters.AddWithValue("@sale_discount", SALE_DISCOUNT);
                cmd.Parameters.AddWithValue("@reorder_level", REORDER_LEVEL);
                cmd.Parameters.AddWithValue("@demand", QUANTITY_DEMAND);
                cmd.Parameters.AddWithValue("@is_expireable", IS_EXPIREABLE);
                cmd.Parameters.AddWithValue("@is_imported", IS_IMPORTED);
                cmd.Parameters.AddWithValue("@is_active", IS_ACTIVE);
                cmd.Parameters.AddWithValue("@is_counter_sale",IS_COUNTER_SALE);

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
            String query = @"SELECT MAX(id) from items;";
            SqlCommand cmd = new SqlCommand(query, conn);
            object obj = cmd.ExecuteScalar();
            if (obj != DBNull.Value)
            {
                result = Convert.ToInt32(obj) + 1;
            }
            conn.Close();
            return result;
        }
        public bool Update(int ID,String NAME, String UNICODE, Double PURCHASE_RATE, Double SALE_RATE, Double UNIT_COST, Double PACKING, int BARCODE_ID = -1, Byte PICTURE = Byte.MinValue, int UNIT_ID = -1, int GROUP_ID = -1, int CATEGORY_ID = -1, int MANUFACTURER_ID = -1, int DEFAULT_VENDOR_ID = -1, Double GST_PERCENT = 0, Double SALE_DISCOUNT = 0, Double REORDER_LEVEL = 0, Double QUANTITY_DEMAND = 0, bool IS_EXPIREABLE = false, bool IS_IMPORTED = false, bool IS_ACTIVE = true, bool IS_COUNTER_SALE = false, int RACK_ID = -1, Double LOCATION = -1,int Model_Id=-1, int NO_OF_INSTALLMENTS = 0, double ADVANCE_RATE = 0, double EMI_RATE = 0, double CASH_RATE = 0)
        {
            conn.Open();
            bool result = false;
            using (SqlCommand cmd = new SqlCommand("UPDATE items SET name=@name,unicode_name=@unicode_name,barcode_id=@barcode_id,picture=@picture,unit_id=@unit_id,packing=@packing,group_id=@group_id,category_id=@category_id,manufacturer_id=@manufacturer_id,vendor_id=@vendor_id,purchase_rate=@purchase_rate,emi_price=@emi_price, advance_rate=@advance_rate, no_of_installments=@no_of_installments, cash_rate=@cash_rate,sale_rate=@sale_rate,unit_cost=@unit_cost,gst=@gst,sale_discount=@sale_discount,reorder_level=@reorder_level,demand=@demand,is_expireable=@is_expireable,is_imported=@is_imported,is_active=@is_active,is_counter_sale=@is_counter_sale,rack_id=@rack_id,location=@location,model_id=@model_id WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@unicode_name", UNICODE);
                cmd.Parameters.AddWithValue("@purchase_rate", PURCHASE_RATE);
                cmd.Parameters.AddWithValue("@advance_rate", ADVANCE_RATE);
                cmd.Parameters.AddWithValue("@emi_price", EMI_RATE);
                cmd.Parameters.AddWithValue("@no_of_installments", NO_OF_INSTALLMENTS);
                cmd.Parameters.AddWithValue("@cash_rate", CASH_RATE);
                cmd.Parameters.AddWithValue("@sale_rate", SALE_RATE);
                cmd.Parameters.AddWithValue("@unit_cost", UNIT_COST);
                cmd.Parameters.AddWithValue("@packing", PACKING);
                if (BARCODE_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@barcode_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@barcode_id", BARCODE_ID);
                }
                if (Model_Id == -1)
                {
                    cmd.Parameters.AddWithValue("@model_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@model_id", Model_Id);
                }
                if (PICTURE == Byte.MinValue)
                {
                    cmd.Parameters.AddWithValue("@picture", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@picture", PICTURE);
                }
                if (UNIT_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@unit_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@unit_id", UNIT_ID);
                }
                if (GROUP_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@group_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@group_id", GROUP_ID);
                }
                if (CATEGORY_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@category_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@category_id", CATEGORY_ID);
                }
                if (MANUFACTURER_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@manufacturer_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@manufacturer_id", MANUFACTURER_ID);
                }

                if (DEFAULT_VENDOR_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@vendor_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@vendor_id", DEFAULT_VENDOR_ID);
                }
                if (RACK_ID == -1)
                {
                    cmd.Parameters.AddWithValue("@rack_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@rack_id", RACK_ID);
                }
                if (LOCATION == -1)
                {
                    cmd.Parameters.AddWithValue("@location", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@location", LOCATION);
                }
                cmd.Parameters.AddWithValue("@gst", GST_PERCENT);
                cmd.Parameters.AddWithValue("@sale_discount", SALE_DISCOUNT);
                cmd.Parameters.AddWithValue("@reorder_level", REORDER_LEVEL);
                cmd.Parameters.AddWithValue("@demand", QUANTITY_DEMAND);
                cmd.Parameters.AddWithValue("@is_expireable", IS_EXPIREABLE);
                cmd.Parameters.AddWithValue("@is_imported", IS_IMPORTED);
                cmd.Parameters.AddWithValue("@is_active", IS_ACTIVE);
                cmd.Parameters.AddWithValue("@is_counter_sale", IS_COUNTER_SALE);
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
            using (SqlCommand cmd = new SqlCommand("DELETE FROM items WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }

        public bool Exists(String name,int Model_Id=-1)
        {
            conn.Open();
            bool result = false;
            String query = null;
            if (Model_Id == -1)
            {
                query = @"SELECT id FROM items WHERE name='" + name + "'  and model_id is NULL";
            }
            else
            {
                query = @"SELECT id FROM items WHERE name='" + name + "'  and model_id='"+Model_Id+"'";
            }
            
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

        public bool Exists(int id, String name,int Model_Id)
        {
            conn.Open();
            bool result = false;
            String query = null;
            if (Model_Id == -1)
            {
                query = @"SELECT id FROM items WHERE name='" + name + "' and id !='" + id + "'  and model_id is NULL";
            }
            else
            {
                query = @"SELECT id FROM items WHERE name='" + name + "' and id !='" + id + "'  and model_id ='"+Model_Id+"'";
            }
            
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

        public Item Get_Item(int item_Id)
        {
            conn.Open();
            Item item = new Item();
            String query = @"SELECT y.purchase_id,items.id as item_id, items.advance_rate, items.emi_price, items.no_of_installments, items.cash_rate,items.name as item_name,items.unicode_name as unicode_name,i_u.id as unit_id,i_u.name as unit_name,items.model_id,models.name as model_name,items.packing as packing,items.purchase_rate as purchase_rate,items.sale_rate as sale_rate,items.unit_cost as unit_cost,items.sale_discount as sale_discount,items.is_active as is_active,items.reorder_level as reorder_level ,i_m.id as manufacturer_id,i_m.name as manufacturer_name,i_g.id as group_id,i_g.name as group_name,i_g_s.id as category_id,i_g_s.name as category_name,COALESCE(SUM(y.items_stock_in - y.items_stock_out),0) as item_stock from items left join item_manufacturers  i_m on i_m.id=items.manufacturer_id left join item_groups  i_g on i_g.id=items.group_id left join item_categories as i_g_s on i_g_s.id=items.category_id left join item_units as i_u on i_u.id=items.unit_id left join purchase_items as y on items.id=y.item_id left join item_models as models on items.model_id=models.id  WHERE items.id='" + item_Id+ "' group by items.id ,items.name,items.unicode_name,i_u.id,i_u.name,items.packing,items.purchase_rate,items.sale_rate ,items.unit_cost,items.sale_discount,items.is_active,items.reorder_level ,i_m.id,i_m.name,i_g.id,i_g.name ,i_g_s.id,i_g_s.name,y.purchase_id,models.name,items.model_id,items.advance_rate, items.emi_price, items.no_of_installments, items.cash_rate ";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                item.Id = item_Id;
                item.Packing = Convert.ToDouble(reader["packing"]);
                item.Name = reader["item_name"].ToString();
                item.Unicode = reader["unicode_name"].ToString();
                if(reader["purchase_id"] != DBNull.Value)
                {
                    item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                }
                item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                item.Cash_Rate = Convert.ToDouble(reader["cash_rate"]);
                item.Advance_Price = Convert.ToDouble(reader["advance_rate"]);
                item.Monthly_EMI_Price = Convert.ToDouble(reader["emi_price"]);
                item.No_Of_Installments = Convert.ToDouble(reader["no_of_installments"]);
                item.Unit_Cost = Convert.ToDouble(reader["unit_cost"]);
                item.Sale_Discount = Convert.ToDouble(reader["sale_discount"]);
                item.Reorder_Level = Convert.ToDouble(reader["reorder_level"]);
                if(reader["is_active"].ToString() == "1")
                {
                    item.Is_Active = true;
                }
                else
                {
                    item.Is_Active = false;
                }
                if (reader["unit_id"] != DBNull.Value)
                {
                    item.Unit_Id = Convert.ToInt32(reader["unit_id"]);
                    item.Unit_Name = reader["unit_name"].ToString();
                }
                else
                {
                    item.Unit_Name = null;
                }
                if (reader["model_id"] != DBNull.Value)
                {
                    item.Model_Id = Convert.ToInt32(reader["model_id"]);
                    item.Model_Name = reader["model_name"].ToString();
                }
                else
                {
                    item.Model_Name = null;
                }
                if (reader["group_id"] != DBNull.Value)
                {
                    item.Group_id = Convert.ToInt32(reader["group_id"]);
                    item.Group_Name = reader["group_name"].ToString();
                }
                else
                {
                    item.Group_Name = null;
                }
                if (reader["manufacturer_id"] != DBNull.Value)
                {
                    item.Manufacturer_Id = Convert.ToInt32(reader["manufacturer_id"]);
                    item.Manufacturer_Name = reader["manufacturer_name"].ToString();
                }
                else
                {
                    item.Manufacturer_Name = null;
                }
                if (reader["category_id"] != DBNull.Value)
                {
                    item.Category_Id = Convert.ToInt32(reader["category_id"]);
                    item.Category_Name = reader["category_name"].ToString();
                }
                else
                {
                    item.Category_Name = null;
                }
            }
            reader.Close();
            conn.Close();
            return item;
        }

        public DataTable Get_Items_Table()
        {
            DataTable dt = new DataTable();

            // This query matches the column names you used in your Sales_Counter grid
            string query = @"SELECT 
                                id as 'Code', 
                                name as 'Name', 
                                sale_rate as 'Sale Rate',
                                1 as 'Qty' 
                             FROM items";

            try
            {
                using (SqlConnection connect = this.conn)
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connect))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error loading items: " + ex.Message);
            }

            return dt;
        }
    }
}
