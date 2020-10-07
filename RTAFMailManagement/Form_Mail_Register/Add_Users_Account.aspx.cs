using Microsoft.Ajax.Utilities;
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
    public partial class Add_Users_Account : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadUnits();
                //LoadRanks();
                //LoadRTAFStatus();
                //LoadADStatus();
                //LoadQuestions();
                //LoadUserTypes();

                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string User_IdGvm = code[1];
                    string User_IdCard = code[2];
                    string User_Id = code[3];

                    int act = Convert.ToInt32(Session["Class_Active"].ToString());

                    if (act == 13)
                    {
                        header_page_Lbl.Text = "ผู้ใช้งาน";
                        sub_header_page_Lbl.Text = "ผู้ใช้งาน";

                        List_Username_DDL.Visible = true;
                        Username_UG_TBx.Visible = false;

                        LoadPersonData(new RTAFData_Managers().GetRTAFData(User_IdCard, User_IdGvm), 1);
                    }
                    else if (act == 14)
                    {
                        header_page_Lbl.Text = "ผู้รับผิดชอบ หน่วยงาน";
                        sub_header_page_Lbl.Text = "ผู้รับผิดชอบ หน่วยงาน";

                        List_Username_DDL.Visible = false;
                        Username_UG_TBx.Visible = true;

                        LoadPersonData(new RTAFData_Managers().GetRTAFData(User_IdCard, User_IdGvm), 2);
                    }
                    else if (act == 15)
                    {
                        header_page_Lbl.Text = "ผู้รับผิดชอบ คณะทำงาน";
                        sub_header_page_Lbl.Text = "ผู้รับผิดชอบ คณะทำงาน";

                        List_Username_DDL.Visible = false;
                        Username_UG_TBx.Visible = true;

                        LoadPersonData(new RTAFData_Managers().GetRTAFData(User_IdCard, User_IdGvm), 3);
                    }
                }

                if (Request.Params["gnrd"] != null)
                {
                    if (Request.Params["gnrd"] == "ad")
                    {

                    }
                    else if (Request.Params["gnrd"] == "ma")
                    {

                    }
                    else if (Request.Params["gnrd"] == "adma")
                    {

                    }
                }
            }
        }

        // ดึงข้อมูลชั้นยศ ทั้งหมด
        private void LoadRanks()
        {
            List<Ranks> list_data = new Ranks_Manager().getAllRanks();
            Rank_DDL.Items.Add(new ListItem("--------กรุณาเลือก--------", "0"));
            for (int i = 0; i < list_data.Count; i++)
            {
                Ranks data = list_data[i];
                Rank_DDL.Items.Add(new ListItem(data.Rank_FullName + " ( " + data.Rank_Name + " ) ", data.Rank_Code.ToString()));
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

        private void LoadPersonData(RTAF_DATA data, int mode)
        {
            IdCard_TBx.Text = data.RTAF_person_IdCard;
            Rank_DDL.SelectedValue = data.RTAF_person_Rank.Rank_Code.ToString();
            FName_TBx.Text = data.RTAF_person_FirstName;
            LName_TBx.Text = data.RTAF_person_LastName;
            IdGvm_TBx.Text = data.RTAF_person_IdGvm;
            Rank_Eng_TBx.Text = data.RTAF_person_Rank.Rank_FullNameEng + " ( " + data.RTAF_person_Rank.Rank_NameEng + " ) ";
            FName_Eng_TBx.Text = data.RTAF_person_FirstName_Eng;
            LName_Eng_TBx.Text = data.RTAF_person_LastName_Eng;
            Birthday_Date_TBx.Text = DateTimeUtility.convertDateToPageRealServer(data.RTAF_person_BirthDate);
            Person_Status_DDL.SelectedValue = data.RTAF_person_Status.RTAF_status_Code.ToString();
            Units_DDL.SelectedValue = data.RTAF_person_Unit.Unit_Code.ToString();
            Position_TBx.Text = data.RTAF_person_Position;

            if (mode == 1)
            {
                /// สร้าง User Account ไว้ให้เลือก ** เฉพาะบุคคลากรของ ทอ. **
                string[] c_username = new string[data.RTAF_person_LastName_Eng.Length + 1];

                for (int u = 0; u <= data.RTAF_person_LastName_Eng.Length; u++)
                {
                    if (u == 0)
                    {
                        c_username[u] = data.RTAF_person_FirstName_Eng;
                    }
                    else
                    {
                        c_username[u] = data.RTAF_person_FirstName_Eng + "_" + data.RTAF_person_LastName_Eng.Substring(0, u);
                    }
                }

                /// เช็ค User Account ที่สร้างไว้ โดยนำไปตรวจสอบกับ AD Server หากไม่มีข้อมูลให้เก็บไว้ใน list เพื่อเป็นตัวเลือกสำหรับสร้าง Account ใน AD
                string[] list_username = new string[5];

                for (int i = 0; i <= c_username.Length; i++)
                {
                    if (ConnectRTAFService.GetInfomationsAccountWithADDS(c_username[i], "") == null)
                    {
                        list_username[i] = c_username[i];
                    }

                    if (list_username.Length == 5) { i = 999; }
                }

                for (int i = 0; i < list_username.Length; i++)
                {
                    List_Username_DDL.Items.Add(new ListItem(list_username[i], list_username[i]));
                }
            }

            Acc_Type_DDL.SelectedValue = mode.ToString();

            Session["person_uid"] = data.RTAF_person_Uid;
            Session["type_rank"] = data.RTAF_person_type.Person_Type_Id;

        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            Users user_data = new Users()
            {
                User_IdCard = IdCard_TBx.Text,
                User_IdGvm = IdGvm_TBx.Text,

                User_Rank = new Ranks()
                {
                    Rank_Code = int.Parse(Rank_DDL.SelectedValue)
                },

                User_FirstName = FName_TBx.Text,
                User_FirstNameEn = LName_TBx.Text,
                User_LastName = FName_Eng_TBx.Text,
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

                User_UserName = List_Username_DDL.SelectedValue,
                User_Email = List_Username_DDL.SelectedValue + "@rtaf.mi.th",
                User_Password = newPassword_TBx.Text,

                User_Question = new Questions()
                {
                    Questions_id = int.Parse(Quastion_DDL.SelectedValue)
                },

                User_Answer = Answer_TBx.Text,
                User_SecEmail = Email_Sec_TBx.Text,

                User_ADStatus = new AD_Status()
                {
                    AD_Status_Code = int.Parse(AD_Status_DDL.SelectedValue)
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

            Admin_Users au = (Admin_Users)Session["admin_user"];
            string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

            /// เพิ่มข้อมูล User Account ลงในฐานข้อมูล
            if (new Users_Mananer().AddUserAccount(user_data))
            {
                /// เพิ่มข้อมูล User Account ใน AD Server
                if (ConnectRTAFService.AddAccount2ADDS(new Users_Mananer().GetUserAccountByUsername(user_data.User_UserName)))
                {
                    Activity_Log log = new Activity_Log()
                    {
                        Act_log_user = au.Admin_Users_Name,
                        Act_log_ip = ipAdd,
                        Act_log_details = "AddUser_SUCF : Add User Account : " + user_data.User_UserName + " : in DB and AD Server Success"
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
                        Act_log_details = "AddUser_SUCC : Add User Account : " + user_data.User_UserName + " : in DB Success but AD Server Fail"
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
                    Act_log_details = "AddUser_FAIL : Add User Account : " + user_data.User_UserName + " : Fail"
                };

                new Activity_Log_Manager().AddActivityLogs(log);

                success_panel.Visible = false;
                bad_panel.Visible = true;
                bad_Lbl.Text = "ไม่สามารถเพิ่มบัญชีผู้ใช้งาน : " + user_data.User_UserName + " ได้ กรุณาตรวจสอบข้อมูล";
            }

            ClearText();
        }

        protected void Cancel_Btn_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void ClearText()
        {
            IdCard_TBx.Text = "";
            IdGvm_TBx.Text = "";
            Rank_DDL.SelectedValue = "0";
            FName_TBx.Text = "";
            LName_TBx.Text = "";
            FName_Eng_TBx.Text = "";
            LName_Eng_TBx.Text = "";
            Birthday_Date_TBx.Text = "";
            Person_Status_DDL.SelectedValue = "0";
            Units_DDL.SelectedValue = "0";
            Position_TBx.Text = "";
            Tel_TBx.Text = "";
            Acc_Type_DDL.SelectedValue = "0";
            List_Username_DDL.SelectedValue = "0";
            newPassword_TBx.Text = "";
            Quastion_DDL.SelectedValue = "0";
            Answer_TBx.Text = "";
            Email_Sec_TBx.Text = "";
            AD_Status_DDL.SelectedValue = "0";
        }

        protected void Close_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Mail_Register/Search_User_Accounts");
        }
    }
}