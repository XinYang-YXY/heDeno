using heDeno.MyDenoDBServiceReference;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace heDeno
{
    public partial class UpdateAppointment : System.Web.UI.Page
    {
        int appointment_id = 0;
        string clinicId, clinicType, doctorId;
        string startDateTime, date;


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.Parse(select_start_time.Text);
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            int update = client.UpdateAppointment(appointment_id, select_date.Text, time, int.Parse(select_doctor.SelectedValue), 1);

            if (update == 1)
            {
                Response.Redirect("AppointmentSuccess");
                Session.Clear();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var s_aid = (string)Session["Appointment_id"];
            if (s_aid != null)
            {
                appointment_id = int.Parse(Session["Appointment_id"].ToString());
            }

            retreiveData();

            select_date.Attributes["min"] = DateTime.Today.AddDays(5).ToString("yyyy-MM-dd");


            if (!IsPostBack && appointment_id > 0)
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

                    select_specialty.Items.FindByValue(clinicType).Selected = true;
                    

                    /**select_specialty.Items.Insert(0, new ListItem("-- Select Specialty --", ""));
                    select_clinic.Items.Insert(0, new ListItem("-- Select Clinic --", ""));
                    select_doctor.Items.Insert(0, new ListItem("-- Select Preferred Doctor --", ""));**/
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }


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

                    select_clinic.Items.FindByValue(clinicId).Selected = true;
                    /** select_clinic.Items.Insert(0, new ListItem("-- Select Clinic --", "")); **/
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

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
                    
                    
                    select_doctor.Items.FindByValue(doctorId).Selected = true;
                    /**select_doctor.Items.Insert(0, new ListItem("-- Select Preferred Doctor --", ""));**/
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }

                select_date.Text = date;
                select_start_time.Text = startDateTime;
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
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        protected void retreiveData()
        {
            try
            {
                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                Appointment appointmentObj = client.GetOneAppointment(appointment_id);
                if(appointmentObj != null) 
                {
                    clinicType = appointmentObj.clinicType;
                    clinicId = appointmentObj.clinicId.ToString();
                    doctorId = appointmentObj.doctorId.ToString();
                    date = appointmentObj.date.ToString();
                    startDateTime = appointmentObj.time.ToString();
                } else
                {
                    Response.Redirect("/");
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}