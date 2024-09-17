<?php
    session_start();
    require 'config.php';
    
?>
<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <title>TSA | Invoices Management</title>

    <style>
      @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap');

.sidebar{
position: fixed;
top: 0;
left: 0;
height: 100%;
width: 260px;
background: linear-gradient(90deg, rgba(71,9,121,1) 0%, rgba(140,56,250,1) 100%);
z-index: 100;
transition: all 0.5s ease;
}
.sidebar.close{
width: 78px;
}
.sidebar .logo-details{
height: 60px;
width: 100%;
display: flex;
align-items: center;
}
.sidebar .logo-details i{
font-size: 30px;
color: #fff;
height: 50px;
min-width: 78px;
text-align: center;
line-height: 50px;
}
.sidebar .logo-details .logo_name{
font-size: 17px;
color: #fff;
font-weight: 600;
transition: 0.3s ease;
transition-delay: 0.1s;
}
.sidebar.close .logo-details .logo_name{
transition-delay: 0s;
opacity: 0;
pointer-events: none;
}
.sidebar .nav-links{
height: 100%;
padding: 30px 0 150px 0;
overflow: auto;
}
.sidebar.close .nav-links{
overflow: visible;
}
.sidebar .nav-links::-webkit-scrollbar{
display: none;
}
.sidebar .nav-links li{
position: relative;
list-style: none;
transition: all 0.4s ease;
}
.sidebar .nav-links li:hover{
background: #1d1b31;
}
.sidebar .nav-links li .iocn-link{
display: flex;
align-items: center;
justify-content: space-between;
}
.sidebar.close .nav-links li .iocn-link{
display: block
}
.sidebar .nav-links li i{
height: 50px;
min-width: 78px;
text-align: center;
line-height: 50px;
color: #fff;
font-size: 20px;
cursor: pointer;
transition: all 0.3s ease;
}
.sidebar .nav-links li.showMenu i.arrow{
transform: rotate(-180deg);
}
.sidebar.close .nav-links i.arrow{
display: none;
}
.sidebar .nav-links li a{
display: flex;
align-items: center;
text-decoration: none;
}
.sidebar .nav-links li a .link_name{
font-size: 18px;
font-weight: 400;
color: #fff;
transition: all 0.4s ease;
}
.sidebar.close .nav-links li a .link_name{
opacity: 0;
pointer-events: none;
}
.sidebar .nav-links li .sub-menu{
padding: 6px 6px 14px 80px;
margin-top: -10px;
background: linear-gradient(to bottom, #3f71c8 0%, #4481eb 200%);
display: none;
}
.sidebar .nav-links li.showMenu .sub-menu{
display: block;
}
.sidebar .nav-links li .sub-menu a{
color: #fff;
font-size: 15px;
padding: 5px 0;
white-space: nowrap;
opacity: 0.6;
transition: all 0.3s ease;
}
.sidebar .nav-links li .sub-menu a:hover{
opacity: 1;
}
.sidebar.close .nav-links li .sub-menu{
position: absolute;
left: 100%;
top: -10px;
margin-top: 0;
padding: 10px 20px;
border-radius: 0 6px 6px 0;
opacity: 0;
display: block;
pointer-events: none;
transition: 0s;
}
.sidebar.close .nav-links li:hover .sub-menu{
top: 0;
opacity: 1;
pointer-events: auto;
transition: all 0.4s ease;
}
.sidebar .nav-links li .sub-menu .link_name{
display: none;
}
.sidebar.close .nav-links li .sub-menu .link_name{
font-size: 18px;
opacity: 1;
display: block;
}
.sidebar .nav-links li .sub-menu.blank{
opacity: 1;
pointer-events: auto;
padding: 3px 20px 6px 16px;
opacity: 0;
pointer-events: none;
}
.sidebar .nav-links li:hover .sub-menu.blank{
top: 50%;
transform: translateY(-50%);
}
.sidebar .profile-details{
position: fixed;
bottom: 0;
width: 260px;
display: flex;
align-items: center;
justify-content: space-between;
padding: 12px 0;
transition: all 0.5s ease;
}
.sidebar.close .profile-details{
background: none;
}
.sidebar.close .profile-details{
width: 78px;
}
.sidebar .profile-details .profile-content{
display: flex;
align-items: center;
}
.sidebar .profile-details img{
height: 52px;
width: 52px;
object-fit: cover;
border-radius: 16px;
margin: 0 14px 0 12px;
background:linear-gradient(to bottom, #3333cc 52%, #99ccff 200%);
transition: all 0.5s ease;
}
.sidebar.close .profile-details img{
padding: 10px;
}
.sidebar .profile-details .profile_name,
.sidebar .profile-details .job{
color: #fff;
font-size: 18px;
font-weight: 500;
white-space: nowrap;
}
.sidebar.close .profile-details i,
.sidebar.close .profile-details .profile_name,
.sidebar.close .profile-details .job{
display: none;
}
.sidebar .profile-details .job{
font-size: 12px;
}
.home-section{
position: relative;

/* height: 100vh; */
left: 260px;
width: calc(100% - 260px);
transition: all 0.5s ease;
}
.sidebar.close ~ .home-section{
left: 78px;
width: calc(100% - 78px);
}
.home-section .home-content{
height: 60px;
display: flex;
align-items: center;
}
.home-section .home-content .bx-menu,
.home-section .home-content .text{
color:linear-gradient(to bottom, #3333cc 0%, #99ccff 200%);

font-size: 35px;
}
.home-section .home-content .bx-menu{
margin: 0 15px;
cursor: pointer;
}
.home-section .home-content .text{
font-size: 26px;
font-weight: 600;
}
</style>

</head>
<body>
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
          <li><a class="link_name" href="#">Tasks</a></li>
          <li><a href="add.php" target="_self" name="Add_invoice">Add a Invoice</a></li>
          <li><a href="view.php"target="_self">Edit Invoice</a></li>
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
  <section class="home-section">
  <div class="home-content">
      <i class='bx bx-menu' ></i>
      <br>
      <span class="text">
      </span>
      
    </div>
    <div style="margin:20px;" class="container mt-4">

        <?php include('message.php'); ?>
                    
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                         <h4>Invoice Details 
                          <!--  <a href="user_add.php" class="btn btn-danger float-end">BACK</a>-->
                        </h4>
                    </div>
                        <div class="card-body table-responsive">

                        <table class="table table-bordered table-striped">
                       
                            <thead>
                                <tr>
                                    <th>InvoiceID</th>
                                    <th>EmployeeID</th>
                                    <th>Name</th>
                                    <th>Surname</th>                                    
                                    <th>InvoiceType</th>
                                    <th>Status</th>
                                    <th>Date</th>
                                    <th>Comment</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <?php 
                                    $query = "SELECT * FROM invoice_activity";
                                    $query2 = "SELECT * FROM customers";
                                    $query_run = mysqli_query($con, $query);
                                    $query_run2 = mysqli_query($con, $query2);

                                    if((mysqli_num_rows($query_run) > 0) || (mysqli_num_rows($query_run2) > 0))
                                    {
                                        foreach($query_run as $invoice )
                                        foreach($query_run2 as $invoice_co )
                                        // foreach (array_combine($courses, $sections) as $course => $section)
                                        {
                                            ?>
                                            <tr class="active-row">
                                                <td><?= $invoice['InvoiceID']; ?></td>
                                                <td><?= $invoice['EmployeeID']; ?></td>
                                                <td><?= $invoice_co['Name']; ?></td>
                                                <td><?= $invoice_co['Surname']; ?></td>
                                                <td><?= $invoice['InvoiceType']; ?></td>
                                                <td><?= $invoice['Status']; ?></td>
                                                <td><?= $invoice['Date']; ?></td>
                                                <td><?= $invoice['Comment']; ?></td>
                                                <td>
                                                    <a href="update.php?InvoiceID=<?= $invoice['InvoiceID']; ?>" class="btn btn-success btn-sm">Edit</a>
                                                    <form action="code.php" method="POST" class="d-inline">
                                                        <button type="submit" name="delete_invoice" value="<?=$invoice['InvoiceID'];?>" class="btn btn-danger btn-sm">Delete</button>
                                                    </form>
                                                </td>
                                            </tr>
                                            <?php
                                        }
                                    }
                                    else
                                    {
                                        echo "<h5> No Record Found </h5>";
                                    }
                                ?>
                                
                            </tbody>
                        </table>
                        </div>
                                  </div>
                                  </div>
                                  </div>
                </div>
   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
</section>
    </div>

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
</html>
