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

namespace Jamera.Purchases
{
    public partial class Preview_Bill : DevExpress.XtraEditors.XtraForm
    {
        Print_Bill print_bill;
        public Preview_Bill(int bill_id)
        {
            InitializeComponent();
            print_bill = new Print_Bill(bill_id,"",null);
            print_bill.RequestParameters = false;
            documentViewer1.DocumentSource = print_bill;
            print_bill.CreateDocument();

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
    }
}