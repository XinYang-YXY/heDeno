using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;


namespace heDeno
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            if (isPwdStrong(tb_password.Text))
            {
                if (tb_password.Text == tb_cfmPassword.Text)
                {
                    Guid uuid = Guid.NewGuid();
                    MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                    int result = client.CreatePatient(uuid, tb_email.Text, tb_phoneNum.Text,
                        tb_firstName.Text, tb_lastName.Text,
                        DateTime.Parse(tb_dob.Text), (rb_male.Checked) ? "Male" : "Female",
                        tb_password.Text);

                    if (result == 1)
                    {
                        SendEmailVerification(tb_email.Text, "http://localhost:50198/Verify?id=" + uuid);
                        Response.Redirect("ConfirmEmail");
                        System.Diagnostics.Debug.WriteLine("New patient created");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("MySQL Error. Insert failure");
                    }
                }
                else
                {
                    lbl_forPwdStrength.Text = "Your confirm password is not the same";
                }
            }

        }

        protected void SendEmailVerification(string to, string apiUrl)
        {
            string senderEmail = Environment.GetEnvironmentVariable("gMail").ToString();
            string senderPwd = Environment.GetEnvironmentVariable("gPwd").ToString();

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(senderEmail, senderPwd),
                EnableSsl = true
            };

            string subject = "HeDeno Support - Email Verification";
            string message = string.Format(
                "<div style=\"text-align: center;\">" +
                "<h3>Email Verification</h3>" +
                "<p>Thank you for Choosing HeDeno! Please confirm your email address by clicking the link below.</p>" +
                "<a href=\"{0}\" style=\"background-color:rgba(0, 0, 0, 0);color: #5c73f2;border: 2px solid #5c73F2;padding:8px;\">Verify your email address</a>" +
                "</div>", apiUrl);
            MailMessage mail = new MailMessage(senderEmail, to, subject, message);
            mail.IsBodyHtml = true;
            client.Send(mail);
        }

        private bool isPwdStrong(string password)
        {
            if (password.Length < 8)
            {
                lbl_forPwdStrength.Text = "Password length MUST be at least 8";
                return false;
            }
            if (!Regex.IsMatch(password, "[a-z]"))
            {
                lbl_forPwdStrength.Text = "Password MUST have at least 1 character";
                return false;
            }
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                lbl_forPwdStrength.Text = "Password MUST have at least 1 uppercase character";
                return false;
            }
            if (!Regex.IsMatch(password, "[0-9]"))
            {
                lbl_forPwdStrength.Text = "Password MUST have at least 1 number";
                return false;
            }
            lbl_forPwdStrength.Text = "";
            return true;
        }

    }
}