using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heDenoDB.Entity
{
    public class MedicalRecord
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Allergies { get; set; }
        public string FamilyMedicalHistory { get; set; }
        public string CurrentMedications { get; set; }
        public string Diagnosis { get; set; }
        public string Comment { get; set; }
        public string DoctorId { get; set; }
        public string ClinicId { get; set; }
        public string PatientId { get; set; }
        public string AppointmentId { get; set; }

        public MedicalRecord() { }

        public MedicalRecord(DateTime date, string allergies, string fmh, string currentmedications, string diagnosis, string comment, string doctorId, string clinicId, string patientId, string appointmentId)
        {
            Date = date;
            Allergies = allergies;
            FamilyMedicalHistory = fmh;
            CurrentMedications = currentmedications;
            Diagnosis = diagnosis;
            Comment = comment;
            DoctorId = doctorId;
            ClinicId = clinicId;
            PatientId = patientId;
            AppointmentId = appointmentId;
        }

        public MedicalRecord(string id, DateTime date, string allergies, string fmh, string currentmedications, string diagnosis, string comment, string doctorId, string clinicId, string patientId, string appointmentId)
        {
            Id = id;
            Date = date;
            Allergies = allergies;
            FamilyMedicalHistory = fmh;
            CurrentMedications = currentmedications;
            Diagnosis = diagnosis;
            Comment = comment;
            DoctorId = doctorId;
            ClinicId = clinicId;
            PatientId = patientId;
            AppointmentId = appointmentId;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO medicalrecord ( date, allergies, familyMedicalHistory, currentMedications, diagnosis, comment, doctorId, clinicId, patientId, appointmentId) " +
                "VALUES ( @paraDate,@paraAllergies, @paraFMH, @paraCurrentMedications, @paraDiagnosis, @paraComment, @paraDoctorId, @paraClinicId, @paraPatientId, @paraAppointmentId); select last_insert_id();";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            // sqlCmd.Parameters.AddWithValue("@paraId", Id);
            sqlCmd.Parameters.AddWithValue("@paraDate", Date);
            sqlCmd.Parameters.AddWithValue("@paraAllergies", Allergies);
            sqlCmd.Parameters.AddWithValue("@paraFMH", FamilyMedicalHistory);
            sqlCmd.Parameters.AddWithValue("@paraCurrentMedications", CurrentMedications);
            sqlCmd.Parameters.AddWithValue("@paraDiagnosis", Diagnosis);
            sqlCmd.Parameters.AddWithValue("@paraComment", Comment);
            sqlCmd.Parameters.AddWithValue("@paraDoctorId", DoctorId);
            sqlCmd.Parameters.AddWithValue("@paraClinicId", ClinicId);
            sqlCmd.Parameters.AddWithValue("@paraPatientId", PatientId);
            sqlCmd.Parameters.AddWithValue("@paraAppointmentId", AppointmentId);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<MedicalRecord> SelectMRById(string givenPatientId)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from medicalrecord where patientId = @paraPatientId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraPatientId", givenPatientId);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            //int rec_cnt = ds.Tables[0].Rows.Count;
            //MedicalRecord obj = null;
            //if (rec_cnt == 1)
            //{
            //    DataRow row = ds.Tables[0].Rows[0];
            //    string recordId = row["id"].ToString();
            //    string date = row["date"].ToString();
            //    string mc = row["mc"].ToString();
            //    string medicalInstruction = row["medicalInstruction"].ToString();
            //    string doctorComment = row["doctorComment"].ToString();
            //    string doctorId = row["doctorId"].ToString();
            //    string clinicId = row["clinicId"].ToString();
            //    string patientId = row["patientId"].ToString();

            //    obj = new MedicalRecord(recordId, date, mc, medicalInstruction, doctorComment, doctorId, clinicId, patientId);
            //}
            //return obj;

            List<MedicalRecord> medicalRecordList = new List<MedicalRecord>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string recordId = row["id"].ToString();
                DateTime date = Convert.ToDateTime(row["date"].ToString());
                string allergies = row["allergies"].ToString();
                string familyMedicalHistory = row["familyMedicalHistory"].ToString();
                string currentMedications = row["currentMedications"].ToString();
                string diagnosis = row["diagnosis"].ToString();
                string comment = row["comment"].ToString();
                string doctorId = row["doctorId"].ToString();
                string clinicId = row["clinicId"].ToString();
                string patientId = row["patientId"].ToString();
                string appointmentId = row["appointmentId"].ToString();

                MedicalRecord obj = new MedicalRecord(recordId, date, allergies, familyMedicalHistory, currentMedications, diagnosis, comment, doctorId, clinicId, patientId, appointmentId);
                medicalRecordList.Add(obj);
            }
            return medicalRecordList;
        }

        public MedicalRecord SelectOneMRById(string givenMRId)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from medicalrecord where id = @paraMRId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraMRId", givenMRId);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            MedicalRecord obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string recordId = row["id"].ToString();
                DateTime date = Convert.ToDateTime(row["date"].ToString());
                string allergies = row["allergies"].ToString();
                string familyMedicalHistory = row["familyMedicalHistory"].ToString();
                string currentMedications = row["currentMedications"].ToString();
                string diagnosis = row["diagnosis"].ToString();
                string comment = row["comment"].ToString();
                string doctorId = row["doctorId"].ToString();
                string clinicId = row["clinicId"].ToString();
                string patientId = row["patientId"].ToString();
                string appointmentId = row["appointmentId"].ToString();

                obj = new MedicalRecord(recordId, date, allergies, familyMedicalHistory, currentMedications, diagnosis, comment, doctorId, clinicId, patientId, appointmentId);
            }
            return obj;
        }
    }
}
