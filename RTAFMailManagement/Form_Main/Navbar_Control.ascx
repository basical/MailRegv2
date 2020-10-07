<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar_Control.ascx.cs" Inherits="RTAFMailManagement.Form_Main.Navbar_Control" %>

<%@ Import Namespace="RTAFMailManagement.Class" %>

<%
    int act = 1;
    if (Session["Class_Active"] != null)
    {
        act = Convert.ToInt32(Session["Class_Active"].ToString());
    }
%>

<!-- Navbar -->
<nav class="main-header navbar navbar-expand navbar-white navbar-light">

    <!-- Left navbar links -->
    <ul class="navbar-nav">
        <li class="nav-item">
            <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
        </li>
    </ul>

</nav>
<!-- /.navbar -->

<!-- Main Sidebar Container -->
<aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <a href="#" class="brand-link">
        <span class="brand-text font-weight-light">RTAF Mail Admin v.2</span>
    </a>

    <!-- Sidebar -->
    <div class="sidebar">

        <% 
            if (Session["admin_user"] != null)
            {
                Admin_Users au = (Admin_Users)Session["admin_user"];
        %>
        <!-- Sidebar user panel (optional) -->
        <div class="user-panel mt-3 pb-3 mb-3 d-flex">
            <div class="info">
                <a> USING BY : </a>
            </div>
            <div class="info">
                <a> <%= au.Admin_Users_Name %> </a>
            </div>
        </div>
        <% 
            }
        %>
        <!-- Sidebar Menu -->
        <nav class="mt-2">
            <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                <!-- Add icons to the links using the .nav-icon class with font-awesome or any other icon font library -->
                <li class="nav-item">
                    <a href="/Form_Main/Form_MainPage" class="nav-link <%= act == 0 ? "active" : "" %>">
                        <i class="nav-icon fas fa-home"></i>
                        <p>หน้าแรก</p>
                    </a>
                </li>

                <% 
                    if (Session["admin_user"] != null)
                    {
                        Admin_Users au = (Admin_Users)Session["admin_user"];

                        if (au.Admin_User_Type.Admin_Users_Type_id == 3)
                        {
                %>
                <li class="nav-header">CONFIGURATION</li>
                <li class="nav-item has-treeview <%= act > 0 && act < 10 ? "menu-open" : "" %>">
                    <a href="#" class="nav-link <%= act > 0 && act < 10 ? "active" : "" %>">
                        <i class="nav-icon fas fa-cogs"></i>
                        <p>การตั้งค่า<i class="fas fa-angle-left right"></i></p>
                    </a>
                    <ul class="nav nav-treeview">
                        <li class="nav-item">
                            <a href="/Form_Configuration/AD_Status_Management" class="nav-link <%= act == 1 ? "active" : "" %>">
                                <i class="fas fa-server nav-icon"></i>
                                <p>AD Status *</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_Configuration/Admins_Management" class="nav-link <%= act == 2 ? "active" : "" %>">
                                <i class="fas fa-user-tie nav-icon"></i>
                                <p>Admins *</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_Configuration/Admin_Types_Management" class="nav-link <%= act == 3 ? "active" : "" %>">
                                <i class="fas fa-user-tie nav-icon"></i>
                                <p>Admin Type *</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_Configuration/Questions_Management" class="nav-link <%= act == 4 ? "active" : "" %>">
                                <i class="far fa-question-circle nav-icon"></i>
                                <p>Questions *</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_Configuration/Ranks_Management" class="nav-link <%= act == 5 ? "active" : "" %>">
                                <i class="fas fa-layer-group nav-icon"></i>
                                <p>Ranks *</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_Configuration/Units_Management" class="nav-link <%= act == 6 ? "active" : "" %>">
                                <i class="fas fa-layer-group nav-icon"></i>
                                <p>Units *</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_Configuration/Users_Type_Management" class="nav-link <%= act == 7 ? "active" : "" %>">
                                <i class="fas fa-user-circle nav-icon"></i>
                                <p>User Type *</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_Configuration/RTAF_Status_Management" class="nav-link <%= act == 8 ? "active" : "" %>">
                                <i class="far fa-address-card nav-icon"></i>
                                <p>RTAF Status *</p>
                            </a>
                        </li>
                    </ul>
                </li>
                <% 
                    }
                %>
                <li class="nav-header">บัญชีผู้ใช้งาน </li>
                <li class="nav-item has-treeview <%= act > 10 && act < 20 ? "menu-open" : "" %>">
                    <a href="#" class="nav-link <%= act > 10 && act < 20 ? "active" : "" %>">
                        <i class="nav-icon fas fa-users"></i>
                        <p>บัญชีผู้ใช้งาน<i class="right fas fa-angle-left"></i></p>
                    </a>
                    <ul class="nav nav-treeview">
                        <li class="nav-item has-treeview <%= act > 10 && act < 16 ? "menu-open" : "" %>">
                            <a href="#" class="nav-link <%= act > 10 && act < 16 ? "active" : "" %>">
                                <i class="fas fa-user-cog nav-icon"></i>
                                <p>Managed Account <i class="right fas fa-angle-left"></i></p>
                            </a>
                            <ul class="nav nav-treeview">
                                <li class="nav-item">
                                    <a href="/Form_Mail_Register/Search_Prepare_Create_Account?mode=p" class="nav-link <%= act == 13 ? "active" : "" %>">
                                        <i class="fas fa-user-plus nav-icon"></i>
                                        <p>Add Account Person</p>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href="/Form_Mail_Register/Search_Prepare_Create_Account?mode=u" class="nav-link <%= act == 14 ? "active" : "" %>">
                                        <i class="far fa-building nav-icon"></i>
                                        <p>Add Account Unit</p>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href="/Form_Mail_Register/Search_Prepare_Create_Account?mode=g" class="nav-link <%= act == 15 ? "active" : "" %>">
                                        <i class="fas fa-users nav-icon"></i>
                                        <p>Add Account Group</p>
                                    </a>
                                </li>
                                <li class="nav-item">
                                    <a href="/Form_Mail_Register/Search_User_Accounts" class="nav-link <%= act == 12 ? "active" : "" %>">
                                        <i class="fas fa-search nav-icon"></i>
                                        <p>Search Account </p>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_Mail_Register/Reset_Password_User_Fast" class="nav-link <%= act == 16 ? "active" : "" %>">
                                <i class="fas fa-sync-alt nav-icon"></i>
                                <p>Reset Password </p>
                            </a>
                        </li>
                        <%
                            if (au.Admin_User_Type.Admin_Users_Type_id == 3)
                            {
                        %>
                        <li class="nav-item">
                            <a href="/Form_Mail_Register/Update_User_Account_CPDTSV" class="nav-link <%= act == 17 ? "active" : "" %>">
                                <i class="fas fa-users-cog nav-icon"></i>
                                <p>Update Person2UserAcc *</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_Mail_Register/Move_OU_Account" class="nav-link <%= act == 18 ? "active" : "" %>">
                                <i class="fas fa-exchange-alt nav-icon"></i>
                                <p>Move OU Account *</p>
                            </a>
                        </li>
                        <%
                            }
                        %>
                    </ul>
                </li>
                <%
                    if (au.Admin_User_Type.Admin_Users_Type_id == 3)
                    {
                %>
                <li class="nav-header">ข้อมูลกำลังพล </li>
                <li class="nav-item has-treeview <%= act > 20 ? "menu-open" : "" %>">
                    <a href="#" class="nav-link <%= act > 20 ? "active" : "" %>">
                        <i class="nav-icon fas fa-user-tie"></i>
                        <p>ปรับปรุงข้อมูลกำลังพล <i class="fas fa-angle-left right"></i></p>
                    </a>
                    <ul class="nav nav-treeview">
                        <li class="nav-item">
                            <a href="/Form_ComparePersonData/Form_Add_PersonData" class="nav-link <%= act == 21 ? "active" : "" %>">
                                <i class="fas fa-user-circle nav-icon"></i>
                                <p>:: Add Person ::</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_ComparePersonData/Form_Search_Person" class="nav-link <%= act == 22 ? "active" : "" %>">
                                <i class="fas fa-search-plus nav-icon"></i>
                                <p>:: Search Person ::</p>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a href="/Form_ComparePersonData/Form_Search_PersonData" class="nav-link <%= act == 29 ? "active" : "" %>">
                                <i class="fas fa-people-arrows nav-icon"></i>
                                <p>:: Compare WebService ::</p>
                            </a>
                        </li>
                    </ul>
                </li>
                <%
                    }
                %>

                <li class="nav-item">
                    <a href="/Form_Main/Form_MainPage?code=LGOT" class="nav-link">
                        <i class="nav-icon fas fa-sign-out-alt"></i>
                        <p>ออกจากระบบ</p>
                    </a>
                </li>
                <%
                    }
                %>
            </ul>
        </nav>
        <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
</aside>
