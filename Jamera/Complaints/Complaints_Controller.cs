using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraEditors;

namespace Jamera.Complaints
{
    public class Complaints_Controller
    {
        SqlConnection conn = new SqlConnection();
        public Complaints_Controller()
        {
            DatabaseHandler db_handler = new DatabaseHandler();
            this.conn = db_handler.GetDatabseConnection();
        }
        public int Store(int AGGREMENT_Ref_No,int ELECTRITION_ID,DateTime DATE,String STATUS,String REMARKS)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO complaints(ref_no,electrition_id,date,status) values(@ref_no,@electrition_id,@date,@status) SELECT CAST(scope_identity() AS int)", conn))
            {
                //date,status
                cmd.Parameters.AddWithValue("@ref_no", AGGREMENT_Ref_No);
                cmd.Parameters.AddWithValue("@electrition_id", ELECTRITION_ID);
                cmd.Parameters.AddWithValue("@date", DATE.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@status", STATUS);
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                    conn.Close();
                    Store_Complaint_Status(result,DATE,STATUS,REMARKS);
                }
            }
            return result;
        }

        public DataTable Get_Status_Updates_Table(int Complaint_Id)
        {
            DataTable status_updates_table = new DataTable();
            conn.Open();
            String query = @"SELECT date as 'Date',status as 'Status',remarks as 'Remarks' from complaint_updates WHERE complaint_id='"+Complaint_Id+"';";
            SqlDataAdapter adp = new SqlDataAdapter(query,conn);
            adp.Fill(status_updates_table);
            conn.Close();
            return status_updates_table;
        }

        public void Update_Complaint_Satus(int Complaint_Id,String Status)
        {
            conn.Open();
            String query = @"update complaints set status='"+Status+"'  WHERE id='" + Complaint_Id + "';";
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public int Store_Complaint_Status(int COMPLAINT_ID,DateTime DATE, String STATUS, String REMARKS)
        {
            int result = -1;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO complaint_updates(complaint_id,date,remarks,status) values(@complaint_id,@date,@remarks,@status) SELECT CAST(scope_identity() AS int)", conn))
            {
                cmd.Parameters.AddWithValue("@complaint_id", COMPLAINT_ID);
                cmd.Parameters.AddWithValue("@date", DATE.ToString("dd-MM-yyyy"));
                cmd.Parameters.AddWithValue("@status", STATUS);
                cmd.Parameters.AddWithValue("@remarks", REMARKS);
                object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value || obj != null)
                {
                    result = Convert.ToInt32(obj);
                }
            }
            conn.Close();
            Update_Complaint_Satus(COMPLAINT_ID, STATUS);
            return result;
        }

        public Complaint Get_Complain_Updates(int Complaint_Id)
        {
            conn.Open();
            Complaint complaint = new Complaint();
            String query = "SELECT cmp.id as 'DATE' FROM complaint_updates as cmp left join accounts as elec on cmp.electrition_id=elec.id left join aggrements as ag on cmp.aggrement_id=ag.id left join accounts as customers on ag.customer_id=customers.id left join stores on stores.id=customers.store_id WHERE cmp.id='" + Complaint_Id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                complaint.Complaint_Id = Convert.ToInt32(reader["Code"]);
                complaint.Store_Id = Convert.ToInt32(reader["Store Id"]);
                complaint.Date = Convert.ToString(reader["Date"]);
                complaint.Ref_No = Convert.ToInt32(reader["ref_no"]);
                complaint.Customer_Id = Convert.ToInt32(reader["Customer Code"]);
                complaint.Customer_Name = Convert.ToString(reader["Customer"]);
                complaint.Electrition_Id = Convert.ToInt32(reader["Election Code"]);
                complaint.Customer_Name = Convert.ToString(reader["Electrition"]);
                complaint.Status = Convert.ToString(reader["Status"]);

            }
            reader.Close();
            conn.Close();



            return complaint;
        }

        public Complaint Get_Complaint(int Complaint_Id)
        {
            conn.Open();
            Complaint complaint = new Complaint();
            String query = "SELECT cmp.id as 'Code',stores.id as 'Store Id',cmp.date as 'Date',cmp.ref_no,customers.id as 'Customer Code',customers.name as 'Customer',elec.id as 'Election Code',elec.name as 'Electrition',cmp.status as 'Status' FROM complaints as cmp left join accounts as elec on cmp.electrition_id=elec.id left join aggrements as ag on cmp.ref_no=ag.ref_no left join accounts as customers on ag.customer_id=customers.id left join stores on stores.id=customers.store_id WHERE cmp.id='"+Complaint_Id+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                complaint.Complaint_Id = Convert.ToInt32(reader["Code"]);
                complaint.Store_Id= Convert.ToInt32(reader["Store Id"]);
                complaint.Date = Convert.ToString(reader["Date"]);
                complaint.Ref_No= Convert.ToInt32(reader["ref_no"]);
                complaint.Customer_Id = Convert.ToInt32(reader["Customer Code"]);
                complaint.Customer_Name = Convert.ToString(reader["Customer"]);
                complaint.Electrition_Id = Convert.ToInt32(reader["Election Code"]);
                complaint.Customer_Name = Convert.ToString(reader["Electrition"]);
                complaint.Status = Convert.ToString(reader["Status"]);
            }
            reader.Close();
            conn.Close();
            complaint.status_updates_table = Get_Status_Updates_Table(Complaint_Id);
            return complaint;
        }

    }
}
