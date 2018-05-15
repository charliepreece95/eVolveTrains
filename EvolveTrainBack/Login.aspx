<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TrainsWebApp.Login" %>

<DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eVolveTrains</title>
    <!--charset ID-->
    <meta charset="utf-8" />
    <!-- View Port ID -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--Style Sheet Link -->
    <link rel="stylesheet" href="../style.css" />
    <link rel="stylesheet" href="../responsive.css" />
    <link rel="stylesheet" href="../authorisation.css" />
</head>
<body>
    <header>
        <img id="logo" src="../imgs/eVolveTrains.png" alt="logo" />
        <img id="menu" src="../imgs/burger.svg" alt="nav-item" />
        <nav id="nav-menu">
            <ul>
                <li><a href="../Login.aspx">Login</a></li>
                <li><a href="Registration/Registration.aspx">Register</a></li>
            </ul>
        </nav>
    </header>
    <main>
        <section>
            <form id="form1" runat="server">
                <table class="table-login">
                    <tr>
                        <td>
                            <label>Username:</label></td>
                        <td>
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <label>Password:</label></td>
                        <td>
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkBoxRememberMe" runat="server" Text="Remember Me" /></td>
                        <td class="checked">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="62px" />
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
            </form>
        </section>
    </main>
    <!--Jquery sourced from code pen-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <!--External Javascripts files-->
    <script src="js/script.js"></script>
    <script src="js/scroll.js"></script>
    <!--footer-->
    <footer>
    </footer>
</body>
</html>
