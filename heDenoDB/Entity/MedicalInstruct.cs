using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heDenoDB.Entity
{
    public class MedicalInstruct
    {

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Prescription { get; set; }
        public string Instruction { get; set; }
        public string Quantity { get; set; }
        public string Refills { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public string AppointmentId { get; set; }

        public MedicalInstruct() { }

        public MedicalInstruct(DateTime date, string prescription, string instruction, string quantity, string refills, string doctorId, string patientId, string appointmentId)
        {
            Date = date;
            Prescription = prescription;
            Instruction = instruction;
            Quantity = quantity;
            Refills = refills;
            DoctorId = doctorId;
            PatientId = patientId;
            AppointmentId = appointmentId;
        }

        public MedicalInstruct(string id, DateTime date, string prescription, string instruction, string quantity, string refills, string doctorId, string patientId, string appointmentId)
        {
            Id = id;
            Date = date;
            Prescription = prescription;
            Instruction = instruction;
            Quantity = quantity;
            Refills = refills;
            DoctorId = doctorId;
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
            string sqlStmt = "INSERT INTO medicalinstruct ( date, prescription, instruction, quantity, refills, doctorId, patientId, appointmentId) " +
                "VALUES ( @paraDate, @paraPrescription, @paraInstruction, @paraQuantity, @paraRefills, @paraDoctorId, @paraPatientId, @paraAppointmentId); select last_insert_id();";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            // sqlCmd.Parameters.AddWithValue("@paraId", Id);
            sqlCmd.Parameters.AddWithValue("@paraDate", Date);
            sqlCmd.Parameters.AddWithValue("@paraPrescription", Prescription);
            sqlCmd.Parameters.AddWithValue("@paraInstruction", Instruction);
            sqlCmd.Parameters.AddWithValue("@paraQuantity", Quantity);
            sqlCmd.Parameters.AddWithValue("@paraRefills", Refills);
            sqlCmd.Parameters.AddWithValue("@paraDoctorId", DoctorId);
            sqlCmd.Parameters.AddWithValue("@paraPatientId", PatientId);
            sqlCmd.Parameters.AddWithValue("@paraAppointmentId", AppointmentId);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = Convert.ToInt32(sqlCmd.ExecuteScalar());
            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<MedicalInstruct> SelectMIById(string givenPatientId)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from medicalinstruct where patientId = @paraPatientId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraPatientId", givenPatientId);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            List<MedicalInstruct> medicalInstructList = new List<MedicalInstruct>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string recordId = row["id"].ToString();
                DateTime date = Convert.ToDateTime(row["date"].ToString());
                string prescription = row["prescription"].ToString();
                string instruction = row["instruction"].ToString();
                string quantity = row["quantity"].ToString();
                string refills = row["refills"].ToString();
                string doctorId = row["doctorId"].ToString();
                string patientId = row["patientId"].ToString();
                string appointmentId = row["appointmentId"].ToString();

                MedicalInstruct obj = new MedicalInstruct(recordId, date, prescription, instruction, quantity, refills, doctorId, patientId, appointmentId);
                medicalInstructList.Add(obj);
            }
            return medicalInstructList;
        }

        public MedicalInstruct SelectOneMIById(string givenMIId)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from medicalinstruct where id = @paraMRId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraMRId", givenMIId);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            MedicalInstruct obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string recordId = row["id"].ToString();
                DateTime date = Convert.ToDateTime(row["date"].ToString());
                string prescription = row["prescription"].ToString();
                string instruction = row["instruction"].ToString();
                string quantity = row["quantity"].ToString();
                string refills = row["refills"].ToString();
                string doctorId = row["doctorId"].ToString();
                string patientId = row["patientId"].ToString();
                string appointmentId = row["appointmentId"].ToString();

                obj = new MedicalInstruct(recordId, date, prescription, instruction, quantity, refills, doctorId, patientId, appointmentId);
            }
            return obj;
        }
    }
}
