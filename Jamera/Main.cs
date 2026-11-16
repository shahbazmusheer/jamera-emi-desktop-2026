using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using System.IO;
using Jamera.Aggrements;
using Jamera.Properties;
using Jamera.Reports.Recoveries;
using Jamera.Reports.Stocks;
namespace Jamera
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XtraUserControl DashboardUserControl;
        //Employees
        public DatabaseHandler database_handler { get; set; }
        XtraUserControl EmployeesUserControl;
        XtraUserControl EmployeePaymentsHistoryUserControl;
        XtraUserControl ItemsCommissionUserControl;

        // Inventory

        XtraUserControl NewItemUserControl;
        XtraUserControl ItemsListUserControl;
        XtraUserControl ItemsCatagoryUserControl;
        XtraUserControl ItemsModelsUserControl;
        XtraUserControl ItemsGroupUserControl;
        XtraUserControl ItemsManufacturerUserControl;
        XtraUserControl ItemsUnitsUserControl;
        XtraUserControl LowStockUserControl;
        XtraUserControl LowStockAtStoresUserControl;
        XtraUserControl StoresUserControl;
        XtraUserControl StockTransferUserControl;
        XtraUserControl StockTransactionsHistoryUserControl;
        XtraUserControl StockReturnUserControl;
        XtraUserControl StockReturnsHistoryUserControl;

        // Accounts

        XtraUserControl NewAccountUserControl;
        XtraUserControl ChartOfAccountsUserControl;
        XtraUserControl AccountGroupsUserControl;
        XtraUserControl GeneralLedgerUserControl;
        XtraUserControl AccountLedgerStatementUserControl;
        XtraUserControl IncomeStatementUserControl;
        XtraUserControl TrialBalanceUserControl;
        XtraUserControl ExpenseManagerUserControl;
        XtraUserControl BalanceSheetUserControl;

        // Sales

        //XtraUserControl NewSaleUserControl;
        //XtraUserControl SaleReturnUserControl;
        //XtraUserControl SalesHistoryUserControl;
        //XtraUserControl SaleReturnsHistoryUserControl;
        XtraUserControl CustomersUserControl;
        XtraUserControl CustomersDetailsUserControl;

        // Purchases

        XtraUserControl NewPurchaseUserControl;
        XtraUserControl PurchasesHistoryUserControl;
        XtraUserControl PurchaseReturnsHistoryUserControl;
        XtraUserControl SuppliersUserControl;
        XtraUserControl SupplierDetailsUserControl;
        XtraUserControl RecieptsMessagesUserControl;

        // Vouchers

        XtraUserControl CashVouchersHistoryMasterUserControl;
        XtraUserControl VouchersHistoryUserControl;
        XtraUserControl BulkCashVoucherUserControl;
        XtraUserControl EMIVouchersHistoryUserControl;
        XtraUserControl CashVouchersHistoryUserControl;

        // Aggrements

        XtraUserControl NewAgreementUserControl;
        XtraUserControl AgreementsUserControl;
        XtraUserControl AuditAgreementsUserControl;
        XtraUserControl AgreementReturnUserControl;
        XtraUserControl AggrementReturnsHistoryUserControl;
        XtraUserControl GuardiansUserControl;
        XtraUserControl GuardianDetailsControl;
        XtraUserControl NewComplaintUserControl;
        XtraUserControl ComplaintsUserControl;
        XtraUserControl CustomerDuesUserControl;
        XtraUserControl LateCustomersUserControl;


        XtraUserControl SingleMessageUserControl;
        XtraUserControl BulkMessagesUserControl;
        XtraUserControl MessagesHistoryUserControl;
        XtraUserControl MyMessagesGroupsUserControl;
        XtraUserControl GroupsContactsUserControl;

        XtraUserControl StockManagementUserControl;
        XtraUserControl StockManagementHistoryUserControl;
        DatabaseHandler db_handler = new DatabaseHandler();

        public Main()
        {
            InitializeComponent();
            //db_handler.Open_Connection();
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

            LoadTabs_Visibility();

            if (Settings.Default.should_show_flush_btn_in_main == false)
            {
                flush_db_btn.Visibility = BarItemVisibility.Never;
            }
            else
            {
                flush_db_btn.Visibility = BarItemVisibility.Always;
            }


        }

        public void LoadTabs_Visibility()
        {
            aggrements_tab.Visible = Settings.Default.show_aggrements_tab;
            messages_tab.Visible = Settings.Default.show_messages_tab;
            purchases_tab.Visible = Settings.Default.show_purchases_tab;
            inventory_tab.Visible = Settings.Default.show_inventory_tab;
            employees_tab.Visible = Settings.Default.show_employees_tab;
            accounts_tab.Visible = Settings.Default.show_accounts_tab;
            vouchers_tab.Visible = Settings.Default.show_vouchers_tab;
            reports_tab.Visible = Settings.Default.show_reports_tab;
            settings_tab.Visible = Settings.Default.show_settings_tab;
            
        }

        public void TabbedView_Items()
        {
            DashboardUserControl = CreateUserControl("Dashboard", new Dashboard());
            NewItemUserControl = CreateUserControl("New Item", new Items.New_Item());
            ItemsListUserControl = CreateUserControl("Items List", new Items.Items());
            ItemsModelsUserControl = CreateUserControl("Items Models", new Items.Models.Models());
            ItemsGroupUserControl = CreateUserControl("Items Groups", new Items.Groups.Item_Groups());
            ItemsCatagoryUserControl = CreateUserControl("Items Catagories", new Items.Catagories.Catagories());
            ItemsManufacturerUserControl = CreateUserControl("Items Manufacturers", new Items.Manufacturers.Manufacturers());
            ItemsUnitsUserControl = CreateUserControl("Items Units", new Items.Units.Units());
            LowStockUserControl = CreateUserControl("Low Stock", new Items.Low_Stock());
            LowStockAtStoresUserControl = CreateUserControl("Low Stock at Stores", new Items.Low_Stock_at_Stores());
            StoresUserControl = CreateUserControl("Stores", new Items.Stores.Stores());
            StockTransferUserControl = CreateUserControl("Stock Transfer", new Items.Stock_Transfer());
            StockTransactionsHistoryUserControl = CreateUserControl("Stock Transactions History", new Items.Stock_Transactions_History());
            StockReturnUserControl = CreateUserControl("Stock Return", new Items.Stock_Return());
            StockReturnsHistoryUserControl = CreateUserControl("Stock Returns History", new Items.Stock_Return_History());

            EmployeesUserControl = CreateUserControl("Employees", new Employees.Employees());
            EmployeePaymentsHistoryUserControl = CreateUserControl("Employees Payment History", new Employees.Payment_History());
            ItemsCommissionUserControl = CreateUserControl("Items Commission", new Employees.Commissions.Items_Commission());

            NewAccountUserControl = CreateUserControl("New Account", new Accounts.New_Account());
            ChartOfAccountsUserControl = CreateUserControl("Chart of Accounts", new Accounts.Chart_Of_Accounts());
            AccountGroupsUserControl = CreateUserControl("Account Groups", new Accounts.Account_Groups.Groups());
            GeneralLedgerUserControl = CreateUserControl("General Ledger", new Accounts.General_Ledger());
            AccountLedgerStatementUserControl = CreateUserControl("Account Ledger Statement", new Accounts.Account_Ledger_Statement());
            IncomeStatementUserControl = CreateUserControl("Income Statement", new Accounts.Income_Statement());
            TrialBalanceUserControl = CreateUserControl("Trial Statement", new Accounts.Trial_Balance());
            ExpenseManagerUserControl = CreateUserControl("Expense Manager", new Accounts.Expense_Manager());
            BalanceSheetUserControl = CreateUserControl("Balance Sheet", new Accounts.Balance_Sheet());

            //NewSaleUserControl = CreateUserControl("New Sale", new Sales.New_Sale());
            //SaleReturnUserControl = CreateUserControl("Sale Return", new Sales.Sale_Return());
            //SalesHistoryUserControl = CreateUserControl("Sales History", new Sales.Sales_History());
            //SaleReturnsHistoryUserControl = CreateUserControl("Sale Returns History", new Sales.Sale_Returns_History());
            CustomersUserControl = CreateUserControl("Customers", new Sales.Customers());
            CustomersDetailsUserControl = CreateUserControl("Customer Details", new Accounts.Account_Ledger_Statement());

            NewPurchaseUserControl = CreateUserControl("New Purchase", new Purchases.New_Purchase());
            PurchasesHistoryUserControl = CreateUserControl("Purchases History", new Purchases.Purchases_History());
            PurchaseReturnsHistoryUserControl = CreateUserControl("Purchase Returns History", new Purchases.Purchase_Returns_History());
            SuppliersUserControl = CreateUserControl("Suppliers", new Purchases.New_Purchase());
            SupplierDetailsUserControl = CreateUserControl("Supplier Details", new Purchases.New_Purchase());


            CashVouchersHistoryMasterUserControl = CreateUserControl("Cash Vouchers Master", new Vouchers.Cash_Vouchers_History_Master());
            VouchersHistoryUserControl = CreateUserControl("Vouchers History", new Vouchers.Vouchers_History());
            BulkCashVoucherUserControl = CreateUserControl("Bulk Cash Voucher", new Vouchers.Bulk_Cash_Voucher());
            CashVouchersHistoryUserControl = CreateUserControl("Cash Vouchers History", new Vouchers.Cash_Vouchers_History());
            EMIVouchersHistoryUserControl = CreateUserControl("EMI Vouchers History", new Vouchers.EMI_Vouchers_History());
            RecieptsMessagesUserControl = CreateUserControl("Reciepts Vouchers", new Vouchers.Reciepts_Messages());

            NewAgreementUserControl = CreateUserControl("New Agreement", new Aggrements.New_Aggrment());
            AgreementsUserControl = CreateUserControl("Agreements", new Aggrements.Aggrements());
            AuditAgreementsUserControl = CreateUserControl("Audit Agreements", new Aggrements.Audit_Aggrements());
            AgreementReturnUserControl = CreateUserControl("Agreement Return", new Aggrements.Aggrment_Return());
            AggrementReturnsHistoryUserControl = CreateUserControl("Agreement Returns", new Aggrements.Aggrement_Returns());
            GuardianDetailsControl = CreateUserControl("Guarantors Details", new Accounts.Account_Ledger_Statement());
            GuardiansUserControl = CreateUserControl("Guarantors", new Aggrements.Guardians());
            NewComplaintUserControl = CreateUserControl("New Complaint", new Complaints.New_Complaint());
            ComplaintsUserControl = CreateUserControl("Complaints", new Complaints.Complaints());
            CustomerDuesUserControl = CreateUserControl("Customer Dues", new Aggreements.Customer_Dues());
            LateCustomersUserControl = CreateUserControl("Late Customers", new Aggreements.Late_Customers());

            SingleMessageUserControl = CreateUserControl("Single Message", new Messages.Single_Message());
            BulkMessagesUserControl= CreateUserControl("Bulk Messages", new Messages.Bulk_Message());
            MessagesHistoryUserControl = CreateUserControl("Messages History", new Messages.Messages_History());
            MyMessagesGroupsUserControl = CreateUserControl("My Groups", new Messages.My_Groups());
            GroupsContactsUserControl = CreateUserControl("Groups Contacts", new Messages.Groups_Contacts());


        }


        XtraUserControl CreateUserControl(string text, UserControl form)
        {
            XtraUserControl result = new XtraUserControl();
            result.Name = text.ToLower() + "UserControl";
            result.Text = text;
            form.Dock = DockStyle.Fill;
            result.Controls.Add(form);
            return result;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            Backup_Restore.Backup_Restores bak_res = new Backup_Restore.Backup_Restores();
            bak_res.Update_Backup();

            db_handler.Close_Connection();
            TabbedView_Items();
            //dashboard_container.Controls.Add(new Dashboard() { Dock = DockStyle.Fill });
            //ribbonControl.ShowApplicationButtonContentControl();
            //Toggle Sidebar Menu
            sidebar_menu_panel.Visible = Settings.Default.show_main_sidebar_menu;
            if (sidebar_menu_panel.Visible == true)
            {
                show_hide_menu_btn.Text = "Hide Menu";
                show_hide_menu_btn.Image = Resources.left_16x16;
            }
            else
            {
                show_hide_menu_btn.Text = "Show Menu";
                show_hide_menu_btn.Image = Resources.alignverticalleft_16x16;
            }

            server_lbl.Text = Settings.Default.server_name + " ["+Settings.Default.db_name+"]";
            //Dashboard Show
            //tabbedView.AddDocument(DashboardUserControl);
            //tabbedView.ActivateDocument(DashboardUserControl);
            //{
            //    tabbedView.ActiveDocument.Image = Resources.pie2_16x16;
            //}
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Opacity = 100;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                Application_Settings.Super_Admin_Login login = new Application_Settings.Super_Admin_Login();
                login.Show(this);
            }
        }

        private void new_item_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((NewItemUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(NewItemUserControl);
                tabbedView.ActivateDocument(NewItemUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_item_btn.Glyph;
                }
            }
            else
            {
                NewItemUserControl = CreateUserControl("New Item", new Items.New_Item());
                tabbedView.AddDocument(NewItemUserControl);
                tabbedView.ActivateDocument(NewItemUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_item_btn.Glyph;
                }
            }
        }

        public void Items_List_Click()
        {
            if ((ItemsListUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(ItemsListUserControl);
                tabbedView.ActivateDocument(ItemsListUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_list_btn.Glyph;
                }
            }
            else
            {
                ItemsListUserControl = CreateUserControl("Items List", new Items.Items());
                tabbedView.AddDocument(ItemsListUserControl);
                tabbedView.ActivateDocument(ItemsListUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_list_btn.Glyph;
                }
            }
        }


        private void items_list_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Items_List_Click();
        }

        private void items_groups_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((ItemsGroupUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(ItemsGroupUserControl);
                tabbedView.ActivateDocument(ItemsGroupUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_groups_btn.Glyph;
                }
            }
            else
            {
                ItemsGroupUserControl = CreateUserControl("Items Groups", new Items.Groups.Item_Groups());
                tabbedView.AddDocument(ItemsGroupUserControl);
                tabbedView.ActivateDocument(ItemsGroupUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_groups_btn.Glyph;
                }
            }
        }

        private void items_catagory_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((ItemsCatagoryUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(ItemsCatagoryUserControl);
                tabbedView.ActivateDocument(ItemsCatagoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_catagory_btn.Glyph;
                }
            }
            else
            {
                ItemsCatagoryUserControl = CreateUserControl("Items Catagories", new Items.Catagories.Catagories());
                tabbedView.AddDocument(ItemsCatagoryUserControl);
                tabbedView.ActivateDocument(ItemsCatagoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_catagory_btn.Glyph;
                }
            }
        }

        private void items_Manufacturer_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((ItemsManufacturerUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(ItemsManufacturerUserControl);
                tabbedView.ActivateDocument(ItemsManufacturerUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_Manufacturer_btn.Glyph;
                }
            }
            else
            {
                ItemsManufacturerUserControl = CreateUserControl("Items Manufacturers", new Items.Manufacturers.Manufacturers());
                tabbedView.AddDocument(ItemsManufacturerUserControl);
                tabbedView.ActivateDocument(ItemsManufacturerUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_Manufacturer_btn.Glyph;
                }
            }
        }

        private void items_units_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((ItemsUnitsUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(ItemsUnitsUserControl);
                tabbedView.ActivateDocument(ItemsUnitsUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_units_btn.Glyph;
                }
            }
            else
            {
                ItemsUnitsUserControl = CreateUserControl("Items Units", new Items.Units.Units());
                tabbedView.AddDocument(ItemsUnitsUserControl);
                tabbedView.ActivateDocument(ItemsUnitsUserControl);
                {
                    tabbedView.ActiveDocument.Image = items_units_btn.Glyph;
                }
            }
        }

        private void low_stock_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((LowStockUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(LowStockUserControl);
                tabbedView.ActivateDocument(LowStockUserControl);
                {
                    tabbedView.ActiveDocument.Image = low_stock_btn.Glyph;
                }
            }
            else
            {
                LowStockUserControl = CreateUserControl("Low Stock", new Items.Low_Stock());
                tabbedView.AddDocument(LowStockUserControl);
                tabbedView.ActivateDocument(LowStockUserControl);
                {
                    tabbedView.ActiveDocument.Image = low_stock_btn.Glyph;
                }
            }
        }

        private void low_stock_at_stores_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((LowStockAtStoresUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(LowStockAtStoresUserControl);
                tabbedView.ActivateDocument(LowStockAtStoresUserControl);
                {
                    tabbedView.ActiveDocument.Image = low_stock_at_stores_btn.Glyph;
                }
            }
            else
            {
                LowStockAtStoresUserControl = CreateUserControl("Low Stock at Stores", new Items.Low_Stock_at_Stores());
                tabbedView.AddDocument(LowStockAtStoresUserControl);
                tabbedView.ActivateDocument(LowStockAtStoresUserControl);
                {
                    tabbedView.ActiveDocument.Image = low_stock_at_stores_btn.Glyph;
                }
            }
        }
        private void customers_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((CustomersUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(CustomersUserControl);
                tabbedView.ActivateDocument(CustomersUserControl);
                {
                    tabbedView.ActiveDocument.Image = customers_btn.Glyph;
                }
            }
            else
            {
                CustomersUserControl = CreateUserControl("Customers", new Sales.Customers());
                tabbedView.AddDocument(CustomersUserControl);
                tabbedView.ActivateDocument(CustomersUserControl);
                {
                    tabbedView.ActiveDocument.Image = customers_btn.Glyph;
                }
            }
        }

        private void customer_details_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((CustomersDetailsUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(CustomersDetailsUserControl);
                tabbedView.ActivateDocument(CustomersDetailsUserControl);
                {
                    tabbedView.ActiveDocument.Image = customer_details_btn.Glyph;
                }
            }
            else
            {
                CustomersDetailsUserControl = CreateUserControl("Customer Details", new Accounts.Account_Ledger_Statement());
                tabbedView.AddDocument(CustomersDetailsUserControl);
                tabbedView.ActivateDocument(CustomersDetailsUserControl);
                {
                    tabbedView.ActiveDocument.Image = customer_details_btn.Glyph;
                }
            }
        }


        private void new_account_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((NewAccountUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(NewAccountUserControl);
                tabbedView.ActivateDocument(NewAccountUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_account_btn.Glyph;
                }
            }
            else
            {
                NewAccountUserControl = CreateUserControl("New Account", new Accounts.New_Account());
                tabbedView.AddDocument(NewAccountUserControl);
                tabbedView.ActivateDocument(NewAccountUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_account_btn.Glyph;
                }
            }
        }

        public void Chart_of_Accounts_Click()
        {
            if ((ChartOfAccountsUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(ChartOfAccountsUserControl);
                tabbedView.ActivateDocument(ChartOfAccountsUserControl);
                {
                    tabbedView.ActiveDocument.Image = chart_of_accnts_btn.Glyph;
                }
            }
            else
            {
                ChartOfAccountsUserControl = CreateUserControl("Chart of Accounts", new Accounts.Chart_Of_Accounts());
                tabbedView.AddDocument(ChartOfAccountsUserControl);
                tabbedView.ActivateDocument(ChartOfAccountsUserControl);
                {
                    tabbedView.ActiveDocument.Image = chart_of_accnts_btn.Glyph;
                }
            }
        }

        private void chart_of_accnts_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Chart_of_Accounts_Click();
        }

        private void general_ledger_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((GeneralLedgerUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(GeneralLedgerUserControl);
                tabbedView.ActivateDocument(GeneralLedgerUserControl);
                {
                    tabbedView.ActiveDocument.Image = general_ledger_btn.Glyph;
                }
            }
            else
            {
                GeneralLedgerUserControl = CreateUserControl("General Statement", new Accounts.General_Ledger());
                tabbedView.AddDocument(GeneralLedgerUserControl);
                tabbedView.ActivateDocument(GeneralLedgerUserControl);
                {
                    tabbedView.ActiveDocument.Image = general_ledger_btn.Glyph;
                }
            }
        }

        private void accnt_ledger_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((AccountLedgerStatementUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(AccountLedgerStatementUserControl);
                tabbedView.ActivateDocument(AccountLedgerStatementUserControl);
                {
                    tabbedView.ActiveDocument.Image = accnt_ledger_btn.Glyph;
                }
            }
            else
            {
                AccountLedgerStatementUserControl = CreateUserControl("Account Ledger Statement", new Accounts.Account_Ledger_Statement());
                tabbedView.AddDocument(AccountLedgerStatementUserControl);
                tabbedView.ActivateDocument(AccountLedgerStatementUserControl);
                {
                    tabbedView.ActiveDocument.Image = accnt_ledger_btn.Glyph;
                }
            }
        }

        private void income_statement_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((IncomeStatementUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(IncomeStatementUserControl);
                tabbedView.ActivateDocument(IncomeStatementUserControl);
                {
                    tabbedView.ActiveDocument.Image = income_statement_btn.Glyph;
                }
            }
            else
            {
                IncomeStatementUserControl = CreateUserControl("Income Statement", new Accounts.Income_Statement());
                tabbedView.AddDocument(IncomeStatementUserControl);
                tabbedView.ActivateDocument(IncomeStatementUserControl);
                {
                    tabbedView.ActiveDocument.Image = income_statement_btn.Glyph;
                }
            }
        }

        private void trial_balance_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((TrialBalanceUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(TrialBalanceUserControl);
                tabbedView.ActivateDocument(TrialBalanceUserControl);
                {
                    tabbedView.ActiveDocument.Image = trial_balance_btn.Glyph;
                }
            }
            else
            {
                TrialBalanceUserControl = CreateUserControl("Trial Statement", new Accounts.Trial_Balance());
                tabbedView.AddDocument(TrialBalanceUserControl);
                tabbedView.ActivateDocument(TrialBalanceUserControl);
                {
                    tabbedView.ActiveDocument.Image = trial_balance_btn.Glyph;
                }
            }
        }

        private void expense_manager_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((ExpenseManagerUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(ExpenseManagerUserControl);
                tabbedView.ActivateDocument(ExpenseManagerUserControl);
                {
                    tabbedView.ActiveDocument.Image = expense_manager_btn.Glyph;
                }
            }
            else
            {
                ExpenseManagerUserControl = CreateUserControl("Expense Manager", new Accounts.Expense_Manager());
                tabbedView.AddDocument(ExpenseManagerUserControl);
                tabbedView.ActivateDocument(ExpenseManagerUserControl);
                {
                    tabbedView.ActiveDocument.Image = expense_manager_btn.Glyph;
                }
            }
        }

        private void account_groups_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((AccountGroupsUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(AccountGroupsUserControl);
                tabbedView.ActivateDocument(AccountGroupsUserControl);
                {
                    tabbedView.ActiveDocument.Image = account_groups_btn.Glyph;
                }
            }
            else
            {
                AccountGroupsUserControl = CreateUserControl("Account Groups", new Accounts.Account_Groups.Groups());
                tabbedView.AddDocument(AccountGroupsUserControl);
                tabbedView.ActivateDocument(AccountGroupsUserControl);
                {
                    tabbedView.ActiveDocument.Image = account_groups_btn.Glyph;
                }
            }
        }

        private void balanc_sheet_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((BalanceSheetUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(BalanceSheetUserControl);
                tabbedView.ActivateDocument(BalanceSheetUserControl);
                {
                    tabbedView.ActiveDocument.Image = balanc_sheet_btn.Glyph;
                }
            }
            else
            {
                BalanceSheetUserControl = CreateUserControl("Balance Sheet", new Accounts.Balance_Sheet());
                tabbedView.AddDocument(BalanceSheetUserControl);
                tabbedView.ActivateDocument(BalanceSheetUserControl);
                {
                    tabbedView.ActiveDocument.Image = balanc_sheet_btn.Glyph;
                }
            }
        }

        public void New_Purchase_Click()
        {
            if ((NewPurchaseUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(NewPurchaseUserControl);
                tabbedView.ActivateDocument(NewPurchaseUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_purchase_btn.Glyph;
                }
            }
            else
            {
                NewPurchaseUserControl = CreateUserControl("New Purchase", new Purchases.New_Purchase());
                tabbedView.AddDocument(NewPurchaseUserControl);
                tabbedView.ActivateDocument(NewPurchaseUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_purchase_btn.Glyph;
                }
            }
        }

        private void new_purchase_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.New_Purchase_Click();
        }

        private void purchases_history_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((PurchasesHistoryUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(PurchasesHistoryUserControl);
                tabbedView.ActivateDocument(PurchasesHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = purchases_history_btn.Glyph;
                }
            }
            else
            {
                PurchasesHistoryUserControl = CreateUserControl("Purchases History", new Purchases.Purchases_History());
                tabbedView.AddDocument(PurchasesHistoryUserControl);
                tabbedView.ActivateDocument(PurchasesHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = purchases_history_btn.Glyph;
                }
            }
        }

        private void purchase_returns_history_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((PurchaseReturnsHistoryUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(PurchaseReturnsHistoryUserControl);
                tabbedView.ActivateDocument(PurchaseReturnsHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = purchase_returns_history_btn.Glyph;
                }
            }
            else
            {
                PurchaseReturnsHistoryUserControl = CreateUserControl("Purchase Returns History", new Purchases.Purchase_Returns_History());
                tabbedView.AddDocument(PurchaseReturnsHistoryUserControl);
                tabbedView.ActivateDocument(PurchaseReturnsHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = purchase_returns_history_btn.Glyph;
                }
            }
        }

        private void suppliers_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((NewPurchaseUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(NewPurchaseUserControl);
                tabbedView.ActivateDocument(NewPurchaseUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_purchase_btn.Glyph;
                }
            }
            else
            {
                NewPurchaseUserControl = CreateUserControl("Suppliers", new Purchases.New_Purchase());
                tabbedView.AddDocument(NewPurchaseUserControl);
                tabbedView.ActivateDocument(NewPurchaseUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_purchase_btn.Glyph;
                }
            }
        }

        private void supplier_details_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((NewPurchaseUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(NewPurchaseUserControl);
                tabbedView.ActivateDocument(NewPurchaseUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_purchase_btn.Glyph;
                }
            }
            else
            {
                NewPurchaseUserControl = CreateUserControl("Supplier Details", new Purchases.New_Purchase());
                tabbedView.AddDocument(NewPurchaseUserControl);
                tabbedView.ActivateDocument(NewPurchaseUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_purchase_btn.Glyph;
                }
            }
        }

        private void tinestar_hyperlink_Click(object sender, EventArgs e)
        {
            Process.Start("www.alasratechnologies.com/");
        }

        private void stores_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((StoresUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(StoresUserControl);
                tabbedView.ActivateDocument(StoresUserControl);
                {
                    tabbedView.ActiveDocument.Image = stores_btn.Glyph;
                }
            }
            else
            {
                StoresUserControl = CreateUserControl("Stores", new Items.Stores.Stores());
                tabbedView.AddDocument(StoresUserControl);
                tabbedView.ActivateDocument(StoresUserControl);
                {
                    tabbedView.ActiveDocument.Image = stores_btn.Glyph;
                }
            }
        }

        private void general_vchr_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Vouchers.Journal_Voucher voucher = new Vouchers.Journal_Voucher();
            voucher.Show(this);
        }

        private void receipt_vchr_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Vouchers.Receipt_Voucher voucher = new Vouchers.Receipt_Voucher();
            voucher.Show(this);
        }

        private void payment_vochr_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Vouchers.Payment_Voucher voucher = new Vouchers.Payment_Voucher();
            voucher.Show(this);
        }

        private void vouchers_history_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((VouchersHistoryUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(VouchersHistoryUserControl);
                tabbedView.ActivateDocument(VouchersHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = vouchers_history_btn.Glyph;
                }
            }
            else
            {
                VouchersHistoryUserControl = CreateUserControl("Vouchers History", new Vouchers.Vouchers_History());
                tabbedView.AddDocument(VouchersHistoryUserControl);
                tabbedView.ActivateDocument(VouchersHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = vouchers_history_btn.Glyph;
                }
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form form = new Login_Form();
            form.Show();
        }

        private void settings_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application_Settings.Admin_Settings form = new Application_Settings.Admin_Settings();
            form.Show(this);
        }

        private void stock_adjustment_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Items.Stock_Adjustment form = new Items.Stock_Adjustment();
            form.Show(this);
        }

        private void day_book_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Day_Book form = new Accounts.Day_Book();
            form.Show(this);
        }

        private void logout_btn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form form = new Login_Form();
            form.Show();
        }

        private void update_backup_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            db_handler.Open_Connection();
            Backup_Restore.Backup_Restores bak_res = new Backup_Restore.Backup_Restores();
            bak_res.Update_Backup();
            db_handler.Close_Connection();
            XtraMessageBox.Show("Backup is updated !");
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure, you want to exit?", "Warning Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) != DialogResult.No)
            {
                if (Messages.SMS_Gateway.client != null)
                {
                    if (Messages.SMS_Gateway.client.Connected)
                    {
                        Messages.SMS_Gateway.client.Close();
                    }
                }
                //Taking Backup on closing application !
                db_handler.Open_Connection();
                Backup_Restore.Backup_Restores bak_res = new Backup_Restore.Backup_Restores();
                bak_res.Update_Backup();
                db_handler.Close_Connection();
            }
            else
            {
                e.Cancel = true;
            }
        }

        public void Employees_Click()
        {
            if ((EmployeesUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(EmployeesUserControl);
                tabbedView.ActivateDocument(EmployeesUserControl);
                {
                    tabbedView.ActiveDocument.Image = employees_btn.Glyph;
                }
            }
            else
            {
                EmployeesUserControl = CreateUserControl("Employees", new Employees.Employees());
                tabbedView.AddDocument(EmployeesUserControl);
                tabbedView.ActivateDocument(EmployeesUserControl);
                {
                    tabbedView.ActiveDocument.Image = employees_btn.Glyph;
                }
            }
        }

        private void employees_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Employees_Click();
        }

        private void employee_payment_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Employees.Salary_Payment uc = new Employees.Salary_Payment();
            uc.Dock = DockStyle.Fill;
            UC_Opener_Form form = new UC_Opener_Form("Salary Payment", uc);
            form.Size = new Size(uc.Width, uc.Height+25);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.Show(this);
        }


        private void employee_advance_payment_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Employees.Employee_Advance_Payment uc = new Employees.Employee_Advance_Payment();
            uc.Dock = DockStyle.Fill;
            UC_Opener_Form form = new UC_Opener_Form("Employee Advance Payment", uc);
            form.Size = new Size(uc.Width, uc.Height);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.Show(this);
        }

        public void Employee_Payments_History_Click()
        {
            if ((EmployeePaymentsHistoryUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(EmployeePaymentsHistoryUserControl);
                tabbedView.ActivateDocument(EmployeePaymentsHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = payment_history_btn.Glyph;
                }
            }
            else
            {
                EmployeePaymentsHistoryUserControl = CreateUserControl("Employees Payment History", new Employees.Payment_History());
                tabbedView.AddDocument(EmployeePaymentsHistoryUserControl);
                tabbedView.ActivateDocument(EmployeePaymentsHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = payment_history_btn.Glyph;
                }
            }
        }

        private void payment_history_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Employee_Payments_History_Click();
        }

        private void new_aggrement_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((NewAgreementUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(NewAgreementUserControl);
                tabbedView.ActivateDocument(NewAgreementUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_aggrement_btn.Glyph;
                }
            }
            else
            {
                NewAgreementUserControl = CreateUserControl("New Agreement", new Aggrements.New_Aggrment());
                tabbedView.AddDocument(NewAgreementUserControl);
                tabbedView.ActivateDocument(NewAgreementUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_aggrement_btn.Glyph;
                }
            }
        }

        private void aggrements_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((AgreementsUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(AgreementsUserControl);
                tabbedView.ActivateDocument(AgreementsUserControl);
                {
                    tabbedView.ActiveDocument.Image = aggrements_btn.Glyph;
                }
            }
            else
            {
                AgreementsUserControl = CreateUserControl("Agreements", new Aggrements.Aggrements());
                tabbedView.AddDocument(AgreementsUserControl);
                tabbedView.ActivateDocument(AgreementsUserControl);
                {
                    tabbedView.ActiveDocument.Image = aggrements_btn.Glyph;
                }
            }
        }

        private void new_message_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((SingleMessageUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(SingleMessageUserControl);
                tabbedView.ActivateDocument(SingleMessageUserControl);
                {
                    tabbedView.ActiveDocument.Image = single_message_btn.Glyph;
                }
            }
            else
            {
                SingleMessageUserControl = CreateUserControl("Single Message", new Messages.Single_Message());
                tabbedView.AddDocument(SingleMessageUserControl);
                tabbedView.ActivateDocument(SingleMessageUserControl);
                {
                    tabbedView.ActiveDocument.Image = single_message_btn.Glyph;
                }
            }
        }

        private void messages_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((MessagesHistoryUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(MessagesHistoryUserControl);
                tabbedView.ActivateDocument(MessagesHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = messages_btn.Glyph;
                }
            }
            else
            {
                MessagesHistoryUserControl = CreateUserControl("Messages History", new Messages.Messages_History());
                tabbedView.AddDocument(MessagesHistoryUserControl);
                tabbedView.ActivateDocument(MessagesHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = messages_btn.Glyph;
                }
            }
        }

        public void Stock_Transfer_Click()
        {
            if ((StockTransferUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(StockTransferUserControl);
                tabbedView.ActivateDocument(StockTransferUserControl);
                {
                    tabbedView.ActiveDocument.Image = stock_adjustment_btn.Glyph;
                }
            }
            else
            {
                StockTransferUserControl = CreateUserControl("Stock Transfer", new Items.Stock_Transfer());
                tabbedView.AddDocument(StockTransferUserControl);
                tabbedView.ActivateDocument(StockTransferUserControl);
                {
                    tabbedView.ActiveDocument.Image = stock_adjustment_btn.Glyph;
                }
            }
        }

        private void stock_transfer_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Stock_Transfer_Click();
        }

        private void guardians_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((GuardiansUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(GuardiansUserControl);
                tabbedView.ActivateDocument(GuardiansUserControl);
                {
                    tabbedView.ActiveDocument.Image = guardians_btn.Glyph;
                }
            }
            else
            {
                GuardiansUserControl = CreateUserControl("Guarantors", new Aggrements.Guardians());
                tabbedView.AddDocument(GuardiansUserControl);
                tabbedView.ActivateDocument(GuardiansUserControl);
                {
                    tabbedView.ActiveDocument.Image = guardians_btn.Glyph;
                }
            }
        }

        private void guadian_details_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((GuardianDetailsControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(GuardianDetailsControl);
                tabbedView.ActivateDocument(GuardianDetailsControl);
                {
                    tabbedView.ActiveDocument.Image = guadian_details_btn.Glyph;
                }
            }
            else
            {
                GuardianDetailsControl = CreateUserControl("Guarantors Details", new Accounts.Account_Ledger_Statement());
                tabbedView.AddDocument(GuardianDetailsControl);
                tabbedView.ActivateDocument(GuardianDetailsControl);
                {
                    tabbedView.ActiveDocument.Image = guadian_details_btn.Glyph;
                }
            }
        }

        private void new_emi_voucher_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Vouchers.Issue_EMI_Voucher form = new Vouchers.Issue_EMI_Voucher(DateTime.Now);
            form.Show(this);
        }

        private void emi_vouchers_history_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((EMIVouchersHistoryUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(EMIVouchersHistoryUserControl);
                tabbedView.ActivateDocument(EMIVouchersHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = emi_vouchers_history_btn.Glyph;
                }
            }
            else
            {
                EMIVouchersHistoryUserControl = CreateUserControl("EMI Vouchers History", new Vouchers.EMI_Vouchers_History());
                tabbedView.AddDocument(EMIVouchersHistoryUserControl);
                tabbedView.ActivateDocument(EMIVouchersHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = emi_vouchers_history_btn.Glyph;
                }
            }
        }

        private void cash_vouchers_history_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((CashVouchersHistoryUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(CashVouchersHistoryUserControl);
                tabbedView.ActivateDocument(CashVouchersHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = cash_vouchers_history_btn.Glyph;
                }
            }
            else
            {
                CashVouchersHistoryUserControl = CreateUserControl("Cash Vouchers History", new Vouchers.Cash_Vouchers_History());
                tabbedView.AddDocument(CashVouchersHistoryUserControl);
                tabbedView.ActivateDocument(CashVouchersHistoryUserControl);
                {
                   tabbedView.ActiveDocument.Image = cash_vouchers_history_btn.Glyph;
                }
            }
        }

        private void purch_master_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Purchases.Purchases_Master().Show();
        }

        private void purch_details_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Purchases.Purchase_Details().Show();
        }

        private void purch_returns_master_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Purchases.Purchase_Returns_Master().Show();
        }

        private void purch_return_details_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Purchases.Purchase_Return_Details().Show();
        }

        private void as_supplier_purch_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Purchases.Supplier_Wise_Purchases().Show();
        }

        private void as_item_purch_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Purchases.Item_Wise_Purchases().Show();
        }

        private void master_stocks_transactions_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Stocks_Transactions.Master_Stocks_Transactions().Show();
        }

        private void as_store_stocks_transactions_rep_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Stocks_Transactions.Store_Wise_Stocks_Transactions().Show();
        }

        private void available_stock_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Available_Stock().Show();
        }

        private void available_stock_at_stores_rep_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Available_Stock_at_Stores().Show();
        }

        private void low_stock_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Low_Stock().Show();
        }

        private void low_stock_at_stores_rep_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Low_Stock_at_Stores().Show();
        }

        private void dues_master_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Dues.Dues_Master().Show();
        }

        private void late_customers_dues_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Dues.Late_Customers_Dues().Show();
        }

        private void defaulters_dues_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Dues.Defualters_Dues().Show();
        }

        private void aggrements_master_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Sales.Sales_Master().Show();
        }

        private void as_customer_aggrements_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Sales.Customer_Wise_Sales().Show();
        }

        private void store_wise_expenses_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Expenses.Area_Code_Wise_Expenses().Show();
        }

        private void custom_expenses_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Expenses.General_Expenses().Show();
        }

        private void messages_master_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Messages.Messages_Master().Show();
        }

        private void customer_wise_messages_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Messages.Customer_Wise_Messages().Show();
        }

        private void phone_wise_messages_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Messages.Phone_Wise_Messages().Show();
        }

        private void store_wise_messages_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Messages.Store_Wise_Messages().Show();
        }

        private void cash_vouchers_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Vouchers.Cash_Vouchers().Show();
        }

        private void emi_vouchers_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Vouchers.EMI_Vouchers().Show();
        }



        private void journal_vouchers_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Vouchers.Journal_Vouchers().Show();
        }

        private void receipt_vouchers_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Vouchers.Receipt_Vouchers().Show();
        }

        private void payment_vouchers_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Vouchers.Payment_Vouchers().Show();
        }

        private void accnt_ledger_statement_rep_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Accounts.Account_Ledger_Statement().Show();
        }

        private void flush_db_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("All the data/entries will be deleted from the database.\nAre you sure, you want to flush the database?", "Warning Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            {
                DatabaseHandler db_handler = new DatabaseHandler();
                db_handler.TRUNCATE_DATABASE();
                XtraMessageBox.Show("Database is flushed !");
            }
        }

        private void dashboard_acc_btn_Click(object sender, EventArgs e)
        {
            if ((DashboardUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(DashboardUserControl);
                tabbedView.ActivateDocument(DashboardUserControl);
                {
                    tabbedView.ActiveDocument.Image = Resources.pie2_16x16;
                }
            }
            else
            {
                DashboardUserControl = CreateUserControl("Dashboard", new Dashboard());
                tabbedView.AddDocument(DashboardUserControl);
                tabbedView.ActivateDocument(DashboardUserControl);
                {
                    tabbedView.ActiveDocument.Image = Resources.pie2_16x16;
                }
            }
        }

        private void receipt_vchr_acc_btn_Click(object sender, EventArgs e)
        {
            new Vouchers.Receipt_Voucher().Show(this);
        }

        private void payment_vchr_acc_btn_Click(object sender, EventArgs e)
        {
            new Vouchers.Payment_Voucher().Show(this);
        }

        private void chart_of_accnts_acc_btn_Click(object sender, EventArgs e)
        {
            this.Chart_of_Accounts_Click();
        }

        private void new_purchase_acc_btn_Click(object sender, EventArgs e)
        {
            this.New_Purchase_Click();
        }

        private void stock_transfer_acc_btn_Click(object sender, EventArgs e)
        {
            this.Stock_Transfer_Click();
        }

        private void employees_acc_btn_Click(object sender, EventArgs e)
        {
            this.Employees_Click();
        }

        private void employee_payment_acc_btn_Click(object sender, EventArgs e)
        {
            Employees.Salary_Payment uc = new Employees.Salary_Payment();
            uc.Dock = DockStyle.Fill;
            UC_Opener_Form form = new UC_Opener_Form("Salary Payment", uc);
            form.Size = new Size(uc.Width, uc.Height + 25);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.Show(this);
        }

        private void items_list_acc_btn_Click(object sender, EventArgs e)
        {
            this.Items_List_Click();
        }

        private void emp_payments_history_acc_btn_Click(object sender, EventArgs e)
        {
            this.Employee_Payments_History_Click();
        }

        private void new_complaint_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((NewComplaintUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(NewComplaintUserControl);
                tabbedView.ActivateDocument(NewComplaintUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_complaint_btn.Glyph;
                }
            }
            else
            {
                NewComplaintUserControl = CreateUserControl("New Complaint", new Complaints.New_Complaint());
                tabbedView.AddDocument(NewComplaintUserControl);
                tabbedView.ActivateDocument(NewComplaintUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_complaint_btn.Glyph;
                }
            }
        }

        private void complaints_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((ComplaintsUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(ComplaintsUserControl);
                tabbedView.ActivateDocument(ComplaintsUserControl);
                {
                    tabbedView.ActiveDocument.Image = new_complaint_btn.Glyph;
                }
            }
            else
            {
                ComplaintsUserControl = CreateUserControl("Complaints", new Complaints.Complaints());
                tabbedView.AddDocument(ComplaintsUserControl);
                tabbedView.ActivateDocument(ComplaintsUserControl);
                {
                    tabbedView.ActiveDocument.Image = complaints_btn.Glyph;
                }
            }
        }

        private void stock_transactions_history_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((StockTransactionsHistoryUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(StockTransactionsHistoryUserControl);
                tabbedView.ActivateDocument(StockTransactionsHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = stock_transactions_history_btn.Glyph;
                }
            }
            else
            {
                StockTransactionsHistoryUserControl = CreateUserControl("Stock Transactions History", new Items.Stock_Transactions_History());
                tabbedView.AddDocument(StockTransactionsHistoryUserControl);
                tabbedView.ActivateDocument(StockTransactionsHistoryUserControl);
                {
                    tabbedView.ActiveDocument.Image = stock_transactions_history_btn.Glyph;
                }
            }
        }

        private void stock_return_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((StockReturnUserControl.IsHandleCreated) == true)
            {
                tabbedView.AddDocument(StockReturnUserControl);
                tabbedView.ActivateDocument(StockReturnUserControl);
                {
                    tabbedView.ActiveDocument.Image = stock_return_btn.Glyph;
                }
            }
            else
            {
                StockReturnUserControl = CreateUserControl("Stock Return", new Items.Stock_Return());
                tabbedView.AddDocument(StockReturnUserControl);
                tabbedView.ActivateDocument(StockReturnUserControl);
                {
                    tabbedView.ActiveDocument.Image = stock_return_btn.Glyph;
                }
            }
        }

        private void stock_returns_history_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((StockReturnsHistoryUserControl.IsHandleCreated) == false)
            {
                StockReturnsHistoryUserControl = CreateUserControl("Stock Returns History", new Items.Stock_Return_History());
            }
            tabbedView.AddDocument(StockReturnsHistoryUserControl);
            tabbedView.ActivateDocument(StockReturnsHistoryUserControl);
            {
                tabbedView.ActiveDocument.Image = stock_returns_history_btn.Glyph;
            }
        }

        private void salaries_master_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Salaries.Salaries_Master().Show();
        }

        private void employee_wise_salary_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Salaries.Employee_Wise_Salary().Show();
        }

        private void advance_payment_master_rep_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void employee_wise_advance_payment_rep_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void available_stock_with_value_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Available_Stock_With_Value().Show();
        }

        private void available_stock_at_stores_with_value_rep_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Available_Stock_at_Stores_With_Value().Show();
        }

        private void new_customer_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new UC_Opener_Form("New Customer", new Sales.New_Customer(-1)).Show(this);
        }

        private void new_guardian_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new UC_Opener_Form("New Guarantor", new Aggrements.New_Guardian(-1)).Show(this);
        }

        private void new_store_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Items.Stores.New_Store().Show(this);
        }

        private void new_employee_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Employees.New_Employee().Show(this);
        }

        private void new_cash_voucher_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Vouchers.Cash_Voucher UC = new Vouchers.Cash_Voucher();
            new UC_Opener_Form("New Cash Voucher", UC) { WindowState = FormWindowState.Maximized, Is_New_Cash_Voucher = true, CASH_VOUCHER = UC }.Show(this);
        }

        private void show_hide_menu_btn_Click(object sender, EventArgs e)
        {
            if (sidebar_menu_panel.Visible == false)
            {
                sidebar_menu_panel.Visible = true;
                show_hide_menu_btn.Text = "Hide Menu";
                show_hide_menu_btn.Image = Resources.left_16x16;
            }
            else
            {
                sidebar_menu_panel.Visible = false;
                show_hide_menu_btn.Text = "Show Menu";
                show_hide_menu_btn.Image = Resources.alignverticalleft_16x16;
            }

            Settings.Default["show_main_sidebar_menu"] = sidebar_menu_panel.Visible;
            Settings.Default.Save();
        }

        private void opening_sales_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Opening_Sales().Show(this);
        }

        private void debitors_entry_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Opening_Sales().Show(this);
        }

        private void creditors_entry_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Accounts.Creditors_Entry().Show(this);
        }

        private void customers_master_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Customers.Customers_List().Show();
        }

        private void customers_ledger_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Customers.Customers_Ledger().Show();
        }

        private void area_wise_customers_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Customers.Area_Wise_Customers form = new Reports.Customers.Area_Wise_Customers();
            form.Show();
        }

        private void available_stock_at_stores_with_profit_rep_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Available_Stock_at_Store_With_Profit().Show();
        }

        private void stock_book_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Reports.Stocks.Stocks_Transactions.Stock_Book form = new Reports.Stocks.Stocks_Transactions.Stock_Book();
            //form.Show();
        }

        private void bulk_messages_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((BulkMessagesUserControl.IsHandleCreated) == false)
            {
                BulkMessagesUserControl = CreateUserControl("Bulk Messages", new Messages.Bulk_Message());
            }

            tabbedView.AddDocument(BulkMessagesUserControl);
            tabbedView.ActivateDocument(BulkMessagesUserControl);
            {
                tabbedView.ActiveDocument.Image = bulk_messages_btn.Glyph;
            }
        }

        private void new_message_group_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Messages.New_Group().Show(this);
        }

        private void messages_groups_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((MyMessagesGroupsUserControl.IsHandleCreated) == false)
            {
                MyMessagesGroupsUserControl = CreateUserControl("My Groups", new Messages.My_Groups());
            }

            tabbedView.AddDocument(MyMessagesGroupsUserControl);
            tabbedView.ActivateDocument(MyMessagesGroupsUserControl);
            {
                tabbedView.ActiveDocument.Image = messages_groups_btn.Glyph;
            }
        }

        private void add_message_contact_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Messages.Add_Contact().Show(this);
        }

        private void message_group_contact_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((GroupsContactsUserControl.IsHandleCreated) == false)
            {
                GroupsContactsUserControl = CreateUserControl("Groups Contacts", new Messages.Groups_Contacts());
            }

            tabbedView.AddDocument(GroupsContactsUserControl);
            tabbedView.ActivateDocument(GroupsContactsUserControl);
            {
                tabbedView.ActiveDocument.Image = message_group_contact_btn.Glyph;
            }
        }

        private void custome_dues_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((CustomerDuesUserControl.IsHandleCreated) == false)
            {
                CustomerDuesUserControl = CreateUserControl("Customer Dues", new Aggreements.Customer_Dues());
            }

            tabbedView.AddDocument(CustomerDuesUserControl);
            tabbedView.ActivateDocument(CustomerDuesUserControl);
            {
                tabbedView.ActiveDocument.Image = custome_dues_btn.Glyph;
            }
        }

        private void late_customers_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((LateCustomersUserControl.IsHandleCreated) == false)
            {
                LateCustomersUserControl = CreateUserControl("Late Customers", new Aggreements.Late_Customers());
            }

            tabbedView.AddDocument(LateCustomersUserControl);
            tabbedView.ActivateDocument(LateCustomersUserControl);
            {
                tabbedView.ActiveDocument.Image = late_customers_btn.Glyph;
            }
        }

        private void sales_details_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Sales.Sales_Details().Show();
        }

        private void profit_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Sales.Profit_Reports.Profit_Report().Show();
        }

        private void customer_wise_profit_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Sales.Profit_Reports.Customer_Wise_Profit form = new Reports.Sales.Profit_Reports.Customer_Wise_Profit();
            form.Show();
        }

        private void items_models_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((ItemsModelsUserControl.IsHandleCreated) == false)
            {
                ItemsModelsUserControl = CreateUserControl("Items Models", new Items.Models.Models());
            }

            tabbedView.AddDocument(ItemsModelsUserControl);
            tabbedView.ActivateDocument(ItemsModelsUserControl);
            {
                tabbedView.ActiveDocument.Image = items_models_btn.Glyph;
            }
        }

        private void bal_adjustmnt_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            //new Vouchers.Balance_Adjustment().Show(this);
        }

        private void item_wise_sales_01_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Sales.Item_Wise_Profit().Show();
        }

        private void item_wise_sales_02_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Sales.Area_Wise_Profit().Show();
        }

        private void item_wise_sales_03_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Sales.Area_Wise_Sales().Show();
        }

        private void agreements_returns_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((AgreementReturnUserControl.IsHandleCreated) == false)
            {
                AgreementReturnUserControl = CreateUserControl("Agreement Return", new Aggrements.Aggrment_Return());
            }

            tabbedView.AddDocument(AgreementReturnUserControl);
            tabbedView.ActivateDocument(AgreementReturnUserControl);
            {
                tabbedView.ActiveDocument.Image = agreements_returns_btn.Glyph;
            }
        }

        private void area_wise_balances_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Customers.Area_Wise_Balances().Show();
        }

        private void reciept_vouchers_sms_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((RecieptsMessagesUserControl.IsHandleCreated) == false)
            {
                RecieptsMessagesUserControl = CreateUserControl("Reciepts Vouchers", new Vouchers.Reciepts_Messages());
            }

            tabbedView.AddDocument(RecieptsMessagesUserControl);
            tabbedView.ActivateDocument(RecieptsMessagesUserControl);
            {
                tabbedView.ActiveDocument.Image = reciept_vouchers_sms_btn.Glyph;
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Employees.Commissions.Add_Commission().Show(this);
        }

        private void item_commission_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((ItemsCommissionUserControl.IsHandleCreated) == false)
            {
                ItemsCommissionUserControl = CreateUserControl("Items Commission", new Employees.Commissions.Items_Commission());
            }

            tabbedView.AddDocument(ItemsCommissionUserControl);
            tabbedView.ActivateDocument(ItemsCommissionUserControl);
            {
                tabbedView.ActiveDocument.Image = item_commission_btn.Glyph;
            }
        }

        private void area_wise_commission_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Employees.Commission.Area_Code_Wise_Commission_Report_Form().Show(this);
        }

        private void cash_vouchers_history_master_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((CashVouchersHistoryMasterUserControl.IsHandleCreated) == false)
            {
                CashVouchersHistoryMasterUserControl = CreateUserControl("Cash Vouchers Master", new Vouchers.Cash_Vouchers_History_Master());
            }

            tabbedView.AddDocument(CashVouchersHistoryMasterUserControl);
            tabbedView.ActivateDocument(CashVouchersHistoryMasterUserControl);
            {
                tabbedView.ActiveDocument.Image = cash_vouchers_history_master_btn.Glyph;
            }
        }

        private void aggrement_returns_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((AggrementReturnsHistoryUserControl.IsHandleCreated) == false)
            {
                AggrementReturnsHistoryUserControl = CreateUserControl("Agreement Returns", new Aggrements.Aggrement_Returns());
            }

            tabbedView.AddDocument(AggrementReturnsHistoryUserControl);
            tabbedView.ActivateDocument(AggrementReturnsHistoryUserControl);
            {
                tabbedView.ActiveDocument.Image = aggrement_returns_btn.Glyph;
            }
        }

        private void bulk_cash_vouchers_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((BulkCashVoucherUserControl.IsHandleCreated) == false)
            {
                BulkCashVoucherUserControl = CreateUserControl("Bulk Cash Voucher", new Vouchers.Bulk_Cash_Voucher());
            }

            tabbedView.AddDocument(BulkCashVoucherUserControl);
            tabbedView.ActivateDocument(BulkCashVoucherUserControl);
            {
                tabbedView.ActiveDocument.Image = bulk_cash_vouchers_btn.Glyph;
            }
        }

        private void saleItemsMasterReportBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Sales.Sale_Items_Master().Show();
        }

        private void sale_return_details_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void stock_transactions_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Reports.Stocks.Stocks_Transactions.Stock_Transactions().Show(this);
        }

        private void salesCounter_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Sales.Sales_Counter().Show(this);
        }

        private void recovery_master_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Recovery_Master().Show();
        }

        private void stock_ledger_rep_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            new Stock_Ledger().Show();
        }

        private void audit_aggrements_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((AuditAgreementsUserControl.IsHandleCreated) == false)
            {
                AuditAgreementsUserControl = CreateUserControl("Audit Aggrements", new Aggrements.Audit_Aggrements());
            }

            tabbedView.AddDocument(AuditAgreementsUserControl);
            tabbedView.ActivateDocument(AuditAgreementsUserControl);
            {
                tabbedView.ActiveDocument.Image = audit_aggrements_btn.Glyph;
            }
        }
    }
}