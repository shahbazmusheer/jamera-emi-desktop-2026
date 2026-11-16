using Jamera.Aggrements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Collections
{
    public class VoucherCollection
    {
        public VoucherCollection() { }

        public DataTable RecieptsTable()
        {
            DataTable receiptsDatatable = new DataTable();
            receiptsDatatable.Columns.Add("Sr.No", typeof(Int32));
            receiptsDatatable.Columns.Add("EMI No", typeof(Int32));
            receiptsDatatable.Columns.Add("Due Amount", typeof(Double));
            receiptsDatatable.Columns.Add("Due Date", typeof(String));
            receiptsDatatable.Columns.Add("Status", typeof(String));
            receiptsDatatable.Columns.Add("Is Return Fixed", typeof(String));
            receiptsDatatable.Columns.Add("Is Deleted Row", typeof(Int32));
            receiptsDatatable.Columns.Add("Receipt Date", typeof(String));
            receiptsDatatable.Columns.Add("Received Amount", typeof(Double));
            receiptsDatatable.Columns.Add("Balance", typeof(Double));
            receiptsDatatable.Columns.Add("Remarks", typeof(String));
            return receiptsDatatable;
        }

        public String ReceiptsQueryString(int agreementId)
        {
            String query = @"SELECT ROW_NUMBER() OVER (ORDER BY CONVERT(datetime, emi_date,105) ASC) AS 'Sr.No', id as 'Code', emi_no as 'EMI No',emi_amount as 'Due Amount',emi_date as 'Due Date', status as 'Status', is_return_fixed as 'Is Return Fixed', paid_date as 'Receipt Date', paid_amount as 'Received Amount', balance as 'Balance', remarks as 'Remarks' from aggrement_dues WHERE aggrement_id='" + agreementId + "' ORDER BY balance DESC,CONVERT(datetime, emi_date,105) ASC, is_return_fixed DESC ";
            return query;
        }

        public String PaidReceiptsQueryString(int agreementId)
        {
            String query = @"SELECT ROW_NUMBER() OVER (ORDER BY CONVERT(datetime, emi_date,105) ASC) AS 'Sr.No', emi_no as 'EMI No', status as 'Status', is_return_fixed as 'Is Return Fixed',emi_amount as 'Due Amount',emi_date as 'Due Date', paid_date as 'Receipt Date', paid_amount as 'Received Amount', balance as 'Balance', remarks as 'Remarks' from aggrement_dues WHERE aggrement_id='" + agreementId + "' AND (paid_amount > 0 OR is_return_fixed = 1) ORDER BY CONVERT(datetime, emi_date,105) ASC, is_return_fixed DESC ";
            return query;
        }

        public List<String> ReceiptStatusItems()
        {
            List<String> items = new List<String>();
            items.Add("Normal");
            items.Add("Short List");
            items.Add("Skipped");
            items.Add("Return Issue");
            items.Add("Clearance Required");
            items.Add("Discount Given");
            return items;
        }

        public DataRow LoadAdvanceRow(DataRow newRow,  string DueDate, string DueAmount, string ReceiptDate, string ReceivedAmount, string EMINo, double Balance, string Remarks, int index)
        {
            newRow["Sr.No"] = 0;
            newRow["EMI No"] = EMINo;
            newRow["Due Amount"] = DueAmount;
            newRow["Due Date"] = DueDate;
            newRow["Status"] = "Normal";
            newRow["Is Return Fixed"] = -1;
            newRow["Receipt Date"] = ReceiptDate;
            newRow["Received Amount"] = ReceivedAmount;
            newRow["Balance"] = Balance;
            newRow["Remarks"] = Remarks;
            return newRow;

        }
    }
}
