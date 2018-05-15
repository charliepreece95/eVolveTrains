<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="TrainsWebApp.Registration" %>

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
        <a href="../Default.aspx">
            <img id="logo" src="../imgs/eVolveTrains.png" alt="logo" /></a>
        <img id="menu" src="../imgs/burger.svg" alt="nav-item" />
        <nav id="nav-menu">
            <ul>
                <li><a href="../Login.aspx">Login</a></li>
                <li><a href="Registration.aspx">Register</a></li>
            </ul>
        </nav>
    </header>
    <main>
        <section>
            <form id="form1" runat="server">
                <table>
                    <tr>
                        <td>Username:
                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                        <span class="checked1">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorusername" runat="server" ErrorMessage="User Name required" ControlToValidate="txtUsername" ForeColor="Red"></asp:RequiredFieldValidator></span>
                    </tr>
                    <tr>
                        <td>Password:
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></td>
                        <span class="checked2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password required" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator></span>

                    </tr>
                    <tr>
                        <td class="resize"><span>Re-enter Password:</span><asp:TextBox ID="txtRePassword" TextMode="Password" runat="server"></asp:TextBox></td>
                        <span class="checked3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirmPassword" runat="server" ErrorMessage="Confirm Password required" ControlToValidate="txtRePassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator></span>
                        <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Password and Confirm Password must match" ControlToValidate="txtRePassword" ForeColor="Red" ControlToCompare="txtPassword" Display="Dynamic" Type="String" Operator="Equal" Text="*"></asp:CompareValidator>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
                        <asp:ValidationSummary ID="ValidationSummary" ForeColor="Red" runat="server" />
                    </tr>
                </table>
                <asp:Button ID="btnSignUp" runat="server" Text="Register" OnClick="btnSignUp_Click" />
            </form>
        </section>
    </main>
    <!--Jquery sourced from code pen-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <!--External Javascripts files-->
    <script src="../js/script.js"></script>
    <script src="../js/scroll.js"></script>
    <!--footer-->
    <footer>
    </footer>
</body>
</html>
