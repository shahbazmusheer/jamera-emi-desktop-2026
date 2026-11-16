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
using System.IO;
using Jamera.Properties;

namespace Jamera.Items
{
    public partial class Stock_Return_Details : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = new SqlConnection();
        DataTable Return_Items_Table = new DataTable();
        Stock_Returned stock_return = new Stock_Returned();
        public Stock_Return_Details(Stock_Returned Stock_Return)
        {
            InitializeComponent();
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
            stock_return = Stock_Return;
            Load_Data();

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
            date_lbl.Text= stock_return.DATE.ToString("dd-MM-yyyy");
            name_lbl.Text= stock_return.Name;
            store_lbl.Text = stock_return.Store_Name;
            remarks_label.Text= stock_return.Description;
            String query = @"SELECT items.id as 'Code',items.name as 'Item',models.name as 'Model',sri.sale_rate as 'Sale Rate',SUM(sri.quantity) as 'Quantity' from stock_return_items as sri left join items on sri.item_id=items.id left join item_models as models on items.model_id=models.id WHERE sri.stock_return_id = '" + stock_return.Stock_Return_Id+ "' group by items.id,items.name,sri.sale_rate,models.name";
            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(query,conn);
            adp.Fill(Return_Items_Table);
            Stock_Returns_list_Container.DataSource = Return_Items_Table;
            conn.Close();
        }

        private void Stock_Return_Details_Load(object sender, EventArgs e)
        {

        }
    }
}