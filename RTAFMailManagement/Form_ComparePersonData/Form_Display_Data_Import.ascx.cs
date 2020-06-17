using RTAFMailManagement.Class;
using RTAFMailManagement.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace RTAFMailManagement.Form_ComparePersonData
{
    public partial class Form_Display_Data_Import : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Import_Data_Btn_Click(object sender, EventArgs e)
        {
            List<RTAF_DATA> list_data = (List<RTAF_DATA>)Session["nfound_data"];

            for (int i = 0; i < list_data.Count(); i++)
            {
                RTAF_DATA data = list_data[i];

                RTAFData_Managers rtaf_mng = new RTAFData_Managers();

                rtaf_mng.AddPersonalData(data);
            }
        }
    }
}