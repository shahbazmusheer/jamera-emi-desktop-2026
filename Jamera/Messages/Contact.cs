using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Messages
{
    public class Contact
    {
        public int Member_Id { get; set; } 
        public int Store_Id { get; set; } 
        public int Group_Id { get; set; }
        public String Name { get; set; } = null;
        public String Office_Phone { get; set; } = null;
        public String Home_Phone { get; set; } = null;
        public String Address { get; set; } = null;
        public String Remarks { get; set; } = null;
    }
}

