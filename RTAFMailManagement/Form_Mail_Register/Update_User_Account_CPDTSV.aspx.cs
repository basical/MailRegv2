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
    public partial class Update_User_Account_CPDTSV : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Class_Active"] = 17;
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {
            int count_all = 0;
            int count_success = 0;
            int count_fail = 0;

            RTAF_DATA g_data = new RTAF_DATA()
            {
                RTAF_person_Rank = new Ranks()
                {
                    Rank_Code = 0
                },

                RTAF_person_Unit = new Units()
                {
                    Unit_Code = 0
                },

                RTAF_person_Status = new RTAF_Status()
                {
                    RTAF_status_Code = 0
                }
            };

            List<RTAF_DATA> list_all_data = new RTAFData_Managers().GetRTAFDataALL(g_data, 0, 0);

            count_all = list_all_data.Count;

            for (int i = 0; i < list_all_data.Count; i++)
            {
                RTAF_DATA data = list_all_data[i];

                Users i_data = new Users()
                {
                    User_IdCard = data.RTAF_person_IdCard,
                    User_IdGvm = data.RTAF_person_IdGvm,
                    User_BirthDate = data.RTAF_person_BirthDate,
                    User_FirstName = data.RTAF_person_FirstName,
                    User_LastName = data.RTAF_person_LastName,
                    User_FirstNameEn = data.RTAF_person_FirstName_Eng,
                    User_LastNameEn = data.RTAF_person_LastName_Eng,

                    User_Rank = new Ranks()
                    {
                        Rank_Code = data.RTAF_person_Rank.Rank_Code
                    },

                    User_Unit = new Units()
                    {
                        Unit_Code = data.RTAF_person_Unit.Unit_Code
                    },

                    User_Position = data.RTAF_person_Position,

                    User_status = new RTAF_Status()
                    {
                        RTAF_status_Code = data.RTAF_person_Status.RTAF_status_Code,
                        RTAF_status_Name = data.RTAF_person_Status.RTAF_status_Name
                    },

                    User_status_msg = data.RTAF_person_Status.RTAF_status_Name
                };

                if (new Users_Mananer().UpdateUserAccountWithRTAFDATA(i_data))
                {
                    count_success++;
                }
                else
                {
                    count_fail++;
                }
            }

            All_Row_TBx.Text = count_all.ToString();
            Row_Count_TBx.Text = count_success.ToString();
            Row_Fail_Count_TBx.Text = count_fail.ToString();

        }

        protected void Cancel_Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Form_Mail_Register/Search_User_Accounts");
        }
    }
}