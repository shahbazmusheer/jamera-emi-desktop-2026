using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using Jamera.Properties;

namespace Jamera.Items
{
    public partial class Stock_Transfer_Print : DevExpress.XtraReports.UI.XtraReport
    {
        public Stock_Transfer_Print(int stock_transfer_id)
        {
            InitializeComponent();

            company_name.Value = Settings.Default.company_name;
            company_address.Value = Settings.Default.company_address;
            company_phone.Value = Settings.Default.company_phone;
            company_other_info.Value = Settings.Default.company_other_info;

            Stocks_Controller stocks_controller = new Stocks_Controller();
            Stock_Transfer_Instance stock_transfer_instance= stocks_controller.Get_Stock_Transfer_Instance(stock_transfer_id);
            stock_transfer_date.Value= stock_transfer_instance.Date;
            if(stock_transfer_instance.From_Store_Id == -1)
            {
                from_store_name.Value = "Head Office";
            }
            else
            {
                from_store_name.Value = stock_transfer_instance.From_Store;
            }
            to_store_name.Value = stock_transfer_instance.To_Store;
            if(stock_transfer_instance.Name != null)
            {
                name_inp.Value = stock_transfer_instance.Name;
            }
            sqlDataSource1.Queries.Remove(sqlDataSource1.Queries["Query"]);
            CustomSqlQuery query = new CustomSqlQuery();
            query.Sql = @"SELECT items.id as 'Item Code',items.name as 'Item Name',sti.stock_in as 'Quantity' FROM stock_transaction_items as sti left join items on sti.item_id=items.id WHERE sti.stock_transaction_id='"+stock_transfer_id+"'";
            query.Name = "Query";
            sqlDataSource1.Queries.Add(query);
            sqlDataSource1.RebuildResultSchema();
            sqlDataSource1.Fill();
        }

    }
}
