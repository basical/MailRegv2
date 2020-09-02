<%@ Page Title=" RTAF E-Mail Registration Management System " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AD_Account_information.aspx.cs" Inherits="RTAFMailManagement.Form_Mail_Register.AD_Account_information" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0 text-dark"><i class="far fa-address-card"></i>&nbsp; :: AD Account Information :: </h1>

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
                        <h3 class="card-title"><i class="far fa-address-card"></i>&nbsp; :: AD Account Information :: </h3>
                        <div class="card-tools">
                            <asp:LinkButton ID="Close_Btn" runat="server" CssClass="btn btn-tool" OnClick="Close_Btn_Click"> <i class="fas fa-times"></i> </asp:LinkButton>
                        </div>
                    </div>
                    <!-- /.card-header -->
                    <!-- form start -->
                    <div class="form-horizontal">
                        <div class="card-body">
                            <div class="card card-info">
                                <div class="card-header">
                                    <h3 class="card-title"><i class="fas fa-user-tag"></i>&nbsp; :: Information :: </h3>
                                </div>
                                <!-- /.card-header -->
                                <!-- form start -->
                                <div class="form-horizontal">
                                    <div class="card-body">
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label1" runat="server" > AD_EmployeeId </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_EmployeeId" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label2" runat="server" > AD_SamAccountName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_SamAccountName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label3" runat="server" > AD_GivenName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_GivenName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label4" runat="server" > AD_DisplayName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_DisplayName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label5" runat="server" > AD_DistinguishedName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_DistinguishedName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label6" runat="server" > AD_EmailAddress </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_EmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label7" runat="server" > AD_HomeDirectory </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_HomeDirectory" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label8" runat="server" > AD_HomeDrive </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_HomeDrive" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label9" runat="server" > AD_LastBadPasswordAttempt </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_LastBadPasswordAttempt" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label10" runat="server" > AD_Name </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label11" runat="server" > AD_MiddleName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_MiddleName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label12" runat="server" > AD_Surname </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Surname" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label13" runat="server" > AD_PasswordNeverExpires </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_PasswordNeverExpires" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label14" runat="server" > AD_PasswordNotRequired </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_PasswordNotRequired" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label15" runat="server" > AD_ScriptPath </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_ScriptPath" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label16" runat="server" > AD_Enabled </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Enabled" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label17" runat="server" > AD_lastLogIn </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_lastLogIn" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label18" runat="server" > AD_lastPasswordSet </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_lastPasswordSet" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label19" runat="server" > AD_AccountExpirationDate </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_AccountExpirationDate" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label20" runat="server" > AD_AccountLockoutTime </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_AccountLockoutTime" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label21" runat="server" > AD_BadLogonCount </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_BadLogonCount" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label22" runat="server" > AD_UserCannotChangePassword </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_UserCannotChangePassword" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label23" runat="server" > AD_UserPrincipalName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_UserPrincipalName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label24" runat="server" > AD_Nv_AccountDisabled </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_AccountDisabled" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label25" runat="server" > AD_Nv_AccountExpirationDate </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_AccountExpirationDate" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label26" runat="server" > AD_Nv_ADsPath </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_ADsPath" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label27" runat="server" > AD_Nv_BadLoginAddress </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_BadLoginAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label28" runat="server" > AD_Nv_BadLoginCount </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_BadLoginCount" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label29" runat="server" > AD_Nv_Department </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Department" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label30" runat="server" > AD_Nv_Description </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Description" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label31" runat="server" > AD_Nv_Division </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Division" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label32" runat="server" > AD_Nv_EmailAddress </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_EmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label33" runat="server" > AD_Nv_EmployeeID </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_EmployeeID" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label34" runat="server" > AD_Nv_FaxNumber </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_FaxNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label35" runat="server" > AD_Nv_FirstName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_FirstName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label36" runat="server" > AD_Nv_FullName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_FullName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label37" runat="server" > AD_Nv_GraceLoginsAllowed </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_GraceLoginsAllowed" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label38" runat="server" > AD_Nv_GraceLoginsRemaining </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_GraceLoginsRemaining" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label39" runat="server" > AD_Nv_GUID </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_GUID" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label40" runat="server" > AD_Nv_HomeDirectory </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_HomeDirectory" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label41" runat="server" > AD_Nv_HomePage </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_HomePage" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label42" runat="server" > AD_Nv_IsAccountLocked </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_IsAccountLocked" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label43" runat="server" > AD_Nv_Languages </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Languages" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label44" runat="server" > AD_Nv_LastFailedLogin </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_LastFailedLogin" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label45" runat="server" > AD_Nv_LastLogin </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_LastLogin" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label46" runat="server" > AD_Nv_LastLogoff </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_LastLogoff" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label47" runat="server" > AD_Nv_LastName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_LastName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label48" runat="server" > AD_Nv_LoginHours </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_LoginHours" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label49" runat="server" > AD_Nv_LoginScript </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_LoginScript" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label50" runat="server" > AD_Nv_LoginWorkstations </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_LoginWorkstations" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label51" runat="server" > AD_Nv_Manager </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Manager" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label52" runat="server" > AD_Nv_MaxLogins </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_MaxLogins" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label53" runat="server" > AD_Nv_MaxStorage </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_MaxStorage" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label54" runat="server" > AD_Nv_Name </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Name" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label55" runat="server" > AD_Nv_NamePrefix </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_NamePrefix" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label56" runat="server" > AD_Nv_NameSuffix </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_NameSuffix" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label57" runat="server" > AD_Nv_OfficeLocations </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_OfficeLocations" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label58" runat="server" > AD_Nv_OtherName </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_OtherName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label59" runat="server" > AD_Nv_Parent </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Parent" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label60" runat="server" > AD_Nv_PasswordExpirationDate </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_PasswordExpirationDate" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label61" runat="server" > AD_Nv_PasswordLastChanged </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_PasswordLastChanged" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label62" runat="server" > AD_Nv_PasswordMinimumLength </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_PasswordMinimumLength" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label63" runat="server" > AD_Nv_PasswordRequired </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_PasswordRequired" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label64" runat="server" > AD_Nv_Picture </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Picture" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label65" runat="server" > AD_Nv_PostalAddresses </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_PostalAddresses" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label66" runat="server" > AD_Nv_PostalCodes </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_PostalCodes" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label67" runat="server" > AD_Nv_Profile </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Profile" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label68" runat="server" > AD_Nv_RequireUniquePassword </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_RequireUniquePassword" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label69" runat="server" > AD_Nv_Schema </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Schema" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label70" runat="server" > AD_Nv_TelephoneHome </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_TelephoneHome" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label71" runat="server" > AD_Nv_TelephoneMobile </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_TelephoneMobile" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label72" runat="server" > AD_Nv_TelephoneNumber </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_TelephoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label73" runat="server" > AD_Nv_TelephonePager </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_TelephonePager" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label74" runat="server" > AD_Nv_Title </asp:Label>
                                            </div>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="AD_Nv_Title" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.card-body -->
                                </div>
                            </div>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer">
                            <asp:LinkButton ID="Cancel_Btn" runat="server" CssClass="btn bg-gradient-warning" OnClick="Close_Btn_Click"> <i class="fas fa-window-close"></i>&nbsp; กลับ </asp:LinkButton>
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
