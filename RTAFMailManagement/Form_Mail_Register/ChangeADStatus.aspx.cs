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
    public partial class ChangeADStatus : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string User_IdGvm = code[1];
                    string User_IdCard = code[2];
                    string User_Id = code[3];

                    Admin_Users au = (Admin_Users)Session["admin_user"];
                    string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

                    Users data = new Users_Mananer().GetUserById(User_Id);

                    if (Request.Params["mode"] == "e")
                    {
                        ConnectRTAFService.AccountDisabledWithADDS(data.User_UserName, true);

                        Activity_Log log = new Activity_Log()
                        {
                            Act_log_user = au.Admin_Users_Name,
                            Act_log_ip = ipAdd,
                            Act_log_details = "LGN_WAR : Unknown User Attempting Sign in System With Authenticate"
                        };

                        new Activity_Log_Manager().AddActivityLogs(log);
                    }
                    else if (Request.Params["mode"] == "d")
                    {
                        ConnectRTAFService.AccountDisabledWithADDS(data.User_UserName, false);

                        Activity_Log log = new Activity_Log()
                        {
                            Act_log_user = au.Admin_Users_Name,
                            Act_log_ip = ipAdd,
                            Act_log_details = "LGN_WAR : Unknown User Attempting Sign in System With Authenticate"
                        };

                        new Activity_Log_Manager().AddActivityLogs(log);
                    }
                }
            }
        }
    }
}