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
    public partial class Available_Stock : DevExpress.XtraEditors.XtraForm
    {
        Available_Stock_Report available_Stock_report;
        public Available_Stock()
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

            available_Stock_report = null;
            available_Stock_report = new Available_Stock_Report();
            available_Stock_report.RequestParameters = false;
            documentViewer1.DocumentSource = available_Stock_report;
            available_Stock_report.CreateDocument();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            available_Stock_report = null;
            available_Stock_report = new Available_Stock_Report();
            available_Stock_report.RequestParameters = false;
            documentViewer1.DocumentSource = available_Stock_report;
            available_Stock_report.CreateDocument();
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(available_Stock_report);
            print_tool.Print();
        }
    }
}