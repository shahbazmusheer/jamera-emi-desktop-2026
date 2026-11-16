using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Sales
{
    public partial class Customer_Wise_Sales_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Customer_Wise_Sales_Report(int customer_id)
        {
            InitializeComponent();
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            if(customer_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select accounts.name as 'Customer',stores.area_code as 'Area Code',aggrements.id as 'Agmt.Code', guardians.name as 'Guardian',aggrements.current_balance as 'Dues',aggrements.status as 'Status' from ((((dbo.aggrements aggrements left join dbo.accounts accounts on (accounts.id = aggrements.customer_id))  inner join dbo.stores stores on (stores.id = aggrements.store_id)) left join dbo.guardians guardians on (guardians.id = aggrements.guardian_id)))";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select accounts.name as 'Customer',stores.area_code as 'Area Code',aggrements.id as 'Agmt.Code', guardians.name as 'Guardian',aggrements.current_balance as 'Dues',aggrements.status as 'Status' from ((((dbo.aggrements aggrements left join dbo.accounts accounts on (accounts.id = aggrements.customer_id))  inner join dbo.stores stores on (stores.id = aggrements.store_id)) left join dbo.guardians guardians on (guardians.id = aggrements.guardian_id))) WHERE accounts.id='"+customer_id+"'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
        }

    }
}
