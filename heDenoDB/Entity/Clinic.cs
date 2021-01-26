using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heDenoDB.Entity
{
    public class Clinic
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string ClinicName { get; set; }

        public string ClinicType { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Clinic()
        {

        }
        // Define a constructor to initialize all the properties
        public Clinic(string id, string address, string phoneNum, string email, string clinicName, string clinicType, TimeSpan startTime, TimeSpan endTime)
        {
            Id = id;
            Address = address;
            PhoneNum = phoneNum;
            Email = email;
            ClinicName = clinicName;
            ClinicType = clinicType;
            StartTime = startTime;
            EndTime = endTime;
        }
        public Clinic(string address, string phoneNum, string email, string clinicName, string clinicType, TimeSpan startTime, TimeSpan endTime)
        {
            Address = address;
            PhoneNum = phoneNum;
            Email = email;
            ClinicName = clinicName;
            ClinicType = clinicType;
            StartTime = startTime;
            EndTime = endTime;
        }


        // New
        public List<Clinic> SelectBySpecialty(string specialty_name)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "SELECT * FROM clinic WHERE clinicType = @specialty_name";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@specialty_name", specialty_name);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to list.
            int rec_cnt = ds.Tables[0].Rows.Count;
            List<Clinic> clinicList = new List<Clinic>();
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string clinicId = row["id"].ToString();
                string address = row["address"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string email = row["email"].ToString();
                string clinicName = row["clinicName"].ToString();
                string clinicType = row["clinicType"].ToString();
                TimeSpan startTime = TimeSpan.Parse(row["startTime"].ToString());
                TimeSpan endTime = TimeSpan.Parse(row["endTime"].ToString());

                Clinic obj = new Clinic(clinicId, address, phoneNum, email, clinicName, clinicType, startTime, endTime);
                clinicList.Add(obj);
            }
            return clinicList;
        }
        // End


        public Clinic SelectByName(string givenClinicName)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from Clinic where clinicName = @paraClinicName";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraClinicName", givenClinicName);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            Clinic obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string clinicId = row["id"].ToString();
                string address = row["address"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string email = row["email"].ToString();
                string clinicName = row["clinicName"].ToString();
                string clinicType = row["clinicType"].ToString();
                TimeSpan startTime = TimeSpan.Parse(row["startTime"].ToString());
                TimeSpan endTime = TimeSpan.Parse(row["endTime"].ToString());

                obj = new Clinic(clinicId, address, phoneNum, email, clinicName, clinicType, startTime, endTime);
            }
            return obj;
        }
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Clinic ( address, phoneNum, email, clinicName, clinicType, startTime, endTime) " +
                "VALUES ( @paraAddress,@paraPhoneNum, @paraEmail, @paraClinicName, @paraClinicType, @paraStartTime, @paraEndTime)";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            // sqlCmd.Parameters.AddWithValue("@paraId", Id);
            sqlCmd.Parameters.AddWithValue("@paraAddress", Address);
            sqlCmd.Parameters.AddWithValue("@paraPhoneNum", PhoneNum);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraClinicName", ClinicName);
            sqlCmd.Parameters.AddWithValue("@paraClinicType", ClinicType);
            sqlCmd.Parameters.AddWithValue("@paraStartTime", StartTime);
            sqlCmd.Parameters.AddWithValue("@paraEndTime", EndTime);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
        public List<Clinic> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Clinic";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Clinic> clinicList = new List<Clinic>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string clinicId = row["id"].ToString();
                string address = row["address"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string email = row["email"].ToString();
                string clinicName = row["clinicName"].ToString();
                string clinicType = row["clinicType"].ToString();
                TimeSpan startTime = TimeSpan.Parse(row["startTime"].ToString());
                TimeSpan endTime = TimeSpan.Parse(row["endTime"].ToString());

                Clinic obj = new Clinic(clinicId, address, phoneNum, email, clinicName, clinicType, startTime, endTime);
                clinicList.Add(obj);
            }
            return clinicList;
        }
    }
}
