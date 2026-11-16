using System;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Sales
{
    public partial class Item_Wise_Profit_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Item_Wise_Profit_Report(int store_id, String Store_Name, String Start_date, String End_date)
        {
            InitializeComponent();

            // 1. Set Report Parameter Values
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            from_date.Value = Start_date;
            to_date.Value = End_date;
            if (store_id == -1) {
                store_name.Value = "All Stores";
            }
            else
            {
                store_name.Value = Store_Name;
            }

                // 2. Define the Base Query with the new 'Total Value' logic
                string baseQuery = @"
                SELECT 
                    items.id as 'Item.Code',
                    items.name as 'Item',
                    CONVERT(decimal(37,2), (SUM(sale_items.sold_qty) - SUM(sale_items.returned_quantity))) as 'Qty',
                    
                    CONVERT(decimal(37,2), 
                        SUM((purchase_items.purchase_rate / items.packing) * (sale_items.sold_qty - sale_items.returned_quantity)) / 
                        NULLIF(SUM(sale_items.sold_qty - sale_items.returned_quantity), 0)
                    ) as 'Unit Cost(Per Item)',
                    
                    CONVERT(decimal(37,2), 
                        SUM(sale_items.sale_rate * (sale_items.sold_qty - sale_items.returned_quantity)) / 
                        NULLIF(SUM(sale_items.sold_qty - sale_items.returned_quantity), 0)
                    ) as 'Sale Rate(Per Item)',
                    
                    CONVERT(decimal(37,2), 
                        SUM(sale_items.sale_rate * (sale_items.sold_qty - sale_items.returned_quantity))
                    ) as 'Total Value',
                    
                    CONVERT(decimal(37,2), 
                        SUM(sale_items.sale_rate * (sale_items.sold_qty - sale_items.returned_quantity)) - 
                        SUM((purchase_items.purchase_rate / items.packing) * (sale_items.sold_qty - sale_items.returned_quantity))
                    ) as 'Total Margin'

                FROM sale_items 
                LEFT JOIN purchase_items ON sale_items.purchase_item_id = purchase_items.id 
                LEFT JOIN items ON items.id = sale_items.item_id 
                LEFT JOIN aggrements ON sale_items.agreement_id = aggrements.id";

            // 3. Build the dynamic WHERE clause
            List<string> filters = new List<string>();

            // Always filter by Date Range
            filters.Add($"CONVERT(DATETIME, aggrements.date, 103) >= CONVERT(DATETIME, '{Start_date}', 103)");
            filters.Add($"CONVERT(DATETIME, aggrements.date, 103) <= CONVERT(DATETIME, '{End_date}', 103)");

            // Conditional Filter: Store
            if (store_id != -1)
            {
                filters.Add($"aggrements.store_id = '{store_id}'");
            }

            // 4. Combine into final SQL string
            string finalSql = baseQuery +
                             " WHERE " + string.Join(" AND ", filters) +
                             " GROUP BY items.id, items.name, items.list_order " +
                             " HAVING (SUM(sale_items.sold_qty) - SUM(sale_items.returned_quantity)) > 0 " +
                             " ORDER BY items.list_order ASC";

            // 5. Update Data Source
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