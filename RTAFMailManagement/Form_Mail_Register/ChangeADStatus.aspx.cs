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
                        if (ConnectRTAFService.AccountDisabledWithADDS(data.User_UserName, true))
                        {
                            if(new Users_Mananer().ChangeADStatusDB(data.User_UserName, 2))
                            {
                                Activity_Log log = new Activity_Log()
                                {
                                    Act_log_user = au.Admin_Users_Name,
                                    Act_log_ip = ipAdd,
                                    Act_log_details = "AD_CHG_ENB : Enable User is Ready for Use System With Authenticate"
                                };

                                new Activity_Log_Manager().AddActivityLogs(log);
                            }
                        }
                    }
                    else if (Request.Params["mode"] == "d")
                    {
                        if (ConnectRTAFService.AccountDisabledWithADDS(data.User_UserName, false))
                        {
                            if (new Users_Mananer().ChangeADStatusDB(data.User_UserName, 3))
                            {
                                Activity_Log log = new Activity_Log()
                                {
                                    Act_log_user = au.Admin_Users_Name,
                                    Act_log_ip = ipAdd,
                                    Act_log_details = "AD_CHG_DIS : Disable User was Locked for Use System With Authenticate"
                                };

                                new Activity_Log_Manager().AddActivityLogs(log);
                            }
                        }
                    }
                }
            }
        }
    }
}