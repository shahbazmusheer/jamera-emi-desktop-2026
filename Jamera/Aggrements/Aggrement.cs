using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Jamera.Aggrements
{
    public class Aggrement
    {
        public String Date { get; set; }
        public int Customer_Id { get; set; }
        public String Ref_No { get; set; }
        public int Aggrement_Id { get; set; }
        //public int Stock_Transaction_Item_Id { get; set; }
        //public int Item_Id { get; set; }
        public int Guardian_Id { get; set; }
        public int Store_Id { get; set; }
        public String Store_Name { get; set; }
        //public Double Sale_Rate { get; set; }
        public Double Advance_Payment { get; set; }
        public Double Balance { get; set; }
        public Double Current_Balance { get; set; }
        public int No_Of_Installments { get; set; }
        public int EMI_No { get; set; }
        public Double First_EMI { get; set; }
        public Double Rest_EMI { get; set; }
        public Double Total_Amount { get; set; }
        public Double Sale_Return_Amount { get; set; }
        public String Start_Date { get; set; }
        public String Status { get; set; }
        public String Remarks { get; set; }
        public DataTable Aggrement_Dues_Table { get; set; }
        public DataTable Aggrement_Items_Table { get; set; }
        public DataTable Aggrement__Return_Items_Table { get; set; }
    }
}
