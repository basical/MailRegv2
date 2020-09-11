namespace RTAFMailManagement.Class
{
    public class RTAF_DATA
    {
        public string RTAF_person_Uid { get; set; }
        public string RTAF_person_IdCard { get; set; }
        public string RTAF_person_IdGvm { get; set; }
        public string RTAF_person_BirthDate { get; set; }
        public string RTAF_person_FirstName { get; set; }
        public string RTAF_person_LastName { get; set; }
        public string RTAF_person_FirstName_Eng { get; set; }
        public string RTAF_person_LastName_Eng { get; set; }
        public Ranks RTAF_person_Rank { get; set; }
        public Units RTAF_person_Unit { get; set; }
        public int RTAF_person_Type { get; set; } // 1 น.สัญญาบัตร, 2. น.ประทวน
        public int RTAF_person_Enable { get; set; } // 6 ใช้งาน , 1 รอ
        public string RTAF_person_UpdateDate { get; set; }
        public string RTAF_person_CreateDate { get; set; }
        public string RTAF_person_Position { get; set; }
        public RTAF_Status RTAF_person_Status { get; set; }
    }
}