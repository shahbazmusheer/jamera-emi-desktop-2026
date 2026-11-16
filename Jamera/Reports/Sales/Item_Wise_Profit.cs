using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace Jamera.Reports.Sales
{
    public partial class Item_Wise_Profit : DevExpress.XtraEditors.XtraForm
    {
        Item_Wise_Profit_Report item_wise_01_rpt;
        public Item_Wise_Profit()
        {
            InitializeComponent();

            item_wise_01_rpt = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.DateTime = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.DateTime = DateTime.Now;
            item_wise_01_rpt = new Item_Wise_Profit_Report(-1, null, from_date_picker.Text, to_date_picker.Text);
            item_wise_01_rpt.RequestParameters = false;
            documentViewer1.DocumentSource = item_wise_01_rpt;
            item_wise_01_rpt.CreateDocument();
            sqlDataSource1.Fill();
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(item_wise_01_rpt);
            print_tool.Print();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            item_wise_01_rpt = null;
            int store_id = -1;
            String store_name = null;
            if (store_cmb.Text != "")
            {
                store_id = Convert.ToInt32(store_cmb.EditValue);
                store_name = store_cmb.Text;
            }
            item_wise_01_rpt = new Item_Wise_Profit_Report(store_id,store_name, from_date_picker.Text, to_date_picker.Text);
            item_wise_01_rpt.RequestParameters = false;
            documentViewer1.DocumentSource = item_wise_01_rpt;
            item_wise_01_rpt.CreateDocument();
        }
    }
}