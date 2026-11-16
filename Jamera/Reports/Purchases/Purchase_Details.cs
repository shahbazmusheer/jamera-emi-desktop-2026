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

namespace Jamera.Reports.Purchases
{
    public partial class Purchase_Details : DevExpress.XtraEditors.XtraForm
    {
        Purchases_Master_Details purchases_details_report;
        public Purchase_Details()
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

            purchases_details_report = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = DateTime.Now;
            purchases_details_report = new Purchases_Master_Details(from_date_picker.Text, to_date_picker.Text);
            purchases_details_report.RequestParameters = false;
            documentViewer1.DocumentSource = purchases_details_report;
            purchases_details_report.CreateDocument();

        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            purchases_details_report = null;
            purchases_details_report = new Purchases_Master_Details(from_date_picker.Text, to_date_picker.Text);
            purchases_details_report.RequestParameters = false;
            documentViewer1.DocumentSource = purchases_details_report;
            purchases_details_report.CreateDocument();
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(purchases_details_report);
            print_tool.Print();
        }
    }
}