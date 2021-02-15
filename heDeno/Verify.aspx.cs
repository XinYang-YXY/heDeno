using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading.Tasks;

using System.Net.Mail;
using System.Net.Http;

using System.Net;

using System.IO;


namespace heDeno
{
    public partial class Verify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            
            string id = Request.QueryString["id"];
            HttpClient client = new HttpClient();

            // state the URI address that hosted the web API
            client.BaseAddress = new Uri("http://localhost:50198/");

            int data = 0;
            Task<HttpResponseMessage> responseTask;
            responseTask = client.GetAsync("api/verify?id=" + id);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<int>();
                readTask.Wait();
                data = readTask.Result;
            }

            if (data == 1)
            {
                lbl_result.Text = "Congratulations, you have verified your account! You can login now.";
            }
            
        }
    }
}