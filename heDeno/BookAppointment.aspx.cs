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
    public partial class BookAppointment : System.Web.UI.Page
    {
        string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
        MySqlConnection myConn = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            select_date.Attributes["min"] = DateTime.Today.AddDays(5).ToString("yyyy-MM-dd");
            
            if (!IsPostBack)
            {
                try
                {
                    myConn = new MySqlConnection(DBConnect);

                    string sqlstmt = "SELECT * FROM specialty";
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //Custom text in dropdownlist
                    dt.Columns.Add("specialtyFull", typeof(String), "specialtyName + ' (' + specialtyDesc + ')'");

                    select_specialty.DataSource = dt;
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
                finally
                {
                    myConn.Close();
                }
                
            }
        
        }

        protected void select_specialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_specialty = select_specialty.SelectedValue;

            try
            {
                myConn = new MySqlConnection(DBConnect);
                string sqlstmt = string.Format("SELECT * FROM clinic WHERE clinicType = @specialty_name");
                MySqlCommand command = new MySqlCommand(sqlstmt, myConn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@specialty_name", selected_specialty);

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = command;
                DataSet ds = new DataSet();
                da.Fill(ds);

                select_clinic.DataSource = ds;
                select_clinic.DataTextField = "clinicName";
                select_clinic.DataValueField = "clinicName";
                select_clinic.DataBind();

                select_clinic.Items.Insert(0, new ListItem("-- Select Clinic --", ""));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                myConn.Close();
            }
           
        }

        protected void select_clinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_clinic = select_clinic.SelectedValue;

            try
            {
                myConn = new MySqlConnection(DBConnect);
                string sqlstmt = string.Format("SELECT * FROM doctor INNER JOIN clinic ON doctor.clientId = clinic.id WHERE clinic.clinicName = @clinic_name");
                MySqlCommand command = new MySqlCommand(sqlstmt, myConn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@clinic_name", selected_clinic);

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = command;
                DataTable dt = new DataTable();
                da.Fill(dt);

                //Custom text in dropdownlist
                dt.Columns.Add("doctorFull", typeof(String), "firstName + ' ' + lastName");
                
                select_doctor.DataSource = dt;
                select_doctor.DataTextField = "doctorFull";
                select_doctor.DataValueField = "id";
                select_doctor.DataBind();

                select_doctor.Items.Insert(0, new ListItem("-- Select Preferred Doctor --", ""));

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                myConn.Close();
            }

            try
            {
                myConn = new MySqlConnection(DBConnect);
                string sqlstmt = string.Format("SELECT * FROM clinic WHERE clinicName = @clinic_name");
                MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
                da.SelectCommand.Parameters.AddWithValue("@clinic_name", selected_clinic);
                DataSet ds = new DataSet();
                da.Fill(ds);

                int rec_cnt = ds.Tables[0].Rows.Count;
                if (rec_cnt == 1)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    select_start_time.Attributes["min"] = row["startTime"].ToString();
                    select_start_time.Attributes["max"] = row["endTime"].ToString();
                    select_end_time.Attributes["max"] = row["endTime"].ToString();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                myConn.Close();
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