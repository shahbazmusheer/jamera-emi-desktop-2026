using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Jamera.Items
{
    public class Stock_Returned
    {
        public int Stock_Return_Id { get; set; }
        public DateTime DATE { get; set; }
        public int Store_Id { get; set; }
        public String Store_Name { get; set; }
        public String Name { get; set; }
        public DataTable Stock_Return_Items_Table { get; set; }
        public String Description { get; set; }
    }
}
