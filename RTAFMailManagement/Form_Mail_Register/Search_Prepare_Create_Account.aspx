<%@ Page Title=" RTAF E-Mail Registration Management System " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_Prepare_Create_Account.aspx.cs" Inherits="RTAFMailManagement.Form_Mail_Register.Search_Prepare_Create_Account" %>

<%@ Import Namespace="RTAFMailManagement.Class" %>
<%@ Import Namespace="RTAFMailManagement.Global_Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0 text-dark"><i class="fas fa-search-plus fa-fw"></i>&nbsp; :: ค้นหาข้อมูลกำลังพล ::</h1>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->

        <!-- Main content -->
        <div class="content">
            <div class="container-fluid">

                <!-- Horizontal Form -->
                <div class="card card-primary">
                    <div class="card-header">
                        <h3 class="card-title"><i class="fas fa-search-plus fa-fw"></i>&nbsp; :: ค้นหาข้อมูล ::</h3>
                    </div>
                    <!-- /.card-header -->
                    <!-- form start -->
                    <div class="form-horizontal">
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:Label ID="IdCard_Lbl" runat="server"> เลขบัตรประจำตัวประชาชน </asp:Label>
                                    <asp:TextBox ID="IdCard_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="IdGvm_Lbl" runat="server"> เลขบัตรข้าราชการ 10 หลัก </asp:Label>
                                    <asp:TextBox ID="IdGvm_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:Label ID="Rank_Lbl" runat="server"> ยศ </asp:Label>
                                    <asp:DropDownList ID="Rank_DDL" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="FName_Lbl" runat="server"> ชื่อ </asp:Label>
                                    <asp:TextBox ID="FName_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="LName_Lbl" runat="server"> นามสกุล </asp:Label>
                                    <asp:TextBox ID="LName_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:Label ID="Units_Lbl" runat="server">สังกัด</asp:Label>
                                    <asp:DropDownList ID="Units_DDL" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="Person_Status_Lbl" runat="server"> สถานะกำลังพล </asp:Label>
                                    <asp:DropDownList ID="Person_Status_DDL" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:LinkButton ID="Search_Btn" runat="server" CssClass="btn bg-gradient-primary" OnClick="Search_Btn_Click"> <i class="fas fa-search fa-fw"></i>&nbsp; ค้นหาข้อมูล </asp:LinkButton>
                            <asp:LinkButton ID="Cancel_Btn" runat="server" CssClass="btn bg-gradient-warning" OnClick="Cancel_Btn_Click"> <i class="fas fa-window-close"></i>&nbsp; ยกเลิก </asp:LinkButton>
                        </div>
                        <!-- /.card-footer -->
                    </div>
                </div>
                <!-- /.card -->

                <!-- Result Search -->
                <div class="row">
                    <!-- table left -->
                    <div class="col-md-12">
                        <%
                            if (Session["Person_Data_DB"] != null)
                            {
                        %>
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">:: ข้อมูลกำลังพลจากฐานข้อมูล RTAFDB :: </h3>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <table id="service_table" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th style="width: 5%; text-align: center;">#</th>
                                            <th style="width: 10%; text-align: center;">รหัสบัตรประชาชน</th>
                                            <th style="width: 10%; text-align: center;">เลข 10 หลัก</th>
                                            <th style="width: 10%; text-align: center;">ยศ</th>
                                            <th style="width: 10%; text-align: center;">ชื่อ</th>
                                            <th style="width: 10%; text-align: center;">นามสกุล</th>
                                            <th style="width: 5%; text-align: center;">วันเกิด</th>
                                            <th style="width: 10%; text-align: center;">สังกัด</th>
                                            <th style="width: 20%; text-align: center;">ตำแหน่ง</th>
                                            <th style="width: 15%; text-align: center;">สถานะ</th>
                                            <th style="width: 5%; text-align: center;"></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <% 
                                            List<RTAF_DATA> list_data = (List<RTAF_DATA>)Session["Person_Data_DB"];

                                            for (int i = 0; i < list_data.Count(); i++)
                                            {
                                                RTAF_DATA data = list_data[i];

                                                string ogn_code = CryptographyCode.GenerateSHA512String(data.RTAF_person_IdGvm);
                                        %>
                                        <tr>
                                            <td style="text-align: center;"><%= i+1 %></td>
                                            <td><%= data.RTAF_person_IdCard %></td>
                                            <td><%= data.RTAF_person_IdGvm %></td>
                                            <td><%= data.RTAF_person_Rank.Rank_Name %></td>
                                            <td><%= data.RTAF_person_FirstName %></td>
                                            <td><%= data.RTAF_person_LastName %></td>
                                            <td><%= DateTimeUtility.convertDateToPageRealServer(data.RTAF_person_BirthDate) %></td>
                                            <td><%= data.RTAF_person_Unit.Unit_Name %></td>
                                            <td><%= data.RTAF_person_Position %></td>
                                            <td><%= data.RTAF_person_Status %></td>
                                            <td>
                                                <a class="btn bg-gradient-warning" href="Form_Edit_PersonData?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.RTAF_person_IdGvm, data.RTAF_person_IdCard, data.RTAF_person_Uid) %>&mode=e" data-toggle="tooltip" data-placement="top" title="แก้ไขข้อมูล"><i class="fa fa-edit fa-fw"></i></a>

                                            </td>
                                        </tr>
                                        <%
                                            }
                                        %>
                                    </tbody>
                                </table>
                            </div>

                            <!-- /.card-body -->
                            <!-- /.card-body -->
                            <div class="card-footer clearfix">
                                <div class="offset-md-3 col-md-6">
                                    <ul class="pagination offset-md-4">
                                        <li>
                                            <asp:LinkButton ID="link_Previous" runat="server" OnClick="link_Previous_Click" CssClass="btn btn-block btn-outline-primary"> <i class="fas fa-angle-left fa-fw"></i> ก่อนหน้า </asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:DropDownList ID="Paging_DDL" runat="server" CssClass="form-control custom-select" ForeColor="#cc0000" Font-Bold="true" OnSelectedIndexChanged="Paging_DDL_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="link_Next" runat="server" OnClick="link_Next_Click" CssClass="btn btn-block btn-outline-primary"> ต่อไป <i class="fas fa-angle-right fa-fw"></i> </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- /.card -->
                        <%  
                            }
                        %>
                    </div>
                </div>

            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content -->

    </div>
    <!-- /.content-wrapper -->
</asp:Content>
