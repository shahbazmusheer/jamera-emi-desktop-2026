using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace Jamera.Items.Stores
{
    class Stores_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Stores_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }

        public Store_Item Get_Current_Stock_Item(int ITEM_ID,int STORE_ID)
        {
            conn.Open();
            Store_Item store_item = new Store_Item();
            String query = "SELECT TOP 1 sti.id,sti.purchase_item_id,sti.stock_transaction_id,sti.purchase_id,sti.purchase_rate,sti.sale_rate,sti.stock_in, sti.sold_out,sti.returned,sti.transfered FROM stock_transaction_items as sti WHERE sti.item_id='" + ITEM_ID + "' and sti.store_id='" + STORE_ID + "' and sti.stock_in > (sti.sold_out + sti.returned + sti.transfered)";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                store_item.Store_Item_Id = Convert.ToInt32(reader["id"]);
                store_item.Purchase_Item_Id = Convert.ToInt32(reader["purchase_item_id"]);
                store_item.Stock_Transaction_Id = Convert.ToInt32(reader["stock_transaction_id"]);
                store_item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                store_item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                store_item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                store_item.Stock_in = Convert.ToDouble(reader["stock_in"]);
                store_item.Sold_out = Convert.ToDouble(reader["sold_out"]);
                store_item.Returned_Items = Convert.ToDouble(reader["returned"]);
                store_item.Transfered_Items = Convert.ToDouble(reader["transfered"]);
                store_item.Item_Id = ITEM_ID;
            }
            reader.Close();
            conn.Close();
            return store_item;
        }

        public Store_Item Get_Current_Stock_Item_By_Sale_Rate(int ITEM_ID, int STORE_ID,Double Sale_Rate)
        {
            conn.Open();
            Store_Item store_item = new Store_Item();
            String query = "SELECT TOP 1 sti.id,sti.item_id,items.model_id,sti.purchase_item_id,sti.stock_transaction_id,sti.purchase_id,sti.purchase_rate,sti.sale_rate,sti.stock_in, sti.sales_return, sti.sold_out,sti.returned,sti.transfered FROM stock_transaction_items as sti left join items on sti.item_id=items.id WHERE sti.item_id='" + ITEM_ID + "' and sti.store_id='" + STORE_ID + "' and sti.sale_rate='"+Sale_Rate+"' and (sti.stock_in + sti.sales_return) > (sti.sold_out + sti.returned + sti.transfered)";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                store_item.Store_Item_Id = Convert.ToInt32(reader["id"]);
                if(reader["model_id"] != DBNull.Value)
                {
                    store_item.Model_Id = Convert.ToInt32(reader["model_id"]);
                    //XtraMessageBox.Show(Convert.ToInt32(reader["model_id"]).ToString());
                }
                else
                {
                    store_item.Model_Id = -1;
                }
                store_item.Purchase_Item_Id = Convert.ToInt32(reader["purchase_item_id"]);
                store_item.Stock_Transaction_Id = Convert.ToInt32(reader["stock_transaction_id"]);
                store_item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                store_item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                store_item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                store_item.Stock_in = Convert.ToDouble(reader["stock_in"]);
                store_item.Sales_Return = Convert.ToDouble(reader["sales_return"]);
                store_item.Sold_out = Convert.ToDouble(reader["sold_out"]);
                store_item.Returned_Items = Convert.ToDouble(reader["returned"]);
                store_item.Transfered_Items = Convert.ToDouble(reader["transfered"]);
                store_item.Item_Id = Convert.ToInt32(reader["item_id"]); ;
            }
            reader.Close();
            conn.Close();
            return store_item;
        }
        public Available_Stock_Item_Value Get_Available_Item_Value(int ITEM_ID, int STORE_ID,Double Sale_Rate)
        {
            conn.Open();
            Available_Stock_Item_Value available_stock_value = new Available_Stock_Item_Value();
            String query = "SELECT SUM(sti.stock_in -  (sti.sold_out + sti.returned + sti.transfered)) as stock,(SUM(sti.stock_in -  (sti.sold_out + sti.returned + sti.transfered)) * sti.purchase_rate) as 'value' FROM items right join  stock_transaction_items as sti on items.id=sti.item_id WHERE sti.item_id='"+ITEM_ID+"' and sti.store_id='"+STORE_ID+"' and sti.sale_rate='"+Sale_Rate+"' group by items.id,sti.purchase_rate";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                available_stock_value.Item_Id = ITEM_ID;
                
                available_stock_value.Available_Stock= Convert.ToDouble(reader["stock"]);
                available_stock_value.Stock_Value = Convert.ToDouble(reader["value"]);
            }
            reader.Close();
            conn.Close();
            return available_stock_value;
        }
        public Store_Item Get_Stock_Item(int STOCK_TRSANACTIONS_ITEM_ID)
        {
            conn.Open();
            Store_Item store_item = new Store_Item();
            String query = "SELECT TOP 1 sti.id,sti.item_id,sti.purchase_item_id,sti.stock_transaction_id,sti.purchase_id,sti.purchase_rate,sti.sale_rate,sti.stock_in, sti.sold_out,sti.returned,sti.transfered FROM stock_transaction_items as sti WHERE sti.id='" + STOCK_TRSANACTIONS_ITEM_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                store_item.Item_Id = Convert.ToInt32(reader["id"]);
                store_item.Store_Item_Id = Convert.ToInt32(reader["item_id"]);
                store_item.Purchase_Item_Id = Convert.ToInt32(reader["purchase_item_id"]);
                store_item.Stock_Transaction_Id = Convert.ToInt32(reader["stock_transaction_id"]);
                store_item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                store_item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                store_item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                store_item.Stock_in = Convert.ToDouble(reader["stock_in"]);
                store_item.Sold_out = Convert.ToDouble(reader["sold_out"]);
                store_item.Returned_Items = Convert.ToDouble(reader["returned"]);
                store_item.Transfered_Items = Convert.ToDouble(reader["transfered"]);
            }
            reader.Close();
            conn.Close();
            return store_item;
        }

        public Store_Item Get_Current_Item_Sale_Rate(int ITEM_ID, int STORE_ID)
        {
            conn.Open();
            Store_Item store_item = new Store_Item();
            String query = "SELECT TOP 1 sti.id,sti.stock_transaction_id,sti.purchase_id,sti.purchase_rate,sti.sale_rate,sti.stock_in, sti.sold_out,sti.returned,sti.transfered FROM stock_transaction_items as sti WHERE sti.item_id='" + ITEM_ID + "' and sti.store_id='" + STORE_ID + "' and sti.stock_in > (sti.sold_out + sti.returned + sti.transfered)";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                store_item.Store_Item_Id = Convert.ToInt32(reader["id"]);
                store_item.Stock_Transaction_Id = Convert.ToInt32(reader["stock_transaction_id"]);
                store_item.Purchase_Id = Convert.ToInt32(reader["purchase_id"]);
                store_item.Purchase_Rate = Convert.ToDouble(reader["purchase_rate"]);
                store_item.Sale_Rate = Convert.ToDouble(reader["sale_rate"]);
                store_item.Stock_in = Convert.ToDouble(reader["stock_in"]);
                store_item.Sold_out = Convert.ToDouble(reader["sold_out"]);
                store_item.Returned_Items = Convert.ToDouble(reader["returned"]);
                store_item.Transfered_Items = Convert.ToDouble(reader["transfered"]);
            }
            reader.Close();
            conn.Close();
            return store_item;
        }

        public int Store(String NAME,String AREA_CODE,String COMPANY_NAME,String PHONE,String ADDRESS,String DESCRIPTION)
        {
            conn.Open();
            int result = -1;
            using (SqlCommand cmd = new SqlCommand("INSERT INTO stores(name,company_name,area_code,phone,address,description) values(@name,@company_name,@area_code,@phone,@address,@description) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@name",NAME);
                cmd.Parameters.AddWithValue("@area_code", AREA_CODE);
                cmd.Parameters.AddWithValue("@phone", PHONE);
                cmd.Parameters.AddWithValue("@company_name", COMPANY_NAME);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                cmd.Parameters.AddWithValue("@description", DESCRIPTION);
                Object obj = cmd.ExecuteScalar();
                if(obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }


        public bool Update(int ID, String NAME, String AREA_CODE,String COMPANY_NAME, String PHONE, String ADDRESS, String DESCRIPTION)
        {
            conn.Open();
            bool result = false;
            using (SqlCommand cmd = new SqlCommand("UPDATE stores SET name=@name,company_name=@company_name,area_code=@area_code,phone=@phone,address=@address,description=@description WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@area_code", AREA_CODE);
                cmd.Parameters.AddWithValue("@company_name", COMPANY_NAME);
                cmd.Parameters.AddWithValue("@phone", PHONE);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                cmd.Parameters.AddWithValue("@description", DESCRIPTION);
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
            using (SqlCommand cmd = new SqlCommand("DELETE FROM  stores WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }

        public Store Get_Store(int ID)
        {
            conn.Open();
            String query = @"SELECT id,name,address,company_name,phone,description,ref_prefix FROM stores WHERE id='"+ID+"'";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Store store = new Store();
            while (reader.Read())
            {
                store.Id = Convert.ToInt32(reader["id"]);
                store.Name = Convert.ToString(reader["name"]);
                if(reader["company_name"] != null)
                {
                    store.Company_Name = Convert.ToString(reader["company_name"]);
                }
                if (reader["phone"] != null)
                {
                    store.Phone = Convert.ToString(reader["phone"]);
                }
                store.Address = Convert.ToString(reader["address"]);
                store.Ref_Prefix = Convert.ToString(reader["ref_prefix"]);
                store.Description = Convert.ToString(reader["description"]);
            }
            reader.Close();
            conn.Close();
            return store;
        }

        public bool Store_Exists(String name)
        {
            conn.Open();
            bool result = false;
            String query = @"SELECT id FROM stores WHERE name='" + name + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object query_results = cmd.ExecuteScalar();
            if(query_results == DBNull.Value || query_results == null)
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

        public bool Store_Exists(int id,String name)
        {
            conn.Open();
            bool result = false;
            String query = @"SELECT name FROM stores WHERE name='" + name + "' and id !='"+id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            object query_results = cmd.ExecuteScalar();
            if (query_results != DBNull.Value && query_results != null)
            {
                if(Convert.ToString(query_results) == name)
                {
                    result = true;
                }
            }
            conn.Close();
            return result;
        }
    }
}
