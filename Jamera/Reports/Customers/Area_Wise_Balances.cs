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

namespace Jamera.Reports.Customers
{
    public partial class Area_Wise_Balances : DevExpress.XtraEditors.XtraForm
    {
        Area_Wise_Balances_Report area_wise_balances_report;
        public Area_Wise_Balances()
        {
            InitializeComponent();
            area_wise_balances_report = new Area_Wise_Balances_Report();
            area_wise_balances_report.RequestParameters = false;
            documentViewer1.DocumentSource = area_wise_balances_report;
            area_wise_balances_report.CreateDocument();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            area_wise_balances_report = null;
            area_wise_balances_report = new Area_Wise_Balances_Report();
            area_wise_balances_report.RequestParameters = false;
            documentViewer1.DocumentSource = area_wise_balances_report;
            area_wise_balances_report.CreateDocument();
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(area_wise_balances_report);
            print_tool.Print();
        }
    }
}