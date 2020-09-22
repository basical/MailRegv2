<%@ Page Title=" RTAF E-Mail Registration Management System " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Form_Search_PersonData.aspx.cs" Inherits="RTAFMailManagement.Form_ComparePersonData.Form_Search_PersonData" %>

<%@ Register TagPrefix="service_page" TagName="Tab_service_page" Src="Form_Display_Data_Service.ascx" %>
<%@ Register TagPrefix="db_page" TagName="Tab_db_page" Src="Form_Display_Data_DB.ascx" %>
<%@ Register TagPrefix="compare_page" TagName="Tab_compare_page" Src="Form_Display_Data_Compare.ascx" %>
<%@ Register TagPrefix="import_page" TagName="Tab_import_page" Src="Form_Display_Data_Import.ascx" %>

<%@ Import Namespace="RTAFMailManagement.Class" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0 text-dark">:: ข้อมูลกำลังพลจาก WebService ::</h1>
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
                        <h3 class="card-title">:: ค้นหา ::</h3>
                    </div>
                    <!-- /.card-header -->
                    <!-- form start -->
                    <div class="form-horizontal">
                        <div class="card-body">
                            <div class="form-group row">
                                <div class="col-sm-4">
                                    <asp:Label ID="Units_Lbl" runat="server">สังกัด</asp:Label>
                                    <asp:DropDownList ID="Units_DDL" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:LinkButton ID="Search_rtaf_data_Btn" runat="server" CssClass="btn bg-gradient-primary" OnClick="Search_rtaf_data_Btn_Click"> <i class="fa fa-search fa-fw"></i> ค้นหาข้อมูล </asp:LinkButton>
                            <asp:LinkButton ID="OneClick_All_Btn" runat="server" CssClass="btn bg-gradient-danger float-right" OnClick="OneClick_All_Btn_Click"> <i class="fa fa-download fa-fw"></i> Download ข้อมุลทั้งหมด  </asp:LinkButton>
                        </div>
                        <!-- /.card-footer -->
                    </div>
                </div>
                <!-- /.card -->


                <%
                    if (Session["service_data"] != null && Session["service_data"] != null && Session["service_data"] != null && Session["service_data"] != null)
                    {

                        List<RTAF_DATA> service_data = (List<RTAF_DATA>)Session["service_data"];
                        List<RTAF_DATA> data_by_unit = (List<RTAF_DATA>)Session["data_by_unit"];
                        List<Compare_Data> found_data = (List<Compare_Data>)Session["found_data"];
                        List<RTAF_DATA> nfound_data = (List<RTAF_DATA>)Session["nfound_data"];
                %>
                <!-- Result Search -->
                <div class="row">
                    <!-- table left -->
                    <div class="col-md-12">

                        <div class="card card-primary card-tabs">
                            <div class="card-header p-0 pt-1">
                                <ul class="nav nav-tabs" id="custom-tabs-one-tab" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" id="custom-tabs-one-home-tab" data-toggle="pill" href="#custom-tabs-one-home" role="tab" aria-controls="custom-tabs-one-home" aria-selected="true">ข้อมูลจาก Web Service [ <%= service_data.Count() %> ] record </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="custom-tabs-one-profile-tab" data-toggle="pill" href="#custom-tabs-one-profile" role="tab" aria-controls="custom-tabs-one-profile" aria-selected="false">ข้อมูลจาก DB  [ <%= data_by_unit.Count() %> ] record </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="custom-tabs-one-messages-tab" data-toggle="pill" href="#custom-tabs-one-messages" role="tab" aria-controls="custom-tabs-one-messages" aria-selected="false">ข้อมูลรอแก้ไข [ <%= found_data.Count() %> ] record </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="custom-tabs-one-settings-tab" data-toggle="pill" href="#custom-tabs-one-settings" role="tab" aria-controls="custom-tabs-one-settings" aria-selected="false">ข้อมูลรอนำเข้า [ <%= nfound_data.Count() %> ] record </a>
                                    </li>
                                </ul>
                            </div>
                            <div class="card-body">
                                <div class="tab-content" id="custom-tabs-one-tabContent">
                                    <div class="tab-pane fade show active" id="custom-tabs-one-home" role="tabpanel" aria-labelledby="custom-tabs-one-home-tab">
                                        <!-- Tab MenuBar -->
                                        <service_page:Tab_service_page ID="page_tab_1" runat="server" />

                                        <!-- ./Tab MenuBar -->

                                    </div>
                                    <div class="tab-pane fade" id="custom-tabs-one-profile" role="tabpanel" aria-labelledby="custom-tabs-one-profile-tab">
                                        <!-- Tab MenuBar -->
                                        <db_page:Tab_db_page ID="page_tab_2" runat="server" />

                                        <!-- ./Tab MenuBar -->

                                    </div>
                                    <div class="tab-pane fade" id="custom-tabs-one-messages" role="tabpanel" aria-labelledby="custom-tabs-one-messages-tab">
                                        <!-- Tab MenuBar -->
                                        <compare_page:Tab_compare_page ID="page_tab_3" runat="server" />

                                        <!-- ./Tab MenuBar -->

                                    </div>
                                    <div class="tab-pane fade" id="custom-tabs-one-settings" role="tabpanel" aria-labelledby="custom-tabs-one-settings-tab">
                                        <!-- Tab MenuBar -->
                                        <import_page:Tab_import_page ID="page_tab_4" runat="server" />

                                        <!-- ./Tab MenuBar -->

                                    </div>
                                </div>
                            </div>
                            <!-- /.card -->
                        </div>


                    </div>
                    <!-- /.col -->

                </div>
                <!-- /.Result Search -->
                <%
                    }
                %>
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content -->

    </div>
    <!-- /.content-wrapper -->

</asp:Content>
