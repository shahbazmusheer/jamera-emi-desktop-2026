using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using Jamera.Application_Settings;
using Jamera.Properties;
using Jamera.Reports.Recoveries;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
namespace Jamera
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            DevExpress.UserSkins.BonusSkins.Register();
            
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle(Settings.Default.App_Default_Skin);
            new Supper_Admin_Setting().refreshServerConnection();
            
            systemValidations sys_valid = new systemValidations();
            if (sys_valid.is_valid())
            {
                int registeration_type = Settings.Default.reg_type;
                if (registeration_type == 0)
                {
                    Application.Run(new Application_Settings.Trials());
                }
                if (registeration_type == 1)
                {
                    Installments ins = new Installments();
                    if (ins.Is_Valid())
                    {
                        Application.Run(new Login_Form());
                    }
                    else
                    {
                        if (XtraMessageBox.Show("Your installment period is completed. Are you admin ?", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                        {
                            Application.Run(new Application_Settings.Super_Admin_Login());
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                }

                if (registeration_type == 2)
                {
                    String current_date_str = DateTime.Now.ToString("dd-MM-yyyy");
                    DateTime current_date = Convert.ToDateTime(current_date_str);
                    DateTime soft_end_date = Convert.ToDateTime(Settings.Default.soft_end_date);
                    if (current_date >= soft_end_date)
                    {
                        if (XtraMessageBox.Show("Yearly license agreement is completed ! Are you admin ?", "Warning Alert", MessageBoxButtons.YesNo) == DialogResult.OK)
                        {
                            Application.Run(new Application_Settings.Super_Admin_Login());
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        Application.Run(new Login_Form());
                    }
                }
                if (registeration_type == 3)
                {
                    //Application.Run(new UC_Opener_Form("Bulk Voucher", new Vouchers.Bulk_Cash_Voucher()) { WindowState = FormWindowState.Maximized});
                    Application.Run(new Login_Form());
                    //Application.Run(new Application_Settings.Supper_Admin_Settings());
                    //Application.Run(new Recovery_Master());
                }

            }
            else
            {
                if (XtraMessageBox.Show("Please register your system to use this software !", "Warning Alert", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    Application.Run(new Application_Settings.Super_Admin_Login());
                }
                else
                {
                    Application.Exit();
                }
            }
            //DatabaseHandler database_handler = new DatabaseHandler();
            //database_handler.createAllTables();
            //Application.Run(new Login());
            //Application.Run(new UC_Opener_Form("Aggrement Return", new Aggrements.Aggrment_Return()) { WindowState = FormWindowState.Maximized});
        }
    }
}