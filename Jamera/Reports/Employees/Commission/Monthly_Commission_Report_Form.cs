using DevExpress.XtraEditors;
using Jamera.Reports.Stocks.Stocks_Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamera.Reports.Employees.Commission
{
    public partial class Monthly_Commission_Report_Form : DevExpress.XtraEditors.XtraForm
    {
        Area_Code_Wise_Commission_Report area_code_wise_commission_report;
        public Monthly_Commission_Report_Form()
        {
            InitializeComponent();
            sqlDataSource1.FillAsync();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            area_code_wise_commission_report = null;
            if (store_cmb.Text == "")
            {
                area_code_wise_commission_report = new Area_Code_Wise_Commission_Report(from_date_picker.Text, to_date_picker.Text, -1, "");
            }
            else
            {
                area_code_wise_commission_report = new Area_Code_Wise_Commission_Report(from_date_picker.Text, to_date_picker.Text, Convert.ToInt32(store_cmb.EditValue), store_cmb.Text.ToString());
            }
            area_code_wise_commission_report.RequestParameters = false;
            documentViewer1.DocumentSource = area_code_wise_commission_report;
            area_code_wise_commission_report.CreateDocument();
        }

        private void Area_Code_Wise_Commission_Report_Form_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            from_date_picker.DateTime = (new DateTime(now.Year, now.Month, 1));
            to_date_picker.DateTime = (new DateTime(now.Year, now.Month, 1).AddMonths(1).AddDays(-1));
            LoadReport();
        }
    }
}