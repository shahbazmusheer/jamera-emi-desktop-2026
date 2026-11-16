using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Employees.Commissions
{
    internal class Item_Commission
    {
        public int Commission_Id { get; set; }
        public int Item_Id { get; set; }

        public string Item {  get; set; } = string.Empty;

        public Double Area_Manager { get; set; } = 0;
        public Double Senior_Secretary { get; set; } = 0;
        public Double Junior_Secretary { get; set; } = 0;
        public Double Salesman { get; set; } = 0;
        public String Description { get; set; }
    }
}
