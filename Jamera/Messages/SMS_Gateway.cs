using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Jamera.Properties;
using System.Text.RegularExpressions;

namespace Jamera.Messages
{

    static class SMS_Gateway
    {
        public static TcpClient client;
        public static Stream stream;
        public static Boolean Is_Busy = false;
        public static Boolean Is_Connected() {
            Boolean result= false;
            if (client != null)
            {
                if (client.Connected)
                {
                    result = true;
                    Console.WriteLine("is connected()=" + true);
                }
                else
                {
                    result = false;
                    Console.WriteLine("is connected()=" + false);
                }
            }
            else
            {
                result = false;
                Console.WriteLine("is connected()=" + false);
            }
            return result;
        }
        public static TcpClient Connect() {
            try {
                if (client != null) {
                    if (client.Connected)
                    {
                        client.Close();
                    }
                }
                client = null;
                string Server_Address = Settings.Default.wifi_ip_address;
                string Server_Port = Settings.Default.wifi_port;
                //check if settings stored ip address is null
                if (Server_Address != null && Server_Address != "") {
                    //check if server ip address contains . for valid ip string
                    if (Server_Address.Contains(".")) {
                        int ip_address_dot_counter=Server_Address.Count(s => s=='.');
                        //if string contains dot three time it means valid ip address like
                        //192.168.1.102
                        if (ip_address_dot_counter == 3) {
                            //check if settings port value is not empty
                            if (Server_Port != "" && Server_Port != null) {
                                //Check if given String contains only numeric values 
                                if (Regex.IsMatch(Server_Port, @"^\d+$"))
                                {
                                    int port=Convert.ToInt32(Server_Port);
                                    client = new TcpClient(Server_Address, port);
                                }
                            }
                        }
                    }
                }
            }
            catch (IOException ex) {
                client = null;
                Console.WriteLine(ex.ToString());
            }
            catch (NullReferenceException ex)
            {
                client = null;
                Console.WriteLine(ex.ToString());
            }
            catch (SocketException ex)
            {
                 client = null;
                Console.WriteLine(ex.ToString());
            }
            return client;
        }
        public static int Send(String String_To_Send) {
            int result = -3;
            Is_Busy = true;
            try
            {
                if (client == null)
                {
                    Connect();
                }
                else if (!(client.Connected))
                {
                    Connect();
                }

                if (client.Connected) {
                    byte[] buf = new byte[6000];
                    buf = Encoding.UTF8.GetBytes(String_To_Send + "\n");
                    stream = client.GetStream();
                    stream.Write(buf, 0, String_To_Send.Length + 1);
                    byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                    int bytesRead = stream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                    String str = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                    string[] stringSeparators = new string[] { "\n" };
                    string[] lines = str.Split(stringSeparators, StringSplitOptions.None);
                    String res = lines[0];
                    result = Convert.ToInt32(res);
                    Console.WriteLine("Message Sent ...");
                    Is_Busy = false;
                    }
                }
                catch (FormatException ex)
                {
                Is_Busy = false;
                result = -2;
                Console.WriteLine(ex.ToString());
                }
                catch (IOException ex)
                {
                result = -2;
                Is_Busy = false;
                Console.WriteLine(ex.ToString());
                }
                catch (SocketException ex)
                {
                result = -2;
                Is_Busy = false;
                Console.WriteLine(ex.ToString());
                }
                catch (NullReferenceException ex)
                {
                result = -2;
                Is_Busy = false;
                Console.WriteLine(ex.ToString());
                }
            return result;
        }
    }

}
