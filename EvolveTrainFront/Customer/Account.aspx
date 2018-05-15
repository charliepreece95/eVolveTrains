<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="TrainsWebApp.Customer.Account" %>

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
    <form id="AccountForm" runat="server">
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
                        <a href="Bookings.aspx">Bookings</a><br />
                        <a href="Reviews.aspx">Reviews</a>
                    </div>
                </div>
            </nav>
        </header>
        <main>
            <section class="account-control">
                <div id="account-text">
                    <h2>Update Account</h2>
                </div>
                <table class="update-table">
                    <tr>
                        <td>FirstName</td>
                        <td>
                            <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>LastName</td>
                        <td>
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Date Of Birth</td>
                        <td>
                            <asp:TextBox ID="txtDob" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Address</td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>PostCode</td>
                        <td>
                            <asp:TextBox ID="txtPostCode" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Town</td>
                        <td>
                            <asp:TextBox ID="txtTown" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Country</td>
                        <td>
                            <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>TeleNo</td>
                        <td>
                            <asp:TextBox ID="txtTeleNo" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Email</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <div class="btnUpdate">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" UseSubmitBehavior="false" />
                    <br />
                    <asp:Label ID="lblUpdateMessage" runat="server" Text=""></asp:Label>
                </div>
            </section>
            <section class="GVPerson">
                <asp:GridView ID="GVPerson" runat="server" CssClass="grid" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="PersonID" HeaderText="ID" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                        <asp:BoundField DataField="DOB" HeaderText="Date Of Birth" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="PostCode" HeaderText="Postcode" />
                        <asp:BoundField DataField="Town" HeaderText="Town" />
                        <asp:BoundField DataField="Country" HeaderText="Country" />
                        <asp:BoundField DataField="TeleNo" HeaderText="TeleNo" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
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
