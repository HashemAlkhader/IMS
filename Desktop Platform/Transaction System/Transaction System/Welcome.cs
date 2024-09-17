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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e) 
         {
          if (progressBar1.Value < 100)
            {

                progressBar1.Value += 1;
                lblload.Text = progressBar1.Value.ToString() + "% Loading...";

            }
            else
            {
                timer1.Stop();
                Login l = new Login();
                l.Show();
                this.Hide();
            }
        }



        private void Welcome_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
      

    }
}
