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

namespace Jamera.Messages
{
    public partial class My_Groups : DevExpress.XtraEditors.XtraUserControl
    {
        public My_Groups()
        {
            InitializeComponent();
            //sqlDataSource1.Fill();
        }

        private void create_new_btn_Click(object sender, EventArgs e)
        {
            search_inp.Focus();
            New_Group new_grp = new New_Group();
            new_grp.Show(this);
        }

        public void Refresh_Grid_Data()
        {
            search_inp.Text = null;
            this.Enabled = false;
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
            list.Update();
            this.Enabled = true;
            search_inp.Focus();
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            Refresh_Grid_Data();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue(gridView1.Columns[0]));
                Edit_Group edit_group = new Edit_Group(Id);
                edit_group.ShowDialog(this);
            }
        }

        private void search_inp_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.ApplyFindFilter(search_inp.Text);
        }

        public void Controls_List(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Down)
            {
                gridView1.Focus();
            }
            if ((e.KeyCode == Keys.F2 || e.KeyCode == Keys.Enter) && list.ContainsFocus == true)
            {
                if (gridView1.DataRowCount > 0)
                {
                    int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue(gridView1.Columns[0]));
                    Edit_Group edit_group = new Edit_Group(Id);
                    edit_group.ShowDialog(this);
                }
            }
            if (e.KeyCode == Keys.F3 || (e.Control && e.KeyCode == Keys.F))
            {
                search_inp.Focus();
            }
            if (e.KeyCode == Keys.F6 || (e.Control && e.KeyCode == Keys.N))
            {
                search_inp.Focus();
                New_Group new_grp = new New_Group();
                new_grp.Show(this);
            }
            if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
            {
                Refresh_Grid_Data();
            }

        }

        private void panelControl12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
