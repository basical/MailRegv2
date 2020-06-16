using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Class
{
    public class RTAF_DATA
    {
        public long rtaf_person_id { get; set; }
        public string rtaf_person_IdCard { get; set; }
        public string rtaf_person_IdGvm { get; set; }
        public string rtaf_person_BirthDate { get; set; }
        public string rtaf_person_FirstName { get; set; }
        public string rtaf_person_LastName { get; set; }
        public Ranks Rank { get; set; }
        public Units Unit { get; set; }
        public int rtaf_person_Type { get; set; } // 1 น.สัญญาบัตร, 2. น.ประทวน
        public int rtaf_person_Enable { get; set; } // 6 ใช้งาน , 1 รอ
        public string rtaf_person_UpdateDate { get; set; }
        public string rtaf_person_CreateDate { get; set; }
        public string rtaf_person_Position { get; set; }
        public string status { get; set; }
    }
}