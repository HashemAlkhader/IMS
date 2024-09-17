using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Transaction_System
{
    public partial class Update : Form
    {
        db dbms = new db();
        DataTable dt = new DataTable();

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=tsa");
        MySqlCommand cmd;
        public static String ids;
        Color selectionBackColor;
        Color selectionForeColor;
        public Update()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String employeeID = txtemployeeid.Text, invoiceID = txtInvoiceID.Text, invoiceType = txtInvoiceType.Text, status = txtStatus.Text, date = txtDate.Text, comment = txtComment.Text, name = txtName.Text, surname = txtSurname.Text, gender = txtGender.Text, nationality = txtNationality.Text;
            if ((employeeID == "") || (invoiceID == "") || (status == "") || (date == "") || (comment == "")){MessageBox.Show("Please fill all the fields", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            if ((Login.id != employeeID) && (Login.id != "220220")){ MessageBox.Show("You Can NOT update the other Employees' work", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
            else
            {
                string Query = "update invoice_activity set EmployeeID='" + this.txtemployeeid.Text + "' ,InvoiceType='" + this.txtInvoiceType.Text + "',Status='" + this.txtStatus.Text + "',Date ='" + this.txtDate.Text + "',Comment='" + this.txtComment.Text + "' where InvoiceID='" + this.txtInvoiceID.Text + "';";

                string Query2 = "update customers set Name='" + this.txtName.Text + "' ,Surname='" + this.txtSurname.Text + "',Gender='" + this.txtGender.Text + "',Nationality ='" + this.txtNationality.Text + "' where InvoiceID='" + this.txtInvoiceID.Text + "';";

                MySqlCommand insert = new MySqlCommand(Query);


                insert.Parameters.AddWithValue("@employeeID", employeeID);
                insert.Parameters.AddWithValue("@invoiceType", invoiceType);
                insert.Parameters.AddWithValue("@status", status);
                insert.Parameters.AddWithValue("@date", date);
                insert.Parameters.AddWithValue("@comment", comment);
                int row = dbms.executeQuery(insert);

                MySqlCommand insert2 = new MySqlCommand(Query2);
                insert2.Parameters.AddWithValue("@Name", name);
                insert2.Parameters.AddWithValue("@Surname", surname);
                insert2.Parameters.AddWithValue("@Gender", gender);
                insert2.Parameters.AddWithValue("@Nationality", nationality);
                int row2 = dbms.executeQuery(insert2);

                if ((row == 1) || (row2 == 1)){MessageBox.Show("Account setting Updated Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                else{ MessageBox.Show("Check all the info");}
              
            }
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = selectionForeColor;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtInvoiceID.Text = row.Cells["InvoiceID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSurname.Text = row.Cells["Surname"].Value.ToString();
                txtGender.Text = row.Cells["Gender"].Value.ToString();
                txtNationality.Text = row.Cells["Nationality"].Value.ToString();

                txtemployeeid.Text = row.Cells["EmployeeID"].Value.ToString();
                txtInvoiceType.Text = row.Cells["InvoiceType"].Value.ToString();
                txtStatus.Text = row.Cells["Status"].Value.ToString();
                txtDate.Text = row.Cells["Date"].Value.ToString();
                txtComment.Text = row.Cells["Comment"].Value.ToString();
            }
        }

        private void Update_Load(object sender, EventArgs e)
        {
            /*
            SELECT Orders.OrderID, Customers.CustomerName
            FROM Orders
            INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

             */
            String query3 = "SELECT invoice_activity.InvoiceID,invoice_activity.EmployeeID,customers.Name, customers.Surname,customers.Gender,customers.Nationality,invoice_activity.InvoiceType,invoice_activity.Status,invoice_activity.Date,invoice_activity.Comment from customers INNER JOIN invoice_activity ON customers.InvoiceID = invoice_activity.InvoiceID";


            String query = "Select InvoiceID,EmployeeID,InvoiceType,Status,Date,Comment from invoice_activity";
            dbms.readDatathroughAdapter(query3, dt);
            dataGridView1.DataSource = dt;
            dbms.closeConn();

            dataGridView1.Columns["InvoiceID"].ReadOnly = true;
            dataGridView1.Columns["EmployeeID"].ReadOnly = true;
            dataGridView1.Columns["Name"].ReadOnly = true;
            dataGridView1.Columns["Surname"].ReadOnly = true;
            dataGridView1.Columns["Gender"].ReadOnly = true;
            dataGridView1.Columns["Nationality"].ReadOnly = true;

            //dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(239, 230, 255);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
           // dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 230, 255);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            //dataGridView.

            dataGridView1.EnableHeadersVisualStyles = false;
            // dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(72, 37, 134);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if(Login.id == "220220"){txtemployeeid.Enabled = true;txtemployeeid.BackColor = Color.White;txtemployeeid.Cursor = Cursors.IBeam;btnDelete.Visible = true;  }
            else { btnClear.Location = new Point(613, 373); txtemployeeid.BackColor = Color.WhiteSmoke; }

            
            
                
               
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure to delete This Invoice?", "Delete Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                String insertt = "DELETE FROM invoice_activity where invoiceID = '" + this.txtInvoiceID.Text + "';";
                String insertt2 = "DELETE FROM customers where invoiceID = '" + this.txtInvoiceID.Text + "';";

                MySqlCommand insertts = new MySqlCommand(insertt);
                MySqlCommand insertts2 = new MySqlCommand(insertt2);

                int row = dbms.executeQuery(insertts);
                int row2 = dbms.executeQuery(insertts2);

                if ((row == 1) || (row2 == 1)){ MessageBox.Show("The Invoice has been Deleted Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                else{ MessageBox.Show("Error Occured"); }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInvoiceType.Text = "";txtStatus.Text = "";txtDate.Text = "";txtComment.Text = "";txtName.Text = "";txtSurname.Text = "";txtGender.Text = "";txtNationality.Text = "";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            String date = DateTime.Now.ToString("MM/dd/yyyy");
            e.Graphics.DrawString("My Invoice", new Font("Arial", 20, FontStyle.Bold), Brushes.Indigo, new Point(350, 150));
            e.Graphics.DrawString(date, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(20, 30));
            e.Graphics.DrawString("Linasoft", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(700, 30));
            e.Graphics.DrawString("Gazi Mustafa Kemal", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(700, 50));
            e.Graphics.DrawString("City,Famagusta", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(700, 70));
            e.Graphics.DrawString("99450", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(700, 90));
            e.Graphics.DrawString("North Cyprus", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(700, 110));
            e.Graphics.DrawString("90 544 339 9389", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(700, 130));
            e.Graphics.DrawString("Invoice ID:#", new Font("Arial", 10, FontStyle.Bold), Brushes.Indigo, new Point(100, 200));
            e.Graphics.DrawString(txtInvoiceID.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(180, 200));
            e.Graphics.DrawString("Invoice Type:", new Font("Arial", 10, FontStyle.Bold), Brushes.Indigo, new Point(100, 250));
            e.Graphics.DrawString(txtInvoiceType.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(190, 250));
            e.Graphics.DrawString("Invoice Status:", new Font("Arial", 10, FontStyle.Bold), Brushes.Indigo, new Point(100, 300));
            e.Graphics.DrawString(txtStatus.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(200, 300));
            e.Graphics.DrawString("Date:", new Font("Arial", 10, FontStyle.Bold), Brushes.Indigo, new Point(100, 350));
            e.Graphics.DrawString(txtDate.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(140, 350));
            e.Graphics.DrawString("Comment:", new Font("Arial", 10, FontStyle.Bold), Brushes.Indigo, new Point(100, 400));
            e.Graphics.DrawString(txtComment.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(100, 420));
            
            
            
            Image photo = Image.FromFile("C://Users//User//source//repos//Transaction System//images//invoice_ico.png");
            PrintDocument printDoc = new PrintDocument();
            Point ulCorner = new Point(370, 30);
            e.Graphics.DrawImage(photo, ulCorner);
            e.Graphics.DrawString("Invoice ID Verification", new Font("Arial", 10, FontStyle.Bold), Brushes.Indigo, new Point(580, 250));
            e.Graphics.DrawImage(pictureBox1.Image, new Point(600, 280));
            e.Graphics.DrawString("Employee ID", new Font("Arial", 10, FontStyle.Bold), Brushes.Indigo, new Point(600, 400));
            e.Graphics.DrawString(txtemployeeid.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(620, 420));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(1, 500));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.Document = printDocument1;

            DialogResult r = pd.ShowDialog();
            if(r == DialogResult.OK)
            {
                printDocument1.Print();
                MessageBox.Show("You have Saved the File as PDF", "Save as PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = String.Format("InvoiceType like '%" + txtSearch.Text + "%'");
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_MouseLeave(object sender, EventArgs e)
        {
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtInvoiceID_TextChanged(object sender, EventArgs e)
        {
            try
            {   
                    BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                    pictureBox1.Image = writer.Write(txtInvoiceID.Text);  
               
            }catch(Exception ee)
            {
                MessageBox.Show("Invoice ID should be filled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
