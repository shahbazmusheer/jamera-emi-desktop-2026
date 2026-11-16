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
namespace Jamera.Accounts
{
    public partial class Balance_Sheet : DevExpress.XtraEditors.XtraUserControl
    {
        DataTable accounts_table = new DataTable();
        SqlConnection conn = new SqlConnection();
        public Balance_Sheet()
        {
            InitializeComponent();
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
            date_picker.EditValue = DateTime.Now;

            Load_Data();
        }

        public void Load_Data()
        {
            accounts_table.Clear();
            this.Enabled = false;
            conn.Open();
            String query = @"SELECT ag.nature as 'Nature',ag.name as 'Head',jt.account_id as 'Code',jt.account_name as 'Account',(CASE WHEN ac.account_type='DR' THEN (SUM(jt.debit) - SUM(jt.credit)) ELSE (SUM(jt.credit) - SUM(jt.debit))END) as 'Balance' from journal_transactions as jt left join accounts as ac on jt.account_id=ac.id left join account_groups as ag on ac.account_group_id=ag.id WHERE(ag.nature='Asset' or ag.nature='Liability' or ag.nature='Equity') and ((jt.debit > 0) or (jt.credit > 0)) and DATEADD(dd,0,DATEDIFF(dd,0,jt.entry_date)) <= DATEADD(dd,0,DATEDIFF(dd,0,CONVERT(DATETIME,'"+date_picker.Text+"',103))) group by jt.account_id,jt.account_name,ag.nature,ag.name,ac.account_type;";
            SqlDataAdapter adp = new SqlDataAdapter(query,conn);
            adp.Fill(accounts_table);
            conn.Close();
            Double Assets_Sum = Convert.ToDouble(accounts_table.AsEnumerable().Where(row => row.Field<String>("Nature") == "Asset").Sum(row => row.Field<Decimal>("Balance")));
            Double Equities_Sum = Convert.ToDouble(accounts_table.AsEnumerable().Where(row => row.Field<String>("Nature") == "Equity").Sum(row => row.Field<Decimal>("Balance")));
            Double Liabilities_Sum = Convert.ToDouble(accounts_table.AsEnumerable().Where(row => row.Field<String>("Nature") == "Liability").Sum(row => row.Field<Decimal>("Balance")));
            Double Net_Income = (Assets_Sum - (Equities_Sum + Liabilities_Sum));
            DataRow dr = accounts_table.NewRow();
            dr["Nature"] = "Equity";
            dr["Head"] = "Shareholders Equity";
            dr["Code"] = DBNull.Value;
            dr["Account"] = "Net Income";
            dr["Balance"] = Net_Income;
            accounts_table.Rows.Add(dr);
            list.DataSource = accounts_table;
            total_assets_inp.Text = Assets_Sum.ToString();
            equities_liabilities_intp.Text = (Equities_Sum + Liabilities_Sum + Net_Income).ToString();
            this.Enabled = true;
            date_picker.Focus();
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            date_picker.EditValue = DateTime.Now;
            Load_Data();
        }

        private void gridView1_GroupLevelStyle(object sender, DevExpress.XtraGrid.Views.Grid.GroupLevelStyleEventArgs e)
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
                    //break;

            }
        }

        private void list_Click(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
        }

        private void list_Load(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            Load_Data();
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView1.Focus();
        }

        public void Controls_List(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || (e.KeyCode == Keys.Down && (date_picker.ContainsFocus || search_btn.ContainsFocus)))
            {
                gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
                gridView1.Focus();
            }
            if (e.KeyCode == Keys.F3 || (e.Control && e.KeyCode == Keys.F))
            {
                date_picker.Focus();
            }
            if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
            {
                date_picker.EditValue = DateTime.Now;
                Load_Data();
            }

        }

        private void date_picker_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void search_btn_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void total_assets_inp_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void equities_liabilities_intp_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }
    }
}
