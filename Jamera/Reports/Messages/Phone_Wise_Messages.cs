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
using System.Text.RegularExpressions;
using System.IO;
using Jamera.Properties;

namespace Jamera.Reports.Messages
{
    public partial class Phone_Wise_Messages : DevExpress.XtraEditors.XtraForm
    {
        Number_Wise_Messages_Report number_wise_messages_report;
        public Phone_Wise_Messages()
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

            number_wise_messages_report = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = DateTime.Now;
            number_wise_messages_report = new Number_Wise_Messages_Report(from_date_picker.Text, to_date_picker.Text,null);
            number_wise_messages_report.RequestParameters = false;
            documentViewer1.DocumentSource = number_wise_messages_report;
            number_wise_messages_report.CreateDocument();
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(number_wise_messages_report);
            print_tool.Print();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            number_wise_messages_report = null;
            if(phone_no_inp.Text == "")
            {
                number_wise_messages_report = new Number_Wise_Messages_Report(from_date_picker.Text, to_date_picker.Text, null);
            }
            else
            {
                number_wise_messages_report = new Number_Wise_Messages_Report(from_date_picker.Text, to_date_picker.Text, phone_no_inp.Text);
            }
            number_wise_messages_report.RequestParameters = false;
            documentViewer1.DocumentSource = number_wise_messages_report;
            number_wise_messages_report.CreateDocument();
        }

        private void phone_no_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            phone_no_inp.Properties.MaxLength = 13;
            Char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 13 && ch != 8 && ch != 127 && ch != 45 && ch != 43)
            {
                e.Handled = true;
            }
            if (phone_no_inp.Text.Contains("+92") && phone_no_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{6}\-\d{7}");
                phone_no_inp.Properties.MaxLength = 14;
                if (phone_no_inp != null)
                    if (r.IsMatch(phone_no_inp.Text))
                    {

                    }
            }
            else if (phone_no_inp.Text.Contains("+92"))
            {
                phone_no_inp.Properties.MaxLength = 13;
            }
            else if (phone_no_inp.Text.Contains("03") && phone_no_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{4}\-\d{7}");
                phone_no_inp.Properties.MaxLength = 12;
            }
            else if (phone_no_inp.Text.Contains("03"))
            {
                phone_no_inp.Properties.MaxLength = 11;
            }
        }
    }
}