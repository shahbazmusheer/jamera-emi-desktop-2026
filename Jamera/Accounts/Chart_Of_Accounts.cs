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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Jamera.Accounts
{
    public partial class Chart_Of_Accounts : DevExpress.XtraEditors.XtraUserControl
    {
        public Chart_Of_Accounts()
        {
            InitializeComponent();
            Accounts_DS.Fill();
        }

        private void create_new_btn_Click(object sender, EventArgs e)
        {
            search_inp.Focus();
            New_Account new_account = new New_Account();
            new_account.chart_of_accounts = this;
            UC_Opener_Form form = new UC_Opener_Form("New Account", new_account);
            form.Show(this);
        }
        private void Chart_Of_Accounts_Load(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            search_inp.Focus();
        }

        public void Refresh_Grid_Data()
        {
            this.Enabled = false;
            Accounts_DS.RebuildResultSchema();
            Accounts_DS.Fill();
            list.Update();
            this.Enabled = true;
            search_inp.Focus();
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            search_inp.Text = null;
            search_filter_cmb.SelectedIndex = 0;
            Refresh_Grid_Data();
        }

        private void list_Click(object sender, EventArgs e)
        {

        }
        //private void list_RowStyle(object sender,RowStyleEventArgs e)
        //{
        //    GridView View = sender as GridView;
        //    if (e.RowHandle >= 0)
        //    {
        //        string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Category"]);
        //        if (category == "Beverages")
        //        {
        //            e.Appearance.BackColor = Color.Salmon;
        //            e.Appearance.BackColor2 = Color.SeaShell;
        //            e.HighPriority = true;
        //        }
        //    }
        //}

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["account_groups_name"]);
                if (category != "")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }
        private void gridView1_RowStyle_1(object sender, RowStyleEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["nature"]);
            //    if (category !="")
            //    {
            //        e.Appearance.BackColor = Color.Salmon;
            //        e.Appearance.BackColor2 = Color.SeaShell;
            //        e.HighPriority = true;
            //    }
            //}
        }

        private void search_inp_EditValueChanged(object sender, EventArgs e)
        {
            if (search_filter_cmb.SelectedIndex == 0)
            {
                gridView1.OptionsFind.FindFilterColumns = "*";
            }
            else if (search_filter_cmb.SelectedIndex == 1)
            {
                gridView1.OptionsFind.FindFilterColumns = "Name";
            }
            else if (search_filter_cmb.SelectedIndex == 2)
            {
                gridView1.OptionsFind.FindFilterColumns = "Phone";

            }
            gridView1.ApplyFindFilter(search_inp.Text);
        }

        private void search_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                
            }
        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_filter_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            search_inp.Text = "";
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {

                GridHitInfo hitInfo = gridView1.CalcHitInfo((e as MouseEventArgs).Location);
                if (!(hitInfo.InGroupRow))
                {
                    if (gridView1.GetFocusedRowCellValue("Code") != DBNull.Value)
                    {
                        Accounts_Controller accounts_controller = new Accounts_Controller();
                        int ac_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Code"));
                        if (accounts_controller.Is_Account_Editable(ac_id) == true)
                        {
                            Edit_Account edit_accnt = new Edit_Account(ac_id);
                            edit_accnt.ShowDialog();
                        }
                        else
                        {
                            XtraMessageBox.Show("This is system created account. The account can not be modified !", "Access Denied");
                        }
                    }
                }
            }
        }

        private void list_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_GroupLevelStyle(object sender, GroupLevelStyleEventArgs e)
        {
            switch (e.Level)
            {
                case 0:
                    e.LevelAppearance.Options.UseBackColor = true;
                    e.LevelAppearance.BackColor = Color.FromArgb(102,51,0);
                    e.LevelAppearance.ForeColor = Color.White;
                    e.LevelAppearance.BackColor2 = Color.FromArgb(255,153,51);
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

        public void Controls_List(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || (e.KeyCode == Keys.Down && search_inp.ContainsFocus))
            {
                gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
                gridView1.Focus();
            }
            if ((e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter) && list.ContainsFocus == true)
            {
                if (gridView1.DataRowCount > 0)
                {
                    GridRowInfo hitInfo = new GridRowInfo(null,gridView1.FocusedRowHandle,0);
                    if (!(hitInfo.IsGroupRow))
                    {
                        if (gridView1.IsDataRow(gridView1.FocusedRowHandle) == true)
                        {
                            Accounts_Controller accounts_controller = new Accounts_Controller();
                            int ac_id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Code"));
                            if (accounts_controller.Is_Account_Editable(ac_id) == true)
                            {
                                Edit_Account edit_accnt = new Edit_Account(ac_id);
                                edit_accnt.ShowDialog();
                            }
                            else
                            {
                                XtraMessageBox.Show("This is system created account. The account can not be modified !", "Access Denied");
                            }
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.F3 || (e.Control && e.KeyCode == Keys.F))
            {
                search_inp.Focus();
            }
            if (e.KeyCode == Keys.F6 || (e.Control && e.KeyCode == Keys.N))
            {
                search_inp.Focus();
                UC_Opener_Form form = new UC_Opener_Form("New Account", new New_Account());
                form.Show(this);
            }
            if (e.KeyCode == Keys.F7)
            {
                search_filter_cmb.Focus();
                search_filter_cmb.ShowPopup();
            }
            if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
            {
                search_inp.Text = null;
                search_filter_cmb.SelectedIndex = 0;
                Refresh_Grid_Data();
            }

        }

        private void search_inp_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void search_filter_cmb_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void list_Click_1(object sender, EventArgs e)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
        }
    }
}
