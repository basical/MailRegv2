<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form_Display_Data_DB.ascx.cs" Inherits="RTAFMailManagement.Form_ComparePersonData.Form_Display_Data_DB" %>

<%@ Import Namespace="RTAFMailManagement.Class" %>
<%@ Import Namespace="RTAFMailManagement.Global_Class" %>

<%
    if (Session["data_by_unit"] != null)
    {

%>

<div class="card">
    <div class="card-header">
        <h3 class="card-title">:: ข้อมูลกำลังพลจากฐ้านข้อมูล RTAFDB :: </h3>
    </div>
    <!-- /.card-header -->
    <div class="card-body">
        <table id="service_table" class="table table-bordered table-striped">
            <thead>
                <tr>
                    <th style="width: 5%; text-align: center;">#</th>
                    <th style="text-align: center;">รหัสบัตรประชาชน</th>
                    <th style="text-align: center;">เลข 10 หลัก</th>
                    <th style="text-align: center;">ยศ</th>
                    <th style="width: 10%; text-align: center;">ชื่อ</th>
                    <th style="width: 10%; text-align: center;">นามสกุล</th>
                    <th style="width: 10%; text-align: center;">ชื่อ ( Eng ) </th>
                    <th style="width: 10%; text-align: center;">นามสกุล ( Eng ) </th>
                    <th style="text-align: center;">วันเกิด</th>
                    <th style="text-align: center;">สังกัด</th>
                    <th style="text-align: center;">ตำแหน่ง</th>
                    <th style="text-align: center;">สถานะ</th>
                </tr>
            </thead>
            <tbody>
                <% 
                    List<RTAF_DATA> list_data = (List<RTAF_DATA>)Session["data_by_unit"];

                    for (int i = 0; i < list_data.Count(); i++)
                    {
                        RTAF_DATA data = list_data[i];
                %>
                <tr>
                    <td style="text-align: center;"><%= i+1 %></td>
                    <td><%= data.rtaf_person_IdCard %></td>
                    <td><%= data.rtaf_person_IdGvm %></td>
                    <td><%= data.Rank.rank_Name %></td>
                    <td><%= data.rtaf_person_FirstName %></td>
                    <td><%= data.rtaf_person_LastName %></td>
                    <td><%= data.rtaf_person_FirstName_Eng %></td>
                    <td><%= data.rtaf_person_LastName_Eng %></td>
                    <td><%= DateTimeUtility.convertDateToPageRealServer(data.rtaf_person_BirthDate) %></td>
                    <td><%= data.Unit.unit_Name %></td>
                    <td><%= data.rtaf_person_Position %></td>
                    <td><%= data.rtaf_person_status %></td>
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
                int page = 1;
                for (int i = 0; i < list_data.Count(); i++)
                {
                    if (i % 20 == 0)
                    {
            %>
            <li class="page-item"><a class="page-link" href="#"><%= page %></a></li>
            <% 
                        page++;
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
