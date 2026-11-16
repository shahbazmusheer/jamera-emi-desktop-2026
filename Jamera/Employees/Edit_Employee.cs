using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Text.RegularExpressions;
using Jamera.Properties;

namespace Jamera.Employees
{
    public partial class Edit_Employee : DevExpress.XtraEditors.XtraForm
    {
        int employee_id = -1;
        Employee employee = new Employee();
        Employees_Controller employees_controller = new Employees_Controller();
        public Edit_Employee(int emp_id)
        {
            InitializeComponent();
            this.employee_id = emp_id;

            string icon_path = Settings.Default.company_icon;
            string img_name = Settings.Default.db_name;
            if (icon_path != "")
            {
                FileInfo image = new FileInfo(icon_path);
                if (image.Exists == true)
                {
                    this.Icon = new Icon(icon_path);
                }
            }
            else
            {
                string img_path = Environment.CurrentDirectory + @"\Icons\" + img_name + @".ico";
                FileInfo image = new FileInfo(img_path);
                if (image.Exists == true)
                {
                    this.Icon = new Icon(img_path);
                }
            }

            sqlDataSource1.Fill();

            Load_Data();
           
        }
        public void Load_Data()
        {
            employee = employees_controller.Get_Employee(employee_id);
            if(employee_id == 2020)
            {
                delete_btn.Enabled = false;
            }
            role_cmb.EditValue = employee.Emp_Role_Id;
            store_cmb.EditValue = employee.Emp_Store_Id;
            address_inp.Text = employee.Emp_Address;
            name_inp.Text = employee.Emp_Name;
            phone_inp.Text = employee.Emp_Phone;
            pay_date_cmb.Text = employee.Pay_Date;
            if (employee.Emp_Basic_Salary > 0)
            {
                basic_salary_inp.Text = employee.Emp_Basic_Salary.ToString();
            }
            if(employee.Emp_Advance_Limit > 0)
            {
                advance_payment_inp.Text = employee.Emp_Advance_Limit.ToString();
            }
            pay_date_cmb.Text = employee.Pay_Date;
        }
        private void Edit_Employee_Load(object sender, EventArgs e)
        {

        }

        private void Edit_Employee_Shown(object sender, EventArgs e)
        {
            store_cmb.Focus();
        }

        private void store_cmb_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void role_cmb_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void phone_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            phone_inp.Properties.MaxLength = 13;
            Char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 13 && ch != 8 && ch != 127 && ch != 45 && ch != 43)
            {
                e.Handled = true;
            }
            if (phone_inp.Text.StartsWith("+92", StringComparison.CurrentCulture) && phone_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{6}\-\d{7}");
                phone_inp.Properties.MaxLength = 14;
            }
            else if (phone_inp.Text.StartsWith("+92", StringComparison.CurrentCulture))
            {
                phone_inp.Properties.MaxLength = 13;
            }
            else if (phone_inp.Text.StartsWith("03", StringComparison.CurrentCulture) && phone_inp.Text.Contains("-"))
            {
                Regex r = new Regex(@"\d{4}\-\d{7}");
                phone_inp.Properties.MaxLength = 12;
            }
            else if (phone_inp.Text.StartsWith("03", StringComparison.CurrentCulture))
            {
                phone_inp.Properties.MaxLength = 11;
            }
            else if (phone_inp.Text.StartsWith("92", StringComparison.CurrentCulture) && phone_inp.Text.Contains("-"))
            {
                phone_inp.Properties.MaxLength = 13;
            }
            else if (phone_inp.Text.StartsWith("92", StringComparison.CurrentCulture))
            {
                phone_inp.Properties.MaxLength = 12;
            }

        }

        private void description_inp_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        public void Reset_Entries()
        {
            store_cmb.Text = null;
            name_inp.Text = null;
            basic_salary_inp.Text = null;
            address_inp.Text = null;
            phone_inp.Text = null;
            pay_date_cmb.Text = null;
            role_cmb.Text = null;
            advance_payment_inp.Text = null;
            store_cmb.Focus();

        }
        public void Update()
        {
            if (role_cmb.Text == "")
            {
                XtraMessageBox.Show("Please select role !");
                role_cmb.ShowPopup();
            }
            else if (name_inp.Text == "")
            {
                XtraMessageBox.Show("Please enter name of employee !");
                name_inp.Focus();
            }
            else if (pay_date_cmb.Text == "")
            {
                XtraMessageBox.Show("Please select pay date !");
                pay_date_cmb.Focus();
            }
            else
            {
                int store_id = -1;
                if(store_cmb.Text != "")
                {
                    store_id = Convert.ToInt32(store_cmb.EditValue);
                }
                Employees_Controller employees_controller = new Employees_Controller();
                bool emp_exists = employees_controller.Employee_Exists(this.employee_id,name_inp.Text);
                if (emp_exists == false)
                {
                    Double advance_payment_limit = 0;
                    Double basic_salary = 0;
                    if (basic_salary_inp.Text != "")
                    {
                        basic_salary = Convert.ToDouble(basic_salary_inp.Text);
                    }
                    if (advance_payment_inp.Text != "")
                    {
                        advance_payment_limit = Convert.ToDouble(advance_payment_inp.Text);
                    }
                    bool is_updated = employees_controller.Update(this.employee_id,pay_date_cmb.Text,store_id, Convert.ToInt32(role_cmb.EditValue), name_inp.Text, address_inp.Text, phone_inp.Text, advance_payment_limit, basic_salary);
                    if (is_updated ==true)
                    {
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Employee already exists !");
                    name_inp.Focus();
                }
            }
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            this.Update();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            Employees_Controller employees_controller = new Employees_Controller();
            bool is_deleted = employees_controller.Employee_Delete(this.employee_id);
            if(is_deleted == true)
            {
                this.Close();
            }
        }

        private void advance_payment_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;

            if (!(Char.IsDigit(ch) || ch == 13 || ch == 8 || ch == 46))
            {
                e.Handled = true;
            }
        }

        private void basic_salary_inp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;

            if (!(Char.IsDigit(ch) || ch == 13 || ch == 8 || ch == 46))
            {
                e.Handled = true;
            }
        }
    }
}