using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Jamera.Employees
{
    public class Employees_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Employees_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }
        public int Store(String DATE, int STORE_ID,int ROLE_ID,String NAME,String ADDRESS,String PHONE,Double ADVANCE_LIMIT=-1,Double basic_salary=-1)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO accounts(pay_date,store_id,role_id,name,address,phone,advance_limit,basic_salary,account_group_id,account_group,account_type,balance,created_type) values(@pay_date,@store_id,@role_id,@name,@address,@phone,@advance_limit,@basic_salary,'1009','Employees','DR','0','Custom') SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@pay_date", DATE);
                cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@phone", PHONE);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                if(ADVANCE_LIMIT > 0)
                {
                    cmd.Parameters.AddWithValue("@advance_limit", ADVANCE_LIMIT);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@advance_limit", DBNull.Value);
                }
                if(basic_salary > 0)
                {
                    cmd.Parameters.AddWithValue("@basic_salary", basic_salary);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@basic_salary", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@role_id",ROLE_ID);
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }
        public bool Employee_Exists(String NAME)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT name from accounts where name='"+NAME+"'", conn))
            {
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    if(Convert.ToString(obj) == NAME)
                    {
                        result = true;
                    }
                }
            }
            conn.Close();
            return result;
        }
        public bool Employee_Exists(int ID,String NAME)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT name from accounts where id !='"+ID+"' and name='" + NAME + "'", conn))
            {
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    if (Convert.ToString(obj) == NAME)
                    {
                        result = true;
                    }
                }
            }
            conn.Close();
            return result;
        }
        public bool Employee_Delete(int ID)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE from accounts where id ='" + ID + "'", conn))
            {
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }
        public bool Update(int ID,String DATE, int STORE_ID, int ROLE_ID, String NAME, String ADDRESS, String PHONE, Double ADVANCE_LIMIT = -1, Double basic_salary = -1)
        {
            bool result =false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE accounts SET pay_date=@pay_date,store_id=@store_id,role_id=@role_id,name=@name,address=@address,phone=@phone,advance_limit=@advance_limit,basic_salary=@basic_salary WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@pay_date", DATE);
                cmd.Parameters.AddWithValue("@store_id", STORE_ID);
                cmd.Parameters.AddWithValue("@name", NAME);
                cmd.Parameters.AddWithValue("@phone", PHONE);
                cmd.Parameters.AddWithValue("@address", ADDRESS);
                if (ADVANCE_LIMIT > 0)
                {
                    cmd.Parameters.AddWithValue("@advance_limit", ADVANCE_LIMIT);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@advance_limit", DBNull.Value);
                }
                if (basic_salary > 0)
                {
                    cmd.Parameters.AddWithValue("@basic_salary", basic_salary);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@basic_salary", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@role_id", ROLE_ID);
                Object obj = cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }

        public int Pay_Salary(int EMP_ID,String EMP_NAME,DateTime DATE,Double BASIC_SALARY,Double BONUS,Double COMMISSION,Double ADVANCE_PAID,Double OTHER_DEDUCTIONS,Double NET_SALARY,String REMARKS)
        {

            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO employees_salaries(account_id,basic_salary,bonus,commission,advance_payment,other_deductions,net_salary,pay_date,remarks) values(@account_id,@basic_salary,@bonus,@commission,@advance_payment,@other_deductions,@net_salary,@pay_date,@remarks) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@pay_date", DATE.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@account_id", EMP_ID);
                cmd.Parameters.AddWithValue("@basic_salary", BASIC_SALARY);
                cmd.Parameters.AddWithValue("@bonus", BONUS);
                cmd.Parameters.AddWithValue("@commission", COMMISSION);
                cmd.Parameters.AddWithValue("@advance_payment", ADVANCE_PAID);
                cmd.Parameters.AddWithValue("@other_deductions", OTHER_DEDUCTIONS);
                cmd.Parameters.AddWithValue("@net_salary", NET_SALARY);
                cmd.Parameters.AddWithValue("@remarks", REMARKS);
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    Accounts.Accounts_Controller accounts_controller = new Accounts.Accounts_Controller();
                    Accounts.Account cash_account = new Accounts.Account();
                    Accounts.Account salaries_account = new Accounts.Account();
                    cash_account = accounts_controller.Get_Account(2001);
                    salaries_account = accounts_controller.Get_Account(2018);
                    Accounts.Account employee_account = new Accounts.Account();
                    employee_account = accounts_controller.Get_Account(EMP_ID);

                    //credit cash account
                    accounts_controller.Insert_Account_Transaction(cash_account.Account_Id, cash_account.Account_Name, cash_account.Account_Type, cash_account.Account_Nature, "Employee Payment",REMARKS, 0, 0, 0, NET_SALARY, (cash_account.Balance - (NET_SALARY + ADVANCE_PAID)), DATE);

                    //Debit Employee Account
                    accounts_controller.Insert_Account_Transaction(employee_account.Account_Id, employee_account.Account_Name, employee_account.Account_Type, employee_account.Account_Nature, "Employee Payment", REMARKS, 0, 0, NET_SALARY, 0, (employee_account.Balance + (NET_SALARY + ADVANCE_PAID)), DATE);

                    //--------------------
                    employee_account = null;
                    employee_account = accounts_controller.Get_Account(EMP_ID);
                    accounts_controller.Insert_Account_Transaction(employee_account.Account_Id, employee_account.Account_Name, employee_account.Account_Type, employee_account.Account_Nature, "Employee Payment", REMARKS, 0, 0, 0,NET_SALARY, (employee_account.Balance - (NET_SALARY + ADVANCE_PAID)), DATE);
                    accounts_controller.Insert_Account_Transaction(salaries_account.Account_Id,salaries_account.Account_Name,salaries_account.Account_Type,salaries_account.Account_Nature, "Employee Payment", REMARKS, 0, 0,NET_SALARY,0, (salaries_account.Balance + (NET_SALARY + ADVANCE_PAID )), DATE);
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }

        public Employee Get_Employee(int Emp_Id)
        {
            Employee employee= new Employee();
            conn.Open();
            String query = @"SELECT TOP 1 accounts.id as 'ID',accounts.name as 'Name',accounts.phone as 'Phone',accounts.address as 'Address',role_id,store_id,basic_salary,advance_limit,pay_date,balance from accounts left join account_groups as ac_gps on accounts.account_group_id=ac_gps.id WHERE accounts.id='" + Emp_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employee.Emp_Id = Emp_Id;
                employee.Emp_Name = reader["Name"].ToString();
                employee.Emp_Phone = reader["Phone"].ToString();
                employee.Emp_Address = reader["Address"].ToString();
                employee.Emp_Role_Id = Convert.ToInt32(reader["role_id"]);
                employee.Pay_Date= Convert.ToString(reader["pay_date"]);
                if(reader["store_id"] != DBNull.Value)
                {
                    employee.Emp_Store_Id = Convert.ToInt32(reader["store_id"]);
                }
                if(reader["basic_salary"] != DBNull.Value)
                {
                    employee.Emp_Basic_Salary = Convert.ToDouble(reader["basic_salary"]);
                }
                else
                {
                    employee.Emp_Basic_Salary = 0;
                }
                if(reader["advance_limit"] != DBNull.Value)
                {
                    employee.Emp_Advance_Limit = Convert.ToDouble(reader["advance_limit"]);
                }
                else
                {
                    employee.Emp_Advance_Limit = 0;
                }
                if(reader["balance"] != DBNull.Value)
                {
                    employee.Balance = Convert.ToDouble(reader["balance"]);
                }
                else
                {
                    employee.Balance = 0;
                }
            }
            reader.Close();
            conn.Close();
            return employee;
        }
    }
}
