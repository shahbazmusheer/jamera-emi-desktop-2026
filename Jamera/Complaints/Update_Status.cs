using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using Jamera.Properties;

namespace Jamera.Complaints
{
    public partial class Update_Status : DevExpress.XtraEditors.XtraForm
    {
        int complaint_id=-1;
        public Update_Status(int complaint_id,String status)
        {
            InitializeComponent();
            date_picker.EditValue = DateTime.Now;
            this.complaint_id = complaint_id;
            status_cmb.Text = status;

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
        }
        public void Save()
        {
            if(date_picker.Text == "")
            {
                XtraMessageBox.Show("Please select date !");
                date_picker.ShowPopup();
                date_picker.Focus();
            }
            else if(status_cmb.Text == "")
            {
                XtraMessageBox.Show("Please select status !");
                status_cmb.ShowPopup();
                status_cmb.Focus();
            }
            else
            {
                Complaints_Controller complaints_controller = new Complaints_Controller();
                if(complaints_controller.Store_Complaint_Status(this.complaint_id,Convert.ToDateTime(date_picker.Text),status_cmb.Text,description_inp.Text) > 0)
                {
                    this.Close();
                }
            }
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Update_Status_Load(object sender, EventArgs e)
        {

        }
    }
}