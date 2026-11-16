using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Vouchers
{
    public partial class EMI_Vourchers_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public EMI_Vourchers_Report(String Start_Date,String End_Date)
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
            query.Sql = @"select  stores.area_code as 'Area Code',emi_vouchers.date as 'Date',emi_vouchers.start_serial as 'Start Serial',emi_vouchers.end_serial as 'End Serial',emi_vouchers.description as 'Description'  from (dbo.emi_vouchers emi_vouchers  left join dbo.stores stores on (stores.id = emi_vouchers.store_id)) WHERE convert(datetime,emi_vouchers.date,103) >= CONVERT(DATETIME,'"+Start_Date+"',103) and convert(datetime,emi_vouchers.date,103) <= CONVERT(DATETIME,'"+End_Date+"',103);";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

    }
}
