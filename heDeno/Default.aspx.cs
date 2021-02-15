using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using heDenoDB.Entity;

namespace heDeno
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Specialty> specialtyList = new List<Specialty>();
                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                specialtyList = client.GetAllSpecialty().ToList<Specialty>();

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
            Response.Redirect("ClinicList?specialty=" + selected_specialty);
        }
    }
}