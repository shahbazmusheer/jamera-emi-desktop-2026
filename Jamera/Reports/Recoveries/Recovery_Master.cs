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

namespace Jamera.Reports.Recoveries
{
    public partial class Recovery_Master : DevExpress.XtraEditors.XtraForm
    {
        Recovery_Master_Report recovery_Master_Report;
        public Recovery_Master()
        {
            InitializeComponent();

            recovery_Master_Report = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.AddMonths(-1).Month.ToString();
            String year = today_date.Year.ToString();
            //from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            //to_date_picker.EditValue = DateTime.Now;
            month_selector.EditValue = Convert.ToDateTime(today_date.AddMonths(-1)).ToString("MMM - yyyy");
            recovery_Master_Report = new Recovery_Master_Report(-1, from_date_picker.Text, to_date_picker.Text, -1);
            recovery_Master_Report.RequestParameters = false;
            documentViewer1.DocumentSource = recovery_Master_Report;
            recovery_Master_Report.CreateDocument();
            sqlDataSource1.Fill();
           
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(recovery_Master_Report);
            print_tool.Print();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            recovery_Master_Report = null;
            int store_id = -1;
            int item_id = -1;
            string store_name = "";
            if (store_cmb.Text != "")
            {
                store_id = Convert.ToInt32(store_cmb.EditValue);
                store_name = store_cmb.Text;
            }
            recovery_Master_Report = new Recovery_Master_Report(store_id, from_date_picker.Text, to_date_picker.Text, item_id);
            recovery_Master_Report.RequestParameters = false;
            documentViewer1.DocumentSource = recovery_Master_Report;
            recovery_Master_Report.CreateDocument();
        }

        private void month_selector_EditValueChanged(object sender, EventArgs e)
        {
            from_date_picker.DateTime = Convert.ToDateTime("01-" + month_selector.DateTime.Month.ToString() + "-" +month_selector.DateTime.Year.ToString());
            to_date_picker.DateTime = Convert.ToDateTime("01-" + month_selector.DateTime.AddMonths(1).Month.ToString() + "-" +month_selector.DateTime.Year.ToString()).AddDays(-1);
        }
    }
}