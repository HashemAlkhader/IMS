<?php

session_start();
require "config.php";

if(isset($_POST['submit'])){

    $dbsign = new mysqli("localhost", "root", "", "tsa");
	  if (mysqli_connect_errno()) 
	  {
		 printf("Connect failed: %s", mysqli_connect_error());
		 exit();
	  } 

    $emp_id = $_POST["EmployeeID"];
    $user = $_POST["usertype"];
    $NAME = $_POST["name"];
    $SURNAME = $_POST["surname"];
    $DEPT = $_POST["departement"];
    $email = $_POST["email"];
    //$pass = md5($_POST["Password"]);
  //  $cpass = md5($_POST["cpassword"]);
    

   $select = " SELECT * FROM employees WHERE EmployeeID = '$emp_id' ";

   $result = mysqli_query($dbsign, $select);

   if(mysqli_num_rows($result) > 0){

      $row = mysqli_fetch_array($result);//Fetch a result row as a numeric array and as an associative array
      if(($row['EmployeeID'] == $emp_id) && ($row['Name'] == $NAME) && ($row['Surname'] == $SURNAME) && ($row['Departement'] == $DEPT) & ($row['Email'] == $email))
      {   
        $password_length = rand(8, 10);
        $pw = '';
        for($i = 0; $i < $password_length; $i++)
         {
          $pw .= chr(rand(32, 126));
         }
        $a = md5($pw);
        $query = "UPDATE employees SET Password='$a' WHERE EmployeeID='$emp_id' ";
        $query_run = mysqli_query($con, $query);
        echo"<script>alert('You reset succesfully, your temp password is $pw');</script>";
     }
     else{
      $error[] = 'Incorrect Info';
   }
}
};
?>

<!DOCTYPE html>
<html lang="en">
<head>
   <meta charset="UTF-8">
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <title>Reset</title>

   <!-- custom css file link  -->
   <!-- <link rel="stylesheet" href="styless.css"> -->
   <style>
      @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@100;200;300;400;500;600&display=swap');

*{
   font-family: 'Poppins', sans-serif;
   margin:0; padding:0;
   box-sizing: border-box;
   outline: none; border:none;
   text-decoration: none;
}

.form-container{
   min-height: 100vh;
   display: flex;
   align-items: center;
   justify-content: center;
   padding:20px;
   padding-bottom: 60px;
   background: #eee;
}

.form-container form{
   padding:20px;
   border-radius: 5px;
   box-shadow: 0 5px 10px rgba(0,0,0,.1);
   background: #fff;
   text-align: center;
   width: 500px;
}

.form-container form h3{
   font-size: 30px;
   text-transform: uppercase;
   margin-bottom: 10px;
   color:#333;
}

.form-container form input,
.form-container form select{
   width: 100%;
   padding:10px 15px;
   font-size: 17px;
   margin:8px 0;
   background: #eee;
   border-radius: 5px;
}

.form-container form select option{
   background: #fff;
}

.form-container form .form-btn{
   background: #fbd0d9;
   color:crimson;
   text-transform: capitalize;
   font-size: 20px;
   cursor: pointer;
}

.form-container form .form-btn:hover{
   background: crimson;
   color:#fff;
}

.form-container form p{
   margin-top: 10px;
   font-size: 20px;
   color:#333;
}

.form-container form p a{
   color:crimson;
}

.form-container form .error-msg{
   margin:10px 0;
   display: block;
   background: crimson;
   color:#fff;
   border-radius: 5px;
   font-size: 20px;
   padding:10px;
}
   </style>

</head>
<body>
   
<div class="form-container">

   <form action="" method="post">
      <h3>Reset</h3>
      <?php
      if(isset($error)){
         foreach($error as $error){
            echo '<span class="error-msg">'.$error.'</span>';
         };
      };
      ?>
      <input type="text" name="EmployeeID" required placeholder="enter your EmployeeID">
      <input type="text" name="usertype" required placeholder="enter your Usertype">
      <input type="text" name="name" required placeholder="enter your Name">
      <input type="text" name="surname" required placeholder="enter your Surname">
      <input type="text" name="departement" required placeholder="enter your departement">
      <input type="text" name="email" required placeholder="enter your email">

      <input type="submit" name="submit" value="Reset" class="form-btn">
      <p>Remember Password? <a href="login.php">Login</a></p>
   </form>

</div>

</body>
</html>