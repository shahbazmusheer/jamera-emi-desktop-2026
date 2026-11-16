using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Jamera.Items
{
    public class Stock_Transaction
    {
        public int Stock_Transaction_Id { get; set; }
        public int From_Store_Id { get; set; }
        public int To_Store_Id { get; set; }
        public String Name { get; set; }
        public String GatePassNo { get; set; }
        public String Date { get; set; }
        public String From_Area_Code { get; set; }
        public String To_Area_Code { get; set; }
        public String From_Store_Name { get; set; }
        public String To_Store_Name { get; set; }
        public String Remarks { get; set; }
        public DataTable Stock_Transaction_Items_Table { get; set; }
    }
}
