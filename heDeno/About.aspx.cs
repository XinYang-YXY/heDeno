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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlstmt = "Select * from Patient";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();

            da.Fill(ds);

            DataRow row = ds.Tables[0].Rows[0];

            string id = row["lastName"].ToString();

            webform.Text = id;
        }
    }
}