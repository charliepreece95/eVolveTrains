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
    <form id="JourneysForm" runat="server">
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
                </div>
            </nav>
        </header>
        <main>
            <section class="flex-sections">
                <article><a href="Trains.aspx">
                    <img id="flex-style" src="../imgs/train.svg" alt="nav-item" /></a></article>
                <article><a href="Journeys.aspx">
                    <img id="flex-style" src="../imgs/journey.svg" alt="nav-item" /></a></article>
                <article><a href="Users.aspx">
                    <img id="flex-style" src="../imgs/user.svg" alt="nav-item" /></a></article>
                <article><a href="Reports.aspx">
                    <img id="flex-style" src="../imgs/report.svg" alt="nav-item" /></a></article>
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
