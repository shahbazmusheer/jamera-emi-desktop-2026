using System;
using System.Management;
using Jamera.Properties;

namespace Jamera
{
    class systemValidations
    {

        public String pre_baseboard_serial = "PCCKB001Y1XFO2";
        public String pre_window_serial = "00426-OEM-8992662-00010";

        public Boolean getValidations()
        {
            String baseboard_serial = "";
            String wind_serial = "";
            Boolean returnResult = false;

            ManagementObjectSearcher mos_baseboard = new ManagementObjectSearcher("SELECT * FROM win32_baseboard");
            ManagementObject mow = new ManagementObject("win32_OperatingSystem=@");
            wind_serial = mow["SerialNumber"].ToString();
            foreach(ManagementObject mob in mos_baseboard.Get())
            {
                baseboard_serial = mob["SerialNumber"].ToString();
            }

            if(baseboard_serial == pre_baseboard_serial && wind_serial == pre_window_serial || baseboard_serial == "2UA8440C0B" && wind_serial == "00426-292-0000007-85874" || baseboard_serial == "2UA812135J" && wind_serial == "00371-OEM-8992671-00008" || wind_serial == "00359-OEM-9818072-57150" || wind_serial == Settings.Default.OS_No && baseboard_serial ==Settings.Default.Baseboard_No)
            {
                returnResult = true;
            }
            else
            {
                returnResult = false;
            }          

            return returnResult;
        }

        public  Boolean is_valid()
        {
            if (this.getValidations())
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
