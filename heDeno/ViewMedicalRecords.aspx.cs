using heDenoDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace heDeno
{
    public partial class ViewMedicalRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("/Login", false);
                }
                else
                {
                    MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                    List<MedicalRecord> MRList = client.SelectMRById(Session["id"].ToString()).ToList<MedicalRecord>();

                    for (int i = 0; i < MRList.Count; i++)
                    {
                        Doctor doctor = client.SelectDoctorByID(MRList[i].DoctorId);
                        Clinic clinic = client.SelectClinicByID(doctor.clientId.ToString());
                        Literal record = new Literal();

                        var div = new HtmlGenericControl("div");
                        div.Attributes["class"] = "layout-records";


                        var button = new Button
                        {
                            ID = MRList[i].Id,
                            Text = "View Record",
                            CssClass = "montserrat rounded-full standard-btn btn-standard-width y-gap record-btn"
                        };
                        button.Command += ViewBtnClick;

                        record.Text = $"<span class='record-titles IDTitle'>Medical Record ID:</span> <span class='records ID'>{MRList[i].Id}</span> <span class='record-titles'>Date:</span> <span class='records NRIC'>{MRList[i].Date.ToString("dd/MM/yy")}</span> <span class='record-titles NameTitle'>Doctor Name:</span> <span class='records Name' >{doctor.firstName + " " + doctor.lastName}</span> <span class='record-titles'>Clinic Name:</span> <span class='records' >{clinic.ClinicName}</span>";

                        div.Controls.Add(record);
                        div.Controls.Add(button);
                        allMRs.Controls.Add(div);
                    }
                }
            }
            else
            {
                Response.Redirect("/Login", false);
            }
        }
        protected void ViewBtnClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            System.Diagnostics.Debug.WriteLine(clickedButton.ID);
            Response.Redirect($"~/ViewMR.aspx?id={clickedButton.ID}");
        }

    }
}