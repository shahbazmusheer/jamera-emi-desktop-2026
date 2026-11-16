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

namespace Jamera.Items
{
    public partial class Low_Stock : DevExpress.XtraEditors.XtraUserControl
    {
        //String Message_Title = "Error Alert";
        public Low_Stock()
        {
            InitializeComponent();
            sqlDataSource1.Fill();
        }

        private void Low_Stock_Load(object sender, EventArgs e)
        {
            search_inp.Focus();
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
            if (e.KeyCode == Keys.F3 || (e.Control && e.KeyCode == Keys.F))
            {
                search_inp.Focus();
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

        private void search_inp_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            Controls_List(sender, e);
        }
    }
}
