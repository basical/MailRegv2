<%@ Page Title=" RTAF E-Mail Registration Management System " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update_User_Account_CPDTSV.aspx.cs" Inherits="RTAFMailManagement.Form_Mail_Register.Update_User_Account_CPDTSV" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0 text-dark"><i class="fas fa-sync-alt"></i>&nbsp; :: อัพเดต ผู้ใช้งาน :: </h1>

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
                <div class="card card-warning">
                    <div class="card-header">
                        <h3 class="card-title"><i class="fas fa-sync-alt"></i>&nbsp; :: อัพเดต ผู้ใช้งาน  :: </h3>
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
                                                <asp:Label ID="All_Row_Lbl" runat="server"> Row Count </asp:Label>
                                                <asp:TextBox ID="All_Row_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Row_Count_Lbl" runat="server"> Row Success </asp:Label>
                                                <asp:TextBox ID="Row_Count_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Row_Fail_Count_Lbl" runat="server"> Row Fails </asp:Label>
                                                <asp:TextBox ID="Row_Fail_Count_TBx" runat="server" CssClass="form-control"></asp:TextBox>
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

