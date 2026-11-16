using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Jamera.Aggrements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Jamera.Vouchers
{
    public partial class Cash_Vouchers_History_Master : DevExpress.XtraEditors.XtraUserControl
    {
        public int rowHandle = -1;
        public Cash_Vouchers_History_Master()
        {
            InitializeComponent();
            Update_Master_History_List();
        }

        private void ConfigureGrid()
        {
            gridView1.BeginUpdate();
            gridView1.GroupSummary.Clear();

            // Set Grouping
            gridView1.Columns["Area Code"].GroupIndex = 0;
            gridView1.Columns["Date"].GroupIndex = 1;

            // Summary for Received Amount
            GridGroupSummaryItem totalSum = new GridGroupSummaryItem();
            totalSum.FieldName = "Recieved Amt";
            totalSum.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            totalSum.DisplayFormat = "Sum = Rs. {0:#,##0.00}";
            totalSum.ShowInGroupColumnFooter = gridView1.Columns["Recieved Amt"];
            gridView1.GroupSummary.Add(totalSum);

            gridView1.OptionsView.ShowFooter = true;
            gridView1.ExpandAllGroups();
            gridView1.EndUpdate();
        }

        public void Update_Master_History_List(string filter = "", int recordsCount = 1)
        {
            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Name = "Query";

            // Updated SQL based on your requirement
            // Note: I added 'stores.id AS [StoreID]' to the subqueries so your filter logic still works.
            string rawSql = $@"
            SELECT TOP {recordsCount} * FROM (
                -- 1. MONTHLY RECOVERY ENTRIES (From Agreement Dues)
                SELECT 
                    stores.area_code AS [Area Code],
                    stores.id AS 'Store Id',
	                ad.id as 'Code',
	                'Aggrement Dues' as 'Source Table',
                    ad.paid_date AS [Date],
                    agg.ref_no AS [Ref.No],
                    ad.emi_no AS [EMI #],
                    agg.customer_id AS [Customer Code],
                    accounts.name AS [Customer],
                    ad.emi_date AS [Due Date],
                    CAST(ad.emi_amount AS VARCHAR) AS [Due Amount],
                    CASE 
                        WHEN (SELECT COUNT(*) FROM sale_items si WHERE si.agreement_id = agg.id) > 1 THEN -1
                        ELSE (SELECT TOP 1 item_id FROM sale_items WHERE agreement_id = agg.id)
                    END AS [Item Code],
                    CASE 
                        WHEN (SELECT COUNT(*) FROM sale_items si WHERE si.agreement_id = agg.id) > 1 THEN 
                             'Multiple (' + CAST((SELECT COUNT(*) FROM sale_items si WHERE si.agreement_id = agg.id) AS VARCHAR) + ')'
                        ELSE (SELECT TOP 1 itm_inner.name FROM sale_items si_inner JOIN items itm_inner ON si_inner.item_id = itm_inner.id WHERE si_inner.agreement_id = agg.id)
                    END AS [Item],
                    ad.paid_amount AS [Recieved Amt],
                    ad.balance AS [Balance],
                    'Monthly Installment Paid' AS [Description],
                    stores.id AS [StoreID],
                    CONVERT(DATETIME, ad.paid_date, 103) AS [SortDate]
                FROM dbo.aggrement_dues ad
                INNER JOIN dbo.aggrements agg ON ad.aggrement_id = agg.id
                INNER JOIN dbo.stores stores ON agg.store_id = stores.id
                INNER JOIN dbo.accounts accounts ON agg.customer_id = accounts.id
                WHERE ad.paid_amount > 0

                UNION ALL

                -- 2. ADVANCE PAYMENT ENTRIES (From Initial Agreement)
                SELECT 
                    stores.area_code AS [Area Code],
                    stores.id AS 'Store Id',
	                agg.id as 'Code',
	                'Aggrements' as 'Source Table',
                    CONVERT(VARCHAR, agg.date, 105) AS [Date],
                    agg.ref_no AS [Ref.No],
                    CAST(agg.emi_no AS VARCHAR) AS [EMI #],
                    agg.customer_id AS [Customer Code],
                    accounts.name AS [Customer],
                    'At Sale' AS [Due Date],
                    CAST(agg.advance_amount AS VARCHAR) AS [Due Amount],
                    CASE 
                        WHEN (SELECT COUNT(*) FROM sale_items si WHERE si.agreement_id = agg.id) > 1 THEN -1
                        ELSE (SELECT TOP 1 item_id FROM sale_items WHERE agreement_id = agg.id)
                    END AS [Item Code],
                    CASE 
                        WHEN (SELECT COUNT(*) FROM sale_items si WHERE si.agreement_id = agg.id) > 1 THEN 
                             'Multiple (' + CAST((SELECT COUNT(*) FROM sale_items si WHERE si.agreement_id = agg.id) AS VARCHAR) + ')'
                        ELSE (SELECT TOP 1 itm_inner.name FROM sale_items si_inner JOIN items itm_inner ON si_inner.item_id = itm_inner.id WHERE si_inner.agreement_id = agg.id)
                    END AS [Item],
                    agg.advance_amount AS [Recieved Amt],
                    agg.balance AS [Balance],
                    'Advance Paid' AS [Description],
                    stores.id AS [StoreID],
                    agg.date AS [SortDate]
                FROM dbo.aggrements agg
                INNER JOIN dbo.stores stores ON agg.store_id = stores.id
                INNER JOIN dbo.accounts accounts ON agg.customer_id = accounts.id
                WHERE agg.advance_amount > 0
            ) AS MasterHistory 
            {filter} 
            ORDER BY SortDate ASC, [EMI #] ASC, [Description] DESC";

            query.Sql = rawSql;
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.Fill();
            ConfigureGrid();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            List<string> filters = new List<string>();

            if (!string.IsNullOrWhiteSpace(ref_no_inp.Text))
                filters.Add($"[Ref.No] = '{ref_no_inp.Text}'");

            if (by_customer_check.Checked && customer_search_cmb.EditValue != null)
                filters.Add($"[Customer Code] = '{customer_search_cmb.EditValue}'");

            if (stores_check.Checked && stores_cmb.EditValue != null)
                filters.Add($"[StoreID] = '{stores_cmb.EditValue}'");

            if (item_chkbx.Checked && items_cmb.EditValue != null)
                filters.Add($"[Item Code] = '{items_cmb.EditValue}'");

            if (by_date_check.Checked)
            {
                // Note: Using SortDate for filtering because it is a proper DateTime type
                string start = from_date_picker.DateTime.ToString("yyyy-MM-dd 00:00:00");
                string end = to_date_picker.DateTime.ToString("yyyy-MM-dd 23:59:59");
                filters.Add($"SortDate >= '{start}' AND SortDate <= '{end}'");
            }

            string finalFilter = filters.Count > 0 ? " WHERE " + string.Join(" AND ", filters) : "";
            Update_Master_History_List(finalFilter, 5000);
        }

        // --- UI Logic (Checkbox handling) ---
        private void by_customer_check_CheckedChanged(object sender, EventArgs e)
        {
            customer_search_cmb.Enabled = by_customer_check.Checked;
            if (!by_customer_check.Checked) customer_search_cmb.EditValue = null;
        }

        private void stores_check_CheckedChanged(object sender, EventArgs e)
        {
            stores_cmb.Enabled = stores_check.Checked;
            if (!stores_check.Checked) stores_cmb.EditValue = null;
        }

        private void item_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            items_cmb.Enabled = item_chkbx.Checked;
            if (!item_chkbx.Checked) items_cmb.EditValue = null;
        }

        private void by_date_check_CheckedChanged(object sender, EventArgs e)
        {
            from_date_picker.Enabled = to_date_picker.Enabled = by_date_check.Checked;
            if (!by_date_check.Checked) { from_date_picker.EditValue = null; to_date_picker.EditValue = null; }
        }

        private void gridView1_GroupLevelStyle(object sender, GroupLevelStyleEventArgs e)
        {
            if (e.Level == 0) // Area
            {
                e.LevelAppearance.BackColor = Color.FromArgb(0, 34, 204);
                e.LevelAppearance.BackColor2 = Color.FromArgb(0, 153, 204);
                e.LevelAppearance.ForeColor = Color.White;
            }
            else if (e.Level == 1) // Date
            {
                e.LevelAppearance.BackColor = Color.FromArgb(221, 0, 221);
                e.LevelAppearance.BackColor2 = Color.FromArgb(255, 153, 102);
                e.LevelAppearance.ForeColor = Color.White;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.UpdateEMI();
        }

        private void UpdateEMI()
        {
            if (gridView1.DataRowCount > 0)
            {

                int rowHandle = gridView1.FocusedRowHandle;
                if (!(gridView1.IsGroupRow(rowHandle)))
                {
                    string emi = gridView1.GetFocusedRowCellValue(gridView1.Columns["EMI #"]).ToString();
                    int target_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue(gridView1.Columns["Code"]));
                    DateTime date = Convert.ToDateTime(gridView1.GetFocusedRowCellValue(gridView1.Columns["Date"]));
                    int store_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue(gridView1.Columns["Store Id"]));
                    string source = Convert.ToString(gridView1.GetFocusedRowCellValue(gridView1.Columns["Source Table"]));
                    int emi_no = (emi == "" || emi == null) ? -1 : Convert.ToInt32(emi);
                    this.rowHandle = rowHandle;
                    Update_EMI update_EMI = new Update_EMI(target_id, source);
                    update_EMI.cash_Vouchers_History_Master = this;
                    update_EMI.Show(this);

                }
            }
        }

        public void refreshData()
        {
            stores_check.Checked = false;
            by_date_check.Checked = false;
            item_chkbx.Checked = false;
            by_customer_check.Checked = false;
            ref_no_inp.Text = "";
            Update_Master_History_List();
            gridView1.Focus();
            if(rowHandle > -1) gridView1.FocusedRowHandle = rowHandle;
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void ref_no_inp_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ApplyFindFilter(ref_no_inp.Text);
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateEMI();
            }
        }
    }
}