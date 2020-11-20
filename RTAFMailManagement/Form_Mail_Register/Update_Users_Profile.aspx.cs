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

                Session["User_Id"] = User_Id;

                Users data = new Users_Mananer().GetUserById(User_Id);

                if (Request.Params["mode"] == "e")
                {
                    DisplayInfoProfile(data);
                }
                else if (Request.Params["mode"] == "d")
                {
                    RemoveUserAccount(data);
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
            Tel_TBx.Text = data.User_Tel;

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

            Group_panel.Visible = data.User_Type.User_Type_Code == 3? true : false;
            
            if(data.User_Type.User_Type_Code == 3)
            {
                Employee_Name_TBx.Text = data.Employee_name;
                Company_Name_TBx.Text = data.Company_name;
            }

        }

        private void RemoveUserAccount(Users data)
        {
            Admin_Users au = (Admin_Users)Session["admin_user"];
            string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

            if (ConnectRTAFService.RemoveUserAccountWithADDS(data.User_UserName))
            {
                new Users_Mananer().RemoveUserAccount(data);

                Activity_Log log = new Activity_Log()
                {
                    Act_log_user = au.Admin_Users_Name,
                    Act_log_ip = ipAdd,
                    Act_log_details = "Revm_Acc_SCC : Remove User Account in AD Server : " + data.User_UserName + " Success"
                };

                new Activity_Log_Manager().AddActivityLogs(log);

                success_panel.Visible = true;
                bad_panel.Visible = false;
                success_Lbl.Text = "ลบบัญชีผู้ใช้งาน : " + data.User_UserName + " สำเร็จ ";
            }
            else
            {
                Activity_Log log = new Activity_Log()
                {
                    Act_log_user = au.Admin_Users_Name,
                    Act_log_ip = ipAdd,
                    Act_log_details = "Revm_Acc_Fail : Remove User Account in AD Server : " + data.User_UserName + " Fail"
                };

                new Activity_Log_Manager().AddActivityLogs(log);

                success_panel.Visible = false;
                bad_panel.Visible = true;
                bad_Lbl.Text = "ลบบัญชีผู้ใช้งาน : " + data.User_UserName + " ล้มเหลว ";
            }

            Save_Btn.Visible = false;
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
            Users user_data = new Users()
            {
                User_id = (int)Session["User_Id"],
                User_IdCard = IdCard_TBx.Text,
                User_IdGvm = IdGvm_TBx.Text,

                User_Rank = new Ranks()
                {
                    Rank_Code = int.Parse(Rank_DDL.SelectedValue)
                },

                User_FirstName = FName_TBx.Text,
                User_LastName = LName_TBx.Text,
                User_FirstNameEn = FName_Eng_TBx.Text,
                User_LastNameEn = LName_Eng_TBx.Text,
                User_BirthDate = Birthday_Date_TBx.Text,

                User_status = new RTAF_Status()
                {
                    RTAF_status_Code = int.Parse(Person_Status_DDL.SelectedValue)
                },

                User_Unit = new Units()
                {
                    Unit_Code = int.Parse(Units_DDL.SelectedValue)
                },

                User_Position = Position_TBx.Text,
                User_Tel = Tel_TBx.Text,

                User_Type = new Users_Type()
                {
                    User_Type_Code = int.Parse(Acc_Type_DDL.SelectedValue)
                },

                User_UserName = Username_TBx.Text,
                User_Email = Email_TBx.Text,
                User_Password = newPassword_TBx.Text,

                User_Question = new Questions()
                {
                    Questions_id = int.Parse(Quastion_DDL.SelectedValue)
                },

                User_Answer = Answer_TBx.Text,
                User_SecEmail = Email_Sec_TBx.Text,

                User_ADStatus = new AD_Status()
                {
                    AD_Status_Code = int.Parse(AD_Status_DDL.SelectedValue) == 0 ? 1 : int.Parse(AD_Status_DDL.SelectedValue)
                },

                User_MailStatus = new Mail_Status()
                {
                    Mail_Status_Code = 1
                },

                person_data = new RTAF_DATA()
                {
                    RTAF_person_Uid = (string)Session["person_uid"]
                },

                User_Type_Rank = (int)Session["type_rank"]
            };

            int act = 0;

            if (Acc_Type_DDL.SelectedValue == "1")
            {
                act = 1;
            }
            else if (Acc_Type_DDL.SelectedValue == "2")
            {
                act = 2;
            }
            else if (Acc_Type_DDL.SelectedValue == "3")
            {
                act = 3;
            }

            Admin_Users au = (Admin_Users)Session["admin_user"];
            string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

            /// ปรับปรุงข้อมูล User Account ลงในฐานข้อมูล
            if (new Users_Mananer().UpdateUserAccount(user_data))
            {
                /// ปรับปรุงข้อมูล User Account ใน AD Server
                if (ConnectRTAFService.UpDateUserADwithIDGADService(new Users_Mananer().GetUserAccountByUsername(user_data.User_UserName), act))
                {
                    Activity_Log log = new Activity_Log()
                    {
                        Act_log_user = au.Admin_Users_Name,
                        Act_log_ip = ipAdd,
                        Act_log_details = "UpdateUser_SUCF : Update User Account : " + user_data.User_UserName + " : in DB and AD Server Success"
                    };

                    new Activity_Log_Manager().AddActivityLogs(log);

                    success_panel.Visible = true;
                    bad_panel.Visible = false;
                    success_Lbl.Text = "เพิ่มบัญชีผู้ใช้งาน : " + user_data.User_UserName + " ใน ฐานข้อมูล และ AD Server สำเร็จ ";
                }
                else
                {
                    Activity_Log log = new Activity_Log()
                    {
                        Act_log_user = au.Admin_Users_Name,
                        Act_log_ip = ipAdd,
                        Act_log_details = "UpdateUse_SUCC : Update User Account : " + user_data.User_UserName + " : in DB Success but AD Server Fail"
                    };

                    new Activity_Log_Manager().AddActivityLogs(log);

                    success_panel.Visible = false;
                    bad_panel.Visible = true;
                    bad_Lbl.Text = "เพิ่มบัญชีผู้ใช้งาน : " + user_data.User_UserName + " ใน ฐานข้อมูล สำเร็จ แต่พบปัญหาในการเพิ่มลงใน AD Server ";
                }
            }
            else
            {
                Activity_Log log = new Activity_Log()
                {
                    Act_log_user = au.Admin_Users_Name,
                    Act_log_ip = ipAdd,
                    Act_log_details = "UpdateUse_FAIL : Update User Account : " + user_data.User_UserName + " : Fail"
                };

                new Activity_Log_Manager().AddActivityLogs(log);

                success_panel.Visible = false;
                bad_panel.Visible = true;
                bad_Lbl.Text = "ไม่สามารถเพิ่มบัญชีผู้ใช้งาน : " + user_data.User_UserName + " ได้ กรุณาตรวจสอบข้อมูล";
            }
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
                Rank_DDL.Items.Add(new ListItem(data.Rank_Name + " ( " + data.Rank_FullName + " ) ", data.Rank_Code.ToString()));
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