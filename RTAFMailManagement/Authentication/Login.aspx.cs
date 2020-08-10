using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using RTAFMailManagement.Managers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTAFMailManagement.Authentication
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_btn_Click(object sender, EventArgs e)
        {
            /*string username = Username_TBx.Text;
            string password = Password_TBx.Text;

            if(ConnectRTAFService.AuthenUserWithADDS(username, password))
            {*/

            Admin_Users au = new Admin_Users()
            {
                Admin_User_Type = new Admin_Users_Type()
                {
                    Admin_Users_Type_id = 3,
                    Admin_Users_Type_Name = "Super Admin"
                }
            };

            Session["admin_user"] = au;
            Response.Redirect("/Form_Main/Form_MainPage");
            //}
        }
    }
}