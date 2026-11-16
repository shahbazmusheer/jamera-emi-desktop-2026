using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
namespace Jamera.Reports.Customers
{
    public partial class Area_Wise_Balances_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Area_Wise_Balances_Report()
        {
            InitializeComponent();
            date_label.Value = DateTime.Now.ToString("dd-MM-yyyy");
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
        }

    }
}
