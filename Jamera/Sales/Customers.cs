using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using Jamera.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamera.Sales
{
    public partial class Customers : DevExpress.XtraEditors.XtraUserControl
    {
        public Customers()
        {
            InitializeComponent();
            sqlDataSource1.Fill();
        }

        private void create_new_btn_Click(object sender, EventArgs e)
        {
            search_inp.Focus();
            UC_Opener_Form form = new UC_Opener_Form("New Customer",new New_Customer(-1));
            form.Show(this);
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            search_inp.Text = null;
            this.Enabled = false;
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
            list.Update();
            this.Enabled = true;
            search_inp.Focus();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                int ac_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Code"));
                Edit_Customer edit_customer = new Edit_Customer(ac_id);
                UC_Opener_Form uc_opener = new UC_Opener_Form("Edit Customer",edit_customer);
                edit_customer.uc_opener = uc_opener;
                uc_opener.Show();
            }
        }
        public void Controls_List(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Down)
            {
                gridView1.Focus();
            }
            if ((e.KeyCode == Keys.F2 || e.KeyCode==Keys.Enter) && list.ContainsFocus == true)
            {
                if (gridView1.DataRowCount > 0)
                {
                    int ac_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Code"));
                    Edit_Customer edit_customer = new Edit_Customer(ac_id);
                    UC_Opener_Form uc_opener = new UC_Opener_Form("Edit Customer", edit_customer);
                    edit_customer.uc_opener = uc_opener;
                    uc_opener.Show();
                }
            }
            if (e.KeyCode == Keys.F3 || (e.Control && e.KeyCode==Keys.F))
            {
                search_inp.Focus();
            }
            if((e.KeyCode == Keys.F6) || (e.Control && e.KeyCode == Keys.N))
            {
                UC_Opener_Form form = new UC_Opener_Form("New Customer", new New_Customer(-1));
                form.Show(this);
            }
            if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
            {
                search_inp.Text = null;
                this.Enabled = false;
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
                list.Update();
                this.Enabled = true;
                search_inp.Focus();
            }

        }

        private void search_inp_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ApplyFindFilter(search_inp.Text);
        }

        private void search_inp_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender,e);
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void print_customers_list_btn_Click(object sender, EventArgs e)
        {
            gridView1.ShowPrintPreview();
        }

        private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = false;
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
                case 1:
                    e.LevelAppearance.Options.UseBackColor = true;
                    e.LevelAppearance.BackColor = Color.FromArgb(128, 0, 128);
                    e.LevelAppearance.ForeColor = Color.White;
                    e.LevelAppearance.BackColor2 = Color.FromArgb(255, 153, 51);
                    break;
                    //case 2:
                    //    e.LevelAppearance.Options.UseBackColor = true;
                    //    e.LevelAppearance.BackColor = Color.FromArgb(197, 217, 241);
                    //    break;
                    //default:
                    //    //do nothing  
                    //break;

            }
        }

        private void stores_cmb_EditValueChanged(object sender, EventArgs e)
        {
            executeResponsiveSearch();
        }

        private void executeResponsiveSearch()
        {
            // 4. Update the SqlDataSource

            string finalSql = @"select stores.name as 'Store',accounts.id as 'Code', accounts.name as 'Name',       accounts.father_name as 'Father Name', 
                   accounts.age as 'Age',
                   accounts.phone as 'Office Phone', accounts.address as 'Permanent Address',
                   accounts.cost, accounts.profession as 'Profession',
                   accounts.id_card_no as 'CNIC',
                   accounts.business_address as 'Business Address',
                   accounts.home_address as 'Home Address',
                   accounts.home_phone as 'Home Phone',
                   accounts.remarks as 'Remarks',
                   accounts.balance
              from (dbo.accounts as accounts
              left join dbo.stores as stores
                   on (stores.id = accounts.store_id)) WHERE accounts.account_group_id='1002'
            ";

            if(stores_cmb.Text != "")
            {
                finalSql += " AND accounts.store_id = '"+Convert.ToInt32(stores_cmb.EditValue)+"'";
            }
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
                XtraMessageBox.Show("Search Error: " + ex.Message);
            }
        }
    }
}
