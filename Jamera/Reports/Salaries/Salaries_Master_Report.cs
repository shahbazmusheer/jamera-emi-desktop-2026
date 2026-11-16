using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using Jamera.Properties;
namespace Jamera.Reports.Salaries
{
    public partial class Salaries_Master_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Salaries_Master_Report(String From_date,String To_Date,int store_id)
        {
            InitializeComponent();

            from_date.Value = From_date;
            to_date.Value = To_Date;
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            //SELECT stores.name as 'Store',e_s.pay_date as 'Paid Date',ac.id as 'Emp.Code',ac.name as 'Emp.Name',e_s.basic_salary'Basic Salary',e_s.bonus as 'Bonus',e_s.commission as 'Commission',e_s.advance_payment as 'Advance Payment',e_s.other_deductions as 'Other Duductons',e_s.net_salary as 'Net Salary',e_s.remarks as 'Remarks' FROM employees_salaries e_s left join accounts as ac on e_s.account_id=ac.id right join stores on ac.store_id=stores.id
            if (store_id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT stores.name as 'Store',e_s.pay_date as 'Paid Date',ac.id as 'Emp.Code',ac.name as 'Emp.Name',e_s.basic_salary'Basic Salary',e_s.bonus as 'Bonus',e_s.commission as 'Commission',e_s.advance_payment as 'Advance Payment',e_s.other_deductions as 'Other Duductons',e_s.net_salary as 'Net Salary',e_s.remarks as 'Remarks' FROM employees_salaries e_s left join accounts as ac on e_s.account_id=ac.id right join stores on ac.store_id=stores.id WHERE CONVERT(DATETIME,e_s.pay_date,103) > CONVERT(DATETIME,'"+From_date+"',103) and CONVERT(DATETIME,e_s.pay_date,103) < CONVERT(DATETIME,'"+To_Date+"',103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT stores.name as 'Store',e_s.pay_date as 'Paid Date',ac.id as 'Emp.Code',ac.name as 'Emp.Name',e_s.basic_salary'Basic Salary',e_s.bonus as 'Bonus',e_s.commission as 'Commission',e_s.advance_payment as 'Advance Payment',e_s.other_deductions as 'Other Duductons',e_s.net_salary as 'Net Salary',e_s.remarks as 'Remarks' FROM employees_salaries e_s left join accounts as ac on e_s.account_id=ac.id right join stores on ac.store_id=stores.id WHERE CONVERT(DATETIME,e_s.pay_date,103) > CONVERT(DATETIME,'" + From_date + "',103) and CONVERT(DATETIME,e_s.pay_date,103) < CONVERT(DATETIME,'" + To_Date + "',103) and stores.id='"+store_id+"'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            
        }

    }
}
