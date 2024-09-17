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
    public partial class Update_emp : Form
    {
        db dbms = new db();
        DataTable dt = new DataTable();

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=tsa");
        MySqlCommand cmd;
        public static String ids;
        Color selectionBackColor;
        Color selectionForeColor;
        public Update_emp()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string emaill = txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emaill);
            String employeeID = txtemployeeid.Text, name = txtName.Text, surname= txtSurname.Text, email = txtEmail.Text, departement = txtDept.Text, password = txtPassword.Text;
            if ((employeeID == "") || (name == "") || (surname == "") || (email == "") || (departement == "") || (password == "")) { MessageBox.Show("Please fill all the fields", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else if (!match.Success)
            {
                MessageBox.Show("Email format is wrong", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Query = "update employees set EmployeeID='" + this.txtemployeeid.Text + "' ,Name='" + this.txtName.Text + "',Surname='" + this.txtSurname.Text + "',Email ='" + this.txtEmail.Text + "',Password='" + this.txtPassword.Text + "' where EmployeeID='" + this.txtemployeeid.Text + "';";
                MySqlCommand insert = new MySqlCommand(Query);

                insert.Parameters.AddWithValue("@employeeID", employeeID);
                insert.Parameters.AddWithValue("@name", name);
                insert.Parameters.AddWithValue("@surname", surname);
                insert.Parameters.AddWithValue("@departement", departement);
                insert.Parameters.AddWithValue("@email", email);
                insert.Parameters.AddWithValue("@password", password);
                int row = dbms.executeQuery(insert);

                if (row == 1) { MessageBox.Show("Account setting Updated Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Check all the info"); }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            this.dataGridView1.DefaultCellStyle.SelectionForeColor = selectionForeColor;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtemployeeid.Text = row.Cells["EmployeeID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtSurname.Text = row.Cells["Surname"].Value.ToString();
                txtDept.Text = row.Cells["Departement"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }

        private void Update_emp_Load(object sender, EventArgs e)
        {
            String query = "Select EmployeeID,Name,Surname,Departement,Email,Password from employees";
            dbms.readDatathroughAdapter(query, dt);
            dataGridView1.DataSource = dt;
            dbms.closeConn();

            dataGridView1.Columns["EmployeeID"].ReadOnly = true;
            
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure to delete This Employee?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                String insertt = "DELETE FROM employees where EmployeeID = '" + this.txtemployeeid.Text + "';";
                MySqlCommand insertts = new MySqlCommand(insertt);

                int row = dbms.executeQuery(insertts);
                if (row == 1) { MessageBox.Show("The Employee has been Deleted Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Error Occured"); }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtemployeeid.Text = "";txtName.Text = "";txtSurname.Text = "";txtDept.Text = "";txtEmail.Text = ""; txtPassword.Text = "";
        }

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
