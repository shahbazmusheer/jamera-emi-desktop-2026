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
    public partial class Sale_Items_Master : DevExpress.XtraEditors.XtraForm
    {
        Sale_Items_Master_Report sale_Items_Master_Report;
        public Sale_Items_Master()
        {
            InitializeComponent();

            sale_Items_Master_Report = null;
            DateTime today_date = DateTime.Now;
            String month = today_date.Month.ToString();
            String year = today_date.Year.ToString();
            from_date_picker.EditValue = Convert.ToDateTime("01-" + month + "-" + year);
            to_date_picker.EditValue = DateTime.Now;
            sale_Items_Master_Report = new Sale_Items_Master_Report(-1, "", from_date_picker.Text, to_date_picker.Text, -1);
            sale_Items_Master_Report.RequestParameters = false;
            documentViewer1.DocumentSource = sale_Items_Master_Report;
            sale_Items_Master_Report.CreateDocument();
            sqlDataSource1.Fill();
           
        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {
            ReportPrintTool print_tool = new ReportPrintTool(sale_Items_Master_Report);
            print_tool.Print();
        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {
            sale_Items_Master_Report = null;
            int store_id = -1;
            int item_id = -1;
            string store_name = "";
            if (store_cmb.Text != "")
            {
                store_id = Convert.ToInt32(store_cmb.EditValue);
                store_name = store_cmb.Text;
            }
            if (item_cmb.Text != "")
            {
                item_id = Convert.ToInt32(item_cmb.EditValue);
            }
            sale_Items_Master_Report = new Sale_Items_Master_Report(store_id, store_name, from_date_picker.Text, to_date_picker.Text, item_id);
            sale_Items_Master_Report.RequestParameters = false;
            documentViewer1.DocumentSource = sale_Items_Master_Report;
            sale_Items_Master_Report.CreateDocument();
        }
    }
}