<%@ Page Title=" RTAF E-Mail Registration Management System " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Form_Edit_PersonData.aspx.cs" Inherits="RTAFMailManagement.Form_ComparePersonData.Form_Edit_PersonData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0 text-dark"><i class="fas fa-user-edit"></i>&nbsp; :: แก้ไขข้อมูลกำลังพล ::</h1>
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
                        <h3 class="card-title"><i class="fas fa-user-edit"></i>&nbsp; :: แก้ไขข้อมูลกำลังพล ::</h3>
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
                                    <asp:Label ID="IdGvm_Lbl" runat="server"> เลขบัตรข้าราชการ 10 หลัก </asp:Label>
                                    <asp:TextBox ID="IdGvm_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="Rank_Eng_Lbl" runat="server"> ยศ (ENG) </asp:Label>
                                    <asp:TextBox ID="Rank_Eng_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="FName_Eng_Lbl" runat="server"> ชื่อ (ENG) </asp:Label>
                                    <asp:TextBox ID="FName_Eng_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="LName_Eng_Lbl" runat="server"> นามสกุล (ENG) </asp:Label>
                                    <asp:TextBox ID="LName_Eng_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">

                                <div class="col-sm-3">
                                    <asp:Label ID="Birthday_Date_Lbl" runat="server"> วันเดือนปีเกิด </asp:Label>
                                    <div class="input-group" id="Birthday_Date">
                                        <asp:TextBox ID="Birthday_Date_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="fa fa-calendar fa-fw"></i></span>
                                        </div>
                                    </div>
                                    <script type="text/javascript">
                                        $(function () {

                                            $.datetimepicker.setLocale('th'); // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.

                                            // กรณีใช้แบบ input
                                            $("#Birthday_Date").datetimepicker({
                                                timepicker: false,
                                                format: 'd/m/Y',  // กำหนดรูปแบบวันที่ ที่ใช้ เป็น 00-00-0000			
                                                lang: 'th',  // ต้องกำหนดเสมอถ้าใช้ภาษาไทย และ เป็นปี พ.ศ.
                                                onSelectDate: function (dp, $input) {
                                                    var yearT = new Date(dp).getFullYear() - 0;
                                                    var yearTH = yearT + 543;
                                                    var fulldate = $input.val();
                                                    var fulldateTH = fulldate.replace(yearT, yearTH);
                                                    $("<%= "#" + Birthday_Date_TBx.ClientID %>").val(fulldateTH);
                                                },
                                            });

                                            // กรณีใช้กับ input ต้องกำหนดส่วนนี้ด้วยเสมอ เพื่อปรับปีให้เป็น ค.ศ. ก่อนแสดงปฏิทิน
                                            $("<%= "#" + Birthday_Date_TBx.ClientID %>").on("mouseenter mouseleave", function (e) {
                                                var dateValue = $(this).val();
                                                if (dateValue != "") {
                                                    var arr_date = dateValue.split("-"); // ถ้าใช้ตัวแบ่งรูปแบบอื่น ให้เปลี่ยนเป็นตามรูปแบบนั้น
                                                    // ในที่นี้อยู่ในรูปแบบ 00-00-0000 เป็น d-m-Y  แบ่งด่วย - ดังนั้น ตัวแปรที่เป็นปี จะอยู่ใน array
                                                    //  ตัวที่สอง arr_date[2] โดยเริ่มนับจาก 0 
                                                    if (e.type == "mouseenter") {
                                                        var yearT = arr_date[2] - 543;
                                                    }
                                                    if (e.type == "mouseleave") {
                                                        var yearT = parseInt(arr_date[2]) + 543;
                                                    }
                                                    dateValue = dateValue.replace(arr_date[2], yearT);
                                                    $(this).val(dateValue);
                                                }
                                            });
                                        });
                                    </script>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="Person_Status_Lbl" runat="server"> สถานะกำลังพล </asp:Label>
                                    <asp:DropDownList ID="Person_Status_DDL" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <asp:Label ID="Units_Lbl" runat="server">สังกัด</asp:Label>
                                    <asp:DropDownList ID="Units_DDL" runat="server" CssClass="form-control select2"></asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <asp:Label ID="Position_Lbl" runat="server"> ตำแหน่ง </asp:Label>
                                    <asp:TextBox ID="Position_TBx" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:LinkButton ID="Save_Btn" runat="server" CssClass="btn bg-gradient-primary" OnClick="Save_Btn_Click"> <i class="fa fa-save fa-fw"></i>&nbsp; บันทึกข้อมูล </asp:LinkButton>
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
