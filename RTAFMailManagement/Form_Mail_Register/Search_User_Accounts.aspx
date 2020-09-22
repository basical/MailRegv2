<%@ Page Title=" RTAF E-Mail Registration Management System " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_User_Accounts.aspx.cs" Inherits="RTAFMailManagement.Form_Mail_Register.Search_User_Accounts" %>

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
                        <h1 class="m-0 text-dark"><i class="fas fa-search fa-fw"></i>&nbsp; :: ค้นหาข้อมูลบัญชีผู้ใช้ ::</h1>
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
                        <h3 class="card-title"><i class="fas fa-search fa-fw"></i>&nbsp; :: ค้นหาข้อมูลบัญชีผู้ใช้ ::</h3>
                    </div>
                    <!-- /.card-header -->
                    <!-- form start -->
                    <div class="form-horizontal">
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:Label ID="Username_Lbl" runat="server"> Username </asp:Label>
                                    <asp:TextBox ID="Username_TBx" runat="server" CssClass="form-control" onkeypress="return SearchEnterEvent(event)"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="IdCard_Lbl" runat="server"> เลขบัตรประจำตัวประชาชน </asp:Label>
                                    <asp:TextBox ID="IdCard_TBx" runat="server" CssClass="form-control" onkeypress="return SearchEnterEvent(event)"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="IdGvm_Lbl" runat="server"> เลขบัตรข้าราชการ 10 หลัก </asp:Label>
                                    <asp:TextBox ID="IdGvm_TBx" runat="server" CssClass="form-control" onkeypress="return SearchEnterEvent(event)"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:Label ID="Rank_Lbl" runat="server"> ยศ </asp:Label>
                                    <asp:DropDownList ID="Rank_DDL" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="FName_Lbl" runat="server"> ชื่อ </asp:Label>
                                    <asp:TextBox ID="FName_TBx" runat="server" CssClass="form-control" onkeypress="return SearchEnterEvent(event)"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="LName_Lbl" runat="server"> นามสกุล </asp:Label>
                                    <asp:TextBox ID="LName_TBx" runat="server" CssClass="form-control" onkeypress="return SearchEnterEvent(event)"></asp:TextBox>
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
                            <asp:LinkButton ID="Add_Btn" runat="server" CssClass="btn bg-gradient-success float-right" OnClick="Add_Btn_Click"> <i class="fas fa-user-plus fa-fw"></i>&nbsp; Add User Account </asp:LinkButton>
                        </div>
                        <!-- /.card-footer -->

                        <script type="text/javascript">
                            function SearchEnterEvent(e) {
                                if (e.keyCode == 13) {
                                    __doPostBack('<%=Search_Btn.UniqueID%>', "");
                                }
                            }
                        </script>
                    </div>
                </div>
                <!-- /.card -->

                <!-- Result Search -->
                <div class="row">
                    <!-- table left -->
                    <div class="col-md-12">
                        <%
                            if (Session["List_User_Acc"] != null)
                            {
                        %>
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">:: รายชื่อบัญชีผู้ใช้ :: </h3>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <table id="service_table" class="table table-bordered table-striped">
                                    <thead>
                                        <tr style="text-align: center;">
                                            <th style="width: 5%; vertical-align: text-top;">#</th>
                                            <th style="width: 15%; vertical-align: text-top;">ยศ ชื่อ-นามสกุล </th>
                                            <th style="vertical-align: text-top;">Username </th>
                                            <th style="vertical-align: text-top;">สังกัด </th>
                                            <th style="vertical-align: text-top;">OU Name </th>
                                            <th style="vertical-align: text-top;">AD Status (DB) </th>
                                            <th style="vertical-align: text-top;">AD Status (Real)</th>
                                            <th style="width: 10%; vertical-align: text-top">วันที่ปรับปรุงข้อมูลล่าสุด </th>
                                            <th style="width: 10%; vertical-align: text-top;">อายุรหัสผ่าน (วัน) </th>
                                            <th style="width: 10%; vertical-align: text-top">วันที่เข้าระบบล่าสุด </th>
                                            <th style="width: 15%; vertical-align: text-top">สถานะกำลังพล</th>
                                            <th></th>
                                            <th></th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <% 
                                            List<Users> list_data = (List<Users>)Session["List_User_Acc"];

                                            for (int i = 0; i < list_data.Count(); i++)
                                            {
                                                Users data = list_data[i];

                                                string ogn_code = CryptographyCode.GenerateSHA512String(data.User_IdGvm);
                                        %>
                                        <tr style="text-align: center; vertical-align: text-top;">
                                            <td style="text-align: center;"><%= i+1 %></td>
                                            <td><a id="user_info" class="text-primary" href="Update_Users_Profile?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.User_IdGvm, data.User_IdCard, data.User_id.ToString()) %>&mode=e" data-toggle="tooltip" data-placement="top" title="แก้ไขข้อมูล"><%= data.User_Rank.Rank_Name + data.User_FirstName + " " + data.User_LastName  %> </a></td>
                                            <td><%= data.User_UserName %></td>
                                            <td><%= data.User_Unit.Unit_Name %></td>
                                            <td><%= data.User_Unit.Unit_OUName %></td>

                                            <td style="text-align: center;">
                                                <span class="<%= data.User_ADStatus.AD_Status_Code == 2 ? "badge bg-success" : data.User_ADStatus.AD_Status_Code == 3 ? "badge bg-danger" : "badge bg-warning" %>"><%= data.User_ADStatus.AD_Status_Name %></span>
                                            </td>
                                            <td style="text-align: center;">
                                                <span class="<%= data.User_Real_AD != null? data.User_Real_AD.AD_Enabled? "badge bg-success" : "badge bg-danger" : "badge bg-danger" %>"><%= data.User_Real_AD != null? data.User_Real_AD.AD_Enabled? "Active" : "Disable" : "Disable" %></span>
                                            </td>
                                            <td><%= data.User_Real_AD != null? DateTimeUtility.convertDateTimeToPageRealServer(data.User_Real_AD.AD_Nv_PasswordLastChanged) : "" %></td>
                                            <td <%= data.User_Real_AD != null? data.User_Real_AD.passdiff >= 150 && data.User_Real_AD.passdiff < 180 ? "style='color: #ebeb00;'" : data.User_Real_AD.passdiff >= 180 ? "style='color: #eb0000;'" : "style='color: #107500;'" : "style='color: #eb0000;'" %>><%= data.User_Real_AD != null? data.User_Real_AD.passdiff : 0 %></td>
                                            <td><%= data.User_Real_AD != null? DateTimeUtility.convertDateTimeToPageRealServer(data.User_Real_AD.AD_Nv_LastLogin) : "" %></td>
                                            <td><%= data.User_status_msg %></td>
                                            <td style="text-align: center;">
                                                <a class="btn bg-gradient-info btn-sm" href="AD_Account_information?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.User_IdGvm, data.User_IdCard, data.User_id.ToString()) %>&mode=e" data-toggle="tooltip" data-placement="top" title="ข้อมูล User ใน AD Server"><i class="far fa-address-card fa-fw"></i></a>
                                            </td>
                                            <td style="text-align: center;">
                                                <% 
                                                    if (data.User_Real_AD != null)
                                                    {
                                                        if (data.User_Real_AD.AD_Enabled)
                                                        {
                                                %>
                                                <a class="btn bg-gradient-danger btn-sm" href="ChangeADStatus?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.User_IdGvm, data.User_IdCard, data.User_id.ToString()) %>&mode=d" data-toggle="tooltip" data-placement="top" title="ปิดการใช้งาน"><i class="fas fa-user-slash fa-fw"></i></a>
                                                <%  }
                                                        else
                                                        { 
                                                %>
                                                <a class="btn bg-gradient-success btn-sm" href="ChangeADStatus?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.User_IdGvm, data.User_IdCard, data.User_id.ToString()) %>&mode=e" data-toggle="tooltip" data-placement="top" title="เปิดการใช้งาน"><i class="fas fa-user fa-fw"></i></a>
                                                <%
                                                        }
                                                    }
                                                %>
                                            </td>
                                            <td style="text-align: center;">
                                                <a class="btn bg-gradient-warning btn-sm" href="Update_Users_Profile?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.User_IdGvm, data.User_IdCard, data.User_id.ToString()) %>&mode=e" data-toggle="tooltip" data-placement="top" title="แก้ไขข้อมูล"><i class="fas fa-edit fa-fw"></i></a>
                                            </td>
                                        </tr>
                                        <%
                                            }
                                        %>
                                    </tbody>
                                </table>
                            </div>

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

