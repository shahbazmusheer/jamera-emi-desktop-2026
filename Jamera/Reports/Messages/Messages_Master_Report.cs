using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Messages
{
    public partial class Messages_Master_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Messages_Master_Report(String Start_Date,String End_Date)
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
            query.Sql = @"SELECT msg.date as 'Date',ac.id as 'Code',ac.name as 'Account',msg.to_number as 'Reciever Number',msg.message_text as 'Message' from messages as msg left join accounts as ac on msg.account_id=ac.id WHERE CONVERT(DATETIME,msg.date,103) >= CONVERT(DATETIME,'"+Start_Date+"',103) and CONVERT(DATETIME,msg.date,103) <= CONVERT(DATETIME,'"+End_Date+"',103)";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

    }
}
