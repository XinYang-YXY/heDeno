using heDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace heDeno
{
    public partial class ViewAppointment : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Appointment_id"] = null;
            List<Appointment> appList = new List<Appointment>();

            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            appList = client.GetAppointmentsByPatientId(1).ToList<Appointment>();

            appointment_repeater.Visible = true;
            appointment_repeater.DataSource = appList;
            appointment_repeater.DataBind();
        }

        protected void appointment_repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "UpdateAppointment")
            {
                HiddenField id = e.Item.FindControl("hidden_id") as HiddenField;

                Session["Appointment_id"] = id.Value;
                Response.Redirect("UpdateAppointment.aspx");

            }
        }
    }
}