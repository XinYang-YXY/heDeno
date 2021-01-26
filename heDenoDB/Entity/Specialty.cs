using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heDenoDB.Entity
{
    public class Specialty
    {
        public string specialtyName { get; set; }
        public string specialtyDesc { get; set; }
        public string specialtyFull { get; set; }

        public Specialty()
        {

        }

        public Specialty(string specialtyName, string specialtyDesc, string specialtyFull)
        {
            this.specialtyName = specialtyName;
            this.specialtyFull = specialtyFull;
            this.specialtyDesc = specialtyDesc;
        }

        public List<Specialty> SelectAllSpecialty()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * FROM specialty";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);

            //Step 3 -  Create a DataTable to store the data to be retrieved
            DataTable dt = new DataTable();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(dt);

            // Custom text in dropdownlist
            dt.Columns.Add("specialtyFull", typeof(String), "specialtyName + ' (' + specialtyDesc + ')'");
 
            //Step 5 -  Read data from DataSet to list.
            int rec_cnt = dt.Rows.Count;
            List<Specialty> specialtyList = new List<Specialty>();
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = dt.Rows[i];
                string specialtyName = row["specialtyName"].ToString();
                string specialtyDesc = row["specialtyDesc"].ToString();
                string specialtyFull = row["specialtyFull"].ToString();

                Specialty obj = new Specialty(specialtyName, specialtyDesc, specialtyFull);
                specialtyList.Add(obj);
            }
            return specialtyList;
        }
    }
}
