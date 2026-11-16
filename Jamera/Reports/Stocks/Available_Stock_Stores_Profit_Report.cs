using System;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Stocks
{
    public partial class Available_Stock_Stores_Profit_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Available_Stock_Stores_Profit_Report(int store_id, int item_id, string store_name = "All Stores")
        {
            InitializeComponent();

            // 1. Set Report Parameter Values for Header
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            other_info.Value = Settings.Default.company_other_info;
            date_lbl.Value = DateTime.Now.ToString("dd-MM-yyyy");
            store_lbl_para.Value = store_name;

            // 2. Define the Base Query
            string baseQuery = @"
                SELECT 
                    items.id as 'Code',
                    items.name as 'Item',
                    
                    -- 1. Total Available Stock
                    CONVERT(decimal(37,2), SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered))) as 'Available Stock',

                    -- 2. Weighted Average Purchase Rate
                    CONVERT(decimal(37,2), 
                        SUM(((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) * store_items.purchase_rate) / 
                        NULLIF(SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)), 0)
                    ) as 'Avg. Purchase Rate',

                    -- 3. Weighted Average Sale Rate
                    CONVERT(decimal(37,2), 
                        SUM(((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) * store_items.sale_rate) / 
                        NULLIF(SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)), 0)
                    ) as 'Avg. Sale Rate',

                    -- 4. PURCHASE VALUE (Available Stock * Purchase Rate)
                    CONVERT(decimal(37,2), 
                        SUM(((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) * store_items.purchase_rate)
                    ) as 'Purchase Value',

                    -- 5. TOTAL VALUE (Available Stock * Sale Rate)
                    CONVERT(decimal(37,2), 
                        SUM(((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) * store_items.sale_rate)
                    ) as 'Total Value',

                    -- 6. TOTAL PROFIT (Total Value - Purchase Value)
                    CONVERT(decimal(37,2), 
                        SUM(((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) * store_items.sale_rate) 
                        - 
                        SUM(((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) * store_items.purchase_rate)
                    ) as 'Expected Profit'

                FROM stock_transaction_items as store_items 
                LEFT JOIN items ON items.id = store_items.item_id 
                LEFT JOIN stores ON store_items.store_id = stores.id";

            // 3. Build dynamic filters
            List<string> filters = new List<string>();

            // Store Filter Logic
            if (store_id != -1)
            {
                filters.Add($"store_items.store_id = {store_id}");
            }
            else
            {
                filters.Add("stores.is_countable_in_reports = 1");
            }

            // Item Filter Logic
            if (item_id != -1)
            {
                filters.Add($"store_items.item_id = {item_id}");
            }

            // 4. Combine into final SQL string
            string whereClause = (filters.Count > 0) ? " WHERE " + string.Join(" AND ", filters) : "";

            string finalSql = baseQuery + whereClause +
                             @" GROUP BY items.id, items.name, items.list_order 
                                HAVING SUM((store_items.stock_in + store_items.sales_return) - (store_items.sold_out + store_items.returned + store_items.transfered)) > 0 
                                ORDER BY items.list_order ASC";

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