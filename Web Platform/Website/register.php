<?php

 if (!empty($_POST))
  {
	  $dbsign = new mysqli("localhost", "root", "", "tsa");
	  if (mysqli_connect_errno()) 
	  {
		 printf("Connect failed: %s", mysqli_connect_error());
		 exit();
	  } 
      else
      {
            $user = $_POST["UserType"];
            $NAME = $_POST["Name"];
            $SURNAME = $_POST["Surname"];
            $DEPT = $_POST["Departement"];
            $email = $_POST["Email"];
            $pass = md5($_POST["Password"]);
            $cpass = md5($_POST["cpassword"]);
            

            $select = " SELECT * FROM employees WHERE Email = '$email' && Password = '$pass' ";
            $result = mysqli_query($dbsign, $select);
            if(mysqli_num_rows($result) > 0)
            {
                $error[] = 'user email already exists';
            }
            else
            {
                if($pass != $cpass)
                {
                    $error[] = 'passwords not matched';
                }
                else
                {
	                 $sql = "INSERT INTO employees (UserType,Name,Surname,Departement,Email,Password) VALUES('$user','$NAME','$SURNAME','$DEPT','$email','$pass')";//"SELECT * FROM loginform WHERE Username ='".$_POST["User"]."';";
	                 $res = mysqli_query($dbsign, $sql);
                     if($res)//check if the query has been excuted successfully or has an error
                     {
                         echo"<script>alert('The account has been created')</script>";
                         header("Refresh:1 login_form.php");
                     }
                }
            }
       
         }
         mysqli_close($dbsign);
     };
   
?> 


<!DOCTYPE html>
<html lang="en">
<head>
   <meta charset="UTF-8">
   <meta http-equiv="X-UA-Compatible" content="IE=edge">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <title>register form</title>

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
   
<div class="form-container" style="background: linear-gradient(45deg, #470979 0%, #b7fef1 100%);">


   <form action="" method="post">
      <h3>register now</h3>
      <?php
      if(isset($error)){
         foreach($error as $error){
            echo '<span class="error-msg">'.$error.'</span>';
         };
      };
      ?>
       <select name="UserType">
         <option value="user">user</option>
         <option value="admin">admin</option>
      </select>
      <input type="text" name="Name" required placeholder="enter your name">
      <input type="text" name="Surname" required placeholder="enter your surname">
      <input type="text" name="Departement" required placeholder="enter your departement">
      <input type="email" name="Email" required placeholder="enter your email">
      <input type="password" name="Password" required placeholder="enter your password">
      <input type="password" name="cpassword" required placeholder="confirm your password">

      <input type="submit" name="submit" value="register now" class="form-btn">
      <p>already have an account? <a href="login.php" style="color:purple;">login now</a></p>
   </form>

</div>

</body>
</html>