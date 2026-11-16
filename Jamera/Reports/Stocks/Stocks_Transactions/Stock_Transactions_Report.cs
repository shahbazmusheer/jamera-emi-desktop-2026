using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;
using System.Collections.Generic;
using DevExpress.XtraEditors;

namespace Jamera.Reports.Stocks.Stocks_Transactions
{
    public partial class Stock_Transactions_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Stock_Transactions_Report(String Start_Date,String End_Date, String gatePassNo = "",int from_store_id = -2, int to_store_id = -2, int item_id = -1)
        {
            InitializeComponent();

            from_date.Value = Start_Date;
            to_date.Value = End_Date;
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            ExecuteResponsiveStockSearch(Convert.ToDateTime(Start_Date), Convert.ToDateTime(End_Date), gatePassNo, from_store_id, to_store_id, item_id);
            //if(store_id == -1)
            //{
            //    sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            //    CustomSqlQuery query = new CustomSqlQuery();
            //    query.Sql = @"SELECT CONVERT(VARCHAR,st.date,103) as 'Date',to_stores.area_code as 'To Store',items.id as 'Code',items.name as 'Item',sti.stock_in as 'Stock In',sti.sold_out as 'Sold Out',sti.returned as 'Returned',sti.transfered as 'Transfered',(sti.stock_in - (sti.sold_out + sti.returned + sti.transfered)) as 'Available Stock' FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id left join stock_transaction_items as sti on sti.stock_transaction_id=st.id left join items on sti.item_id=items.id WHERE  CONVERT(DATETIME,st.date,105) >= CONVERT(DATETIME,'" + Start_Date + "',105) and CONVERT(DATETIME,st.date,105) <= CONVERT(DATETIME,'" + End_Date + "',105)";
            //    query.Name = "Query";
            //    sqlDataSource1.Queries.Add(query);
            //    sqlDataSource1.RebuildResultSchema();
            //    sqlDataSource1.Fill();
            //}
            //else
            //{
            //    //store wise search
            //    sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            //    CustomSqlQuery query = new CustomSqlQuery();
            //    query.Sql = @"SELECT CONVERT(VARCHAR,st.date,103) as 'Date',to_stores.area_code as 'To Store',items.id as 'Code',items.name as 'Item',sti.stock_in as 'Stock In',sti.sold_out as 'Sold Out',sti.returned as 'Returned',sti.transfered as 'Transfered',(sti.stock_in - (sti.sold_out + sti.returned + sti.transfered)) as 'Available Stock' FROM stock_transactions as st left join stores as from_stores on st.from_store=from_stores.id left join stores as to_stores on st.to_store=to_stores.id left join stock_transaction_items as sti on sti.stock_transaction_id=st.id left join items on sti.item_id=items.id WHERE  CONVERT(DATETIME,st.date,105) >= CONVERT(DATETIME,'" + Start_Date + "',105) and CONVERT(DATETIME,st.date,105) <= CONVERT(DATETIME,'" + End_Date + "',105) and to_stores.id='"+store_id+"'";
            //    query.Name = "Query";
            //    sqlDataSource1.Queries.Add(query);
            //    sqlDataSource1.RebuildResultSchema();
            //    sqlDataSource1.Fill();
            //}
            
        }

        public void ExecuteResponsiveStockSearch(DateTime fromDate, DateTime toDate, string gatePassNo = "", int fromStoreId = -2, int toStoreId = -2, int itemId = -1)
        {
            // 1. Define SQL constant parts (using your new query)
            string selectPart = @"
        SELECT 
            CONVERT(DATETIME, st.date, 103) AS 'Date',

    '[Code: ' + CONVERT(VARCHAR, st.id) +
    '] - [Gatepass.No: ' + st.gate_pass_no +
    '] - [Name: ' + st.name +
    '] - [Remarks: ' + st.remarks + ']' AS 'Transaction Details',

    st.name AS 'Name',

    COALESCE(from_stores.name, 'Purchases (' + suppliers.name + ')') AS 'From.Store',
    from_stores.area_code AS 'From.Area.Code',

    COALESCE(to_stores.name, 'Purchases') AS 'To.Store',
    to_stores.area_code AS 'To.Area.Code',

    st.fuel_expenses_amount AS 'Fuel Exp',
    st.remarks AS 'Remarks',
    st.gate_pass_no AS 'Gatepass.No',
    ac.name AS 'Paid By',

    items.id AS 'Item.Code',
    items.name AS 'Item',
    models.name AS 'Model',

    -- Qty
    CASE
        WHEN SUM(ISNULL(sti.stock_in,0)) = 0
             AND st.to_store IS NULL
        THEN SUM(ISNULL(sti.returned,0))
        ELSE SUM(ISNULL(sti.stock_in,0))
    END AS 'Qty',

    SUM(ISNULL(sti.returned,0)) AS 'Returned',

    sti.remarks AS 'Item.Remarks' ";

            string joinPart = @"
        FROM stock_transactions AS st

LEFT JOIN stores AS from_stores
    ON st.from_store = from_stores.id

LEFT JOIN stores AS to_stores
    ON st.to_store = to_stores.id

LEFT JOIN accounts AS ac
    ON st.paid_by_ac_id = ac.id

INNER JOIN stock_transaction_items AS sti
    ON st.id = sti.stock_transaction_id

LEFT JOIN purchases AS p
    ON sti.purchase_id = p.id

LEFT JOIN accounts AS suppliers
    ON p.supplier_id = suppliers.id

LEFT JOIN items
    ON sti.item_id = items.id

LEFT JOIN item_models AS models
    ON items.model_id = models.id ";

            string groupByPart = @"
        GROUP BY
    st.date,
    st.id,
    st.name,
    st.remarks,
    st.gate_pass_no,
    from_stores.name,
    from_stores.area_code,
    to_stores.name,
    to_stores.area_code,
    suppliers.name,
    st.fuel_expenses_amount,
    ac.name,
    items.id,
    items.name,
    models.name,
    sti.remarks,
    st.to_store ";

            // 2. Build dynamic filters
            List<string> filters = new List<string>();

            // A. Item Filter
            if (itemId > -1)
            {
                filters.Add($"items.id = {itemId}");
            }

            // B. Responsive Store Logic
            var fStore = fromStoreId.ToString();
            var tStore = toStoreId.ToString();

            if (Convert.ToInt32(fStore) > -2 && (Convert.ToInt32(tStore) == -2))
            {
                if (Convert.ToInt32(fStore) == -1)
                {
                    fStore = "is null";
                }
                else
                {
                    fStore = "=" + fStore;
                }
                // Only From Store selected: check if it exists in either column
                filters.Add($"(st.from_store {fStore} OR st.to_store {fStore})");
            }
            else if (Convert.ToInt32(fStore) > -2 && Convert.ToInt32(tStore) > -2)
            {
                if (Convert.ToInt32(fStore) > -1)
                {
                    fStore = "=" + fStore;
                }
                else
                {
                    fStore = "is null";
                }
                if (Convert.ToInt32(tStore) > -1)
                {
                    tStore = "=" + tStore;
                }
                else
                {
                    tStore = "is null";
                }

                filters.Add($"(st.from_store {fStore} AND st.to_store {tStore})");
                // Both selected: Specific From -> To match
            }
            else if (Convert.ToInt32(tStore) > -2)
            {
                if (Convert.ToInt32(tStore) == -1) tStore = "is null";
                else { tStore = "=" + tStore; }
                // Only To Store selected
                filters.Add($"st.to_store {tStore}");
            }


            // C. Date Range Filter
            
            if (fromDate != null && toDate != null)
            {
                filters.Add($"(CONVERT(DATETIME, st.date, 103) >= CONVERT(DATETIME, '{fromDate}', 103) " +
                            $"AND CONVERT(DATETIME, st.date, 103) <= CONVERT(DATETIME, '{toDate}', 103))");
            }

            // D. Gate Pass Filter (Partial search)
            if (!string.IsNullOrEmpty(gatePassNo))
            {
                filters.Add($"st.gate_pass_no LIKE '%{gatePassNo}%'");
            }

            // 3. Assemble and Execute
            string whereClause = (filters.Count > 0) ? " WHERE " + string.Join(" AND ", filters) : "";
            string finalSql = selectPart + joinPart + whereClause + groupByPart + " ORDER BY CONVERT(DATETIME, st.date, 103) DESC, st.id DESC;";

            try
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Name = "Query";
                query.Sql = finalSql;
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Stock Transaction Search Failed: " + ex.Message);
            }
        }


    }
}
