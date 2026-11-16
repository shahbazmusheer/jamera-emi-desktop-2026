using System;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using Jamera.Properties;

namespace Jamera.Reports.Sales
{
    public partial class Area_Wise_Sales_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Area_Wise_Sales_Report(int store_id, String Start_date, String End_date, int item_id)
        {
            InitializeComponent();

            // 1. Set Report Parameter Values for the Header
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            from_date.Value = Start_date;
            to_date.Value = End_date;

            // 2. Define the Base Query (Joins and Selections)
            // Note: We sum row-by-row to ensure different items/batches calculate correctly at store level
            string baseQuery = @"
                SELECT 
                    st.area_code as 'Area.Code',
                    st.name as 'Store',
                        -- 1. Net Quantity (Total units sold across all items in this store)
                        CONVERT(decimal(37,2), SUM(si.sold_qty)) as 'Total.Sales',
    
                        -- 1. Net Quantity (Total units sold across all items in this store)
                        CONVERT(decimal(37,2), SUM(si.returned_quantity)) as 'Sale.Returns',
    
                        -- 1. Net Quantity (Total units sold across all items in this store)
                        CONVERT(decimal(37,2), SUM(si.sold_qty - si.returned_quantity)) as 'Net.Sales'

                FROM sale_items AS si
                INNER JOIN aggrements AS ag ON si.agreement_id = ag.id
                INNER JOIN stores AS st ON ag.store_id = st.id
                LEFT JOIN purchase_items AS pi ON si.purchase_item_id = pi.id
                LEFT JOIN items AS itm ON si.item_id = itm.id";

            // 3. Build the dynamic WHERE clause
            List<string> filters = new List<string>();

            // Filter A: Date Range (Mandatory)
            filters.Add($"CONVERT(DATETIME, ag.date, 103) >= CONVERT(DATETIME, '{Start_date}', 103)");
            filters.Add($"CONVERT(DATETIME, ag.date, 103) <= CONVERT(DATETIME, '{End_date}', 103)");

            // Filter B: Specific Store (Optional)
            if (store_id != -1)
            {
                filters.Add($"st.id = '{store_id}'");
            }

            // Filter C: Specific Item (Optional)
            // Even in a store summary, we can filter to see the performance of a specific item across stores
            if (item_id != -1)
            {
                filters.Add($"si.item_id = '{item_id}'");
            }

            // 4. Combine into final SQL string with Grouping and Having
            string finalSql = baseQuery +
                             " WHERE " + string.Join(" AND ", filters) +
                             " GROUP BY st.name, st.area_code, st.id " +
                             " HAVING SUM(si.sold_qty - si.returned_quantity) > 0 " +
                             " ORDER BY st.id ASC";

            // 5. Update the Report Data Source
            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Name = "Query";
            query.Sql = finalSql;

            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }
    }
}