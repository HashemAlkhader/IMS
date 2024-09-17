using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Transaction_System
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            customize();
        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
        private void customize()
        {  panelworkersubmenu.Visible = false; panelmethodssubmenu.Visible = false; }
        private void hidemenu()
        {   if (panelworkersubmenu.Visible == true) panelworkersubmenu.Visible = false; 
            if (panelmethodssubmenu.Visible == true)panelmethodssubmenu.Visible = false;}
        private void showsubmenu(Panel submenu)
        { if (submenu.Visible == false){ hidemenu();submenu.Visible = true;} else submenu.Visible = false;}

        private void btnDashboard_Click(object sender, EventArgs e) {hidemenu();}

        private void btnCreate_Click(object sender, EventArgs e){hidemenu();}

        private void btnEdit_Click(object sender, EventArgs e){ hidemenu(); }

        private void btnCreateEmployee_Click(object sender, EventArgs e){ hidemenu();}

        private void btnEditEmployee_Click(object sender, EventArgs e){ hidemenu(); }

        private void btnSupport_Click(object sender, EventArgs e){hidemenu();}

        private void btnHome_Click(object sender, EventArgs e){hidemenu();}

        private void btnworker_Click(object sender, EventArgs e){showsubmenu(panelworkersubmenu);}

        private void btninsertworker_Click(object sender, EventArgs e){loadform(new CreateInvoice()); hidemenu();}

        private void btnupdateworker_Click(object sender, EventArgs e){loadform(new Update());hidemenu();}

        private void btnmethods_Click(object sender, EventArgs e){showsubmenu(panelmethodssubmenu);}

        private void btnrula_Click(object sender, EventArgs e) { loadform(new Add_emp()); hidemenu();}

        private void btnreba_Click(object sender, EventArgs e){ loadform(new Update_emp()); hidemenu();}

        private void btnhelp_Click(object sender, EventArgs e){loadform(new Edit_profile());hidemenu();}

        private void btnlogout_Click(object sender, EventArgs e)
        {hidemenu(); DialogResult d = MessageBox.Show("Are you sure to logout?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Warning); if (d == DialogResult.Yes) { Login l = new Login(); l.Show(); this.Hide(); } }
        private void btnemployees_Click(object sender, EventArgs e) {loadform(new Dashboard());hidemenu();}

        private void Admin_panel_Load(object sender, EventArgs e){ if (Login.id != "220220"){ btnEmployees.Visible = false;} Text = "Profile - " + Login.id;}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadform(new Dashboard());
            hidemenu();
        }

        private void btnHelp_Click_1(object sender, EventArgs e)
        {
            loadform(new Support()); hidemenu();
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
