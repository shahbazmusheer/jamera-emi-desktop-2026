using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Stocks.Stocks_Transactions
{
    public partial class Stock_Book_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Stock_Book_Report(String FROM_DATE,String TO_DATE,int FROM_STORE_ID,int TO_STORE_ID)
        {
            InitializeComponent();

            if (FROM_STORE_ID == -1 && TO_STORE_ID == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT purchases.date as 'Purchase Date',purchases.id as 'Purchase.Code',st.date as 'Trc.Date',st.id as 'Trc.Code',from_stores.name as 'From Store',to_stores.name as 'To Store',items.id as 'Item.Code',items.name as 'Item',sti.stock_in as 'Stock In',sti.sold_out as 'Sold Out',sti.transfered as 'Transfered',sti.returned as 'Returned',SUM(sti.stock_in - (sti.sold_out + sti.returned + sti.transfered)) as 'Final Stock' FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id left join stock_transaction_items as sti on st.id=sti.stock_transaction_id left join items on sti.item_id=items.id left join purchase_items as p_i on sti.purchase_item_id=p_i.id left join purchases on p_i.purchase_id=purchases.id group by purchases.date,purchases.id,st.date,st.id,from_stores.name,to_stores.name,items.id,items.name,sti.stock_in,sti.sold_out,sti.transfered,sti.returned";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else if (FROM_STORE_ID != -1 && TO_STORE_ID == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT purchases.date as 'Purchase Date',purchases.id as 'Purchase.Code',st.date as 'Trc.Date',st.id as 'Trc.Code',from_stores.name as 'From Store',to_stores.name as 'To Store',items.id as 'Item.Code',items.name as 'Item',sti.stock_in as 'Stock In',sti.sold_out as 'Sold Out',sti.transfered as 'Transfered',sti.returned as 'Returned',SUM(sti.stock_in - (sti.sold_out + sti.returned + sti.transfered)) as 'Final Stock' FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id left join stock_transaction_items as sti on st.id=sti.stock_transaction_id left join items on sti.item_id=items.id left join purchase_items as p_i on sti.purchase_item_id=p_i.id left join purchases on p_i.purchase_id=purchases.id WHERE st.from_store='"+FROM_STORE_ID+"' group by purchases.date,purchases.id,st.date,st.id,from_stores.name,to_stores.name,items.id,items.name,sti.stock_in,sti.sold_out,sti.transfered,sti.returned";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else if (FROM_STORE_ID == -1 && TO_STORE_ID != -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT purchases.date as 'Purchase Date',purchases.id as 'Purchase.Code',st.date as 'Trc.Date',st.id as 'Trc.Code',from_stores.name as 'From Store',to_stores.name as 'To Store',items.id as 'Item.Code',items.name as 'Item',sti.stock_in as 'Stock In',sti.sold_out as 'Sold Out',sti.transfered as 'Transfered',sti.returned as 'Returned',SUM(sti.stock_in - (sti.sold_out + sti.returned + sti.transfered)) as 'Final Stock' FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id left join stock_transaction_items as sti on st.id=sti.stock_transaction_id left join items on sti.item_id=items.id left join purchase_items as p_i on sti.purchase_item_id=p_i.id left join purchases on p_i.purchase_id=purchases.id WHERE st.to_store='" + TO_STORE_ID + "' group by purchases.date,purchases.id,st.date,st.id,from_stores.name,to_stores.name,items.id,items.name,sti.stock_in,sti.sold_out,sti.transfered,sti.returned";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else if (FROM_STORE_ID != -1 && TO_STORE_ID != -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT purchases.date as 'Purchase Date',purchases.id as 'Purchase.Code',st.date as 'Trc.Date',st.id as 'Trc.Code',from_stores.name as 'From Store',to_stores.name as 'To Store',items.id as 'Item.Code',items.name as 'Item',sti.stock_in as 'Stock In',sti.sold_out as 'Sold Out',sti.transfered as 'Transfered',sti.returned as 'Returned',SUM(sti.stock_in - (sti.sold_out + sti.returned + sti.transfered)) as 'Final Stock' FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id left join stock_transaction_items as sti on st.id=sti.stock_transaction_id left join items on sti.item_id=items.id left join purchase_items as p_i on sti.purchase_item_id=p_i.id left join purchases on p_i.purchase_id=purchases.id WHERE st.from_store='" + FROM_STORE_ID + "' and st.to_store='" + TO_STORE_ID + "'  group by purchases.date,purchases.id,st.date,st.id,from_stores.name,to_stores.name,items.id,items.name,sti.stock_in,sti.sold_out,sti.transfered,sti.returned";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
        }

    }
}
