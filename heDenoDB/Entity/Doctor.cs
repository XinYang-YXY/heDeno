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
    
    }
}
