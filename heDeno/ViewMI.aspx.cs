using heDenoDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace heDeno
{
    public partial class ViewMI : System.Web.UI.Page
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
                    string id = Request.QueryString["id"];
                    MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
                    MedicalInstruct medicalInstruct = client.SelectOneMIById(id);
                    if(Session["id"] != medicalInstruct.PatientId)
                    {
                        Response.Redirect("/Login", false);
                    }
                    else
                    {
                        Doctor doctor = client.SelectDoctorByID(medicalInstruct.DoctorId);
                        Clinic clinic = client.SelectClinicByID(doctor.clientId.ToString());

                        RecordID.Text = id;
                        DoctorName.Text = doctor.firstName + " " + doctor.lastName;
                        RecordDate.Text = medicalInstruct.Date.ToString("dd/MM/yy");
                        ClinicName.Text = clinic.ClinicName;

                        string[] PSplit = medicalInstruct.Prescription.Split('|');
                        PSplit = PSplit.Take(PSplit.Count() - 1).ToArray();
                        string[] ISplit = medicalInstruct.Instruction.Split('|');
                        ISplit = ISplit.Take(ISplit.Count() - 1).ToArray();
                        string[] QSplit = medicalInstruct.Quantity.Split('|');
                        QSplit = QSplit.Take(QSplit.Count() - 1).ToArray();
                        string[] RSplit = medicalInstruct.Refills.Split('|');
                        RSplit = RSplit.Take(RSplit.Count() - 1).ToArray();

                        for (int i = 0; i < PSplit.Count(); i++)
                        {
                            Literal record5 = new Literal();
                            record5.Text = $"<span class='record-titlesnew'>Prescription:</span> <span class='records ID'>{PSplit[i]}</span> <span class='record-titles'>Instruction:</span> <span class='records'>{ISplit[i]}</span><span class='record-titlesnew'>Quantity:</span> <span class='records ID'>{QSplit[i]}</span> <span class='record-titles'>Refills:</span> <span class='records'>{RSplit[i]}</span>";

                            MIPlaceholder.Controls.Add(record5);
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("/Login", false);
            }
        }
    }
}