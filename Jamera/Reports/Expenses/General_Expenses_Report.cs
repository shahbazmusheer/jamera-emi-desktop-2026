using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Expenses
{
    public partial class General_Expenses_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public General_Expenses_Report(String Start_Date,String End_Date)
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
            query.Sql = @"SELECT CONVERT(varchar(11),jt.entry_date,103) as 'Date',ac.id as 'Code',ac.name as 'Expense Account',jt.debit as 'Amount' from journal_transactions as jt left join accounts as ac on jt.account_id=ac.id left join account_groups as ag on ac.account_group_id=ag.id WHERE ag.nature='Expense' and ac.created_type='Custom' and jt.store_id IS NULL and  DATEADD(dd,0,jt.entry_date) >= DATEDIFF(dd,0,convert(datetime, '"+Start_Date+ "',103)) and  DATEADD(dd,0,jt.entry_date) <= DATEDIFF(dd,0,convert(datetime, '" + End_Date + "',103))";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

    }
}
