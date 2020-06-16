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
                    <asp:LinkButton ID="Compare_Data_Btn" runat="server" CssClass="btn btn-block btn-warning" OnClick="Compare_Data_Btn_Click"><i class="fa fa-code-branch fa-fw"></i> ปรับปรุงข้อมูล </asp:LinkButton>
                </li>
            </ul>
        </div>
    </div>
    <!-- /.card-header -->
    <div class="card-body">
        <table id="service_table" class="table table-bordered table-striped" style="font-size: 7pt;">
            <thead>
                <tr>
                    <th style="text-align: center; background-color: dodgerblue; border-right: 2px solid #000000;" colspan="10">ข้อมูลใหม่ [ WEB Service ] </th>

                    <th style="text-align: center; background-color: crimson; border-left: 2px solid #000000;" colspan="9">ข้อมูลเก่า [ RTAF DB ]</th>
                </tr>
                <tr>
                    <th style="width: 2%; text-align: center; background-color: dodgerblue;">#</th>
                    <th style="width: 4%; text-align: center; background-color: dodgerblue;">รหัสบัตร</th>
                    <th style="width: 4%; text-align: center; background-color: dodgerblue;">10 หลัก</th>
                    <th style="width: 4%; text-align: center; background-color: dodgerblue;">ยศ</th>
                    <th style="width: 4%; text-align: center; background-color: dodgerblue;">ชื่อ</th>
                    <th style="width: 5%; text-align: center; background-color: dodgerblue;">นามสกุล</th>
                    <th style="width: 5%; text-align: center; background-color: dodgerblue;">วันเกิด</th>
                    <th style="width: 3%; text-align: center; background-color: dodgerblue;">สังกัด</th>
                    <th style="width: 10%; text-align: center; background-color: dodgerblue;">ตำแหน่ง</th>
                    <th style="width: 10%; text-align: center; background-color: dodgerblue; border-right: 2px solid #000000;">สถานะ</th>

                    <th style="width: 4%; text-align: center; background-color: crimson; border-left: 2px solid #000000;">รหัสบัตร</th>
                    <th style="width: 4%; text-align: center; background-color: crimson;">10 หลัก</th>
                    <th style="width: 4%; text-align: center; background-color: crimson;">ยศ</th>
                    <th style="width: 4%; text-align: center; background-color: crimson;">ชื่อ</th>
                    <th style="width: 5%; text-align: center; background-color: crimson;">นามสกุล</th>
                    <th style="width: 5%; text-align: center; background-color: crimson;">วันเกิด</th>
                    <th style="width: 3%; text-align: center; background-color: crimson;">สังกัด</th>
                    <th style="width: 10%; text-align: center; background-color: crimson;">ตำแหน่ง</th>
                    <th style="width: 10%; text-align: center; background-color: crimson;">สถานะ</th>
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
                    <td><%= data.sevice_data.rtaf_person_IdCard %></td>
                    <td><%= General_Functions.subStringIdGvm(data.sevice_data.rtaf_person_IdGvm) %></td>
                    <td><%= data.sevice_data.Rank.rank_Name %></td>
                    <td><%= data.sevice_data.rtaf_person_FirstName %></td>
                    <td><%= data.sevice_data.rtaf_person_LastName %></td>
                    <td><%= DateTimeUtility.convertDateToPageRealServer(data.sevice_data.rtaf_person_BirthDate) %></td>
                    <td><%= data.sevice_data.Unit.unit_Name %></td>
                    <td><%= data.sevice_data.rtaf_person_Position %></td>
                    <td style="border-right: 2px solid #000000;"><%= data.sevice_data.status %></td>

                    <td style="border-left: 2px solid #000000;"><%= data.db_data.rtaf_person_IdCard %></td>
                    <td><%= data.db_data.rtaf_person_IdGvm %></td>
                    <td><%= data.db_data.Rank.rank_Name %></td>
                    <td><%= data.db_data.rtaf_person_FirstName %></td>
                    <td><%= data.db_data.rtaf_person_LastName %></td>
                    <td><%= DateTimeUtility.convertDateToPageRealServer(data.db_data.rtaf_person_BirthDate) %></td>
                    <td><%= data.db_data.Unit.unit_Name %></td>
                    <td><%= data.db_data.rtaf_person_Position %></td>
                    <td><%= data.db_data.status %></td>
                </tr>
                <%
                    }
                %>
            </tbody>
        </table>
    </div>

    <!-- /.card-body -->
    <div class="card-footer clearfix">
        <ul class="pagination pagination-sm m-0 float-right">
            <% 
                int page_left = 1;
                for (int i = 0; i < list_data.Count(); i++)
                {
                    if (i % 20 == 0)
                    {
            %>
            <li class="page-item"><a class="page-link" href="#"><%= page_left %></a></li>
            <% 
                        page_left++;
                    }
                }
            %>
        </ul>
    </div>
</div>
<!-- /.card -->
<%  
    }
%>
