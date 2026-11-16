using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.UI;
using Jamera.Aggrements;
using Jamera.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Jamera.Reports.Sales
{
    public partial class Sale_Details_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Sale_Details_Report(int store_id, String Start_Date, String End_Date, int item_id, bool check_returns_only = false)
        {
            InitializeComponent();
            // Load Company Settings
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            from_date.Value = Start_Date;
            to_date.Value = End_Date;

            string finalQuery = "";
            List<string> filters = new List<string>();

            if (check_returns_only)
            {
                // --- LOGIC FOR HISTORICAL RETURNS ---
                string baseReturnQuery = @"
            SELECT 
               stores.name as 'Area',
               ar.id as 'Code',
               '[Ret. Code: '+convert(varchar,ar.id)+']  -  [Date:'+convert(varchar(11),ar.return_date,105) + ']  -  [Ref.No:'+ISNULL(ar.ref_no,'')+']  -  [EMI.No:'+ISNULL(ar.emi_no,'')+']' as 'Agg.Details',
               '[Customer:'+accounts.name +']  -  [Fee Kept: ' +convert(varchar,ar.fee_kept)+']  -  [New.Bal: ' +convert(varchar,ar.new_balance)+']' as 'Sale Details',
               convert(varchar(11),ar.return_date,105) as 'Date',
               ar.ref_no as 'Ref.No', ar.emi_no as 'EMI.No',
               accounts.name as 'Customer', ar.aggrement_adv_amount as 'Advance', ar.new_balance as 'Agg.Balance', accounts.balance as 'Cust.Balance',
               items.id as 'Item.Code',
               items.name as 'Item',
               ari.sale_rate as 'Rate',
               0 as 'Sold', 
               ari.quantity as 'Returned',
               ari.sub_total as 'Total' 
            FROM agreement_returns ar
            LEFT JOIN accounts ON accounts.id = ar.customer_id 
            INNER JOIN dbo.stores stores ON stores.id = ar.store_id 
            INNER JOIN agreement_return_items ari ON ar.id = ari.aggrement_return_id 
            LEFT JOIN items ON ari.item_id = items.id";

                filters.Add($"CONVERT(DATETIME, ar.return_date, 103) >= CONVERT(DATETIME, '{Start_Date}', 103)");
                filters.Add($"CONVERT(DATETIME, ar.return_date, 103) <= CONVERT(DATETIME, '{End_Date}', 103)");

                if (store_id != -1) filters.Add($"ar.store_id = '{store_id}'");
                if (item_id != -1) filters.Add($"items.id = '{item_id}'");

                finalQuery = baseReturnQuery + " WHERE " + string.Join(" AND ", filters) + " ORDER BY ar.return_date DESC";
            }
            else
            {
                // --- LOGIC FOR STANDARD SALES ---
                string baseSaleQuery = @"
            SELECT 
               stores.name as 'Area',
               aggrements.id as 'Code',
               '[Agg. Code: '+convert(varchar,aggrements.id)+']  -  [Date:'+convert(varchar(11),aggrements.date,105) + ']  -  [Ref.No:'+ISNULL(aggrements.ref_no,'')+']  -  [EMI.No:'+ISNULL(convert(varchar,aggrements.emi_no),'')+']' as 'Agg.Details',
               '[Customer:'+accounts.name +']  -  [Agr.Advance: ' +convert(varchar,aggrements.advance_amount)+']  -  [Agr.Balance: ' +convert(varchar,aggrements.current_balance)+']  -  [Customer.Bal: '+convert(varchar,aggrements.current_balance)+']' as 'Sale Details',
               convert(varchar(11),aggrements.date,105) as 'Date',
               aggrements.ref_no as 'Ref.No', aggrements.emi_no as 'EMI.No',
               accounts.name as 'Customer', aggrements.advance_amount as 'Advance', aggrements.current_balance as 'Agg.Balance', accounts.balance as 'Cust.Balance',
               items.id as 'Item.Code',
               items.name as 'Item',
               sale_items.sale_rate as 'Rate',
               sold_qty as 'Sold', 
               returned_quantity as 'Returned',
               sale_items.net_total as 'Total' 
            FROM aggrements 
            LEFT JOIN accounts ON accounts.id = aggrements.customer_id 
            INNER JOIN dbo.stores stores ON stores.id = aggrements.store_id 
            LEFT JOIN sale_items ON aggrements.id = sale_items.agreement_id 
            LEFT JOIN items ON sale_items.item_id = items.id";

                filters.Add($"CONVERT(DATETIME, aggrements.date, 103) >= CONVERT(DATETIME, '{Start_Date}', 103)");
                filters.Add($"CONVERT(DATETIME, aggrements.date, 103) <= CONVERT(DATETIME, '{End_Date}', 103)");

                if (store_id != -1) filters.Add($"stores.id = '{store_id}'");
                if (item_id != -1) filters.Add($"items.id = '{item_id}'");

                finalQuery = baseSaleQuery + " WHERE " + string.Join(" AND ", filters) + " ORDER BY aggrements.ref_no ASC";
            }

            // 4. Update the SqlDataSource
            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Name = "Query";
            query.Sql = finalQuery;

            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }
        

    }
}
