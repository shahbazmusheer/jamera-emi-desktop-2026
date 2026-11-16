using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Sales
{
    public partial class Sales_Master_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Sales_Master_Report(int store_id,String Start_Date,String End_Date)
        {
            InitializeComponent();
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            from_date.Value = Start_Date;
            to_date.Value = End_Date;
            if (store_id != -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.name as 'Area',convert(varchar(12),aggrements.date,105)  as 'Date',aggrements.ref_no as 'Ref.No',accounts.id as 'Cu.Code',accounts.name as 'Customer',guardians.name as 'Guarantor',aggrements.total_amount as 'Total',aggrements.advance_amount as 'Adv.Amount',aggrements.balance as 'Ag.Balance',aggrements.current_balance as 'Current Balance' from ((((dbo.aggrements aggrements left join dbo.accounts accounts on (accounts.id = aggrements.customer_id))  inner join dbo.stores stores on (stores.id = aggrements.store_id)) left join dbo.accounts guardians on (guardians.id = aggrements.guardian_id))) WHERE stores.id='" + store_id+ "' and CONVERT(DATETIME,aggrements.date,103) >= CONVERT(DATETIME,'" + Start_Date+ "',103) and CONVERT(DATETIME,aggrements.date,103) <= CONVERT(DATETIME,'" + End_Date + "',103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.name as 'Area',convert(varchar(12),aggrements.date,105)  as 'Date',aggrements.ref_no as 'Ref.No',accounts.id as 'Cu.Code',accounts.name as 'Customer',guardians.name as 'Guarantor',aggrements.total_amount as 'Total',aggrements.advance_amount as 'Adv.Amount',aggrements.balance as 'Ag.Balance',aggrements.current_balance as 'Current Balance' from ((((dbo.aggrements aggrements left join dbo.accounts accounts on (accounts.id = aggrements.customer_id))  inner join dbo.stores stores on (stores.id = aggrements.store_id)) left join dbo.accounts guardians on (guardians.id = aggrements.guardian_id))) WHERE aggrements.date >= CONVERT(DATETIME,'" + Start_Date + "',103) and aggrements.date <= CONVERT(DATETIME,'" + End_Date + "',103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
        }

    }
}
