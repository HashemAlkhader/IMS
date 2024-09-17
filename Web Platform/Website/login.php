<?php

session_start();


if(isset($_POST['submit'])){

    $dbsign = new mysqli("localhost", "root", "", "tsa");
	  if (mysqli_connect_errno()) 
	  {
		 printf("Connect failed: %s", mysqli_connect_error());
		 exit();
	  } 

    $emp_id = $_POST["EmployeeID"];
    $pass = md5($_POST["Password"]);
    
   $select = " SELECT * FROM employees WHERE EmployeeID = '$emp_id' && Password = '$pass' ";

   $result = mysqli_query($dbsign, $select);

   if(mysqli_num_rows($result) > 0){

      $row = mysqli_fetch_array($result);//Fetch a result row as a numeric array and as an associative array
    
      if($row['UserType'] == 'admin'){
         $_SESSION['loggedin'] = TRUE;
         $_SESSION['admin_name'] = $row['Name'];
         echo"<script>alert('You logged in as an admin')</script>";
         header('Refresh:1 profile.php');

      }elseif($row['UserType'] == 'user'){   
         $_SESSION['loggedin'] = TRUE;
         $_SESSION['user_name'] = $row['Name'];
         echo"<script>alert('You logged in as a user')</script>";
         header('Location:profile.php');
      }
     
   }else{
      $error[] = 'incorrect email or password!';
   }
};
?>

<!DOCTYPE html>
<html lang="en">
<head>
   <meta charset="UTF-8">
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <title>login form</title>

   <!-- custom css file link  -->
   <!-- <link rel="stylesheet" href="style.css"> -->

   <style>
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
   
<div class="form-container" style="background: linear-gradient(90deg, rgba(71,9,121,1) 20%, rgba(140,56,250,1) 69%);">

   <form action="" method="post">
      <h3>login now</h3>
      <?php
      if(isset($error)){
         foreach($error as $error){
            echo '<span class="error-msg">'.$error.'</span>';
         };
      };
      ?>
      <input type="text" name="EmployeeID" required placeholder="enter your EmployeeID">
      <input type="password" name="Password" required placeholder="enter your password">
      <input type="submit" name="submit" value="login now" class="form-btn" >
      <p >Forgot password? <a href="reset.php" style="color: purple;">reset password</a></p>
      <p >don't have an account? <a href="register.php" style="color: purple;">register now</a></p>
   </form>

</div>

</body>
</html>