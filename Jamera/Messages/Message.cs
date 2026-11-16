using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Messages
{
    public class Message
    {
        public String RECIEVER_NUMBER { get; set; } = null;
        public int Message_Id { get; set; }
        public int Store_Id { get; set; }
        public String Message_Type { get; set; } = "English";
        public String Group { get; set; } = null;
        public String RECIEVER_NAME { get; set; } = null;
        public String Message_Text { get; set; } = null;
        //EMI MESSAGES
        public String Message_Status { get; set; } = null;
        public String SMS_Gateway { get; set; } = null;
        public String Message_Date { get; set; } = null;
        public String Status { get; set; } = null;
        public int ACCOUNT_ID { get; set; }
    }
}
