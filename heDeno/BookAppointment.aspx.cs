using heDeno.MyDenoDBServiceReference;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                    select_clinic.Items.Insert(0, new ListItem("-- Select Clinic --", ""));
                    select_doctor.Items.Insert(0, new ListItem("-- Select Preferred Doctor --", ""));
                } 
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }                
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

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            try
            {
                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                var clinic = client.GetOneClinic(select_clinic.SelectedItem.Text);
                select_start_time.Attributes["min"] = clinic.StartTime.ToString();
                select_start_time.Attributes["max"] = clinic.EndTime.ToString();
                select_end_time.Attributes["max"] = clinic.EndTime.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.ParseExact(select_date.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            var startTime = DateTime.ParseExact(select_start_time.Text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact(select_end_time.Text, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime startDateTime = new DateTime(date.Year, date.Month, date.Day, startTime.Hour, startTime.Minute, startTime.Second);
            DateTime endDateTime = new DateTime(date.Year, date.Month, date.Day, endTime.Hour, endTime.Minute, endTime.Second);

            if(startTime > endTime || endTime < startTime)
            {
                lbl_msg.ForeColor = System.Drawing.Color.Red;
                lbl_msg.Text = "Time is not valid!";
            } else
            {
                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                //Patient id is 1 for now.
                int result = client.CreateAppointment(startDateTime, endDateTime, int.Parse(select_doctor.SelectedValue), 1);

                if (result == 1)
                {
                    Response.Redirect("AppointmentSuccess");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Failed");
                }
            }

            
        }
    }
}