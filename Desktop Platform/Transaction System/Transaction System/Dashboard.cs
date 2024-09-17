using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transaction_System
{
    public partial class Dashboard : Form
    {
        db dbms = new db();
        DataTable dt = new DataTable();

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=tsa");
        MySqlCommand cmd;
        public Dashboard()
        {
            InitializeComponent();
        }
        public void Dashboard_Load(object sender, EventArgs e)
        {
            String b = Login.id, query = "Select COUNT(*) from employees", user = lblUsers.Text,surnames = lblID.Text, dept = "Accountant", a = null, verified = "Verified", pending = "Pending", cancelled = "Cancelled";
   
            dbms.readDatathroughAdapter(query, dt);//used to read the data in db sequentially

            MySqlCommand cmd = new MySqlCommand("Select COUNT(*) from employees", con);
            con.Open();
            lblUsers.Text = cmd.ExecuteScalar().ToString();
            con.Close();

            MySqlCommand cmd2 = new MySqlCommand("Select COUNT(InvoiceID) from invoice_activity" , con);
            con.Open();
            lblInvoices.Text = cmd2.ExecuteScalar().ToString();
            con.Close();

            MySqlCommand cmd3 = new MySqlCommand("Select EmployeeID from employees where"
                                                 + " EmployeeID='" + b + "'", con);
            con.Open();
            lblID.Text = cmd3.ExecuteScalar().ToString();
            con.Close();

            MySqlCommand cmd4 = new MySqlCommand("Select COUNT(Status) from invoice_activity" +
                                                 " where Status='" + verified + "'", con);
            con.Open();
            lblVI.Text = cmd4.ExecuteScalar().ToString();
            con.Close();

            MySqlCommand cmd5 = new MySqlCommand("Select COUNT(Status) from invoice_activity where Status='" + pending + "'", con);
            con.Open();
            lblPI.Text = cmd5.ExecuteScalar().ToString();
            con.Close();

            MySqlCommand cmd6 = new MySqlCommand("Select COUNT(Status) from invoice_activity where Status='" + cancelled + "'", con);
            con.Open();
            lblCI.Text = cmd6.ExecuteScalar().ToString();
            con.Close();

            if(Login.id != "220220")
            {
                lblUsersName.Text = "Input\nTypes";

                MySqlCommand cmd7 = new MySqlCommand("Select COUNT(InvoiceType) from invoice_activity", con);
                con.Open();
                lblUsers.Text = cmd7.ExecuteScalar().ToString();
                con.Close();
            }

        }
    }
}
