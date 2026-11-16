using DevExpress.XtraReports.UI;
using Jamera.Properties;
using System.Data;

namespace Jamera.Reports.Sales
{
    public partial class Sales_Count_Report : DevExpress.XtraReports.UI.XtraReport
    {
        // Update constructor to accept DataTable and Store Name
        public Sales_Count_Report(DataTable salesData, string storeName, string reportType)
        {
            InitializeComponent();

            // 1. Set Company Info from Settings
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            // 2. Set Parameters
            from_date.Value = storeName; // Reusing from_date parameter for Store Name based on your xrLabel16 binding
            xrLabel11.Text = reportType + " Report"; // Set Title dynamically

            // 3. Bind the DataTable
            this.DataSource = salesData;
            this.DataMember = ""; // Clear data member when binding directly to a DataTable

            // 4. Update Label Bindings 
            // Since your report design was using "Query.Code", we point it to the DataTable columns
            xrLabel6.ExpressionBindings.Clear();
            xrLabel6.ExpressionBindings.Add(new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "'Date: ' + [Date]"));

            xrLabel1.ExpressionBindings.Clear();
            xrLabel1.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "'Sale Qty: ' + sumSum([Qty])"));

            //xrLabel3.ExpressionBindings.Clear();
            //xrLabel3.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "'Total Qty: ' + sumSum([Qty])"));

            if(reportType == "Date Wise Sales Count")
            {
                GroupFooter2.Visible = true;
                xrLabel1.ExpressionBindings.Clear();
                xrLabel1.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "'Sale Qty: ' + sumSum([Qty])"));

                xrLabel4.ExpressionBindings.Clear();
                xrLabel4.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "'Total Sale: ' + sumSum([Qty])"));
            }
            else
            {
                xrLabel1.ExpressionBindings.Clear();
                xrLabel1.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "'Total Sale: ' + sumSum([Qty])"));

                GroupFooter2.Visible = false;
            }

            xrLabel7.ExpressionBindings.Clear();
            xrLabel7.ExpressionBindings.Add(new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Name]")); // Showing Name in the middle column

            xrLabel10.ExpressionBindings.Clear();
            xrLabel10.ExpressionBindings.Add(new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")); // Showing Qty in the end column
        }
    }
}