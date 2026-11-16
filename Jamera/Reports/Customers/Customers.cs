using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using Jamera.Properties;
namespace Jamera.Reports.Customers
{
    public partial class Customers : DevExpress.XtraReports.UI.XtraReport
    {
        public Customers(int store_id)
        {
            InitializeComponent();
            date_lbl.Value = DateTime.Now.ToString("dd-MM-yyyy");
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            other_info.Value = Settings.Default.company_other_info;
            if (store_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.area_code as 'Area Code',accounts.id as 'Code', accounts.name as 'Name',accounts.father_name as 'Father Name',accounts.age as 'Age',accounts.phone as 'Office Phone',accounts.home_phone as 'Home Phone',accounts.cost as 'Cast', accounts.profession as 'Profession',accounts.id_card_no as 'CNIC',accounts.business_address as 'Business Address',accounts.home_address as 'Home Address',accounts.balance from (dbo.accounts accounts left join dbo.stores stores  on (stores.id = accounts.store_id)) WHERE accounts.account_group_id='1002'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"select stores.area_code as 'Area Code',accounts.id as 'Code', accounts.name as 'Name',accounts.father_name as 'Father Name',accounts.age as 'Age',accounts.phone as 'Office Phone',accounts.home_phone as 'Home Phone',accounts.cost as 'Cast', accounts.profession as 'Profession',accounts.id_card_no as 'CNIC',accounts.business_address as 'Business Address',accounts.home_address as 'Home Address',accounts.balance from (dbo.accounts accounts left join dbo.stores stores  on (stores.id = accounts.store_id)) WHERE accounts.account_group_id='1002' and store_id='"+store_id+"'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
        }

    }
}
