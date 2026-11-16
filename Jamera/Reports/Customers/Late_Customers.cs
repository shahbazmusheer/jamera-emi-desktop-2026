using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jamera.Reports.Customers
{
    public partial class Late_Customers : DevExpress.XtraReports.UI.XtraReport
    {
        public Late_Customers(DateTime date, int minFrequency = 3, int store_id = -1, int customer_id = -1)
        {
            InitializeComponent();

            // Set Report Header Controls
            date_lbl.Value = date.ToString("dd-MM-yyyy");
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            other_info.Value = Settings.Default.company_other_info;

            LoadLateCustomersReport(date, minFrequency, store_id, customer_id);
        }

        public void LoadLateCustomersReport(DateTime reportDate, int minFrequency, int storeId = -1, int customerId = -1)
        {
            try
            {
                string dateStr = reportDate.ToString("dd-MM-yyyy");

                // 1. Build conditional filters
                string storeFilter = storeId != -1 ? $" AND st.id = {storeId}" : "";
                string customerFilter = customerId != -1 ? $" AND ag.customer_id = {customerId}" : "";

                // 2. The Updated SQL Query
                string finalQuery = $@"
                SELECT 
                    st.name as 'Store Name',
                    ag.rest_emi as 'Monthly EMI',
                    ag.ref_no as 'Ref.No',
                    cust.name as 'Customer',
                    cust.father_name as 'Father',
                    cust.phone as 'Office Phone',
                    cust.home_phone as 'Home Phone',
                    cust.id_card_no as 'CNIC',
                    ag.current_balance as 'Total Overdue', -- Entire remaining debt
                    
                    -- Late Details calculated via CROSS APPLY
                    LateInfo.LateMonths as 'Late Months Count',
                    LateInfo.SumLateAmount as 'Late Overdue Amount',
                    LateInfo.Duration as 'Duration'
                    
                FROM aggrements ag
                INNER JOIN accounts cust ON ag.customer_id = cust.id
                INNER JOIN stores st ON ag.store_id = st.id
                CROSS APPLY (
                    SELECT 
                        COUNT(ad.id) as LateMonths,
                        ISNULL(SUM(ad.emi_amount - ad.paid_amount), 0) as SumLateAmount,
                        -- Duration formatting: e.g., Jan-26 - Apr-26
                        FORMAT(MIN(CONVERT(DATETIME, ad.emi_date, 103)), 'MMM-yy') + ' - ' + 
                        FORMAT(MAX(CONVERT(DATETIME, ad.emi_date, 103)), 'MMM-yy') as Duration
                    FROM aggrement_dues ad
                    WHERE ad.aggrement_id = ag.id
                      AND ad.is_return_fixed < 1 -- Exclude adjustments
                      AND CONVERT(DATETIME, ad.emi_date, 103) <= CONVERT(DATETIME, '{dateStr}', 103)
                      
                      -- SILENT STREAK LOGIC: 
                      -- Only count months strictly AFTER the customer's last payment (paid_amount > 0)
                      AND CONVERT(DATETIME, ad.emi_date, 103) > ISNULL(
                          (SELECT MAX(CONVERT(DATETIME, inner_ad.emi_date, 103))
                           FROM aggrement_dues inner_ad
                           WHERE inner_ad.aggrement_id = ag.id 
                             AND inner_ad.paid_amount > 0 
                             AND inner_ad.is_return_fixed < 1
                             AND CONVERT(DATETIME, inner_ad.emi_date, 103) <= CONVERT(DATETIME, '{dateStr}', 103)),
                          -- If no payment was ever made, start from the day before the first installment
                          DATEADD(DAY, -1, (SELECT MIN(CONVERT(DATETIME, m.emi_date, 103)) 
                                            FROM aggrement_dues m WHERE m.aggrement_id = ag.id))
                      )
                ) AS LateInfo
                
                WHERE ag.status = 'In-Progress'
                  AND LateInfo.LateMonths >= {minFrequency} -- Streak filter
                  {storeFilter}
                  {customerFilter}
                  
                ORDER BY 
                    st.name ASC, 
                    -- Sort numerically by Year first (Middle part of Ref.No)
                    CAST(PARSENAME(REPLACE(ag.ref_no, '-', '.'), 2) AS INT) ASC,
                    -- Sort numerically by Serial Number (Last part of Ref.No)
                    CAST(PARSENAME(REPLACE(ag.ref_no, '-', '.'), 1) AS INT) ASC";

                // 3. Update SqlDataSource
                if (sqlDataSource1.Queries.Count > 0)
                    sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);

                CustomSqlQuery query = new CustomSqlQuery();
                query.Name = "Query";
                query.Sql = finalQuery;

                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error generating continuous late report: " + ex.Message, "Report Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
    }
}