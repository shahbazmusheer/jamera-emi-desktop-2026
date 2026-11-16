using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Stocks
{
    public partial class Low_Stock_At_Stores_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Low_Stock_At_Stores_Report(int store_id)
        {
            InitializeComponent();
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            date_inp.Value = DateTime.Now.ToString("dd-MM-yyyy");
            
            if(store_id == -1)
            {
                //SELECT stores.area_code as 'Area Code',stores.name as 'Store',items.id as 'Code',items.name as 'Item',(SUM(st.stock_in) - (SUM(st.sold_out) + SUM(st.returned) + SUM(st.transfered) )) as 'Stock',i_u.name as 'U.O.M' FROM items left join stock_transaction_items as st on items.id=st.item_id left join item_units as i_u on items.unit_id=i_u.id left join stores on st.store_id=stores.id WHERE items.id IN (SELECT CASE WHEN ((SUM(sti.stock_in) - (SUM(sti.sold_out) + SUM (sti.returned) + SUM(sti.transfered))) > 0) and store_id='501' THEN sti.item_id END FROM stock_transaction_items as sti group by sti.item_id,sti.store_id) GROUP BY items.id,items.name,st.stock_in,i_u.name,stores.name,stores.area_code
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT distinct stores.area_code as 'Area Code',stores.name as 'Store',items.id as 'Code',items.name as 'Item',(SUM(st.stock_in - st.sold_out + st.returned + st.transfered )) as 'Stock',i_u.name as 'U.O.M' FROM items left join stock_transaction_items as st on items.id=st.item_id left join item_units as i_u on items.unit_id=i_u.id left join stores on st.store_id=stores.id WHERE items.id IN (SELECT CASE WHEN ((SUM(sti.stock_in - sti.sold_out + sti.returned + sti.transfered)) < 5) THEN sti.item_id END FROM stock_transaction_items as sti group by sti.item_id,sti.store_id) GROUP BY items.id,items.name,i_u.name,stores.name,stores.area_code";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT distinct stores.area_code as 'Area Code',stores.name as 'Store',items.id as 'Code',items.name as 'Item',(SUM(st.stock_in - st.sold_out + st.returned + st.transfered )) as 'Stock',i_u.name as 'U.O.M' FROM items left join stock_transaction_items as st on items.id=st.item_id left join item_units as i_u on items.unit_id=i_u.id left join stores on st.store_id=stores.id WHERE items.id IN (SELECT CASE WHEN ((SUM(sti.stock_in - sti.sold_out + sti.returned + sti.transfered)) < 5) THEN sti.item_id END FROM stock_transaction_items as sti group by sti.item_id,sti.store_id) and stores.id='"+store_id+"' GROUP BY items.id,items.name,i_u.name,stores.name,stores.area_code";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
        }

    }
}
