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
    public partial class Area_Wise_Sales : DevExpress.XtraEditors.XtraForm
    {
        Area_Wise_Sales_Report area_Wise_Sales_Report;
        public Area_Wise_Sales()
        {
            InitializeComponent();

            area_Wise_Sales_Report = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.DateTime = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.DateTime = DateTime.Now;
            area_Wise_Sales_Report = new Area_Wise_Sales_Report(-1, from_date_picker.Text, to_date_picker.Text,-1);
            area_Wise_Sales_Report.RequestParameters = false;
            documentViewer1.DocumentSource = area_Wise_Sales_Report;
            area_Wise_Sales_Report.CreateDocument();
            sqlDataSource1.Fill();
           
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(area_Wise_Sales_Report);
            print_tool.Print();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            area_Wise_Sales_Report = null;
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
            area_Wise_Sales_Report = new Area_Wise_Sales_Report(store_id, from_date_picker.Text, to_date_picker.Text, item_id);
            area_Wise_Sales_Report.RequestParameters = false;
            documentViewer1.DocumentSource = area_Wise_Sales_Report;
            area_Wise_Sales_Report.CreateDocument();
        }
    }
}