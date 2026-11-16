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

namespace Jamera.Reports.Stocks
{
    public partial class Stock_Ledger : DevExpress.XtraEditors.XtraForm
    {
        Stock_Ledger_Report stock_Ledger_Report;
        public Stock_Ledger()
        {
            InitializeComponent();

            stock_Ledger_Report = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = DateTime.Now;
            //stock_Ledger_Report = new Stock_Ledger_Report(-1, "", from_date_picker.Text, to_date_picker.Text);
            //stock_Ledger_Report.RequestParameters = false;
            //documentViewer1.DocumentSource = stock_Ledger_Report;
            //stock_Ledger_Report.CreateDocument();
            sqlDataSource1.Fill();
           
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(stock_Ledger_Report);
            print_tool.Print();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            stock_Ledger_Report = null;
            int store_id = -1;
            string store_name = "";
            if (store_cmb.Text != "")
            {
                store_id = Convert.ToInt32(store_cmb.EditValue);
                store_name = store_cmb.Text;
            }
            stock_Ledger_Report = new Stock_Ledger_Report(store_id, store_name, from_date_picker.Text, to_date_picker.Text);
            stock_Ledger_Report.RequestParameters = false;
            documentViewer1.DocumentSource = stock_Ledger_Report;
            stock_Ledger_Report.CreateDocument();
        }
    }
}