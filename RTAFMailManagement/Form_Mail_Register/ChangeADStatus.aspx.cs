using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RTAFMailManagement.Form_Mail_Register
{
    public partial class ChangeADStatus : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["code"] != null)
                {
                    string[] code = Request.Params["code"].Split('U');
                    string User_IdGvm = code[1];
                    string User_IdCard = code[2];

                    if (Request.Params["mode"] == "e")
                    {

                    }
                    else if (Request.Params["mode"] == "d")
                    {

                    }
                }
            }
        }
    }
}