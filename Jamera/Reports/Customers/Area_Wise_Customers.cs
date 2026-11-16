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
using Jamera.Properties;
using System.IO;

namespace Jamera.Reports.Customers
{
    public partial class Area_Wise_Customers : DevExpress.XtraEditors.XtraForm
    {
        public Area_Wise_Customers()
        {
            InitializeComponent();

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

        private void Area_Wise_Customers_Load(object sender, EventArgs e)
        {

        }

        private void load_report_btn_Click(object sender, EventArgs e)
        {

        }

        private void print_report_btn_Click(object sender, EventArgs e)
        {

        }
    }
}