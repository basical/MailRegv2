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
    public partial class Search_User_Accounts : Page
    {
        private string error = string.Empty;

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
            /*try
            {
                string agree_no = Agree_No_TBx.Text;
                string agree_no_ref = Agree_No_Ref_TBx.Text;
                string idcard = Cust_Idcard_TBx.Text;
                string fname = Cust_FName_TBx.Text.Trim(' ');
                string lname = Cust_LName_TBx.Text.Trim(' ');
                string date_str = DateTimeUtility.convertDateToMYSQL(Agree_Date_str_TBx.Text);
                string date_end = DateTimeUtility.convertDateToMYSQL(Agree_Date_end_TBx.Text);
                string company_inline = _getCheckedBranch();
                string zone_id_inline = _getCheckedZone();
                string pay_id_inline = _getCheckedPaymentmethod();

                if (!string.IsNullOrEmpty(agree_no) || !string.IsNullOrEmpty(agree_no_ref) || !string.IsNullOrEmpty(idcard) || !string.IsNullOrEmpty(fname) || !string.IsNullOrEmpty(lname) || !string.IsNullOrEmpty(date_str) ||
                    !string.IsNullOrEmpty(date_end) || !string.IsNullOrEmpty(zone_id_inline) || !string.IsNullOrEmpty(company_inline))
                {

                    List<Agreements> list_data_all = agmt_mng.getAgreements(agree_no, agree_no_ref, idcard, fname, lname, date_str, date_end, company_inline, "", zone_id_inline, "", pay_id_inline, 0, 0);


                    int row = list_data_all.Count;

                    _pageCount(row);

                    List<Agreements> list_data = agmt_mng.getAgreements(agree_no, agree_no_ref, idcard, fname, lname, date_str, date_end, company_inline, "", zone_id_inline, "", pay_id_inline, 0, 20);

                    Session["agree_no"] = agree_no;
                    Session["agree_no_ref"] = agree_no_ref;
                    Session["idcard"] = idcard;
                    Session["fname"] = fname;
                    Session["lname"] = lname;
                    Session["date_str"] = date_str;
                    Session["date_end"] = date_end;
                    Session["company_inline"] = company_inline;
                    Session["zone_id_inline"] = zone_id_inline;
                    Session["pay_id_inline"] = pay_id_inline;
                    Session["row_str"] = 0;

                    Session["List_Agreements"] = list_data;
                }
            }
            catch (Exception ex)
            {
                error = "Exception ===> Form_Agreements ==> Search_Agreements --> _getAgreements() ";
                Log_Error._writeErrorFile(error, ex);
            }*/

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
            /*try
            {
                string agree_no = (string)Session["agree_no"];
                string agree_no_ref = (string)Session["agree_no_ref"];
                string idcard = (string)Session["idcard"];
                string fname = (string)Session["fname"];
                string lname = (string)Session["lname"];
                string date_str = (string)Session["date_str"];
                string date_end = (string)Session["date_end"];
                string company_inline = (string)Session["leasing_Code_inline"];
                string zone_id_inline = (string)Session["zone_id_inlinecompany_inline"];
                string agree_type_inline = (string)Session["agree_type_inline"];
                string pay_id_inline = (string)Session["pay_id_inline"];

                if (current_page > 1)
                {
                    int row_str = (current_page - 1) * 20;

                    link_Previous.Enabled = true;

                    List<Agreements> list_data = agmt_mng.getAgreements(agree_no, agree_no_ref, idcard, fname, lname, date_str, date_end, company_inline, "", zone_id_inline, "", pay_id_inline, row_str, 20);

                    Session["row_str"] = row_str;

                    Session["List_Agreements"] = list_data;
                }
                else
                {
                    link_Previous.Enabled = false;

                    List<Agreements> list_data = agmt_mng.getAgreements(agree_no, agree_no_ref, idcard, fname, lname, date_str, date_end, company_inline, "", zone_id_inline, "", pay_id_inline, 0, 20);

                    Session["row_str"] = 0;

                    Session["List_Agreements"] = list_data;
                }

                int max_page = (int)Session["max_page"];
                if (current_page == max_page) { link_Next.Enabled = false; }
            }
            catch (Exception ex)
            {
                error = "Exception ===> Form_Agreements ==> Search_Agreements --> _getMoreData() ";
                Log_Error._writeErrorFile(error, ex);
            }*/
        }
    }
}