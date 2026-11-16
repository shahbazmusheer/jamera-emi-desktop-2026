using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Stocks.Stocks_Transactions
{
    public partial class To_Store_Transactions_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public To_Store_Transactions_Report(String Start_Date,String End_Date,int store_id)
        {
            InitializeComponent();

            from_date.Value = Start_Date;
            to_date.Value = End_Date;
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            if(store_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT CONVERT(VARCHAR,st.date,103) as 'Date',to_stores.area_code as 'To Store',items.id as 'Code',items.name as 'Item',sti.stock_in as 'Stock In',sti.sold_out as 'Sold Out',sti.returned as 'Returned',sti.transfered as 'Transfered',(sti.stock_in - (sti.sold_out + sti.returned + sti.transfered)) as 'Available Stock' FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id left join stock_transaction_items as sti on sti.stock_transaction_id=st.id left join items on sti.item_id=items.id WHERE  CONVERT(DATETIME,st.date,105) >= CONVERT(DATETIME,'" + Start_Date + "',105) and CONVERT(DATETIME,st.date,105) <= CONVERT(DATETIME,'" + End_Date + "',105)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                //store wise search
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT CONVERT(VARCHAR,st.date,103) as 'Date',to_stores.area_code as 'To Store',items.id as 'Code',items.name as 'Item',sti.stock_in as 'Stock In',sti.sold_out as 'Sold Out',sti.returned as 'Returned',sti.transfered as 'Transfered',(sti.stock_in - (sti.sold_out + sti.returned + sti.transfered)) as 'Available Stock' FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id left join stock_transaction_items as sti on sti.stock_transaction_id=st.id left join items on sti.item_id=items.id WHERE  CONVERT(DATETIME,st.date,105) >= CONVERT(DATETIME,'" + Start_Date + "',105) and CONVERT(DATETIME,st.date,105) <= CONVERT(DATETIME,'" + End_Date + "',105) and to_stores.id='"+store_id+"'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            
        }

    }
}
