<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TrainsBackEnd.Admin.CentralHub" %>

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
    <form id="CentralHubForm" runat="server">
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
                        <a href="Trains.aspx">Trains</a>
                    </div>
                </div>
            </nav>
        </header>
        <main>
            <section class="flex-reports">
                <article id="fitness">
                    <h2>Fitness Reports</h2>
                    <asp:GridView ID="Fitness" runat="server" CssClass="grid" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="Fitness_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ClientID" HeaderText="ClientID" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="TelNo" HeaderText="Mobile" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Height" HeaderText="Height" />
                            <asp:BoundField DataField="Age" HeaderText="Age" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        </Columns>
                    </asp:GridView>
                </article>
                <article id="pc">
                    <h2>PC Reports</h2>
                    <asp:GridView ID="PC" runat="server" CssClass="grid" AutoGenerateColumns="False" AllowPaging="true" PageSize="8" OnPageIndexChanging="PC_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:BoundField DataField="Category" HeaderText="Category" />
                            <asp:BoundField DataField="Supplier" HeaderText="Supplier" />
                        </Columns>
                    </asp:GridView>
                </article>
            </section>
            <section class="flex-reports">
                <article id="home">
                    <h2>Home Reports</h2>
                    <asp:GridView ID="Home" runat="server" CssClass="grid" AutoGenerateColumns="False" AllowPaging="true" PageSize="9" OnPageIndexChanging="Home_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ProductID" HeaderText="ProductID" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:BoundField DataField="Type" HeaderText="Type" />
                            <asp:BoundField DataField="Collection" HeaderText="Collection" />
                            <asp:BoundField DataField="Description" HeaderText="Description" />
                            <asp:BoundField DataField="Dimentions" HeaderText="Dimensions" />
                        </Columns>
                    </asp:GridView>
                </article>
                <article id="phone">
                    <h2>Phone Reports</h2>
                    <asp:GridView ID="Phone" runat="server" CssClass="grid" AutoGenerateColumns="False" AllowPaging="true" PageSize="10" OnPageIndexChanging="Phone_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ContractNo" HeaderText="ContractNo" />
                            <asp:BoundField DataField="DeviceName" HeaderText="DeviceName" />
                            <asp:BoundField DataField="NetworkerProvider" HeaderText="Network Provider" />
                            <asp:BoundField DataField="SpecialFeatures" HeaderText="Features" />
                            <asp:BoundField DataField="CapacityGB" HeaderText="Capacity" />
                            <asp:BoundField DataField="MonthlyPayment" HeaderText="Monthly Payment" />
                            <asp:BoundField DataField="Duration" HeaderText="Duration" />
                        </Columns>
                    </asp:GridView>
                </article>
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
            <section class="footer-item footer-zero">
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

