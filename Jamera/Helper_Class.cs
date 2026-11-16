using DevExpress.XtraEditors;
using DevExpress.XtraEditors.TextEditController.Win32;
using Jamera.Properties;
using Jamera.Vouchers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jamera
{
    public class Helper_Class
    {
        Vouchers_Controller v_controller = new Vouchers_Controller();
        public bool IfEMINoExists(int emiNo, int storeId, DateTime date, bool shouldCheckInList = false, DataTable list = null, String listColumn = "EMI #", int FocusedRowHandle = -1)
        {
            // if EMI Existence Validation Check is false in Settings
            if(!Settings.Default.check_emi_existence) return false;
            
            
            // --- STEP 1: CHECK IF ISSUED ---
            // This checks the 'emi_vouchers' table for a range [start_serial to end_serial]
            int issuedVoucherId = v_controller.Get_Valid_Emi_Store_Serial(storeId, emiNo, date);
            if (issuedVoucherId <= 0)
            {
                DialogResult dr = XtraMessageBox.Show($"EMI Serial #{emiNo} has NOT been issued to this store. \nDo you want to assign the serial number?",
                    "Invalid Serial", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == DialogResult.Yes)
                {
                    Vouchers.Issue_EMI_Voucher form = new Vouchers.Issue_EMI_Voucher(date, storeId, emiNo);
                    form.ShowDialog();
                }
                return true;
            }

            // --- STEP 2: CHECK IF ALREADY USED (Database) ---
            // 1. Comprehensive Database Check
            string existenceMessage = v_controller.Get_EMI_Serial_Existence_Details(emiNo, storeId, date);

            if (!string.IsNullOrEmpty(existenceMessage))
            {
                // existenceMessage will be: "Serial exists in 'New Agreement' with Ref. No: AGG-101"
                
                if (XtraMessageBox.Show(existenceMessage+"\nDo you want to ignore this warning?", "Duplicate Serial", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    return false;
                else
                    return true;
            }

            // --- STEP 3: CHECK IF IN LOCAL CART ---
            if (shouldCheckInList)
            {
                if (Emi_Exists_In_Cart(emiNo, list, listColumn, FocusedRowHandle))
                {
                    if (XtraMessageBox.Show($"EMI Serial #{emiNo} is already in your current list.\nDo you want to ignore this warning?", "Duplicate in Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        return false;
                    else
                        return true;
                }
            }

            return false;
        }

        public bool Emi_Exists_In_Cart(int emiNo, DataTable list, String listColumn = "EMI #", int FocusedRowHandle = -1)
        {
            int i = 0;
            foreach (DataRow row in list.Rows)
            {
                string emi = row[listColumn].ToString();

                // Check if the cell is not null before converting
                if (emi != "")
                {
                    if (emiNo == Convert.ToInt32(emi))
                    {
                        if(FocusedRowHandle == -1 || (FocusedRowHandle > 0 && FocusedRowHandle != i))
                        {
                            return true;
                        }
                    }
                }
                i++;
            }
            return false;
        }

        public bool validateRefNo(string refNo)
        {
            if (refNo == "" || !refNo.Contains("-") || refNo.Split('-').Length < 3)
            {
                XtraMessageBox.Show("Please enter a valid Ref.No in the format 'XXX-XXX-XX'!");
                return false;
            }

            return true;
        }
    }
}
