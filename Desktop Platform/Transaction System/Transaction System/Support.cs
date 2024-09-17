using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transaction_System
{
    public partial class Support : Form
    {
        public Support()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string emailTo = txtSend.Text;
            string emailFrom = txtFrom.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailTo);
            Match match2 = regex.Match(emailFrom);

            if ((!match.Success) || (!match2.Success))
            {
                MessageBox.Show("Email format is wrong", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                String to, from, pass, mail;
                to = (txtSend.Text).ToString();
                from = (txtFrom.Text).ToString();
                mail = (txtComment.Text).ToString();
                pass = (txtCpws.Text).ToString();

                MailMessage m = new MailMessage();
                m.To.Add(to);
                m.From = new MailAddress(from);
                m.Body = mail;
                m.Subject = txtSubject.Text;

                SmtpClient smtp = new SmtpClient("smtp.hotmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 25;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(m);
                    MessageBox.Show("Email has sent successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
