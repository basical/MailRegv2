using RTAFMailManagement.Class;
using RTAFMailManagement.Managers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTAFMailManagement.Form_Mail_Register
{
    public partial class Search_User_Accounts : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Class_Active"] = 11;

                //LoadUnits();
                //LoadRanks();
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

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            if (getAll_ChkBx.Checked)
            {

            }
            else
            {

            }

            ClearText();
        }

        protected void Add_Btn_Click(object sender, EventArgs e)
        {
            Session.Remove("List_User_Acc");

            Response.Redirect("/Form_Mail_Register/Add_Users_Account");
        }

        private void ClearText()
        {
            Username_TBx.Text = "";
            IdCard_TBx.Text = "";
            IdGvm_TBx.Text = "";
            Rank_DDL.SelectedValue = "0";
            FName_TBx.Text = "";
            LName_TBx.Text = "";
            Units_DDL.SelectedValue = "0";
            getAll_ChkBx.Checked = false;
        }
    }
}