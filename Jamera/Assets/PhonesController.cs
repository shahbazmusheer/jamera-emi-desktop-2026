using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamera.Assets
{
    public class PhonesController
    {
        public String[] Get_Phone_Formates(String phone_no)
        {
            //It processes phone number into 6 different formates
            //Like [03061192596,0306-1192596,+92306-1192596,+923061192596,923061192596,92306-1192596]
            //[0]:0306-1192596
            //[1]:03061192596
            //[2]:+92306-1192596
            //[3]:+923061192596
            //[4]:92306-1192596
            //[5]:923061192596

            String first_two_ch = null;
            String result = null;
            first_two_ch = phone_no.Substring(0, 2);
            if (first_two_ch == "03")
            {
                //Starts with 03
                if (phone_no.Contains("-"))
                {
                    //Including hyphone like 0306-11...
                    //0306-1192596
                    result = result + phone_no + ",";
                    //03061192596
                    result = result + phone_no.Replace("-", "") + ",";
                    //+92306-1192596
                    result = result + phone_no.Remove(0, 1).Insert(0, "+92") + ",";
                    //+923061192596
                    result = result + phone_no.Remove(0, 1).Insert(0, "+92").Replace("-", "") + ",";
                    //92306-1192596
                    result = result + phone_no.Remove(0, 1).Insert(0, "92") + ",";
                    //923061192596
                    result = result + phone_no.Remove(0, 1).Insert(0, "92").Replace("-", "");
                }
                else
                {
                    //Without hyphone like 030611...
                    String Phone_With_Hyphone = null;
                    Phone_With_Hyphone = phone_no.Insert(4, "-");
                    //0306-1192596
                    result = result + Phone_With_Hyphone + ",";
                    //03061192596
                    result = result + Phone_With_Hyphone.Replace("-", "") + ",";
                    //+92306-1192596
                    result = result + Phone_With_Hyphone.Remove(0, 1).Insert(0, "+92") + ",";
                    //+923061192596
                    result = result + Phone_With_Hyphone.Remove(0, 1).Insert(0, "+92").Replace("-", "") + ",";
                    //92306-1192596
                    result = result + Phone_With_Hyphone.Remove(0, 1).Insert(0, "92") + ",";
                    //923061192596
                    result = result + Phone_With_Hyphone.Remove(0, 1).Insert(0, "92").Replace("-", "");

                }
            }
            else if (first_two_ch == "+9")
            {
                if (phone_no.Contains("-"))
                {
                    //Including hyphone like +92306-11...
                    String replaced_phone = phone_no.Remove(0, 3).Insert(0, "0");
                    //0306-1192596
                    result = result + replaced_phone + ",";
                    //03061192596
                    result = result + replaced_phone.Replace("-", "") + ",";
                    //+92306-1192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "+92") + ",";
                    //+923061192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "+92").Replace("-", "") + ",";
                    //92306-1192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "92") + ",";
                    //923061192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "92").Replace("-", "");
                }
                else
                {
                    //Including hyphone like +9230611...
                    String replaced_phone = phone_no.Remove(0, 3).Insert(0, "0").Insert(4, "-");
                    //0306-1192596
                    result = result + replaced_phone + ",";
                    //03061192596
                    result = result + replaced_phone.Replace("-", "") + ",";
                    //+92306-1192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "+92") + ",";
                    //+923061192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "+92").Replace("-", "") + ",";
                    //92306-1192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "92") + ",";
                    //923061192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "92").Replace("-", "");
                }
            }
            else if (first_two_ch == "92")
            {
                if (phone_no.Contains("-"))
                {
                    //Including hyphone like 92306-11...
                    String replaced_phone = phone_no.Remove(0, 2).Insert(0, "0");
                    //0306-1192596
                    result = result + replaced_phone + ",";
                    //03061192596
                    result = result + replaced_phone.Replace("-", "") + ",";
                    //+92306-1192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "+92") + ",";
                    //+923061192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "+92").Replace("-", "") + ",";
                    //92306-1192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "92") + ",";
                    //923061192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "92").Replace("-", "");
                }
                else
                {
                    //Including hyphone like +9230611...
                    String replaced_phone = phone_no.Remove(0, 2).Insert(0, "0").Insert(4, "-");
                    //0306-1192596
                    result = result + replaced_phone + ",";
                    //03061192596
                    result = result + replaced_phone.Replace("-", "") + ",";
                    //+92306-1192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "+92") + ",";
                    //+923061192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "+92").Replace("-", "") + ",";
                    //92306-1192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "92") + ",";
                    //923061192596
                    result = result + replaced_phone.Remove(0, 1).Insert(0, "92").Replace("-", "");
                }
            }
            return result.Split(',');
        }
    }
}
