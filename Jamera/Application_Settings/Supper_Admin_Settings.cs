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
using Jamera.Properties;
using DevExpress.LookAndFeel;
using System.IO;
using DevExpress.Images;
//using Newtonsoft.Json;

namespace Jamera.Application_Settings
{
    public partial class Supper_Admin_Settings : DevExpress.XtraEditors.XtraForm
    {
        String skin_name = Settings.Default.App_Default_Skin;
        public Supper_Admin_Settings()
        {
            InitializeComponent();

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

            drives_container.DataSource = Environment.GetLogicalDrives();
            Load_Tabs_Visibility_Settings();
        }

        private void change_style_btn_Click(object sender, EventArgs e)
        {
            Skin_Style_Customizations style = new Skin_Style_Customizations();
            style.ShowDialog();
        }

        public void LoadDataToSettings()
        {
            os_no_inp.Text = Settings.Default.OS_No;
            baseboard_no_inp.Text = Settings.Default.Baseboard_No;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Settings.Default.App_Default_Skin = UserLookAndFeel.Default.SkinName;
            Settings.Default.OS_No = os_no_inp.Text;
            Settings.Default.Baseboard_No = baseboard_no_inp.Text;
            Settings.Default.Save();
            this.Close();
            
        }

        private void Supper_Admin_Settings_Load(object sender, EventArgs e)
        {
            LoadDataToSettings();
            tabPane.SelectedPageIndex = 0;
        }

        private void csancel_btn_Click(object sender, EventArgs e)
        {
            UserLookAndFeel.Default.SetSkinStyle(skin_name);
            this.Close();
        }

        private void opening_balances_btn_Click(object sender, EventArgs e)
        {
            Accounts.Opening_Balances form = new Accounts.Opening_Balances();
            form.Show(this);
        }

        private void opening_stocks_btn_Click(object sender, EventArgs e)
        {
            Purchases.Opening_Stocks form = new Purchases.Opening_Stocks();
            form.Show(this);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void os_no_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                baseboard_no_inp.Focus();
            }
        }
        private void baseboard_no_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                //XtraMessageBox.Show("Codes are not available to save system configurations!", Message_Title);
            }
        }

        private void server_name_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                db_name_inp.Focus();
            }
        }

        private void db_name_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                db_username_inp.Focus();
            }
        }

        private void db_username_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                db_password_inp.Focus();
            }
        }

        private void db_password_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                //XtraMessageBox.Show("Codes are not available to save connection settings!", Message_Title);
            }
        }

        private void admin_new_password_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                admin_confirm_pass_inp.Focus();
            }
        }

        private void admin_confirm_new_pass_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                //XtraMessageBox.Show("Codes are not available to save admin password!", Message_Title);
            }
        }

        private void search_filter_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(registeration_type.SelectedIndex == 0 || registeration_type.SelectedIndex == 3)
            {
                reg_paid_month_cmb.Text = null;
                soft_start_date.Text = null;
                soft_end_date.Text = null;
                reg_paid_month_cmb.Enabled = false;
                soft_start_date.Enabled = false;
                soft_end_date.Enabled = false;
            }
            if (registeration_type.SelectedIndex == 1)
            {
                reg_paid_month_cmb.Text = DateTime.Now.Month.ToString();
                reg_paid_month_cmb.Enabled = true;
                soft_start_date.Text = null;
                soft_end_date.Text = null;
                soft_start_date.Enabled = false;
                soft_end_date.Enabled = false;
            }
            if (registeration_type.SelectedIndex == 2)
            {
                reg_paid_month_cmb.Text = null;
                reg_paid_month_cmb.Enabled = false;
                soft_start_date.Enabled = true;
                soft_end_date.Enabled = true;
            }

        }

        private void reg_financial_year_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            reg_paid_month_cmb.ShowPopup();
        }

        private void reg_paid_month_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //XtraMessageBox.Show("Codes are not available to save registration settings!", Message_Title);
        }

        public void Save_General_Settings()
        {
            if (os_no_inp.Text == "" && baseboard_no_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter system registeration requirements !");
                os_no_inp.Focus();
            }
            else if (os_no_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter system registeration requirements !");
                os_no_inp.Focus();
            }
            else if (baseboard_no_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter system registeration requirements !");
                baseboard_no_inp.Focus();
            }
            else
            {
                this.Store_General_Settings();
            }
        }

        public void Store_General_Settings()
        {
            Supper_Admin_Setting supper_admin_settigs = new Supper_Admin_Setting();
            if (supper_admin_settigs.Store_General_Settings(os_no_inp.Text, baseboard_no_inp.Text) == true)
            {
                XtraMessageBox.Show("General Settings are stored successfully !");
            }
        }

        private void gen_save_btn_Click(object sender, EventArgs e)
        {
            this.Save_General_Settings();
        }

        public void Save_Server_Settings()
        {
            if(server_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter server name !");
                server_name_inp.Focus();
            }
            else if(db_name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter database name !");
                db_name_inp.Focus();
            }else if (db_username_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter user name !");
                db_name_inp.Focus();
            }else if (db_password_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter user password !");
                db_password_inp.Focus();
            }else if(drives_container.Text == "")
            {
                XtraMessageBox.Show("Please select drive for backup !");
                drives_container.Focus();
            }
            else
            {
                if (save_message_without_sent_check.Checked == true)
                {
                    Settings.Default["should_save_message_without_sent"] = true;
                }
                else
                {
                    Settings.Default["should_save_message_without_sent"] = false;
                }

                if (shoud_show_flush_btn_check.Checked == true)
                {
                    Settings.Default["should_show_flush_btn_in_main"] = true;
                }
                else
                {
                    Settings.Default["should_show_flush_btn_in_main"] = false;
                }

                string custom_connection = null;

                if(custom_connection_check.Checked == true)
                {
                    custom_connection = custom_connection_inp.Text;
                }
                Settings.Default.Save();
                Supper_Admin_Setting supper_admin_settings = new Supper_Admin_Setting();
                if (supper_admin_settings.Store_Server_Settings(server_name_inp.Text, db_name_inp.Text, db_username_inp.Text, db_password_inp.Text, drives_container.Text, custom_connection))
                {
                    XtraMessageBox.Show("Server settings are updated successfully !");
                }
            }
        }

        private void server_settings_save_btn_Click(object sender, EventArgs e)
        {
            this.Save_Server_Settings();
        }

        private void Supper_Admin_Settings_Shown(object sender, EventArgs e)
        {
            int drives_number = drives_container.Items.Count;
            for(int i = 0; i < drives_number; i++)
            {
                if(drives_container.Items[i].ToString() == Settings.Default.backup_drive)
                {
                    drives_container.SelectedIndex = i;
                }
            }

            server_name_inp.Text = Settings.Default.server_name;
            db_name_inp.Text = Settings.Default.db_name;
            db_username_inp.Text = Settings.Default.db_user_name;
            db_password_inp.Text = Settings.Default.db_password;

            registeration_type.SelectedIndex = Settings.Default.reg_type;
            if (Settings.Default.reg_type == 1)
            {
                reg_paid_month_cmb.Text = DateTime.Now.Month.ToString();
                soft_start_date.Text = null;
                soft_end_date.Text = null;
                soft_start_date.Enabled = false;
                soft_end_date.Enabled = false;
            }
            if (Settings.Default.reg_type == 2)
            {
                soft_start_date.Text = Settings.Default.soft_start_date;
                soft_end_date.Text = Settings.Default.soft_end_date;
                reg_paid_month_cmb.Text = null;
                reg_paid_month_cmb.Enabled = false;
            }
            if (Settings.Default.reg_type == 0 || Settings.Default.reg_type == 3)
            {
                reg_paid_month_cmb.Text = null;
                soft_start_date.Text = null;
                soft_end_date.Text = null;
                reg_paid_month_cmb.Enabled = false;
                soft_start_date.Enabled = false;
                soft_end_date.Enabled = false;
            }
            if (Settings.Default.should_save_message_without_sent == true)
            {
                save_message_without_sent_check.Checked = true;
            }
            else
            {
                save_message_without_sent_check.Checked = false;
            }

            if (Settings.Default.should_show_flush_btn_in_main == true)
            {
                shoud_show_flush_btn_check.Checked = true;
            }
            else
            {
                shoud_show_flush_btn_check.Checked = false;
            }
            //For Wifi
            wifi_ip_address_inp.Text = Settings.Default.wifi_ip_address;
            wifi_port_inp.Text = Settings.Default.wifi_port;
            wifi_user_name_inp.Text = Settings.Default.wifi_user_name;
            wifi_password_inp.Text = Settings.Default.wifi_password;

            //For API
            api_url_inp.Text = Settings.Default.api_url;
            api_port_inp.Text = Settings.Default.api_port;
            api_maskng_inp.Text = Settings.Default.api_masking;
            api_username_inp.Text = Settings.Default.api_username;
            api_pass_inp.Text = Settings.Default.api_password;

            sms_gateway_cmb.Text = Settings.Default.sms_gateway;
            default_sms_gateway_cmb.Text = Settings.Default.default_sms_gateway;
            default_sms_lang_cmb.Text = Settings.Default.default_sms_language;
        }

        private void username_show_btn_Click(object sender, EventArgs e)
        {
            if(db_username_inp.UseSystemPasswordChar == true)
            {
                db_username_inp.UseSystemPasswordChar = false;
            }
            else
            {
                db_username_inp.UseSystemPasswordChar = true;
            }
        }

        private void password_show_btn_Click(object sender, EventArgs e)
        {
            if (db_password_inp.UseSystemPasswordChar == true)
            {
                db_password_inp.UseSystemPasswordChar = false;
            }
            else
            {
                db_password_inp.UseSystemPasswordChar = true;
            }
        }

        private void update_database_btn_Click(object sender, EventArgs e)
        {
            this.Save_Server_Settings();
            DatabaseHandler db_handler = new DatabaseHandler();
            db_handler.createAllTables();
            XtraMessageBox.Show("Database is updated !");
        }

        public void Save_Software_Registeration_Settings()
        {
            if(registeration_type.SelectedIndex == 1 && reg_paid_month_cmb.Text == "")
            {
                XtraMessageBox.Show("Please select paid month !");
            }
            else if(registeration_type.SelectedIndex == 2 && soft_start_date.Text == "" && soft_end_date.Text == "")
            {
                XtraMessageBox.Show("Please select start and end dates for software !");
            }
            else if (registeration_type.SelectedIndex == 2 && Convert.ToDateTime(soft_end_date.Text) <= DateTime.Now)
            {
                XtraMessageBox.Show("Please select end date greater then current date !");
            }
            else
            {
                this.Store_Software_Registeration_Settings();
            }
        }
        public void Store_Software_Registeration_Settings()
        {
            Supper_Admin_Setting supper_admin_settings = new Supper_Admin_Setting();
            if (supper_admin_settings.Store_Software_Registeration_Settings(Convert.ToInt32(registeration_type.SelectedIndex), reg_paid_month_cmb.Text, soft_start_date.Text, soft_end_date.Text))
            {
                XtraMessageBox.Show("Software registeration settings are updated !");
            }
        }
        private void soft_registeration_btn_Click(object sender, EventArgs e)
        {
            Save_Tabs_Visibility_Settings();
            this.Save_Software_Registeration_Settings();

        }

        private void Load_Tabs_Visibility_Settings()
        {
            aggrements_tab_check.Checked = Settings.Default.show_aggrements_tab;
            messages_tab_check.Checked = Settings.Default.show_messages_tab;
            purchases_tab_check.Checked = Settings.Default.show_purchases_tab;
            inventory_tab_check.Checked = Settings.Default.show_inventory_tab;
            employees_tab_check.Checked = Settings.Default.show_employees_tab;
            accounts_tab_check.Checked = Settings.Default.show_accounts_tab;
            vouchers_tab_check.Checked = Settings.Default.show_vouchers_tab;
            reports_tab_check.Checked = Settings.Default.show_reports_tab;
            settings_tab_check.Checked = Settings.Default.show_settings_tab;
        }

        private void Save_Tabs_Visibility_Settings()
        {
            Settings.Default.show_aggrements_tab = aggrements_tab_check.Checked;
            Settings.Default.show_messages_tab = messages_tab_check.Checked;
            Settings.Default.show_purchases_tab = purchases_tab_check.Checked;
            Settings.Default.show_inventory_tab = inventory_tab_check.Checked;
            Settings.Default.show_employees_tab = employees_tab_check.Checked;
            Settings.Default.show_accounts_tab = accounts_tab_check.Checked;
            Settings.Default.show_vouchers_tab = vouchers_tab_check.Checked;
            Settings.Default.show_reports_tab = reports_tab_check.Checked;
            Settings.Default.show_settings_tab = settings_tab_check.Checked;
        }

        private void server_name_inp_TextChanged(object sender, EventArgs e)
        {

        }

        private void Supper_Admin_Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }

        private void admin_password_update_btn_Click(object sender, EventArgs e)
        {
            if(admin_new_password_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter new password !");
                admin_new_password_inp.Focus();
            }else if (admin_confirm_pass_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter confirm password !");
                admin_confirm_pass_inp.Focus();
            }else if(admin_new_password_inp.Text != admin_confirm_pass_inp.Text)
            {
                XtraMessageBox.Show("Please enter correct confirm password !");
                admin_confirm_pass_inp.Focus();
            }
            else
            {
                Login_Controller l_c = new Login_Controller();
                if (l_c.Update_Password("admin", admin_new_password_inp.Text))
                {
                    XtraMessageBox.Show("Admin password has been updated successfully !");
                }
            }
        }

        private void flush_databse_btn_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("All the data/entries will be deleted from the database.\nAre you sure, you want to flush the database?", "Warning Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.No)
            {
                DatabaseHandler db_handler = new DatabaseHandler();
                db_handler.TRUNCATE_DATABASE();
                XtraMessageBox.Show("Database has been truncated !");
            }
        }

        private void wifi_show_pass_btn_Click(object sender, EventArgs e)
        {
            if (wifi_password_inp.UseSystemPasswordChar == true)
            {
                wifi_password_inp.UseSystemPasswordChar = false;
            }
            else
            {
                wifi_password_inp.UseSystemPasswordChar = true;
            }
        }

        private void api_show_pass_btn_Click(object sender, EventArgs e)
        {
            if (api_pass_inp.UseSystemPasswordChar == true)
            {
                api_pass_inp.UseSystemPasswordChar = false;
            }
            else
            {
                api_pass_inp.UseSystemPasswordChar = true;
            }
        }

        private void sms_config_cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sms_config_save_btn_Click(object sender, EventArgs e)
        {

            //For Wifi
            Settings.Default["wifi_ip_address"] = wifi_ip_address_inp.Text ;
            Settings.Default["wifi_port"] = wifi_port_inp.Text;
            Settings.Default["wifi_user_name"] = wifi_user_name_inp.Text;
            Settings.Default["wifi_password"] = wifi_password_inp.Text;

            //For API
            Settings.Default["api_url"] = api_url_inp.Text;
            Settings.Default["api_port"] = api_port_inp.Text;
            Settings.Default["api_masking"] = api_maskng_inp.Text;
            Settings.Default["api_username"] = api_username_inp.Text;
            Settings.Default["api_password"] = api_pass_inp.Text;

            Settings.Default["sms_gateway"] = sms_gateway_cmb.Text;
            Settings.Default["default_sms_gateway"] = default_sms_gateway_cmb.Text;
            Settings.Default["default_sms_language"] = default_sms_lang_cmb.Text;

            Settings.Default.Save();

            XtraMessageBox.Show("SMS Configurations has been updated successfully !");
        }

        private void test_sms_connection_btn_Click(object sender, EventArgs e)
        {
            Messages.Messages_Controller messages_controller = new Messages.Messages_Controller();
            if (sms_gateway_cmb.Text == "API")
            {
                string jsonResponse = null;
                jsonResponse =messages_controller.SendSMS_VIA_API("03061192596", "Testing API");
                if(jsonResponse != "" && jsonResponse != null)
                {
                    if (jsonResponse.Substring(0, 2) == "OK")
                    {
                        XtraMessageBox.Show("Connection established successfuly !");
                    }
                    else
                    {
                        XtraMessageBox.Show(jsonResponse);
                    }
                }
            }
            else
            {
                //string wifi_server_result =messages_controller.Send_SMS_VIA_ANDROID_WIFI("03061192596","Testing API", Settings.Default.wifi_user_name, Settings.Default.wifi_password, Settings.Default.wifi_ip_address, Settings.Default.wifi_port);
                //var NameObject = JsonConvert.DeserializeObject<Messages.Wifi__Server_Status>(wifi_server_result);
                //if (NameObject.Status == "200")
                //{
                //    XtraMessageBox.Show("Connection established successfuly !");
                //}
                //else
                //{
                //    XtraMessageBox.Show("Connection Error:"+ wifi_server_result);
                //}
            }
        }

        private void custom_connection_check_CheckedChanged(object sender, EventArgs e)
        {
            if (custom_connection_check.CheckState == CheckState.Checked)
            {
                custom_connection_inp.Text = @"Data Source=" + server_name_inp.Text + ";Initial Catalog=" + db_name_inp.Text + ";User ID=" + db_username_inp.Text + ";Password=" + db_password_inp.Text + ";MultipleActiveResultSets=True;Pooling=False;";
                custom_connection_inp.Enabled = true;
            }
            else
            {
                custom_connection_inp.Text = null;
                custom_connection_inp.Enabled = false;
            }
        }

        private void restore_db_btn_Click(object sender, EventArgs e)
        {
            string file_source = null;
            OpenFileDialog file_dlg = new OpenFileDialog();
            file_dlg.Filter = "BAK Files(*.bak;)|*.bak";
            if (file_dlg.ShowDialog(this) == DialogResult.OK)
            {
                file_source = file_dlg.FileName.ToString();
                if (XtraMessageBox.Show("Are you sure, you want to restore '" + file_dlg.SafeFileName.ToString()+"'", "Confirm Restore!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DatabaseHandler db_handler = new DatabaseHandler();
                    db_handler.Restore_Database(file_source);
                }
            }
        }

        private void soft_start_date_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}