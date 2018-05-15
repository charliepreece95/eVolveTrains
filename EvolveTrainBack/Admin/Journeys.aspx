<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Journeys.aspx.cs" Inherits="TrainsBackEnd.Admin.Journeys" %>

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
    <form id="JourneyForm" runat="server">
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
                        <a href="Trains.aspx">Trains</a><br />
                        <a href="Users.aspx">Users</a><br />
                        <a href="Reports.aspx">Reports</a>
                    </div>
                </div>
            </nav>
        </header>
        <main>
            <section id="travel" class="train-control-Journeys" runat="server">
            </section>
            <h2>List of Journeys</h2>
            <section class="journey-control">
                <table class="journey-table">
                    <h2>Journey Control</h2>
                    <tr>
                        <td>JourneyID</td>
                        <td>
                            <asp:TextBox ID="txtJourneyID" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Station</td>
                        <td>
                            <asp:TextBox ID="txtStationFrom" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Platform </td>
                        <td>
                            <asp:TextBox ID="txtplatformFrom" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Destination </td>
                        <td>
                            <asp:TextBox ID="txtStationTo" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Platform</td>
                        <td>
                            <asp:TextBox ID="txtPlatformTo" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Price</td>
                        <td>
                            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Departure</td>
                        <td>
                            <asp:TextBox ID="txtDeparture" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Arrival</td>
                        <td>
                            <asp:TextBox ID="txtArrvial" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <div class="btnValid">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnFind_Click" />
                    <asp:Button ID="btnReset" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
                    <br />
                    <asp:Label ID="lblValid" runat="server" Text=""></asp:Label>
                </div>
            </section>
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
