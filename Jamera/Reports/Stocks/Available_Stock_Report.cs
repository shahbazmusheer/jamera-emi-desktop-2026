using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;

namespace Jamera.Reports.Stocks
{
    public partial class Available_Stock_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Available_Stock_Report()
        {
            InitializeComponent();

            print_date.Value = DateTime.Now.ToString("dd-MM-yyyy"); ;
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Sql = @"SELECT  items.id as 'Code',items.name as 'Item',SUM(p_i.items_stock_in - (p_i.items_stock_out + p_i.returned_quantity)) as 'Available Stock' FROM purchase_items as p_i right join items on p_i.item_id=items.id group by items.id,items.name;";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

        private void xrTableCell12_BeforePrint(object sender, CancelEventArgs e)
        {
            //Decimal iVariance = Convert.ToDecimal(this.Report.GetCurrentColumnValue("Available Stock").ToString());
            //if (iVariance == 2)
            //{
            //    ((XRTableCell)sender).BackColor = Color.Red;
            //    ((XRTableCell)sender).ForeColor = Color.White;
            //}
            //else
            //{
            //    ((XRTableCell)sender).BackColor = Color.Lime;
            //    ((XRTableCell)sender).ForeColor = Color.Black;
            //}
        }
    }
}
