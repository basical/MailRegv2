﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form_Display_Data_Service.ascx.cs" Inherits="RTAFMailManagement.Form_ComparePersonData.Form_Display_Data_Service" %>

<%@ Import Namespace="RTAFMailManagement.Class" %>
<%@ Import Namespace="RTAFMailManagement.Global_Class" %>

<%
    if (Session["service_data"] != null)
    {

%>

<div class="card">
    <div class="card-header">
        <h3 class="card-title">:: ข้อมูลกำลังพลจาก WEB SERVICE :: </h3>
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
                    <th style="text-align: center;">สถานะ code </th>
                    <th style="text-align: center;">ประเภทบุคคล code </th>
                </tr>
            </thead>
            <tbody>
                <% 
                    List<RTAF_DATA> list_data = (List<RTAF_DATA>)Session["service_data"];

                    for (int i = 0; i < list_data.Count(); i++)
                    {
                        RTAF_DATA data = list_data[i];
                %>
                <tr>
                    <td style="text-align: center;"><%= i+1 %></td>
                    <td><%= data.RTAF_person_IdCard %></td>
                    <td><%= General_Functions.subStringIdGvm(data.RTAF_person_IdGvm) %></td>
                    <td><%= data.RTAF_person_Rank.Rank_Name %></td>
                    <td><%= data.RTAF_person_FirstName %></td>
                    <td><%= data.RTAF_person_LastName %></td>
                    <td><%= data.RTAF_person_FirstName_Eng %></td>
                    <td><%= data.RTAF_person_LastName_Eng %></td>
                    <td><%= data.RTAF_person_BirthDate %></td>
                    <td><%= data.RTAF_person_Unit.Unit_Name %></td>
                    <td><%= data.RTAF_person_Position %></td>
                    <td><%= data.RTAF_person_Status.RTAF_status_Name %></td>
                    <td><%= data.RTAF_person_Status.RTAF_status_Code %></td>
                    <td><%= data.RTAF_person_type.Person_Type_Id %></td>
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

