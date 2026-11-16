using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Stocks
{
    public partial class Stock_Inventory_Report_With_Value : DevExpress.XtraReports.UI.XtraReport
    {
        public Stock_Inventory_Report_With_Value(int store_id)
        {
            InitializeComponent();
            date_inp.Value = DateTime.Now.ToString("dd-MM-yyyy");
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            date_inp.Value = DateTime.Now.ToString("dd-MM-yyyy");
            if (store_id != -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT stores.area_code as 'Area Code', items.id as 'Code',items.name as 'Item',SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) as 'Available Stock',SUM(((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) * store_items.purchase_rate) as 'Stock Value'  from stock_transaction_items as store_items inner join items on items.id= store_items.item_id inner join stores on store_items.store_id=stores.id WHERE stores.id='" + store_id+ "' and ((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) > 0 group by items.id,items.name,stores.area_code,items.list_order order by items.list_order ASC;";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT stores.area_code as 'Area Code', items.id as 'Code',items.name as 'Item',SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) as 'Available Stock',SUM(((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) * store_items.purchase_rate) as 'Stock Value'  from stock_transaction_items as store_items inner join items on items.id= store_items.item_id inner join stores on store_items.store_id=stores.id WHERE ((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) > 0 group by items.id,items.name,stores.area_code,items.list_order order by items.list_order ASC;";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
        }

    }
}
