using heDenoDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace heDeno
{
    public partial class ViewMR : System.Web.UI.Page
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
                    MedicalRecord medicalRecord = client.SelectOneMRById(id);
                    Patient patient = client.SelectPatientByID(medicalRecord.PatientId);

                    if(Session["id"] != patient.ID)
                    {
                        Response.Redirect("/Login", false);
                    } 
                    
                    else

                    {
                        RecordID.Text = medicalRecord.Id;
                        RecordDate.Text = medicalRecord.Date.ToString("dd/MM/yy");

                        Literal record = new Literal();

                        record.Text = $"<span class='record-titlesnew IDTitle'>Patient ID:</span> <span class='records ID'>{patient.ID}</span> <span class='record-titles NRICTitle'>NRIC:</span> <span class='records NRIC'>{patient.NRIC}</span> <span class='record-titles NameTitle'>Name:</span> <span class='records Name' >{patient.FirstName + " " + patient.LastName}</span> <span class='record-titles EmailTitle'>Email:</span> <span class='records Email'>{patient.Email}</span> <span class='record-titles GenderTitle'>Gender:</span> <span class='records Gender'>{patient.Gender}</span> <span class='record-titles ContactTitle'>Contact Number:</span> <span class='records Contact'>{patient.PhoneNum}</span>";

                        PlaceHolder1.Controls.Add(record);

                        string[] ASplit = medicalRecord.Allergies.Split('|');
                        ASplit = ASplit.Take(ASplit.Count() - 1).ToArray();

                        foreach (string A in ASplit)
                        {
                            Literal record2 = new Literal();
                            record2.Text = $"<span class='record-titlesnew'>Allergy:</span> <span class='records ID'>{A}</span>";

                            PlaceHolder2.Controls.Add(record2);
                        }

                        string[] FMHSplit = medicalRecord.FamilyMedicalHistory.Split('|');
                        FMHSplit = FMHSplit.Take(FMHSplit.Count() - 1).ToArray();

                        foreach (string FMH in FMHSplit)
                        {
                            Literal record3 = new Literal();
                            record3.Text = $"<span class='record-titlesnew'>Condition:</span> <span class='records ID'>{FMH}</span>";

                            PlaceHolder3.Controls.Add(record3);
                        }

                        string[] CMSplit = medicalRecord.CurrentMedications.Split('|');
                        CMSplit = CMSplit.Take(CMSplit.Count() - 1).ToArray();

                        foreach (string CM in CMSplit)
                        {
                            Literal record4 = new Literal();
                            record4.Text = $"<span class='record-titlesnew'>Medication:</span> <span class='records ID'>{CM}</span>";

                            PlaceHolder4.Controls.Add(record4);
                        }

                        Diagnosis.Text = medicalRecord.Diagnosis.ToString();

                        string[] CSplit = medicalRecord.Comment.Split('|');
                        CSplit = CSplit.Take(CSplit.Count() - 1).ToArray();

                        foreach (string C in CSplit)
                        {
                            Literal record5 = new Literal();
                            record5.Text = $"<span class='record-titlesnew'>Comment:</span> <span class='records ID'>{C}</span>";

                            PlaceHolder5.Controls.Add(record5);
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