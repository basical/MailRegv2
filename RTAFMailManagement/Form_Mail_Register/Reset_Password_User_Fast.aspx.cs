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
    public partial class Reset_Password_User_Fast : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Class_Active"] = 16;
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            string username = Username_TBx.Text;
            string newPassword = Password_TBx.Text;
            string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

            if(ConnectRTAFService.ResetPasswordWithADDS(username, newPassword))
            {
                Activity_Log log = new Activity_Log()
                {
                    Act_log_user = username,
                    Act_log_ip = ipAdd,
                    Act_log_details = "ResP_HC_001 : Reset New Passweord Success"
                };

                new Activity_Log_Manager().AddActivityLogs(log);

                success_panel.Visible = true;
                bad_panel.Visible = false;
                success_Lbl.Text = "รีเซตรหัสผ่านของบัญชีผู้ใช้งาน : " + username + " สำเร็จ ";
            }
            else
            {
                Activity_Log log = new Activity_Log()
                {
                    Act_log_user = username,
                    Act_log_ip = ipAdd,
                    Act_log_details = "ResP_HC_ERR : Reset New Passweord Fail"
                };

                new Activity_Log_Manager().AddActivityLogs(log);

                success_panel.Visible = false;
                bad_panel.Visible = true;
                bad_Lbl.Text = "รีเซตรหัสผ่านของบัญชีผู้ใช้งาน : " + username + " ล้มเหลว กรุณาตรวจสอบใน AD Server อีกครั้ง ";
            }

            ClearText();
        }

        protected void Cancel_Btn_Click(object sender, EventArgs e)
        {
            ClearText();

            Response.Redirect("/Form_Mail_Register/Reset_Password_User_Fast");
        }

        private void ClearText()
        {
            Username_TBx.Text = "";
            Password_TBx.Text = "";
        }
    }
}