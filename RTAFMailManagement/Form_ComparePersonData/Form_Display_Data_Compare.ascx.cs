using RTAFMailManagement.Class;
using RTAFMailManagement.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace RTAFMailManagement.Form_ComparePersonData
{
    public partial class Form_Display_Data_Compare : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Compare_Data_Btn_Click(object sender, EventArgs e)
        {
            List<Compare_Data> list_data = (List<Compare_Data>)Session["found_data"];

            for (int i = 0; i < list_data.Count(); i++)
            {
                Compare_Data data = list_data[i];

                RTAFData_Managers rtaf_mng = new RTAFData_Managers();

                rtaf_mng.editPersonalData(data.sevice_data);
            }
        }
    }
}