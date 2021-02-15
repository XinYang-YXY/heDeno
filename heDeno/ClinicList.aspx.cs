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
    public partial class ClinicList : System.Web.UI.Page
    {
        protected List<Clinic> clinicList;
        protected string specialty;

        protected void Page_Load(object sender, EventArgs e)
        {
            specialty = Request.QueryString["specialty"];
            getClinicList(specialty);

            if (!IsPostBack)
            {
                List<Specialty> specialtyList = new List<Specialty>();
                MyDenoDBServiceReference.Service1Client serviceClient = new MyDenoDBServiceReference.Service1Client();
                specialtyList = serviceClient.GetAllSpecialty().ToList<Specialty>();

                select_specialty.DataSource = specialtyList;
                select_specialty.DataTextField = "specialtyFull";
                select_specialty.DataValueField = "specialtyName";
                select_specialty.DataBind();

                select_specialty.Items.Insert(0, new ListItem("-- Select Specialty --", ""));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string selected_specialty = select_specialty.SelectedValue;
            getClinicList(selected_specialty);
        }

        protected void getClinicList(string specialty)
        {
            HttpClient client = new HttpClient();

            // state the URI address that hosted the web API
            client.BaseAddress = new Uri("http://localhost:50198/");

            Task<HttpResponseMessage> responseTask;
            responseTask = client.GetAsync("api/clinic?specialty=" + specialty);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<Clinic>>();
                readTask.Wait();
                clinicList = readTask.Result;
            }
        }
    }
}