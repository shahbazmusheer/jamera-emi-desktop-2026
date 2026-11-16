using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;

namespace Jamera.Reports.Stocks
{
    public partial class Available_Stock_With_Value_Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Available_Stock_With_Value_Report()
        {
            InitializeComponent();
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;
            date_inp.Value = DateTime.Now.ToString("dd-MM-yyyy");
        }

    }
}
