<?php
session_start();
require 'config.php';


/* add invoice */
if(isset($_POST['save_invoice']))
{
    // mysqli_real_escape_string for protection
    $name = mysqli_real_escape_string($con, $_POST['name']);
    $surname = mysqli_real_escape_string($con, $_POST['surname']);
    $gender = mysqli_real_escape_string($con, $_POST['Gender']);
    $nationality = mysqli_real_escape_string($con, $_POST['nationality']);
    $phone_no = mysqli_real_escape_string($con, $_POST['Phone_Number']);

    //second table
    $emp_id = mysqli_real_escape_string($con, $_POST['employee_ID']);
    $invoiceType = mysqli_real_escape_string($con, $_POST['invoice_type']);
    $status = mysqli_real_escape_string($con, $_POST['status']);
    $date = mysqli_real_escape_string($con, $_POST['date']);
    $comment = mysqli_real_escape_string($con, $_POST['comment']);

    $query = "INSERT INTO customers (Name,Surname,Gender,Nationality, PhoneNumber) VALUES ('$name','$surname','$gender','$nationality',$phone_no)";
    $query2 = "INSERT INTO invoice_activity (EmployeeID,InvoiceType,Status,Date, Comment) VALUES ('$emp_id','$invoiceType','$status','$date','$comment')";

    $query_run = mysqli_query($con, $query);
    $query_run2 = mysqli_query($con, $query2);
    if ($query_run)
    {
       // $_SESSION['message'] = "Customer Activity Invoice Created Successfully";
        $_SESSION['message'] = "Customer Invoice Created Successfully";
        header("Location: add.php");
        exit(0);
    }
    else
    {
        //$_SESSION['message'] = "Customer Activity Invoice Not Created";
        $_SESSION['message'] = "Customer Invoice Not Created";
        header("Location: add.php");
        exit(0);
    }
    if ($query_run2)
    {
        $_SESSION['message'] = "Customer Activity Invoice Created Successfully";
        //$_SESSION['message'] = "Customer Invoice Created Successfully";
        header("Location: add.php");
        exit(0);
    }
    else
    {
        $_SESSION['message'] = "Customer Activity Invoice Not Created";
       // $_SESSION['message'] = "Customer Invoice Not Created";
        header("Location: add.php");
        exit(0);
    }  
}
// Update invoices
if(isset($_POST['update_invoices']))
{
    $emp_id = mysqli_real_escape_string($con, $_POST['emp_id']);
    $invoice_id= mysqli_real_escape_string($con, $_POST['invoice_id']);

    $name = mysqli_real_escape_string($con, $_POST['name']);
    $surname = mysqli_real_escape_string($con, $_POST['surname']);

    $invoice_type = mysqli_real_escape_string($con, $_POST['invoice_types']);
    $status = mysqli_real_escape_string($con, $_POST['status']);
    $date = mysqli_real_escape_string($con, $_POST['date']);
    $comment = mysqli_real_escape_string($con, $_POST['comment']);

    $query = "UPDATE invoice_activity SET InvoiceType='$invoice_type', Status='$status', Date='$date', Comment='$comment' WHERE EmployeeID='$emp_id' ";
    $query = "UPDATE customers SET Name='$name',Surname='$surname' WHERE InvoiceID='$invoice_id' ";
    $query_run = mysqli_query($con, $query);

    if($query_run)
    {
        $_SESSION['message'] = "Invoice Updated Successfully";
        header("Location: update.php");
        exit(0);
    }
    else
    {
        $_SESSION['message'] = "Invoice Not Updated";
        header("Location: update.php");
        exit(0);
    }

}
// Delete Invoice
if(isset($_POST['delete_invoice']))
{
    $invoice_id = mysqli_real_escape_string($con, $_POST['delete_invoice']);

    $query = "DELETE FROM invoice_activity WHERE InvoiceID='$invoice_id' ";
    $query_run = mysqli_query($con, $query);

    if($query_run)
    {
        $_SESSION['message'] = "Invoice Deleted Successfully";
        header("Location: view.php");
        exit(0);
    }
    else
    {
        $_SESSION['message'] = "Invoice Not Deleted";
        header("Location: view.php");
        exit(0);
    }
}

?>