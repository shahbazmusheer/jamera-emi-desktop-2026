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
using System.Text.RegularExpressions;
using System.IO;

namespace Jamera.Application_Settings
{
    public partial class Admin_Settings : DevExpress.XtraEditors.XtraForm
    {
        String Message_Title = "Error Alert";
        public Admin_Settings()
        {
            InitializeComponent();

            company_name_inp.Text=Settings.Default.company_name;
            company_phone_inp.Text = Settings.Default.company_phone;
            company_address_inp.Text = Settings.Default.company_address;
            company_other_info_inp.Text = Settings.Default.company_other_info;
            message_text_container.Text = Settings.Default.new_aggrement_message;

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

            if (Settings.Default.send_message_on_new_aggrement== true)
            {
                new_aggrement_send_message.CheckState = CheckState.Checked;
            }
            else
            {
                new_aggrement_send_message.CheckState = CheckState.Unchecked;
            }
            send_message_to_phones_cmb.SelectedIndex = Settings.Default.phone_number_options_home_office;


            company_icon_path.Text = Settings.Default.company_icon;
            before_emi_days.Text = Settings.Default.emi_before_days.ToString();
            after_emi_days.Text = Settings.Default.emi_after_days.ToString();
            if(Settings.Default.is_send_message_after_due_date == true)
            {
                is_send_message_after_due_date.CheckState = CheckState.Checked;
            }
            else
            {
                is_send_message_after_due_date.CheckState = CheckState.Unchecked;
            }
            if(Settings.Default.is_send_message_before_due_date == true)
            {
                is_send_message_before_due_date.CheckState = CheckState.Checked;
            }
            else
            {
                is_send_message_before_due_date.CheckState = CheckState.Unchecked;
            }
            if (Settings.Default.send_message_after_stock_transfer == true)
            {
                is_send_message_after_stock_transfer.CheckState = CheckState.Checked;
            }
            else
            {
                is_send_message_after_stock_transfer.CheckState = CheckState.Unchecked;
            }
            if (Settings.Default.send_message_on_update_aggrement_status == true)
            {
                update_aggrement_status_check.CheckState = CheckState.Checked;
            }
            else
            {
                update_aggrement_status_check.CheckState = CheckState.Unchecked;
            }
        }

        private void Admin_Settings_Load(object sender, EventArgs e)
        {
            tabPane.SelectedPageIndex = 0;
            loadPrevAccDetails();
            loadValidations();
        }

        private void Admin_Settings_Shown(object sender, EventArgs e)
        {
            
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void company_name_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void address_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void phone_no_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void other_info_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                XtraMessageBox.Show("Codes are not available to save general settings!", Message_Title);
            }
        }

        private void admin_current_pass_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                admin_new_pass_inp.Focus();
            }
        }

        private void admin_new_pass_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                admin_confirm_pass_inp.Focus();
            }
        }

        private void admin_confirm_pass_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (ch == 13)
            {
                XtraMessageBox.Show("Codes are not available to save admin password settings!", Message_Title);
            }
        }

        private void save_messages_setting_btn_Click(object sender, EventArgs e)
        {
            if(new_aggrement_send_message.CheckState == CheckState.Checked)
            {
                Settings.Default["send_message_on_new_aggrement"] = true;
            }
            else
            {
                Settings.Default["send_message_on_new_aggrement"] = true;
            }
            Settings.Default["phone_number_options_home_office"] = send_message_to_phones_cmb.SelectedIndex;
            if(before_emi_days.Text != "")
            {
                Settings.Default["emi_before_days"] = Convert.ToInt32(before_emi_days.Text);
            }
            if (after_emi_days.Text != "")
            {
                Settings.Default["emi_after_days"] = Convert.ToInt32(after_emi_days.Text);
            }
            if(is_send_message_after_due_date.CheckState == CheckState.Checked)
            {
                Settings.Default["is_send_message_after_due_date"] = true;
            }
            else
            {
                Settings.Default["is_send_message_after_due_date"] = false;
            }
            if (is_send_message_before_due_date.CheckState == CheckState.Checked)
            {
                Settings.Default["is_send_message_before_due_date"] = true;
            }
            else
            {
                Settings.Default["is_send_message_before_due_date"] = false;
            }
            if(is_send_message_after_stock_transfer.CheckState == CheckState.Checked)
            {
                Settings.Default["send_message_after_stock_transfer"] = true;
            }
            else
            {
                Settings.Default["send_message_after_stock_transfer"] = false;
            }
            if (update_aggrement_status_check.CheckState == CheckState.Checked)
            {

                Settings.Default["send_message_on_update_aggrement_status"]= true;
            }
            else
            {
                Settings.Default["send_message_on_update_aggrement_status"] = false;
            }
            Settings.Default.Save();
            XtraMessageBox.Show("Message Settings saved successfully !");
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tasks_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tasks_cmb.ContainsFocus == true)
            {
                if(tasks_cmb.SelectedIndex == 0)
                {
                    //new aggrement
                    message_text_container.Text = Settings.Default.new_aggrement_message;
                }else if (tasks_cmb.SelectedIndex == 1)
                {
                    //due date
                    message_text_container.Text = Settings.Default.due_date_message;
                }
                else if(tasks_cmb.SelectedIndex == 2)
                {
                    //cash voucher
                    message_text_container.Text = Settings.Default.cash_voucher_eng_message;
                }
                else
                {
                    //after du date
                    message_text_container.Text = Settings.Default.after_due_date_message;
                }
            }
        }

        private void message_text_save_btn_Click(object sender, EventArgs e)
        {
            if (tasks_cmb.SelectedIndex == 0)
            {
                //new aggrement
                Settings.Default["new_aggrement_message"]= message_text_container.Text;
                Settings.Default.Save();
            }
            else if (tasks_cmb.SelectedIndex == 1)
            {
                //due date
                Settings.Default["due_date_message"]= message_text_container.Text;
                Settings.Default.Save();
            }
            else if (tasks_cmb.SelectedIndex == 2)
            {
                //cash voucher
                Settings.Default["cash_voucher_message"]= message_text_container.Text;
                Settings.Default.Save();
            }
            else
            {
                //after du date
                Settings.Default["after_due_date_message"]= message_text_container.Text;
                Settings.Default.Save();
            }
            XtraMessageBox.Show("Settings saved successfully !");
        }

        private void gen_save_btn_Click(object sender, EventArgs e)
        {
            Settings.Default["company_name"]=company_name_inp.Text;
            Settings.Default["company_phone"]=company_phone_inp.Text;
            Settings.Default["company_address"]=company_address_inp.Text;
            Settings.Default["company_other_info"] =company_other_info_inp.Text;

            //if (company_icon_path.Text != null && company_icon_path.Text != "")
            //{
            //    FileInfo Old_img_path = new FileInfo(company_icon_path.Text);
            //    string New_img_path = Environment.CurrentDirectory + @"\Icons\" + Old_img_path.Name;
            //    FileInfo image = new FileInfo(New_img_path);
            //    if (!(image.Exists))
            //    {
            //        Old_img_path.CopyTo(New_img_path);
            //    }
            //    Settings.Default["company_icon"] = New_img_path;
            //}
            Settings.Default.Save();

            XtraMessageBox.Show("General settings are updated !");
        }

        private void company_icon_browse_btn_Click(object sender, EventArgs e)
        {
            image_browser.Filter = "Icon Image |*.ico; *.icon;";
            if (image_browser.ShowDialog() == DialogResult.OK)
            {
                string path = image_browser.FileName;
                company_icon_path.Text = path;
                company_ico_pic_box.Image = Image.FromFile(path);
            }
        }

        private void change_password_btn_Click(object sender, EventArgs e)
        {
            if(admin_current_pass_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter current password !");
                admin_current_pass_inp.Focus();
            }else if(admin_new_pass_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter new password !");
                admin_new_pass_inp.Focus();
            }else if(admin_current_pass_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter confirm password !");
                admin_confirm_pass_inp.Focus();
            }else if(admin_new_pass_inp.Text != admin_confirm_pass_inp.Text)
            {
                XtraMessageBox.Show("Confirm password not matching the new password !");
                admin_confirm_pass_inp.Focus();
            }
            else
            {
                Login_Controller login_controller = new Login_Controller();
                if(login_controller.Is_User_Valid("Admin",admin_current_pass_inp.Text) != true)
                {
                    XtraMessageBox.Show("Please enter valid current password !");
                    admin_current_pass_inp.Focus();
                }
                else
                {
                   if(login_controller.Update_Password("Admin",admin_new_pass_inp.Text) == true)
                    {
                        XtraMessageBox.Show("Password successfully updated !");
                        admin_current_pass_inp.Text = null;
                        admin_confirm_pass_inp.Text = null;
                        admin_new_pass_inp.Text = null;
                    }
                }
            }
        }

        private void company_phone_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            company_phone_inp.MaxLength = 13;
            Char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 13 && ch != 8 && ch != 127 && ch != 45 && ch != 43)
            {
                e.Handled = true;
            }
            if (company_phone_inp.Text.Contains("+92") && company_phone_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{6}\-\d{7}");
                company_phone_inp.MaxLength = 14;
                if (company_phone_inp != null)
                    if (r.IsMatch(company_phone_inp.Text))
                    {

                    }
            }
            else if (company_phone_inp.Text.Contains("+92"))
            {
                company_phone_inp.MaxLength = 13;
            }
            else if (company_phone_inp.Text.Contains("03") && company_phone_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{4}\-\d{7}");
                company_phone_inp.MaxLength = 12;
            }
            else if (company_phone_inp.Text.Contains("03"))
            {
                company_phone_inp.MaxLength = 11;
            }
        }

        public void loadPrevAccDetails()
        {
            if (Settings.Default.insert_new_row_for_partial_receipt) insert_new_row_for_partial_receipt_auto.Checked = true;
            if (Settings.Default.load_prev_acc_name) load_prev_father_name_check.Checked = true;
            if (Settings.Default.load_prev_acc_father_name) load_prev_father_name_check.Checked = true;
            if (Settings.Default.load_prev_acc_age) load_prev_age_check.Checked = true;
            if (Settings.Default.load_prev_acc_cast) load_prev_cast_check.Checked = true;
            if (Settings.Default.load_prev_acc_profession) load_prev_profession_check.Checked = true;
            if (Settings.Default.load_prev_acc_name) load_prev_cnic_check.Checked = true;
            if (Settings.Default.load_prev_acc_business_address) load_prev_busi_add_check.Checked = true;
            if (Settings.Default.load_prev_acc_office_phone) load_prev_office_phone_check.Checked = true;
            if (Settings.Default.load_prev_acc_home_address) load_prev_home_add_check.Checked=true;
            if (Settings.Default.load_prev_acc_home_phone) load_prev_home_phone_check.Checked = true;
            if (Settings.Default.load_prev_acc_permanent_address) load_prev_perm_add_check.Checked = true;
            //store_cmb.Text = null;
            //description_inp.Text = null;
            //id_card_1_inp.Focus();
        }

        public void loadValidations()
        {
            ref_prefix_inp.Text =  Settings.Default.ref_prefix_year;
            if (Settings.Default.auto_popup_new_customer_after_agg_save) auto_popup_new_customer_after_agg_save_check.Checked = true;
            if (Settings.Default.check_emi_existence) check_emi_no_exist_Check.Checked = true;
            if (Settings.Default.check_ref_no_existence) check_ref_no_exist_Check.Checked = true;
            if (Settings.Default.low_stock_alert_on_main_window) low_stock_alert_check.Checked = true;
        }

        public void savePrevAccDetails()
        {
            try
            {
                // Name
                Settings.Default.insert_new_row_for_partial_receipt = insert_new_row_for_partial_receipt_auto.Checked;

                // Name
                Settings.Default.load_prev_acc_name = load_prev_name_check.Checked;

                // Father Name
                Settings.Default.load_prev_acc_father_name = load_prev_father_name_check.Checked;

                // Age
                Settings.Default.load_prev_acc_age = load_prev_age_check.Checked;

                // Cast
                Settings.Default.load_prev_acc_cast = load_prev_cast_check.Checked;

                // Profession
                Settings.Default.load_prev_acc_profession = load_prev_profession_check.Checked;

                // CNIC (Fixed the mapping error from your snippet)
                Settings.Default.load_prev_acc_cnic = load_prev_cnic_check.Checked;

                // Business Address
                Settings.Default.load_prev_acc_business_address = load_prev_busi_add_check.Checked;

                // Office Phone
                Settings.Default.load_prev_acc_office_phone = load_prev_office_phone_check.Checked;

                // Home Address
                Settings.Default.load_prev_acc_home_address = load_prev_home_add_check.Checked;

                // Home Phone
                Settings.Default.load_prev_acc_home_phone = load_prev_home_phone_check.Checked;

                // Permanent Address
                Settings.Default.load_prev_acc_permanent_address = load_prev_perm_add_check.Checked;

                // CRITICAL: Save the settings to the user's config file
                Settings.Default.Save();

                XtraMessageBox.Show("Loading Details Saved, Successfully!");
                // Optional: Provide feedback or move focus
                // id_card_1_inp.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error saving preferences: " + ex.Message);
            }
        }
        private void save_load_prev_details_btn_Click(object sender, EventArgs e)
        {
            savePrevAccDetails();
        }

        private void save_validations_btn_Click(object sender, EventArgs e)
        {
            saveValidations();
        }

        public void saveValidations()
        {
            try
            {
                // Name
                Settings.Default.check_emi_existence = check_emi_no_exist_Check.Checked;

                Settings.Default.auto_popup_new_customer_after_agg_save = auto_popup_new_customer_after_agg_save_check.Checked;

                // Father Name
                Settings.Default.check_ref_no_existence = check_ref_no_exist_Check.Checked;

                // Age
                Settings.Default.low_stock_alert_on_main_window = low_stock_alert_check.Checked;

                Settings.Default.ref_prefix_year = ref_prefix_inp.Text;


                // CRITICAL: Save the settings to the user's config file
                Settings.Default.Save();
                XtraMessageBox.Show("Validation Settings Saved, Successfully!");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error saving preferences: " + ex.Message);
            }
        }

        private void cancel_btn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ref_prefix_inp_TextChanged(object sender, EventArgs e)
        {

        }

        private void ref_prefix_inp_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}