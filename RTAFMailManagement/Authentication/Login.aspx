<%@ Page Title="Log in" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RTAFMailManagement.Authentication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title><%: Page.Title %> - My ASP.NET Application</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Font Awesome -->
    <link rel="stylesheet" href="~/Content/plugins/fontawesome-free/css/all.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="~/Content/plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="~/Content/dist/css/adminlte.min.css" />
    <!-- Google Font: Source Sans Pro -->
    <link href="https://fonts.googleapis.com/css?family=Sarabun:300,400,400i,700" rel="stylesheet" />
</head>

<body class="hold-transition login-page" style="margin-top: -200px;">
    <div class="login-box">
        <div class="login-logo">
            <asp:Label ID="login_Lbl" runat="server"><b>RTAF Mail</b> Management </> <i class="fa fa-sign-in-alt fa-fw"></i> </asp:Label>
        </div>
        <!-- /.login-logo -->
        <div class="card">
            <div class="card-body login-card-body">
                <p class="login-box-msg">Sign in to start your session</p>

                <form runat="server">
                    <div class="input-group mb-3">
                        <asp:TextBox ID="Username_TBx" runat="server" CssClass="form-control" placeholder="Username" > </asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="Password_TBx" CssClass="form-control" runat="server" placeholder="Password"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-7">
                            <!-- <div class="icheck-primary">
                                <asp:CheckBox ID="Remember_ChkBx" runat="server" />
                                <label for="remember">
                                    Remember Me
                                </label>
                            </div> -->
                        </div>
                        <!-- /.col -->
                        <div class="col-5">
                            <asp:LinkButton ID="Login_btn" runat="server" CssClass="btn btn-primary btn-block" OnClick="Login_btn_Click">Sign In <i class="fa fa-sign-in-alt fa-fw"></i> </asp:LinkButton>
                        </div>
                        <!-- /.col -->
                    </div>
                </form>
            </div>
            <!-- /.login-card-body -->
        </div>
    </div>
    <!-- /.login-box -->

    <!-- jQuery -->
    <script src="~/Content/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="~/Content/dist/js/adminlte.min.js"></script>

</body>
</html>
