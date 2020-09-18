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
    public partial class Form_Search_PersonData : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Class_Active"] = 29;

                LoadUnits();
            }
        }
        protected void Search_rtaf_data_Btn_Click(object sender, EventArgs e)
        {
            LoadService(Units_DDL.SelectedValue);
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                   Load Default Data to Form                        ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

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

        private void LoadService(string Unit_id)
        {
            Session.Remove("service_data");
            Session.Remove("data_by_unit");
            Session.Remove("found_data");
            Session.Remove("nfound_data");

            RTAF_DATA sv_data = new RTAF_DATA()
            {
                RTAF_person_Rank = new Ranks()
                {
                    Rank_Code = 0
                },

                RTAF_person_Unit = new Units()
                {
                    Unit_Code = Convert.ToInt64(Unit_id)
                },

                RTAF_person_Status = new RTAF_Status()
                {
                    RTAF_status_Code = 0
                }
            };

            List<RTAF_DATA> service_data = ConnectRTAFService.getNewRTAFPerson(Unit_id);

            List<RTAF_DATA> data_by_unit = new RTAFData_Managers().GetRTAFDataByUnit(sv_data, 0, 0);

            List<Compare_Data> found_data = new List<Compare_Data>();

            List<RTAF_DATA> nfound_data = new List<RTAF_DATA>();

            for (int i = 0; i < service_data.Count; i++)
            {
                RTAF_DATA data = new RTAFData_Managers().CheckPersonalData(service_data[i]);

                if (data != null)
                {
                    Compare_Data cprd = new Compare_Data();

                    cprd.db_data = new RTAF_DATA();
                    cprd.db_data = data;

                    cprd.sevice_data = new RTAF_DATA();
                    cprd.sevice_data = service_data[i];

                    found_data.Add(cprd);
                }
                else
                {
                    nfound_data.Add(service_data[i]);
                }
            }

            Session["service_data"] = service_data;
            Session["data_by_unit"] = data_by_unit;
            Session["found_data"] = found_data;
            Session["nfound_data"] = nfound_data;
        }

        protected void OneClick_All_Btn_Click(object sender, EventArgs e)
        {
            Session.Remove("service_data");
            Session.Remove("data_by_unit");
            Session.Remove("found_data");
            Session.Remove("nfound_data");

            List<Units> list_data = new Units_Manager().getAllUnits();

            for (int i = 0; i < list_data.Count; i++)
            {

                Units data = list_data[i];

                RTAF_DATA sv_data = new RTAF_DATA()
                {
                    RTAF_person_Rank = new Ranks()
                    {
                        Rank_Code = 0
                    },

                    RTAF_person_Unit = new Units()
                    {
                        Unit_Code = data.Unit_Code
                    },

                    RTAF_person_Status = new RTAF_Status()
                    {
                        RTAF_status_Code = 0
                    }
                };

                List<RTAF_DATA> service_data = ConnectRTAFService.getNewRTAFPerson(data.Unit_Code.ToString());

                List<RTAF_DATA> data_by_unit = new RTAFData_Managers().GetRTAFDataByUnit(sv_data, 0, 0);

                List<Compare_Data> found_data = new List<Compare_Data>();

                List<RTAF_DATA> nfound_data = new List<RTAF_DATA>();

                for (int j = 0; j < service_data.Count; j++)
                {
                    RTAF_DATA data_s = new RTAFData_Managers().CheckPersonalData(service_data[j]);

                    if (data_s != null)
                    {
                        Compare_Data cprd = new Compare_Data();

                        cprd.db_data = new RTAF_DATA();
                        cprd.db_data = data_s;

                        cprd.sevice_data = new RTAF_DATA();
                        cprd.sevice_data = service_data[j];

                        found_data.Add(cprd);
                    }
                    else
                    {
                        nfound_data.Add(service_data[j]);
                    }
                }

                Session["service_data"] = service_data;
                Session["data_by_unit"] = data_by_unit;
                Session["found_data"] = found_data;
                Session["nfound_data"] = nfound_data;
            }
        }
    }
}