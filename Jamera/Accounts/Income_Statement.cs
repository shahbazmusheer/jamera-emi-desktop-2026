using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraGrid;
using DevExpress.Data;

namespace Jamera.Accounts
{
    public partial class Income_Statement : DevExpress.XtraEditors.XtraUserControl
    {
        public event CustomSummaryEventHandler CustomSummaryCalculate;
        public Income_Statement()
        {

            InitializeComponent();
            DateTime today_date = DateTime.Now;
            DateTime start_date;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            start_date = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = today_date;
            from_date_picker.EditValue = start_date;
            try
            {
                sqlDataSource1.Fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(sqlDataSource1.Connection.ConnectionString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void Income_Statement_Load(object sender, EventArgs e)
        {
            

        }

        private void Income_Statement_Shown(object sender, EventArgs e)
        {
            
        }

        private void ledger_search_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            DateTime today_date = DateTime.Now;
            DateTime start_date;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            start_date = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = today_date;


            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Sql = @"SELECT ag.nature as 'Nature',ag.name as 'Head',jt.account_id as 'Code',jt.account_name as 'Account',(CASE WHEN ac.account_type='DR' THEN (SUM(jt.debit) - SUM(jt.credit)) ELSE (SUM(jt.credit) - SUM(jt.debit))END) as 'Balance' from journal_transactions as jt left join accounts as ac on jt.account_id=ac.id left join account_groups as ag on ac.account_group_id=ag.id WHERE(ag.nature='Expense' or ag.nature='Revenue') and ((jt.debit > 0) or (jt.credit > 0)) and DATEADD(dd,0,DATEDIFF(dd,0,entry_date)) >= DATEADD(mm,DATEDIFF(mm,0,GETDATE()),0) and DATEADD(dd,0,DATEDIFF(dd,0,entry_date)) <= DATEADD(dd,0,DATEDIFF(dd,0,GETDATE()))  group by jt.account_id,jt.account_name,ag.nature,ag.name,ac.account_type;";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
            accounts_view.Update();
            this.Enabled = true;
            from_date_picker.Focus();

        }
        public void Set_Sum()
        {
            Double Total_Expenses = 0;
            Double Total_Revenues = 0;
            for (int i=0;i < gridView1.RowCount; i++)
            {
                if (gridView1.IsValidRowHandle(i))
                {
                    if(gridView1.GetRowCellValue(i,gridView1.Columns[0]).ToString() == "Expense")
                    {
                        Total_Expenses = Total_Expenses + Convert.ToDouble(gridView1.GetRowCellValue(i, gridView1.Columns["Balance"]));
                    }
                    if(gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString() == "Revenue")
                    {
                        Total_Revenues = Total_Revenues + Convert.ToDouble(gridView1.GetRowCellValue(i, gridView1.Columns["Balance"])); ;
                    }
                }
            }

            net_income_inp.Text = ( Total_Revenues - Total_Expenses ).ToString();
        }
        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            search_btn.Enabled = false;
            accounts_view.Visible = false;            
            accounts_view.Visible = true;
            search_btn.Enabled = true;

            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Sql = @"SELECT ag.nature as 'Nature',ag.name as 'Head',jt.account_id as 'Code',jt.account_name as 'Account',(CASE WHEN ac.account_type='DR' THEN (SUM(jt.debit) - SUM(jt.credit)) ELSE (SUM(jt.credit) - SUM(jt.debit))END) as 'Balance' from journal_transactions as jt left join accounts as ac on jt.account_id=ac.id left join account_groups as ag on ac.account_group_id=ag.id WHERE(ag.nature='Expense' or ag.nature='Revenue') and ((jt.debit > 0) or (jt.credit > 0)) and DATEADD(dd,0,DATEDIFF(dd,0,jt.entry_date)) >= DATEADD(dd,0,DATEDIFF(dd,0,CONVERT(DATETIME,'"+from_date_picker.Text+"',103))) and DATEADD(dd,0,DATEDIFF(dd,0,jt.entry_date)) <= DATEADD(dd,0,DATEDIFF(dd,0,CONVERT(DATETIME,'"+to_date_picker.Text+"',103))) group by jt.account_id,jt.account_name,ag.nature,ag.name,ac.account_type;";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
            accounts_view.Update();

            Set_Sum();
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView1.Focus();
        }

        private void gridView1_GroupLevelStyle(object sender, GroupLevelStyleEventArgs e)
        {
            switch (e.Level)
            {
                case 0:
                    e.LevelAppearance.Options.UseBackColor = true;
                    e.LevelAppearance.BackColor = Color.FromArgb(102, 51, 0);
                    e.LevelAppearance.ForeColor = Color.White;
                    e.LevelAppearance.BackColor2 = Color.FromArgb(255, 153, 51);
                    break;
                    //case 1:
                    //    e.LevelAppearance.Options.UseBackColor = true;
                    //    e.LevelAppearance.BackColor = Color.FromArgb(141, 180, 226);
                    //    break;
                    //case 2:
                    //    e.LevelAppearance.Options.UseBackColor = true;
                    //    e.LevelAppearance.BackColor = Color.FromArgb(197, 217, 241);
                    //    break;
                    //default:
                    //    //do nothing  
                    break;

            }
        }

        private void accounts_view_Load(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
        }

        private void accounts_view_Click(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //if (e.Column.FieldName == "")
            //{
            //    string strCellValue = View.GetRowCellDisplayText(e.RowHandle, View.Columns["XYZ"]);
            //    int inStockCol = e.RowHandle;
            //    if (!strCellValue.Equals("NA"))
            //    {
            //        double dblCellValue = Convert.ToDouble(strCellValue);

            //        if (dblCellValue < 0 || dblCellValue > 1000)
            //        {
            //            e.Appearance.BackColor = Color.Red;
            //            e.Appearance.BackColor2 = Color.LightPink;

            //        }
            //        else
            //        {
            //            e.Appearance.BackColor = Color.Green;
            //            e.Appearance.BackColor2 = Color.LightGreen;
            //        }
            //    }

            //}
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            Set_Sum();
        }

        public void Controls_List(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || (e.KeyCode == Keys.Down && (from_date_picker.ContainsFocus || to_date_picker.ContainsFocus || search_btn.ContainsFocus)))
            {
                gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
                gridView1.Focus();
            }
            if (e.KeyCode == Keys.F3 || (e.Control && e.KeyCode == Keys.F))
            {
                from_date_picker.Focus();
            }
            if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
            {
                this.Enabled = false;
                DateTime today_date = DateTime.Now;
                DateTime start_date;
                String month = today_date.Month.ToString();
                String year = today_date.Year.ToString();
                start_date = Convert.ToDateTime("01-" + month + "-" + year);
                to_date_picker.EditValue = today_date;


                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT ag.nature as 'Nature',ag.name as 'Head',jt.account_id as 'Code',jt.account_name as 'Account',(CASE WHEN ac.account_type='DR' THEN (SUM(jt.debit) - SUM(jt.credit)) ELSE (SUM(jt.credit) - SUM(jt.debit))END) as 'Balance' from journal_transactions as jt left join accounts as ac on jt.account_id=ac.id left join account_groups as ag on ac.account_group_id=ag.id WHERE(ag.nature='Expense' or ag.nature='Revenue') and ((jt.debit > 0) or (jt.credit > 0)) and DATEADD(dd,0,DATEDIFF(dd,0,entry_date)) >= DATEADD(mm,DATEDIFF(mm,0,GETDATE()),0) and DATEADD(dd,0,DATEDIFF(dd,0,entry_date)) <= DATEADD(dd,0,DATEDIFF(dd,0,GETDATE()))  group by jt.account_id,jt.account_name,ag.nature,ag.name,ac.account_type;";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
                accounts_view.Update();
                this.Enabled = true;
                from_date_picker.Focus();
            }

        }

        private void from_date_picker_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void to_date_picker_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void search_btn_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void accounts_view_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void net_income_inp_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }
    }
}
