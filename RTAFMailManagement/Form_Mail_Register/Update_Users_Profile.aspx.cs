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

        private void DisplayInfoProfile()
        {

        }

        protected void Change_Password_Save_Btn_Click(object sender, EventArgs e)
        {
            string username = Username_TBx.Text;
            string newPassword = newPassword_TBx.Text;

            Admin_Users au = (Admin_Users)Session["admin_user"];
            string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

            if (ConnectRTAFService.ResetPasswordWithADDS(username, newPassword))
            {
                Activity_Log log = new Activity_Log()
                {
                    Act_log_user = au.Admin_Users_Name,
                    Act_log_ip = ipAdd,
                    Act_log_details = "ResP_HC_SCC : Reset New Passweord Success"
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
                    Act_log_user = au.Admin_Users_Name,
                    Act_log_ip = ipAdd,
                    Act_log_details = "ResP_HC_FAIL : Reset New Passweord Fail"
                };

                new Activity_Log_Manager().AddActivityLogs(log);

                success_panel.Visible = false;
                bad_panel.Visible = true;
                bad_Lbl.Text = "รีเซตรหัสผ่านของบัญชีผู้ใช้งาน : " + username + " ล้มเหลว กรุณาตรวจสอบใน AD Server อีกครั้ง ";
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {

        }

        protected void Cancel_Btn_Click(object sender, EventArgs e)
        {

        }

        protected void Close_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}