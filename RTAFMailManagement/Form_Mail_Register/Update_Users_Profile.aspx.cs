using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using RTAFMailManagement.Managers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTAFMailManagement.Form_Mail_Register
{
    public partial class Update_Users_Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string User_IdGvm = code[1];
                string User_IdCard = code[2];
                string User_Id = code[3];

                Admin_Users au = (Admin_Users)Session["admin_user"];
                string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

                if (Request.Params["code"] == "e")
                {

                }
            }
        }
    }
}