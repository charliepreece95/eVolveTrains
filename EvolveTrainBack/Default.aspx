<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TrainsWebApp.Default" %>

<DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>eVolveTrains</title>
    <!--charset ID-->
    <meta charset="utf-8" />
    <!-- View Port ID -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--Style Sheet Link -->
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="responsive.css" />
</head>
<body>
    <header>
        <img id="logo" src="imgs/eVolveTrains.png" alt="logo" />
        <img id="menu" src="imgs/burger.svg" alt="nav-item" />
        <nav id="nav-menu">
            <ul>
                <li><a href="Login.aspx">Login</a></li>
                <li><a href="Registration/Registration.aspx">Register</a></li>
            </ul>
        </nav>
    </header>
    <main>
        <!--Scroll icon to the top of the page -->
        <img class="arrow" src="imgs/arrow.svg" alt="scroll-up" />
        <!--Main Content-->
        <section class="container">
            <img class="img-container" src="imgs/train.jpg" />
            <p class="img-wrapper">Book Your Ticket Today</p>
        </section>
        <section class="flex-sections">
             <article>
                <img id="flex-styles" src="../imgs/customer.svg" alt="nav-item" />
            </article>
            <article>
                <img id="flex-styles" src="../imgs/train.svg" alt="nav-item" />
            </article>
            <article>
                <img id="flex-styles" src="../imgs/phone.svg" alt="nav-item" />
            </article>
        </section>
    </main>
    <!--Jquery sourced from code pen-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <!--External Javascripts files-->
    <script src="js/script.js"></script>
    <script src="js/scroll.js"></script>
    <!--footer-->
    <footer>
        <section class="footer-item footer-one">
        </section>
        <section class="footer-item footer-two">
            <ul>
                <li><a href="#">
                    <img src="imgs/github.svg" alt="link1" /></a></li>
                <li><a href="#">
                    <img src="imgs/googlePlus.svg" alt="link2" /></a></li>
                <li><a href="#">
                    <img src="imgs/whatsapp.svg" alt="link3" /></a></li>
                <li><a href="#">
                    <img src="imgs/linkedin.svg" alt="link4" /></a></li>
            </ul>
            <p>&#169;copyright 2018</p>
        </section>
    </footer>
</body>
</html>

