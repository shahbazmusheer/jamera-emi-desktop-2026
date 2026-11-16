using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Jamera.Purchases
{
    public class Purchase_Item
    {
        public int Purchase_Item_Id { get; set; }
        public int Purchase_Id { get; set; }
        public int Item_Id { get; set; }
        public Double Purchase_Rate { get; set; }
        public Double Discount_RS { get; set; }
        public Double Discount_Percent { get; set; }
        public Double Sale_Rate { get; set; }
        public Double Stock_In { get; set; }
        public Double Stock_Out { get; set; }
        public Double Returned_Items { get; set; }
    }
}

