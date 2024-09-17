using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transaction_System
{
    public partial class Login : Form
    {
        db dbms = new db();
        DataTable dt = new DataTable();

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=tsa");
        MySqlCommand cmd;
        String empName, empSurname, empdept, empEmail, empPws, empCPws;
        public static String name, surname, email, passwords, id, dept;

        private void btnsign_Click(object sender, EventArgs e)
        {
            Signup s = new Signup(); s.Show();this.Hide();
        }

        private void txtemployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Only Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblreset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reset_password rp = new Reset_password(); rp.Show(); this.Hide();
        }

        private void checkshow_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkshow.Checked)
            {txtpws.UseSystemPasswordChar = true;}
            else{txtpws.UseSystemPasswordChar = false;}
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtpws.UseSystemPasswordChar = true;
            Random ran = new Random();
            int num = ran.Next(6, 8);
            string captcha = "";
            int tot = 0;
            do
            {
                int chr = ran.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 99) || (chr >= 97 && chr <= 122))
                {
                    captcha = captcha + (char)chr;
                    tot++;
                    if (tot == num)
                        break;
                    {

                    }
                }
            } while (true);
            lblcaptcha.Text = captcha;
        }

        public Login()
        {
            InitializeComponent();
        }

        private void lblsign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup s = new Signup(); s.Show(); this.Hide();
        }

        private void txtemployee_Click(object sender, EventArgs e)
        {
           
            if (txtpws.Text == ""){txtpws.Text = "Password";}    
            if (txtcaptcha.Text == ""){txtcaptcha.Text = "Captcha";}
            txtemployee.Clear();
            colorChanged();
        }

        private void txtpws_Click(object sender, EventArgs e)
        {
            if (txtemployee.Text == ""){txtemployee.Text = "Employee ID";}
            if (txtcaptcha.Text == "") {txtcaptcha.Text = "Captcha"; }
            txtpws.Clear();
            colorChanged();           
        }

        private void txtcaptcha_Click(object sender, EventArgs e)
        {
            if (txtpws.Text == ""){txtpws.Text = "Password";}
            if (txtemployee.Text == ""){txtemployee.Text = "Employee ID"; }
            txtcaptcha.Clear();
            colorChanged();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            String employee, password;
            employee = txtemployee.Text; password = txtpws.Text;

            if ((employee == "") || (password == "")){ MessageBox.Show("Please Enter all the Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            else if (lblcaptcha.Text != txtcaptcha.Text)
            {
                MessageBox.Show("Captcha is wrong, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcaptcha.Clear();
                Random ran = new Random();
                int num = ran.Next(6, 8);
                string captcha = "";
                int tot = 0;
                do
                {
                    int chr = ran.Next(48, 123);
                    if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 99) || (chr >= 97 && chr <= 122))
                    {
                        captcha = captcha + (char)chr;
                        tot++;
                        if (tot == num)
                            break;
                        {

                        }
                    }
                } while (true);
                lblcaptcha.Text = captcha;
            }
            else
            {
                String query = "Select * from employees where EmployeeID = '" + employee + "' AND Password = '" + password + "'";
                dbms.readDatathroughAdapter(query, dt);//used to read the data in db sequentially
                if (dt.Rows.Count == 1)
                {
                    id = dt.Rows[0]["EmployeeID"].ToString();
                    name = dt.Rows[0]["Name"].ToString();
                    surname = dt.Rows[0]["Surname"].ToString();
                    dept = dt.Rows[0]["Departement"].ToString();
                    email = dt.Rows[0]["Email"].ToString();
                    passwords = dt.Rows[0]["Password"].ToString();

                    dbms.closeConn();

                    if (txtemployee.Text == "220220")
                    {Profile ap = new Profile(); ap.Show(); this.Hide();}
                    else if (txtemployee.Text != "220220")
                    { Profile ap = new Profile(); ap.Show(); this.Hide();}
                }
                else{MessageBox.Show("ID/Password do not match, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);txtpws.Clear();txtemployee.Clear();}
            }
        }
        private void colorChanged()
        {
            panel1.BackColor = Color.FromArgb(72, 37, 134);
            txtemployee.ForeColor = Color.FromArgb(72, 37, 134);

            panel2.BackColor = Color.FromArgb(72, 37, 134);
            txtpws.ForeColor = Color.FromArgb(72, 37, 134);

            panel3.BackColor = Color.FromArgb(72, 37, 134);
            txtcaptcha.ForeColor = Color.FromArgb(72, 37, 134);
        }
    }
    
}
