<%@ Page Title=":: Reset Password Service ::" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reset_Password_User_Fast.aspx.cs" Inherits="RTAFMailManagement.Form_Mail_Register.Reset_Password_User_Fast" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0 text-dark"><i class="fas fa-sync-alt"></i>&nbsp; :: รีเซตรหัสผ่าน ผู้ใช้งาน :: </h1>
                    </div>
                </div>
                <!-- /.row -->

                <div class="row">
                    <div class="card-body">
                        <div class="col-sm-6">
                            <asp:Panel ID="success_panel" runat="server" Visible="false">
                                <div class="alert alert-success alert-dismissible">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    <h5><i class="icon fas fa-check"></i>แจ้งเตือน!</h5>
                                    <asp:Label ID="success_Lbl" runat="server"></asp:Label>
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="bad_panel" runat="server" Visible="false">
                                <div class="alert alert-danger alert-dismissible">
                                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                    <h5><i class="icon fas fa-ban"></i>แจ้งเตือน!</h5>
                                    <asp:Label ID="bad_Lbl" runat="server"></asp:Label>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>

            </div>
            <!-- /.container-fluid -->
        </div>
    <!-- /.content-header -->

    <!-- Main content -->
    <div class="content">
        <div class="container-fluid">

            <!-- Horizontal Form -->
            <div class="card card-danger">
                <div class="card-header">
                    <h3 class="card-title"><i class="fas fa-sync-alt"></i>&nbsp; :: รีเซตรหัสผ่าน ผู้ใช้งาน  :: </h3>
                    <div class="card-tools">
                        <asp:LinkButton ID="Close_Btn" runat="server" CssClass="btn btn-tool" OnClick="Cancel_Btn_Click"> <i class="fas fa-times"></i> </asp:LinkButton>
                    </div>
                </div>
                <!-- /.card-header -->
                <!-- form start -->
                <div class="form-horizontal">
                    <div class="card-body">

                        <div class="card card-info">
                            <div class="card-header">
                                <h3 class="card-title"><i class="fas fa-user-tag"></i>&nbsp; :: ข้อมูล :: </h3>
                            </div>
                            <!-- /.card-header -->
                            <!-- form start -->
                            <div class="form-horizontal">
                                <div class="card-body">
                                    <div class="form-group row">
                                        <div class="col-sm-3">
                                            <asp:Label ID="Username_Lbl" runat="server"> ชื่อผู้ใช้ ( Username ) </asp:Label>
                                            <asp:TextBox ID="Username_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Label ID="Password_Lbl" runat="server"> รหัสผ่าน ( Password )  </asp:Label>
                                            <asp:TextBox ID="Password_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.card-body -->
                            </div>
                        </div>

                    </div>
                    <!-- /.card-body -->
                    <div class="card-footer">
                        <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn bg-gradient-primary" OnClick="Save_Btn_Click"> <i class="fas fa-save fa-fw"></i>&nbsp; บันทึกข้อมูล </asp:LinkButton>
                        <asp:LinkButton ID="Cancel_Btn" runat="server" CssClass="btn bg-gradient-warning" OnClick="Cancel_Btn_Click"> <i class="fas fa-window-close"></i>&nbsp; ยกเลิก </asp:LinkButton>
                    </div>
                    <!-- /.card-footer -->
                </div>
            </div>
            <!-- /.card -->

        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /.content -->

    </div>
    <!-- /.content-wrapper -->
</asp:Content>
