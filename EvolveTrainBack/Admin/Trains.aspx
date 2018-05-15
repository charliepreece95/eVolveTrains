<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trains.aspx.cs" Inherits="TrainsBackEnd.Admin.Trains" %>

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
    <link rel="stylesheet" href="../grid.css" />
    <script src="../js/jquery3.2.1.js"></script>
</head>
<body>
    <form id="TrainForm" runat="server">
        <header>
            <img id="logo" src="../imgs/eVolveTrains.png" alt="logo" />
            <img id="menu" src="../imgs/burger.svg" alt="nav-item" />
            <nav id="nav-menu">
                <ul class="login">
                    <li>
                        <asp:LinkButton runat="server" Text="Logout" OnClick="btnLogout_Click" />
                    </li>
                </ul>
                <div class="dropdown">
                    <span class="logged-in">Hello:
                        <asp:Label Text="" runat="server" ID="lblUsername" /></span>
                    <div class="dropdown-content">
                        <a href="Home.aspx">Home</a><br />
                        <a href="Users.aspx">Users</a><br />
                        <a href="Journeys.aspx">Journeys</a><br />
                        <a href="Reports.aspx">Reports</a>
                    </div>
                </div>
            </nav>
        </header>
        <main>
            <section id="travel" class="train-control-Trains" runat="server">
            </section>
            <h2>List of Trains</h2>
            <table class="train-table">
                <h2>Train Control</h2>
                <tr>
                    <td>TrainID</td>
                    <td>
                        <asp:TextBox ID="txtTrainID" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Train</td>
                    <td>
                        <asp:TextBox ID="txtTrain" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Capacity </td>
                    <td>
                        <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Active </td>
                    <td>
                        <asp:TextBox ID="txtActive" runat="server"></asp:TextBox></td>
                </tr>
            </table>
            <div class="btnValidate">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnFind_Click" />
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
                <br />
                <asp:Label ID="lblValid" runat="server" Text=""></asp:Label>
            </div>

        </main>
        <!--Jquery sourced from code pen-->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
        <!--External Javascripts files-->
        <script src="../js/scripts.js"></script>
        <script src="../js/script.js"></script>
        <script src="../js/scroll.js"></script>
        <!--footer-->
        <footer>
            <section class="footer-item footer-one">
            </section>
            <section class="footer-item footer-two">
                <ul>
                    <li><a href="#">
                        <img src="../imgs/github.svg" alt="link1" /></a></li>
                    <li><a href="#">
                        <img src="../imgs/googlePlus.svg" alt="link2" /></a></li>
                    <li><a href="#">
                        <img src="../imgs/whatsapp.svg" alt="link3" /></a></li>
                    <li><a href="#">
                        <img src="../imgs/linkedin.svg" alt="link4" /></a></li>
                </ul>
                <p>&#169;copyright 2018</p>
            </section>
        </footer>
    </form>
</body>
</html>
