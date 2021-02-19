using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace heDenoDB.Entity
{
    public class Patient
    {
        public string ID { get; set; }
        public string SecretId { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string NRIC { get; set; }

        public Patient()
        {

        }

        public Patient(string secretId, string email, string phoneNum, string firstName,
            string lastName, DateTime dateOfBirth, string gender, string nric)
        {
            SecretId = secretId;
            Email = email;
            PhoneNum = phoneNum;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            NRIC = nric;
        }

        public Patient(string id, string secretId, string email, string phoneNum, string firstName,
            string lastName, DateTime dateOfBirth, string gender, string nric)
        {
            ID = id;
            SecretId = secretId;
            Email = email;
            PhoneNum = phoneNum;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            NRIC = nric;
        }

        public int Insert(Guid uuid, string password)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO patient (secretId, email, isEmailVerified, phoneNum, firstName, lastName, dob, gender, password, NRIC) " +
                "VALUES (@secretId,@email, @isEmailVerified, @phoneNum, @firstName, @lastName,@dob,@gender,@password,@nric)";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@secretId", uuid);
            sqlCmd.Parameters.AddWithValue("@email", Email);
            sqlCmd.Parameters.AddWithValue("@isEmailVerified", 0);
            sqlCmd.Parameters.AddWithValue("@phoneNum", PhoneNum);
            sqlCmd.Parameters.AddWithValue("@firstName", FirstName);
            sqlCmd.Parameters.AddWithValue("@lastName", LastName);
            sqlCmd.Parameters.AddWithValue("@dob", DateOfBirth.ToString("yyyy-MM-dd"));
            sqlCmd.Parameters.AddWithValue("@gender", Gender);
            sqlCmd.Parameters.AddWithValue("@password", password);
            sqlCmd.Parameters.AddWithValue("@nric", NRIC);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }

        public Patient GetByEmail(string email, string password)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM patient WHERE email = @email AND password = @password";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@email", email);
            da.SelectCommand.Parameters.AddWithValue("@password", password);

            DataSet ds = new DataSet();

            da.Fill(ds);

            Patient patient = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string secretId = row["id"].ToString();
                string dataEmail = row["email"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gender = row["gender"].ToString();
                string nric = row["NRIC"].ToString();

                patient = new Patient(secretId, dataEmail, phoneNum, firstName, lastName, dob, gender, nric);
            }
            return patient;
        }

        public Patient GetById(string id)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM patient WHERE secretId = @id";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@id", id);

            DataSet ds = new DataSet();

            da.Fill(ds);

            Patient patient = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string secretId = row["secretId"].ToString();
                string dataEmail = row["email"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gender = row["gender"].ToString();
                string nric = row["NRIC"].ToString();

                patient = new Patient(secretId, dataEmail, phoneNum, firstName, lastName, dob, gender, nric);
            }
            return patient;
        }

        public int updateEmail(string secretId, string email)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "UPDATE patient SET email = @email WHERE secretId = @secretId";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@secretId", secretId);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }

        public int updatePhoneNum(string secretId, string phoneNum)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "UPDATE patient SET phoneNum = @phoneNum WHERE secretId = @secretId";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@phoneNum", phoneNum);
            sqlCmd.Parameters.AddWithValue("@secretId", secretId);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }

        public int verifyEmail(string secretId)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "UPDATE patient SET isEmailVerified = @isEmailVerified WHERE secretId = @secretId";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@isEmailVerified", 1);
            sqlCmd.Parameters.AddWithValue("@secretId", secretId);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }

        public bool isEmailVerified(string email)
        {
            bool isVerified = false;

            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM patient WHERE email = @email";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@email", email);

            DataSet ds = new DataSet();

            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int isEmailVerified = Int32.Parse(row["isEmailVerified"].ToString());
                if (isEmailVerified > 0) isVerified = true;
            }
            return isVerified;
        }

        public Patient SelectPatientByID(string givenPatientID)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from patient where id = @paraPatientID";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraPatientID", givenPatientID);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            Patient obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string patientId = row["id"].ToString();
                string secretId = row["secretId"].ToString();
                string email = row["email"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();
                DateTime dob = DateTime.Parse(row["dob"].ToString());
                string gender = row["gender"].ToString();
                string nric = row["NRIC"].ToString();

                obj = new Patient(patientId, secretId, email, phoneNum, firstName, lastName, dob, gender, nric);
            }
            return obj;
        }
    }
}
