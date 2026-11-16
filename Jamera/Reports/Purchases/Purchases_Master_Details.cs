using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Purchases
{
    public partial class Purchases_Master_Details : DevExpress.XtraReports.UI.XtraReport
    {
        public Purchases_Master_Details(String Start_Date,String End_Date)
        {
            InitializeComponent();
            from_date.Value = Start_Date;
            to_date.Value = End_Date;
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Sql = @"select CONVERT(VARCHAR,purchases.date,106) as 'Date',accounts.name as 'Supplier',purchases.payment_method as 'Mode',items.name as 'Item',p_i.purchase_rate as 'Purchase Rate',p_i.sale_rate as 'Sale Rae',p_i.items_stock_in as 'Quantity',p_i.discount_rs as 'Discount',p_i.net_total as 'Sub Total'  from (dbo.purchases purchases  left  join dbo.accounts accounts on (accounts.id = purchases.supplier_id)) left join purchase_items as p_i on purchases.id=p_i.purchase_id left join items on p_i.item_id=items.id WHERE purchases.purchase_type='New Purchase' and CONVERT(DATETIME,purchases.date,105) >= CONVERT(DATETIME,'" + Start_Date + "',105) and CONVERT(DATETIME,purchases.date,105) <= CONVERT(DATETIME,'" + End_Date + "',105)";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

    }
}
