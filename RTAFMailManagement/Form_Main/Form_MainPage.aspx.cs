using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using RTAFMailManagement.Managers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTAFMailManagement.Form_Main
{
    public partial class Form_MainPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Class_Active"] = 0;

                if (Request.Params["code"] != null && Request.Params["code"] == "LGOT")
                {
                    LogoutFNC();
                }
            }
        }

        private void LogoutFNC()
        {
            Admin_Users au = (Admin_Users)Session["admin_user"];
            string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

            Activity_Log log = new Activity_Log()
            {
                Act_log_user = au.Admin_Users_Name,
                Act_log_ip = ipAdd,
                Act_log_details = "LGOT_001 : Sign Out Successfully"
            };

            new Activity_Log_Manager().AddActivityLogs(log);

            Session.RemoveAll();

            Response.Redirect("/Authentication/Login");
        }
    }
}