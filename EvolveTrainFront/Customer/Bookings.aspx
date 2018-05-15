<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="TrainsWebApp.Customer.Bookings" %>

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
    <form id="BookingForm" runat="server">
        <header>
            <img id="logo" src="../imgs/eVolveTrains.png" alt="logo" />
            <img id="menu" src="../imgs/burger.svg" alt="nav-item" />
            <nav id="nav-menu">
                <ul class="login">
                    <li>
                        <asp:LinkButton runat="server" Text="Logout" OnClick="btnLogout_Click" /></li>
                </ul>
                <div class="dropdown">
                    <span class="logged-in">Hello:
                        <asp:Label Text="" runat="server" ID="lblUsername" /></span>
                    <div class="dropdown-content">
                        <a href="Home.aspx">Home</a><br />
                        <a href="Account.aspx">Account</a><br />
                        <a href="Reviews.aspx">Reviews</a>
                    </div>
                </div>
            </nav>
        </header>
        <main>
            <section class="booking-control">
                <div id="booking-text">
                    <h2>Your Bookings</h2>
                </div>
                <asp:GridView ID="GVBookings" runat="server" CssClass="grid" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="BookingID" HeaderText="BookingID" />
                        <asp:BoundField DataField="Station_Origin" HeaderText="Station" />
                        <asp:BoundField DataField="Station_Destination" HeaderText="Destination" />
                        <asp:BoundField DataField="Type" HeaderText="Type" />
                        <asp:BoundField DataField="Month" HeaderText="Month" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Departure" HeaderText="Departure" />               
                    </Columns>
                </asp:GridView>
            </section>
            <section class="Delete-valid">
                <asp:TextBox ID="txtRemove" runat="server"></asp:TextBox>
                <asp:Button ID="btnDelete" runat="server" Text="Remove Booking" OnClick="btnDelete_Click" />
                <asp:Label Text="" ID="lblError" runat="server"></asp:Label>
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
