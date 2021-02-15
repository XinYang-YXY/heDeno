using heDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using heDenoDB.Entity;

namespace heDeno
{
    public partial class ViewAppointment : System.Web.UI.Page
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
                    List<Appointment> appList = new List<Appointment>();
                    List<Appointment> pastAppList = new List<Appointment>();
                    List<Appointment> upcomingAppList = new List<Appointment>();

                    MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                    appList = client.GetAppointmentsByPatientId(Int32.Parse(Session["id"].ToString())).ToList<Appointment>();

                    foreach (var app in appList)
                    {
                        if (DateTime.Parse(app.date) > DateTime.Now.Date)
                        {
                            upcomingAppList.Add(app);
                        }
                        else
                        {
                            pastAppList.Add(app);
                        }
                    }

                    upcoming_appointment_repeater.Visible = true;
                    upcoming_appointment_repeater.DataSource = upcomingAppList;
                    upcoming_appointment_repeater.DataBind();

                    past_appointment_repeater.Visible = true;
                    past_appointment_repeater.DataSource = pastAppList;
                    past_appointment_repeater.DataBind();
                }
            }
            else
            {
                Response.Redirect("/Login", false);
            }
        }

        protected void upcoming_appointment_repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "UpdateAppointment")
            {
                HiddenField id = e.Item.FindControl("hidden_id") as HiddenField;

                Session["Appointment_id"] = id.Value;
                Response.Redirect("UpdateAppointment.aspx");

            }

            if(e.CommandName == "CancelAppointment")
            {
                HiddenField id = e.Item.FindControl("hidden_id") as HiddenField;

                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                int delete = client.CancelAppointment(int.Parse(id.Value));

                if (delete == 1)
                {
                    Response.Redirect("ViewAppointment.aspx");
                }
            }
        }

        protected void past_appointment_repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        }
    }
}