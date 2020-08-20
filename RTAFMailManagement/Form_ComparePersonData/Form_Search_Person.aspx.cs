using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTAFMailManagement.Form_ComparePersonData
{
    public partial class Form_Search_Person : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Class_Active"] = 22;
            }
        }

        protected void Search_Btn_Click(object sender, EventArgs e)
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
            Units_DDL.SelectedValue = "0";
        }

        protected void Cancel_Btn_Click(object sender, EventArgs e)
        {
            ClearText();
        }
    }
}