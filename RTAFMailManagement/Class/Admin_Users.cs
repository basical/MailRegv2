namespace RTAFMailManagement.Class
{
    public class Admin_Users
    {
        public int Admin_Users_id { get; set; }
        public string Admin_Users_Name { get; set; }
        public Admin_Users_Type Admin_User_Type { get; set; }
        public Units Admin_Users_Unit { get; set; }

        public Users Admin_User_detail { get; set; }
    }
}