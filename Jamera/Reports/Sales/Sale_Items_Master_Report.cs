using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;
using System.Collections.Generic;

namespace Jamera.Reports.Sales
{
    public partial class Sale_Items_Master_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Sale_Items_Master_Report(int store_id,String Store_Name,String Start_date,String End_date, int item_id = -1)
        {
            InitializeComponent();
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
             from_date.Value= Start_date;
            store_name.Value = Store_Name;
            to_date.Value = End_date;

            List<string> filters = new List<string>();

            // 1. Store Filter
            if (store_id != -1)
            {
                filters.Add("ag.store_id = " + store_id);
            }

            // 2. Item Filter
            if (item_id != -1)
            {
                filters.Add("itm.id = " + item_id);
            }

            // 3. Date Range
            if (!string.IsNullOrEmpty(Start_date) && !string.IsNullOrEmpty(End_date))
            {
                filters.Add($"(CONVERT(DATETIME, ag.date, 103) >= CONVERT(DATETIME, '{Start_date}', 103) " +
                            $"AND CONVERT(DATETIME, ag.date, 103) <= CONVERT(DATETIME, '{End_date}', 103))");
            }

            string whereClause = filters.Count > 0 ? " WHERE " + string.Join(" AND ", filters) : "";

            // Update your Data Source Query
            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery baseQuery = new CustomSqlQuery();
            baseQuery.Sql = @"
                SELECT itm.id as 'Item Code', itm.name as 'Item', 
                SUM(si.sold_qty) as 'Total Sale', 
                SUM(si.returned_quantity) as 'Sale Returns', 
                SUM(si.sold_qty - si.returned_quantity) as 'Net Sales'
                FROM sale_items si
                LEFT JOIN items itm ON si.item_id = itm.id
                LEFT JOIN aggrements ag ON si.agreement_id = ag.id
                LEFT JOIN stores st ON ag.store_id = st.id "
                + whereClause +
                " GROUP BY itm.id, itm.name,itm.list_order ORDER BY itm.list_order ASC";
            baseQuery.Name = "Query";
            sqlDataSource1.Queries.Add(baseQuery);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();

        }

    }
}
