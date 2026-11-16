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

namespace Jamera.Reports.Sales
{
    public partial class Sales_Details : DevExpress.XtraEditors.XtraForm
    {
        Sale_Details_Report sale_Details_rpt;
        public Sales_Details()
        {
            InitializeComponent();

            sale_Details_rpt = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = DateTime.Now;
            sale_Details_rpt = new Sale_Details_Report(-1, from_date_picker.Text, to_date_picker.Text,-1);
            sale_Details_rpt.RequestParameters = false;
            documentViewer1.DocumentSource = sale_Details_rpt;
            sale_Details_rpt.CreateDocument();
            sqlDataSource1.Fill();
           
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(sale_Details_rpt);
            print_tool.Print();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            sale_Details_rpt = null;
            bool returns_check = false;
            int store_id = -1;
            int item_id = -1;
            if (store_cmb.Text != "")
            {
                store_id = Convert.ToInt32(store_cmb.EditValue);
            }
            if (item_cmb.Text != "")
            {
                item_id = Convert.ToInt32(item_cmb.EditValue);
            }

            if(returns_checkbox.CheckState == CheckState.Checked)
            {
                returns_check = true;
            }
            sale_Details_rpt = new Sale_Details_Report(store_id, from_date_picker.Text, to_date_picker.Text,item_id, returns_check);
            sale_Details_rpt.RequestParameters = false;
            documentViewer1.DocumentSource = sale_Details_rpt;
            sale_Details_rpt.CreateDocument();
        }
    }
}