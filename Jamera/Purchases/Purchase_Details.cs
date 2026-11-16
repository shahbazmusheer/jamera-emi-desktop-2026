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
using System.IO;
using DevExpress.XtraReports.UI;

namespace Jamera.Purchases
{
    public partial class Purchase_Details : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn = new SqlConnection();
        Purchases_Controller purchases_controller = new Purchases_Controller();
        int purchase_id=-1;
        DataTable purchase_items_table = new DataTable();
        public Purchase_Details(int Purchase_Id)
        {
            InitializeComponent();
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
            this.purchase_id = Purchase_Id;
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
        public void Block_Selected_Item(int itm_id)
        {
            conn.Open();
            String query = "UPDATE purchase_items set status='blocked' WHERE item_id='" + itm_id + "' and purchase_id='"+this.purchase_id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Unblock_Selected_Item(int itm_id)
        {
            conn.Open();
            String query = "UPDATE purchase_items set status='unblocked' WHERE item_id='" + itm_id + "' and purchase_id='" + this.purchase_id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Block_All_Items()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                int sel_item_id = Convert.ToInt32(gridView1.GetDataRow(i)["Code"]);
                Block_Selected_Item(sel_item_id);
            }
        }

        public void Unblock_All_Items()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                int sel_item_id = Convert.ToInt32(gridView1.GetDataRow(i)["Code"]);
                Unblock_Selected_Item(sel_item_id);
            }
        }


        public void Load_Data()
        {
            Purchase purchase = purchases_controller.Get_Purchase(purchase_id);
            this.purchase_id = purchase.Purchase_ID;
            date_lbl.Text = purchase.Purchase_Date.ToString("dd-MM-yyyy");
            supplier_lbl.Text = purchase.Supplier_Name;
            purchase_type_label.Text = purchase.Purchase_Type;
            disc_percent_lbl.Text = purchase.Total_Discount_Percent.ToString();
            payment_method_label.Text = purchase.Payment_Method;
            disc_rs_lbl.Text = purchase.Total_Discount_RS.ToString();
            paid_inp.Text = purchase.Paid.ToString();
            balance_inp.Text = purchase.Balance.ToString();
            remarks_label.Text = purchase.Remarks;
            fuel_expenses_inp.Text = purchase.Fuel_Expense_Amount.ToString();
            total_top_lbl.Text = purchase.Net_Total.ToString();
            fuel_expenses_inp.Text = purchase.Fuel_Expense_Amount.ToString();
            if(purchase.Expense_Paid_Ac_ID > 0)
            {
                Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
                fuel_expenses_ac_inp.Text = accounts_controller.Get_Account_Name(purchase.Expense_Paid_Ac_ID);
            }
            purchase_items_table.Clear();
            conn.Open();
            String query = @"SELECT itm.id as 'Code',itm.name as 'Item',models.name as 'Model',p.status as 'Status',p.purchase_rate as 'Purchase Rate',p.sale_rate as 'Sale Rate',p.quantity as 'Packing',p.sub_total as 'Sub Total',p.discount_percent as 'Disc(%)',p.discount_rs as 'Disc(R.S)',p.items_stock_in as 'Stock In',p.items_stock_out as 'Stock Out',p.returned_quantity as 'Returned',p.net_total as 'Net Total' FROM purchase_items as p join items as itm on p.item_id=itm.id left join item_models as models on itm.model_id=models.id  WHERE purchase_id='" + this.purchase_id + "'";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            adp.Fill(purchase_items_table);
            conn.Close();
            Double stock_out_value = Convert.ToDouble(purchase_items_table.AsEnumerable().Sum(row => row.Field<Decimal>("Stock Out")));
            if(stock_out_value > 0)
            {
                delete_btn.Enabled = false;
            }
            purchases_list_Container.DataSource = purchase_items_table;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {

        }

        private void new_btn_Click(object sender, EventArgs e)
        {

        }

        private void Purchase_Details_Load(object sender, EventArgs e)
        {

        }

        private void block_selected_items_btn_Click(object sender, EventArgs e)
        {
            Block_Selected_Item(Convert.ToInt32(gridView1.GetFocusedRowCellValue(gridView1.Columns["Code"])));
            Load_Data();
        }

        private void unblock_selected_items_btn_Click(object sender, EventArgs e)
        {
            Unblock_Selected_Item(Convert.ToInt32(gridView1.GetFocusedRowCellValue(gridView1.Columns["Code"])));
            Load_Data();
        }

        private void block_complete_purch_btn_Click(object sender, EventArgs e)
        {
            Block_All_Items();
            Load_Data();
        }

        private void unblock_complete_purch_btn_Click(object sender, EventArgs e)
        {
            Unblock_All_Items();
            Load_Data();
        }
        private void print_btn_Click(object sender, EventArgs e)
        {
            Print_Bill print_bill = new Print_Bill(purchase_id, "Purchase Invoice", payment_method_label.Text);
            ReportPrintTool print_tool = new ReportPrintTool(print_bill);
            print_tool.Print();
        }

        private void row_delete_btn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("The complete purchase invoice will delete.Do you want to proceed !", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (purchases_controller.Delete_New_Purchase(purchase_id) == true)
                {
                    this.Close();
                }
            }
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            
        }

        private void gridView1_AsyncCompleted(object sender, EventArgs e)
        {
            //DevExpress.XtraGrid.GridSummaryItem debit_item = gridView1.Columns["Debit"].SummaryItem;
            //debit_item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //Double debit_total = Convert.ToDouble(debit_item.SummaryValue);
            //total_debit.Text = string.Format("{0:#,##0.00}", Double.Parse(debit_total.ToString()));
        }

        private void purchases_list_Container_Click(object sender, EventArgs e)
        {

        }
    }
}