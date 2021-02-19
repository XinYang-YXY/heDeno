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
    public partial class ViewMedicalInstructions : System.Web.UI.Page
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
                    List<MedicalInstruct> MIList = client.SelectMIById(Session["id"].ToString()).ToList<MedicalInstruct>();
                    for (int i = 0; i < MIList.Count; i++)
                    {
                        Doctor doctor = client.SelectDoctorByID(MIList[i].DoctorId);
                        Clinic clinic = client.SelectClinicByID(doctor.clientId.ToString());
                        Literal record = new Literal();

                        var div = new HtmlGenericControl("div");
                        div.Attributes["class"] = "layout-records";


                        var button = new Button
                        {
                            ID = MIList[i].Id,
                            Text = "View instruction",
                            CssClass = "montserrat rounded-full standard-btn btn-standard-width y-gap record-btn"
                        };
                        button.Command += ViewBtnClick;

                        record.Text = $"<span class='record-titles IDTitle'>Medical Instruction ID:</span> <span class='records ID'>{MIList[i].Id}</span> <span class='record-titles NRICTitle'>Date:</span> <span class='records NRIC'>{MIList[i].Date.ToString("dd/MM/yy")}</span> <span class='record-titles NameTitle'>Doctor Name:</span> <span class='records Name' >{doctor.firstName + " " + doctor.lastName}</span> <span class='record-titles'>Clinic Name:</span> <span class='records' >{clinic.ClinicName}</span>";

                        div.Controls.Add(record);
                        div.Controls.Add(button);
                        allMIs.Controls.Add(div);
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
            Response.Redirect($"~/ViewMI.aspx?id={clickedButton.ID}");
        }
    }
}