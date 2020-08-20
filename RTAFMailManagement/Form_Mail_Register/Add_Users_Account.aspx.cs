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

        protected void Save_Btn_Click(object sender, EventArgs e)
        {

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