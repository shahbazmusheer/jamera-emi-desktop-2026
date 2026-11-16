using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamera.Employees.Commissions
{
    public partial class Items_Commission : DevExpress.XtraEditors.XtraUserControl
    {
        public Items_Commission()
        {
            InitializeComponent();

            sqlDataSource1.FillAsync();
        }

        private void create_new_btn_Click(object sender, EventArgs e)
        {
            Add_Commission add_Commission = new Add_Commission();
            add_Commission.Show(this);
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            search_inp.Text = "";
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
            list.Update();
        }

        private void search_inp_EditValueChanged(object sender, EventArgs e)
        {
            if (search_inp.ContainsFocus == true)
            {
                gridView1.ApplyFindFilter(search_inp.Text);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                Edit_Item_Commission edit_item_commission = new Edit_Item_Commission(Convert.ToInt32(gridView1.GetFocusedRowCellValue(gridView1.Columns["Code"])));
                edit_item_commission.Show(this);
            }
        }
    }
}
