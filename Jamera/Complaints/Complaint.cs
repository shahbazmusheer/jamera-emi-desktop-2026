using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Jamera.Complaints
{
    public class Complaint
    {
        public int Complaint_Id { get; set; }
        public DataTable status_updates_table { get; set; }
        public int Store_Id { get; set; }
        public String Date { get; set; }
        public String Area_Code { get; set; }
        public int Electrition_Id { get; set; }
        public String Electrition_Name { get; set; }
        public int Customer_Id { get; set; }
        public String Customer_Name { get; set; }
        public String Status { get; set; }
        public int Aggrement_Id { get; set; }
        public int Ref_No { get; set; }
    }
}
