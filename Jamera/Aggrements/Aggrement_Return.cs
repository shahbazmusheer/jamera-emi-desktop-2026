using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Aggrements
{
    public class Aggrement_Return
    {
        public String Date { get; set; }
        public int Customer_Id { get; set; }
        public String Ref_No { get; set; }
        public int Aggrement_Id { get; set; }
        public int Aggrement_Return_Id { get; set; }
        //public int Stock_Transaction_Item_Id { get; set; }
        //public int Item_Id { get; set; }
        public int Guardian_Id { get; set; }
        public int Store_Id { get; set; }
        public String Store_Name { get; set; }
        //public Double Sale_Rate { get; set; }
        public Double Advance_Payment { get; set; }
        public Double Prev_Balance { get; set; }
        public Double New_Balance { get; set; }
        public Double Fee_Kept { get; set; }
        public int No_Of_Installments { get; set; }
        public int EMI_No { get; set; }
        public Double Aggrement_Total_Amount { get; set; }
        public Double Total_Returning_Amount { get; set; }
        public Double Total_Paid_Amount { get; set; }
        public Double Total_Remaining_Amount { get; set; }
        public Double Total_Amount { get; set; }
        public Double Sale_Return_Amount { get; set; }
        public String Start_Date { get; set; }
        public String Status { get; set; }
        public String Remarks { get; set; }
        public DataTable Aggrement_Return_Items_Table { get; set; }
    }
}
