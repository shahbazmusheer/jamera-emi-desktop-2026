using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Jamera.Properties;
using DevExpress.DataAccess.Sql;

namespace Jamera.Purchases
{
    public partial class Print_Bill : DevExpress.XtraReports.UI.XtraReport
    {
        int purchase_id = -1;
        String purchase_type = "";
        Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
        Purchases_Controller purchases_controller = new Purchases_Controller();
        public Print_Bill(int purchase_id,String print_title,string Mode)
        {
            InitializeComponent();
            this.purchase_id = purchase_id;
            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            report_title_text.Text = print_title;
            company_other_info.Value = Settings.Default.company_other_info;
            invoice_mode.Value = Mode;
            
            purchase_type = print_title;
            Load_Data();
            if(print_title != "Purchase Return")
            {
                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT items.id as 'Item Code',items.name as 'Item',p_i.purchase_rate as 'Purchase Rate',p_i.items_stock_in as 'Quantity',p_i.sub_total 'Sub Total',p_i.discount_rs as 'Discount',p_i.net_total as 'Net Total' from purchases left join accounts as suppliers on purchases.supplier_id=suppliers.id left join purchase_items as p_i on purchases.id=p_i.purchase_id left join items on p_i.item_id=items.id WHERE purchases.id='" + purchase_id + "'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            else
            {
                //purchase return

                sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
                CustomSqlQuery query = new CustomSqlQuery();
                query.Sql = @"SELECT items.id as 'Item Code',items.name as 'Item',p_i.purchase_rate as 'Purchase Rate',p_i.returned_quantity as 'Quantity',p_i.sub_total 'Sub Total',p_i.discount_rs as 'Discount',p_i.net_total as 'Net Total' from purchases_return left join accounts as suppliers on purchases_return.supplier_id=suppliers.id left join purchases_return_items as p_i on purchases_return.id=p_i.purchases_return_id left join items on p_i.item_id=items.id WHERE purchases_return.id='"+purchase_id+"'";
                query.Name = "Query";
                sqlDataSource1.Queries.Add(query);
                sqlDataSource1.RebuildResultSchema();
                sqlDataSource1.Fill();
            }
            purchase_id = -1;
            
        }
        public void Load_Data()
        {
            if(purchase_type != "Purchase Return")
            {
                Purchase purchase = purchases_controller.Get_Purchase(purchase_id);
                supplier_code.Value = purchase.Supplier_ID.ToString();
                supplier_name.Value = purchase.Supplier_Name;
                invoice_no.Value = purchase.Invoice_No;
                remarks.Value = purchase.Remarks;
                fuel_expenses_lbl.Text = purchase.Fuel_Expense_Amount.ToString();
                if(purchase.Expense_Paid_Ac_ID > 0)
                {
                    paid_by_account_name.Text = accounts_controller.Get_Account_Name(purchase.Expense_Paid_Ac_ID);
                }
                else
                {
                    paid_by_account_name.Text = "None";
                }
                total_discount.Value = purchase.Total_Discount_RS.ToString();
                net_total.Value = purchase.Net_Total.ToString();
                purchase_date.Value = purchase.Purchase_Date.ToString("dd-MM-yyyy");
            }
            else
            {
                //purchase return
                Purchase purchase = purchases_controller.Get_Purchase_Return(purchase_id);
                supplier_code.Value = purchase.Supplier_ID.ToString();
                supplier_name.Value = purchase.Supplier_Name;
                invoice_no.Value = purchase.Invoice_No;
                remarks.Value = purchase.Remarks;
                total_discount.Value = purchase.Total_Discount_RS.ToString();
                net_total.Value = purchase.Net_Total.ToString();
                purchase_date.Value = purchase.Purchase_Date.ToString("dd-MM-yyyy");
            }
        }


    }
}
