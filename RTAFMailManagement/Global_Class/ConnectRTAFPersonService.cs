using RTAFMailManagement.Class;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Global_Class
{
    public class ConnectRTAFPersonService
    {
        public static List<RTAF_DATA> getRTAFPersonData(string unit_code)
        {
            string user = ConfigurationManager.AppSettings["UserServicePersonRTAF"];
            string pass = ConfigurationManager.AppSettings["PassServicePersonRTAF"];
            string unitID = ConvertUnitId2String(unit_code); //ค่าid แต่ละกรม

            RTAFService.RTAFMail data = new RTAFService.RTAFMail
            {
                UseDefaultCredentials = true
            };

            // ค่าที่ web service ส่งมา ให้ 
            RTAFService.RTAFMailData[] resault = data.GetData(user, pass, unitID);

            List<RTAF_DATA> list_data = new List<RTAF_DATA>();

            for (int i = 0; i < resault.Length; i++)
            {
                RTAF_DATA person = new RTAF_DATA
                {
                    rtaf_person_IdGvm = resault[i].ID,
                    rtaf_person_IdCard = resault[i].PeopleID,

                    Rank = new Ranks
                    {
                        rank_Name = resault[i].RANK,
                        rank_Code = int.Parse(resault[i].RANKCODE)
                    },

                    rtaf_person_FirstName = resault[i].FIRSTNAME,
                    rtaf_person_LastName = resault[i].LASTNAME,

                    Unit = new Units
                    {
                        unit_Code = int.Parse(resault[i].UNITCODE),
                        unit_Name = resault[i].UNITNAME
                    },

                    rtaf_person_BirthDate = resault[i].BIRTHDAY.ToString(),

                    rtaf_person_Position = resault[i].POSITION,
                    status = resault[i].STATUS
                };

                list_data.Add(person);
            }

            return list_data;
        }

        public static string ConvertUnitId2String(string unit_code)
        {
            if (unit_code.Length == 1)
            {
                unit_code = "00" + unit_code;
            }
            else if (unit_code.Length == 2)
            {
                unit_code = "0" + unit_code;
            }

            return unit_code;
        }
    }
}