using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Employees
{
    public class Employee
    {
        public int Emp_Id { get; set; }
        public int Emp_Store_Id { get; set; }

        public String Emp_Store_Area_Code { get; set; }
        public String Emp_Store_Name { get; set; }
        public String Emp_Role_Name { get; set; }
        public int Emp_Role_Id { get; set; }
        public String Emp_Name { get; set; } = null;
        public String Pay_Date { get; set; } = null;
        public String Emp_Phone { get; set; } = null;
        public String Emp_Address { get; set; } = null;
        public Double Emp_Advance_Limit { get; set; } = -1;
        public Double Emp_Basic_Salary { get; set; } = -1;
        public Double Balance { get; set; } = 0;
    }
}
