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

namespace Jamera.Reports.Expenses
{
    public partial class General_Expenses : DevExpress.XtraEditors.XtraForm
    {
        General_Expenses_Report general_expenses_report;
        public General_Expenses()
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

            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = DateTime.Now;
            general_expenses_report = new General_Expenses_Report(from_date_picker.Text, to_date_picker.Text);
            general_expenses_report.RequestParameters = false;
            documentViewer1.DocumentSource = general_expenses_report;
            general_expenses_report.CreateDocument();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            general_expenses_report = null;
            general_expenses_report = new General_Expenses_Report(from_date_picker.Text, to_date_picker.Text);
            general_expenses_report.RequestParameters = false;
            documentViewer1.DocumentSource = general_expenses_report;
            general_expenses_report.CreateDocument();
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(general_expenses_report);
            print_tool.Print();
        }
    }
}