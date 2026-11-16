using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Items
{
    public class Item
    {
        public int Id;
        public String Name = null;
        public String Unicode = null;
        public int Unit_Id;
        public int Model_Id;
        public String Unit_Name = null;
        public String Model_Name = null;
        public Double Packing = 0;
        public Double Quantity = 0;
        public int Group_id;
        public String Group_Name = null;
        public int Category_Id;
        public String Category_Name = null;
        public int Manufacturer_Id;
        public String Manufacturer_Name = null;
        public int Default_Vendor_id;
        public String Default_Vendor_Name = null;
        public Double Purchase_Rate = 0;
        public Double Advance_Price = 0;
        public Double Monthly_EMI_Price = 0;
        public Double Cash_Rate = 0;
        public Double No_Of_Installments = 0;
        public Double Sale_Rate = 0;
        public Double Unit_Cost = 0;
        public Double Sale_Discount = 0;
        public Double Reorder_Level = 0;
        public Double Quantity_Demand = 0;
        public bool Is_Expireable = false;
        public Double GST_Percent = 0;
        public bool Is_Imported = false;
        public bool Is_Active = false;
        public int Rack_Id;
        public String Rack_Name = null;
        public Double Location = 0;
        public int Purchase_Id = -1;
    }
}
