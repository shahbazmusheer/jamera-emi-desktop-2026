using System;
using System.Drawing;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Reports.Recoveries
{
    public partial class Recovery_Master_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Recovery_Master_Report(int store_id, String Start_Date, String End_Date, int item_id)
        {
            InitializeComponent();

            // 1. Basic Setup
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            from_date.Value = Start_Date;
            to_date.Value = End_Date;

            // 2. Load Data
            LoadRecoveryPerformanceReport(Start_Date, End_Date, store_id);

        }

        private void ReportFooter_BeforePrint(object sender)
        {
            // This event fires just before the footer prints, when summaries are READY
            try
            {
                // --- CARDS PERCENTAGE (xrLabel18) ---
                // Get the final summary results from labels 20 and 19
                double totalCards = Convert.ToDouble(xrLabel20.Summary.GetResult() ?? 0);
                double recoveredCards = Convert.ToDouble(xrLabel19.Summary.GetResult() ?? 0);

                if (totalCards > 0)
                {
                    double ratio = (recoveredCards / totalCards) * 100;
                    xrLabel18.Text = ratio.ToString("0.00") + "%";
                    xrLabel18.BackColor = GetStatusColor(ratio);
                }
                else { xrLabel18.Text = "0.00%"; }

                // --- AMOUNT PERCENTAGE (xrLabel33) ---
                // Get the final summary results from labels 26 and 27
                double totalAmountDue = Convert.ToDouble(xrLabel26.Summary.GetResult() ?? 0);
                double recoveredAmount = Convert.ToDouble(xrLabel27.Summary.GetResult() ?? 0);

                if (totalAmountDue > 0)
                {
                    double ratio = (recoveredAmount / totalAmountDue) * 100;
                    xrLabel33.Text = ratio.ToString("0.00") + "%";
                    xrLabel33.BackColor = GetStatusColor(ratio);
                }
                else { xrLabel33.Text = "0.00%"; }
            }
            catch (Exception)
            {
                xrLabel18.Text = "0.00%";
                xrLabel33.Text = "0.00%";
            }
        }

        public void LoadRecoveryPerformanceReport(string Start_Date, string End_Date, int store_id = -1)
        {
            string storeFilter = (store_id != -1) ? $" AND st.id = {store_id}" : "";

            // If filtering by one store, we might want to hide the footer
            reportFooterBand1.Visible = (store_id == -1);
            string finalQuery = $@"
            SELECT 
                Area,

                -- 1. Cards Logic
                TotalCards,
                RecoveredCards,
                (TotalCards - RecoveredCards) as RemainingCards,

                CAST(
                    CASE 
                        WHEN TotalCards = 0 THEN 0 
                        ELSE (RecoveredCards * 100.0 / TotalCards) 
                    END 
                    AS NUMERIC(10,2)
                ) as CardRecoveryPercentage,

                -- 2. Amount Logic
                TotalDueAmount,
                RecoveredAmount,
                (TotalDueAmount - RecoveredAmount) as RemainingAmount,

                CAST(
                    CASE 
                        WHEN TotalDueAmount = 0 THEN 0 
                        ELSE (RecoveredAmount * 100.0 / TotalDueAmount) 
                    END 
                    AS NUMERIC(10,2)
                ) as AmountRecoveryPercentage

            FROM (
                SELECT 
                    st.name as 'Area',

                    -- Internal column for ordering
                    st.id as StoreID,

                    COALESCE(COUNT(DISTINCT ad.aggrement_id), 0) as TotalCards,

                    COALESCE(
                        COUNT(DISTINCT CASE 
                            WHEN ad.paid_amount > 0 
                            THEN ad.aggrement_id 
                        END), 
                        0
                    ) as RecoveredCards,

                    COALESCE(SUM(ad.emi_amount), 0) as TotalDueAmount,

                    COALESCE(SUM(ad.paid_amount), 0) as RecoveredAmount

                FROM aggrement_dues ad

                INNER JOIN aggrements ag 
                    ON ad.aggrement_id = ag.id

                INNER JOIN stores st 
                    ON ag.store_id = st.id

                WHERE CONVERT(DATETIME, ad.emi_date, 103) >= 
                        CONVERT(DATETIME, '{Start_Date}', 103)

                    AND CONVERT(DATETIME, ad.emi_date, 103) <= 
                        CONVERT(DATETIME, '{End_Date}', 103)

                    AND ad.is_return_fixed < 1

                    {storeFilter}

                GROUP BY 
                    st.id,
                    st.name

            ) as SummarySource

            ORDER BY StoreID ASC";

            string finalQueryOld = $@"
                SELECT 
                    Area,
                    -- 1. Cards Logic (COALESCE applied to Subquery outputs)
                    TotalCards,
                    RecoveredCards,
                    (TotalCards - RecoveredCards) as RemainingCards,
                    CAST(CASE WHEN TotalCards = 0 THEN 0 ELSE (RecoveredCards * 100.0 / TotalCards) END as NUMERIC(10,2)) as CardRecoveryPercentage,

                    -- 2. Amount Logic (COALESCE applied to Subquery outputs)
                    TotalDueAmount,
                    RecoveredAmount,
                    (TotalDueAmount - RecoveredAmount) as RemainingAmount,
                    CAST(CASE WHEN TotalDueAmount = 0 THEN 0 ELSE (RecoveredAmount * 100.0 / TotalDueAmount) END as NUMERIC(10,2)) as AmountRecoveryPercentage
                FROM (
                    SELECT 
                        st.name as 'Area',
                        -- Use COALESCE to ensure a 0 is returned if no records match
                        COALESCE(COUNT(DISTINCT ad.aggrement_id), 0) as TotalCards,
                        COALESCE(COUNT(DISTINCT CASE WHEN ad.paid_amount > 0 THEN ad.aggrement_id END), 0) as RecoveredCards,
                        COALESCE(SUM(ad.emi_amount), 0) as TotalDueAmount,
                        COALESCE(SUM(ad.paid_amount), 0) as RecoveredAmount
                    FROM aggrement_dues ad
                    INNER JOIN aggrements ag ON ad.aggrement_id = ag.id
                    INNER JOIN stores st ON ag.store_id = st.id
                WHERE CONVERT(DATETIME, ad.emi_date, 103) >= CONVERT(DATETIME, '{Start_Date}', 103)
                      AND CONVERT(DATETIME, ad.emi_date, 103) <= CONVERT(DATETIME, '{End_Date}', 103)
                      AND ad.is_return_fixed < 1
                      {storeFilter}
                GROUP BY st.name
                ) as SummarySource";

            sqlDataSource1.Queries.Clear();
            sqlDataSource1.Queries.Add(new CustomSqlQuery("Query", finalQuery));
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

        private void reportFooterBand1_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReportFooter_BeforePrint(sender);
        }

        private void Detail_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Get the percentages calculated in your SQL query for the current row
            double cardPerc = Convert.ToDouble(GetCurrentColumnValue("CardRecoveryPercentage") ?? 0);
            double amountPerc = Convert.ToDouble(GetCurrentColumnValue("AmountRecoveryPercentage") ?? 0);

            // Apply colors to the specific labels in the Detail Band
            // Note: Replace these names with your actual label names from the Report Explorer

            // Cards Row Labels (Top row in your detail)
            Color cardColor = GetStatusColor(cardPerc);
            //xrLabel13.BackColor = xrLabel14.BackColor = xrLabel15.BackColor = xrLabel23.BackColor = 
            xrLabel16.BackColor = cardColor;

            // Amount Row Labels (Bottom row in your detail)
            Color amtColor = GetStatusColor(amountPerc);
            //xrLabel6.BackColor = xrLabel5.BackColor = xrLabel4.BackColor = xrLabel7.BackColor =
            xrLabel3.BackColor = amtColor;
        }

        // 1. Helper method for the color logic
        private Color GetStatusColor(object value)
        {
            if (value == null || value == DBNull.Value) return Color.Transparent;

            double percentage = Convert.ToDouble(value);

            if (percentage < 70) return Color.MistyRose;        // Light Red
            else if (percentage <= 80) return Color.LightYellow;     // Light Yellow
            else if (percentage <= 90) return Color.LightSkyBlue;    // Light Blue
            else return Color.LightGreen;                            // Light Green
        }
    }
}