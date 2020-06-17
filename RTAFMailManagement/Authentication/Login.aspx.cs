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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_btn_Click(object sender, EventArgs e)
        {
            string username = Username_TBx.Text;
            string password = Password_TBx.Text;

            if(ConnectRTAFService.AuthenUserWithADServer(username, password))
            {
                Response.Redirect("/Form_Main/Form_MainPage");
            }
        }
    }
}