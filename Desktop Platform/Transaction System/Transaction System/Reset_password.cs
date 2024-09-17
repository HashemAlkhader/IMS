using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transaction_System
{
    public partial class Reset_password : Form
    {
        db dbms = new db();
        DataTable dt = new DataTable();

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=tsa");
        MySqlCommand cmd;
        String empName, empSurname, empdept, empEmail, empPws, empCPws, empID;
        public static String name, surname, email, password, id, dept;

        private void txtemployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Only Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Only Alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Login l = new Login();l.Show();this.Hide();
        }

        public Reset_password()
        {
            InitializeComponent();
        }
        private void txtemployee_Click(object sender, EventArgs e)
        {
            if (txtsurname.Text == "") { txtsurname.Text = "Surname"; }
            if (txtdept.Text == "") { txtdept.Text = "Departement"; }
            if (txtname.Text == "") { txtname.Text = "Name"; }
            if (txtemail.Text == "") { txtname.Text = "Email"; }
            colorChanged();
            txtemployee.Clear();
        }

        private void txtname_Click(object sender, EventArgs e)
        {
            if (txtsurname.Text == "") { txtsurname.Text = "Surname"; }
            if (txtdept.Text == "") { txtdept.Text = "Departement"; }
            if (txtemployee.Text == "") { txtemployee.Text = "Employee ID"; }
            if (txtemail.Text == "") { txtname.Text = "Email"; }
            colorChanged();
            txtname.Clear();
        }

        private void txtsurname_Click(object sender, EventArgs e)
        {
            if (txtemployee.Text == "") { txtemployee.Text = "Employee ID"; }
            if (txtdept.Text == "") { txtdept.Text = "Departement"; }
            if (txtname.Text == "") { txtname.Text = "Name"; }
            if (txtemail.Text == "") { txtname.Text = "Email"; }
            colorChanged();
            txtsurname.Clear();     
        }

        private void txtdept_Click(object sender, EventArgs e)
        {
            if (txtsurname.Text == "") { txtsurname.Text = "Surname"; }
            if (txtemployee.Text == "") { txtemployee.Text = "Employee ID"; }
            if (txtname.Text == "") { txtname.Text = "Name"; }
            if (txtemail.Text == "") { txtname.Text = "Email"; }
            colorChanged();
            txtdept.Clear();      
        }

        private void txtemail_Click(object sender, EventArgs e)
        {
            if (txtsurname.Text == "") { txtsurname.Text = "Surname"; }
            if (txtdept.Text == "") { txtdept.Text = "Departement"; }
            if (txtname.Text == "") { txtname.Text = "Name"; }
            if (txtemployee.Text == "") { txtemployee.Text = "Email"; }
            colorChanged();
            txtemail.Clear();      
        }

        private void lbllogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l = new Login();l.Show();this.Hide();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            empName = txtname.Text;empdept = txtdept.Text;empEmail = txtemail.Text;empSurname = txtsurname.Text;empID = txtemployee.Text;

            if ((empName == "") || (empdept == "") || (empEmail == "") || (empSurname == "") || (empID == "")){ MessageBox.Show("Please Enter all the Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (!match.Success)
            {
                MessageBox.Show("Email format is wrong", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String query = "Select * from employees where EmployeeID = '" + empID + "'";
                dbms.readDatathroughAdapter(query, dt);//used to read the data in db sequentially
                if (dt.Rows.Count == 1)
                {
                    id = dt.Rows[0]["EmployeeID"].ToString();
                    name = dt.Rows[0]["Name"].ToString();
                    surname = dt.Rows[0]["Surname"].ToString();
                    dept = dt.Rows[0]["Departement"].ToString();
                    email = dt.Rows[0]["Email"].ToString();

                    dbms.closeConn();

                    if((empID == id) || (empName == name) || (empSurname == surname) || (empdept == dept) || (empEmail == email))
                    {
                        int count = 10;
                        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                        String new_password;
                        StringBuilder res = new StringBuilder();
                        Random rnd = new Random();
                        while (0 < count--)
                        {
                            res.Append(valid[rnd.Next(valid.Length)]);
                        }
                        new_password = res.ToString();

                        string Query = "update employees set Password='" + new_password + "' where EmployeeID='" + this.txtemployee.Text + "';";
                        MySqlCommand insert = new MySqlCommand(Query);

                        insert.Parameters.AddWithValue("@Password", new_password);
                        
                        int row = dbms.executeQuery(insert);
                        if (row == 1) { MessageBox.Show("Your New Password is " + "\n" + new_password, "", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                        else{ MessageBox.Show("Error Occured, sql error");}
                    }
                }
                else{MessageBox.Show("Information do not match, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            }
        }
        private void colorChanged()
        {
            panel1.BackColor = Color.FromArgb(72, 37, 134);
            txtname.ForeColor = Color.FromArgb(72, 37, 134);

            panel2.BackColor = Color.FromArgb(72, 37, 134);
            txtsurname.ForeColor = Color.FromArgb(72, 37, 134);

            panel3.BackColor = Color.FromArgb(72, 37, 134);
            txtdept.ForeColor = Color.FromArgb(72, 37, 134);

            panel4.BackColor = Color.FromArgb(72, 37, 134);
            txtemail.ForeColor = Color.FromArgb(72, 37, 134);
        }

    }
}
