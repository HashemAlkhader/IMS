using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transaction_System
{
    public partial class Signup : Form
    {
        db dbms = new db();
        DataTable dt = new DataTable();

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=tsa");
        MySqlCommand cmd;
        String empName, empSurname, empdept, empEmail, empPws, empCPws, type;
        public Signup()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        { Login l = new Login(); l.Show(); this.Hide(); }

        private void txtname_Click_1(object sender, EventArgs e)
        {
            if (txtsurname.Text == "") { txtsurname.Text = "Surname"; }
            if (txtdept.Text == "") { txtdept.Text = "Departement"; }
            if (txtcpws.Text == "") { txtcpws.Text = "Confirm Password"; }
            if (txtpws.Text == "") { txtpws.Text = "Password"; }
            if (txtemail.Text == "") { txtname.Text = "Email"; }
            if (txtcaptcha.Text == "") { txtcaptcha.Text = "Captcha"; }
            txtname.Clear();
            colorChanged();
        }

        private void txtsurname_Click_1(object sender, EventArgs e)
        {
            if (txtemail.Text == "") { txtemail.Text = "Email"; }
            if (txtdept.Text == "") { txtdept.Text = "Departement"; }
            if (txtcpws.Text == "") { txtcpws.Text = "Confirm Password"; }
            if (txtpws.Text == "") { txtpws.Text = "Password"; }
            if (txtname.Text == "") { txtname.Text = "Name"; }
            if (txtcaptcha.Text == "") { txtcaptcha.Text = "Captcha"; }
            txtsurname.Clear();
            colorChanged();
        }

        private void txtdept_Click_1(object sender, EventArgs e)
        {
            if (txtsurname.Text == "") { txtsurname.Text = "Surname"; }
            if (txtdept.Text == "") { txtdept.Text = "Departement"; }
            if (txtemail.Text == "") { txtcpws.Text = "Email"; }
            if (txtpws.Text == "") { txtpws.Text = "Password"; }
            if (txtname.Text == "") { txtname.Text = "Name"; }
            if (txtcaptcha.Text == "") { txtcaptcha.Text = "Captcha"; }
            txtdept.Clear();
            colorChanged();
        }

        private void txtemail_Click_1(object sender, EventArgs e)
        {
            if (txtsurname.Text == "") { txtsurname.Text = "Surname"; }
            if (txtdept.Text == "") { txtdept.Text = "Departement"; }
            if (txtcpws.Text == "") { txtcpws.Text = "Confirm Password"; }
            if (txtpws.Text == "") { txtpws.Text = "Password"; }
            if (txtname.Text == "") { txtname.Text = "Name"; }
            if (txtcaptcha.Text == "") { txtcaptcha.Text = "Captcha"; }
            txtemail.Clear();
            colorChanged();
        }

        private void txtpws_Click_1(object sender, EventArgs e)
        {
            if (txtsurname.Text == "") { txtsurname.Text = "Surname"; }
            if (txtdept.Text == "") { txtdept.Text = "Departement"; }
            if (txtemail.Text == "") { txtemail.Text = "Email"; }
            if (txtcpws.Text == "") { txtcpws.Text = "Confirm Password"; }
            if (txtname.Text == "") { txtname.Text = "Name"; }
            if (txtcaptcha.Text == "") { txtcaptcha.Text = "Captcha"; }
            txtpws.Clear();
            colorChanged();
        }

        private void txtcpws_Click_1(object sender, EventArgs e)
        {
            if(txtsurname.Text == ""){txtsurname.Text = "Surname";}
            if(txtdept.Text == ""){txtdept.Text = "Departement"; }
            if(txtemail.Text == ""){txtemail.Text = "Email";  }
            if(txtpws.Text == ""){txtpws.Text = "Password"; }
            if(txtname.Text == ""){txtname.Text = "Name"; }
            if(txtcaptcha.Text == ""){txtcaptcha.Text = "Captcha";}
            txtcpws.Clear();
            colorChanged();
        }

        private void txtcaptcha_Click_1(object sender, EventArgs e)
        {
            if (txtname.Text == "") { txtname.Text = "Name"; }
            if (txtsurname.Text == "") { txtsurname.Text = "Surname"; }
            if(txtdept.Text == "") { txtdept.Text = "Departement"; }
            if(txtemail.Text == "") { txtemail.Text = "Email"; }
            if(txtpws.Text == "") { txtpws.Text = "Password"; }
            if(txtcpws.Text == "") txtcpws.Text = "Confirm Password";
            txtcaptcha.Clear();
            colorChanged();
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Only Alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsign_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
          

            empName = txtname.Text; empSurname = txtsurname.Text; empdept = txtdept.Text; empEmail = txtemail.Text; empPws = txtpws.Text; empCPws = txtcpws.Text; type = comboType.Text;
            String a = Encryption.HashString(empPws); 
            if ((empName == "") || (empSurname == "") || (empEmail == "") || (empPws == "")){ MessageBox.Show("Please Check All the Information and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if(empPws != empCPws){MessageBox.Show("Password don't match, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  }
            else if (!match.Success)
            {
                MessageBox.Show("Email format is wrong", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                String insertt = "INSERT INTO employees(UserType,Name,Surname,Departement,Email,Password)values('" + this.comboType.Text + "', '" + this.txtname.Text + "','" + this.txtsurname.Text + "','" + this.txtdept.Text + "','" + this.txtemail.Text + "','" + a + "');";
                MySqlCommand insert = new MySqlCommand(insertt);

                // SqlCommand insert = new SqlCommand("insert into Worker(Name,Surname,Age,Gender,DominantHand,Departement,TaskName,TaskNumber)values(@Names,@Surnames,@age,@gender,@hand,@dept,@task_name,@task_no)");
                //to make the data secure,make the database private
                insert.Parameters.AddWithValue("@type", type);
                insert.Parameters.AddWithValue("@Names", empName);
                insert.Parameters.AddWithValue("@Surnames", empSurname);
                insert.Parameters.AddWithValue("@Departement", empdept);
                insert.Parameters.AddWithValue("@Email", empEmail);
                insert.Parameters.AddWithValue("@Password", empPws);

                int row = dbms.executeQuery(insert);
                if (row == 1){ MessageBox.Show("Employees' info is created Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                else{MessageBox.Show("Error Occured!, please try again", "error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);}
            }
        }
        private void lbllogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            txtpws.UseSystemPasswordChar = true; txtcpws.UseSystemPasswordChar = true;
            comboType.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void checkshow_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkshow.Checked) {   txtpws.UseSystemPasswordChar = true; txtcpws.UseSystemPasswordChar = true;}
            else{txtpws.UseSystemPasswordChar = false; txtcpws.UseSystemPasswordChar = false;}
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

            panel5.BackColor = Color.FromArgb(72, 37, 134);
            txtpws.ForeColor = Color.FromArgb(72, 37, 134);

            panel6.BackColor = Color.FromArgb(72, 37, 134);
            txtcpws.ForeColor = Color.FromArgb(72, 37, 134);

            panel7.BackColor = Color.FromArgb(72, 37, 134);
            txtcaptcha.ForeColor = Color.FromArgb(72, 37, 134);
        }
    }
}
