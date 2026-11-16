using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
namespace Jamera.Reports.Dues
{
    public partial class Late_Customers_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Late_Customers_Report(int store_id)
        {
            InitializeComponent();
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            print_date.Value = DateTime.Now.ToString("dd-MM-yyyy");
            if(store_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.name as 'Area Code',accounts.id as 'Code',accounts.name as 'Name',accounts.phone as 'Office Phone',accounts.home_phone as 'Home Phone',aggrements.ref_no as 'Ref.No',a_d.emi_date as 'Due Date',a_d.emi_amount as 'Due Amount' from aggrement_dues as a_d left join aggrements on a_d.aggrement_id=aggrements.id right join accounts on aggrements.customer_id=accounts.id  left join stores on accounts.store_id=stores.id WHERE accounts.account_group_id='1002' and a_d.paid_amount <= 0 and  convert(datetime,a_d.emi_date,103) < convert(datetime,DATEADD(day,-1,GETDATE()),103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.name as 'Area Code',accounts.id as 'Code',accounts.name as 'Name',accounts.phone as 'Office Phone',accounts.home_phone as 'Home Phone',aggrements.ref_no as 'Ref.No',a_d.emi_date as 'Due Date',a_d.emi_amount as 'Due Amount' from aggrement_dues as a_d left join aggrements on a_d.aggrement_id=aggrements.id right join accounts on aggrements.customer_id=accounts.id  left join stores on accounts.store_id=stores.id WHERE accounts.store_id='"+store_id+ "' and accounts.account_group_id='1002' and a_d.paid_amount <= 0 and  convert(datetime,a_d.emi_date,103) < convert(datetime,DATEADD(day,-1,GETDATE()),103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }


        }

    }
}
