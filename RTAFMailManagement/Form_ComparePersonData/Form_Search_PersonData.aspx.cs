﻿using RTAFMailManagement.Class;
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
                Session["Class_Active"] = 22;

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
                Units_DDL.Items.Add(new ListItem(data.unit_Name + " ( " + data.unit_FullName + " ) ", data.unit_Code.ToString()));
            }
        }

        private void LoadService(string Unit_id)
        {
            Session.Remove("service_data");
            Session.Remove("data_by_unit");
            Session.Remove("found_data");
            Session.Remove("nfound_data");

            List<RTAF_DATA> service_data = ConnectRTAFPersonService.getRTAFPersonData(Unit_id);

            List<RTAF_DATA> data_by_unit = new RTAFData_Managers().getRTAFDataByUnit(int.Parse(Unit_id));

            List<Compare_Data> found_data = new List<Compare_Data>();

            List<RTAF_DATA> nfound_data = new List<RTAF_DATA>();

            for (int i = 0; i < service_data.Count; i++)
            {
                RTAF_DATA data = new RTAFData_Managers().getCheckPersonalData(service_data[i].rtaf_person_IdCard,
                                                                        General_Functions.subStringIdGvm(service_data[i].rtaf_person_IdGvm),
                                                                        DateTimeUtility.CDateTime4Service2MSSQL(service_data[i].rtaf_person_BirthDate),
                                                                        service_data[i].rtaf_person_FirstName + " " + service_data[i].rtaf_person_LastName,
                                                                        (int)service_data[i].Unit.unit_Code,
                                                                        service_data[i].Rank.rank_Code,
                                                                        service_data[i].rtaf_person_Position,
                                                                        service_data[i].rtaf_person_IdCard);

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
    }
}