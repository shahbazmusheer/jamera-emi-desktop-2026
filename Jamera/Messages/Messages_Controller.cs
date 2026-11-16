using System;
using System.Net;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data;
using Jamera.Properties;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Jamera.Messages
{
     class Messages_Controller
    {
        TcpClient client;
        Assets.PhonesController phones_controller = new Assets.PhonesController();
        SqlConnection conn = new SqlConnection();
        public Messages_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }
        public int Send_Message(Message message)
        {
            Console.WriteLine("I m entered in Messages_Controller.Send_Message() function...");
            int result = -2;
            String[] phone_formats = phones_controller.Get_Phone_Formates(message.RECIEVER_NUMBER);            
            string jsonResponse = null;
            if (Settings.Default.should_save_message_without_sent == true)
            {
                jsonResponse = "OK";
            }
            else
            {
                if (message.SMS_Gateway == "API")
                {
                    jsonResponse = SendSMS_VIA_API(phone_formats[5], message.Message_Text, message.Message_Type);
                    if (jsonResponse != null)
                    {
                        if (jsonResponse.Substring(0, 2) == "OK")
                        {
                            result = 1;
                        }
                        else
                        {
                            result = -2;
                        }
                    }
                }
                else if(message.SMS_Gateway == "Android Wifi")
                {
                    Console.WriteLine("I m entered in Android Wifi function...");
                    int wifi_server_result = Send_SMS_VIA_ANDROID_WIFI(phone_formats[0], message.Message_Text, Settings.Default.wifi_ip_address,Settings.Default.wifi_port);
                    Console.WriteLine("result="+wifi_server_result);
                    result = wifi_server_result;
                }
            }
            return result;
        }
        public int Store_Message(Message message)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO messages(store_id,group_name,account_id,date,to_number,message_text,status,message_type,sms_gateway) values(@store_id,@group_name,@account_id,@date,@to_number,@message_text,@status,@message_type,@sms_gateway) SELECT CAST(scope_identity() AS int)", conn))
            {
                if (message.ACCOUNT_ID != -1)
                {
                    cmd.Parameters.AddWithValue("@account_id", message.ACCOUNT_ID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@account_id", DBNull.Value);
                }
                if(message.Group == null)
                {
                    cmd.Parameters.AddWithValue("@group_name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@group_name", message.Group);
                }
                if (message.Store_Id == -1)
                {
                    cmd.Parameters.AddWithValue("@store_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@store_id", message.Store_Id);
                }
                cmd.Parameters.AddWithValue("@sms_gateway", message.SMS_Gateway);
                cmd.Parameters.AddWithValue("@message_type", message.Message_Type);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@to_number", message.RECIEVER_NUMBER);
                cmd.Parameters.AddWithValue("@message_text", message.Message_Text);
                
                cmd.Parameters.AddWithValue("@status", message.Status);
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }
        public int Update_Message(Message message)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE messages SET store_id=@store_id,group_name=@group_name,account_id=@account_id,date=@date,to_number=@to_number,message_text=@message_text,status=@status,message_type=@message_type,sms_gateway=@sms_gateway WHERE id=@message_id", conn))
            {
                cmd.Parameters.AddWithValue("@message_id", message.Message_Id);
                if (message.ACCOUNT_ID != -1)
                {
                    cmd.Parameters.AddWithValue("@account_id", message.ACCOUNT_ID);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@account_id", DBNull.Value);
                }
                if (message.Group == null)
                {
                    cmd.Parameters.AddWithValue("@group_name", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@group_name", message.Group);
                }
                if (message.Store_Id == -1)
                {
                    cmd.Parameters.AddWithValue("@store_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@store_id", message.Store_Id);
                }
                cmd.Parameters.AddWithValue("@sms_gateway", message.SMS_Gateway);
                cmd.Parameters.AddWithValue("@message_type", message.Message_Type);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@to_number", message.RECIEVER_NUMBER);
                cmd.Parameters.AddWithValue("@message_text", message.Message_Text);

                cmd.Parameters.AddWithValue("@status", message.Status);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
            return result;
        }
        public int Send_SMS_VIA_ANDROID_WIFI(string toNumber, string MessageText,String Ip_Address, String Port, String Message_Type = "English")
        {
            int result = -2;
            goto send_sms_msg;
        //Server Result Codes Description -----
        //[-3]=Wait... Server is busy
        //[-2]=Client not connected 
        //[-1]= No Service
        //[0] = Null PDU
        //[1] = Sent
        //[2] = AirPlane Mode / Radio Off
        //[3] = Short Codes Never Allowed
        //[4] = Unknown Error
        send_sms_msg:
            try
            {
                Console.WriteLine("Message Sending ...");
                String Unicode_Lang = null;
                if (Message_Type == "English")
                {
                    Unicode_Lang = "eng";
                }
                else
                {
                    Unicode_Lang = "urd";
                }
                string msg_str = "http://192.168.1.1:8092?lang=" + Unicode_Lang + "&phone=" + toNumber + "&message=" + MessageText;
                if (!(SMS_Gateway.Is_Busy)) {
                    result = SMS_Gateway.Send(msg_str);
                }
                else
                {
                    result = -3;
                }
            }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            return result;
        }
        public string SendSMS_VIA_API(string toNumber, string MessageText, String Message_Type = "English")
        {
            if (Message_Type != "English")
            {
                String URI = Settings.Default.api_url +
            "/api/sms.php?" +
            "username=" + Settings.Default.api_username +
            "&password=" + Settings.Default.api_password +
            "&sender=" + Settings.Default.api_masking +
            "&mobile=" + toNumber +
            "&type=" + "unicode" +
            "&message=" + Uri.UnescapeDataString(MessageText); // Visual Studio 10-15 
                //"//&message=" + WebUtility.UrlEncode(MessageText);// Visual Studio 12 
                try
                {
                    WebRequest req = WebRequest.Create(URI);
                    WebResponse resp = req.GetResponse();
                    var sr = new System.IO.StreamReader(resp.GetResponseStream());
                    return sr.ReadToEnd().Trim();
                }
                catch (WebException ex)
                {
                    var httpWebResponse = ex.Response as HttpWebResponse;
                    if (httpWebResponse != null)
                    {
                        switch (httpWebResponse.StatusCode)
                        {
                            case HttpStatusCode.NotFound:
                                return "404:URL not found :" + URI;
                                break;
                            case HttpStatusCode.BadRequest:
                                return "400:Bad Request";
                                break;
                            default:
                                return httpWebResponse.StatusCode.ToString();
                        }
                    }
                }
            }
            else
            {
                String URI = Settings.Default.api_url +
            "/api/sms.php?" +
            "username=" + Settings.Default.api_username +
            "&password=" + Settings.Default.api_password +
            "&sender=" + Settings.Default.api_masking +
            "&mobile=" + toNumber +
            "&message=" + Uri.UnescapeDataString(MessageText); // Visual Studio 10-15 
               //"//&message=" + WebUtility.UrlEncode(MessageText);// Visual Studio 12 
                try
                {
                    WebRequest req = WebRequest.Create(URI);
                    WebResponse resp = req.GetResponse();
                    var sr = new System.IO.StreamReader(resp.GetResponseStream());
                    return sr.ReadToEnd().Trim();
                }
                catch (WebException ex)
                {
                    var httpWebResponse = ex.Response as HttpWebResponse;
                    if (httpWebResponse != null)
                    {
                        switch (httpWebResponse.StatusCode)
                        {
                            case HttpStatusCode.NotFound:
                                return "404:URL not found :" + URI;
                                break;
                            case HttpStatusCode.BadRequest:
                                return "400:Bad Request";
                                break;
                            default:
                                return httpWebResponse.StatusCode.ToString();
                        }
                    }
                }
            }

            return null;
        }

        public Message Get_Message(int Message_Id)
        {
            Message message = new Message();
            conn.Open();
            String query = @"SELECT messages.store_id,messages.date as 'Date',messages.group_name as 'Group',messages.account_id as 'User.Code',(CASE WHEN messages.group_name in (SELECT name from account_groups) Then (select name from accounts WHERE accounts.id= messages.account_id ) ELSE (select name from group_contacts WHERE group_contacts.id= messages.account_id ) END) as 'User',messages.to_number as 'Ph.No',messages.id as 'Msg.Code',messages.message_type as 'Msg.Type',messages.message_text as 'Msg.Text',messages.status as 'Status' from messages WHERE messages.id='" + Message_Id+"' order by messages.date desc;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                message.Message_Id = Convert.ToInt32(reader["Msg.Code"]);
                if(reader["User.Code"] != DBNull.Value)
                {
                    message.ACCOUNT_ID = Convert.ToInt32(reader["User.Code"]);
                    message.RECIEVER_NAME= Convert.ToString(reader["User"]);
                }
                if(reader["store_id"] != DBNull.Value)
                {
                    message.Store_Id = Convert.ToInt32(reader["store_id"]);
                }
                else
                {
                    message.Store_Id = -1;
                }
                message.Message_Date = Convert.ToString(reader["Date"]);
                message.Group = Convert.ToString(reader["Group"]);
                message.Message_Text = Convert.ToString(reader["Msg.Text"]);
                message.Message_Type = Convert.ToString(reader["Msg.Type"]);
                message.RECIEVER_NUMBER = Convert.ToString(reader["Ph.No"]);
                message.Message_Status = Convert.ToString(reader["Status"]);
            }
            reader.Close();
            conn.Close();
            return message;
        }
        public void Delete_Message(int Message_Id)
        {
            conn.Open();
            String query = @"DELETE FROM messages WHERE messages.id='" + Message_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
