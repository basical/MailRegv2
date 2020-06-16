using RTAFMailManagement.Class;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTAFMailManagement.Class
{
    public class Users
    {
        public int user_id { get; set; }
        public string user_Email { get; set; }
        public string user_IdCard { get; set; }
        public string user_IdGvm { get; set; }
        public string user_BirthDate { get; set; }
        public string user_FirstName { get; set; }
        public string user_LastName { get; set; }
        public string user_FirstNameEn { get; set; }
        public string user_LastNameEn { get; set; }
        public Ranks Rank { get; set; }
        public Units Unit { get; set; }
        public string user_Password { get; set; }
        public int user_Format { get; set; }
        public int user_Question { get; set; }
        public string user_Answer { get; set; }
        public string user_Position { get; set; }
        public string user_UserName { get; set; }
        public string user_Name { get; set; }
        public int user_ADStatus { get; set; }
        public int user_MailStatus { get; set; }
        public int user_Type { get; set; } // 1.บุคคล, 2.หน่วยงาน, 3.กลุ่มการทำงาน
        public string user_Tel { get; set; }
        public int user_Type_Rank { get; set; } // 1 น.สัญญาบัตร, 2. น.ประทวน
        public string user_UpdateDate { get; set; }
        public string user_CreateDate { get; set; }
        public string user_Remark { get; set; }
        public string user_PasswordOld { get; set; }
        public int user_Permission { get; set; }
        public int user_Division { get; set; }
        public int user_WorkingYear { get; set; }
        public int user_WorkingRank { get; set; }
        public int user_PosAction { get; set; }
        public string user_SecEmail { get; set; }
        public string status { get; set; }
    }
}