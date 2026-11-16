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
using System.Data.SqlClient;
using Jamera.Properties;
using DevExpress.XtraReports.UI;
using System.IO;

namespace Jamera.Purchases
{
    public partial class Purchase_Return_Details : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = new SqlConnection();
        int purchase_ret_id = -1;
        DataTable purchase_items_table = new DataTable();
        public Purchase_Return_Details(Purchase purchase)
        {
            InitializeComponent();

            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
            this.purchase_ret_id = purchase.Purchase_ID;
            date_lbl.Text = purchase.Purchase_Date.ToString("dd-MM-yyyy");
            supplier_lbl.Text = purchase.Supplier_Name;
            disc_percent_lbl.Text = purchase.Total_Discount_Percent.ToString();
            payment_method_label.Text = purchase.Payment_Method;
            discount_rs_label.Text = purchase.Total_Discount_RS.ToString();
            remarks_ret_label.Text = purchase.Remarks;
            total_top_lbl.Text = purchase.Net_Total.ToString();
            this.Load_Data();

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
        }
        public void Load_Data()
        {
            purchase_items_table.Clear();
            String query = @"SELECT itm.id as 'Code',itm.name as 'Item',p.status as 'Status',p.purchase_rate as 'Purchase Rate',p.sale_rate as 'Sale Rate',p.sub_total as 'Sub Total',p.discount_percent as 'Disc(%)',p.discount_rs as 'Disc(R.S)',p.returned_quantity as 'Returned',p.net_total as 'Net Total' FROM purchases_return_items as p join items as itm on p.item_id=itm.id  WHERE purchases_return_id='" + this.purchase_ret_id + "'";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.Fill(purchase_items_table);
            purchases_Returns_list_Container.DataSource = purchase_items_table;
        }
        private void Purchase_Return_Details_Load(object sender, EventArgs e)
        {

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Print_Bill print_bill = new Print_Bill(purchase_ret_id, "Purchase Return", payment_method_label.Text);
            ReportPrintTool print_tool = new ReportPrintTool(print_bill);
            print_tool.Print();
        }
    }
}