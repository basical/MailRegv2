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
    public partial class Form_Search_Person : Page
    {
        private string error = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Class_Active"] = 22;

                LoadUnits();
                LoadRanks();
                LoadRTAFStatus();
            }
        }

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

        protected void Search_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                RTAF_DATA data = new RTAF_DATA
                {
                    RTAF_person_IdCard = IdCard_TBx.Text,
                    RTAF_person_IdGvm = IdGvm_TBx.Text,

                    RTAF_person_Rank = new Ranks()
                    {
                        Rank_Code = string.IsNullOrEmpty(Rank_DDL.SelectedValue) ? 0 : int.Parse(Rank_DDL.SelectedValue)
                    },

                    RTAF_person_FirstName = FName_TBx.Text,
                    RTAF_person_LastName = LName_TBx.Text,

                    RTAF_person_Unit = new Units()
                    {
                        Unit_Code = string.IsNullOrEmpty(Units_DDL.SelectedValue) ? 0 : int.Parse(Units_DDL.SelectedValue)
                    },

                    RTAF_person_Status = new RTAF_Status()
                    {
                        RTAF_status_Code = string.IsNullOrEmpty(Person_Status_DDL.SelectedValue) ? 0 : int.Parse(Person_Status_DDL.SelectedValue)
                    }
                };


                List<RTAF_DATA> list_data_all = new RTAFData_Managers().GetRTAFDataALL(data, 0, 0);

                int row = list_data_all.Count;

                _pageCount(row);

                List<RTAF_DATA> list_data = new RTAFData_Managers().GetRTAFDataALL(data, 0, 20);

                Session["RTAF_DATA"] = data;

                Session["row_str"] = 0;

                Session["Person_Data_DB"] = list_data;

            }
            catch (Exception ex)
            {
                error = "Exception ===> Form_ComparePersonData ==> Form_Search_Person --> _getMoreData() ";
                Log_Error._writeErrorFile(error, ex);
            }

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
            Units_DDL.SelectedValue = "0";
            Person_Status_DDL.SelectedValue = "0";
        }

        /*******************************************************************************************************************************************************************************
        ****************************************************                                                                    ********************************************************
        ****************************************************                            Paging Function                         ********************************************************
        ****************************************************                                                                    ********************************************************
        *******************************************************************************************************************************************************************************/

        protected void link_Previous_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            if (current_page > 1)
            {
                int prev = current_page - 1;

                Paging_DDL.SelectedValue = prev.ToString();

                _getMoreData(prev);
            }
        }

        protected void Paging_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            _getMoreData(current_page);
        }

        protected void link_Next_Click(object sender, EventArgs e)
        {
            int current_page = Convert.ToInt32(Paging_DDL.SelectedValue);

            int next = current_page + 1;

            Paging_DDL.SelectedValue = next.ToString();

            _getMoreData(next);
        }

        private void _pageCount(int row)
        {
            int paging = row > 20 ? (row / 20) : 1;

            Session["max_page"] = paging;

            for (int i = 1; i <= paging; i++)
            {
                Paging_DDL.Items.Add(new ListItem("" + i, "" + i));
            }

            if (paging == 1)
            {
                link_Previous.Enabled = false;
                link_Next.Enabled = false;
            }
            else if (paging > 1 && Paging_DDL.Items[0].Value == "0")
            {
                link_Previous.Enabled = false;
                link_Next.Enabled = true;
            }
            else
            {
                link_Previous.Enabled = true;
                link_Next.Enabled = true;
            }
        }

        private void _getMoreData(int current_page)
        {
            try
            {
                RTAF_DATA data = (RTAF_DATA)Session["RTAF_DATA"];

                if (current_page > 1)
                {
                    int row_str = (current_page - 1) * 20;

                    link_Previous.Enabled = true;

                    List<RTAF_DATA> list_data = new RTAFData_Managers().GetRTAFDataALL(data, row_str, 20);

                    Session["row_str"] = row_str;

                    Session["Person_Data_DB"] = list_data;
                }
                else
                {
                    link_Previous.Enabled = false;

                    List<RTAF_DATA> list_data = new RTAFData_Managers().GetRTAFDataALL(data, 0, 20);

                    Session["row_str"] = 0;

                    Session["Person_Data_DB"] = list_data;
                }

                int max_page = (int)Session["max_page"];

                if (current_page == max_page) { link_Next.Enabled = false; }
            }
            catch (Exception ex)
            {
                error = "Exception ===> Form_ComparePersonData ==> Form_Search_Person --> _getMoreData() ";
                Log_Error._writeErrorFile(error, ex);
            }
        }
    }
}