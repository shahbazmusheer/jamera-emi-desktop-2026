using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jamera.Properties;
using DevExpress.XtraEditors;
using System.Configuration;

namespace Jamera.Application_Settings
{
    class Supper_Admin_Setting
    {
        public bool Store_General_Settings(String OS_NUMBER,String BASEBOARD_NO)
        {
            if(OS_NUMBER == "" && BASEBOARD_NO == "")
            {
                XtraMessageBox.Show("Please pass the values of general settings !");
                return false;
            }else if(OS_NUMBER == "")
            {
                XtraMessageBox.Show("Please pass the operating system number !");
                return false;
            }
            else
            {
                Settings.Default["OS_No"] = OS_NUMBER;
                Settings.Default["Baseboard_No"] = BASEBOARD_NO;
                Settings.Default.Save();
                return true;
            }
        }

        public bool Store_Server_Settings(String SERVER_NAME,String DATABASE_NAME,String USER_NAME,String DATABASE_PASSWORD,String BAKUP_DRIVE, String CUSTOM_CONNECTION)
        {
            if(SERVER_NAME == "")
            {
                XtraMessageBox.Show("Please pass server name !");
                return false;
            }else if (DATABASE_NAME == "")
            {
                XtraMessageBox.Show("Please pass database name !");
                return false;
            }
            else if (USER_NAME == "")
            {
                XtraMessageBox.Show("Please pass user name !");
                return false;
            }
            else if (DATABASE_PASSWORD == "")
            {
                XtraMessageBox.Show("Please pass database password !");
                return false;
            }
            else if (BAKUP_DRIVE == "")
            {
                XtraMessageBox.Show("Please pass bakup drive !");
                return false;
            }
            else
            {
                Settings.Default["server_name"] = SERVER_NAME;
                Settings.Default["db_name"] = DATABASE_NAME;
                Settings.Default["db_user_name"] = USER_NAME;
                Settings.Default["db_password"] = DATABASE_PASSWORD;
                Settings.Default["backup_drive"] = BAKUP_DRIVE;
                Settings.Default["custom_connection"] = CUSTOM_CONNECTION;
                Settings.Default.Save();

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connection_str_section = (ConnectionStringsSection)config.GetSection("connectionStrings");
                if(connection_str_section != null)
                {
                    String query = @"XpoProvider=MSSqlServer;Data Source=" + SERVER_NAME + ";Initial Catalog=" + DATABASE_NAME + ";User ID=" + USER_NAME + ";Password=" + DATABASE_PASSWORD + ";MultipleActiveResultSets=True;Pooling=False;";
                    connection_str_section.ConnectionStrings["JAMERA_CONNECTION"].ConnectionString = query;
                    config.Save();
                    ConfigurationManager.RefreshSection("connectionStrings");
                }
                return true;
            }
        }

        public void refreshServerConnection()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connection_str_section = (ConnectionStringsSection)config.GetSection("connectionStrings");
            if (connection_str_section != null)
            {
                String query = @"XpoProvider=MSSqlServer;Data Source=" + Settings.Default.server_name + ";Initial Catalog=" + Settings.Default.db_name + ";User ID=" + Settings.Default.db_user_name + ";Password=" + Settings.Default.db_password + ";MultipleActiveResultSets=True;Pooling=False;";
                connection_str_section.ConnectionStrings["JAMERA_CONNECTION"].ConnectionString = query;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        
        public bool Store_Software_Registeration_Settings(int REGISTERATION_TYPE,String PAID_MONTH,String SOFTWARE_START_DATE,String SOFTWARE_END_DATE)
        {
            String PAID_MONTH_VAL = null;
            String SOFT_START_DATE = null;
            String SOFT_END_DATE = null;
            if(REGISTERATION_TYPE == 0)
            {
                PAID_MONTH = null;
                SOFT_START_DATE = null;
                SOFT_END_DATE = null;
            }else if(REGISTERATION_TYPE == 1)
            {
                PAID_MONTH_VAL = PAID_MONTH;
                SOFT_START_DATE = null;
                SOFT_END_DATE = null;
            }else if(REGISTERATION_TYPE == 2)
            {
                PAID_MONTH = null;
                SOFT_START_DATE = SOFTWARE_START_DATE;
                SOFT_END_DATE = SOFTWARE_END_DATE;
            }
            else if(REGISTERATION_TYPE == 3)
            {
                PAID_MONTH = null;
                SOFT_START_DATE = null;
                SOFT_END_DATE = null;
            }

            Settings.Default["reg_type"] = REGISTERATION_TYPE;
            Settings.Default["paid_month"] = PAID_MONTH_VAL;
            Settings.Default["soft_start_date"] = SOFT_START_DATE;
            Settings.Default["soft_end_date"] = SOFT_END_DATE;
            Settings.Default.Save();
            return true;

        }
    }
}
