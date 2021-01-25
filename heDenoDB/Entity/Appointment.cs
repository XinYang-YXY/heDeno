using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heDenoDB.Entity
{
    public class Appointment
    {
        public int id { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public int doctorId { get; set; }
        public int patientId { get; set; }

        public string clinicName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string clinicType {get; set;}
        public int clinicId { get; set; }

        public Appointment()
        {

        }

        public Appointment(DateTime startDateTime, DateTime endDateTime, int doctorId, int patientId)
        {
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.doctorId = doctorId;
            this.patientId = patientId;
        }

        public Appointment(int id, DateTime startDateTime, DateTime endDateTime, string clinicName, string firstName, string lastName, string clinicType)
        {
            this.id = id;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.clinicName = clinicName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.clinicType = clinicType;
        }

        public Appointment(int id, DateTime startDateTime, DateTime endDateTime, int clinicId, int doctorId, string clinicType)
        {
            this.id = id;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.clinicId = clinicId;
            this.doctorId = doctorId;
            this.clinicType = clinicType;
        }

        public List<Appointment> SelectByPatientId(int id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * FROM appointment INNER JOIN doctor ON doctor.id = appointment.doctorId INNER JOIN clinic on clinic.id = doctor.clientId WHERE patientId = @paraId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to list.
            int rec_cnt = ds.Tables[0].Rows.Count;
            List<Appointment> appList = new List<Appointment>();
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int appid = int.Parse(row["id"].ToString());
                DateTime startDateTime = DateTime.Parse(row["startDateTime"].ToString());
                DateTime endDateTime = DateTime.Parse(row["endDateTime"].ToString());
                string sclinicName = row["clinicName"].ToString();
                string doctorFN = row["firstName"].ToString();
                string doctorLN = row["lastName"].ToString();
                string sclinicType = row["clinicType"].ToString();

                Appointment obj = new Appointment(appid, startDateTime, endDateTime, sclinicName, doctorFN, doctorLN, sclinicType);
                appList.Add(obj);
            }
            return appList;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO appointment (startDateTime, endDateTime, doctorId, patientId) VALUES (@startDateTime, @endDateTime, @doctorId, @patientId)";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@startDateTime", startDateTime);
            sqlCmd.Parameters.AddWithValue("@endDateTime", endDateTime);
            sqlCmd.Parameters.AddWithValue("@doctorId", doctorId);
            sqlCmd.Parameters.AddWithValue("@patientId", patientId);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public int Update(int id, DateTime startDateTime, DateTime endDateTime, int doctorId, int patientId)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "UPDATE appointment SET startDateTime = @startDateTime, endDateTime = @endDateTime, doctorId = @doctorId, patientId = @patientId WHERE id = @id";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@startDateTime", startDateTime);
            sqlCmd.Parameters.AddWithValue("@endDateTime", endDateTime);
            sqlCmd.Parameters.AddWithValue("@doctorId", doctorId);
            sqlCmd.Parameters.AddWithValue("@patientId", patientId);
            sqlCmd.Parameters.AddWithValue("@id", id);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public Appointment SelectOneAppointment(int id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "SELECT* FROM appointment INNER JOIN doctor ON appointment.doctorId = doctor.id INNER JOIN clinic ON doctor.clientId = clinic.id WHERE appointment.id = @appointment_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@appointment_id", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Appointment appointment = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0]; // Sql command returns only one record
                int app_id = int.Parse(row["id"].ToString());
                DateTime startDateTime = DateTime.Parse(row["startDateTime"].ToString());
                DateTime endDateTime = DateTime.Parse(row["endDateTime"].ToString());
                int clinicId = int.Parse(row["clientId"].ToString());
                int doctorId = int.Parse(row["doctorId"].ToString());
                string sclinicType = row["clinicType"].ToString();
                appointment = new Appointment(app_id, startDateTime, endDateTime, clinicId, doctorId, sclinicType);
            }
            return appointment;
        }

    }
}
