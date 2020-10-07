using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using RTAFMailManagement.Managers;

using System;
using System.Collections.Generic;
using System.Drawing;
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
                Session.Remove("List_User_Acc");

                LoadUnits();
                LoadRanks();
                LoadRTAFStatus();
                LoadADStatus();
                LoadQuestions();
                LoadUserTypes();

                string[] code = Request.Params["code"].Split('U');
                string User_IdGvm = code[1];
                string User_IdCard = code[2];
                string User_Id = code[3];

                if (Request.Params["mode"] == "e")
                {
                    Users data = new Users_Mananer().GetUserById(User_Id);

                    DisplayInfoProfile(data);
                }
                else if (Request.Params["mode"] == "d")
                {
                    Admin_Users au = (Admin_Users)Session["admin_user"];
                    string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];
                }
            }
        }

        private void DisplayInfoProfile(Users data)
        {
            IdCard_TBx.Text = data.User_IdCard;
            Rank_DDL.SelectedValue = data.User_Rank.Rank_Code.ToString();
            FName_TBx.Text = data.User_FirstName;
            LName_TBx.Text = data.User_LastName;
            IdGvm_TBx.Text = data.User_IdGvm;
            Rank_Eng_TBx.Text = data.User_Rank.Rank_FullNameEng + " ( " + data.User_Rank.Rank_NameEng + " ) ";
            FName_Eng_TBx.Text = data.User_FirstNameEn;
            LName_Eng_TBx.Text = data.User_LastNameEn;
            Birthday_Date_TBx.Text = DateTimeUtility.convertDateToPageRealServer(data.User_BirthDate);

            if (data.User_status.RTAF_status_Code == 0)
            {
                Person_Status_DDL.SelectedItem.Text = data.User_status_msg;
            }
            else
            {
                Person_Status_DDL.SelectedValue = data.User_status.RTAF_status_Code.ToString();
            }

            Units_DDL.SelectedValue = data.User_Unit.Unit_Code.ToString();
            Position_TBx.Text = data.User_Position;
            Tel_Tbx.Text = data.User_Tel;

            Username_TBx.Text = data.User_UserName;
            Username_TBx.ForeColor = Color.OrangeRed;

            Email_TBx.Text = data.User_Email;
            Email_TBx.ForeColor = Color.Blue;

            AD_Status_DDL.SelectedValue = data.User_ADStatus.AD_Status_Code.ToString();
            Quastion_DDL.SelectedValue = data.User_Question.Questions_id.ToString();
            Answer_TBx.Text = data.User_Answer;
            Email_Sec_TBx.Text = data.User_SecEmail;
            Acc_Type_DDL.SelectedValue = data.User_Type.User_Type_Code.ToString();

            AD_Real adrl = ConnectRTAFService.GetInfomationsAccountWithADDS(data.User_UserName, "");

            if (adrl.AD_Enabled)
            {
                AD_Status_Real_TBx.Text = "Active";
                AD_Status_Real_TBx.ForeColor = Color.Green;
            }
            else
            {
                AD_Status_Real_TBx.Text = "Disable";
                AD_Status_Real_TBx.ForeColor = Color.Red;
            }
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
                    Act_log_details = "ResP_HC_SCC : Reset New Passweord User : " + username + " Success"
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
                    Act_log_details = "ResP_HC_FAIL : Reset New Passweord User : " + username + " Fail"
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
            Response.Redirect("/Form_Mail_Register/Search_User_Accounts");
        }

        protected void Close_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Mail_Register/Search_User_Accounts");
        }

        // ดึงข้อมูลชั้นยศ ทั้งหมด
        private void LoadRanks()
        {
            List<Ranks> list_data = new Ranks_Manager().getAllRanks();
            Rank_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Ranks data = list_data[i];
                Rank_DDL.Items.Add(new ListItem(data.Rank_Name+ " ( " + data.Rank_FullName + " ) ", data.Rank_Code.ToString()));
            }
        }

        // ดึงข้อมูลสังกัด ทอ. ทั้งหมด
        private void LoadUnits()
        {
            List<Units> list_data = new Units_Manager().getAllUnits();
            Units_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Units data = list_data[i];
                Units_DDL.Items.Add(new ListItem(data.Unit_FullName + " ( " + data.Unit_Name + " ) ", data.Unit_Code.ToString()));
            }
        }

        // ดึงข้อมูลสถานะกำลังพล ทั้งหมด
        private void LoadRTAFStatus()
        {
            List<RTAF_Status> list_data = new RTAF_Status_Manager().getAllStatus();
            Person_Status_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                RTAF_Status data = list_data[i];
                Person_Status_DDL.Items.Add(new ListItem(data.RTAF_status_Name + " ( " + data.RTAF_status_Remark + " ) ", data.RTAF_status_Code.ToString()));
            }
        }

        // ดึงข้อมูลสถานะ AD ทั้งหมด
        private void LoadADStatus()
        {
            List<AD_Status> list_data = new AD_Status_Manager().getAllADStatus();
            AD_Status_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                AD_Status data = list_data[i];
                AD_Status_DDL.Items.Add(new ListItem(data.AD_Status_Name, data.AD_Status_Code.ToString()));
            }
        }

        // ดึงข้อมูลคำถาม ทั้งหมด
        private void LoadQuestions()
        {
            List<Questions> list_data = new Question_Manager().getAllQuestion();
            Quastion_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Questions data = list_data[i];
                Quastion_DDL.Items.Add(new ListItem(data.Questions_Name, data.Questions_id.ToString()));
            }
        }

        // ดึงข้อมูลประเภทผู้ใช้งาน ทั้งหมด
        private void LoadUserTypes()
        {
            List<Users_Type> list_data = new Users_Mananer().getAllUserType();
            Acc_Type_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Users_Type data = list_data[i];
                Acc_Type_DDL.Items.Add(new ListItem(data.User_Type_Name + " ( " + data.User_Type_Remark + " ) ", data.User_Type_Code.ToString()));
            }
        }
    }
}