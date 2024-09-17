<?php
/*session_start();
       // header('Location:user_add.php');
       if (!isset($_SESSION['loggedin'])) {
       // header('Location: login.php');
        echo"<script>alert('You are not logged in');</script>";

    }
    else
    {
    header('Location:profile.php');
    }*/
?>
<!DOCTYPE html>
<html>
<head>
    <title>User Profile</title>
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="style.css">
</head>     

<body>
<?
    if(!empty($welcomeMessage)) echo $welcomeMessage;
?>
<div class="sidebar close">
    <div class="logo-details">
    <i>
        <img src="img/favicon.png">
    </i>
      <span class="logo_name">Username</span>
    </div>
    <ul class="nav-links">
      <li>
        <a href="#">
        <i class='bx bxs-dashboard'></i>
          <span class="link_name">Dashboard</span>
        </a>
        <ul class="sub-menu blank">
          <li><a class="link_name" href="#">Dashboard</a></li>
        </ul>
      </li>
      <li>
        <div class="iocn-link">
          <a href="#">
          <i class='bx bx-task'></i>
            <span class="link_name">Invoice</span>
          </a>
          <i class='bx bxs-chevron-down arrow' ></i>
        </div>
        <ul class="sub-menu">
          <li><a class="link_name" href="#">Invoices</a></li>
          <li><a href="add.php" target="_self" name="Add_invoice">Add an Invoice</a></li>
          <li><a href="view.php"target="_self">View Invoices</a></li>
        </ul>
      </li>
      <li>
        <div class="iocn-link">
          <a href="#">
            <i class='fa fa-gear' ></i>
            <span class="link_name">Support</span>
          </a>
          <i class='bx bxs-chevron-down arrow' ></i>
        </div>
        <ul class="sub-menu">
          <li><a class="link_name" href="#">Settings</a></li>
          <li><a href="#"target="_self">Help</a></li>
        </ul>
      </li>

      <li>
     <div class="profile-details">
      <div class="profile-content">
        <!--<img src="image/profile.jpg" alt="profileImg">-->
      </div>
      <div class="name-job">
          <a href="#">
            <!-- <i class='bx bx-log-out'></i> -->
        <div class="profile_name">Logout</div>
        </a>
        <div class="job"></div>
      </div>
      <a href="#">
      <i class='bx bx-log-out' ></i>
        </a>
    </div>
  </li>
 </ul>
  </div>
  <!-- Dashboard panel -->
  <section class="home-section">
    <div class="home-content">
      <i class='bx bx-menu' ></i>
      <br>
      <span class="text">
      </span>
      
    </div>
    <h1 align="center">Welcome</h1>
    
  </section>

 
  <script>
  let arrow = document.querySelectorAll(".arrow");
  for (var i = 0; i < arrow.length; i++) {
    arrow[i].addEventListener("click", (e)=>{
   let arrowParent = e.target.parentElement.parentElement;//selecting main parent of arrow
   arrowParent.classList.toggle("showMenu");
    });
  }
  let sidebar = document.querySelector(".sidebar");
  let sidebarBtn = document.querySelector(".bx-menu");
  console.log(sidebarBtn);
  sidebarBtn.addEventListener("click", ()=>{
    sidebar.classList.toggle("close");
  });
  </script>
</body>  
