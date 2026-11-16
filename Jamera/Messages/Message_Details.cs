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
using System.Threading;
using Jamera.Properties;
namespace Jamera.Messages
{
    public partial class Message_Details : DevExpress.XtraEditors.XtraForm
    {
        Message message;
        Thread SMS_Thread;
        delegate void Hide_Panel(Boolean visible_val);
        delegate void Send_Btn_Enabled(Boolean enabled_val);
        delegate void Update_Sent_Message_Counter(String sent_messages_text_value);
        delegate void Group_Cmb_Enabled(Boolean enabled_val);
        delegate void Grid_Cntl_Enabled(Boolean enabled_val);
        delegate void Message_Text_Enabled(Boolean enabled_val);
        Messages_Controller messages_controller = new Messages_Controller();
        public int account_id = -1;
        public Message_Details(int Message_Id)
        {
            InitializeComponent();
            message = messages_controller.Get_Message(Message_Id);
            Load_Data();
            SMS_Thread = new Thread(() => Send_Message_To_Numbers(null,null,null,null));
        }
        public void Send_Message()
        {
            if (phone_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter phone number !");
                phone_inp.Focus();
            }
            else if (message_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter message text !");
                message_inp.Focus();
            }
            else
            {
                String Message_Text = message_inp.Text;
                String SMS_Gateway = sms_gateway_cmb.Text;
                String Message_Type=messages_type_cmb.Text;
                String Phone = phone_inp.Text;
                SMS_Thread = new Thread(() => Send_Message_To_Numbers(Message_Type, Message_Text, SMS_Gateway, Phone));
                SMS_Thread.Start();
            }
        }
        public void Send_Message_To_Numbers(String Message_Type, string Message_Text, String SMS_Gateway, String Phone)
        {
            if (Phone != null && Phone != "")
            {
                //Send Message to office phone
                Message temp_message = new Message();
                temp_message.Message_Id = message.Message_Id;
                temp_message.ACCOUNT_ID = message.ACCOUNT_ID;
                temp_message.Store_Id = message.Store_Id;
                temp_message.Message_Text = Message_Text;
                temp_message.Message_Type = Message_Type;
                temp_message.Group = message.Group;
                temp_message.SMS_Gateway = SMS_Gateway;
                temp_message.RECIEVER_NUMBER = Phone;
                goto send_message_start;
            send_message_start:
                int is_sent = -1;
                is_sent = messages_controller.Send_Message(temp_message);
                if (is_sent == 1)
                {
                    temp_message.Status = "Sent";
                    Console.WriteLine("Message sent susscessfuly !");
                }
                else if (is_sent == -3)
                {
                    Thread.Sleep(2000);
                    goto send_message_start;
                }
                else
                {
                    temp_message.Status = "Draft";
                    Console.WriteLine("Message Drafted !");
                }
                messages_controller.Update_Message(temp_message);
            }
            Hide_Panel after_all_messages_sent = new Hide_Panel(after_sent_messages);
            progress_panel.BeginInvoke(after_all_messages_sent, false);
            Send_Btn_Enabled send_btn_enbl = new Send_Btn_Enabled(send_btn_enabled);
            Message_Text_Enabled mte = new Message_Text_Enabled(message_text_enabled);
            message_inp.BeginInvoke(mte, false);
            XtraMessageBox.Show("Message sending task is completed !");
            SMS_Thread.Abort();
        }
        public void phone_inp_enabled(Boolean bool_val)
        {
            phone_inp.ReadOnly = bool_val;
        }
        public void after_sent_messages(Boolean visibal_value)
        {
            progress_panel.Visible = visibal_value;
        }
        public void message_text_enabled(Boolean visibal_value)
        {
            message_inp.ReadOnly = visibal_value;
        }
        public void send_btn_enabled(Boolean visibal_value)
        {
            resend_btn.Enabled = visibal_value;
        }
        public void Load_Data()
        {
            phone_inp.Text= message.RECIEVER_NUMBER;
            messages_type_cmb.Text = message.Message_Type;
            if (messages_type_cmb.Text != "English")
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "Urdu (Islamic Republic of Pakistan)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "English (United States)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = RightToLeft.No;
            }
            Console.WriteLine("Load_Date()=====> Msg Text:" + message.Message_Text);
            message_inp.Text = message.Message_Text;
        }

        private void phone_inp_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void message_inp_TextChanged(object sender, EventArgs e)
        {
            int char_count = message_inp.Text.Length;
            if (char_count > 10)
            {
                chrators_count_lbl.ForeColor = SystemColors.HotTrack;
            }
            else if (char_count > 0)
            {
                chrators_count_lbl.ForeColor = Color.OrangeRed;
            }
            else
            {
                chrators_count_lbl.ForeColor = SystemColors.HotTrack;
            }
            chrators_count_lbl.Text = char_count.ToString();
        }

        private void search_filter_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (messages_type_cmb.Text != "English")
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "Urdu (Islamic Republic of Pakistan)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "English (United States)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = RightToLeft.No;
            }
            message_inp.Text = null;
        }

        private void resend_btn_Click(object sender, EventArgs e)
        {
            Send_Message();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to delete the message?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                messages_controller.Delete_Message(message.Message_Id);
                this.Close();
            }
        }

        private void Message_Details_Load(object sender, EventArgs e)
        {
            if (Settings.Default.default_sms_gateway == "API")
            {
                sms_gateway_cmb.Text = Settings.Default.default_sms_gateway;
            }
            else if (Settings.Default.default_sms_gateway == "Android Wifi")
            {
                sms_gateway_cmb.Text = Settings.Default.default_sms_gateway;
            }
            else if (Settings.Default.default_sms_gateway == "None")
            {
                sms_gateway_cmb.Text = Settings.Default.default_sms_gateway;
                sms_gateway_cmb.Enabled = false;
                resend_btn.Enabled = false;

            }
            messages_type_cmb.Text = Settings.Default.default_sms_language;
            if (Settings.Default.default_sms_language != "English")
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "Urdu (Islamic Republic of Pakistan)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
                {
                    if (lng.Culture.DisplayName == "English (United States)")
                    {
                        InputLanguage.CurrentInputLanguage = lng;
                    }
                }
                message_inp.RightToLeft = RightToLeft.No;
            }
        }

        private void Message_Details_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
            {
                if (lng.Culture.DisplayName == "English (United States)")
                {
                    InputLanguage.CurrentInputLanguage = lng;
                }
            }
        }

        private void sms_gateway_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sms_gateway_cmb.Text != "")
            {
                Settings.Default["default_sms_gateway"] = sms_gateway_cmb.Text;
                Settings.Default.Save();
            }
        }

        private void message_inp_Leave(object sender, EventArgs e)
        {
            foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
            {
                if (lng.Culture.DisplayName == "English (United States)")
                {
                    InputLanguage.CurrentInputLanguage = lng;
                }
            }
            if (messages_type_cmb.Text != "English")
            {
                message_inp.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                message_inp.RightToLeft = RightToLeft.No;
            }
        }
    }
}
