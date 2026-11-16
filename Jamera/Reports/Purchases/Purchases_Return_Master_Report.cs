using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using Jamera.Properties;

namespace Jamera.Reports.Purchases
{
    public partial class Purchases_Return_Master_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Purchases_Return_Master_Report(String Start_Date,String End_Date)
        {
            InitializeComponent();
            from_date.Value = Start_Date;
            to_date.Value = End_Date;
            comany_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Sql = @"select CONVERT(VARCHAR,purchases.date,106) as 'Date',purchases.id as 'Ref.No',purchases.payment_method as 'Mode',accounts.name as 'Supplier',purchases.invoice_no as 'Invoice No',purchases.discount_rs as 'Discount',purchases.total_amount as 'Net Total'  from (dbo.purchases_return purchases  left  join dbo.accounts accounts on (accounts.id = purchases.supplier_id)) WHERE purchases.purchase_type='Purchase Return' and  CONVERT(DATETIME,purchases.date,105) >= CONVERT(DATETIME,'" + Start_Date + "',105) and CONVERT(DATETIME,purchases.date,105) <= CONVERT(DATETIME,'" + End_Date + "',105)";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

    }
}
