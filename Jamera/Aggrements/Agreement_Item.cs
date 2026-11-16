using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Aggrements
{
    public class Agreement_Item
    {
        public int Agreement_Item_Id { get; set;}
        public int Item_Id { get; set; }
        //here transaction_id=stock_transaction_Item_Id
        public int Stock_Transaction_Item_Id { get; set; }
        public int Purchase_Item_Id { get; set; }
        public Double Purchase_Rate { get; set; }
        public Double Sale_Rate { get; set; }
        public Double Disc_Percent { get; set; }
        public Double Disc_Rs { get; set; }
        public Double Sold_Quantity { get; set; }
        public Double Returned_Quantity { get; set; }
        public Double Defaulted_Quantity { get; set; }
        public Double Net_Total { get; set; }
    }
}
