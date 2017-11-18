<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmLogin.aspx.vb" Inherits="frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js" lang="">
    <head runat="server">
        <title>Welcome to - Locker Kiosk Administrative Web</title>
        <meta name="description" content="" />
        <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1, maximum-scale=1" />
        <link rel="stylesheet" type="text/css" href="styles/webfont.css" />
        <link rel="stylesheet" type="text/css" href="styles/climacons-font.css" />
        <link rel="stylesheet" type="text/css" href="vendor/bootstrap/dist/css/bootstrap.css" />
        <link rel="stylesheet" type="text/css" href="styles/font-awesome.css" />
        <link rel="stylesheet" type="text/css" href="styles/card.css" />
        <link rel="stylesheet" type="text/css" href="styles/sli.css" />
        <link rel="stylesheet" type="text/css" href="styles/animate.css" />
        <link rel="stylesheet" type="text/css" href="styles/app.css" />
        <link rel="stylesheet" type="text/css" href="styles/app.skins.css" />
        <!-- endbuild -->
    </head>
    <body class="page-loading">
        <form id="form1" runat="server">
            <div class="app signin usersession">
                <div class="session-wrapper">
                    <div class="page-height-o row-equal align-middle">
                        <div class="column">
                            <div class="card bg-white no-border">
                                <div class="card-block">
                                    <div role="form" class="form-layout">
                                        <div class="text-center m-b">
                                            <h4 class="text-uppercase">Welcome To Locker Kiosk</h4>
                                            <p>Sign In to Administrative Web</p>
                                        </div>
                                        <div class="form-inputs">
                                            <label class="text-uppercase">User Name</label>
                                            <asp:TextBox ID="txtUserName" runat="server" class="form-control input-lg" placeholder="User Name" required></asp:TextBox>
                                            <label class="text-uppercase">Password</label>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control input-lg" placeholder="Password" required></asp:TextBox>
                                        </div>
                                        <asp:Button ID="btnLogin" runat="server" class="btn btn-success btn-block btn-lg " Text="Sign In" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <script type="text/javascript" src="scripts/helpers/modernizr.js"></script>
            <script type="text/javascript" src="vendor/jquery/dist/jquery.js"></script>
            <script type="text/javascript" src="vendor/bootstrap/dist/js/bootstrap.js"></script>
            <script type="text/javascript" src="vendor/fastclick/lib/fastclick.js"></script>
            <script type="text/javascript" src="vendor/perfect-scrollbar/js/perfect-scrollbar.jquery.js"></script>
            <script type="text/javascript" src="scripts/helpers/smartresize.js"></script>
            <script type="text/javascript" src="scripts/constants.js"></script>
        </form>
    </body>
</html>
