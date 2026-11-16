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

namespace Jamera.Reports.Stocks
{
    public partial class Low_Stock : DevExpress.XtraEditors.XtraForm
    {
        Low_Stock_Report low_stock_report;
        public Low_Stock()
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

            low_stock_report = null;
            low_stock_report = new Low_Stock_Report();
            low_stock_report.RequestParameters = false;
            documentViewer1.DocumentSource = low_stock_report;
            low_stock_report.CreateDocument();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            low_stock_report = null;
            low_stock_report = new Low_Stock_Report();
            low_stock_report.RequestParameters = false;
            documentViewer1.DocumentSource = low_stock_report;
            low_stock_report.CreateDocument();
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(low_stock_report);
            print_tool.Print();
        }
    }
}