using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heDenoDB.Entity
{
    public class MedicalCertificate
    {
        public string Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comments { get; set; }
        public string DoctorId { get; set; }
        public string DoctorSignature { get; set; }
        public string PatientId { get; set; }
        public string AppointmentId { get; set; }

        public string patientname { get; set; }
        public string nric { get; set; }

        public string doctorName { get; set; }

        public string clinicName { get; set; }
        public string clinicType { get; set; }

        public string appointmentDate { get; set; }

        public MedicalCertificate() { }

        public MedicalCertificate(string id, DateTime startDate, DateTime endDate, string comments, string doctorId, string doctorSignature, string patientId, string appointmentId,
            string appointmentDate)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Comments = comments;
            DoctorId = doctorId;
            DoctorSignature = doctorSignature;
            PatientId = patientId;
            AppointmentId = appointmentId;
            this.appointmentDate = appointmentDate;
        }

        public MedicalCertificate(string id, DateTime startDate, DateTime endDate, string comments, string doctorId, string doctorName, string doctorSignature, string patientId,
            string appointmentId, string appointmentDate, string patientname, string nric, string clinicName, string clinicType)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Comments = comments;
            DoctorId = doctorId;
            DoctorSignature = doctorSignature;
            PatientId = patientId;
            AppointmentId = appointmentId;
            this.appointmentDate = appointmentDate;
            this.patientname = patientname;
            this.nric = nric;
            this.doctorName = doctorName;
            this.clinicName = clinicName;
            this.clinicType = clinicType;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO mc ( startDate, endDate, comments, doctorId, doctorSignature, patientId, appointmentId) " +
                "VALUES ( @paraStartDate, @paraEndDate, @paraComments, @paraDoctorId, @paraDoctorSignature, @paraPatientId, @paraAppointmentId); select last_insert_id();";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            // sqlCmd.Parameters.AddWithValue("@paraId", Id);
            sqlCmd.Parameters.AddWithValue("@paraStartDate", StartDate);
            sqlCmd.Parameters.AddWithValue("@paraEndDate", EndDate);
            sqlCmd.Parameters.AddWithValue("@paraComments", Comments);
            sqlCmd.Parameters.AddWithValue("@paraDoctorId", DoctorId);
            sqlCmd.Parameters.AddWithValue("@paraDoctorSignature", DoctorSignature);
            sqlCmd.Parameters.AddWithValue("@paraPatientId", PatientId);
            sqlCmd.Parameters.AddWithValue("@paraAppointmentId", AppointmentId);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<MedicalCertificate> SelectMCById(string givenPatientId)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from mc INNER JOIN appointment ON appointment.id = mc.appointmentId where mc.patientId = @paraPatientId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraPatientId", givenPatientId);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            List<MedicalCertificate> medicalCertificateList = new List<MedicalCertificate>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string recordId = row["id"].ToString();
                DateTime startDate = Convert.ToDateTime(row["startDate"].ToString());
                DateTime endDate = Convert.ToDateTime(row["endDate"].ToString());
                string comments = row["comments"].ToString();
                string doctorId = row["doctorId"].ToString();
                string doctorSignature = row["doctorSignature"].ToString();
                string patientId = row["patientId"].ToString();
                string appointmentId = row["appointmentId"].ToString();
                string appointmentDate = row["date"].ToString();

                MedicalCertificate obj = new MedicalCertificate(recordId, startDate, endDate, comments, doctorId, doctorSignature, patientId, appointmentId, appointmentDate);
                medicalCertificateList.Add(obj);
            }
            return medicalCertificateList;
        }

        public MedicalCertificate SelectOneMCById(string givenMCId)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "SELECT m.id, m.startDate, m.endDate, m.comments, m.doctorId, d.signature, CONCAT(d.firstName, ' ', d.lastName) AS doctorName, m.patientId, m.appointmentId, p.nric, c.clinicName, c.clinicType, a.date, " +
                "CONCAT(p.firstName, ' ', p.lastName) AS patientName from mc AS m INNER JOIN appointment AS a ON m.appointmentId = a.id INNER JOIN patient AS p on p.id = m.patientId INNER JOIN doctor AS d ON d.id = m.doctorId " +
                "INNER JOIN clinic AS c ON c.id = d.clientId WHERE m.id = @paraMCId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraMCId", givenMCId);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            MedicalCertificate obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string recordId = row["id"].ToString();
                DateTime startDate = Convert.ToDateTime(row["startDate"].ToString());
                DateTime endDate = Convert.ToDateTime(row["endDate"].ToString());
                string comments = row["comments"].ToString();
                string doctorId = row["doctorId"].ToString();
                string doctorSignature = row["signature"].ToString();
                string doctor_name = row["doctorName"].ToString();
                string patientId = row["patientId"].ToString();
                string appointmentId = row["appointmentId"].ToString();
                string patient_name = row["patientName"].ToString();
                string nric = row["nric"].ToString();
                string clinicName = row["clinicName"].ToString();
                string clinicType = row["clinicType"].ToString();
                string appointmentDate = row["date"].ToString();

                obj = new MedicalCertificate(recordId, startDate, endDate, comments, doctorId, doctor_name, doctorSignature, patientId, appointmentId, appointmentDate, patient_name, nric, 
                    clinicName, clinicType);
            }
            return obj;
        }
    }
}
