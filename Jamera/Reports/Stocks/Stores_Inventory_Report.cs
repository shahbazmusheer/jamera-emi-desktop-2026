using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Stocks
{
    public partial class Stores_Inventory_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Stores_Inventory_Report(int store_id,int item_id)
        {
            InitializeComponent();

            print_date.Value = DateTime.Now.ToString("dd-MM-yyyy"); ;
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            if(store_id == -1 && item_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT stores.name as 'Area', items.id as 'Code',items.name as 'Item',SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered))as 'Available Stock'  from stock_transaction_items as store_items left join items on items.id= store_items.item_id left join stores on store_items.store_id=stores.id WHERE ((store_items.stock_in + store_items.sales_return ) - (store_items.sold_out + store_items.returned + store_items.transfered)) > 0 group by items.id,items.name,stores.name,items.list_order  ORDER BY items.id ASC;";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else if(store_id != -1 && item_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT stores.name as 'Area', items.id as 'Code',items.name as 'Item',SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered))as 'Available Stock'  from stock_transaction_items as store_items left join items on items.id= store_items.item_id left join stores on store_items.store_id=stores.id WHERE ((store_items.stock_in + store_items.sales_return ) - (store_items.sold_out + store_items.returned + store_items.transfered)) > 0 and stores.id='" + store_id+ "' group by items.id,items.name,stores.name,items.list_order  ORDER BY items.id ASC;";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else if (store_id == -1 && item_id != -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT stores.name as 'Area', items.id as 'Code',items.name as 'Item',SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered))as 'Available Stock'  from stock_transaction_items as store_items left join items on items.id= store_items.item_id left join stores on store_items.store_id=stores.id WHERE ((store_items.stock_in + store_items.sales_return ) - (store_items.sold_out + store_items.returned + store_items.transfered)) > 0 and store_items.item_id='" + item_id + "' group by items.id,items.name,stores.name,items.list_order  ORDER BY items.list_order ASC;";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else if (store_id != -1 && item_id != -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT stores.name as 'Area', items.id as 'Code',items.name as 'Item',SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered))as 'Available Stock'  from stock_transaction_items as store_items left join items on items.id= store_items.item_id left join stores on store_items.store_id=stores.id WHERE ((store_items.stock_in + store_items.sales_return ) - (store_items.sold_out + store_items.returned + store_items.transfered)) > 0 and stores.id='" + store_id + "' and store_items.item_id='" + item_id + "' group by items.id,items.name,stores.name, items.list_order ORDER BY items.list_order ASC;";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }

        }

        private void xrLabel10_BeforePrint(object sender, CancelEventArgs e)
        {
            
        }
    }
}
