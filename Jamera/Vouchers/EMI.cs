using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Vouchers
{
    public class EMI
    {
        public int dueId { get; set; }
        public DateTime dueDate { get; set; }
        public Double dueAmount { get; set; }
        public int emiNo { get; set; }
        public DateTime recDate { get; set; }
        public double recAmount { get; set; }
        public Double Balance { get; set; }
        public int isReturnFixed { get; set; }
        public String Status { get; set; }
        public String Remarks { get; set; }
    }
}
