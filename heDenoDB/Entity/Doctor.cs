using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heDenoDB.Entity
{
    public class Doctor
    {
        public int id { get; set; }
        public string email { get; set; }
        public string phoneNum { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }
        public string signature { get; set; }
        public string password { get; set; }
        public int clientId { get; set; }
        public string doctorFull { get; set; }

        public Doctor()
        {

        }

        public Doctor(int id, string doctorFull)
        {
            this.id = id;
            this.doctorFull = doctorFull;
        }

        public Doctor(int id, string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string signature, string password, int clientId)
        {
            this.id = id;
            this.email = email;
            this.phoneNum = phoneNum;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dob = dob;
            this.gender = gender;
            this.signature = signature;
            this.password = password;
            this.clientId = clientId;

        }

        public List<Doctor> SelectByClinic(string clinic_id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "SELECT * FROM doctor INNER JOIN clinic ON doctor.clientId = clinic.id WHERE clinic.id = @clinic_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@clinic_id", clinic_id);

            //Step 3 -  Create a DataTable to store the data to be retrieved
            DataTable dt = new DataTable();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(dt);

            // Custom text in dropdownlist
            dt.Columns.Add("doctorFull", typeof(String), "firstName + ' ' + lastName");

            //Step 5 -  Read data from DataSet to list.
            int rec_cnt = dt.Rows.Count;
            List<Doctor> doctorList = new List<Doctor>();
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = dt.Rows[i];
                int id = int.Parse(row["id"].ToString());
                string doctorFull = row["doctorFull"].ToString();

                Doctor obj = new Doctor(id, doctorFull);
                doctorList.Add(obj);
            }
            return doctorList;
        }

        public Doctor SelectDoctorByID(string givenDoctorID)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from doctor where id = @paraDoctorID";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraDoctorID", givenDoctorID);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            Doctor obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int doctorId = int.Parse(row["id"].ToString());
                string email = row["email"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gender = row["gender"].ToString();
                string signature = row["signature"].ToString();
                string password = row["password"].ToString();
                int clientId = int.Parse(row["clientId"].ToString());

                obj = new Doctor(doctorId, email, phoneNum, firstName, lastName, dob, gender, signature, password, clientId);
            }
            return obj;
        }

    }
}
