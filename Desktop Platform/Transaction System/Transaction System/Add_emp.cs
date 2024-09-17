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
    public partial class Add_emp : Form
    {
        db dbms = new db();
        DataTable dt = new DataTable();

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=tsa");
        MySqlCommand cmd;
        String empName, empSurname, empdept, empEmail, empPws, empCPws;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            generatePassword();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Only Alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Add_emp()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            
            empName = txtName.Text; empSurname = txtSurname.Text; empdept = txtDept.Text; empEmail = txtEmail.Text; empPws = txtCpws.Text;

            if ((empName == "") || (empSurname == "") || (empEmail == "") || (empPws == "")) { MessageBox.Show("Please Check All the Information and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else if (!match.Success)
            {
                MessageBox.Show("Email format is wrong", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String insertt = "INSERT INTO employees(Name,Surname,Departement,Email,Password)values('" + this.txtName.Text + "','" + this.txtSurname.Text + "','" + this.txtDept.Text + "','" + this.txtEmail.Text + "','" + this.txtCpws.Text + "');";
                MySqlCommand insert = new MySqlCommand(insertt);
    
                insert.Parameters.AddWithValue("@Names", empName);
                insert.Parameters.AddWithValue("@Surnames", empSurname);
                insert.Parameters.AddWithValue("@Departement", empdept);
                insert.Parameters.AddWithValue("@Email", empEmail);
                insert.Parameters.AddWithValue("@Password", empPws);

                int row = dbms.executeQuery(insert);
                if (row == 1) { MessageBox.Show("Employees' info is created Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Error Occured!, please try again", "error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
            }
        }
        private void txtCpws_Enter(object sender, EventArgs e)
        {
           generatePassword();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";txtSurname.Text = "";txtDept.Text = "";txtEmail.Text = "";txtCpws.Text = "";
        }
        private void generatePassword()
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

            txtCpws.Text = new_password;
        }
    }
}
