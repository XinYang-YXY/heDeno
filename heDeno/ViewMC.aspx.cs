using heDenoDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace heDeno
{
    public partial class ViewMC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("/Login", false);
                }
                else
                {
                    Session["Appointment_id"] = null;
                    List<MedicalCertificate> mcList = new List<MedicalCertificate>();

                    MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                    mcList = client.SelectMCById(Session["id"].ToString()).ToList<MedicalCertificate>();

                    mc_repeater.Visible = true;
                    mc_repeater.DataSource = mcList;
                    mc_repeater.DataBind();
                }
            }
            else
            {
                Response.Redirect("/Login", false);
            }
        }

        protected void mc_repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewMc")
            {
                //HiddenField id = e.Item.FindControl("hidden_id") as HiddenField;

                //Session["Appointment_id"] = id.Value;
                //Response.Redirect("PatientMC.aspx");

            }
        }
    }
}