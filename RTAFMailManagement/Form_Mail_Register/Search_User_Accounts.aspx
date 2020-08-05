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
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:CheckBox ID="getAll_ChkBx" runat="server" CssClass="form-check-label" />
                                    <span class="form-check-label text-danger">&nbsp; ค้นหาทั้งหมด </span>
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
                                            <th style="vertical-align: text-top;"> Username </th>
                                            <th style="vertical-align: text-top;">สังกัด </th>
                                            <th style="vertical-align: text-top;">OU Name </th>
                                            <th style="vertical-align: text-top;">AD Status (DB) </th>
                                            <th style="vertical-align: text-top;">AD Status (Real)</th>
                                            <th style="width: 10%; vertical-align: text-top">วันที่ปรับปรุงข้อมูลล่าสุด </th>
                                            <th style="width: 10%; vertical-align: text-top;">อายุรหัสผ่าน (วัน) </th>
                                            <th style="width: 10%; vertical-align: text-top">วันที่เข้าระบบล่าสุด </th>
                                            <th style="width: 15%; vertical-align: text-top">สถานะ</th>
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

                                                string ogn_code = CryptographyCode.GenerateSHA512String(data.user_IdGvm);
                                        %>
                                        <tr style="text-align: center; vertical-align: text-top;">
                                            <td style="text-align: center;"><%= i+1 %></td>
                                            <td><a class="text-primary" href="Update_Users_Profile?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.user_IdGvm, data.user_IdCard) %>&mode=e" data-toggle="tooltip" data-placement="top" title="แก้ไขข้อมูล"> <%= data.Rank.rank_Name + data.user_FirstName + " " + data.user_LastName  %> </a> </td>
                                            <td><%= data.user_UserName %></td>
                                            <td><%= data.Unit.unit_Name %></td>
                                            <td><%= data.Unit.unit_OUName %></td>

                                            <td style="text-align: center;">
                                                <span class="<%= data.AD_status.AD_Status_Code == 2 ? "badge bg-success" : data.AD_status.AD_Status_Code == 3 ? "badge bg-danger" : "badge bg-warning" %>"><%= data.AD_status.AD_Status_Name %></span>
                                            </td>
                                            <td style="text-align: center;">
                                                <span class="<%= data.real_ad.AD_Enabled? "badge bg-success" : "badge bg-danger" %>"><%= data.real_ad.AD_Enabled? "Active" : "Disable" %></span>
                                            </td>
                                            <td><%= DateTimeUtility.convertDateTimeToPageRealServer(data.user_UpdateDate) %></td>
                                            <td <%= data.passdiff >= 150 && data.passdiff < 180 ? "style='color: #ebeb00;'" : data.passdiff >= 180 ? "style='color: #eb0000;'" : "style='color: #107500;'"  %>><%= data.passdiff %></td>
                                            <td><%= DateTimeUtility.convertDateTimeToPageRealServer(data.real_ad.AD_lastLogin) %></td>
                                            <td><%= data.user_status %></td>
                                            <td style="text-align: center;">
                                                <% 
                                                    if (data.real_ad.AD_Enabled)
                                                    {
                                                %>
                                                <a class="btn bg-gradient-danger btn-sm" href="ChangeADStatus?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.user_IdGvm, data.user_IdCard) %>&mode=d" data-toggle="tooltip" data-placement="top" title="ปิดการใช้งาน"><i class="fas fa-user-slash fa-fw"></i></a>
                                                <%  }
                                                    else
                                                    { %>
                                                <a class="btn bg-gradient-success btn-sm" href="ChangeADStatus?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.user_IdGvm, data.user_IdCard) %>&mode=e" data-toggle="tooltip" data-placement="top" title="เปิดการใช้งาน"><i class="fas fa-user fa-fw"></i></a>
                                                <%
                                                    }
                                                %>
                                            </td>
                                            <td style="text-align: center;">
                                                <a class="btn bg-gradient-warning btn-sm" href="Update_Users_Profile?code=<%= CryptographyCode.EncodeTOAddressBar(ogn_code, data.user_IdGvm, data.user_IdCard) %>&mode=e" data-toggle="tooltip" data-placement="top" title="แก้ไขข้อมูล"><i class="fas fa-edit fa-fw"></i></a>
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
                    </div>
                </div>

            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /.content -->

    </div>
    <!-- /.content-wrapper -->
</asp:Content>

