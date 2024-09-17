<?php
session_start();

?>

<!DOCTYPE html>
<html>
<head>
    <title>User Profile</title>
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="style.css">

    <style>

@media(max-width: 600px){
   .container{
       min-width: 280px;
   }

   .user-input-box{
       margin-bottom: 10px;
       width: 100%;
   }

   .user-input-box:nth-child(2n){
       justify-content: space-between;
   }

   .gender-category{
       display: flex;
       justify-content: space-between;
       width: 100%;
   }

   .main-user-info{
       max-height: 380px;
       overflow: auto;
   }

   .main-user-info::-webkit-scrollbar{
       width: 0;
   }
  
}

    </style>
</head>     
<body>

<div class="sidebar close" style="background: linear-gradient(90deg, rgba(71,9,121,1) 20%, rgba(140,56,250,1) 69%);">

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
            <span class="link_name">Invoices</span>
          </a>
          <i class='bx bxs-chevron-down arrow' ></i>
        </div>
        <ul class="sub-menu">
          <li><a class="link_name" href="#">Tasks</a></li>
          <li><a href="add.php" target="_self">Add an Invoice</a></li>
          <li><a href="view.php"target="_self">Edit Invoices</a></li>
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




  
  <!-- add invoice -->
  <section class="home-section">
    <div class="home-content">
      <i class='bx bx-menu' ></i>
      <br>
      <span class="text">
      </span>
      
    </div>
    <div class="form-container">
     

   
      <?php
      if(isset($error)){
         foreach($error as $error){
            echo '<span class="error-msg">'.$error.'</span>';
         };
      };
      ?>
     <div class="container">
     <h1 class="form-title">Create a Customer Invoice</h1>


      <form action="code.php" method="POST">
        <div class="main-user-info">
      

        <div class="user-input-box">
      
            <label for="EmployeeID">EmployeeID</label>
            <input type="number" id="employeeID"name="employee_ID"placeholder="Enter EmployeeID"/>
          </div>

          <div class="user-input-box">
            <label for="Name">Name</label>
            <input type="text" id="name" name="name" placeholder="Enter Name"/>
          </div>

          <div class="user-input-box">
            <label for="surname">Surname</label>
            <input type="text" id="surname" name="surname" placeholder="Enter Surname"/>
          </div>

          <div class="user-input-box">
               <label for="employee">Gender</label>
               <select name="Gender" id="surname">
                <option value="male">Male</option>
                <option value="female">Female</option>
                </select>
          </div>


          <div class="user-input-box">
            <label for="fullName">Nationaliy</label>
            <input type="text" id="nationality" name="nationality" placeholder="Enter Nationality"/>
          </div>

          <div class="user-input-box">
            <label for="Phone Number">Phone Number</label>
            <input type="text"id="Phone Number" name="Phone_Number" placeholder="Enter Phone Number"/>
          </div>

          <div class="user-input-box">
               <label for="employee">Invoice Type</label>
               <select name="invoice_type" id="surname">
                <option value="Request">Request</option>
                <option value="Training">Training</option>
                <option value="Report">Report</option>
                </select>
          </div>

            <div class="user-input-box">
               <label for="employee">Status</label>
               <select name="status" id="surname">
                <option value="Verified">Verified</option>
                <option value="Pending">Pending</option>
                <option value="Cancelled">Cancelled</option>
                </select>
          </div>

          <div class="user-input-box">
            <label for="Date">Date</label>
            <input type="date"id="date" name="date"/>
          </div>

          <div class="user-input-box">
            <label for="Comment">Comment</label>
            <input type="text"id="comment" name="comment" placeholder="Enter Comment"/>
          </div>

          </div>
        <div class="form-submit-btn">
          <input type="submit" name ="save_invoice" value="Sign Up" style="background: linear-gradient(90deg, rgba(71,9,121,1) 0%, rgba(140,56,250,1) 57%);">

       
        <div>
          <div class="user-input-box">
         <?php include('message.php'); ?>
         </div>
        </div>
       </div>
      </form>

 </div>

 </div>
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
