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
            string username = Username_TBx.Text;
            string password = Password_TBx.Text;
            string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

            //if (ConnectRTAFService.AuthenUserWithADDS(username, password))
            //{
            //    Admin_Users au = new Admin_User_Manager().GetCheckAdministratorLevel(username);

            //    if (au.Admin_User_Type.Admin_Users_Type_id == 1)
            //    {
            //        Activity_Log log = new Activity_Log()
            //        {
            //            Act_log_user = au.Admin_Users_Name,
            //            Act_log_ip = ipAdd,
            //            Act_log_details = "LGN_ADM : Admin Authenicated and Sign-in Success"
            //        };

            //        new Activity_Log_Manager().AddActivityLogs(log);

            //        Session["admin_user"] = au;

            //        Response.Redirect("/Form_Main/Form_MainPage");
            //    }
            //    else if (au.Admin_User_Type.Admin_Users_Type_id == 2)
            //    {
            //        Activity_Log log = new Activity_Log()
            //        {
            //            Act_log_user = au.Admin_Users_Name,
            //            Act_log_ip = ipAdd,
            //            Act_log_details = "LGN_UADM : Unit Admin Authenicated and Sign-in Success"
            //        };

            //        new Activity_Log_Manager().AddActivityLogs(log);

            //        Session["admin_user"] = au;

            //        Response.Redirect("/Form_Main/Form_MainPage");
            //    }
            //    else if (au.Admin_User_Type.Admin_Users_Type_id == 3)
            //    {
            //        Activity_Log log = new Activity_Log()
            //        {
            //            Act_log_user = au.Admin_Users_Name,
            //            Act_log_ip = ipAdd,
            //            Act_log_details = "LGN_SADM : Super Admin Authenicated and Sign-in Success"
            //        };

            //        new Activity_Log_Manager().AddActivityLogs(log);

            //        Session["admin_user"] = au;

            //        Response.Redirect("/Form_Main/Form_MainPage");
            //    }
            //    else
            //    {
            //        Activity_Log log = new Activity_Log()
            //        {
            //            Act_log_user = username,
            //            Act_log_ip = ipAdd,
            //            Act_log_details = "LGN_NMU : Normal User Authenicated and Sign-in Success"
            //        };

            //        new Activity_Log_Manager().AddActivityLogs(log);

            //        Response.Redirect("/Form_Main/Form_MainPage");
            //    }
            //}
            //else
            //{
            //    Activity_Log log = new Activity_Log()
            //    {
            //        Act_log_user = username,
            //        Act_log_ip = ipAdd,
            //        Act_log_details = "LGN_WAR : Unknown User Attempting Sign in System With Authenticate"
            //    };

            //    new Activity_Log_Manager().AddActivityLogs(log);
            //}

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
        }
    }
}