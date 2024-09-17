<?php
?>
<!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet'>
        <link rel="stylesheet" href="styles_1.css">
        <title>ABS | Accurate Billing System</title>
    </head>
 
    <body>

        <a href="#" class="scrolltop" id="scroll-top">
            <i class='bx bx-up-arrow-alt scrolltop__icon'></i>
        </a>
        signup
        <header class="l-header" id="header">
            <nav class="nav bd-container">
               
              <a href="#"><img src="img/favicon.png" alt="template" class="nav__logo" ></a>
            
                <div class="nav__menu" id="nav-menu">
                    <ul class="nav__list">
                        <li class="nav__item"><a href="#home" class="nav__link active-link">Home</a></li>
                        <li class="nav__item"><a href="#about" class="nav__link">About</a></li>
                        <li class="nav__item"><a href="#services" class="nav__link">Services</a></li>
                        <li class="nav__item"><a href="login.php" class="nav__link" target="_self">Login</a></li>
                        <li><i class='bx bx-toggle-left change-theme' id="theme-button"></i></li>
                    </ul>
                </div>

                <div class="nav__toggle" id="nav-toggle">
                    <i class='bx bx-grid-alt'></i>
                </div>
            </nav>
        </header>

        <main class="l-main">
            <section class="home" id="home">
                <div class="home__container bd-container bd-grid">
                    <div class="home__img">
                        <img src="img/e-invoice.jpg" alt="">
                    </div>

                    <div class="home__data">
                        <h1 class="home__title">The Only Invoicing System You will Ever Need</h1>
                        <p class="home__description">From organizing and recurring invoices, to custom sales reporting, there's so much more in ABS than just invoicing your projects.</p>
                        <a href="register.php" class="button" target="_blank">Let's Get Started</a><br>
                        <br>
                    </div>   
                </div>
            </section>

            <section class="share section bd-container" id="about">
                <div class="share__container bd-grid">
                    <div class="share__data">
                        <h2 class="section-title-center">Automate Recurring <br> Invoices</h2>
                        <p class="share__description">Is making the same invoice for a customer part of your monthly routine? Schedule your billing for recurring invoices to be generated automatically through our invoicing system and stay focused on your business!</p>
                    </div>

                    <div class="share__img">
                        <img src="img/billing.png" alt="">
                    </div>
                </div>
            </section>

            <section class="d section bd-container" id="services">
                <h2 class="section-title">Why Choose Us?</h2>
                <div class="d__container bd-grid">
                    <div class="d__data">
                        <img src="img/reminder.svg" alt="" class="d__img">
                        <h3 class="d__title">Automate Recurring Inovices</h3>
                    </div>

                    <div class="d__data">
                        <img src="img/modern_design.svg" alt="" class="d__img">
                        <h3 class="d__title">Modern Design</h3>
                    </div>

                    <div class="d__data">
                        <img src="img/todolist.svg" alt="" class="d__img">
                        <h3 class="d__title">Follow Up With Automated Invoices Reminders</h3>
                    </div>
                </div>
            </section>

            <section class="send section" id="contact">
                <div class="send__container bd-container bd-grid">
                    <div class="send__content">
                        <h2 class="section-title-center send__title">Sign Up</h2>
                        <p class="send__description">Stop spending valuable time managing invoices and paymentsFrom organizing and recurring invoices, to custom sales reporting, there's so much more in ABS than just invoicing your projects.</p>
                        <a href="register.php" class="button_signup" target="_blank">Sign up</a><br>
                    </div>

                    <div class="send__img">
                       
                       <img src="img/e-invoice.jpg" alt="">
                       
                    </div>
                </div>
            </section>
        </main>

        <footer class="footer section">
            <div class="footer__container bd-container bd-grid">
                <div class="footer__content">
                    <h3 class="footer__title">
                        <a href="#"><img src="img/favicon.png" alt="template" class="footer__description" ></a>
                        <a href="#" class="footer__logo">Accurate Billing System</a>
                    </h3>
                </div>

                <div class="footer__content">
                    <h3 class="footer__title">Our Services</h3>
                    <ul>
                        <li><a href="#" class="footer__link">Recurring Invoices </a></li>
                        <li><a href="#" class="footer__link">Invoices Status</a></li>
                        <li><a href="#" class="footer__link">Invoices Reminders</a></li>
                    </ul>
                </div>

                <div class="footer__content">
                    <h3 class="footer__title">Our Company</h3>
                    <ul>
                        <li><a href="#" class="footer__link">About us</a></li>
                        <li><a href="#" class="footer__link">Our mision</a></li>
                    </ul>
                </div>

                <div class="footer__content">
                    <h3 class="footer__title">Social</h3>
                    <a href="#" class="footer__social"><i class='bx bxl-facebook-circle '></i></a>
                    <a href="#" class="footer__social"><i class='bx bxl-twitter'></i></a>
                    <a href="#" class="footer__social"><i class='bx bxl-instagram-alt'></i></a>
                </div>
            </div>
            
            <p class="footer__copy">&#169; 2022 ABS. All rights reserved</p>
        </footer>

        <script src="https://unpkg.com/scrollreveal"></script>

        <script src="main.js"></script> 

    </body>
</html> 