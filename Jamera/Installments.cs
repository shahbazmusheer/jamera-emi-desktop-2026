using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jamera.Properties;

namespace Jamera
{
    class Installments
    {
        public Boolean Is_Valid()
        {
            DateTime today = DateTime.Now;
            int month = today.Month;
            if (Settings.Default.paid_month == month)
            {
                return true;
            }else if(Settings.Default.paid_month < month && today.Day < 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
