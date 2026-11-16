using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Purchases
{
    public class Purchase
    {
        public int Purchase_ID { get; set; }
        public String Invoice_No { get; set; } = null;
        public String Purchase_Type { get; set; }
        public String Payment_Method { get; set; }
        public String Status { get; set; }
        public int Supplier_ID { get; set; }
        public int Expense_Paid_Ac_ID { get; set; }
        public DateTime Purchase_Date { get; set; }
        public String Remarks { get; set; } = null;
        public String Supplier_Name { get; set; } = null;
        public Double Fuel_Expense_Amount { get; set; } = 0;
        public Double Total_Discount_Percent { get; set; } = 0;
        public Double Total_Discount_RS { get; set; } = 0;
        public Double Net_Total { get; set; } = 0;

        public Double Paid { get; set; } = 0;

        public Double Balance { get; set; } = 0;
    }
}
