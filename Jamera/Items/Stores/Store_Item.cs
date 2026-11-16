using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Items.Stores
{
    public class Store_Item
    {
        public int Store_Id { get; set; }
        public int Store_Item_Id { get; set; }
        public int Item_Id { get; set; }
        public int Model_Id { get; set; }
        public int Stock_Transaction_Id { get; set; }
        public int Purchase_Id { get; set; }
        public String Name { get; set; }
        public int Purchase_Item_Id { get; set; }
        public Double Purchase_Rate { get; set; }
        public Double Sale_Rate { get; set; }
        public Double Stock_in { get; set; }
        public Double Sales_Return { get; set; }
        public Double Sold_out { get; set; }
        public Double Returned_Items { get; set; }
        public Double Transfered_Items { get; set; }

    }
}
