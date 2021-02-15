using heDeno.MyDenoDBServiceReference;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using heDenoDB.Entity;

namespace heDeno
{
    public partial class BookAppointment : System.Web.UI.Page
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
                    select_date.Attributes["min"] = DateTime.Today.AddDays(5).ToString("yyyy-MM-dd");

                    if (!IsPostBack)
                    {
                        try
                        {
                            List<Specialty> specialtyList = new List<Specialty>();
                            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                            specialtyList = client.GetAllSpecialty().ToList<Specialty>();

                            select_specialty.DataSource = specialtyList;
                            select_specialty.DataTextField = "specialtyFull";
                            select_specialty.DataValueField = "specialtyName";
                            select_specialty.DataBind();

                            select_specialty.Items.Insert(0, new ListItem("-- Select Specialty --", ""));
                            select_specialty.Items.FindByText("-- Select Specialty --").Attributes.Add("disabled", "disabled");
                            select_clinic.Items.Insert(0, new ListItem("-- Select Clinic --", ""));
                            select_clinic.Items.FindByText("-- Select Clinic --").Attributes.Add("disabled", "disabled");
                            select_doctor.Items.Insert(0, new ListItem("-- Select Preferred Doctor --", ""));
                            select_doctor.Items.FindByText("-- Select Preferred Doctor --").Attributes.Add("disabled", "disabled");
                            available_timeslots.Items.Clear();
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.ToString());
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("/Login", false);
            }            


        }

        protected void select_specialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_specialty = select_specialty.SelectedValue;

            try
            {
                List<Clinic> clinicList = new List<Clinic>();
                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                clinicList = client.GetClinicBySpecialty(selected_specialty).ToList<Clinic>();

                select_clinic.DataSource = clinicList;
                select_clinic.DataTextField = "clinicName";
                select_clinic.DataValueField = "id";
                select_clinic.DataBind();

                select_clinic.Items.Insert(0, new ListItem("-- Select Clinic --", ""));
                select_clinic.Items.FindByText("-- Select Clinic --").Attributes.Add("disabled", "disabled");
                select_specialty.Items.FindByText("-- Select Specialty --").Attributes.Add("disabled", "disabled");
                select_doctor.Items.Clear();
                select_doctor.Items.Insert(0, new ListItem("-- Select Preferred Doctor --", ""));
                select_doctor.Items.FindByText("-- Select Preferred Doctor --").Attributes.Add("disabled", "disabled");
                available_timeslots.Items.Clear();
                select_date.Text = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        protected void select_clinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_clinic = select_clinic.SelectedValue;

            try
            {
                List<Doctor> doctorList = new List<Doctor>();
                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                doctorList = client.GetDoctorByClinic(selected_clinic).ToList<Doctor>();

                select_doctor.DataSource = doctorList;
                select_doctor.DataTextField = "doctorFull";
                select_doctor.DataValueField = "id";
                select_doctor.DataBind();

                select_doctor.Items.Insert(0, new ListItem("-- Select Preferred Doctor --", ""));
                select_doctor.Items.FindByText("-- Select Preferred Doctor --").Attributes.Add("disabled", "disabled");
                select_clinic.Items.FindByText("-- Select Clinic --").Attributes.Add("disabled", "disabled");
                select_specialty.Items.FindByText("-- Select Specialty --").Attributes.Add("disabled", "disabled");
                available_timeslots.Items.Clear();
                select_date.Text = "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            try
            {
                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                var clinic = client.GetOneClinic(select_clinic.SelectedItem.Text);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        protected void select_doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_doctor.Items.FindByText("-- Select Preferred Doctor --").Attributes.Add("disabled", "disabled");
            select_clinic.Items.FindByText("-- Select Clinic --").Attributes.Add("disabled", "disabled");
            select_specialty.Items.FindByText("-- Select Specialty --").Attributes.Add("disabled", "disabled");
            available_timeslots.Items.Clear();
            select_date.Text = "";
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.Parse(available_timeslots.SelectedItem.Value);

            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            //Patient id is 1 for now.
            int result = client.CreateAppointment(select_date.Text, time, int.Parse(select_doctor.SelectedValue), Int32.Parse(Session["id"].ToString()));
            if (result == 1)
            {
                Response.Redirect("AppointmentSuccess");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Failed");
            }

        }

        protected void select_date_TextChanged(object sender, EventArgs e)
        {
            select_doctor.Items.FindByText("-- Select Preferred Doctor --").Attributes.Add("disabled", "disabled");
            select_clinic.Items.FindByText("-- Select Clinic --").Attributes.Add("disabled", "disabled");
            select_specialty.Items.FindByText("-- Select Specialty --").Attributes.Add("disabled", "disabled");
            available_timeslots.Items.Clear();

            var appDate = select_date.Text;
            List<Appointment> appList = new List<Appointment>();

            if (select_doctor.SelectedIndex != 0 && select_specialty.SelectedIndex != 0  && select_clinic.SelectedIndex != 0)
            {
                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                appList = client.GetAllAppointmentsByDoctorAndDate(int.Parse(select_doctor.SelectedValue), appDate).ToList<Appointment>();
                var clinic = client.GetOneClinic(select_clinic.SelectedItem.Text);

                TimeSpan timediff = clinic.EndTime - clinic.StartTime;
                var hours = timediff.Hours;
                TimeSpan startTime = clinic.StartTime;

                for (int i = 0; i < hours; i++)
                {
                    ListItem btn = new ListItem();
                    btn.Text = startTime.ToString("hh\\:mm");
                    btn.Value = startTime.ToString();
                    btn.Attributes.Add("class", "btn btn-outline-success mr-2 timeslot");
                    btn.Attributes.Add("title", "Available");

                    foreach (var appointment in appList)
                    {
                        if (startTime.ToString() == appointment.time.ToString())
                        {
                            btn.Attributes.Clear();
                            btn.Enabled = false;
                            btn.Attributes.Add("title", "Not available");
                            btn.Attributes.Add("class", "btn btn-outline-danger mr-2 timeslot");
                            break;
                        }
                    }

                    available_timeslots.Items.Add(btn);
                    startTime = startTime.Add(TimeSpan.FromHours(1));
                }
            }
        }
    }
}