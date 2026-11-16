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
using Jamera.Properties;

namespace Jamera.Application_Settings
{
    public partial class Trials : DevExpress.XtraEditors.XtraForm
    {
        Timer t = new Timer();
        int total_hrs = 56;
        int per_day_hours_var = 8;
        Boolean inner_check = false;
        public Trials()
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
        public Boolean is_valid()
        {
            if (Settings.Default.hr <= total_hrs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void startCounting()
        {
            if (Settings.Default.hr >= total_hrs)
            {
                t.Stop();
                MessageBox.Show("Sorry ! your trials are completed ! \n Register Your System Now", "Registration Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }

            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }
        private void t_Tick(Object Sender, EventArgs e)
        {

            if (Settings.Default.hr >= total_hrs)
            {
                t.Stop();
                MessageBox.Show("Sorry ! your trials are completed !");
                Application.Exit();
            }

            String f_sec, f_min, f_hr;

            if (Settings.Default.hr == 0 && Settings.Default.min == 0 && Settings.Default.sec == 0 && inner_check == false)
            {
                inner_check = true;
            }
            else
            {

                if (Settings.Default.sec >= 59)
                {
                    Settings.Default.sec = 0;
                    Settings.Default.min += 1;
                    Settings.Default.Save();

                }
                else
                {
                    Settings.Default.sec += 1;
                    Settings.Default.Save();
                }

                if (Settings.Default.min >= 59)
                {
                    Settings.Default.min = 0;
                    Settings.Default.hr += 1;
                    Settings.Default.Save();
                }

                if (Settings.Default.sec >= 10)
                    f_sec = Settings.Default.sec.ToString();
                else
                {
                    f_sec = "0" + Settings.Default.sec.ToString();
                }

                if (Settings.Default.min >= 10)
                {
                    f_min = Settings.Default.min.ToString();
                }
                else
                {
                    f_min = "0" + Settings.Default.min.ToString();
                }

                if (Settings.Default.hr >= 10)
                {
                    f_hr = Settings.Default.hr.ToString();
                }
                else
                {
                    f_hr = "0" + Settings.Default.hr.ToString();
                }

                //timer_view.Text = f_hr + ":" + f_min + ":" + f_sec;

            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void continue_btn_Click(object sender, EventArgs e)
        {
            Login_Form lf = new Login_Form();
            this.startCounting();
            lf.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Trials_Load(object sender, EventArgs e)
        {
            continue_btn.Focus();
            int rem_hrs = total_hrs - Settings.Default.hr;
            rem_hours.Text = rem_hrs.ToString();
            avg_hours_per_day.Text = per_day_hours_var.ToString();
            double rem_days = rem_hrs / per_day_hours_var;
            days_remaining.Text = rem_days.ToString();
        }
    }
}