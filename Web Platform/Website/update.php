<?php
session_start();
require 'config.php';
?>

<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">

    <title>Update Invoice</title>
</head>
<body>
    <div class="container mt-5">

        <?php include('message.php'); ?>

        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4>Update Invoice
                            <a href="view.php" class="btn btn-danger float-end">BACK</a>
                        </h4>
                    </div>
                    <div class="card-body">

                        <?php
                        if(isset($_GET['InvoiceID']))
                        {
                            $emp_id = mysqli_real_escape_string($con, $_GET['InvoiceID']);

                            $query = "SELECT * FROM invoice_activity WHERE InvoiceID='$emp_id' ";
                            $query2 = "SELECT * FROM customers WHERE InvoiceID='$emp_id' ";
                            $query_run = mysqli_query($con, $query);
                            $query_run2 = mysqli_query($con, $query2);

                            if((mysqli_num_rows($query_run) > 0) || (mysqli_num_rows($query_run2) > 0))
                            {
                                $emp = mysqli_fetch_array($query_run);
                                $emp2 = mysqli_fetch_array($query_run2);

                                ?>
                                <form action="code.php" method="POST">
                                <input type="hidden" name="emp_id" value="<?= $emp['EmployeeID']; ?>">
                                <input type="hidden" name="invoice_id" value="<?= $emp['InvoiceID']; ?>">

                                    <div class="mb-3">
                                        <label>Name</label>
                                        <input type="text" name="name" value="<?=$emp2['Name'];?>" class="form-control">
                                    </div>

                                    <div class="mb-3">
                                        <label>Surname</label>
                                        <input type="text" name="surname" value="<?=$emp2['Surname'];?>" class="form-control">
                                    </div>

                                    <div class="mb-3">
                                        <label>Invoice Type</label>
                                        <input type="text" name="invoice_types" value="<?=$emp['InvoiceType'];?>" class="form-control">
                                    </div>
                                    <div class="mb-3">
                                        <label>Status</label>
                                        <input type="text" name="status" value="<?=$emp['Status'];?>" class="form-control">
                                    </div>
                                    <div class="mb-3">
                                        <label>Date</label>
                                        <input type="date" name="date" value="<?=$emp['Date'];?>" class="form-control">
                                    </div>
                                    <div class="mb-3">
                                        <label>Comment</label>
                                        <input type="text" name="comment" value="<?=$emp['Comment'];?>" class="form-control">
                                    </div>
                                    <div class="mb-3">
                                        <button type="submit" name="update_invoices" class="btn btn-primary">
                                            Update
                                        </button>
                                    </div>

                                </form>
                                <?php
                            }
                            else
                            {
                                echo "<h4>No Such Id Found</h4>";
                                echo "<script>alert('error');</script><h4>No Such Id Found</h4>";

                            }
                        }
                        ?>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
