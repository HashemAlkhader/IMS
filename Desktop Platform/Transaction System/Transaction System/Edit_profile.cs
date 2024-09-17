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
    public partial class Edit_profile : Form
    {
        db dbms = new db();
        DataTable dt = new DataTable();

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=tsa");
        MySqlCommand cmd;
        public Edit_profile()
        {
            InitializeComponent();
        }

        private void Edit_profile_Load(object sender, EventArgs e)
        {
            txtEmployee.Text = Login.id;
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            String Names = txtName.Text,Surnames = txtSurname.Text,dept = txtDept.Text,email = txtEmail.Text,password = txtPws.Text,cpassword = txtCpws.Text;
            if ((Names == "") || (Surnames == "") || (email == "") || (password == "") || (dept == "") || (cpassword == "") || (cpassword != Login.passwords))
            {
                MessageBox.Show("Please Check All Information and try again", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Query = "update employees set Name='" + this.txtName.Text + "',Surname='" + this.txtSurname.Text + "',Departement='" + this.txtDept.Text + "',Email='" + this.txtEmail.Text + "',Password='" + this.txtPws.Text + "' where EmployeeID='" + this.txtEmployee.Text + "';";
                MySqlCommand insert = new MySqlCommand(Query);

                insert.Parameters.AddWithValue("@Names", Names);
                insert.Parameters.AddWithValue("@Surnames", Surnames);
                insert.Parameters.AddWithValue("@dept", dept);
                insert.Parameters.AddWithValue("@email", email);
                insert.Parameters.AddWithValue("@password", password);

                int row = dbms.executeQuery(insert);
                if (row == 1){MessageBox.Show("Account info Updated Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                else{MessageBox.Show("Error Occured, sql error");}
            }
        }

        private void lblReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { Reset_password r = new Reset_password(); r.Show(); r.btnlogin.Visible = false; }

        private void btnClear_Click(object sender, EventArgs e)
        {txtName.Text = "";txtSurname.Text = "";txtDept.Text = "";txtEmail.Text = "";txtPws.Text = "";txtCpws.Text = "";}

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Only Alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
