using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Accounts
{
    class Account
    {
        public int Account_Id { get; set; }
        public int Store_Id { get; set; }
        public int Account_Group_Id { get; set; }
        public int Age { get; set; }
        public String Account_Name { get; set; }
        public String Account_Type { get; set; }
        public String Account_Nature { get; set; }
        public String Account_Group_Name { get; set; }
        public String Phone { get; set; }
        public String Home_Phone { get; set; }
        public String Office_Phone { get; set; }
        public String Address { get; set; }
        public String Cast { get; set; }
        public String Father_Name { get; set; }
        public String Profession { get; set; }
        public String Id_Card_No { get; set; }
        public String Home_Address { get; set; }
        public String Business_Address { get; set; }
        public String Office_Address { get; set; }
        public String Permanent_Address { get; set; }
        public Double Balance { get; set; }
        public Double Opening_Debit { get; set; } = 0;
        public Double Opening_Credit { get; set; } = 0;
        public String Account_Remarks { get; set; } = null;
    }
}
