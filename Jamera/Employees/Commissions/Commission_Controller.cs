using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Employees.Commissions
{
    internal class Commission_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Commission_Controller() {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }

        public int Store(int ITEM_ID, double AREA_MANAGER, double SENIOR_SECRETARY, double JUNIOR_SECRETARY, double SALESMAN, String DESCRIPTION)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO commissions(item_id,area_manager, senior_secretary, junior_secretary, salesman, description) values(@item_id, @area_manager, @senior_secretary, @junior_secretary, @salesman, @description) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@item_id", ITEM_ID);
                cmd.Parameters.AddWithValue("@area_manager", AREA_MANAGER);
                cmd.Parameters.AddWithValue("@senior_secretary", SENIOR_SECRETARY);
                cmd.Parameters.AddWithValue("@junior_secretary", JUNIOR_SECRETARY);
                cmd.Parameters.AddWithValue("@description", DESCRIPTION);
                if (SALESMAN > 0)
                {
                    cmd.Parameters.AddWithValue("@salesman", SALESMAN);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@salesman", 0);
                }
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }
        public bool Commission_Item_Exists(int ITEM_ID)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT id from commissions where item_id='" + ITEM_ID + "'", conn))
            {
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    if (Convert.ToInt32(obj) == ITEM_ID)
                    {
                        result = true;
                    }
                }
            }
            conn.Close();
            return result;
        }
        public bool Commission_Item_Exists(int ID, int ITEM_ID)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT item_id from commissions where id !='" + ID + "' and item_id='" + ITEM_ID + "'", conn))
            {
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value)
                {
                    if (Convert.ToInt32(obj) == ITEM_ID)
                    {
                        result = true;
                    }
                }
            }
            conn.Close();
            return result;
        }
        public bool Item_Commission_Delete(int ID)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE from commissions where id ='" + ID + "'", conn))
            {
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }
        public bool Update(int ID, int ITEM_ID, double AREA_MANAGER, double SENIOR_SECRETARY, double JUNIOR_SECRETARY, double SALESMAN, String DESCRIPTION)
        {
            bool result = false;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE commissions SET item_id=@item_id,area_manager=@area_manager,senior_secretary=@senior_secretary,junior_secretary=@junior_secretary,salesman=@salesman,description=@description WHERE id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@item_id", ITEM_ID);
                cmd.Parameters.AddWithValue("@area_manager", AREA_MANAGER);
                cmd.Parameters.AddWithValue("@senior_secretary", SENIOR_SECRETARY);
                cmd.Parameters.AddWithValue("@junior_secretary", JUNIOR_SECRETARY);
                cmd.Parameters.AddWithValue("@salesman", SALESMAN);
                cmd.Parameters.AddWithValue("@description", DESCRIPTION);
                Object obj = cmd.ExecuteScalar();
                cmd.ExecuteNonQuery();
                result = true;
            }
            conn.Close();
            return result;
        }

        public int Pay_Salary(int EMP_ID, String EMP_NAME, DateTime DATE, Double BASIC_SALARY, Double BONUS, Double COMMISSION, Double ADVANCE_PAID, Double OTHER_DEDUCTIONS, Double NET_SALARY, String REMARKS)
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
                    accounts_controller.Insert_Account_Transaction(cash_account.Account_Id, cash_account.Account_Name, cash_account.Account_Type, cash_account.Account_Nature, "Employee Payment", REMARKS, 0, 0, 0, NET_SALARY, (cash_account.Balance - (NET_SALARY + ADVANCE_PAID)), DATE);

                    //Debit Employee Account
                    accounts_controller.Insert_Account_Transaction(employee_account.Account_Id, employee_account.Account_Name, employee_account.Account_Type, employee_account.Account_Nature, "Employee Payment", REMARKS, 0, 0, NET_SALARY, 0, (employee_account.Balance + (NET_SALARY + ADVANCE_PAID)), DATE);

                    //--------------------
                    employee_account = null;
                    employee_account = accounts_controller.Get_Account(EMP_ID);
                    accounts_controller.Insert_Account_Transaction(employee_account.Account_Id, employee_account.Account_Name, employee_account.Account_Type, employee_account.Account_Nature, "Employee Payment", REMARKS, 0, 0, 0, NET_SALARY, (employee_account.Balance - (NET_SALARY + ADVANCE_PAID)), DATE);
                    accounts_controller.Insert_Account_Transaction(salaries_account.Account_Id, salaries_account.Account_Name, salaries_account.Account_Type, salaries_account.Account_Nature, "Employee Payment", REMARKS, 0, 0, NET_SALARY, 0, (salaries_account.Balance + (NET_SALARY + ADVANCE_PAID)), DATE);
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            return result;
        }

        public Item_Commission Get_Item_Commission(int Commission_Id)
        {
            Item_Commission item_Commission = new Item_Commission();
            conn.Open();
            String query = @"SELECT TOP 1 commissions.id as 'Code', items.id as 'Item.Code', items.name as 'Item', commissions.area_manager as 'Area Manager', commissions.senior_secretary as 'Senior Secretary', commissions.junior_secretary as 'Junior Secretary', commissions.salesman as 'Salesman', commissions.description as 'Description' FROM dbo.commissions AS commissions LEFT JOIN dbo.items AS items ON items.id = commissions.item_id WHERE commissions.id='" + Commission_Id + "'"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                item_Commission.Commission_Id = Commission_Id;
                item_Commission.Item_Id = Convert.ToInt32(reader["Item.Code"]);
                item_Commission.Item = reader["Item"].ToString();
                item_Commission.Area_Manager = Convert.ToDouble(reader["Area Manager"]);
                item_Commission.Senior_Secretary = Convert.ToDouble(reader["Senior Secretary"]);
                item_Commission.Junior_Secretary = Convert.ToDouble(reader["Junior Secretary"]);
                if (reader["Salesman"].ToString() != "") {
                    item_Commission.Salesman = Convert.ToDouble(reader["Salesman"]);
                }
                else
                {
                    item_Commission.Salesman = 0;
                }
                    item_Commission.Description = reader["Description"].ToString();
            }
            reader.Close();
            conn.Close();
            return item_Commission;
        }
    }
}
