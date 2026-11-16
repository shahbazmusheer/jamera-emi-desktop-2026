using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using Jamera.Properties;
namespace Jamera.Reports.Salaries
{
    public partial class Employee_Wise_Salary_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Employee_Wise_Salary_Report(String From_Date,String To_Date,int Employee_Id)
        {
            InitializeComponent();

            from_date.Value = From_Date;
            to_date.Value = To_Date;
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;



            if (Employee_Id == -1)
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT ac.id as 'Emp.Code',ac.name as 'Emp.Name',e_s.pay_date as 'Paid Date',stores.name as 'Store',e_s.basic_salary'Basic Salary',e_s.bonus as 'Bonus',e_s.commission as 'Commission',e_s.advance_payment as 'Advance Payment',e_s.other_deductions as 'Other Duductons',e_s.net_salary as 'Net Salary' FROM employees_salaries e_s left join accounts as ac on e_s.account_id=ac.id right join stores on ac.store_id=stores.id WHERE CONVERT(DATETIME,e_s.pay_date,103) > CONVERT(DATETIME,'" + From_Date + "',103) and CONVERT(DATETIME,e_s.pay_date,103) < CONVERT(DATETIME,'" + To_Date + "',103)";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT ac.id as 'Emp.Code',ac.name as 'Emp.Name',e_s.pay_date as 'Paid Date',stores.name as 'Store',e_s.basic_salary'Basic Salary',e_s.bonus as 'Bonus',e_s.commission as 'Commission',e_s.advance_payment as 'Advance Payment',e_s.other_deductions as 'Other Duductons',e_s.net_salary as 'Net Salary' FROM employees_salaries e_s left join accounts as ac on e_s.account_id=ac.id right join stores on ac.store_id=stores.id WHERE CONVERT(DATETIME,e_s.pay_date,103) > CONVERT(DATETIME,'" + From_Date + "',103) and CONVERT(DATETIME,e_s.pay_date,103) < CONVERT(DATETIME,'" + To_Date + "',103) and e_s.account_id='"+Employee_Id+"'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
        }

    }
}
