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
            if (Request.Params["code"] != null)
            {
                string[] code = Request.Params["code"].Split('U');
                string person_IdGvm = code[1];
                string person_IdCard = code[2];
                string person_UId = code[3];

                Admin_Users au = (Admin_Users)Session["admin_user"];
                string ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];

                if (Request.Params["code"] == "e")
                {

                }
            }
        }

        protected void Save_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}