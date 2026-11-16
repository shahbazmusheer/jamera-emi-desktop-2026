using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;
using System.Collections.Generic;
using DevExpress.XtraEditors;

namespace Jamera.Reports.Stocks
{
    public partial class Stock_Ledger_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Stock_Ledger_Report(int store_id,String Store_Name,String Start_date,String End_date)
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


            string sDate = Start_date;
            string eDate = Convert.ToDateTime(End_date).AddDays(1).ToShortDateString();

            // Update your Data Source Query
            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery baseQuery = new CustomSqlQuery();
            string query = $@"
            SELECT 
            itm.id AS [Item.Code],
            itm.name AS [Item],

            -- Opening Balance
            ISNULL(Opening.TotalIn, 0)
            + ISNULL(Opening.TotalSalesReturn, 0)
            - (
                ISNULL(Opening.TotalSold, 0)
                + ISNULL(Opening.TotalTransferred, 0)
              ) AS [Opening],

            -- Period Movements
            ISNULL(Period.InQty, 0) AS [Stock.In],
            ISNULL(Period.SoldQty, 0) AS [Sold],
            ISNULL(Period.RetQty, 0) AS [Sales.Return],
            ISNULL(Period.TransferredQty, 0) AS [Transferred],

            -- Closing Balance
            (
                ISNULL(Opening.TotalIn, 0)
                + ISNULL(Opening.TotalSalesReturn, 0)
                - (
                    ISNULL(Opening.TotalSold, 0)
                    + ISNULL(Opening.TotalTransferred, 0)
                  )
            )
            + ISNULL(Period.InQty, 0)
            + ISNULL(Period.RetQty, 0)
            - (
                ISNULL(Period.SoldQty, 0)
                + ISNULL(Period.TransferredQty, 0)
              ) AS [Remaining]

        FROM items itm

        CROSS APPLY
        (
            SELECT

                -- Opening Stock In
                (
                    SELECT SUM(ISNULL(stock_in, 0))
                    FROM stock_transaction_items
                    WHERE item_id = itm.id
                      AND store_id = '{store_id}'
                      AND CONVERT(DATETIME, [date], 105) < CONVERT(DATETIME, '{sDate}', 105)
                ) AS TotalIn,

                -- Opening Sold
                (
                    SELECT SUM(ISNULL(si.sold_qty, 0))
                    FROM sale_items si
                    INNER JOIN aggrements ag
                        ON si.agreement_id = ag.id
                    WHERE si.item_id = itm.id
                      AND ag.store_id = '{store_id}'
                      AND ag.date < CONVERT(DATETIME, '{sDate}', 105)
                ) AS TotalSold,

                -- Opening Sales Return
                (
                    SELECT SUM(ISNULL(ari.quantity, 0))
                    FROM agreement_return_items ari
                    INNER JOIN agreement_returns ar
                        ON ari.aggrement_return_id = ar.id
                    WHERE ari.item_id = itm.id
                      AND ar.store_id = '{store_id}'
                      AND ar.return_date < CONVERT(DATETIME, '{sDate}', 105)
                ) AS TotalSalesReturn,

                -- Opening Transferred
                -- Only stock_in is counted
                (
                    SELECT SUM(
                        CASE
                            WHEN ISNULL(sti.stock_in, 0) <> 0 THEN sti.stock_in
                            WHEN ISNULL(sti.returned, 0) <> 0 THEN sti.returned
                            ELSE 0
                        END
                    )
                    FROM stock_transaction_items sti
                    INNER JOIN stock_transactions st
                        ON sti.stock_transaction_id = st.id
                    WHERE sti.item_id = itm.id
                      AND st.from_store = '{store_id}'
                      AND CONVERT(DATETIME, st.date, 105) < CONVERT(DATETIME, '{sDate}', 105)
                ) AS TotalTransferred

        ) Opening

        CROSS APPLY
        (
            SELECT

                -- Stock In
                (
                    SELECT SUM(ISNULL(stock_in, 0))
                    FROM stock_transaction_items
                    WHERE item_id = itm.id
                      AND store_id = '{store_id}'
                      AND CONVERT(DATETIME, [date], 105) >= CONVERT(DATETIME, '{sDate}', 105)
                      AND CONVERT(DATETIME, [date], 105) < CONVERT(DATETIME, '{eDate}', 105)
                ) AS InQty,

                -- Sold
                (
                    SELECT SUM(ISNULL(si.sold_qty, 0))
                    FROM sale_items si
                    INNER JOIN aggrements ag
                        ON si.agreement_id = ag.id
                    WHERE si.item_id = itm.id
                      AND ag.store_id = '{store_id}'
                      AND ag.date >= CONVERT(DATETIME, '{sDate}', 105)
                      AND ag.date < CONVERT(DATETIME, '{eDate}', 105)
                ) AS SoldQty,

                -- Sales Return
                (
                    SELECT SUM(ISNULL(ari.quantity, 0))
                    FROM agreement_return_items ari
                    INNER JOIN agreement_returns ar
                        ON ari.aggrement_return_id = ar.id
                    WHERE ari.item_id = itm.id
                      AND ar.store_id = '{store_id}'
                      AND ar.return_date >= CONVERT(DATETIME, '{sDate}', 105)
                      AND ar.return_date < CONVERT(DATETIME, '{eDate}', 105)
                ) AS RetQty,

               -- Transferred
                -- Use stock_in first, otherwise returned
                (
                    SELECT SUM(
                        CASE
                            WHEN ISNULL(sti.stock_in, 0) <> 0 THEN sti.stock_in
                            WHEN ISNULL(sti.returned, 0) <> 0 THEN sti.returned
                            ELSE 0
                        END
                    )
                    FROM stock_transaction_items sti
                    INNER JOIN stock_transactions st
                        ON sti.stock_transaction_id = st.id
                    WHERE sti.item_id = itm.id
                      AND st.from_store = '{store_id}'
                      AND CONVERT(DATETIME, st.date, 105) >= CONVERT(DATETIME, '{sDate}', 105)
                      AND CONVERT(DATETIME, st.date, 105) < CONVERT(DATETIME, '{eDate}', 105)
                ) AS TransferredQty

        ) Period

        WHERE
               ISNULL(Opening.TotalIn, 0) > 0
            OR ISNULL(Period.InQty, 0) > 0
            OR ISNULL(Period.SoldQty, 0) > 0
            OR ISNULL(Period.RetQty, 0) > 0
            OR ISNULL(Period.TransferredQty, 0) > 0

        ORDER BY itm.list_order ASC;
        ";
            baseQuery.Sql = query; 
            string oldQuery= $@"
        SELECT 
    itm.id AS [Item.Code],
    itm.name AS [Item],

    -- Opening Balance
    ISNULL(Opening.TotalIn,0)
    + ISNULL(Opening.TotalSalesReturn,0)
    - (
        ISNULL(Opening.TotalSold,0)
        + ISNULL(Opening.TotalTransferred,0)
      ) AS [Opening],

    -- Period Movements
    ISNULL(Period.InQty,0) AS [Stock.In],
    ISNULL(Period.SoldQty,0) AS [Sold],
    ISNULL(Period.RetQty,0) AS [Sales.Return],
    ISNULL(Period.TransferredQty,0) AS [Transferred],

    -- Closing Balance
    (
        ISNULL(Opening.TotalIn,0)
        + ISNULL(Opening.TotalSalesReturn,0)
        - (
            ISNULL(Opening.TotalSold,0)
            + ISNULL(Opening.TotalTransferred,0)
          )
    )
    + ISNULL(Period.InQty,0)
    + ISNULL(Period.RetQty,0)
    - (
        ISNULL(Period.SoldQty,0)
        + ISNULL(Period.TransferredQty,0)
      ) AS [Remaining]

FROM items itm

CROSS APPLY
(
    SELECT

        -- Opening Stock In
        (
            SELECT SUM(stock_in)
            FROM stock_transaction_items
            WHERE item_id = itm.id
              AND store_id = '{store_id}'
              AND CONVERT(DATETIME,[date],105) < CONVERT(DATETIME,'{sDate}',105)
        ) AS TotalIn,

        -- Opening Sold
        (
            SELECT SUM(si.sold_qty)
            FROM sale_items si
            INNER JOIN aggrements ag
                ON si.agreement_id = ag.id
            WHERE si.item_id = itm.id
              AND ag.store_id = '{store_id}'
              AND ag.date < CONVERT(DATETIME,'{sDate}',105)
        ) AS TotalSold,

        -- Opening Sales Return
        (
            SELECT SUM(ari.quantity)
            FROM agreement_return_items ari
            INNER JOIN agreement_returns ar
                ON ari.aggrement_return_id = ar.id
            WHERE ari.item_id = itm.id
              AND ar.store_id = '{store_id}'
              AND ar.return_date < CONVERT(DATETIME,'{sDate}',105)
        ) AS TotalSalesReturn,

        -- Opening Transferred + Returned
        (
            SELECT SUM(ISNULL(sti.stock_in,0) + ISNULL(sti.returned,0))
            FROM stock_transaction_items sti
            INNER JOIN stock_transactions st
                ON sti.stock_transaction_id = st.id
            WHERE sti.item_id = itm.id
              AND st.from_store = '{store_id}'
              AND CONVERT(DATETIME,st.date,105) < CONVERT(DATETIME,'{sDate}',105)
        ) AS TotalTransferred

) Opening

CROSS APPLY
(
    SELECT

        -- Stock In
        (
            SELECT SUM(stock_in)
            FROM stock_transaction_items
            WHERE item_id = itm.id
              AND store_id = '{store_id}'
              AND CONVERT(DATETIME,[date],105) >= CONVERT(DATETIME,'{sDate}',105)
              AND CONVERT(DATETIME,[date],105) < CONVERT(DATETIME,'{eDate}',105)
        ) AS InQty,

        -- Sold
        (
            SELECT SUM(si.sold_qty)
            FROM sale_items si
            INNER JOIN aggrements ag
                ON si.agreement_id = ag.id
            WHERE si.item_id = itm.id
              AND ag.store_id = '{store_id}'
              AND ag.date >= CONVERT(DATETIME,'{sDate}',105)
              AND ag.date < CONVERT(DATETIME,'{eDate}',105)
        ) AS SoldQty,

        -- Sales Return
        (
            SELECT SUM(ari.quantity)
            FROM agreement_return_items ari
            INNER JOIN agreement_returns ar
                ON ari.aggrement_return_id = ar.id
            WHERE ari.item_id = itm.id
              AND ar.store_id = '{store_id}'
              AND ar.return_date >= CONVERT(DATETIME,'{sDate}',105)
              AND ar.return_date < CONVERT(DATETIME,'{eDate}',105)
        ) AS RetQty,

        -- Transferred + Returned
        (
            SELECT SUM(ISNULL(sti.stock_in,0) + ISNULL(sti.returned,0))
            FROM stock_transaction_items sti
            INNER JOIN stock_transactions st
                ON sti.stock_transaction_id = st.id
            WHERE sti.item_id = itm.id
              AND st.from_store = '{store_id}'
              AND CONVERT(DATETIME,st.date,105) >= CONVERT(DATETIME,'{sDate}',105)
              AND CONVERT(DATETIME,st.date,105) < CONVERT(DATETIME,'{eDate}',105)
        ) AS TransferredQty

) Period

WHERE
      ISNULL(Opening.TotalIn,0) > 0
   OR ISNULL(Period.InQty,0) > 0
   OR ISNULL(Period.SoldQty,0) > 0
   OR ISNULL(Period.RetQty,0) > 0
   OR ISNULL(Period.TransferredQty,0) > 0

ORDER BY itm.list_order ASC;";

            baseQuery.Name = "Query";
            sqlDataSource1.Queries.Add(baseQuery);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();

        }

    }
}
