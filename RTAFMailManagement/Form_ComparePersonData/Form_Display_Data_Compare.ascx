<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form_Display_Data_Compare.ascx.cs" Inherits="RTAFMailManagement.Form_ComparePersonData.Form_Display_Data_Compare" %>

<%@ Import Namespace="RTAFMailManagement.Class" %>
<%@ Import Namespace="RTAFMailManagement.Global_Class" %>

<%
    if (Session["found_data"] != null)
    {

%>

<div class="card">
    <div class="card-header">
        <h3 class="card-title">:: ข้อมูลกำลังพลจาก WEB SERVICE :: </h3>

        <div class="card-tools">
            <ul class="pagination pagination-sm float-right">
                <li class="page-item">
                    <asp:LinkButton ID="Compare_Data_Btn" runat="server" CssClass="btn bg-gradient-warning" OnClick="Compare_Data_Btn_Click"><i class="fa fa-code-branch fa-fw"></i> ปรับปรุงข้อมูล </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <!-- /.card-header -->
    <div class="card-body">
        <table id="service_table" class="table table-bordered table-striped" style="font-size: 9pt;">
            <thead>
                <tr>
                    <th style="text-align: center; background-color: dodgerblue; border-right: 2px solid #000000;" colspan="12">ข้อมูลใหม่ [ WEB Service ] </th>

                    <th style="text-align: center; background-color: crimson; border-left: 2px solid #000000;" colspan="11">ข้อมูลเก่า [ RTAF DB ]</th>
                </tr>
                <tr>
                    <th style="text-align: center; background-color: dodgerblue;">#</th>
                    <th style="text-align: center; background-color: dodgerblue;">รหัสบัตร</th>
                    <th style="text-align: center; background-color: dodgerblue;">10 หลัก</th>
                    <th style="text-align: center; background-color: dodgerblue;">ยศ</th>
                    <th style="text-align: center; background-color: dodgerblue;">ชื่อ</th>
                    <th style="text-align: center; background-color: dodgerblue;">นามสกุล</th>
                    <th style="text-align: center; background-color: dodgerblue;">ชื่อ ( Eng ) </th>
                    <th style="text-align: center; background-color: dodgerblue;">นามสกุล ( Eng ) </th>
                    <th style="text-align: center; background-color: dodgerblue;">วันเกิด</th>
                    <th style="text-align: center; background-color: dodgerblue;">สังกัด</th>
                    <th style="text-align: center; background-color: dodgerblue;">ตำแหน่ง</th>
                    <th style="text-align: center; background-color: dodgerblue;">สถานะ</th>
                    <th style="text-align: center; background-color: dodgerblue;">สถานะ code </th>
                    <th style="text-align: center; background-color: dodgerblue; border-right: 2px solid #000000;">ประเภทบุคคล code </th>

                    <th style="text-align: center; background-color: crimson; border-left: 2px solid #000000;">รหัสบัตร</th>
                    <th style="text-align: center; background-color: crimson;">10 หลัก</th>
                    <th style="text-align: center; background-color: crimson;">ยศ</th>
                    <th style="text-align: center; background-color: crimson;">ชื่อ</th>
                    <th style="text-align: center; background-color: crimson;">นามสกุล</th>
                    <th style="text-align: center; background-color: crimson;">ชื่อ ( Eng ) </th>
                    <th style="text-align: center; background-color: crimson;">นามสกุล ( Eng ) </th>
                    <th style="text-align: center; background-color: crimson;">วันเกิด</th>
                    <th style="text-align: center; background-color: crimson;">สังกัด</th>
                    <th style="text-align: center; background-color: crimson;">ตำแหน่ง</th>
                    <th style="text-align: center; background-color: crimson;">สถานะ</th>
                    <th style="text-align: center; background-color: crimson;">สถานะ code </th>
                    <th style="text-align: center; background-color: crimson;">ประเภทบุคคล code </th>
                </tr>
            </thead>
            <tbody>
                <% 
                    List<Compare_Data> list_data = (List<Compare_Data>)Session["found_data"];

                    for (int i = 0; i < list_data.Count(); i++)
                    {
                        Compare_Data data = list_data[i];
                %>
                <tr>
                    <td style="text-align: center;"><%= i+1 %></td>
                    <td><%= data.sevice_data.RTAF_person_IdCard %></td>
                    <td><%= General_Functions.subStringIdGvm(data.sevice_data.RTAF_person_IdGvm) %></td>
                    <td><%= data.sevice_data.RTAF_person_Rank.Rank_Name %></td>
                    <td><%= data.sevice_data.RTAF_person_FirstName %></td>
                    <td><%= data.sevice_data.RTAF_person_LastName %></td>
                    <td><%= data.sevice_data.RTAF_person_FirstName_Eng %></td>
                    <td><%= data.sevice_data.RTAF_person_LastName_Eng %></td>
                    <td><%= data.sevice_data.RTAF_person_BirthDate %></td>
                    <td><%= data.sevice_data.RTAF_person_Unit.Unit_Name %></td>
                    <td><%= data.sevice_data.RTAF_person_Position %></td>
                    <td><%= data.sevice_data.RTAF_person_Status.RTAF_status_Name %></td>
                    <td><%= data.sevice_data.RTAF_person_Status.RTAF_status_Code %></td>
                    <td style="border-right: 2px solid #000000;"><%= data.sevice_data.RTAF_person_type.Person_Type_Id %></td>

                    <td style="border-left: 2px solid #000000;"><%= data.db_data.RTAF_person_IdCard %></td>
                    <td><%= data.db_data.RTAF_person_IdGvm %></td>
                    <td><%= data.db_data.RTAF_person_Rank.Rank_Name %></td>
                    <td><%= data.db_data.RTAF_person_FirstName %></td>
                    <td><%= data.db_data.RTAF_person_LastName %></td>
                    <td><%= data.db_data.RTAF_person_FirstName_Eng %></td>
                    <td><%= data.db_data.RTAF_person_LastName_Eng %></td>
                    <td><%= DateTimeUtility.convertDateToPageRealServer(data.db_data.RTAF_person_BirthDate) %></td>
                    <td><%= data.db_data.RTAF_person_Unit.Unit_Name %></td>
                    <td><%= data.db_data.RTAF_person_Position %></td>
                    <td><%= data.db_data.RTAF_person_Status.RTAF_status_Name %></td>
                    <td><%= data.db_data.RTAF_person_Status.RTAF_status_Code %></td>
                    <td><%= data.db_data.RTAF_person_type.Person_Type_Id %></td>
                </tr>
                <%
                    }
                %>
            </tbody>
        </table>
    </div>

    <!-- /.card-body -->
    <div class="card-footer">
        <ul class="pagination pagination-sm m-0 float-right">
        </ul>
    </div>
</div>
<!-- /.card -->
<%  
    }
%>
