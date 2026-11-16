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

namespace Jamera.Reports.Stocks.Stocks_Transactions
{
    public partial class Stock_Transactions : DevExpress.XtraEditors.XtraForm
    {
        Stock_Transactions_Report stock_Transactions_Report;
        public Stock_Transactions()
        {
            InitializeComponent();

            stock_Transactions_Report = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = DateTime.Now;
            stock_Transactions_Report = new Stock_Transactions_Report(from_date_picker.Text, to_date_picker.Text, "", -2, -2, -1);
            stock_Transactions_Report.RequestParameters = false;
            documentViewer1.DocumentSource = stock_Transactions_Report;
            stock_Transactions_Report.CreateDocument();
            sqlDataSource1.Fill();
           
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(stock_Transactions_Report);
            print_tool.Print();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            stock_Transactions_Report = null;
            int from_store_id = -2;
            int to_store_id = -2;
            int item_id = -1;
            if (from_store_cmb.Text != "")
            {
                from_store_id = Convert.ToInt32(from_store_cmb.EditValue);
            }
            if (to_store_cmb.Text != "")
            {
                to_store_id = Convert.ToInt32(to_store_cmb.EditValue);
            }
            if (item_cmb.Text != "")
            {
                item_id = Convert.ToInt32(item_cmb.EditValue);
            }
            stock_Transactions_Report = new Stock_Transactions_Report(from_date_picker.Text, to_date_picker.Text, gate_pass_no_inp.Text, from_store_id, to_store_id,item_id);
            stock_Transactions_Report.RequestParameters = false;
            documentViewer1.DocumentSource = stock_Transactions_Report;
            stock_Transactions_Report.CreateDocument();
        }
    }
}