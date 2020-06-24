<%@ Page Title=":: เพิ่มข้อมูลกำลังพล ::" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Form_Add_PersonData.aspx.cs" Inherits="RTAFMailManagement.Form_ComparePersonData.Form_Add_PersonData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0 text-dark">:: เพิ่มข้อมูลกำลังพล ::</h1>
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
                <div class="card card-info">
                    <div class="card-header">
                        <h3 class="card-title">:: <i class="fa fa-save fa-fw"></i> เพิ่มข้อมูล ::</h3>
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
                                <div class="col-sm-9">
                                    <asp:Label ID="Position_Lbl" runat="server"> ตำแหน่ง </asp:Label>
                                    <asp:TextBox ID="Position_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn btn-info" OnClick="Save_Btn_Click"> <i class="fa fa-save fa-fw"></i> บันทึก </asp:LinkButton>
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
