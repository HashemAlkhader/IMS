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
    public partial class CreateInvoice : Form
    {
        db dbms = new db();
        DataTable dt = new DataTable();

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=tsa");
        MySqlCommand cmd;
        public CreateInvoice()
        {
            InitializeComponent();    
        }
        
        private void Create_Invoice_emp_Load(object sender, EventArgs e)
        {
            if (Login.id == "220220"){ txtEmpID.Enabled = true;}
            else
            {txtEmpID.Enabled = false;grplbl.Text = "Create a New Invoice";}
            txtEmpID.Text = Login.id;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            String type = comboType.Text, comment = txtComment.Text, date = dateTimePicker1.Text, status = comboStatus.Text, login = Login.id, employeeID = txtEmpID.Text, name = txtName.Text, surname = txtSurname.Text, gender = comboGender.Text, nationality = txtNationality.Text, phone = txtPhone.Text;

            if ((type == "") || (comment == "") || (date == "") || (status == "") || (employeeID == "") || (name == "") || (surname == "")) {MessageBox.Show("Please Check All the Information and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                String insertt = "INSERT INTO invoice_activity(EmployeeID,InvoiceType,Status,Date,Comment)values('" + this.txtEmpID.Text + "','" + this.comboType.Text + "','" + this.comboStatus.Text + "','" + this.dateTimePicker1.Text + "','" + this.txtComment.Text + "');";
                String insertt2 = "INSERT INTO customers(Name,Surname,Gender,Nationality,PhoneNumber)values('" + this.txtName.Text + "','" + this.txtSurname.Text + "','" + this.comboGender.Text + "','" + this.txtNationality.Text + "','" + this.txtPhone.Text + "');";

                MySqlCommand insert = new MySqlCommand(insertt);
                MySqlCommand insert2 = new MySqlCommand(insertt2);

                insert.Parameters.AddWithValue("@employeeid", login);
                insert.Parameters.AddWithValue("@invoicetype", type);
                insert.Parameters.AddWithValue("@status", status);
                insert.Parameters.AddWithValue("@date", date);
                insert.Parameters.AddWithValue("@comment", comment);

                insert2.Parameters.AddWithValue("@Name", name);
                insert2.Parameters.AddWithValue("@Surname", surname);
                insert2.Parameters.AddWithValue("@Gender", gender);
                insert2.Parameters.AddWithValue("@Nationality", nationality);
                insert2.Parameters.AddWithValue("@phone", phone);

                int row = dbms.executeQuery(insert);
                int row2 = dbms.executeQuery(insert2);

                if ((row == 1 ) || (row2 == 1)) { MessageBox.Show("A new Customer is created Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                else{  MessageBox.Show("Error Occured!, please try again", "error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {txtComment.Text = "";dateTimePicker1.Text = "";comboStatus.Text = "";comboType.Text = ""; txtName.Text = ""; txtSurname.Text = ""; comboGender.Text = ""; txtNationality.Text = "";txtPhone.Text = ""; }

        private void grplbl_Enter(object sender, EventArgs e)
        {

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Only Alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmpID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) & (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Only Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
