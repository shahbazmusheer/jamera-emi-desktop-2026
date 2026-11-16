using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Jamera.Properties;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;

namespace Jamera
{
    public class DatabaseHandler
    {
        String server_name = Settings.Default.server_name;
        String db_name = Settings.Default.db_name;
        String user_name = Settings.Default.db_user_name;
        String password = Settings.Default.db_password;
        String alert_msgbox_msg = "Error Alert";
        MessageBoxIcon alert_msgbx_icon = MessageBoxIcon.Warning;
        CustomStringConnectionParameters connection_custom_string_parameters = new CustomStringConnectionParameters();
        //Connection For SQLEXPRESS Server :
        public SqlConnection conn = null;
       public DatabaseHandler()
        {
            //if (Settings.Default.custom_connection != null || Settings.Default.custom_connection != "")
            //{
            //    conn = new SqlConnection();
            //    conn.ConnectionString = Settings.Default.custom_connection;
            //    //XtraMessageBox.Show(conn.ConnectionString);
            //}
            //else
            //{
                conn = new SqlConnection(@"Data Source=" + this.server_name + ";Initial Catalog=" + this.db_name + ";User ID=" + this.user_name + ";Password=" + this.password + ";MultipleActiveResultSets=True;Pooling=False;");
                //conn = new SqlConnection(@"Data Source=" +this.server_name + ";Initial Catalog=" + this.db_name + ";User ID=" + this.user_name + ";Password=" + this.password + ";MultipleActiveResultSets=True;Pooling=False;");
            //}
        }

        public CustomStringConnectionParameters Get_Connection_Parameters()
        {
            return this.connection_custom_string_parameters;

        }
        public void Open_Connection()
        {
            conn.Open();
        }
        public void Close_Connection()
        {
            conn.Close();
        }

        public SqlConnection GetDatabseConnection()
        {
            //if (!(conn.State == System.Data.ConnectionState.Open))
            //{
            //    conn.Open();
            //}
            return this.conn;
        }

        public void createAllTables()
        {
            conn.Open();
            createTableCashVouchers();
            createTableCashVoucherItems();
            createTableStockReturns();
            createTableStockReturnItems();
            createTableItemModels();
            createTableStores();
            createTableNatures();
            createTableStockTransactions();
            createTableStockTransactionItems();
            createTableAccountGroups();
            createTableAccounts();
            createTableJournalTransactions();
            createTableVoucherTypes();
            createTableVouchers();
            createTableEmiVouchers();
            createTableItemGroups();
            createTableItemManufacturers();
            createTableItemUnits();
            createTableItemCategories();
            createTablePurchasesRetrunItems();
            createTableItemRacks();
            createTableItems();
            createTablePurchases();
            createTablePurchaseItems();
            createTableRoles();
            InertDataToRolesTable();
            createTableSaleItems();
            createTableSalesReturnItems();
            createTableSalesReturn();
            createTablePurchasesReturn();
            InertDataToNaturesTable();
            createTableGuardians();
            InertDataToAccountGroupsTable();
            InertDataToVocharTypesTable();
            InertDataToAccountsTable();
            createTableAggrements();
            createTableAggrementDues();
            createTableAgreementReturns();
            createTableAgreementReturnItems();
            createTableStoreTeams();
            createTableMessageGroups();
            createTableMessages();
            createTableGroupContacts();
            createTableEmployeesSalaries();
            createTableComplaints();
            createTableComplaintUpdates();
            createTableCommissions();
            conn.Close();
        }

        public void Create_Database()
        {
            try
            {
                SqlConnection db_conn = new SqlConnection(@"Data Source=" + System.Environment.MachineName.ToString() + @"\" + this.server_name + ";User ID=" + this.user_name + ";Password=" + this.password + ";MultipleActiveResultSets=True;Pooling=False;");
                String query = @"IF NOT EXISTS(SELECT * from sys.databases where name='" + db_name + @"') CREATE DATABASE " + db_name;
                SqlCommand cmd = new SqlCommand(query, db_conn);
                db_conn.Open();
                cmd.ExecuteNonQuery();
                db_conn.Close();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void Restore_Database(String File_Path)
        {
            try
            {
                SqlConnection db_conn = new SqlConnection(@"Data Source=" + System.Environment.MachineName.ToString() + @"\" + this.server_name + ";User ID=" + this.user_name + ";Password=" + this.password + ";MultipleActiveResultSets=True;Pooling=False;");
                string query = "RESTORE DATABASE[" + db_name + "] FROM DISK = N'" + File_Path + "' WITH FILE = 1, NOUNLOAD, STATS = 10";
                SqlCommand cmd = new SqlCommand(query, db_conn);
                db_conn.Open();
                cmd.ExecuteNonQuery();
                db_conn.Close();
                XtraMessageBox.Show(db_name + " has been restored, successfully!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void Truncate_Table(String TABLE_NAME)
        {
            conn.Open();
            String query = @"TRUNCATE TABLE "+TABLE_NAME+";";
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void createTableMessageGroups()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='message_groups') CREATE TABLE message_groups(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),name VARCHAR(255),description VARCHAR(255))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void TRUNCATE_DATABASE()
        {

            Truncate_Table("cash_vouchers");
            Truncate_Table("cash_voucher_items");
            Truncate_Table("stock_returns");
            Truncate_Table("stock_return_items");
            Truncate_Table("stores");
            Truncate_Table("natures");
            Truncate_Table("stock_transactions");
            Truncate_Table("stock_transaction_items");
            Truncate_Table("account_groups");
            Truncate_Table("accounts");
            Truncate_Table("journal_transactions");
            Truncate_Table("voucher_types");
            Truncate_Table("vouchers");
            Truncate_Table("emi_vouchers");
            Truncate_Table("item_groups");
            Truncate_Table("item_models");
            Truncate_Table("store_teams");
            Truncate_Table("item_manufacturers");
            Truncate_Table("item_units");
            Truncate_Table("item_categories");
            Truncate_Table("purchases_return_items");
            Truncate_Table("item_racks");
            Truncate_Table("items");
            Truncate_Table("purchases");
            Truncate_Table("purchase_items");
            Truncate_Table("roles");
            Truncate_Table("sale_items");
            Truncate_Table("sales_return_items");
            Truncate_Table("sales_return");
            Truncate_Table("purchases_return");
            Truncate_Table("guardians");
            Truncate_Table("aggrements");
            Truncate_Table("aggrement_dues");
            Truncate_Table("agreement_returns");
            Truncate_Table("agreement_return_items");
            Truncate_Table("messages");
            Truncate_Table("message_groups");
            Truncate_Table("group_contacts");
            Truncate_Table("complaints");
            Truncate_Table("complaint_updates");
            Truncate_Table("commissions");
            createAllTables();
        }
        public void createTableGroupContacts()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='group_contacts') CREATE TABLE group_contacts(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),store_id NUMERIC(37),group_id NUMERIC(37),name VARCHAR(200),office_phone VARCHAR(200),home_phone VARCHAR(200),address VARCHAR(700),remarks VARCHAR(200))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableComplaints()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='complaints') CREATE TABLE complaints(id NUMERIC(5) PRIMARY KEY IDENTITY(50001,1),ref_no NUMERIC(37),electrition_id NUMERIC(37),date varchar(50),status VARCHAR(50))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableComplaintUpdates()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='complaint_updates') CREATE TABLE complaint_updates(id NUMERIC(5) PRIMARY KEY IDENTITY(50001,1),complaint_id NUMERIC(37),date varchar(50),status VARCHAR(50),remarks VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableEmployeesSalaries()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='employees_salaries') CREATE TABLE employees_salaries(id NUMERIC(5) PRIMARY KEY IDENTITY(100,1),account_id NUMERIC(37),basic_salary NUMERIC(37,2),bonus NUMERIC(37,2),commission NUMERIC(37,2) ,advance_payment NUMERIC(37,2),other_deductions NUMERIC(37,2),net_salary NUMERIC(37,2),pay_date VARCHAR(25),remarks VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }


        public void createTableCommissions()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='commissions') CREATE TABLE commissions(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1), item_id NUMERIC(25) NOT NULL, area_manager NUMERIC(30,2), senior_secretary NUMERIC(30,2), junior_secretary NUMERIC(30,2), salesman NUMERIC(30,2), description VARCHAR(255))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableStores()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='stores') CREATE TABLE stores(id NUMERIC(5) PRIMARY KEY IDENTITY(501,1),name VARCHAR(100) NOT NULL,company_logo VARCHAR(255),area_code VARCHAR(100), ref_prefix VARCHAR(25),company_name VARCHAR(100),phone VARCHAR(25),address VARCHAR(250),description VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableNatures()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='natures') CREATE TABLE natures(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),name VARCHAR(25) NOT NULL)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableAccountGroups()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='account_groups') CREATE TABLE account_groups(id NUMERIC(5) PRIMARY KEY IDENTITY(1001,1),name VARCHAR(25) NOT NULL,nature_id NUMERIC(25),nature VARCHAR(25) NOT NULL,category VARCHAR(150),account_type VARCHAR(20) NOT NULL,created_type VARCHAR(20) NOT NULL)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableMessages()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='messages') CREATE TABLE messages(id NUMERIC(5) PRIMARY KEY IDENTITY(1001,1),account_id NUMERIC(25),group_name VARCHAR(500),sms_gateway VARCHAR(100),store_id NUMERIC(37),date VARCHAR(50),message_type NVARCHAR(100),to_number VARCHAR(25) NOT NULL,message_text NVARCHAR(855),status VARCHAR(25))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableAccounts()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='accounts') CREATE TABLE accounts(id int PRIMARY KEY IDENTITY(2001,1) ,name VARCHAR(75) NOT NULL,email VARCHAR(75),phone VARCHAR(25),address VARCHAR(250),role_id NUMERIC(37),basic_salary NUMERIC(37,2),advance_limit NUMERIC(37,2),pay_date VARCHAR(50),login_id VARCHAR(250),login_password VARCHAR(250),account_group_id Numeric(25) NOT NULL,account_group VARCHAR(250) NOT NULL,remarks VARCHAR(250),account_type VARCHAR(20) NOT NULL,remaining_type VARCHAR(25),father_name VARCHAR(250),age NUMERIC(37),cost VARCHAR(250),profession VARCHAR(250),id_card_no VARCHAR(100),business_address VARCHAR(250),office_phone VARCHAR(50),home_address VARCHAR(250),home_phone VARCHAR(50),store_id NUMERIC(37),opening_debit NUMERIC(37,2),opening_credit NUMERIC(37,2),balance NUMERIC(37,2) NOT NULL,created_type VARCHAR(20) NOT NULL)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableGuardians()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='guardians') CREATE TABLE guardians(id int PRIMARY KEY IDENTITY(2001,1) ,name VARCHAR(100) NOT NULL,email VARCHAR(75),phone VARCHAR(25),address VARCHAR(250),remarks VARCHAR(250),father_name VARCHAR(250),age NUMERIC(37),cost VARCHAR(250),profession VARCHAR(250),id_card_no VARCHAR(50),business_address VARCHAR(250),office_phone VARCHAR(50),home_address VARCHAR(250),home_phone VARCHAR(50),store_id NUMERIC(37))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableEmiVouchers()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='emi_vouchers') CREATE TABLE emi_vouchers(id NUMERIC(5) PRIMARY KEY IDENTITY(100,1),date VARCHAR(50),store_id NUMERIC(37),start_serial VARCHAR(250),end_serial VARCHAR(250),description VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableCashVouchers()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='cash_vouchers') CREATE TABLE cash_vouchers(id NUMERIC(5) PRIMARY KEY IDENTITY(100,1),date VARCHAR(50),store_id NUMERIC(37),field_worker VARCHAR(250),description VARCHAR(250),area_name VARCHAR(250),vehicle_number VARCHAR(50),total_Amount NUMERIC(37,2),used_amount NUMERIC(37,2),voucher_balance NUMERIC(37,2),total_accounts NUMERIC(37),finalized_accounts NUMERIC(37),remaining_accounts NUMERIC(37))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableCashVoucherItems()
        {
            try
            {
                // Added ref_no, due_date, and due_amount to ensure DB matches Controller
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='cash_voucher_items') 
                         CREATE TABLE cash_voucher_items(
                            id int PRIMARY KEY IDENTITY(100,1),
                            date VARCHAR(50),
                            ref_no VARCHAR(250), 
                            emi_voucher_id NUMERIC(37),
                            store_id NUMERIC(37),
                            cash_voucher_id NUMERIC(37),
                            customer_id NUMERIC(37),
                            item_id NUMERIC(37),
                            due_date VARCHAR(50), 
                            due_amount NUMERIC(37,2),
                            RECIEVED_AMOUNT NUMERIC(37,2),
                            BALANCE NUMERIC(37,2),
                            remarks VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void createTableCashVoucherItems_Old()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='cash_voucher_items') CREATE TABLE cash_voucher_items(id NUMERIC(5) PRIMARY KEY IDENTITY(100,1),date VARCHAR(50),ref_no VARCHAR(250),emi_voucher_id NUMERIC(37),cash_voucher_id NUMERIC(37),customer_id NUMERIC(37),item_id NUMERIC(37), due_date VARCHAR(50), due_amount NUMERIC(37,2),RECIEVED_AMOUNT NUMERIC(37,2),BALANCE NUMERIC(37,2))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableVoucherTypes()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='voucher_types') CREATE TABLE voucher_types(id NUMERIC(5) PRIMARY KEY IDENTITY(1001,1),name VARCHAR(25) NOT NULL)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableVouchers()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='vouchers') CREATE TABLE vouchers(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),voucher_type_id NUMERIC(37),voucher_type VARCHAR(25),debit_description VARCHAR(255),credit_description VARCHAR(255),issue_date DATETIME,debit_account_id NUMERIC(37),credit_account_id NUMERIC(37),debit_account_name VARCHAR(255),credit_account_name VARCHAR(255),amount NUMERIC(37), emi_no VARCHAR(50),ref_no VARCHAR(50), ref_id NUMERIC(37), ref_type VARCHAR(250),  )";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableJournalTransactions()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='journal_transactions') CREATE TABLE journal_transactions(id NUMERIC(5) PRIMARY KEY IDENTITY(100,1),invoice_no VARCHAR(150),store_id NUMERIC(37),cash_voucher_id NUMERIC(37),account_type VARCHAR(200),account_nature VARCHAR(200),description VARCHAR(255),source VARCHAR(200),item_name VARCHAR(255),item_quantity NUMERIC(37,2) ,system_date VARCHAR(20) ,entry_date VARCHAR(20) ,account_id NUMERIC(37),account_name VARCHAR(200),opening_debit NUMERIC(37,2),opening_credit NUMERIC(37,2),debit NUMERIC(37,2),credit NUMERIC(37,2),closing_balance NUMERIC(37,2))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableItemGroups()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='item_groups') CREATE TABLE item_groups(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),name VARCHAR(255),description VARCHAR(255))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableItemManufacturers()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='item_manufacturers') CREATE TABLE item_manufacturers(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),name VARCHAR(255),description VARCHAR(255))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableItemCategories()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='item_categories') CREATE TABLE item_categories(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),name VARCHAR(255),description VARCHAR(255))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableItemUnits()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='item_units') CREATE TABLE item_units(id NUMERIC(5) PRIMARY KEY IDENTITY(1001,1),name VARCHAR(255) UNIQUE)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableStoreTeams()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='store_teams') CREATE TABLE store_teams(id NUMERIC(5) PRIMARY KEY IDENTITY(11001,1),team_code VARCHAR(255) UNIQUE)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableItemModels()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='item_models') CREATE TABLE item_models(id NUMERIC(5) PRIMARY KEY IDENTITY(1001,1),name VARCHAR(255) UNIQUE)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableStockTransactions()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='stock_transactions') CREATE TABLE stock_transactions(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),from_store NUMERIC(37),paid_by_ac_id NUMERIC(37),fuel_expenses_amount NUMERIC(37,2),to_store NUMERIC(37) ,date VARCHAR(25), gate_pass_no VARCHAR(50),name VARCHAR(250),remarks VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableStockReturns()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='stock_returns') CREATE TABLE stock_returns(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),paid_by_ac_id NUMERIC(37),fuel_expenses_amount NUMERIC(37,2),store_id NUMERIC(37) NOT NULL ,date VARCHAR(25),name VARCHAR(250), gate_pass_no VARCHAR(50),description VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableStockReturnItems()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='stock_return_items') CREATE TABLE stock_return_items(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),store_id NUMERIC(37),stock_return_id NUMERIC(37),purchase_id NUMERIC(37),purchase_item_id NUMERIC(37),stock_transaction_id NUMERIC(37) NOT NULL ,item_id NUMERIC(37) NOT NULL,date VARCHAR(25),purchase_rate NUMERIC(37,2), emi_price NUMERIC(30,2),advance_rate NUMERIC(37,2), no_of_installments NUMERIC(30,2), cash_rate NUMERIC(30,2),sale_rate NUMERIC(37,2),quantity NUMERIC(37,2), remarks VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableStockTransactionItems()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='stock_transaction_items') CREATE TABLE stock_transaction_items(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),store_id NUMERIC(37),purchase_id NUMERIC(37),purchase_item_id NUMERIC(37),stock_transaction_id NUMERIC(37) NOT NULL ,item_id NUMERIC(37) NOT NULL,date VARCHAR(25),purchase_rate NUMERIC(37,2), emi_price NUMERIC(30,2),advance_rate NUMERIC(37,2), no_of_installments NUMERIC(30,2), cash_rate NUMERIC(30,2),sale_rate NUMERIC(37,2),stock_in NUMERIC(37,2),sold_out NUMERIC(37,2),sales_return NUMERIC(37,2) DEFAULT 0,returned NUMERIC(37,2),transfered NUMERIC(37,2),remarks VARCHAR(250) )";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableItems()
        {
            String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='items') CREATE TABLE items(id NUMERIC(11) PRIMARY KEY IDENTITY(50001,1),name  varchar(250), unicode_name nvarchar(255),picture VARCHAR(250),barcode_id VARCHAR(250),unit_id NUMERIC(25),packing NUMERIC(30),group_id NUMERIC(30),category_id NUMERIC (30),manufacturer_id NUMERIC(30),vendor_id NUMERIC(30),model_id NUMERIC(30),location NUMERIC(30), purchase_rate NUMERIC(30,2), emi_price NUMERIC(30,2),advance_rate NUMERIC(37,2), no_of_installments NUMERIC(30,2), cash_rate NUMERIC(30,2),sale_rate NUMERIC(30,2),unit_cost NUMERIC(30,2),sale_discount NUMERIC(30,2),reorder_level NUMERIC(30,2),demand NUMERIC(30,2),gst NUMERIC(30,2),manufacturer_date VARCHAR(30),expiry_date VARCHAR(30),is_expireable REAL,is_imported REAL,is_counter_sale REAL,is_active REAL,rack_id NUMERIC(30))";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }

        }

        public void createTablePurchases()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='purchases') CREATE TABLE purchases(id NUMERIC(5) PRIMARY KEY IDENTITY(10001,1),invoice_no VARCHAR(150),status VARCHAR(37),payment_method VARCHAR(37),purchase_type VARCHAR(37) NOT NULL,supplier_id NUMERIC(37),date DATETIME,discount_percent NUMERIC(37,2),discount_rs NUMERIC(37,2),remarks VARCHAR(250),total_amount NUMERIC(37,2),paid NUMERIC(37,2),remaining NUMERIC(37,2),fuel_expenses_amount NUMERIC(37,2),fuel_expenses_account_id NUMERIC(37))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }
        public void createTableAggrements()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='aggrements') CREATE TABLE aggrements(id NUMERIC(5) PRIMARY KEY IDENTITY(10001,1),customer_id NUMERIC(37),team_id NUMERIC(37),guardian_id NUMERIC(37),ref_no VARCHAR(250),store_id NUMERIC(37),date DATETIME,messages_sent NUMERIC(37),dues_fine NUMERIC(37,2),total_amount NUMERIC(37,2),sale_return_amount NUMERIC(37,2) DEFAULT 0,advance_amount NUMERIC(37,2),balance NUMERIC(37,2),current_balance NUMERIC(37,2),no_of_installments NUMERIC(37),emi_no NUMERIC(37),first_emi NUMERIC(37,2),rest_emi NUMERIC(37,2),start_date VARCHAR(50),status VARCHAR(37),remarks VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableAggrementDues()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='aggrement_dues') CREATE TABLE aggrement_dues(id NUMERIC(5) PRIMARY KEY IDENTITY(10001,1),aggrement_id NUMERIC(37),ref_no VARCHAR(250), emi_no VARCHAR(20), status VARCHAR(20) DEFAULT('Default'),emi_date VARCHAR(20), is_return_fixed INT DEFAULT -1,emi_amount NUMERIC(37,2),before_due_messages NUMERIC(37),after_due_messages NUMERIC(37),cash_voucher_messages NUMERIC(37),paid_date VARCHAR(20),paid_amount NUMERIC(37,2),balance NUMERIC(37,2),remarks VARCHAR(250))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableAgreementReturns()
        {
            try
            {
                // Master table to track the return event
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='agreement_returns') 
                 CREATE TABLE agreement_returns(
                    id INT PRIMARY KEY IDENTITY(50001,1),
                    emi_no VARCHAR(50),
                    agreement_id NUMERIC(37),
                    store_id NUMERIC(37),
                    customer_id NUMERIC(37),
                    guardian_id NUMERIC(37),
                    return_date DATETIME,
                    ref_no VARCHAR(250),
                    aggrement_total_amount NUMERIC(37,2),      -- Aggrement total amount
                    aggrement_adv_amount NUMERIC(37,2),      -- Aggrement advance amount
                    prev_balance NUMERIC(37,2),      -- Balance before return
                    total_return_value NUMERIC(37,2),-- Sum of (Qty * Sale Rate)
                    total_paid_value NUMERIC(37,2),-- Sum of (Paid) for returning items
                    total_remaining_value NUMERIC(37,2),-- Sum of (Remaining) for returning items
                    fee_kept NUMERIC(37,2),          -- Usage income/Deduction
                    credit_to_customer NUMERIC(37,2),-- Amount reduced from debt
                    new_balance NUMERIC(37,2),       -- Final balance after return
                    remarks VARCHAR(500))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { XtraMessageBox.Show(ex.Message); }
        }

        public void createTableAgreementReturnItems()
        {
            try
            {
                // Detail table to track specific items returned
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='agreement_return_items') 
                 CREATE TABLE agreement_return_items(
                    id INT PRIMARY KEY IDENTITY(50001,1),
                    aggrement_id INT,
                    aggrement_return_id INT,
                    ref_no VARCHAR(250),
                    item_id NUMERIC(37),
                    sale_item_id NUMERIC(37),
                    stock_transaction_id NUMERIC(37),
                    quantity NUMERIC(37,2),
                    sale_rate NUMERIC(37,2),
                    sub_total NUMERIC(37,2),
                    total_paid NUMERIC(37,2),
                    total_remaining NUMERIC(37,2),
                    purchase_rate NUMERIC(37,2),
                    emi_price NUMERIC(30,2),
                    advance_rate NUMERIC(37,2), 
                    no_of_installments NUMERIC(30,2), 
                    cash_rate NUMERIC(30,2))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { XtraMessageBox.Show(ex.Message); }
        }
        public void createTablePurchasesReturn()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='purchases_return') CREATE TABLE purchases_return(id NUMERIC(5) PRIMARY KEY IDENTITY(10001,1),purchase_id NUMERIC(37),invoice_no VARCHAR(150),status VARCHAR(37),payment_method VARCHAR(37),purchase_type VARCHAR(37) NOT NULL,supplier_id NUMERIC(37),date DATETIME,discount_percent NUMERIC(37,2),discount_rs NUMERIC(37,2),remarks VARCHAR(250),total_amount NUMERIC(37,2))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }


        public void createTablePurchaseItems()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='purchase_items') CREATE TABLE purchase_items(id NUMERIC(5) PRIMARY KEY IDENTITY(10001,1),date DATETIME,purchase_id NUMERIC(37),batch_no NUMERIC(37),unit_id NUMERIC(37),item_id NUMERIC(37),status VARCHAR(37),category_id NUMERIC(37),manufacturer_id NUMERIC(37),product_group_id NUMERIC(37),exp_date DATETIME,purchase_rate NUMERIC(37,2), emi_price NUMERIC(30,2),advance_rate NUMERIC(37,2), no_of_installments NUMERIC(30,2), cash_rate NUMERIC(30,2),sale_rate NUMERIC(37,2),discount_percent NUMERIC(37,2),discount_rs NUMERIC(37,2),gst_percent NUMERIC(37,2),gst_rs NUMERIC(37,2),sub_total NUMERIC(37,2),quantity NUMERIC(37,2),items_stock_in NUMERIC(37,2),items_stock_out NUMERIC(37,2),net_total NUMERIC(37,2),returned_quantity NUMERIC(37,2))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTablePurchasesRetrunItems()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='purchases_return_items') CREATE TABLE purchases_return_items(id NUMERIC(5) PRIMARY KEY IDENTITY(10001,1),date DATETIME,purchases_return_id NUMERIC(37),batch_no NUMERIC(37),unit_id NUMERIC(37),item_id NUMERIC(37),status VARCHAR(37),category_id NUMERIC(37),manufacturer_id NUMERIC(37),product_group_id NUMERIC(37),exp_date DATETIME,purchase_rate NUMERIC(37,2), emi_price NUMERIC(30,2),advance_rate NUMERIC(37,2), no_of_installments NUMERIC(30,2), cash_rate NUMERIC(30,2),sale_rate NUMERIC(37,2),discount_percent NUMERIC(37,2),discount_rs NUMERIC(37,2),gst_percent NUMERIC(37,2),gst_rs NUMERIC(37,2),sub_total NUMERIC(37,2),unit_cost NUMERIC(37,2),net_total NUMERIC(37,2),returned_quantity NUMERIC(37,2))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableSalesReturn()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='sales_return') CREATE TABLE sales_return(id NUMERIC(5) PRIMARY KEY IDENTITY(20001,1),sale_type VARCHAR(37) NOT NULL,payment_method VARCHAR(37) NOT NULL,customer_id NUMERIC(37),date DATETIME,discount NUMERIC(37,2),remarks VARCHAR(250),total_amount NUMERIC(37,2) )";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableSalesReturnItems()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='sales_return_items') CREATE TABLE sales_return_items(id NUMERIC(5) PRIMARY KEY IDENTITY(1000,1),sales_return_id NUMERIC(37),sale_id NUMERIC(37),unit_id NUMERIC(37),date DATETIME,item_id NUMERIC(37),category_id NUMERIC(37),manufacturer_id NUMERIC(37),product_group_id NUMERIC(37), emi_price NUMERIC(30,2),advance_rate NUMERIC(37,2), no_of_installments NUMERIC(30,2), cash_rate NUMERIC(30,2),sale_rate NUMERIC(37,2),discount NUMERIC(37,2),gst_amount NUMERIC(37,2),gst_percent NUMERIC(37,2),items_stock_in NUMERIC(37,2),amount NUMERIC(37,2))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableSaleItems()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='sale_items') CREATE TABLE sale_items(id NUMERIC(37) PRIMARY KEY IDENTITY(1001,1),agreement_id NUMERIC(37),item_id NUMERIC(37),date DATETIME,stock_transaction_id NUMERIC(37),purchase_item_id NUMERIC(37),purchase_rate NUMERIC(37,2), emi_price NUMERIC(30,2),advance_rate NUMERIC(37,2), no_of_installments NUMERIC(30,2), cash_rate NUMERIC(30,2),sale_rate NUMERIC(37,2),sub_total NUMERIC(37,2),discount_percent NUMERIC(37,2),discount_rs NUMERIC(37,2),sold_qty NUMERIC(37,2),returned_qty NUMERIC(37,2),net_total NUMERIC(37,2),returned_quantity NUMERIC(37,2), returned_value NUMERIC(37, 2),defaulted_quantity NUMERIC(37,2))";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableItemRacks()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='item_racks') CREATE TABLE item_racks(id NUMERIC(5) PRIMARY KEY IDENTITY(101,1),name VARCHAR(100) NOT NULL)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void createTableRoles()
        {
            try
            {
                String query = @"IF NOT EXISTS(SELECT * from sys.tables where name='roles') CREATE TABLE roles(id NUMERIC(5) PRIMARY KEY IDENTITY(1,1),name VARCHAR(250) NOT NULL)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
            }
        }

        public void InertDataToNaturesTable()
        {
            String query_counter = "SELECT COUNT(*) FROM natures";
            SqlCommand cmd_counter = new SqlCommand(query_counter, conn);
            Int32 count = (Int32)cmd_counter.ExecuteScalar();
            if (count <= 0)
            {
                String[] natures = new String[6];

                natures[0] = "Asset";
                natures[1] = "Liability";
                natures[2] = "Expense";
                natures[3] = "Revenue";
                natures[4] = "Equity";
                natures[5] = "Drawings";
                int i = 0;
                while (i < natures.Length)
                {

                    try
                    {
                        String query = "INSERT INTO natures(name) VALUES('" + natures[i] + "')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
                    }

                    i = i + 1;
                }
            }

        }

        public void InertDataToVocharTypesTable()
        {
            String query_counter = "SELECT COUNT(*) FROM voucher_types";
            SqlCommand cmd_counter = new SqlCommand(query_counter, conn);
            Int32 count = (Int32)cmd_counter.ExecuteScalar();
            if (count <= 0)
            {
                String[] vochar_types = new String[5];

                vochar_types[0] = "Journal Voucher";
                vochar_types[1] = "Payment Voucher";
                vochar_types[2] = "Reciept Voucher";

                int i = 0;
                while (i < vochar_types.Length)
                {

                    try
                    {
                        String query = "INSERT INTO voucher_types(name) VALUES('" + vochar_types[i] + "')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
                    }

                    i = i + 1;
                }
            }

        }

        public void InertDataToAccountGroupsTable()
        {
            String query_counter = "SELECT COUNT(*) FROM account_groups";
            SqlCommand cmd_counter = new SqlCommand(query_counter, conn);
            Int32 count = (Int32)cmd_counter.ExecuteScalar();
            if (count <= 0)
            {
                String[] account_groups = new String[10];
                String[] account_group_natures = new String[10];
                String[] nature_names = new String[10];
                String[] categories = new String[10];
                String[] account_types = new String[10];

                account_groups[0] = "Suppliers ( Creditors )";
                categories[0] = "Payable";
                account_types[0] = "CR";
                account_groups[1] = "Customers ( Debitors )";
                categories[1] = "Receivable";
                account_types[1] = "DR";
                account_groups[2] = "Current Assets";
                categories[2] = "";
                account_types[2] = "DR";
                account_groups[3] = "Fixed Assets";
                categories[3] = "";
                account_types[3] = "DR";
                account_groups[4] = "Current Liability";
                categories[4] = "";
                account_types[4] = "CR";
                account_groups[5] = "Shareholders Equity";
                categories[5] = "";
                account_types[5] = "CR";
                account_groups[6] = "Direct Expenses";
                categories[6] = "";
                account_types[6] = "DR";
                account_groups[7] = "Revenues";
                categories[7] = "";
                account_types[7] = "CR";

                account_groups[8] = "Employees";
                categories[8] = "";
                account_types[8] = "DR";

                account_groups[9] = "Guardians ( Debitors )";
                categories[9] = "Receivable";
                account_types[9] = "DR";

                account_group_natures[0] = "102";
                account_group_natures[1] = "101";
                account_group_natures[2] = "101";
                account_group_natures[3] = "101";
                account_group_natures[4] = "102";
                account_group_natures[5] = "105";
                account_group_natures[6] = "103";
                account_group_natures[7] = "104";
                account_group_natures[8] = "103";
                account_group_natures[9] = "101";

                nature_names[0] = "Liability";
                nature_names[1] = "Asset";
                nature_names[2] = "Asset";
                nature_names[3] = "Asset";
                nature_names[4] = "Liability";
                nature_names[5] = "Equity";
                nature_names[6] = "Expense";
                nature_names[7] = "Revenue";
                nature_names[8] = "Expense";
                nature_names[9] = "Asset";

                int i = 0;
                while (i < account_groups.Length)
                {

                    try
                    {
                        String query = "INSERT INTO account_groups(name,nature_id,nature,category,account_type,created_type) VALUES('" + account_groups[i] + "','" + account_group_natures[i] + "','" + nature_names[i] + "','"+ categories[i] +"','"+ account_types[i] +"','System')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
                    }

                    i = i + 1;
                }
            }

        }

        public void InertDataToRolesTable()
        {
            // FIX: Add a check to see if roles already exist
            String query_counter = "SELECT COUNT(*) FROM roles";
            SqlCommand cmd_counter = new SqlCommand(query_counter, conn);
            Int32 count = (Int32)cmd_counter.ExecuteScalar();

            if (count <= 0) // Only insert if the table is empty
            {
                String[] roles = new String[7];
                roles[0] = "Admin";
                roles[1] = "Area Manager";
                roles[2] = "Senior Sactory";
                roles[3] = "Jounior Sactory";
                roles[4] = "Internee";
                roles[5] = "Electrition";
                roles[6] = "Driver";

                for (int i = 0; i < roles.Length; i++)
                {
                    try
                    {
                        String query = "INSERT INTO roles(name) VALUES('" + roles[i] + "')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void InertDataToAccountsTable()
        {
            String query_counter = "SELECT COUNT(*) FROM accounts";
            SqlCommand cmd_counter = new SqlCommand(query_counter, conn);
            Int32 count = (Int32)cmd_counter.ExecuteScalar();
            if (count <= 0)
            {
                String[] account_names = new String[21];
                String[] account_group_name = new String[21];
                int[] account_group_id = new int[24];
                String[] account_types = new String[21];
                account_names[0] = "Cash";
                account_group_name[0] = "Current Assets";
                account_group_id[0] = 1003;
                account_types[0] = "DR";
                account_names[1] = "Bank";
                account_group_name[1] = "Current Assets";
                account_group_id[1] = 1003;
                account_types[1] = "DR";
                account_names[2] = "Accounts Receivable";
                account_group_name[2] = "Current Assets";
                account_group_id[2] = 1003;
                account_types[2] = "DR";

                //end of Assets accounts

                //starting Liability Accounts


                account_names[3] = "Accounts Payable";
                account_group_name[3] = "Current Liability";
                account_group_id[3] = 1005;
                account_types[3] = "CR";
                account_names[4] = "Notes Payable";
                account_group_name[4] = "Current Liability";
                account_group_id[4] = 1005;
                account_types[4] = "CR";
                //ending of liability

                //starting of Equity

                account_names[5] = "Owners Capital";
                account_group_name[5] = "Shareholders Equity";
                account_group_id[5] = 1006;
                account_types[5] = "CR";
                account_names[6] = "Retained Earnings";
                account_group_name[6] = "Shareholders Equity";
                account_group_id[6] = 1006;
                account_types[6] = "CR";
                //end of equity

                //starting of Revenue


                account_names[7] = "Sales";
                account_group_name[7] = "Revenues";
                account_group_id[7] = 1008;
                account_types[7] = "CR";
                //ending of revemue

                //starting of expences


                account_names[8] = "Purchases";
                account_group_name[8] = "Expense";
                account_group_id[8] = 1007;
                account_types[8] = "DR";
                account_names[9] = "Advertising Expense";
                account_group_name[9] = "Expense";
                account_group_id[9] = 1007;
                account_types[9] = "DR";
                account_names[10] = "Inventory";
                account_group_name[10] = "Current Assets";
                account_group_id[10] = 1003;
                account_types[10] = "DR";
                account_names[11] = "Disount Taken";
                account_group_name[11] = "Revenues";
                account_group_id[11] = 1008;
                account_types[11] = "CR";
                account_names[12] = "Sales Tax Payable";
                account_group_name[12] = "Current Liability";
                account_group_id[12] = 1005;
                account_types[12] = "CR";
                account_names[13] = "GST Charged on Purchases";
                account_group_name[13] = "Expense";
                account_group_id[13] = 1007;
                account_types[13] = "DR";
                account_names[14] = "Discount Given";
                account_group_name[14] = "Expense";
                account_group_id[14] = 1007;
                account_types[14] = "DR";
                account_names[15] = "Cost of Goods Sold";
                account_group_name[15] = "Expense";
                account_group_id[15] = 1007;
                account_types[15] = "DR";

                account_names[16] = "Damaged Inventory";
                account_group_name[16] = "Expense";
                account_group_id[16] = 1007;
                account_types[16] = "DR";
                account_names[17] = "Salaries";
                account_group_name[17] = "Expense";
                account_group_id[17] = 1007;
                account_types[17] = "DR";
                account_names[18] = "Defaulters Inventory";
                account_group_name[18] = "Expense";
                account_group_id[18] = 1007;
                account_types[18] = "DR";

                account_names[19] = "Sales Return";
                account_group_name[19] = "Revenues";
                account_group_id[19] = 1008; // ID for Revenues group
                account_types[19] = "DR";

                account_names[20] = "Usage Income";
                account_group_name[20] = "Revenues";
                account_group_id[20] = 1008; // ID for Revenues group
                account_types[20] = "CR";

                int i = 0;
                while (i < account_names.Length)
                {
                    try
                    {
                        String query = "INSERT INTO accounts(name,account_group_id,account_group,balance,account_type,created_type) VALUES('"+ account_names[i] +"','"+ account_group_id[i] +"','"+ account_group_name[i]+"','0','"+ account_types[i] +"','System')";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        XtraMessageBox.Show(ex.Message, alert_msgbox_msg, MessageBoxButtons.OK, alert_msgbx_icon);
                    }

                    i = i + 1;
                }


                String query1 = "INSERT INTO accounts(name,account_group_id,account_group,balance,account_type,role_id,login_id,login_password,created_type) VALUES('Admin','1009','Employees','0','DR','1','admin','admin','System')";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.ExecuteNonQuery();
            }
        }
    }
}
