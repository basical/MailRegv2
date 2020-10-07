using RTAFMailManagement.Class;
using RTAFMailManagement.Global_Class;
using RTAFMailManagement.Managers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTAFMailManagement.Form_ComparePersonData
{
    public partial class Form_Edit_PersonData : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUnits();
                LoadRanks();
                LoadRTAFStatus();

                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string person_IdGvm = code[1];
                    string person_IdCard = code[2];
                    string person_UId = code[3];

                    Admin_Users au = (Admin_Users)Session["admin_user"];
                    string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

                    if (Request.Params["mode"] == "e")
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

        private void LoadPersonData(RTAF_DATA data)
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
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}