using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Sales.Profit_Reports
{
    public partial class Sales_Profit_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Sales_Profit_Report(int store_id,String Start_Date,String End_Date,int item_id)
        {
            InitializeComponent();
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            from_date.Value = Start_Date;
            to_date.Value = End_Date;
            if (store_id != -1 && item_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.name 'Area',aggrements.id as 'Code','Date:'+convert(varchar(11),aggrements.date,105) + ' Ref.No:'+convert(varchar,aggrements.ref_no)+' Customer:'+accounts.name +' Agr.Balance:' +convert(varchar,aggrements.current_balance)+' Customer.Bal:'+convert(varchar,aggrements.current_balance) as 'Sale Details',items.id as 'Item.Code',items.name as 'Item',convert(decimal(10,2),(purchase_items.purchase_rate / items.packing)) as 'Unit Cost',sale_items.sale_rate as 'Rate',convert(decimal(10,2),(sale_items.sale_rate - (purchase_items.purchase_rate / items.packing))) as 'Unit Margin',sold_qty as 'Qty',convert(decimal(10,2),((sale_items.sale_rate - (purchase_items.purchase_rate / items.packing)) * sold_qty)) as 'Total Margin' from aggrements left join accounts on accounts.id = aggrements.customer_id inner join dbo.stores stores on (stores.id = aggrements.store_id) left join sale_items on aggrements.id=sale_items.agreement_id left join items on sale_items.item_id=items.id left join purchase_items on purchase_items.id=sale_items.purchase_item_id WHERE stores.id='" + store_id + "' and CONVERT(DATETIME,aggrements.date,103) >= CONVERT(DATETIME,'" + Start_Date + "',103) and CONVERT(DATETIME,aggrements.date,103) <= CONVERT(DATETIME,'" + End_Date + "',103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else if (store_id == -1 && item_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.name 'Area',aggrements.id as 'Code','Date:'+convert(varchar(11),aggrements.date,105) + ' Ref.No:'+convert(varchar,aggrements.ref_no)+' Customer:'+accounts.name +' Agr.Balance:' +convert(varchar,aggrements.current_balance)+' Customer.Bal:'+convert(varchar,aggrements.current_balance) as 'Sale Details',items.id as 'Item.Code',items.name as 'Item',convert(decimal(10,2),(purchase_items.purchase_rate / items.packing)) as 'Unit Cost',sale_items.sale_rate as 'Rate',convert(decimal(10,2),(sale_items.sale_rate - (purchase_items.purchase_rate / items.packing))) as 'Unit Margin',sold_qty as 'Qty',convert(decimal(10,2),((sale_items.sale_rate - (purchase_items.purchase_rate / items.packing)) * sold_qty)) as 'Total Margin' from aggrements left join accounts on accounts.id = aggrements.customer_id inner join dbo.stores stores on (stores.id = aggrements.store_id) left join sale_items on aggrements.id=sale_items.agreement_id left join items on sale_items.item_id=items.id left join purchase_items on purchase_items.id=sale_items.purchase_item_id WHERE aggrements.date >= CONVERT(DATETIME,'" + Start_Date + "',103) and aggrements.date <= CONVERT(DATETIME,'" + End_Date + "',103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else if (store_id == -1 && item_id != -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.name 'Area',aggrements.id as 'Code','Date:'+convert(varchar(11),aggrements.date,105) + ' Ref.No:'+convert(varchar,aggrements.ref_no)+' Customer:'+accounts.name +' Agr.Balance:' +convert(varchar,aggrements.current_balance)+' Customer.Bal:'+convert(varchar,aggrements.current_balance) as 'Sale Details',items.id as 'Item.Code',items.name as 'Item',convert(decimal(10,2),(purchase_items.purchase_rate / items.packing)) as 'Unit Cost',sale_items.sale_rate as 'Rate',convert(decimal(10,2),(sale_items.sale_rate - (purchase_items.purchase_rate / items.packing))) as 'Unit Margin',sold_qty as 'Qty',convert(decimal(10,2),((sale_items.sale_rate - (purchase_items.purchase_rate / items.packing)) * sold_qty)) as 'Total Margin' from aggrements left join accounts on accounts.id = aggrements.customer_id inner join dbo.stores stores on (stores.id = aggrements.store_id) left join sale_items on aggrements.id=sale_items.agreement_id left join items on sale_items.item_id=items.id left join purchase_items on purchase_items.id=sale_items.purchase_item_id WHERE items.id='" + item_id + "' and CONVERT(DATETIME,aggrements.date,103) >= CONVERT(DATETIME,'" + Start_Date + "',103) and CONVERT(DATETIME,aggrements.date,103) <= CONVERT(DATETIME,'" + End_Date + "',103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else if (store_id != -1 && item_id != -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.name 'Area',aggrements.id as 'Code','Date:'+convert(varchar(11),aggrements.date,105) + ' Ref.No:'+convert(varchar,aggrements.ref_no)+' Customer:'+accounts.name +' Agr.Balance:' +convert(varchar,aggrements.current_balance)+' Customer.Bal:'+convert(varchar,aggrements.current_balance) as 'Sale Details',items.id as 'Item.Code',items.name as 'Item',convert(decimal(10,2),(purchase_items.purchase_rate / items.packing)) as 'Unit Cost',sale_items.sale_rate as 'Rate',convert(decimal(10,2),(sale_items.sale_rate - (purchase_items.purchase_rate / items.packing))) as 'Unit Margin',sold_qty as 'Qty',convert(decimal(10,2),((sale_items.sale_rate - (purchase_items.purchase_rate / items.packing)) * sold_qty)) as 'Total Margin' from aggrements left join accounts on accounts.id = aggrements.customer_id inner join dbo.stores stores on (stores.id = aggrements.store_id) left join sale_items on aggrements.id=sale_items.agreement_id left join items on sale_items.item_id=items.id left join purchase_items on purchase_items.id=sale_items.purchase_item_id WHERE items.id='" + item_id + "' and stores.id='"+store_id+"' and CONVERT(DATETIME,aggrements.date,103) >= CONVERT(DATETIME,'" + Start_Date + "',103) and CONVERT(DATETIME,aggrements.date,103) <= CONVERT(DATETIME,'" + End_Date + "',103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
        }

    }
}
