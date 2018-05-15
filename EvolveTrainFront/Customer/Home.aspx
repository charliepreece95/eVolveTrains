<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TrainsWebApp.Customer.Home" %>

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
    <form id="TrainsForm" runat="server">
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
                        <a href="Account.aspx">Account</a><br />
                        <a href="Bookings.aspx">Bookings</a><br />
                        <a href="Reviews.aspx">Reviews</a>
                    </div>
                </div>
            </nav>
        </header>
        <main>
            <section class="home-control">
                <div id="home-text">
                    <h2>Add Booking</h2>
                </div>
                <table class="add-table">
                    <tr>
                        <td>Origin</td>
                        <td>
                            <asp:DropDownList ID="Station_origin" runat="server">
                                <asp:ListItem Enabled="true" Text="Select Train" Value=""></asp:ListItem>
                                <asp:ListItem Text="London" Value="London"></asp:ListItem>
                                <asp:ListItem Text="Leicester" Value="Leicester"></asp:ListItem>
                                <asp:ListItem Text="Manchester" Value="Manchester"></asp:ListItem>
                                <asp:ListItem Text="Glasgow" Value="Glasgow"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Destination</td>
                        <td>
                            <asp:DropDownList ID="Station_destination" runat="server">
                                <asp:ListItem Enabled="true" Text="Select Destination" Value=""></asp:ListItem>
                                <asp:ListItem Text="London" Value="London"></asp:ListItem>
                                <asp:ListItem Text="Leicester" Value="Leicester"></asp:ListItem>
                                <asp:ListItem Text="Manchester" Value="Manchester"></asp:ListItem>
                                <asp:ListItem Text="Glasgow" Value="Glasgow"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Type</td>
                        <td>
                            <asp:DropDownList ID="ddlType" runat="server">
                                <asp:ListItem Enabled="true" Text="Select Type" Value=""></asp:ListItem>
                                <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                                <asp:ListItem Text="Return" Value="Return"></asp:ListItem>
                                <asp:ListItem Text="Open Return" Value="Open Return"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Date</td>
                        <td>
                            <asp:DropDownList ID="ddlDate" runat="server">
                                <asp:ListItem Enabled="true" Text="Select Date" Value=""></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                <asp:ListItem Text="31" Value="31"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMonth" runat="server">
                                <asp:ListItem Enabled="true" Text="Select Month" Value=""></asp:ListItem>
                                <asp:ListItem Text="Jan" Value="Jan"></asp:ListItem>
                                <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                <asp:ListItem Text="Sep" Value="Sep"></asp:ListItem>
                                <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Departure</td>
                        <td>
                            <asp:DropDownList ID="ddlDeparture" runat="server">
                                <asp:ListItem Enabled="true" Text="Select Departure" Value=""></asp:ListItem>
                                <asp:ListItem Text="7:00" Value="7:00"></asp:ListItem>
                                <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                <asp:ListItem Text="8:00" Value="8:00"></asp:ListItem>
                                <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                <asp:ListItem Text="9:00" Value="9:00"></asp:ListItem>
                                <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                <asp:ListItem Text="10:00" Value="10:00"></asp:ListItem>
                                <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                <asp:ListItem Text="11:00" Value="11:00"></asp:ListItem>
                                <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                <asp:ListItem Text="12:00" Value="12:00"></asp:ListItem>
                                <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                                <asp:ListItem Text="13:30" Value="13:30"></asp:ListItem>
                                <asp:ListItem Text="14:00" Value="14:00"></asp:ListItem>
                                <asp:ListItem Text="14:30" Value="14:30"></asp:ListItem>
                                <asp:ListItem Text="15:00" Value="15:00"></asp:ListItem>
                                <asp:ListItem Text="15:30" Value="15:30"></asp:ListItem>
                                <asp:ListItem Text="16:00" Value="16:00"></asp:ListItem>
                                <asp:ListItem Text="16:30" Value="16:30"></asp:ListItem>
                                <asp:ListItem Text="17:00" Value="17:00"></asp:ListItem>
                                <asp:ListItem Text="17:30" Value="17:30"></asp:ListItem>
                                <asp:ListItem Text="18:00" Value="18:00"></asp:ListItem>
                                <asp:ListItem Text="18:30" Value="18:30"></asp:ListItem>
                                <asp:ListItem Text="19:00" Value="19:00"></asp:ListItem>
                                <asp:ListItem Text="19:30" Value="19:30"></asp:ListItem>
                                <asp:ListItem Text="20:00" Value="20:00"></asp:ListItem>
                                <asp:ListItem Text="20:30" Value="20:30"></asp:ListItem>
                                <asp:ListItem Text="21:00" Value="21:00"></asp:ListItem>
                                <asp:ListItem Text="21:30" Value="21:30"></asp:ListItem>
                                <asp:ListItem Text="22:00" Value="22:00"></asp:ListItem>
                                <asp:ListItem Text="22:30" Value="22:30"></asp:ListItem>
                                <asp:ListItem Text="23:00" Value="23:00"></asp:ListItem>
                                <asp:ListItem Text="23:30" Value="23:30"></asp:ListItem>
                                <asp:ListItem Text="00:00" Value="00:00"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <!--
                    <tr>
                        <td>Arrival</td>
                        <td>
                            <asp:DropDownList ID="ddlArrival" runat="server">
                                <asp:ListItem Enabled="true" Text="Select Arrival" Value=""></asp:ListItem>
                                <asp:ListItem Text="7:00" Value="7:00"></asp:ListItem>
                                <asp:ListItem Text="7:30" Value="7:30"></asp:ListItem>
                                <asp:ListItem Text="8:00" Value="8:00"></asp:ListItem>
                                <asp:ListItem Text="8:30" Value="8:30"></asp:ListItem>
                                <asp:ListItem Text="9:00" Value="9:00"></asp:ListItem>
                                <asp:ListItem Text="9:30" Value="9:30"></asp:ListItem>
                                <asp:ListItem Text="10:00" Value="10:00"></asp:ListItem>
                                <asp:ListItem Text="10:30" Value="10:30"></asp:ListItem>
                                <asp:ListItem Text="11:00" Value="11:00"></asp:ListItem>
                                <asp:ListItem Text="11:30" Value="11:30"></asp:ListItem>
                                <asp:ListItem Text="12:00" Value="12:00"></asp:ListItem>
                                <asp:ListItem Text="12:30" Value="12:30"></asp:ListItem>
                                <asp:ListItem Text="13:00" Value="13:00"></asp:ListItem>
                                <asp:ListItem Text="13:30" Value="13:30"></asp:ListItem>
                                <asp:ListItem Text="14:00" Value="14:00"></asp:ListItem>
                                <asp:ListItem Text="14:30" Value="14:30"></asp:ListItem>
                                <asp:ListItem Text="15:00" Value="15:00"></asp:ListItem>
                                <asp:ListItem Text="15:30" Value="15:30"></asp:ListItem>
                                <asp:ListItem Text="16:00" Value="16:00"></asp:ListItem>
                                <asp:ListItem Text="16:30" Value="16:30"></asp:ListItem>
                                <asp:ListItem Text="17:00" Value="17:00"></asp:ListItem>
                                <asp:ListItem Text="17:30" Value="17:30"></asp:ListItem>
                                <asp:ListItem Text="18:00" Value="18:00"></asp:ListItem>
                                <asp:ListItem Text="18:30" Value="18:30"></asp:ListItem>
                                <asp:ListItem Text="19:00" Value="19:00"></asp:ListItem>
                                <asp:ListItem Text="19:30" Value="19:30"></asp:ListItem>
                                <asp:ListItem Text="20:00" Value="20:00"></asp:ListItem>
                                <asp:ListItem Text="20:30" Value="20:30"></asp:ListItem>
                                <asp:ListItem Text="21:00" Value="21:00"></asp:ListItem>
                                <asp:ListItem Text="21:30" Value="21:30"></asp:ListItem>
                                <asp:ListItem Text="22:00" Value="22:00"></asp:ListItem>
                                <asp:ListItem Text="22:30" Value="22:30"></asp:ListItem>
                                <asp:ListItem Text="23:00" Value="23:00"></asp:ListItem>
                                <asp:ListItem Text="23:30" Value="23:30"></asp:ListItem>
                                <asp:ListItem Text="00:00" Value="00:00"></asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    -->
                </table>
                <div class="btnAdd">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Booking" OnClick="btnAdd_Click" />
                    <br />
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>
            </section>
            <section class="train-control-Journeys">
                <h3>Available Trains</h3>
                <asp:GridView ID="GVJourney" runat="server" CssClass="grid" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="JourneyID" HeaderText="ID" />
                        <asp:BoundField DataField="StationFrom" HeaderText="Station" />
                        <asp:BoundField DataField="PlatformFrom" HeaderText="Platform" />
                        <asp:BoundField DataField="StationTo" HeaderText="Destination" />
                        <asp:BoundField DataField="PlatformTo" HeaderText="PlatformTo" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Departure" HeaderText="Departure" />
                        <asp:BoundField DataField="Arrival" HeaderText="Arrival" />
                    </Columns>
                </asp:GridView>
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
