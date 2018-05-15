<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="TrainsWebApp.Customer.Reviews" %>

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
    <form id="ReviewForm" runat="server">
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
                        <a href="Bookings.aspx">Bookings</a>
                    </div>
                </div>
            </nav>
        </header>
        <main>
            <section class="review-control">
                <div id="review-text">
                    <h2>Review eVolve</h2>
                </div>
                <table class="review-table">
                    <td>Select The Website To Review</td>
                    <tr>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlReviewSystem">
                                <asp:ListItem Enabled="true" Text="Choose" Value=""></asp:ListItem>
                                <asp:ListItem>Fitness</asp:ListItem>
                                <asp:ListItem>Home</asp:ListItem>
                                <asp:ListItem>Phones</asp:ListItem>
                                <asp:ListItem>PC</asp:ListItem>
                                <asp:ListItem>Trains</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <td>Rate System</td>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlRating" runat="server">
                                <asp:ListItem Enabled="true" Text="Choose" Value=""></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <td>Leave a Commit</td>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtReview" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </section>
            <div id="review">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" UseSubmitBehavior="false" />
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" UseSubmitBehavior="false" />
                <br />
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
            <section class="GVReview">
                <asp:GridView ID="GVReview" runat="server" CssClass="grid" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Username" HeaderText="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Rating" HeaderText="Rating" />
                        <asp:BoundField DataField="SystemName" HeaderText="System Reviewed" />
                        <asp:BoundField DataField="RevDate" HeaderText="Review Date" />
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
