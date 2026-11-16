using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Dues
{
    public partial class Area_Code_Wise_Defaulters_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Area_Code_Wise_Defaulters_Report(int store_id)
        {
            InitializeComponent();
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            //select stores.area_code as 'Area Code',aggrements.id as 'Agmt.Code',items.id as 'Item Code',items.name as 'Item',accounts.name as 'Customer', guardians.name as 'Guardian',aggrements.current_balance as 'Dues' from ((((dbo.aggrements aggrements left join dbo.accounts accounts on (accounts.id = aggrements.customer_id))  inner join dbo.stores stores on (stores.id = aggrements.store_id)) left join dbo.guardians guardians on (guardians.id = aggrements.guardian_id))  left join dbo.items items on (items.id = aggrements.item_id)) WHERE aggrements.status='Defaulter'
            if(store_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.area_code as 'Area Code',aggrements.id as 'Agmt.Code',accounts.name as 'Customer', guardians.name as 'Guardian',aggrements.current_balance as 'Balance' from ((((dbo.aggrements aggrements left join dbo.accounts accounts on (accounts.id = aggrements.customer_id))  inner join dbo.stores stores on (stores.id = aggrements.store_id)) left join dbo.guardians guardians on (guardians.id = aggrements.guardian_id)))   WHERE aggrements.status='Defaulter'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.area_code as 'Area Code',aggrements.id as 'Agmt.Code',accounts.name as 'Customer', guardians.name as 'Guardian',aggrements.current_balance as 'Balance' from ((((dbo.aggrements aggrements left join dbo.accounts accounts on (accounts.id = aggrements.customer_id))  inner join dbo.stores stores on (stores.id = aggrements.store_id)) left join dbo.guardians guardians on (guardians.id = aggrements.guardian_id)))   WHERE aggrements.status='Defaulter' and stores.id='" + store_id+"'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
        }

    }
}
