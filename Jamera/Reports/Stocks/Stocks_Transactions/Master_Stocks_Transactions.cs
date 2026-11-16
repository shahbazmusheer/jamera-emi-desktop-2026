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
using System.IO;
using Jamera.Properties;

namespace Jamera.Reports.Stocks.Stocks_Transactions
{
    public partial class Master_Stocks_Transactions : DevExpress.XtraEditors.XtraForm
    {
        Stock_Transactions_Mater_Report stock_trasanactions_master_report;
        public Master_Stocks_Transactions()
        {
            InitializeComponent();

            string icon_path = Settings.Default.company_icon;
            string img_name = Settings.Default.db_name;
            if (icon_path != "")
            {
                FileInfo image = new FileInfo(icon_path);
                if (image.Exists == true)
                {
                    this.Icon = new Icon(icon_path);
                }
            }
            else
            {
                string img_path = Environment.CurrentDirectory + @"\Icons\" + img_name + @".ico";
                FileInfo image = new FileInfo(img_path);
                if (image.Exists == true)
                {
                    this.Icon = new Icon(img_path);
                }
            }

            stock_trasanactions_master_report = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = DateTime.Now;
            stock_trasanactions_master_report = new Stock_Transactions_Mater_Report(from_date_picker.Text, to_date_picker.Text);
            stock_trasanactions_master_report.RequestParameters = false;
            documentViewer1.DocumentSource = stock_trasanactions_master_report;
            stock_trasanactions_master_report.CreateDocument();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            stock_trasanactions_master_report = null;
            stock_trasanactions_master_report = new Stock_Transactions_Mater_Report(from_date_picker.Text, to_date_picker.Text);
            stock_trasanactions_master_report.RequestParameters = false;
            documentViewer1.DocumentSource = stock_trasanactions_master_report;
            stock_trasanactions_master_report.CreateDocument();
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(stock_trasanactions_master_report);
            print_tool.Print();
        }
    }
}