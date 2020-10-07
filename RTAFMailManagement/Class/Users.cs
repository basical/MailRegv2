namespace RTAFMailManagement.Class
{
    public class Users
    {
        public int User_id { get; set; }
        public string User_Email { get; set; }
        public string User_IdCard { get; set; }
        public string User_IdGvm { get; set; }
        public string User_BirthDate { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public string User_FirstNameEn { get; set; }
        public string User_LastNameEn { get; set; }
        public Ranks User_Rank { get; set; }
        public Units User_Unit { get; set; }
        public string User_Password { get; set; }
        public int User_Format { get; set; }
        public Questions User_Question { get; set; }
        public string User_Answer { get; set; }
        public string User_Position { get; set; }
        public string User_UserName { get; set; }
        public string User_Name { get; set; }
        public AD_Status User_ADStatus { get; set; }
        public AD_Real User_Real_AD { get; set; }
        public Mail_Status User_MailStatus { get; set; }
        public Users_Type User_Type { get; set; } // 1.บุคคล, 2.หน่วยงาน, 3.กลุ่มการทำงาน
        public string User_Tel { get; set; }
        public int User_Type_Rank { get; set; } // 1 น.สัญญาบัตร, 2. น.ประทวน
        public string User_UpdateDate { get; set; }
        public string User_CreateDate { get; set; }
        public string User_Remark { get; set; }
        public string User_PasswordOld { get; set; }
        public int User_Permission { get; set; }
        public int User_Division { get; set; }
        public int User_WorkingYear { get; set; }
        public int User_WorkingRank { get; set; }
        public int User_PosAction { get; set; }
        public string User_SecEmail { get; set; }
        public string User_status_msg { get; set; }
        public RTAF_Status User_status { get; set; }
        public RTAF_DATA person_data { get; set; }
        public string Employee_name { get; set; }
        public string Company_name { get; set; }
    }
}