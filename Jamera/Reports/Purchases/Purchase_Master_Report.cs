using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera
{
    public partial class Purchase_Master_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Purchase_Master_Report(String Start_Date,String End_Date, int Supplier_ID = -1)
        {
            InitializeComponent();
            from_date.Value = Start_Date;
            to_date.Value = End_Date;
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            string suplier_filter = "";
            if (Supplier_ID != -1)
            { 
                suplier_filter = " and purchases.supplier_id = " + Supplier_ID;
            }

                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Sql = @"select CONVERT(VARCHAR,purchases.date,106) as 'Date',purchases.id as 'Ref.No',purchases.payment_method as 'Mode',accounts.name as 'Supplier',purchases.invoice_no as 'Invoice No',purchases.remarks as 'Remarks',purchases.discount_rs as 'Discount',purchases.total_amount as 'Net Total'  from (dbo.purchases purchases  left  join dbo.accounts accounts on (accounts.id = purchases.supplier_id)) WHERE purchases.purchase_type='New Purchase' and  CONVERT(DATETIME,purchases.date,105) >= CONVERT(DATETIME,'" + Start_Date+"',105) and CONVERT(DATETIME,purchases.date,105) <= CONVERT(DATETIME,'"+End_Date+"',105) "+suplier_filter + " ORDER BY CONVERT(DATETIME,purchases.date,105) ASC, purchases.invoice_no ASC";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

    }
}
