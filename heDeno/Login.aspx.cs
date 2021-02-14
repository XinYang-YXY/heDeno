using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Http;
using System.Threading.Tasks;

using heDenoDB.Entity;

namespace heDeno
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            Patient patient = client.getPatientByEmail(tb_email.Text, tb_password.Text);
            if (patient != null)
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:50198/");

                bool isEmailVerified = false;
                Task<HttpResponseMessage> responseTask;
                responseTask = httpClient.GetAsync("api/verify?email=" + tb_email.Text);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<bool>();
                    readTask.Wait();
                    isEmailVerified = readTask.Result;
                }

                if (isEmailVerified)
                {
                    Session["user"] = $"{patient.FirstName} {patient.LastName}";
                    Session["id"] = patient.SecretId;

                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                    System.Diagnostics.Debug.WriteLine(Session["user"].ToString());
                    System.Diagnostics.Debug.WriteLine(Session["id"].ToString());
                    Response.Redirect("/", false);
                } 
                else
                {
                    lbl_error.Text = "Please verify your email first";
                }




            }
            else
            {
                lbl_error.Text = "Wrong Email or Password";
                System.Diagnostics.Debug.WriteLine("Patient does not exist");

            }
        }
    }
}