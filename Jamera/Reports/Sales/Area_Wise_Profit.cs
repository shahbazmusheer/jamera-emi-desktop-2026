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
    public partial class Area_Wise_Profit : DevExpress.XtraEditors.XtraForm
    {
        Area_Wise_Profit_Report item_wise_02_rpt;
        public Area_Wise_Profit()
        {
            InitializeComponent();

            item_wise_02_rpt = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = DateTime.Now;
            item_wise_02_rpt = new Area_Wise_Profit_Report(-1, from_date_picker.Text, to_date_picker.Text,-1);
            item_wise_02_rpt.RequestParameters = false;
            documentViewer1.DocumentSource = item_wise_02_rpt;
            item_wise_02_rpt.CreateDocument();
            sqlDataSource1.Fill();
           
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(item_wise_02_rpt);
            print_tool.Print();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            item_wise_02_rpt = null;
            int store_id = -1;
            int item_id = -1;
            if (store_cmb.Text != "")
            {
                store_id = Convert.ToInt32(store_cmb.EditValue);
            }
            if (item_cmb.Text != "")
            {
                item_id = Convert.ToInt32(item_cmb.EditValue);
            }
            item_wise_02_rpt = new Area_Wise_Profit_Report(store_id, from_date_picker.Text, to_date_picker.Text,item_id);
            item_wise_02_rpt.RequestParameters = false;
            documentViewer1.DocumentSource = item_wise_02_rpt;
            item_wise_02_rpt.CreateDocument();
        }
    }
}