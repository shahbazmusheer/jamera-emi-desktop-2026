using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Stocks.Stocks_Transactions
{
    public partial class Stock_Transactions_Mater_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Stock_Transactions_Mater_Report(String Start_Date,String End_Date)
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
            query.Sql = @"SELECT CONVERT(VARCHAR,st.date,103) as 'Date',st.id as 'Code',st.name as 'Name',from_stores.area_code as 'From Store',to_stores.area_code as 'To Store' FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id WHERE CONVERT(DATETIME,st.date,105) >= CONVERT(DATETIME,'" + Start_Date + "',105) and CONVERT(DATETIME,st.date,105) <= CONVERT(DATETIME,'" + End_Date + "',105)";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

    }
}
